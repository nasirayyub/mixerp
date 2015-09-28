DROP VIEW IF EXISTS hrm.employment_tax_scrud_view;

CREATE VIEW hrm.employment_tax_scrud_view
AS
SELECT
    hrm.employment_taxes.employment_tax_id,
    hrm.employment_taxes.employment_tax_code,
    hrm.employment_taxes.employment_tax_name,
    core.tax_authorities.tax_authority_code || ' (' || core.tax_authorities.tax_authority_name || ')' AS tax_authority
FROM hrm.employment_taxes
INNER JOIN core.tax_authorities
ON hrm.employment_taxes.tax_authority_id = core.tax_authorities.tax_authority_id;

