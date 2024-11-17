$(document).ready(function () {
    // Reinitialize the slick slider after content load
    function initializeSlickSlider() {
        $('.product-slider').slick({
            autoplay: true,
            autoplaySpeed: 8000,
            slidesToShow: 5,
            rows: 2,
            dots: true,
            responsive: [
                { breakpoint: 1200, settings: { slidesToShow: 3 } },
                { breakpoint: 768, settings: { slidesToShow: 2 } },
                { breakpoint: 480, settings: { slidesToShow: 1 } },
                { breakpoint: 320, settings: { slidesToShow: 1 } }
            ]
        });
    }

    // Handle tab click and AJAX load
    $('.nav-link').on('click', function (e) {
        e.preventDefault();
        var categoryId = $(this).data('category-id');
        $.ajax({
            url: '/Home/GetProductsByCategory',
            type: 'GET',
            data: { categoryId: categoryId },
            success: function (result) {
                $('#category-content').html(result);
                initializeSlickSlider(); // Reinitialize slider
            },
            error: function () {
                alert('Failed to load products. Please try again.');
            }
        });
    });
});
