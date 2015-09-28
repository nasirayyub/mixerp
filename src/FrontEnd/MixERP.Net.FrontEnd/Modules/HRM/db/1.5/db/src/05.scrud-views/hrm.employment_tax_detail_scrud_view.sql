DROP VIEW IF EXISTS hrm.employment_tax_detail_scrud_view;

CREATE VIEW hrm.employment_tax_detail_scrud_view
AS
SELECT
    hrm.employment_tax_details.employment_tax_detail_id,
    hrm.employment_taxes.employment_tax_code || ' (' || hrm.employment_taxes.employment_tax_name || ')' AS employment_tax,
    hrm.employment_tax_details.employment_tax_detail_code,
    hrm.employment_tax_details.employment_tax_detail_name,
    hrm.employment_tax_details.employee_tax_rate,
    hrm.employment_tax_details.employer_tax_rate
FROM hrm.employment_tax_details
INNER JOIN hrm.employment_taxes
ON hrm.employment_taxes.employment_tax_id = hrm.employment_tax_details.employment_tax_id;