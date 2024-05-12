$.fn.dataTable.Buttons.defaults.dom.button.className = 'btn btn-white btn-sm';
$(document).ready(function () {
    initializeDatatable();
})

function initializeDatatable() {
    $('.tbl-datatable').DataTable({
        pageLength: 25,
        responsive: true,
        dom: '<"html5buttons"B>lTfgitp',
        buttons: [
            { extend: 'copy' },
            { extend: 'csv' },
            { extend: 'excel', title: 'excel-download' },
            { extend: 'pdf', title: 'pdf-download' },

            {
                extend: 'print',
                customize: function (win) {
                    $(win.document.body).addClass('white-bg');
                    $(win.document.body).css('font-size', '10px');

                    $(win.document.body).find('table')
                        .addClass('compact')
                        .css('font-size', 'inherit');
                }
            }
        ]

    });
}


function getRandomGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

function ShowToastMessage(type, message) {
    $.notify(message, type);
}


function imagePreview(destinationSelector, input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            destinationSelector.attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}
