var dataTable;

$(document).ready(function() {
  loadDataTable();
});

function loadDataTable() {
  dataTable = $('#DT_load').dataTable({
    "ajax": {
      "url": "/api/books",
      "type": "GET",
      "datatype": "json"
    },
    "columns": [
      { "data": "name", "width": "20%" },
      {
        "data": "id",
        "render": function(data) {
          return `<div class="text-center">
                    <a href="/Books/Upsert?id=${data}"
                      class="btn btn-success text-white"
                      style="cursor:pointer; width:70px">Edit</a>
                  </div>`;
        },
        "width": "40%"
      }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  });
}
