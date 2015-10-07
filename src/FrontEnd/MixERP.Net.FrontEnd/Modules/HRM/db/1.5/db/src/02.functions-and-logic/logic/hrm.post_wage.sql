DROP FUNCTION IF EXISTS hrm.post_wage
(
    _user_id                                integer,
    _office_id                              integer,
    _login_id                               bigint,
    _as_of                                  date,
    _employee_id                            integer,
    _statement_reference                    text,
    _regular_hours                          numeric,
    _regular_pay_rate                       numeric,
    _overtime_hours                         numeric,
    _overtime_pay_rate                      numeric,
    _details                                hrm.wage_processing_details[]
);

CREATE FUNCTION hrm.post_wage
(
    _user_id                                integer,
    _office_id                              integer,
    _login_id                               bigint,
    _as_of                                  date,
    _employee_id                            integer,
    _statement_reference                    text,
    _regular_hours                          numeric,
    _regular_pay_rate                       numeric,
    _overtime_hours                         numeric,
    _overtime_pay_rate                      numeric,
    _details                                hrm.wage_processing_details[]
)
RETURNS bigint 
AS
$$
    DECLARE _value_date                     date;
    DECLARE _transaction_master_id          bigint;
    DECLARE _wage_processing_id             bigint;
    DECLARE _regular_pay                    numeric;
    DECLARE _overtime_pay                   numeric;
    DECLARE _total_pay                      numeric;
    DECLARE _expense_account_id             integer;
    DECLARE _posting_account_id             integer;
    DECLARE _wage_setup_id                  integer;
    DECLARE _currency_code                  varchar;
BEGIN    
    SELECT
        posting_account_id,
        wage_setup_id
    INTO
        _posting_account_id,
        _wage_setup_id
    FROM hrm.employee_wages
    WHERE employee_id = _employee_id;


    SELECT
        expense_account_id
    INTO
        _expense_account_id
    FROM hrm.wage_setup
    WHERE wage_setup_id = _wage_setup_id;


    DROP TABLE IF EXISTS temp_wage_processing_details;
    CREATE TEMPORARY TABLE temp_wage_processing_details
    ON COMMIT DROP
    AS
    SELECT * FROM unnest(_details);

    UPDATE temp_wage_processing_details
    SET pay_hours = hours_worked + ROUND((adjustment_minutes::numeric - lunch_deduction_minutes::numeric) / 60, 2);

    _value_date             :=  transactions.get_value_date(_office_id);
    _regular_pay            :=  ROUND(_regular_hours * _regular_pay_rate, 2);
    _overtime_pay           := _overtime_hours * _overtime_pay_rate, 2);
    _total_pay              := _regular_pay + _overtime_pay;
    _currency_code          :=  core.get_currency_code_by_office_id(_office_id);
    _transaction_master_id  :=  nextval(pg_get_serial_sequence('transactions.transaction_master', 'transaction_master_id'));
    
    INSERT INTO transactions.transaction_master
    (
        transaction_master_id, 
        transaction_counter, 
        transaction_code, 
        book, 
        value_date, 
        user_id, 
        login_id, 
        office_id, 
        reference_number, 
        statement_reference
    )
    SELECT 
        _transaction_master_id, 
        transactions.get_new_transaction_counter(_value_date), 
        transactions.get_transaction_code(_value_date, _office_id, _user_id, _login_id),
        'Wages',
        _value_date,
        _user_id,
        _login_id,
        _office_id,
        '',
        _statement_reference;

    INSERT INTO transactions.transaction_details(value_date, transaction_master_id, tran_type, account_id, statement_reference, currency_code, amount_in_currency, local_currency_code, er, amount_in_local_currency)
    SELECT _value_date, _transaction_master_id, 'Dr', _expense_account_id, _statement_reference, _currency_code, _total_pay, _currency_code, 1 AS exchange_rate, _total_pay UNION ALL
    SELECT _value_date, _transaction_master_id, 'Cr', _posting_account_id, _statement_reference, _currency_code, _total_pay, _currency_code, 1 AS exchange_rate, _total_pay;
    
    
    INSERT INTO hrm.wage_processing(transaction_master_id, employee_id, posted_till, regular_hours, regular_pay_rate, regular_pay, overtime_hours, overtime_pay_rate, overtime_pay, total_pay, audit_user_id)
    SELECT _transaction_master_id, _employee_id, _as_of, _regular_hours, _regular_pay_rate, _regular_pay, _overtime_hours, _overtime_pay_rate, _overtime_pay, _total_pay, _user_id
    RETURNING wage_processing_id INTO _wage_processing_id;

    INSERT INTO hrm.wage_processing_details(wage_processing_id, for_date, hours_worked, lunch_deduction_minutes, adjustment_minutes, pay_hours, audit_user_id)
    SELECT _wage_processing_id, for_date, hours_worked, lunch_deduction_minutes, adjustment_minutes, pay_hours, audit_user_id
    FROM temp_wage_processing_details;
    
    RETURN _wage_processing_id;
END
$$
LANGUAGE plpgsql;