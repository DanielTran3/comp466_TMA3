CREATE DATABASE IF NOT EXISTS DigitalElectronics;
USE DigitalElectronics;

DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS orders;
DROP TABLE IF EXISTS currentOrder;

CREATE TABLE users (
username VARCHAR(20) NOT NULL,
password VARCHAR(30) NOT NULL,
securityQuestion VARCHAR(256) NOT NULL,
securityAnswer VARCHAR(128) NOT NULL,
PRIMARY KEY (username));

CREATE TABLE orders (
ID int NOT NULL AUTO_INCREMENT,
username VARCHAR(20) NOT NULL,
prebuiltSystem int NOT NULL,
display int NOT NULL,
hardDrive int NOT NULL,
operatingSystem int NOT NULL,
processor int NOT NULL,
ram int NOT NULL,
soundcard int NOT NULL,
totalPrice VARCHAR(32) NOT NULL,
PRIMARY KEY (ID),
FOREIGN KEY (username) REFERENCES users(username),
FOREIGN KEY (prebuiltSystem) REFERENCES prebuiltSystem(ID),
FOREIGN KEY (processor) REFERENCES processor(ID),
FOREIGN KEY (ram) REFERENCES ram(ID),
FOREIGN KEY (hardDrive) REFERENCES hardDrive(ID),
FOREIGN KEY (display) REFERENCES display(ID),
FOREIGN KEY (operatingSystem) REFERENCES operatingSystem(ID),
FOREIGN KEY (soundCard) REFERENCES soundCard(ID));

CREATE TABLE currentOrder (
username VARCHAR(20) NOT NULL,
prebuiltSystem int,
display int,
hardDrive int,
operatingSystem int,
processor int,
ram int,
soundCard int,
totalPrice VARCHAR(32),
editId int,
PRIMARY KEY (username),
FOREIGN KEY (username) REFERENCES users(username),
FOREIGN KEY (prebuiltSystem) REFERENCES prebuiltSystem(ID),
FOREIGN KEY (processor) REFERENCES processor(ID),
FOREIGN KEY (ram) REFERENCES ram(ID),
FOREIGN KEY (hardDrive) REFERENCES hardDrive(ID),
FOREIGN KEY (display) REFERENCES display(ID),
FOREIGN KEY (operatingSystem) REFERENCES operatingSystem(ID),
FOREIGN KEY (soundCard) REFERENCES soundCard(ID));

DROP TABLE IF EXISTS feedback;
CREATE TABLE feedback (
ID int NOT NULL AUTO_INCREMENT,
username VARCHAR(20) NOT NULL,
feedbackText VARCHAR(2048) NOT NULL,
PRIMARY KEY (ID));

DROP TABLE IF EXISTS prebuiltSystem;
DROP TABLE IF EXISTS display;
DROP TABLE IF EXISTS hardDrive;
DROP TABLE IF EXISTS operatingSystem;
DROP TABLE IF EXISTS processor;
DROP TABLE IF EXISTS ram;
DROP TABLE IF EXISTS soundCard;

CREATE TABLE display (
ID int NOT NULL AUTO_INCREMENT,
brand varchar(64) NOT NULL,
model varchar(128) NOT NULL,
size varchar(16) NOT NULL,
resolution varchar(32) NOT NULL,
responseTime varchar(16) NOT NULL,
price varchar(16) NOT NULL,
PRIMARY KEY (ID));

INSERT INTO display (brand, model, size, resolution, responseTime, price) VALUES 
("BenQ", "GW2765HT", "27in", "2560 x 1440", "4ms (GTG)", "$379.99");
INSERT INTO display (brand, model, size, resolution, responseTime, price) VALUES 
("BenQ", "GL2760H", "27in", "1920 x 1080", "2ms (GTG)", "$179.99");
INSERT INTO display (brand, model, size, resolution, responseTime, price) VALUES 
("BenQ", "GW2270", "21.5in", "1920 x 1080", "5ms (GTG)", "$119.99");
INSERT INTO display (brand, model, size, resolution, responseTime, price) VALUES 
("LG", "24M38D-B", "23.6in", "1920 x 1080", "5ms", "$159.99");
INSERT INTO display (brand, model, size, resolution, responseTime, price) VALUES 
("LG", "22MP48HQ-P", "21.5in", "1920 x 1080", "5ms", "$169.99");
INSERT INTO display (brand, model, size, resolution, responseTime, price) VALUES 
("ASUS", "VP239H-P", "23in", "1920 x 1080", "5ms (GTG)", "$184.99");
INSERT INTO display (brand, model, size, resolution, responseTime, price) VALUES 
("ASUS", "ROG SWIFT PG279Q", "27in", "2560 x 1440", "4ms (GTG)", "$1059.99");
INSERT INTO display (brand, model, size, resolution, responseTime, price) VALUES 
("ACER", "Predator XB241H", "24in", "1920x1080", "1ms", "$549.99");

CREATE TABLE hardDrive (
ID int NOT NULL AUTO_INCREMENT,
brand varchar(64) NOT NULL,
model varchar(128) NOT NULL,
type varchar(32) NOT NULL,
size varchar(16) NOT NULL,
readSpeed varchar(16) NOT NULL,
writeSpeed varchar(16) NOT NULL,
price varchar(16) NOT NULL,
PRIMARY KEY (ID));

INSERT INTO hardDrive (brand, model, type, size, readSpeed, writeSpeed, price) VALUES 
("Seagate", "BarraCuda", "Hard Drive (HDD)", "1TB", "156MB/sec", "156MB/sec", "$79.99");
INSERT INTO hardDrive (brand, model, type, size, readSpeed, writeSpeed, price) VALUES 
("Western Digital", "Blue", "Hard Drive (HDD)", "1TB", "150MB/sec", "150MB/sec", "$79.99");
INSERT INTO hardDrive (brand, model, type, size, readSpeed, writeSpeed, price) VALUES 
("Seagate", "BarraCuda", "Hard Drive (HDD)", "2TB", "156MB/sec", "156MB/sec", "$109.99");
INSERT INTO hardDrive (brand, model, type, size, readSpeed, writeSpeed, price) VALUES 
("Western Digital", "Blue", "Hard Drive (HDD)", "2TB", "150MB/sec", "150MB/sec", "$109.99");
INSERT INTO hardDrive (brand, model, type, size, readSpeed, writeSpeed, price) VALUES 
("Seagate", "BarraCuda", "Hard Drive (HDD)", "3TB", "156MB/sec", "156MB/sec", "$139.99");
INSERT INTO hardDrive (brand, model, type, size, readSpeed, writeSpeed, price) VALUES 
("Samsung", "850 EVO", "Solid State Drive (SSD)", "250GB", "540MB/sec", "520MB/sec", "$149.99");
INSERT INTO hardDrive (brand, model, type, size, readSpeed, writeSpeed, price) VALUES 
("Kingston", "SSDNow UV400", "Solid State Drive (SSD)", "240GB", "550MB/sec", "490MB/sec", "$129.99");
INSERT INTO hardDrive (brand, model, type, size, readSpeed, writeSpeed, price) VALUES 
("ADATA", "Ultimate SU800", "Solid State Drive (SSD)", "256GB", "560MB/sec", "520MB/sec", "$139.99");
INSERT INTO hardDrive (brand, model, type, size, readSpeed, writeSpeed, price) VALUES 
("Samsung", "850 EVO", "Solid State Drive (SSD)", "500GB", "540MB/sec", "520MB/sec", "$249.99");
INSERT INTO hardDrive (brand, model, type, size, readSpeed, writeSpeed, price) VALUES 
("ADATA", "Premier SP580", "Solid State Drive (SSD)", "120GB", "560MB/sec", "410MB/sec", "$79.99");

CREATE TABLE operatingSystem (
ID int NOT NULL AUTO_INCREMENT,
brand varchar(64) NOT NULL,
version varchar(128) NOT NULL,
price varchar(16) NOT NULL,
PRIMARY KEY (ID));

INSERT INTO operatingSystem (brand, version, price) VALUES 
("Microsoft", "Windows 10 Home (64-Bit)", "$139.99");
INSERT INTO operatingSystem (brand, version, price) VALUES 
("Microsoft", "Windows 10 Pro (64-Bit)", "$219.99");
INSERT INTO operatingSystem (brand, version, price) VALUES 
("Microsoft", "Windows 7 Pro (64-Bit)", "$199.99");

CREATE TABLE processor (
ID int NOT NULL AUTO_INCREMENT,
brand varchar(64) NOT NULL,
model varchar(128) NOT NULL,
clock varchar(16) NOT NULL,
cache varchar(16) NOT NULL,
socket varchar(16) NOT NULL,
price varchar(16) NOT NULL,
PRIMARY KEY (ID));

INSERT INTO processor (brand, model, clock, cache, socket, price) VALUES 
("Intel", "Core i7-7700k", "4.20 GHz", "8MB Cache", "LGA1151", "$499.99");
INSERT INTO processor (brand, model, clock, cache, socket, price) VALUES 
("Intel", "Core i5-7400", "3.00 GHz", "6MB Cache", "LGA1151", "$269.99");
INSERT INTO processor (brand, model, clock, cache, socket, price) VALUES 
("Intel", "Core i3-7100", "3.90 GHz", "3MB Cache", "LGA1151", "$169.99");
INSERT INTO processor (brand, model, clock, cache, socket, price) VALUES 
("AMD", "Ryzen 7 1700", "3.00 GHz", "16MB Cache", "PGA 1331 ", "$469.99");
INSERT INTO processor (brand, model, clock, cache, socket, price) VALUES 
("AMD", "Ryzen 5 1600", "3.20 GHz", "16MB Cache", "PGA 1331", "$299.99");
INSERT INTO processor (brand, model, clock, cache, socket, price) VALUES 
("AMD", "Ryzen 3 1300X", "3.50 GHz", "8MB Cache", "PGA 1331 ", "$169.99");

CREATE TABLE ram (
ID int NOT NULL AUTO_INCREMENT,
brand varchar(64) NOT NULL,
model varchar(128) NOT NULL,
speed varchar(16) NOT NULL,
memoryType varchar(64) NOT NULL,
price varchar(16) NOT NULL,
PRIMARY KEY (ID));

INSERT INTO ram (brand, model, speed, memoryType, price) VALUES 
("Corsair", "Vengeance LPX", "2400MHz", "DDR4 2 x 8GB PC4-19200", "$234.99");
INSERT INTO ram (brand, model, speed, memoryType, price) VALUES 
("G.Skill", "Ripjaws 4", "2400MHz", "DDR4 2 x 8GB PC4-19200", "$184.99");
INSERT INTO ram (brand, model, speed, memoryType, price) VALUES 
("G.Skill", "Trident Z RGB", "2400MHz", "DDR4 2 x 8GB PC4-19200", "$214.99");
INSERT INTO ram (brand, model, speed, memoryType, price) VALUES 
("Corsair", "Vengeance LPX", "2400MHz", "DDR4 2 x 8GB PC4-25600", "$234.99");
INSERT INTO ram (brand, model, speed, memoryType, price) VALUES 
("G.Skill", "Ripjaws V", "2800MHz", "DDR4 2 x 4GB PC4-22400", "$95.99");
INSERT INTO ram (brand, model, speed, memoryType, price) VALUES 
("Kingston", "HyperX Fury", "2133MHz", "DDR4 1 x 16GB PC4-17000", "$182.99");
INSERT INTO ram (brand, model, speed, memoryType, price) VALUES 
("Kingston", "HyperX Fury", "2133MHz", "DDR4 1 x 8GB PC4-17000", "$92.99");
INSERT INTO ram (brand, model, speed, memoryType, price) VALUES 
("G.Skill", "Ripjaws V", "2800MHz", "DDR4 4 x 4GB PC4-22400", "$189.99");

CREATE TABLE soundCard (
ID int NOT NULL AUTO_INCREMENT,
brand varchar(64) NOT NULL,
model varchar(128) NOT NULL,
price varchar(16) NOT NULL,
PRIMARY KEY (ID));

INSERT INTO soundCard (brand, model, price) VALUES 
("Creative Labs", "Sound Blaster Audigy PCI-E 5.1", "$49.99");
INSERT INTO soundCard (brand, model, price) VALUES 
("ASUS", "Xonar DDGX PCI-E 5.1", "$64.99");
INSERT INTO soundCard (brand, model, price) VALUES 
("Creative Labs", "Sound Blaster Z PCI-E 5.1", "$149.99");
INSERT INTO soundCard (brand, model, price) VALUES 
("ASUS", "Xonar DG PCI-E 5.1", "$49.99");
INSERT INTO soundCard (brand, model, price) VALUES 
("ASUS", "Xonar DSX PCI-E 7.1", "$49.99");


CREATE TABLE prebuiltSystem (
ID int NOT NULL AUTO_INCREMENT,
processor int NOT NULL,
hardDrive int NOT NULL,
operatingSystem int NOT NULL,
display int NOT NULL,
ram int NOT NULL,
soundCard int NOT NULL,
PRIMARY KEY (ID),
FOREIGN KEY (processor) REFERENCES processor(ID),
FOREIGN KEY (ram) REFERENCES ram(ID),
FOREIGN KEY (hardDrive) REFERENCES hardDrive(ID),
FOREIGN KEY (display) REFERENCES display(ID),
FOREIGN KEY (operatingSystem) REFERENCES operatingSystem(ID),
FOREIGN KEY (soundCard) REFERENCES soundCard(ID));

INSERT INTO prebuiltSystem (processor, ram, hardDrive, display, operatingSystem, soundCard) VALUES 
(1, 1, 1, 1, 1, 1);
INSERT INTO prebuiltSystem (processor, ram, hardDrive, display, operatingSystem, soundCard) VALUES 
(2, 4, 5, 2, 2, 3);
INSERT INTO prebuiltSystem (processor, ram, hardDrive, display, operatingSystem, soundCard) VALUES 
(1, 6, 9, 7, 2, 3);
INSERT INTO prebuiltSystem (processor, ram, hardDrive, display, operatingSystem, soundCard) VALUES 
(6, 8, 1, 3, 1, 4);
INSERT INTO prebuiltSystem (processor, ram, hardDrive, display, operatingSystem, soundCard) VALUES 
(5, 3, 7, 4, 3, 4);