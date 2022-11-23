$(document).ready(function () {
    CreateChart(moment().year())
})
function CreateChart(year) {
    $.ajax({
        type: 'POST',
        url: $('#getChartDataUrl').val(),
        data: { year: year },
        success: function (returnData) {
            new Chart($('#profitChart'), {
                type: 'bar',
                data: {
                    labels: ['Jan', 'Feb', 'Mar', 'Apr', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                    datasets: [{
                        data: returnData
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            })
        }
    })
}