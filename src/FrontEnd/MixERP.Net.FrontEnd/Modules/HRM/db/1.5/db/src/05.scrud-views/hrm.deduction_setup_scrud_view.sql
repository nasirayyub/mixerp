DROP VIEW IF EXISTS hrm.deduction_setup_scrud_view;

CREATE VIEW hrm.deduction_setup_scrud_view
AS
SELECT
    hrm.deduction_setups.deduction_setup_id,
    hrm.deduction_setups.deduction_setup_code,
    hrm.deduction_setups.deduction_setup_name,
    core.accounts.account_number || ' (' || core.accounts.account_name || ')' AS account    
FROM hrm.deduction_setups
INNER JOIN core.accounts
ON core.accounts.account_id = hrm.deduction_setups.account_id;