import { Component, Injector, AfterViewInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PlanServiceProxy, PlanProjectServiceProxy, SpecialPlanServiceProxy, TaskBookServiceProxy, ListResultDtoOfPlanProjectCostStatistic, PlanProjectCostStatistic, SpecialPlanCostStatistic } from '@shared/service-proxies/service-proxies';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
    templateUrl: './home.component.html',
    animations: [appModuleAnimation()]
})
export class HomeComponent extends AppComponentBase implements AfterViewInit {

    cost: any[] = [];

    plancount: number = 0;
    planprojectcount: number = 0;
    specialplancount: number = 0;
    taskbookcount: number = 0;

    barlabels: string[] = new Array(6);
    barofplanproject: any[] = [];
    // planProjectBar: PlanProjectBar = null;

    id1: number = 0;
    id2: number = 0;
    id3: number = 0;
    id4: number = 0;
    id5: number = 0;
    id6: number = 0;


    thisyear: string = "";
    lastyear: string = "";
    beforelastyear: string = "";
    donutthisyear: any[] = [];
    donutlastyear: any[] = [];
    donutbeforelastyear: any[] = [];
    planProjectCostStatistic: PlanProjectCostStatistic = null;


    barlabels_s: string[] = new Array(3);
    barofspecialplan: any[] = [];

    ids1: number = 0;
    ids2: number = 0;
    ids3: number = 0;
    thisyear_s: string = "";
    lastyear_s: string = "";
    beforelastyear_s: string = "";
    donutthisyear_s: any[] = [];
    donutlastyear_s: any[] = [];
    donutbeforelastyear_s: any[] = [];
    specialPlanCostStatistic: SpecialPlanCostStatistic = null;

    constructor(
        injector: Injector,
        private _planService: PlanServiceProxy,
        private _planProjectService: PlanProjectServiceProxy,
        private _specialPlanService: SpecialPlanServiceProxy,
        private _taskbookService: TaskBookServiceProxy

    ) {
        super(injector);
    }

    ngAfterViewInit(): void {

        $(function () {
            //Widgets count
            $('.count-to').countTo();

            //Sales count to
            $('.sales-count-to').countTo({
                formatter: function (value, options) {
                    return '$' + value.toFixed(2).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, ' ').replace('.', ',');
                }
            });

            initRealTimeChart();
            initDonutChart();
            initSparkline();

        });

        this._planService.getPlansCount("").subscribe(result => {
            this.plancount = result;
        });

        this._planProjectService.getPlanProjectsCount("").subscribe(result => {
            this.planprojectcount = result;
        });

        this._specialPlanService.getSpecialPlansCount("", -1, "").subscribe(result => {
            this.specialplancount = result;
        });

        this._taskbookService.getTaskBooksCount("", -1, "", -1).subscribe(result => {
            this.taskbookcount = result;
        });

        this._planService.getPlanList("", "Id", 20, 0).finally(() => {

            $('#line_chart_plan').html('');
            ((window as any).Morris).Line({
                element: 'line_chart_plan',
                data: this.cost,
                xkey: 'year',
                ykeys: ['value'],
                labels: ['计划总成本'],
                yLabelFormat: function (y) { return y.toString() + '万元'; }
            });

        }).subscribe(result => {

            this.cost = [];

            result.forEach(element => {
                this.cost.push({ year: element.planYear, value: element.fundBudget });
            });
        });


        this._planProjectService.getStatisticCost().finally(() => {
            // start donut chart
            if (this.thisyear != '') {
                $('#donut_chart_thisyear').html('');
                ((window as any).Morris).Donut({
                    element: 'donut_chart_thisyear',
                    data: this.donutthisyear,
                    colors: ['rgb(233, 30, 99)', 'rgb(0, 188, 212)', 'rgb(255, 152, 0)', 'rgb(0, 150, 136)', 'rgb(96, 125, 139)', 'rgb(0, 25, 139)'],
                    formatter: function (y) {
                        return y + '万元'
                    }
                });
            }

            if (this.lastyear != '') {
                $('#donut_chart_lastyear').html('');
                ((window as any).Morris).Donut({
                    element: 'donut_chart_lastyear',
                    data: this.donutlastyear,
                    colors: ['rgb(233, 30, 99)', 'rgb(0, 188, 212)', 'rgb(255, 152, 0)', 'rgb(0, 150, 136)', 'rgb(96, 125, 139)', 'rgb(0, 25, 139)'],
                    formatter: function (y) {
                        return y + '万元'
                    }
                });
            }

            if (this.beforelastyear != '') {
                $('#donut_chart_beforelastyear').html('');
                ((window as any).Morris).Donut({
                    element: 'donut_chart_beforelastyear',
                    data: this.donutbeforelastyear,
                    colors: ['rgb(233, 30, 99)', 'rgb(0, 188, 212)', 'rgb(255, 152, 0)', 'rgb(0, 150, 136)', 'rgb(96, 125, 139)', 'rgb(0, 25, 139)'],
                    formatter: function (y) {
                        return y + '万元'
                    }
                });
            }
            // end donut chart

            // start bar chart
            $('#planproject_year_chart').html('');
            ((window as any).Morris).Bar({
                element: 'planproject_year_chart',
                data: this.barofplanproject,
                xkey: 'y',
                ykeys: ['id1', "id2", "id3", "id4", "id5", "id6"],
                labels: this.barlabels,
                yLabelFormat: function (y) { return y.toString() + '万元'; }
            });
            // end bar chart

        }).subscribe(result => {

            // start donut chart
            //this year
            if (result.items.length > 0) {
                this.planProjectCostStatistic = result.items[0];
                this.thisyear = this.planProjectCostStatistic.year;
                this.planProjectCostStatistic.items.forEach(element => {
                    this.donutthisyear.push({ label: element.planProjectTypeName, value: element.totalCost });
                });
            }

            //last year
            if (result.items.length > 1) {
                this.planProjectCostStatistic = result.items[1];
                this.lastyear = this.planProjectCostStatistic.year;
                this.planProjectCostStatistic.items.forEach(element => {
                    this.donutlastyear.push({ label: element.planProjectTypeName, value: element.totalCost });
                });
            }

            //before last year
            if (result.items.length > 2) {
                this.planProjectCostStatistic = result.items[2];
                this.beforelastyear = this.planProjectCostStatistic.year;
                this.planProjectCostStatistic.items.forEach(element => {
                    this.donutbeforelastyear.push({ label: element.planProjectTypeName, value: element.totalCost });
                });
            }
            //end donut chart

            // start bar
            if (result.items.length > 0) {
                result.items.forEach(element => {
                    // this.planProjectBar.y = element.year;
                    this.id1 = this.id2 = this.id3 = this.id4 = this.id5 = this.id6 = 0;

                    element.items.forEach(subelement => {
                        switch (subelement.planProjectTypeId) {
                            case 1:
                                this.id1 = subelement.totalCost;
                                this.barlabels[0] = subelement.planProjectTypeName;
                                break;
                            case 2:
                                this.id2 = subelement.totalCost;
                                this.barlabels[1] = subelement.planProjectTypeName;
                                break;
                            case 3:
                                this.id3 = subelement.totalCost;
                                this.barlabels[2] = subelement.planProjectTypeName;
                                break;
                            case 4:
                                this.id4 = subelement.totalCost;
                                this.barlabels[3] = subelement.planProjectTypeName;
                                break;
                            case 5:
                                this.id5 = subelement.totalCost;
                                this.barlabels[4] = subelement.planProjectTypeName;
                                break;
                            case 6:
                                this.id6 = subelement.totalCost;
                                this.barlabels[5] = subelement.planProjectTypeName;
                                break;

                        }

                    });
                    this.barofplanproject.push({ y: element.year, id1: this.id1, id2: this.id2, id3: this.id3, id4: this.id4, id5: this.id5, id6: this.id6 });
                });
            }
            // end bar chart

        });


        this._specialPlanService.getStatisticCost().finally(() => {
            // start donut chart
            if (this.thisyear_s != '') {
                $('#donut_chart_thisyear_s').html('');
                ((window as any).Morris).Donut({
                    element: 'donut_chart_thisyear_s',
                    data: this.donutthisyear_s,
                    colors: ['rgb(233, 30, 99)', 'rgb(0, 188, 212)', 'rgb(255, 152, 0)'],
                    formatter: function (y) {
                        return y + '万元'
                    }
                });
            }

            if (this.lastyear_s != '') {
                $('#donut_chart_lastyear_s').html('');
                ((window as any).Morris).Donut({
                    element: 'donut_chart_lastyear_s',
                    data: this.donutlastyear_s,
                    colors: ['rgb(233, 30, 99)', 'rgb(0, 188, 212)', 'rgb(255, 152, 0)'],
                    formatter: function (y) {
                        return y + '万元'
                    }
                });
            }

            if (this.beforelastyear_s != '') {
                $('#donut_chart_beforelastyear_s').html('');
                ((window as any).Morris).Donut({
                    element: 'donut_chart_beforelastyear_s',
                    data: this.donutbeforelastyear_s,
                    colors: ['rgb(233, 30, 99)', 'rgb(0, 188, 212)', 'rgb(255, 152, 0)'],
                    formatter: function (y) {
                        return y + '万元'
                    }
                });
            }
            // end donut chart

            // start bar chart
            $('#specialplan_year_chart').html('');
            ((window as any).Morris).Bar({
                element: 'specialplan_year_chart',
                data: this.barofspecialplan,
                xkey: 'y',
                ykeys: ['ids1', "ids2", "ids3"],
                labels: this.barlabels_s,
                yLabelFormat: function (y) { return y.toString() + '万元'; }
            });
            // end bar chart

        }).subscribe(result => {

            // start donut chart
            //this year
            if (result.items.length > 0) {
                // this.specialPlanCostStatistic = result.items[0];
                this.thisyear_s = result.items[0].year;
                result.items[0].items.forEach(element => {
                    this.donutthisyear_s.push({ label: element.specialPlanTypeName, value: element.totalCost });
                });
            }

            //last year
            if (result.items.length > 1) {
                // this.specialPlanCostStatistic = result.items[1];
                this.lastyear_s = result.items[1].year;
                result.items[1].items.forEach(element => {
                    this.donutlastyear_s.push({ label: element.specialPlanTypeName, value: element.totalCost });
                });
            }

            //before last year
            if (result.items.length > 2) {
                // this.specialPlanCostStatistic = result.items[2];
                this.beforelastyear_s = result.items[2].year;
                result.items[2].items.forEach(element => {
                    this.donutbeforelastyear_s.push({ label: element.specialPlanTypeName, value: element.totalCost });
                });
            }
            //end donut chart

            // start bar
            if (result.items.length > 0) {
                result.items.forEach(element => {
                    // this.planProjectBar.y = element.year;
                    this.ids1 =  this.ids2 = this.ids3 = 0;
                    element.items.forEach(subelement => {
                        
                        switch (subelement.specialPlanTypeId) {
                            case 1:
                                this.ids1 = subelement.totalCost;
                                this.barlabels_s[0] = subelement.specialPlanTypeName;
                                break;
                            case 2:
                                this.ids2 = subelement.totalCost;
                                this.barlabels_s[1] = subelement.specialPlanTypeName;
                                break;
                            case 3:
                                this.ids3 = subelement.totalCost;
                                this.barlabels_s[2] = subelement.specialPlanTypeName;
                                break;
                        }

                    });
                    this.barofspecialplan.push({ y: element.year, ids1: this.ids1, ids2: this.ids2, ids3: this.ids3 });
                });
            }
            // end bar chart

        });

        var realtime = 'on';
        function initRealTimeChart() {
            //Real time ==========================================================================================
            var plot = ($ as any).plot('#real_time_chart', [getRandomData()], {
                series: {
                    shadowSize: 0,
                    color: 'rgb(0, 188, 212)'
                },
                grid: {
                    borderColor: '#f3f3f3',
                    borderWidth: 1,
                    tickColor: '#f3f3f3'
                },
                lines: {
                    fill: true
                },
                yaxis: {
                    min: 0,
                    max: 100
                },
                xaxis: {
                    min: 0,
                    max: 100
                }
            });

            function updateRealTime() {
                plot.setData([getRandomData()]);
                plot.draw();

                var timeout;
                if (realtime === 'on') {
                    timeout = setTimeout(updateRealTime, 320);
                } else {
                    clearTimeout(timeout);
                }
            }

            updateRealTime();

            $('#realtime').on('change', function () {
                realtime = (this as any).checked ? 'on' : 'off';
                updateRealTime();
            });
            //====================================================================================================
        }

        function initSparkline() {
            $(".sparkline").each(function () {
                var $this = $(this);
                $this.sparkline('html', $this.data());
            });
        }

        function initDonutChart() {
            ((window as any).Morris).Donut({
                element: 'donut_chart',
                data: [{
                    label: 'Chrome',
                    value: 370
                }, {
                    label: 'Firefox',
                    value: 300
                }, {
                    label: 'Safari',
                    value: 180
                }, {
                    label: 'Opera',
                    value: 120
                },
                {
                    label: 'Other',
                    value: 30
                }],
                colors: ['rgb(233, 30, 99)', 'rgb(0, 188, 212)', 'rgb(255, 152, 0)', 'rgb(0, 150, 136)', 'rgb(96, 125, 139)'],
                formatter: function (y) {
                    return y + '万元'
                }
            });
        }

        var data = [], totalPoints = 110;
        function getRandomData() {
            if (data.length > 0) data = data.slice(1);

            while (data.length < totalPoints) {
                var prev = data.length > 0 ? data[data.length - 1] : 50, y = prev + Math.random() * 10 - 5;
                if (y < 0) { y = 0; } else if (y > 100) { y = 100; }

                data.push(y);
            }

            var res = [];
            for (var i = 0; i < data.length; ++i) {
                res.push([i, data[i]]);
            }

            return res;
        }
    }
}
