DROP VIEW IF EXISTS hrm.provident_fund_scrud_view;

CREATE VIEW hrm.provident_fund_scrud_view
AS
SELECT
    hrm.provident_funds.provident_fund_id,
    hrm.provident_funds.provident_fund_code,
    hrm.provident_funds.provident_fund_name,
    hrm.provident_funds.employee_contribution_rate::text || '%' AS employee_contribution_rate,
    hrm.provident_funds.employer_contribution_rate::text || '%' AS employer_contribution_rate,
    holding_account.account_number || ' (' || holding_account.account_name || ')' AS holiding_account,
    expense_account.account_number || ' (' || expense_account.account_name || ')' AS expense_account    
FROM hrm.provident_funds
INNER JOIN core.accounts AS holding_account
ON hrm.provident_funds.fund_holding_account_id = holding_account.account_id
INNER JOIN core.accounts AS expense_account
ON hrm.provident_funds.provident_fund_expense_account_id = expense_account.account_id;