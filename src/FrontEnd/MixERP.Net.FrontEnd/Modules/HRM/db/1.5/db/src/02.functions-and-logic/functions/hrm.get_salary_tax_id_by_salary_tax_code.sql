DROP FUNCTION IF EXISTS hrm.get_salary_tax_id_by_salary_tax_code(_salary_tax_code national character varying(12));
CREATE FUNCTION hrm.get_salary_tax_id_by_salary_tax_code(_salary_tax_code national character varying(12))
RETURNS integer
AS
$$
BEGIN
    RETURN salary_tax_id
    FROM hrm.salary_taxes
    WHERE salary_tax_code = $1;
END
$$
LANGUAGE plpgsql;