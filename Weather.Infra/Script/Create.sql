-- SCRIPT DA CRIAÇÃO DO BANCO E TABELA


CREATE DATABASE weather;


CREATE  TABLE `weather`.`weather_city` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `city` VARCHAR(80) NOT NULL ,
  `temp` DECIMAL(5,2) NOT NULL ,
  `temp_min` DECIMAL(5,2) NOT NULL ,
  `temp_max` DECIMAL(5,2) NOT NULL ,
  `date` DATETIME NOT NULL,
  PRIMARY KEY (`Id`)
);