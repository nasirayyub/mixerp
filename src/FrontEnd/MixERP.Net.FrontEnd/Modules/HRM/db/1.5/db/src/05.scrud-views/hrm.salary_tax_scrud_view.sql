DROP VIEW IF EXISTS hrm.salary_tax_scrud_view;

CREATE VIEW hrm.salary_tax_scrud_view
AS
SELECT
    hrm.salary_taxes.salary_tax_id,
    hrm.salary_taxes.salary_tax_code,
    hrm.salary_taxes.salary_tax_name,
    core.tax_authorities.tax_authority_code || ' (' || core.tax_authorities.tax_authority_name || ')' AS tax_authority,
    hrm.salary_taxes.standard_deduction,
    hrm.salary_taxes.personal_exemption
FROM hrm.salary_taxes
INNER JOIN core.tax_authorities
ON hrm.salary_taxes.tax_authority_id = core.tax_authorities.tax_authority_id;