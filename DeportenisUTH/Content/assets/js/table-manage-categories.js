var handleDataTableDefault = function () {
    "use strict";

    if ($('#data-table-categories').length !== 0) {

        /Inicializar la tabla de marcas/
        var table = $('#data-table-categories').DataTable({
            "iDisplayLength": 10,
            serverSide: true,
            ajax: {
                url: $("#urlCategories").val(),
                dataSrc: 'data',
                type: 'POST'
            },
            drawCallback: function (settings) {
                $(".tooltips").tooltip({ placement: 'top' });
            },
            //data: data,
            "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
            columns: [
                {
                    "className": 'text-left',
                    "data": null,
                    "mRender": function (data, type, full) {
                        return '<a class="editBrand" style="color:#659be0 !important;" href="#">' + data.Name + '</a>';
                    }
                },
                {
                    "className": 'text-right',
                    "data": null,
                    "mRender": function (data, type, full) {
                        var date = new Date(data.LastUpdate).toISOString().slice(0, 10);
                        /// return moment(date).format('DD MMMM YYYY, h:mm a');
                        return date;
                    }
                },
                {
                    "className": 'details-control text-right',
                    "orderable": false,
                    "data": null,
                    "defaultContent": '',
                    "mRender": function (data, type, full) {
                        return '<button  data-placement="top" data-original-title="Editar"  class="btn  btn-secondary btn-circle editDataTable editBrand" attrtype="2"><i class="fa fa-edit" ></i></button> ' +
                            '<button  data-placement="top" data-original-title="Remover" class="btnDelete btn btn-secondary btn-circle editDataTable delBrand" attrtype="2"><i class="fa fa-times" ></i></button>';
                    }
                },
            ],
            dom: 'lBfrtip',
            "language": {
                //"url": $("#urlLanDataTables").val()

            },
            buttons: [
                { extend: 'excel', className: 'btn-sm hide dataTableExcel', text: '<i class="fa fa-file-excel-o fa-lg"></i>', titleAttr: 'Excel' }
            ],
            responsive: true
        });



        /Funcion para los botones de accion/

        $('#data-table-categories tbody').on('click', '.editBrand', function () {
            var data = table.row($(this).parents('tr')).data();
            window.location.href = $("#CategoriesEdit").val() + "?Id=" + data.Id;

        });

        $('#data-table-categories tbody').on('click', '.delBrand', function () {
            var data = table.row($(this).parents('tr')).data();
            swal(
                {
                    title: 'Quiere elimina este registro?',
                    text: "",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#e7505a',
                    cancelButtonColor: '#ccc',
                    confirmButtonText: 'Sí',
                    cancelButtonText: 'No'
                }, function () {
                    window.location.href = $("#CategoriesDelete").val() + "?Id=" + data.Id;
                }
            );


        });





    }
};


$(document).on("click", ".btnExport", function () {
    $(".dataTableExcel").click();
});


var TableManageDepartmentesDefault = function () {
    "use strict";
    return {
        //main function
        init: function () {
            handleDataTableDefault();
        }
    };
}();