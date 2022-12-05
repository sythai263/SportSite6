$.getScript("/js/hot-news.js");
const id = $("#id-single-post").text();

$.get(`/api/pages/${id}/contents`, (data) => {
	const contents = $("#content-post");
	let i = 0;
	let bold = "font-weight-bold";
	data.forEach((content) => {
		if (i !== 0) {
			bold = "";
		}
    const id = `content-${content?.id}`;
    contents.append(`
<div id="${id}">
	<h6 class='${bold}'>${content?.information}</h6>
</div>
		`);
		i+=1;
    if (content.mediaID) {
      const media = content.media;
      if (media.mediaType == 2) {
				$(`#${id}`).append(`
<div class="text-center">
	<audio id="audio" preload="true" controls>
		<source src="${media.source}">
	</audio>
</div>

`);
			} else if (media.mediaType == 0) {
				$(`#${id}`).append(`
<div class="embed-responsive embed-responsive-16by9">
  <iframe class="embed-responsive-item" src="${media.source}"></iframe>
</div>
`);
      } else {
        $(`#${id}`).append(`
<img class="img-fluid" src="${media?.source}" alt="${media?.altText}"/>
<p class="text-center text-muted"><em>${media?.title}</em></p>
			`);
      }
    }
  });
});


$.get(`/api/pages/${id}/related`, (data) => {
	const related = $(`#related-post`);
	if (data.length == 0) {
		related.append(`
<div class ="col-12 col-lg-8" >
	<div class="single-blog-post post-style-4 d-flex align-items-center wow fadeInUpBig" >
		<!-- Post Thumbnail -->
		<div class="post-thumbnail d-flex justify-content-center">
			<i class="bi bi-archive fa-5x"></i>
		</div>
		<!-- Post Content -->
		<div class="post-content">
			<h5>Trống</h5>
		</div>
	</div>
</div>
		`);
		return;
	}
	data.forEach(item => {
		related.append(`
<div class="col-12 col-md-6 col-lg-4">
	<div class="single-blog-post">
		<div class="post-thumbnail">
			<img src="${item?.media?.source}" alt="">
			<div class="post-cta"><a href="#">${item?.category?.title}</a></div>
		</div>
		<div class="post-content">
			<a href="${item?.slug}" class="headline">
				<h5>${item?.title}</h5>
			</a>
			<p>${item?.description}</p>
			<div class="post-meta">
				<p class="post-author"> <i class="bi bi-eye-fill"></i> ${item?.views} lượt xem</p>
			</div>
		</div>
	</div>
</div>
		`);
	});
});

$("#form-comment").submit(function (event) {
	event.preventDefault();
	const data = {}
	data.name = $('input[name="name"]').val();
	data.email = $('input[name="email"]').val();
	data.content = $('textarea[name="content"]').val();
	data.pageID = id;
	console.log(data);
	$.ajax({
    type: "POST",
    url: "/api/comments",
    data,
    success: (data) => {
			$("#alert")
        .removeClass()
        .addClass("alert alert-success text-center inline-block hide")
        .text("Đã đăng thành công !");
			$("#comment-post").empty();
			$("#form-comment").trigger("reset");
			getAllComment();
      $("#alert")
        .fadeTo(2000, 500)
        .slideUp(500, function () {
          $("#alert").slideUp(500);
        });
    },
    error:  ()=> {
      $("#alert")
        .removeClass()
        .addClass("alert alert-danger text-center inline-block hide")
        .text("Đăng thất bại, thử lại !");
      getAllComment();
      $("#alert")
        .fadeTo(2000, 500)
        .slideUp(500, function () {
          $("#alert").slideUp(500);
        });
    },
  });
	
});

let page = 0;
const take = 4;
const getAllComment = () => {
  const allNews = $("#comment-post");
	$.get(`/api/pages/${id}/comments?page=${page}&take=${take}`, (data) => {
		if ((page === 0 && data.length === 0)) {
      allNews.empty();
      allNews.append(`
<li class="single_comment_area">
	<!-- Comment Content -->
	<div class="comment-content">
		<!-- Comment Meta -->
		<div class="comment-meta d-flex align-items-center justify-content-between">
			<p class="post-author"></p>
		</div>
		<h5 class="font-weight-bold">Chưa có bình luận nào</h5>
	</div>
</li>
			`);
      return;
    }
    if (data.length === 0) {
      $("#alert")
        .removeClass()
        .addClass("alert alert-danger text-center inline-block hide")
        .text("Đã hết bình luận !");
      $("#alert")
        .fadeTo(2000, 500)
        .slideUp(500, function () {
          $("#alert").slideUp(500);
        });
      return;
    }
		data.forEach((c) => {
      allNews.append(`
<li class="single_comment_area">
	<!-- Comment Content -->
	<div class="comment-content">
		<!-- Comment Meta -->
		<div class="comment-meta d-flex align-items-center justify-content-between">
			<p class="post-author">${c?.user?.name} đã đăng bình luận lúc ${moment(c?.createdAt).format('lll')}</p>
			<a href="#" class="comment-reply btn world-btn">Reply</a>
		</div>
		<h5 class="font-weight-bold">${c?.content}</h5>
	</div>
</li>
			`);
    });
    
  });
};

const loadMoreComment = () => {
  page += 1;
  getAllComment();
};
getAllComment();

$("#load-more").on("click", loadMoreComment);
