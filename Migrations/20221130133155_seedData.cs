using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSite6.Migrations
{
	public partial class seedData : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
ALTER TABLE user AUTO_INCREMENT=1;
ALTER TABLE media AUTO_INCREMENT=1;
ALTER TABLE page AUTO_INCREMENT=1;
ALTER TABLE category AUTO_INCREMENT=1;
ALTER TABLE content AUTO_INCREMENT=1;

INSERT INTO user(username, password, name, birthday, gender, email, role)
VALUES 
('sythai', '$2a$12$o5suxw8C5HAZs/bOSbWoNOFeHu0fitOG86uDGUXxdclJD3EFEXd9i', 'Sỹ Thái', '2000-03-26', 1, 'sythai@gmail.com', 'Admin' ),
('namdp', '$2a$12$o5suxw8C5HAZs/bOSbWoNOFeHu0fitOG86uDGUXxdclJD3EFEXd9i', 'Phương Nam', '2000-06-16', 1, 'user@gmail.com', 'User' );

INSERT INTO media(title, original_name, source, alt_text, media_type)
VALUES 
('ĐT Việt Nam hạ đẹp Dortmund ngay tại Mỹ Đình', 'Image1.png', '/upload/images/vn-dortmund.jpg', 'ĐT Việt Nam hạ đẹp Dortmund ngay tại Mỹ Đình', 1),
('Bàn thắng của Tuấn Hải ấn định thắng lợi 2-1 cho ĐT Việt Nam', 'Image1.png', '/upload/images/page1-1.jpg', 'Bàn thắng của Tuấn Hải ấn định thắng lợi 2-1 cho ĐT Việt Nam', 1),
('Pháp có lực lượng vượt trội so với Tunisia', 'Image1.png', '/upload/images/page2-1.jpg', 'Pháp có lực lượng vượt trội so với Tunisia', 1),
('Tổng thống Mỹ không giấu được niềm vui trước thành tích của Pulisic và các đồng đội (Ảnh: internet)', 'image3.png', '/upload/images/page3-1.png', 'Tổng thống Mỹ không giấu được niềm vui trước thành tích của Pulisic và các đồng đội (Ảnh: internet)', 1),
('Tổng thống Mỹ không giấu được niềm vui trước thành tích của Pulisic và các đồng đội (Ảnh: internet)', 'image4.png', '/upload/images/page3-2.jpg', 'Tổng thống Mỹ không giấu được niềm vui trước thành tích của Pulisic và các đồng đội (Ảnh: internet)', 1),
('Kết quả Việt Nam vs Dortmund: Thắng lợi khó tin', 'youtube', 'https://www.youtube.com/watch?v=lCXYLExheoM', 'Kết quả Việt Nam vs Dortmund: Thắng lợi khó tin', 0),
('Đội hình mạnh nhất Pháp vs Tunisia: Đẳng cấp chênh lệch', 'audio1.mp3', '/upload/audios/doi-hinh-Phap-Tunisia.mp3', 'Đội hình mạnh nhất Pháp vs Tunisia: Đẳng cấp chênh lệch', 2),
('Tổng thống Mỹ không giấu được niềm vui trước thành tích của Pulisic và các đồng đội', 'audio2.mp3', '/upload/audios/tong-thong-my-vui.mp3', 'Tổng thống Mỹ không giấu được niềm vui trước thành tích của Pulisic và các đồng đội', 1), 
('Tôi không biết Úc yếu hơn Argentina','page4-1.webp', '/upload/images/page4-1.webp', 'Tôi không biết Úc yếu hơn Argentina', 1),
('Sau Ả Rập Xê Út, Messi và các đồng đội sẽ đụng độ một đối thủ châu Á khác tại vòng 16 đội là Úc','page4-2.jpg', '/upload/images/page4-2.jpg', 'Sau Ả Rập Xê Út, Messi và các đồng đội sẽ đụng độ một đối thủ châu Á khác tại vòng 16 đội là Úc', 1),
('Tôi không biết Úc yếu hơn Argentina','audio4.mp3', '/upload/audios/toi-khong-biet-uc-yeu-hon-aghentina.mp3', 'Tôi không biết Úc yếu hơn Argentina', 2),
('HLV Scaloni của ĐT Argentina cho rằng Úc là một đối thủ mạnh và không bất ngờ khi họ giành quyền đi tiếp ở bảng D','page4-3.mp3', '/upload/page4-3.jpg', 'HLV Scaloni của ĐT Argentina cho rằng Úc là một đối thủ mạnh và không bất ngờ khi họ giành quyền đi tiếp ở bảng D', 1),
('Không khó để bắt gặp những tấm banner in hình Messi hay Maradona trên khán đài World Cup 2022','page4-3.jpg', '/upload/page4-4.jpg', 'Không khó để bắt gặp những tấm banner in hình Messi hay Maradona trên khán đài World Cup 2022', 1);



INSERT INTO category(title, slug, description, media_id)
VALUES
('World Cup 2022', 'world-cup', 'Giải vô địch bóng đá thế giới hoặc Cúp bóng đá thế giới', 1),
('Bóng đá Việt Nam', 'v-league', 'Giải vô địch bóng đá thế giới hoặc Cúp bóng đá thế giới', 2),
('AFF CUP 2022', 'aff-cup-2022', 'giải đấu bóng đá giữa các đội tuyển bóng đá nam quốc gia đại diện các quốc gia thuộc khu vực Đông Nam Á do Liên đoàn bóng đá Đông Nam Á (AFF) tổ chức', 3),
('Cúp C1 Châu Âu', 'cup-c1', 'Giải cúp c1 ', 4),
('Ngoại Hạng Anh', 'premiere-league', 'Ngoại Hạng Anh', 5),
('E-Sport', 'e-sport', 'Thể thao điện tử', 6);


INSERT INTO page(title, slug, description, heading, media_id, category_id)
VALUES 
('Kết quả Việt Nam vs Dortmund: Thắng lợi khó tin', '/tin-tuc/ket-qua-viet-nam-vs-dortmund-19h00-hom-nay-30-11', 'ĐT Việt Nam hạ đẹp Dortmund ngay tại Mỹ Đình', 'ĐT Việt Nam hạ đẹp Dortmund ngay tại Mỹ Đình', 1, 2),
('Đội hình mạnh nhất Pháp vs Tunisia: Đẳng cấp chênh lệch','/tin-tuc/doi-hinh-manh-nhat-phap-vs-tunisia-dang-cap-chenh-lech','Đội hình mạnh nhất Pháp vs Tunisia: Đẳng cấp chênh lệch', 'Đội hình mạnh nhất Pháp vs Tunisia	: Đẳng cấp chênh lệch', 3, 1),
('Tổng thống Mỹ vui sướng tột độ về thành tích đội nhà tại World Cup 2022', '/tin-tuc/tong-thong-my-vui-suong-tot-do-voi-thanh-tich-doi-nha-tai-world-cup', 'Tổng thống Mỹ vui sướng tột độ về thành tích đội nhà tại World Cup 2022', 'Tổng thống Mỹ vui sướng tột độ về thành tích đội nhà tại World Cup 2022', 4, 1),
('HLV Scaloni: Tôi không biết Úc yếu hơn Argentina','/tin-tuc/hlv-scaloni-toi-khong-biet-uc-yeu-hon-argentina', 'HLV Lionel Scaloni cho rằng nên loại bỏ mọi sự thiên vị dành cho ĐT Argentina bởi đối thủ của họ tại vòng 1/8 World Cup 2022 là Úc không hề yếu.', 'HLV Scaloni: ""Tôi không biết Úc yếu hơn Argentina""', 9, 1);

INSERT INTO content(heading, information, media_id, page_id)
VALUES
(NULL, 'ĐT Việt Nam lội ngược dòng giành chiến thắng với tỷ số 2-1 trước Dortmund ở trận giao hữu trên SVĐ Mỹ Đình', 6, 1),
(NULL, 'Đúng như những gì HLV Park Hang Seo đã tuyên bố, ĐT Việt Nam đã nhập cuộc cực kỳ tự tin và sẵn sàng chơi sòng phẳng với Dortmund. Thậm chí ngay ở pha giao bóng đầu tiên, Trọng Hoàng đã tung đường chuyền vắt ngang khung thành Dortmund nhưng không ai chạm được bóng.', NULL, 1),
(NULL, 'Tuy nhiên những phút giây hứng khởi đó nhanh chóng bị dập tắt khi Dortmund dần làm quen với nhịp độ của trận đấu. Để rồi đến phút thứ 13, đội bóng nước Đức đã có bàn mở tỷ số khi hàng phòng ngự ĐT Việt Nam để cho Malen thoải mái nhận bóng rồi dứt điểm trong vòng cấm.', NULL, 1),
(NULL, 'Những phút tiếp theo 2 đội chơi ăn miếng trả miếng. Nỗ lực không biết mệt mỏi của ĐT Việt Nam được đền đáp bằng bàn thắng gỡ hòa ở phút thứ 36. Thủ môn Meyer đã không thể bắt dính cú sút góc hẹp của Hồng Duy và Tiến Linh đã có mặt đúng lúc đúng chỗ để dứt điểm gỡ hòa 1-1.', 2, 1),
(NULL, 'Sang đến hiệp thi đấu thứ 2, Dortmund có tới 9 sự thay đổi người. Kể từ thời điểm đó, ĐT Việt Nam mới là đội chơi hay hơn và kiểm soát thế trận. Lần lượt cả Văn Toàn và Đức Chinh đều đã có những cơ hội đối mặt với thủ môn của Dortmund nhưng không thể có bàn thắng dẫn trước.', NULL, 1),
(NULL, 'Những phút còn lại của trận đấu, không còn quá nhiều cơ hội nguy hiểm được 2 đội tạo ra. ĐT Việt Nam có một vài tình huống phản công tốt nhưng thiếu chính xác ở những pha xử lý cuối cùng. Bước ngoặt xảy ra ở phút thi đấu cuối cùng khi ĐT Việt Nam được hưởng penalty. Trên chấm 11m, Tuấn Hải dứt điểm lạnh lùng để ấn định chiến thắng với tỷ số 2-1 trước Dortmund', NULL, 1),
(NULL, '22h00 ngày 30/11 (giờ Việt Nam), Pháp sẽ có trận đấu cuối cùng tại bảng D World Cup 2022 gặp Tunisia. Dưới đây là đội hành mạnh nhất của hai đội.', 7, 2),
(NULL, 'Nhà đương kim vô địch Pháp đã sớm giành quyền vào vòng 1/8 World Cup 2022 sau thắng lợi 2-1 trước Đan Mạch ở lượt trận thứ hai bảng D. Trong khi đó, Tunisia dù đứng cuối bảng nhưng vẫn còn cơ hội cạnh tranh suất đi tiếp.', NULL, 2),
(NULL, 'Hiện tại, Tunisia và Đan Mạch đang có cùng 1 điểm và hiệu số -1. Nếu đại diện châu Phi có thể thắng sốc Pháp, cũng như Đan Mạch và Úc hòa nhau, Tunisia sẽ có tấm vé đi tiếp còn lại tại bảng D World Cup 2022.', NULL, 2),
(NULL, 'Dẫu vậy, nhiệm vụ đánh bại nhà ĐKVĐ Pháp dường như là quá sức với Tunisia, khi Gà trống Gaulois có chất lượng đội hình vượt trội. Kể cả khi HLV Deschamps cho những Kylian Mbappe, Antoine Griezmann, Dembele,... nghỉ ngơi, lực lượng còn lại vẫn là rất chênh lệch.', 3, 2),
('Thông tin lực lượng Pháp vs Tunisia', 'Cầu thủ ghi bàn nhiều thứ hai trong lịch sử bóng đá Tunisia là Wahbi Khazri mới có 1 lần vào sân thay người ở 2 trận đấu vừa qua nhiều khả năng sẽ được trao cơ hội ra sân từ đầu. Ngoài ra, thủ thành dự bị Bechir Ben Said gặp vấn đề về sức khỏe ở trận trước đã bình phục hoàn toàn.', NULL, 2),
(NULL, 'Đối với Pháp, HLV Didier Deschamps có thể vắng thủ môn số 2 Alphonse Areola do vấn đề ở lưng, nhưng có thể sẽ có vô số thay đổi khi ông muốn cất các trụ cột nhằm chuẩn bị cho vòng 1/8. William Saliba, Matteo Guendouzi, Kingsley Coman và Youssouf Fofana, Marcus Thuram nhiều khả năng sẽ có cơ hội ra sân từ đầu.', NULL, 2),
(NULL, 'Lucas Hernandez là trường hợp chấn thương duy nhất của ĐT Pháp.', NULL, 2),
('Đội hình dự kiến Pháp vs Tunisia', 'Pháp: Mandanda; Pavard, Konate, Varane, Camavinga; Guendouzi, Fofana; Coman, Griezmann, Mbappe; Thuram', NULL, 2),
(NULL, 'Tunisia: Dahmen; Bronn, Talbi, Meriah; Kechrida, Skhiri, Laidouni, Abdi; Msakni, Sliti; Khazri', NULL, 2),
(NULL, 'Thành công của ĐT Mỹ tính tới thời điểm này tại World Cup 2022 khiến tổng thống Joe Biden cảm thấy rất tự hào.', 8, 3),
(NULL, 'Vốn được đánh giá không cao trước thềm World Cup 2022 diễn ra, giờ đây ĐT Mỹ đã trình diễn một bộ mặt vượt xa sự kỳ vọng của NHM khi chính thức ghi tên vào vòng 16 đội mạnh nhất. Đương nhiên, thành công của đội nhà tại Qatar lần này là niềm tự hào của người dân Xứ cờ hoa.', NULL, 3),
(NULL, 'Ngay khi trận đấu với Iran kết thúc, Tổng thống Mỹ Joe Biden đã không giấu nổi niềm vui sướng. Phát biểu ngay tại sự kiện trực tiếp, ông đã tự hào hô vang: USA, USA, đây là một chiến thắng trên cả tuyệt vời.', NULL, 3),
(NULL, 'Tôi đã có niềm tin là các cầu thủ sẽ làm nên chuyện ngay từ khi nói chuyện với họ. Chúa phù hộ đội tuyển. Hy vọng tất cả mọi người có thể cùng ăn mừng chiến thắng này.', 5, 3),
(NULL, 'Đừng quên là ngoài việc vượt qua vòng bảng, ĐT Mỹ đã làm được điều này với tư cách là đội chỉ để lọt lưới 1 bàn duy nhất xuất phát từ quả 11m ở trận đấu với Xứ Wales. Trên thực tế thì góp mặt tại vòng knock-out là thành tích thường có của họ tại các kỳ World Cup, tuy nhiên tại Qatar năm nay thì đó được xem như một niềm tự hào.', NULL, 3),
(NULL, 'Đáng tiếc, vị trí thứ 2 bảng B khiến họ sẽ phải đụng độ đối thủ rất mạnh là Hà Lan ở vòng đấu tiếp theo. Mặc dù vậy, Christian Pulisic và các đồng đội đã từng có màn thể hiện rất tốt trước ứng cử viên vô địch là ĐT Anh, do đó họ hoàn toàn có thể làm nên điều kỳ diệu trong một ngày phong độ lên cao.', NULL, 3),
(NULL, 'Trận đấu giữa ĐT Mỹ và ĐT Hà Lan ở vòng knock-out World Cup 2022 sẽ diễn ra vào ngày 3/12 tới.', NULL, 3),
(NULL, 'HLV Lionel Scaloni cho rằng nên loại bỏ mọi sự thiên vị dành cho ĐT Argentina bởi đối thủ của họ tại vòng 1/8 World Cup 2022 là Úc không hề yếu.', 11, 4),
(NULL, 'Ngay sau khi giai đoạn vòng bảng khép lại vào rạng sáng nay 3/12, 16 đội bóng xuất sắc nhất của World Cup 2022 sẽ lập tức bước vào vòng loại trực tiếp đầu tiên. Một trong hai cặp đấu sẽ diễn ra trong ngày thi đấu hôm nay sẽ là Argentina vs Úc.', NULL, 4),
(NULL, 'Đội bóng xứ Tango được đánh giá cao hơn sau màn lội ngược dòng ở vòng bảng. Cụ thể, sau trận thua sốc mở màn trước Ả Rập Xê Út, họ đã giành 2 chiến thắng liên tiếp trước Mexico và Ba Lan, để giành ngôi nhất bảng C. Tương tự như Argentina, Úc cũng để thua trận đầu gặp Pháp nhưng đã vượt qua Đan Mạch và Tunisia một cách ấn tượng để về nhì bảng D.', 10, 4),
(NULL, 'Phát biểu trước trận knock-out đầu tiên của Albiceleste, HLV trưởng Lionel Scaloni đã có những nhận định về đối thủ đến từ châu Á. Theo đó, ông cho rằng Úc không phải đối thủ dễ chơi đồng thời bác bỏ ý kiến cho rằng Argentina là ứng cử viên sáng giá cho vé đi tiếp.', NULL, 4),
(NULL, 'Đối thủ của chúng tôi là một đội bóng mạnh. Tôi không biết liệu họ có thua kém chúng tôi hay không. Nhưng đây là bóng đá, nơi 11 người đấu với 11 người trên sân. Chúng tôi phải gạt bỏ những sự thiên vị trên giấy tờ này sang một bên và tập trung vào trận đấu.<br>Chúng tôi sẽ cố gắng để chống lại những cầu thủ giỏi của họ. Cả đội sẽ cố gắng duy trì lối chơi của mình trong thời gian lâu nhất có thể. Tôi không ngạc nhiên khi Úc giành quyền đi tiếp ở bảng D, họ là một đội bóng mạnh và có truyền thống tại World Cup.', 12, 4),
(NULL, 'Bên cạnh đó, HLV Scaloni cũng khẳng định vai trò quan trọng của người hâm mộ nước nhà và cả thế giới đối với hành trình của ĐT Argentina tại World Cup năm nay.', 13, 4),
(NULL, 'Chúng tôi rất biết ơn mọi người, bầu không khí rất tuyệt. Có rất nhiều người hâm mộ của chúng tôi ở đây, cứ như là được chơi ở Argentina vậy. Trong nhiều năm qua, chiếc áo đấu của Argentina đã phủ sóng rộng khắp toàn thế giới, từ thời Diego Maradona và giờ là Lionel Messi.', NULL, 4),
(NULL, 'Trận đấu giữa Argentina và Úc thuộc khuôn khổ vòng 1/8 World Cup 2022 sẽ diễn ra vào 2h00 rạng sáng 4/12. Nếu vượt qua đối thủ, Messi và các đồng đội sẽ giành quyền vào Tứ kết và đối thủ vòng tới sẽ là đội thắng trong cặp đấu Hà Lan vs Mỹ.', NULL, 4);
", true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
DELETE FROM content;
ALTER TABLE content AUTO_INCREMENT=1;

DELETE FROM page;
ALTER TABLE page AUTO_INCREMENT=1;

DELETE FROM category;
ALTER TABLE category AUTO_INCREMENT=1;

DELETE FROM media;
ALTER TABLE media AUTO_INCREMENT=1;

DELETE FROM user;
ALTER TABLE user AUTO_INCREMENT=1;
		", true);

		}
	}
}