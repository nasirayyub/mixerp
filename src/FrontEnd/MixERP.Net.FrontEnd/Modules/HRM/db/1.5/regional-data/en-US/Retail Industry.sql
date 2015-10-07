-->-->-- C:/Users/nirvan/Desktop/mixerp/0. GitHub/src/Modules/HRM/db/1.5/db/src/01.types-domains-tables-and-constraints/tables-and-constraints.sql --<--<--
/********************************************************************************
Copyright (C) MixERP Inc. (http://mixof.org).
This file is part of MixERP.
MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, version 2 of the License.
MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/

--The meaning of the following should not change
INSERT INTO hrm.employment_status_codes
SELECT -7, 'DEC', 'Deceased'                UNION ALL
SELECT -6, 'DEF', 'Defaulter'               UNION ALL
SELECT -5, 'TER', 'Terminated'              UNION ALL
SELECT -4, 'RES', 'Resigned'                UNION ALL
SELECT -3, 'EAR', 'Early Retirement'        UNION ALL
SELECT -2, 'RET', 'Normal Retirement'       UNION ALL
SELECT -1, 'CPO', 'Contract Period Over'    UNION ALL
SELECT  0, 'NOR', 'Normal Employment'       UNION ALL
SELECT  1, 'OCT', 'On Contract'             UNION ALL
SELECT  2, 'PER', 'Permanent Job'           UNION ALL
SELECT  3, 'RTG', 'Retiring';

INSERT INTO hrm.employment_statuses(employment_status_code, employment_status_name, default_employment_status_code_id, is_contract)
SELECT 'EMP', 'Employee',       0, false UNION ALL
SELECT 'INT', 'Intern',         1, true UNION ALL
SELECT 'CON', 'Contract Basis', 1, true UNION ALL
SELECT 'PER', 'Permanent',      2, false;

INSERT INTO hrm.job_titles(job_title_code, job_title_name)
SELECT 'INT', 'Internship'                      UNION ALL
SELECT 'DEF', 'Default'                         UNION ALL
SELECT 'EXC', 'Executive'                       UNION ALL
SELECT 'MAN', 'Manager'                         UNION ALL
SELECT 'GEM', 'General Manager'                 UNION ALL
SELECT 'BME', 'Board Member'                    UNION ALL
SELECT 'CEO', 'Chief Executive Officer'         UNION ALL
SELECT 'CTO', 'Chief Technology Officer';

INSERT INTO hrm.pay_grades(pay_grade_code, pay_grade_name, minimum_salary, maximum_salary)
SELECT 'L-1', 'Level 1', 0, 0;

INSERT INTO hrm.shifts(shift_code, shift_name, begins_from, ends_on)
SELECT 'MOR', 'Morning Shift',  '6:00'::time,   '14:00'::time   UNION ALL
SELECT 'DAY', 'Day Shift',      '14:00',        '20:00'         UNION ALL
SELECT 'NIT', 'Night Shift',    '20:00',        '6:00';

INSERT INTO hrm.employee_types(employee_type_code, employee_type_name, account_id)
SELECT 'DEF', 'Default',            core.get_account_id_by_account_number('20100') UNION ALL
SELECT 'OUE', 'Outdoor Employees',  core.get_account_id_by_account_number('20100') UNION ALL
SELECT 'PRO', 'Project Employees',  core.get_account_id_by_account_number('20100') UNION ALL
SELECT 'SUP', 'Support Staffs',     core.get_account_id_by_account_number('20100') UNION ALL
SELECT 'ENG', 'Engineers',          core.get_account_id_by_account_number('20100');

INSERT INTO hrm.salary_types(salary_type_code, salary_type_name, account_id)
SELECT 'BAS', 'Basic Salary',       core.get_account_id_by_account_number('43700') UNION
SELECT 'OTS', 'Overtime Salary',    core.get_account_id_by_account_number('43700') UNION ALL
SELECT 'COM', 'Commision',          core.get_account_id_by_account_number('43700') UNION ALL
SELECT 'EBE', 'Employee Benefits',  core.get_account_id_by_account_number('43700');

INSERT INTO hrm.leave_types(leave_type_code, leave_type_name)
SELECT 'NOR', 'Normal' UNION ALL
SELECT 'EME', 'Emergency' UNION ALL
SELECT 'ILL', 'Illness';

INSERT INTO hrm.exit_types(exit_type_code, exit_type_name)
SELECT 'COE', 'Contract Period Over' UNION ALL
SELECT 'RET', 'Retirement' UNION ALL
SELECT 'RES', 'Resignation' UNION ALL
SELECT 'TER', 'Termination' UNION ALL
SELECT 'DEC', 'Deceased';

INSERT INTO hrm.salary_frequencies(salary_frequency_id, frequency_id, salary_frequency_name)
SELECT 0, NULL::integer,    'Weekly' UNION ALL
SELECT 1, NULL,             'Biweekly' UNION ALL
SELECT 2, 2,                'Monhtly' UNION ALL
SELECT 3, 3,                'Quarterly' UNION ALL
SELECT 4, 4,                'Semi Annually' UNION ALL
SELECT 5, 5,                'Anually';


DO
$$
    DECLARE _employment_tax_id      integer;
    DECLARE _tax_authority_id       integer;
BEGIN
    SELECT tax_authority_id INTO _tax_authority_id
    FROM core.tax_authorities
    WHERE tax_authority_code = 'IRS';

    INSERT INTO hrm.employment_taxes(tax_authority_id, employment_tax_code, employment_tax_name)
    SELECT _tax_authority_id, 'USET', 'United States Employment Tax';

    SELECT employment_tax_id INTO _employment_tax_id
    FROM hrm.employment_taxes
    WHERE employment_tax_code = 'USET';

    INSERT INTO hrm.employment_tax_details(employment_tax_id, employment_tax_detail_code, employment_tax_detail_name, employee_tax_rate, employer_tax_rate)
    SELECT _employment_tax_id, 'SS', 'Social Security', 6.2,    6.2 UNION ALL
    SELECT _employment_tax_id, 'MC', 'Medicare',        1.45,   1.45;
END
$$
LANGUAGE plpgsql;

INSERT INTO hrm.salary_taxes(salary_tax_code, salary_tax_name, tax_authority_id, standard_deduction, personal_exemption)
SELECT 'SIN', 'Single Individual', core.get_tax_authority_id_by_tax_authority_code('IRS'), 6200, 3900 UNION ALL
SELECT 'MSF', 'Married (Separately Filing)', core.get_tax_authority_id_by_tax_authority_code('IRS'), 6200, 3900 UNION ALL
SELECT 'WID', 'Qualified Widower', core.get_tax_authority_id_by_tax_authority_code('IRS'), 12400, 3900 UNION ALL
SELECT 'HOH', 'Head of Household', core.get_tax_authority_id_by_tax_authority_code('IRS'), 9100, 3900;

INSERT INTO hrm.salary_tax_income_brackets(salary_tax_id, salary_from, salary_to, income_tax_rate)
SELECT hrm.get_salary_tax_id_by_salary_tax_code('SIN'), 1,      9225,           10 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('SIN'), 9225,   37450,          15 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('SIN'), 37450,  90750,          25 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('SIN'), 90750,  189300,         28 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('SIN'), 189300, 411500,         33 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('SIN'), 411500, 413200,         35 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('SIN'), 413200, NULL,           39.6;

INSERT INTO hrm.salary_tax_income_brackets(salary_tax_id, salary_from, salary_to, income_tax_rate)
SELECT hrm.get_salary_tax_id_by_salary_tax_code('MSF'), 1,      9225,           10 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('MSF'), 9225,   37450,          15 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('MSF'), 37450,  75600,          25 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('MSF'), 75600,  115225,         28 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('MSF'), 115225, 205750,         33 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('MSF'), 205750, 232425,         35 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('MSF'), 232425, NULL,           39.6;

INSERT INTO hrm.salary_tax_income_brackets(salary_tax_id, salary_from, salary_to, income_tax_rate)
SELECT hrm.get_salary_tax_id_by_salary_tax_code('WID'), 1,      18450,          10 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('WID'), 18450,  74900,          15 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('WID'), 74900,  151200,         25 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('WID'), 151200, 230450,         28 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('WID'), 230450, 411500,         33 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('WID'), 411500, 464850,         35 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('WID'), 464850, NULL,           39.6;

INSERT INTO hrm.salary_tax_income_brackets(salary_tax_id, salary_from, salary_to, income_tax_rate)
SELECT hrm.get_salary_tax_id_by_salary_tax_code('HOH'), 1,      13150,          10 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('HOH'), 13150,  50200,          15 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('HOH'), 50200,  129600,         25 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('HOH'), 129600, 209850,         28 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('HOH'), 209850, 411500,         33 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('HOH'), 411500, 439000,         35 UNION ALL
SELECT hrm.get_salary_tax_id_by_salary_tax_code('HOH'), 439000, NULL,           39.6;

INSERT INTO hrm.deduction_setups(deduction_setup_code, deduction_setup_name, account_id)
SELECT 'REN', 'Rent', core.get_account_id_by_account_number('20100') UNION ALL
SELECT 'BOR', 'Borrowings Deduction', core.get_account_id_by_account_number('10400') UNION ALL
SELECT 'FIC', 'Fitness Club', core.get_account_id_by_account_number('20100');

INSERT INTO hrm.wage_setup(wage_setup_code, wage_setup_name, currency_code, max_week_hours, hourly_rate, overtime_applicable, overtime_hourly_rate, expense_account_id)
SELECT 'NY-LIW', 'New York Living Wage', 'USD', 40, 14.30, true, 28.60, core.get_account_id_by_account_number('43800');