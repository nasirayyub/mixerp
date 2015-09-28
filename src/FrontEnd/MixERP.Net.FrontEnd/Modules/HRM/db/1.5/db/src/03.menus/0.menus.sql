--This table should not be localized.
SELECT * FROM core.recreate_menu('HRM', '~/Modules/HRM/Index.mix', 'HRM', 0, NULL);

SELECT * FROM core.recreate_menu('Tasks', NULL, 'HRMTA', 1, core.get_menu_id('HRM'));
SELECT * FROM core.recreate_menu('Attendance', '~/Modules/HRM/Tasks/Attendance.mix', 'ATTNDCE', 2, core.get_menu_id('HRMTA'));
SELECT * FROM core.recreate_menu('Employees', '~/Modules/HRM/Tasks/Employees.mix?View=kanban', 'EMPL', 2, core.get_menu_id('HRMTA'));
SELECT * FROM core.recreate_menu('Contracts', '~/Modules/HRM/Tasks/Contracts.mix', 'CTRCT', 2, core.get_menu_id('HRMTA'));
SELECT * FROM core.recreate_menu('Leave Application', '~/Modules/HRM/Tasks/LeaveApplications.mix', 'LEVAPP', 2, core.get_menu_id('HRMTA'));
SELECT * FROM core.recreate_menu('Resignations', '~/Modules/HRM/Tasks/Resignations.mix', 'RESIGN', 2, core.get_menu_id('HRMTA'));
SELECT * FROM core.recreate_menu('Terminations', '~/Modules/HRM/Tasks/Terminations.mix', 'TERMIN', 2, core.get_menu_id('HRMTA'));
SELECT * FROM core.recreate_menu('Exits', '~/Modules/HRM/Tasks/Exits.mix', 'EXIT', 2, core.get_menu_id('HRMTA'));

SELECT * FROM core.recreate_menu('Verification', NULL, 'HRMVER', 1, core.get_menu_id('HRM'));
SELECT * FROM core.recreate_menu('Verify Contracts', '~/Modules/HRM/Verification/Contracts.mix', 'VERCTRCT', 2, core.get_menu_id('HRMVER'));
SELECT * FROM core.recreate_menu('Verify Leave Applications', '~/Modules/HRM/Verification/LeaveApplications.mix', 'VERLEVAPP', 2, core.get_menu_id('HRMVER'));
SELECT * FROM core.recreate_menu('Verify Resignations', '~/Modules/HRM/Verification/Resignations.mix', 'VERRESIGN', 2, core.get_menu_id('HRMVER'));
SELECT * FROM core.recreate_menu('Verify Terminations', '~/Modules/HRM/Verification/Terminations.mix', 'VERTERMIN', 2, core.get_menu_id('HRMVER'));
SELECT * FROM core.recreate_menu('Verify Exits', '~/Modules/HRM/Verification/Exits.mix', 'VEREXIT', 2, core.get_menu_id('HRMVER'));


SELECT * FROM core.recreate_menu('Payroll', NULL, 'PAYRL', 1, core.get_menu_id('HRM'));
SELECT * FROM core.recreate_menu('Wages', '~/Modules/HRM/Payroll/Wages.mix', 'WAGES', 2, core.get_menu_id('PAYRL'));
SELECT * FROM core.recreate_menu('Overtime', '~/Modules/HRM/Payroll/Overtime.mix', 'OVERTM', 2, core.get_menu_id('PAYRL'));
SELECT * FROM core.recreate_menu('Deduction', '~/Modules/HRM/Payroll/Deduction.mix', 'OVERTM', 2, core.get_menu_id('PAYRL'));
SELECT * FROM core.recreate_menu('Salary', '~/Modules/HRM/Payroll/Salary.mix', 'SALRY', 2, core.get_menu_id('PAYRL'));
SELECT * FROM core.recreate_menu('Bonus', '~/Modules/HRM/Payroll/Bonus.mix', 'BONUS', 2, core.get_menu_id('PAYRL'));
SELECT * FROM core.recreate_menu('Commissions', '~/Modules/HRM/Payroll/Commissions.mix', 'COMMSN', 2, core.get_menu_id('PAYRL'));


SELECT * FROM core.recreate_menu('Setup & Maintenance', NULL, 'HRMSSM', 1, core.get_menu_id('HRM'));
SELECT * FROM core.recreate_menu('Salary Taxes', '~/Modules/HRM/Setup/SalaryTaxes.mix', 'SALTAX', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Salary Tax Income Brackets', '~/Modules/HRM/Setup/SalaryTaxIncomeBrackets.mix', 'STIBTAX', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Employment Taxes', '~/Modules/HRM/Setup/EmploymentTaxes.mix', 'EMPTAX', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Employment Tax Details', '~/Modules/HRM/Setup/EmploymentTaxDetails.mix', 'EMPTAXD', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Provident Funds', '~/Modules/HRM/Setup/ProvidentFunds.mix', 'PROFUN', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Holiday Setup', '~/Modules/HRM/Setup/HolidaySetup.mix', 'HOLDAY', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Salaries', '~/Modules/HRM/Setup/Salaries.mix', 'SETSAL', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Wages', '~/Modules/HRM/Setup/Wages.mix', 'SETWAGES', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Employment Statuses', '~/Modules/HRM/Setup/EmploymentStatuses.mix', 'EMPSTA', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Employee Types', '~/Modules/HRM/Setup/EmployeeTypes.mix', 'EMPTYP', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Education Levels', '~/Modules/HRM/Setup/EducationLevels.mix', 'EDULVL', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Job Titles', '~/Modules/HRM/Setup/JobTitles.mix', 'JOBTA', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Pay Grades', '~/Modules/HRM/Setup/PayGrades.mix', 'PATGR', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Salary Types', '~/Modules/HRM/Setup/SalaryTypes.mix', 'SALTYP', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Shifts', '~/Modules/HRM/Setup/Shifts.mix', 'SHIFT', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Office Hours', '~/Modules/HRM/Setup/OfficeHours.mix', 'OFFHRS', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Leave Types', '~/Modules/HRM/Setup/LeaveTypes.mix', 'LEVTYP', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Leave Benefits', '~/Modules/HRM/Setup/LeaveBenefits.mix', 'LEVBEN', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('Exit Types', '~/Modules/HRM/Setup/ExitTypes.mix', 'Exit Types', 2, core.get_menu_id('HRMSSM'));
SELECT * FROM core.recreate_menu('HRM Reports', NULL, 'HRMRPT', 1, core.get_menu_id('HRM'));


DELETE FROM policy.menu_access;
INSERT INTO policy.menu_access(office_id, menu_id, user_id)
SELECT office_id, menu_id, 2
FROM office.offices, core.menus;