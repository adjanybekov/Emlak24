"use strict";
module.exports = function () {
  require('datatables.net-bs');
  require('datatables.net-responsive-bs');

  var $datatableModal = $('#modal-datatable-detail');

  $('.js-properties-table')
    .DataTable({
      paging: false,
      searching: false,
      info: false,
      responsive: true,
      columnDefs: [
        { responsivePriority: 1, targets: 0 },
        { responsivePriority: 2, targets: -1 }
      ]
    })
    .on('click', 'tbody tr', function (e) {
      if (e.target.tagName === 'A') return;
      var row = $(this);
      $datatableModal
        .modal('show')
        .on('shown.bs.modal', function (e) {
          $datatableModal.find('.modal-body').html($(row).data('info'));
        });
    });

  $('.js-property-table')
    .DataTable({
      paging: false,
      searching: false,
      info: false,
      scrollY: 500,
      responsive: true,
      columnDefs: [
        { responsivePriority: 1, targets: 0 },
        { responsivePriority: 2, targets: -1 }
      ]
    })
    .on('click', 'tbody tr', function (e) {
      if (e.target.tagName === 'A') return;
      var row = $(this);
      $datatableModal
        .modal('show')
        .on('shown.bs.modal', function () {
          $datatableModal.find('.modal-body').html($(row).data('info'));
        });
    });
};
