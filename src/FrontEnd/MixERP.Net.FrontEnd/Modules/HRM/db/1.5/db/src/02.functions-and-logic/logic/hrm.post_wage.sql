DROP FUNCTION IF EXISTS hrm.post_wage
(
    _user_id                    integer,
    _as_of                      date,
    _employee_id                integer,
    _statement_reference        text,
    _regular_pay_rate           numeric,
    _overtime_pay_rate          numeric,
    _details                    hrm.wage_processing_details[]
);

CREATE FUNCTION hrm.post_wage
(
    _user_id                    integer,
    _as_of                      date,
    _employee_id                integer,
    _statement_reference        text,
    _regular_pay_rate           numeric,
    _overtime_pay_rate          numeric,
    _details                    hrm.wage_processing_details[]
)
RETURNS bigint 
AS
$$
BEGIN
    RAISE EXCEPTION 'Not implemented';
    RETURN 0;
END
$$
LANGUAGE plpgsql;
