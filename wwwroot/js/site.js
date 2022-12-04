$(document).ready(function () {
  $.get('/data/menu.json', (data) => {
    const navbar = $('#worldNav>ul');
    data.map((nav) => {
      if (!nav.subMenu) {
        navbar.append(`	<li class="nav-item">
    						<a class="nav-link" href="${nav.slug}">${nav.display}</a>
						</li>`);
      } else {
        const li = $('<li class="nav-item dropdown"></li>');
        const subMenu = nav.subMenu;
        const subId = `navbar${nav.id}`;
        li.append(
          `<a class="nav-link dropdown-toggle" href="${nav.slug}" id="${subId}" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">${nav.display}</a>
		  `
        );
        const subNav = $(
          `<div class="dropdown-menu" aria-labelledby="${subId}"></div>`
        );

        subMenu.map((sub) => {
          subNav.append(
            `<a class="dropdown-item" href="${sub.slug}">${sub.display}</a>`
          );
        });

        li.append(subNav);
        navbar.append(li);
      }
    });
  });
  $.get('/data/footer.json', (data) => {
    const footer = $('.footer-area>.container>.row');
    footer.append(`
<div class="col-12 col-md-4">
	<div class="footer-single-widget">
			<a href="/"><img src="${data?.logo}" alt=""></a>
			<div class="copywrite-text mt-30">
					<p>${data?.copyright} ${new Date().getFullYear()}</p>
			</div>
	</div>
</div>
		`);
    footer.append(`
<div class="col-12 col-md-4">
	<div class="footer-single-widget">
		<ul class="footer-menu d-flex justify-content-between">
		</ul>
	</div>
</div>`);
    data?.navigates?.forEach((nav) => {
      $('.footer-menu').append(
        `<li><a href="${nav?.slug}">${nav?.display}</a></li>`
      );
    });
    footer.append(`
<div class="col-12 col-md-4">
	<div class="footer-single-widget">
		<ul class="d-flex justify-content-end socials">
		</ul>
	</div>
</div>`);
    data?.socials?.forEach((social) => {
      $('.socials').append(
        `<li class="mx-2"><a href="${social?.link}"><i class="${social?.icon} social"></i></a></li>`
      );
    });
	});
	$("#alert").hide();
});
