var slideIndex = 0;

$(document).foundation();

$(document).ready(function () {
    $('#suppliersTable').DataTable();
    $('#productTable').DataTable();
    $('#ordersTable').DataTable();
   

    if ($('#updateForm').length) {
        $('#updateForm').foundation('open');
    }

    if ($('#imgSlider').length)      
    {       
        carousel();
    }


});
$(".aantalTb").change(function () {
    $.post("/Order/UpdateRowAmount", { productId: this.id, aantal: this.value });

    location.reload();
});


$("#searchProductBtn").click(function () {
    var searchValue = $("#searchValue").val();
    window.location.href = "/Product/Search/" + searchValue;

});




function carousel() {
    var i;
    var x = document.getElementsByClassName("mySlides");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    slideIndex++;
    if (slideIndex > x.length) { slideIndex = 1 }
    x[slideIndex - 1].style.display = "block";
    setTimeout(carousel, 5000); 
}

