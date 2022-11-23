﻿var currentYear = moment().year()
var chartCtx;
$(document).ready(function () {
    $('#currYear').html(currentYear)
    CreateChart(currentYear)
})
function CreateChart(year) {
    $.ajax({
        type: 'POST',
        url: $('#getChartDataUrl').val(),
        data: { year: year },
        success: function (returnData) {
            chartCtx = new Chart($('#profitChart'), {
                type: 'bar',
                data: {
                    labels: ['Jan', 'Feb', 'Mar', 'Apr', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                    datasets: [{
                        data: returnData,
                        backgroundColor: '#bd8aff'
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    },
                    plugins: {
                        legend: {
                            display: false
                        }
                    }
                }
            })
        }
    })
}
function DecreaseYear() {
    currentYear -= 1
    $('#currYear').html(currentYear)
    UpdateChart(currentYear)
}
function IncreaseYear() {
    currentYear += 1
    $('#currYear').html(currentYear)
    UpdateChart(currentYear)
}
function UpdateChart(year) {
    chartCtx.destroy()
    CreateChart(year)
}