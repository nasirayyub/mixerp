DROP VIEW IF EXISTS core.item_variant_scrud_view;

CREATE VIEW core.item_variant_scrud_view
AS
SELECT
    core.item_variants.item_variant_id,
    core.item_variants.photo,
    core.item_variants.item_variant_code,
    core.item_variants.item_variant_name,
    core.items.item_code || ' (' || core.items.item_name || ')' AS item
FROM core.item_variants
INNER JOIN core.items
ON core.items.item_id = core.item_variants.item_id;
