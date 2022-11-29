CREATE DATABASE IF NOT EXISTS db_sport;

USE db_sport;

CREATE TABLE user(
	id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
	username varchar(50) NOT NULL,
	password varchar(255) NOT NULL,
	name varchar(255) NULL,
	birthday date NULL,
	gender smallint default 0,
	phone varchar(15) NULL,
	email varchar(255) NOT NULL,
	role enum('Admin', 'User') NOT NULL DEFAULT 'User',
	UNIQUE INDEX UQ_USERNAME (username),
	UNIQUE INDEX UQ_EMAIL (email)
) ENGINE = InnoDB;

CREATE TABLE media(
	id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
	title varchar(2000) NOT NULL,
	original_name varchar(2000) NOT NULL,
	source varchar(2000) NULL,
	alt_text varchar(2000) NULL,
	media_type smallint NOT NULL DEFAULT 1,
	created_at datetime NOT NULL DEFAULT NOW(),
	created_by int NOT NULL DEFAULT 0,
	UNIQUE INDEX UQ_ORIGINAL (original_name)
) ENGINE = InnoDB;

CREATE TABLE category(
	id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
	title varchar(2000) NOT NULL,
	slug varchar(255) NOT NULL,
	description text NULL,
	media_id int NULL,
	display tinyint NOT NULL DEFAULT 1,
	UNIQUE INDEX UQ_CATEGORY (slug),
	CONSTRAINT FK_CATEGORY_MEDIA FOREIGN KEY (media_id) REFERENCES media(id)
) ENGINE = InnoDB;

CREATE TABLE page(
	id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
	slug varchar(255) NOT NULL,
	title varchar(2000) NOT NULL,
	heading varchar(5000) NOT NULL,
	description varchar(5000) NULL,
	approve tinyint NOT NULL DEFAULT 1,
	media_id int NULL,
	category_id int NOT NULL,
	created_at datetime NOT NULL DEFAULT NOW(),
	created_by int NOT NULL DEFAULT 0,
	updated_at datetime NOT NULL DEFAULT NOW() ON UPDATE NOW(),
	UNIQUE INDEX UQ_PAGE (slug),
	CONSTRAINT FK_PAGE_MEDIA FOREIGN KEY (media_id) REFERENCES media(id),
	CONSTRAINT FK_PAGE_CATEGORY FOREIGN KEY (category_id) REFERENCES category(id)
) ENGINE = InnoDB;

CREATE TABLE content(
	id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
	heading varchar(5000) NOT NULL,
	information text NULL,
	media_id int NULL,
	page_id int NOT NULL,
	display tinyint NOT NULL DEFAULT 1,
	created_at datetime NOT NULL DEFAULT NOW(),
	created_by int NOT NULL DEFAULT 0,
	updated_at datetime NOT NULL DEFAULT NOW() ON UPDATE NOW(),
	CONSTRAINT FK_CONTENT_MEDIA FOREIGN KEY (media_id) REFERENCES media(id),
	CONSTRAINT FK_CONTENT_PAGE FOREIGN KEY (page_id) REFERENCES page(id)
) ENGINE = InnoDB;

CREATE TABLE evaluation(
	id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
	page_id int NOT NULL,
	user_id int NOT NULL,
	content text NOT NULL,
	rate smallint NOT NULL DEFAULT 5,
	created_at datetime NOT NULL DEFAULT NOW(),
	created_by int NOT NULL DEFAULT 0,
	CONSTRAINT FK_EVALUATION_PAGE FOREIGN KEY (page_id) REFERENCES page(id),
	CONSTRAINT FK_EVALUATION_USER FOREIGN KEY (user_id) REFERENCES user(id)
) ENGINE = InnoDB;