$.getScript('/js/hot-news.js');
let page = 0;
const take = 4;
const getAllNews = () => {
	const allNews = $("#all_news");
	let delay = 0.1;
	$.get(`/api/news?page=${page}&take=${take}`, (data) => {
		if ((page === 0 && data.length === 0)) {
      allNews.empty();
      allNews.append(`
<div class="single-blog-post post-style-4 d-flex align-items-center wow fadeInUpBig"  data-wow-delay="${delay}s">
	<!-- Post Thumbnail -->
	<div class="post-thumbnail d-flex justify-content-center">
		<i class="bi bi-archive fa-5x"></i>
	</div>
	<!-- Post Content -->
	<div class="post-content">
		<h5>Trống</h5>
	</div>
</div>
			`);
      return;
		} 
		
		if (data.length === 0) {
			$("#alert")
        .removeClass()
        .addClass("alert alert-danger text-center inline-block hide")
        .text("Đã hết tin hiển thị !");
			$("#alert")
        .fadeTo(2000, 500)
        .slideUp(500, function () {
          $("#alert").slideUp(500);
        });
			return;
		}
		data.forEach(p => {
			allNews.append(`
<div class="single-blog-post post-style-4 d-flex align-items-center wow fadeInUpBig"  data-wow-delay="${delay}s">
	<!-- Post Thumbnail -->
	<div class="post-thumbnail">
		<img src="${p?.media?.source}" alt="${p?.media?.altText}">
	</div>
	<!-- Post Content -->
	<div class="post-content">
		<a href="${p?.slug}" class="headline">
			<h5>${p?.title}</h5>
		</a>
		<p>${p?.description}</p>
		<!-- Post Meta -->
		<div class="post-meta">
			<p class="post-date">${moment(p?.createdAt).format("lll")}</p>
		</div>
	</div>
</div>
			`);
			
		});
		delay += 0.05;
	});
}

const loadMore = () => {
	page += 1;
	getAllNews();
}

$("#load-more").on("click", loadMore);
getAllNews();