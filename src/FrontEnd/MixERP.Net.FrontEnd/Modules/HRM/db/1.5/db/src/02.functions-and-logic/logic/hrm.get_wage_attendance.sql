DROP FUNCTION IF EXISTS hrm.get_wage_attendance
(
    _employee_id            integer,
    _as_of                  date
);

CREATE FUNCTION hrm.get_wage_attendance
(
    _employee_id            integer,
    _as_of                  date
)
RETURNS TABLE
(
    employee_id             integer,
    employee                text,
    regular_hours           integer,
    regular_pay             numeric,
    overtime_pay            numeric,
    photo                   text,
    attendance_date         date,
    hours_worked            numeric
)
AS
$$
    DECLARE _regular_hours  numeric;
    DECLARE _regular_pay    numeric;
    DECLARE _overtime_pay   numeric;
    DECLARE _last_paid_for  date;
    DECLARE _total_weeks    integer;
BEGIN
    SELECT
        max_week_hours,
        hourly_rate,
        overtime_hourly_rate
    INTO
        _regular_hours,
        _regular_pay,
        _overtime_pay
    FROM hrm.employee_wages
    WHERE hrm.employee_wages.employee_id = _employee_id
    AND valid_till >= _as_of
    AND is_active;

    IF(_regular_hours IS NULL) THEN
        RAISE EXCEPTION 'Cannot process wage. This employee does not have wage information setup.'
        USING ERRCODE='P2001';
    END IF;

    SELECT
        MAX(for_date)
    INTO
        _last_paid_for
    FROM hrm.wage_processing_details
    INNER JOIN hrm.wage_processing
    ON hrm.wage_processing.wage_processing_id = hrm.wage_processing_details.wage_processing_id
    WHERE hrm.wage_processing.employee_id = _employee_id;

    IF(_last_paid_for IS NULL) THEN
        SELECT
            MIN(hrm.attendances.attendance_date)
        INTO
            _last_paid_for
        FROM hrm.attendances
        WHERE hrm.attendances.employee_id = _employee_id;
    END IF;

    SELECT
        COUNT(DISTINCT date_trunc('week', series))
    INTO
        _total_weeks
    FROM generate_series(_last_paid_for, _as_of,interval '1 day') series;

    IF(_total_weeks > 0) THEN
        _regular_hours := _regular_hours * _total_weeks;
    END IF;

    DROP TABLE IF EXISTS _temp_wage_attendance;
    CREATE TEMPORARY TABLE _temp_wage_attendance
    (
        employee_id             integer,
        employee                text,
        regular_hours           integer,
        regular_pay             numeric,
        overtime_pay            numeric,
        photo                   text,
        attendance_date         date,
        hours_worked            numeric
    ) ON COMMIT DROP;

    INSERT INTO _temp_wage_attendance(employee_id, employee, photo, attendance_date, hours_worked)
    SELECT
        hrm.employees.employee_id,
        hrm.employees.employee_code || ' (' || hrm.employees.employee_name || ')' AS employee,
        hrm.employees.photo::text,
        hrm.attendances.attendance_date,
        ROUND((EXTRACT(EPOCH FROM hrm.attendances.check_out_time - check_in_time)/3600)::numeric, 2) AS hours_worked
    FROM hrm.attendances
    INNER JOIN hrm.employees
    ON hrm.employees.employee_id = hrm.attendances.employee_id
    WHERE hrm.attendances.attendance_date <= _as_of
    AND hrm.attendances.attendance_date > _last_paid_for
    AND was_present
    AND hrm.employees.employee_id = _employee_id;

    UPDATE _temp_wage_attendance
    SET
        regular_hours = _regular_hours,
        regular_pay = _regular_pay,
        overtime_pay = _overtime_pay;

    RETURN QUERY
    SELECT * FROM _temp_wage_attendance;
END
$$
LANGUAGE plpgsql;