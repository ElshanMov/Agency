$(function ()
{
    $(document).on("click", ".delete-btn", function (e)
    {
        e.preventDefault();
        let href = $(this).attr("href")
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                fetch(href)
                    .then(respone => {
                        if (respone.ok) {

                            window.location.reload(true)
                        }
                        else {
                            alert("xetha bash verdi")
                        }
                    })                
            }
            else
            {
                console.log("cancel")
            }
        })
    })
})