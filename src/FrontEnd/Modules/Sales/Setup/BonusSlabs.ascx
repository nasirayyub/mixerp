<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BonusSlabs.ascx.cs"
    Inherits="MixERP.Net.Core.Modules.Sales.Setup.BonusSlabs" %>

<style>
    .disableClick {
        pointer-events: none;
    }
</style>


<script>
    var scrudFactory = new Object();

    scrudFactory.title = Resources.Titles.AgentBonusSlabs();

    scrudFactory.viewAPI = "/api/core/bonus-slab-scrud-view";
    scrudFactory.viewTableName = "core.bonus_slab_scrud_view";

    scrudFactory.formAPI = "/api/core/bonus-slab";
    scrudFactory.formTableName = "core.bonus_slabs";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];


    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;


    scrudFactory.live = "BonusSlabName";

    scrudFactory.queryStringKey = "BonusSlabId";

    scrudFactory.keys = [
        {
            property: "CheckingFrequencyId",
            url: '/api/core/frequency/display-fields',
            data: null,
            isArray: false,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "AccountId",
            url: '/api/core/bonus-slab-account-selector-view/display-fields',
            data: null,
            isArray: false,
            valueField: "Key",
            textField: "Value"
        }
    ];
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>
<script type="text/javascript">
    function customFormValidator() {
        var effectiveFromTextbox = $("#effective_from");
        var endsOnTextbox = $("#ends_on");

        var effectiveFrom = parseDate(effectiveFromTextbox.val());
        var endsOn = parseDate(endsOnTextbox.val());

        if (endsOn <= effectiveFrom) {
            makeDirty(endsOnTextbox);
            displayMessage(Resources.Warnings.InvalidDate());
            return false;
        };

        return true;
    };

</script>



