DROP VIEW IF EXISTS hrm.wage_posting_account_selector_view;

CREATE VIEW hrm.wage_posting_account_selector_view
AS
SELECT * FROM core.account_scrud_view
--Accounts Receivable, Accounts Payable
WHERE account_master_id = ANY(ARRAY[10110, 15010])
ORDER BY account_id;