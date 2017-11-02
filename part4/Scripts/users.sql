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