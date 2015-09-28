DROP VIEW IF EXISTS hrm.salary_tax_income_bracket_scrud_view;

CREATE VIEW hrm.salary_tax_income_bracket_scrud_view
AS
SELECT
    hrm.salary_tax_income_brackets.salary_tax_income_bracket_id,
    hrm.salary_taxes.salary_tax_code || ' (' || hrm.salary_taxes.salary_tax_name || ')' AS salary_tax,
    hrm.salary_tax_income_brackets.salary_from,
    hrm.salary_tax_income_brackets.salary_to,
    hrm.salary_tax_income_brackets.income_tax_rate::text || '%' AS income_tax_rate
FROM hrm.salary_tax_income_brackets
INNER JOIN hrm.salary_taxes
ON hrm.salary_tax_income_brackets.salary_tax_id = hrm.salary_taxes.salary_tax_id;
