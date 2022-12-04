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
			$("#alert").text("Đã đăng thành công !");
			$("#comment-post").empty();
			getAllComment();
      $("#alert")
        .fadeTo(2000, 500)
        .slideUp(500, function () {
          $("#alert").slideUp(500);
        });
    },
    error: function (xhr, ajaxOptions, thrownError) {
      alert(xhr.status);
      alert(thrownError);
    },
  });
	
});

let page = 0;
const take = 4;
const getAllComment = () => {
  const allNews = $("#comment-post");
  $.get(`/api/pages/${id}/comments?page=${page}&take=${take}`, (data) => {
    if (data.length === 0) {
      $("#alert").text("Đã hết bình luận !");
      $("#alert")
        .fadeTo(2000, 500)
        .slideUp(500, function () {
          $("#alert").slideUp(500);
        });
      return;
    }
		data.forEach((c) => {
			console.log(c?.user.name);
      allNews.append(`
<li class="single_comment_area">
	<!-- Comment Content -->
	<div class="comment-content">
		<!-- Comment Meta -->
		<div class="comment-meta d-flex align-items-center justify-content-between">
			<p class="post-author">${c?.user.name} <p class="post-author">${c?.createdAt}</p></p>
		</div>
		<p>${c?.content}</p>
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
