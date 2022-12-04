
$.get('/api/hot-news', (data) => {
	const hot = $('#hot-news');
	data.forEach(item => {
		hot.append(`
<div class="single-blog-post post-style-2 d-flex align-items-center widget-post">
	<!-- Post Thumbnail -->
	<div class="post-thumbnail">
		<img src="${item?.media?.source}" alt="${item.media.altText}">
	</div>
	<!-- Post Content -->
	<div class="post-content">
		<a href="${item.slug}" class="headline">
			<h5 class="mb-0">${item.title}</h5>
		</a>
	</div>
</div>
		`);
	});
})

