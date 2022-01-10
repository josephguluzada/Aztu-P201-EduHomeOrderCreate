$(function () {
    $(document).on("click", ".btn-modal-partial", function () {
        let id = $(this).attr("data-id");

        fetch(`/home/getpartial/${id}`)
            .then(response => response.text())
            .then(data => {

                console.log(data)
                $("#exampleModal .modal-content").html(data)
            })
        $("#exampleModal").modal("toggle")
    })

    $(document).on("click", ".addBasketBtn", function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        console.log(url)

        fetch(url)
            .then(response => {
                if (response.ok) {
                }
                else {
                    alert("Xeta bas verdi!")
                }
            })
    })
    $(document).on("click", ".basketModalBtn", function () {
        let id = $(this).attr("data-id");

        fetch(``)
            .then(response => response.text())
            .then(data => {

                console.log(data)
                //$("#exampleModal .modal-content").html(data)
            })
        $("#exampleModal").modal("toggle")
    })
})