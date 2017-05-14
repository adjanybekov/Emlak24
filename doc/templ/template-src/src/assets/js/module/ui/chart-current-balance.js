"use strict";
module.exports = function () {
  var Chart = require('chart.js');
  var data = {
    labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun"],
    datasets: [
      {
        label: "My First dataset",
        fillColor: "rgba(220,220,220,0)",
        strokeColor: "red",
        pointColor: "red",
        //pointStrokeColor: "#fff",
        //pointHighlightFill: "#fff",
        //pointHighlightStroke: "rgba(220,220,220,1)",
        data: [65, 59, 80, 81, 56, 55]
      }
    ]
  };

  // Get the context of the canvas element we want to select
  var viewCurrentBalance = document.getElementById("current-balance");
  if (viewCurrentBalance) {
    var ctx = viewCurrentBalance.getContext("2d");
    var chartCurrentBalance = new Chart(ctx).Line(data, {
      scaleShowGridLines: false,
      scaleGridLineColor : "rgba(0,0,0,.05)"
    });
  }
};
