DROP VIEW IF EXISTS hrm.deduction_account_selector_view;

CREATE VIEW hrm.deduction_account_selector_view
AS
SELECT * FROM core.account_scrud_view
--Accounts Receivable, Accounts Payable
WHERE account_master_id = ANY(ARRAY[10110, 15010])
ORDER BY account_id;
