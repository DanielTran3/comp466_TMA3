CREATE DATABASE IF NOT EXISTS DigitalElectronics;
USE DigitalElectronics;

DROP TABLE IF EXISTS users;
CREATE TABLE users (
username VARCHAR(20) NOT NULL,
password VARCHAR(30) NOT NULL,
securityQuestion VARCHAR(256) NOT NULL,
securityAnswer VARCHAR(128) NOT NULL,
PRIMARY KEY (Username));

DROP TABLE IF EXISTS orders;
CREATE TABLE orders (
ID int NOT NULL AUTO_INCREMENT,
username VARCHAR(20) NOT NULL,
prebuiltSystem VARCHAR(2048),
display VARCHAR(512),
hardDrive VARCHAR(512),
operatingSystem VARCHAR(512),
processor VARCHAR(512),
ram VARCHAR(512),
soundcard VARCHAR(512),
totalPrice VARCHAR(16),
PRIMARY KEY (ID),
FOREIGN KEY (username) REFERENCES users(username));

/*
DROP TABLE IF EXISTS currentOrder;
CREATE TABLE currentOrder (
username VARCHAR(20) NOT NULL,
prebuiltSystem VARCHAR(2048),
display VARCHAR(512),
hardDrive VARCHAR(512),
operatingSystem VARCHAR(512),
processor VARCHAR(512),
ram VARCHAR(512),
soundCard VARCHAR(512),
totalPrice VARCHAR(16),
PRIMARY KEY (username),
FOREIGN KEY (username) REFERENCES users(username));
*/

/* USE ID OF TABLES INSTEAD */
DROP TABLE IF EXISTS currentOrder;
CREATE TABLE currentOrder (
username VARCHAR(20) NOT NULL,
prebuiltSystem VARCHAR(2048),
display VARCHAR(512),
hardDrive VARCHAR(512),
operatingSystem VARCHAR(512),
processor VARCHAR(512),
ram VARCHAR(512),
soundCard VARCHAR(512),
totalPrice VARCHAR(16),
PRIMARY KEY (username),
FOREIGN KEY (username) REFERENCES users(username));
