"use strict";
module.exports = function () {
  var Chart = require('chart.js');
  var units = [
    {
      value: 957,
      color:"#43a047",
      highlight: "#43a047",
      label: "Total sold unit"
    },
    {
      value: 768,
      color: "#a5d6a7",
      highlight: "#a5d6a7",
      label: "Total unsold unit"
    }
  ];

  var price = [
    {
      value: 590,
      color:"#1e88e5",
      highlight: "#1e88e5",
      label: "Total sold price"
    },
    {
      value: 165,
      color: "#90caf9",
      highlight: "#90caf9",
      label: "Total unsold price"
    }
  ];

  // Get the context of the canvas element we want to select
  var viewUnits = document.getElementById("property-statistics-units");
  if (viewUnits) {
    var ctx = viewUnits.getContext("2d");
    new Chart(ctx).Doughnut(units, {
      segmentShowStroke : true,
      percentageInnerCutout : 90,
      segmentStrokeWidth : 1,
      animation: false
    });
  }

  // Get the context of the canvas element we want to select
  var viewPrice = document.getElementById("property-statistics-price");
  if (viewPrice) {
    var ctx2 = viewPrice.getContext("2d");
    new Chart(ctx2).Doughnut(price, {
      segmentShowStroke : true,
      percentageInnerCutout : 90,
      segmentStrokeWidth : 1,
      animation: false
    });
  }
};
