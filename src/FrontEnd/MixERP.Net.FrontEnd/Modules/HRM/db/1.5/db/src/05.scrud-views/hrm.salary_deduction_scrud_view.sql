DROP VIEW IF EXISTS hrm.salary_deduction_scrud_view;

CREATE VIEW hrm.salary_deduction_scrud_view
AS
SELECT
    hrm.salary_deductions.salary_deduction_id,
    hrm.employees.employee_code || ' (' || hrm.employees.employee_name || ')' AS employee,
    hrm.employees.photo,
    hrm.deduction_setups.deduction_setup_code || ' (' || hrm.deduction_setups.deduction_setup_name || ')' AS deduction_setup,
    hrm.salary_deductions.currency_code,
    hrm.salary_deductions.amount,
    hrm.salary_deductions.begins_from,
    hrm.salary_deductions.ends_on
FROM hrm.salary_deductions
INNER JOIN hrm.employees
ON hrm.employees.employee_id = hrm.salary_deductions.employee_id
INNER JOIN hrm.deduction_setups
ON hrm.deduction_setups.deduction_setup_id = hrm.salary_deductions.deduction_setup_id;