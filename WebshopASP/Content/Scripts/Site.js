$(document).foundation();

$(document).ready(function () {
    $('#suppliersTable').DataTable();
    $('#productTable').DataTable();
    $('#updateForm').foundation('open');
});

$(".aantalTb").change(function() {
    $.post("/Order/UpdateRowAmount", { productId: this.id, aantal: this.value });

    location.reload();
});