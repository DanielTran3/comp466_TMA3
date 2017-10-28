CREATE DATABASE IF NOT EXISTS DigitalElectronics;
USE DigitalElectronics;

DROP TABLE IF EXISTS users;
CREATE TABLE users (
username VARCHAR(20) NOT NULL,
password VARCHAR(30) NOT NULL,
securityQuestion VARCHAR(256) NOT NULL,
securityAnswer VARCHAR(128) NOT NULL,
PRIMARY KEY (Username));