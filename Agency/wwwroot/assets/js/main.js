window.onscroll = function () {
  scrollFunction();
};

function scrollFunction() {
  if (document.documentElement.scrollTop > 80) {
    document.getElementById("blacknav").style.backgroundColor = "transparent";
  }
}

$(function () {
    $(document).on("click", ".hover-btn", function ()
    {
        var id = $(this).attr("data-id");

        fetch(`/home/getportfolio/${id}`)
            .then(response => response.text())

            .then(data =>
            {
                console.log(data)
                $("#portfolioModal .modal-content").html(data)
            })



        $("#portfolioModal").modal("show");
    })
});
