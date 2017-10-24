DROP DATABASE IF EXISTS PART2;

CREATE DATABASE PART2;

USE PART2;

CREATE TABLE PhotoSlideshow (
	photoNumber int NOT NULL AUTO_INCREMENT, 
	url VARCHAR(256) NOT NULL,
    caption VARCHAR(256) NOT NULL,
	PRIMARY KEY(photoNumber)
);

INSERT INTO PhotoSlideshow (url, caption) VALUES ("../shared/beef_tartare.png", "Beef Tartare");