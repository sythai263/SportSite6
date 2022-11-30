$(document).ready(function () {
	
	$.get('/api/home/hero', (data) => {
		const slide = $('.hero-slides.owl-carousel');
		
		data?.map((img) => {
			const id = `hero-${img?.id}`;
			slide.append(`<div class="single-hero-slide bg-img background-overlay" id="${id}"></div>`);
			$(`#${id}`).css('background-image', `url(${img?.source})`);
		})
	})
});
