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
('Image 1', 'Image1.png', '/images/upload/b1.jpg', 'Image 1', 1),
('Image 2', 'Image2.png', '/images/upload/b2.jpg', 'Image 2', 1),
('Image 3', 'Image3.png', '/images/upload/b3.jpg', 'Image 3', 1),
('Image 4', 'Image4.png', '/images/upload/b4.jpg', 'Image 4', 1),
('Image 5', 'Image5.png', '/images/upload/b5.jpg', 'Image 5', 1),
('Image 6', 'Image6.png', '/images/upload/b6.jpg', 'Image 6', 1),
('Image 7', 'Image7.png', '/images/upload/b7.jpg', 'Image 7', 1),
('Image 8', 'Image8.png', '/images/upload/b8.jpg', 'Image 8', 1),
('Image 9', 'Image9.png', '/images/upload/b9.jpg', 'Image 9', 1),
('Image 10', 'Image10.png', '/images/upload/b10.jpg', 'Image 10', 1),
('Image 11', 'Image11.png', '/images/upload/b11.jpg', 'Image 1', 1),
('Image 12', 'Image12.png', '/images/upload/b12.jpg', 'Image 12', 1),
('Image 13', 'Image13.png', '/images/upload/b13.jpg', 'Image 13', 1),
('Image 14', 'Image14.png', '/images/upload/b14.jpg', 'Image 14', 1),
('Image 15', 'Image15.png', '/images/upload/b15.jpg', 'Image 15', 1),
('Image 16', 'Image16.png', '/images/upload/b16.jpg', 'Image 16', 1),
('Image 17', 'Image17.png', '/images/upload/b17.jpg', 'Image 17', 1),
('Image 18', 'Image18.png', '/images/upload/b18.jpg', 'Image 18', 1),
('Image 19', 'Image19.png', '/images/upload/b19.jpg', 'Image 19', 1),
('Image 20', 'Image20.png', '/images/upload/b20.jpg', 'Image 20', 1),
('Image 21', 'Image21.png', '/images/upload/b21.jpg', 'Image 21', 1),
('Image 22', 'Image22.png', '/images/upload/b22.jpg', 'Image 22', 1),
('Image 23', 'Image23.png', '/images/upload/b23.jpg', 'Image 23', 1),
('Image 24', 'Image24.png', '/images/upload/b24.jpg', 'Image 24', 1),
('Background 1', 'Background1.png', '/images/upload/bg1.jpg', 'Background 1', 1),
('Background 2', 'Background2.png', '/images/upload/bg2.jpg', 'Background 2', 1),
('Background 3', 'Background3.png', '/images/upload/bg3.jpg', 'Background 3', 1),
('Background 4', 'Background4.png', '/images/upload/bg4.jpg', 'Background 4', 1);

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
('Kết quả Việt Nam vs Dortmund: Thắng lợi khó tin', 'ket-qua-viet-nam-vs-dortmund-19h00-hom-nay-30-11', 'ĐT Việt Nam hạ đẹp Dortmund ngay tại Mỹ Đình', 'ĐT Việt Nam hạ đẹp Dortmund ngay tại Mỹ Đình', 9, 2),
('Đội hình mạnh nhất Pháp vs Tunisia: Đẳng cấp chênh lệch','doi-hinh-manh-nhat-phap-vs-tunisia-dang-cap-chenh-lech','Đội hình mạnh nhất Pháp vs Tunisia: Đẳng cấp chênh lệch', 'Đội hình mạnh nhất Pháp vs Tunisia: Đẳng cấp chênh lệch', 10, 1),
('Tổng thống Mỹ vui sướng tột độ về thành tích đội nhà tại World Cup 2022', '', 'Tổng thống Mỹ vui sướng tột độ về thành tích đội nhà tại World Cup 2022', 'Tổng thống Mỹ vui sướng tột độ về thành tích đội nhà tại World Cup 2022', 11, 1);

INSERT INTO content(heading, information, media_id, page_id)
VALUES
(NULL, 'ĐT Việt Nam lội ngược dòng giành chiến thắng với tỷ số 2-1 trước Dortmund ở trận giao hữu trên SVĐ Mỹ Đình', 20, 1),
(NULL, 'Đúng như những gì HLV Park Hang Seo đã tuyên bố, ĐT Việt Nam đã nhập cuộc cực kỳ tự tin và sẵn sàng chơi sòng phẳng với Dortmund. Thậm chí ngay ở pha giao bóng đầu tiên, Trọng Hoàng đã tung đường chuyền vắt ngang khung thành Dortmund nhưng không ai chạm được bóng.', NULL, 1),
(NULL, 'Tuy nhiên những phút giây hứng khởi đó nhanh chóng bị dập tắt khi Dortmund dần làm quen với nhịp độ của trận đấu. Để rồi đến phút thứ 13, đội bóng nước Đức đã có bàn mở tỷ số khi hàng phòng ngự ĐT Việt Nam để cho Malen thoải mái nhận bóng rồi dứt điểm trong vòng cấm.', NULL, 1),
(NULL, 'Những phút tiếp theo 2 đội chơi ăn miếng trả miếng. Nỗ lực không biết mệt mỏi của ĐT Việt Nam được đền đáp bằng bàn thắng gỡ hòa ở phút thứ 36. Thủ môn Meyer đã không thể bắt dính cú sút góc hẹp của Hồng Duy và Tiến Linh đã có mặt đúng lúc đúng chỗ để dứt điểm gỡ hòa 1-1.', 22, 1),
(NULL, 'Sang đến hiệp thi đấu thứ 2, Dortmund có tới 9 sự thay đổi người. Kể từ thời điểm đó, ĐT Việt Nam mới là đội chơi hay hơn và kiểm soát thế trận. Lần lượt cả Văn Toàn và Đức Chinh đều đã có những cơ hội đối mặt với thủ môn của Dortmund nhưng không thể có bàn thắng dẫn trước.', NULL, 1),
(NULL, 'Những phút còn lại của trận đấu, không còn quá nhiều cơ hội nguy hiểm được 2 đội tạo ra. ĐT Việt Nam có một vài tình huống phản công tốt nhưng thiếu chính xác ở những pha xử lý cuối cùng. Bước ngoặt xảy ra ở phút thi đấu cuối cùng khi ĐT Việt Nam được hưởng penalty. Trên chấm 11m, Tuấn Hải dứt điểm lạnh lùng để ấn định chiến thắng với tỷ số 2-1 trước Dortmund', NULL, 1),
(NULL, '22h00 ngày 30/11 (giờ Việt Nam), Pháp sẽ có trận đấu cuối cùng tại bảng D World Cup 2022 gặp Tunisia. Dưới đây là đội hành mạnh nhất của hai đội.', 10, 2),
(NULL, 'Nhà đương kim vô địch Pháp đã sớm giành quyền vào vòng 1/8 World Cup 2022 sau thắng lợi 2-1 trước Đan Mạch ở lượt trận thứ hai bảng D. Trong khi đó, Tunisia dù đứng cuối bảng nhưng vẫn còn cơ hội cạnh tranh suất đi tiếp.', NULL, 2),
(NULL, 'Hiện tại, Tunisia và Đan Mạch đang có cùng 1 điểm và hiệu số -1. Nếu đại diện châu Phi có thể thắng sốc Pháp, cũng như Đan Mạch và Úc hòa nhau, Tunisia sẽ có tấm vé đi tiếp còn lại tại bảng D World Cup 2022.', NULL, 2),
(NULL, 'Dẫu vậy, nhiệm vụ đánh bại nhà ĐKVĐ Pháp dường như là quá sức với Tunisia, khi Gà trống Gaulois có chất lượng đội hình vượt trội. Kể cả khi HLV Deschamps cho những Kylian Mbappe, Antoine Griezmann, Dembele,... nghỉ ngơi, lực lượng còn lại vẫn là rất chênh lệch.', 18, 2),
('Thông tin lực lượng Pháp vs Tunisia', 'Cầu thủ ghi bàn nhiều thứ hai trong lịch sử bóng đá Tunisia là Wahbi Khazri mới có 1 lần vào sân thay người ở 2 trận đấu vừa qua nhiều khả năng sẽ được trao cơ hội ra sân từ đầu. Ngoài ra, thủ thành dự bị Bechir Ben Said gặp vấn đề về sức khỏe ở trận trước đã bình phục hoàn toàn.', NULL, 2),
(NULL, 'Đối với Pháp, HLV Didier Deschamps có thể vắng thủ môn số 2 Alphonse Areola do vấn đề ở lưng, nhưng có thể sẽ có vô số thay đổi khi ông muốn cất các trụ cột nhằm chuẩn bị cho vòng 1/8. William Saliba, Matteo Guendouzi, Kingsley Coman và Youssouf Fofana, Marcus Thuram nhiều khả năng sẽ có cơ hội ra sân từ đầu.', NULL, 2),
(NULL, 'Lucas Hernandez là trường hợp chấn thương duy nhất của ĐT Pháp.', NULL, 2),
('Đội hình dự kiến Pháp vs Tunisia', 'Pháp: Mandanda; Pavard, Konate, Varane, Camavinga; Guendouzi, Fofana; Coman, Griezmann, Mbappe; Thuram', NULL, 2),
(NULL, 'Tunisia: Dahmen; Bronn, Talbi, Meriah; Kechrida, Skhiri, Laidouni, Abdi; Msakni, Sliti; Khazri', NULL, 2),
(NULL, 'Thành công của ĐT Mỹ tính tới thời điểm này tại World Cup 2022 khiến tổng thống Joe Biden cảm thấy rất tự hào.', NULL, 3),
(NULL, 'Vốn được đánh giá không cao trước thềm World Cup 2022 diễn ra, giờ đây ĐT Mỹ đã trình diễn một bộ mặt vượt xa sự kỳ vọng của NHM khi chính thức ghi tên vào vòng 16 đội mạnh nhất. Đương nhiên, thành công của đội nhà tại Qatar lần này là niềm tự hào của người dân Xứ cờ hoa.', NULL, 3),
(NULL, 'Ngay khi trận đấu với Iran kết thúc, Tổng thống Mỹ Joe Biden đã không giấu nổi niềm vui sướng. Phát biểu ngay tại sự kiện trực tiếp, ông đã tự hào hô vang: USA, USA, đây là một chiến thắng trên cả tuyệt vời.', NULL, 3),
(NULL, 'Tôi đã có niềm tin là các cầu thủ sẽ làm nên chuyện ngay từ khi nói chuyện với họ. Chúa phù hộ đội tuyển. Hy vọng tất cả mọi người có thể cùng ăn mừng chiến thắng này.', 8, 3),
(NULL, 'Đừng quên là ngoài việc vượt qua vòng bảng, ĐT Mỹ đã làm được điều này với tư cách là đội chỉ để lọt lưới 1 bàn duy nhất xuất phát từ quả 11m ở trận đấu với Xứ Wales. Trên thực tế thì góp mặt tại vòng knock-out là thành tích thường có của họ tại các kỳ World Cup, tuy nhiên tại Qatar năm nay thì đó được xem như một niềm tự hào.', NULL, 3),
(NULL, 'Đáng tiếc, vị trí thứ 2 bảng B khiến họ sẽ phải đụng độ đối thủ rất mạnh là Hà Lan ở vòng đấu tiếp theo. Mặc dù vậy, Christian Pulisic và các đồng đội đã từng có màn thể hiện rất tốt trước ứng cử viên vô địch là ĐT Anh, do đó họ hoàn toàn có thể làm nên điều kỳ diệu trong một ngày phong độ lên cao.', NULL, 3),
(NULL, 'Trận đấu giữa ĐT Mỹ và ĐT Hà Lan ở vòng knock-out World Cup 2022 sẽ diễn ra vào ngày 3/12 tới.', NULL, 3);

");
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
		");

		}
	}
}