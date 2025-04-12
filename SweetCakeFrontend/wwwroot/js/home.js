$(document).ready(function () {
    var currentSlide = localStorage.getItem('currentSlide') || 0;

    var slickBanner = $('.banner').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 2000,
        initialSlide: parseInt(currentSlide),
    });

    slickBanner.on('afterChange', function (event, slick, currentSlide) {
        localStorage.setItem('currentSlide', currentSlide);
    });

    window.clearAuthData = function () {
        localStorage.removeItem('authToken');
        localStorage.removeItem('userEmail');
    };
});

