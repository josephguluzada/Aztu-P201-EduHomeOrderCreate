$(function () {
    $(document).on("click", ".image-delete-btn", function () {
        $(".image-box").remove();
        $(".image-box-index").remove();
    })
})