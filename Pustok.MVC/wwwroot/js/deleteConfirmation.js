document.addEventListener("DOMContentLoaded", () => {
    const deleteButtons = document.querySelectorAll(".delete-btn");

    deleteButtons.forEach(button => {
        button.addEventListener("click", (e) => {
            e.preventDefault();

            const deleteUrl = button.getAttribute("data-url");

            Swal.fire({
                title: 'Are you sure?',
                text: "You won't be able to undo this!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.isConfirmed) {
                    // Proceed with deletion
                    fetch(deleteUrl, {
                        method: 'POST', // Or 'DELETE' depending on your API
                        headers: {
                            'Content-Type': 'application/json',
                            'X-CSRF-TOKEN': document.querySelector('input[name="__RequestVerificationToken"]').value
                        }
                    })
                        .then(response => {
                            if (response.ok) {
                                Swal.fire(
                                    'Deleted!',
                                    'Your item has been deleted.',
                                    'success'
                                ).then(() => location.reload()); // Refresh page or remove item from UI
                            } else {
                                Swal.fire(
                                    'Error!',
                                    'There was an error deleting the item.',
                                    'error'
                                );
                            }
                        });
                }
            });
        });
    });
});
