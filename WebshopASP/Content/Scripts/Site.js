$(document).foundation();

$(document).ready(function () {
    $('#productTable').DataTable();
});

$(".aantalTb").change(function() {
    $.post("/Order/UpdateRowAmount", { productId: this.id, aantal: this.value });

    location.reload();
});