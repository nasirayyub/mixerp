<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Wages.ascx.cs" Inherits="MixERP.Net.Core.Modules.HRM.Payroll.Wages" %>
<div id="WageController" data-ng-controller="WageController" data-ng-cloak="">
    <div class="ui grey huge header">{{getResource('Resources.Titles.WageProcessing')}}</div>
    <style>
        @media only screen and (min-width: 768px) {
            .payroll.table {
                max-width: 1100px !important;
            }
        }
    </style>
    <div class="ui divider"></div>

    <div class="ui form bpad8">
        <div class="fields">
            <div class="two wide field">
                <label for="AsOfDateInputText">{{getResource('Resources.Titles.Date')}}</label>
                <input id="AsOfDateInputText" type="text" class="date" value="5d" />
            </div>
            <div class="four wide field">
                <label for="EmployeeSelect">{{getResource('Resources.Titles.Employee')}}</label>
                <select id="EmployeeSelect" class="ui search fluid dropdown"></select>
            </div>
            <div class="one wide field">
                <label>&nbsp;</label>
                <input type="button" class="ui basic button" value="{{getResource('Resources.Titles.Show')}}" data-ng-click="show();" />
            </div>
        </div>
    </div>

    <div id="WagePanel" style="display: none;">
        <table class="ui payroll collapsing bordered basic table padded attached segment"
            data-employee-id="{{EmployeeId}}">
            <thead>
                <tr>
                    <th colspan="5">
                        <div class="ui grey header">
                            <img class="ui tiny middle aligned bordered rounded circular image"
                                data-ng-src="/api/core/attachment/document/272/272/{{Photo}}" />
                            {{Employee}}
                        </div>
                    </th>
                </tr>
                <tr class="warning">
                    <th>
                        <i class="ui calendar icon"></i>
                        {{getResource('Resources.Titles.Date')}}
                    </th>
                    <th class="right aligned">
                        <i class="icons">
                            <i class="time icon"></i>
                            <i class="corner add icon"></i>
                        </i>
                        {{getResource('Resources.Titles.HoursWorked')}}
                    </th>
                    <th class="right aligned">
                        <i class="ui food icon"></i>
                        {{getResource('Resources.Titles.LunchDeduction')}}
                    
                    </th>
                    <th class="right aligned">
                        <i class="ui add square icon"></i>
                        {{getResource('Resources.Titles.Adjustment')}}
                    
                    </th>
                    <th class="right aligned">
                        <i class="ui time icon"></i>
                        {{getResource('Resources.Titles.PayHours')}}
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr data-ng-repeat="attendance in attendances">
                    <td>{{attendance.AttendanceDate.toString().toFormattedDate()}}</td>
                    <td class="right aligned attendance" data-hours-worked="{{attendance.HoursWorked}}">{{attendance.HoursWorked.toString().toFormattedHours()}}
                    </td>
                    <td class="collapsing">
                        <div class="ui tiny right labeled input ">
                            <input type="text" class="integer lunch right aligned deduction" />
                            <div class="ui basic label">
                                {{getResource('Resources.Labels.MinutesAbbreviate')}}
                            </div>
                        </div>
                    </td>
                    <td class="collapsing">
                        <div class="ui tiny right labeled input ">
                            <input type="text" class="integer right aligned adjustment" />
                            <div class="ui basic label">
                                {{getResource('Resources.Labels.MinutesAbbreviate')}}
                            </div>
                        </div>
                    </td>
                    <td class="right aligned hours worked" data-pay-hours="{{attendance.HoursWorked}}">{{attendance.HoursWorked.toString().toFormattedHours()}}
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <th colspan="2" class="right aligned">
                        <div class="ui small header">
                            {{getResource('Resources.Titles.RunningTotal')}}
                        </div>
                    </th>
                    <th>
                        <div class="ui tiny right labeled disabled input">
                            <input type="text" class="running total lunch deduction right aligned integer" readonly="readonly" />
                            <div class="ui basic label">
                                {{getResource('Resources.Labels.MinutesAbbreviate')}}
                            </div>
                        </div>
                    </th>
                    <th>
                        <div class="ui tiny right labeled disabled input">
                            <input type="text" class="running total adjustment right aligned integer" readonly="readonly" />
                            <div class="ui basic label">
                                {{getResource('Resources.Labels.MinutesAbbreviate')}}
                            </div>
                        </div>
                    </th>
                    <th class="right aligned">
                        <div class="ui running total hours small header"></div>
                    </th>
                </tr>
                <tr>
                    <th colspan="2" class="right aligned">
                        <div class="ui small grey header">
                            {{getResource('Resources.Titles.RegularWage')}}
                        </div>
                    </th>
                    <th>
                        <div class="ui small header">
                            {{getResource('Resources.Titles.RegularHours')}}
                        </div>
                        <div class="ui tiny right labeled disabled input">
                            <input type="text" class="regular hours right aligned decimal" readonly="readonly" />
                            <div class="ui basic label">
                                {{getResource('Resources.Labels.HoursAbbreviated')}}
                            </div>
                        </div>
                    </th>
                    <th>
                        <div class="ui small header">
                            {{getResource('Resources.Titles.PayRate')}}
                        </div>
                        <div class="ui tiny fluid input ">
                            <input type="text" class="regular pay right aligned decimal" value="{{RegularPay}}" />
                        </div>
                    </th>
                    <th>
                        <div class="ui small header">
                            {{getResource('Resources.Titles.Wage')}}
                        </div>
                        <div class="ui tiny right labeled disabled input">
                            <input type="text" class="regular wage right aligned currency" readonly="readonly" />
                        </div>
                    </th>
                </tr>
                <tr class="warning">
                    <th colspan="2" class="right aligned">
                        <div class="ui small header">
                            {{getResource('Resources.Titles.OvertimeWage')}}
                        </div>
                    </th>
                    <th>
                        <div class="ui small header">
                            {{getResource('Resources.Titles.OvertimeHours')}}
                        </div>
                        <div class="ui tiny right labeled disabled input">
                            <input type="text" class="overtime hours right aligned decimal" readonly="readonly" />
                            <div class="ui basic label">
                                {{getResource('Resources.Labels.HoursAbbreviated')}}
                            </div>
                        </div>
                    </th>
                    <th>
                        <div class="ui small header">
                            {{getResource('Resources.Titles.PayRate')}}
                        </div>
                        <div class="ui tiny fluid input ">
                            <input type="text" class="overtime pay right aligned currency" value="{{OvertimePay}}" />
                        </div>
                    </th>
                    <th>
                        <div class="ui small header">
                            {{getResource('Resources.Titles.Wage')}}
                        </div>
                        <div class="ui tiny right labeled disabled input">
                            <input type="text" class="overtime wage right aligned currency" readonly="readonly" />
                        </div>
                    </th>
                </tr>
                <tr>
                    <th colspan="4">
                        <div class="ui tiny fluid input">
                            <input type="text" id="StatementReferenceInputText" class="statement reference" placeholder="{{getResource('Resources.Titles.StatementReference')}}" />
                        </div>                        
                    </th>
                    <th class="right aligned">
                        <div class="ui grand total huge grey header"></div>
                    </th>
                </tr>
            </tfoot>
        </table>

        <div class="bpad8"></div>
        <div class="ui buttons">
            <a href="javascript:void(0);" class="ui teal button" data-ng-click="processWage();">{{getResource('Resources.Titles.ProcessWage')}}
            </a>
            <a href="javascript:void(0);" class="ui basic teal button">{{getResource('Resources.Titles.CreatePayslips')}}
            </a>
        </div>
        {{success()}}
    </div>
</div>

<script>
    function getWageAttendance(employeeId, asOf) {
        var url = "/api/hrm/procedures/get-wage-attendance/execute";
        var annotation = {
            EmployeeId: employeeId,
            AsOf: asOf
        };

        var data = JSON.stringify(annotation);

        return window.getAjaxRequest(url, "POST", data);
    };

    MixERPApp.controller("WageController", function ($scope, $sce, $window, $timeout) {
        $window.ajaxDataBind("/api/hrm/employee-view/display-fields", $("#EmployeeSelect"), null, null, null, function () {
            $timeout(function() {
                $("#EmployeeSelect").dropdown("set selected", "2");
                $scope.show();
            });
        }, "Key", "Value");

        $scope.show = function () {
            var employeeId = $("#EmployeeSelect").val();

            if (!employeeId) {
                $window.makeDirty($("#EmployeeSelect"));
                return;
            };

            $window.removeDirty($("#EmployeeSelect"));

            var asOf = $window.parseLocalizedDate($("#AsOfDateInputText").val());
            var getWageAttendanceAjax = getWageAttendance(employeeId, asOf);

            getWageAttendanceAjax.success(function (msg) {
                $scope.$apply(function () {
                    $scope.EmployeeId = msg[0].EmployeeId;
                    $scope.Employee = msg[0].Employee;
                    $scope.Photo = msg[0].Photo;
                    $scope.RegularHours = msg[0].RegularHours;
                    $scope.RegularPay = msg[0].RegularPay;
                    $scope.OvertimePay = msg[0].OvertimePay;

                    $scope.attendances = msg;
                    $("#WagePanel").fadeIn(1000);
                });
            });
        };

        $scope.getResource = function (func) {
            return $window.executeFunctionByName(func, $window);
        };

        function getSumOf(selector, attr) {
            var sum = 0;
            $(selector).each(function () {
                if (attr === "val") {
                    sum += parseFloat($(this).val() || 0);
                } else {
                    sum += parseFloat($(this).attr(attr) || 0);
                }
            });

            return sum;
        };

        function calculateRunningTotals() {
            var totalLunchDeductionEl = $("input.running.total.lunch.deduction");
            var totalAdjustmentEl = $("input.running.total.adjustment");
            var totalHourEl = $("div.running.total.hours.small.header");

            totalLunchDeductionEl.val(getSumOf(".lunch.deduction:not(.running.total)", "val"));
            totalAdjustmentEl.val(getSumOf(".adjustment:not(.running.total)", "val"));

            var totalHours = getSumOf(".hours.worked:not(.running.total)", "data-pay-hours");
            totalHourEl.attr("data-pay-hours", totalHours);
            totalHourEl.html(totalHours.toFixed(2).toString().toFormattedHours());

            var regularHours = totalHours;
            var overtimeHours = 0;

            if (regularHours > $scope.RegularHours) {
                regularHours = $scope.RegularHours;
                overtimeHours = totalHours - $scope.RegularHours;
            };

            $('input.regular.hours[readonly]').val(regularHours);
            $('input.overtime.hours[readonly]').val(overtimeHours);

            var regularPayRate = $("input.regular.pay").val();
            var regularPay = regularPayRate * regularHours;

            $("input.regular.wage[readonly]").val(regularPay);

            var overtimePayRate = $("input.overtime.pay").val();
            var overtimePay = overtimePayRate * overtimeHours;
            var totalPay = regularPay + overtimePay;

            $("input.overtime.wage[readonly]").val(overtimePay);

            $(".grand.total").html($window.currencySymbol + totalPay.toFixed(2));
            $(".grand.total").attr("data-grand-total", totalPay.toFixed(2));
        };

        function calculatePayHours(el) {
            el = $(el);
            var container = el.closest("tr");

            var worked = parseFloat(container.find("td.attendance").attr("data-hours-worked") || 0);
            var lunch = parseInt(container.find(".lunch.deduction").val() || 0);
            var adjustment = parseInt(container.find(".adjustment").val() || 0);

            var totalAdjustment = (adjustment - lunch) / 60;
            var payHours = (worked + totalAdjustment).toFixed(2);

            var target = container.find("td.hours.worked");

            target.attr("data-pay-hours", payHours);

            target.html(payHours.toString().toFormattedHours());
            calculateRunningTotals();
        };

        $scope.success = function () {
            $timeout(function () {
                calculateRunningTotals();
                $(".lunch.deduction").blur(function () {
                    calculatePayHours(this);
                });

                $(".adjustment").blur(function () {
                    calculatePayHours(this);
                });
            }, 500);
        };

        $scope.processWage = function() {            
            function ajax(annotation) {
                var url = "/api/hrm/procedures/post-wage/execute";
                var data = JSON.stringify(annotation);

                return $window.getAjaxRequest(url, "POST", data);
            };

            var asOf = window.parseLocalizedDate($("#AsOfDateInputText").val());
            var employeeId = $("#EmployeeSelect").val();
            var statementReference = $("#StatementReferenceInputText").val();
            var regularPayRate = $("input.regular.pay").val();
            var overtimePayRate = $("input.overtime.pay").val();

            var details = [];
            $("#WagePanel table tbody tr").each(function() {
                var el = $(this);
                var hoursWorked = parseFloat(el.find("td:nth-child(2)").attr("data-hours-worked") || 0);
                var lunchDeductionMinutes = parseFloat(el.find("td:nth-child(3) input").val() || 0);
                var adjustmentMinutes = parseFloat(el.find("td:nth-child(4) input").val() || 0);
                var totalAdjustment = (adjustmentMinutes - lunchDeductionMinutes) / 60;
                var payHours = (hoursWorked + totalAdjustment).toFixed(2);

                var detail = {
                    ForDate: asOf,
                    HoursWorked: hoursWorked,
                    LunchDeductionMinutes: lunchDeductionMinutes,
                    AdjustmentMinutes: adjustmentMinutes,
                    PayHours: payHours
                };

                

                details.push(detail);
            });
    
            var annotation = {
                UserId: $window.userId,
                AsOf: asOf,
                EmployeeId: employeeId,
                StatementReference: statementReference,
                RegularPayRate: regularPayRate,
                OvertimePayRate: overtimePayRate,
                Details: details
            };

            var request = ajax(annotation);

            request.success(function(msg) {
                alert(msg);
            });


        };
    });
</script>
