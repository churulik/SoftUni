-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema Universities
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema Universities
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Universities` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `Universities` ;

-- -----------------------------------------------------
-- Table `Universities`.`Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Universities`.`Titles` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(45) NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Universities`.`Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Universities`.`Courses` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(45) NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '')
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Universities`.`Proffesors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Universities`.`Proffesors` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(45) NOT NULL COMMENT '',
  `Titles_Id` INT NOT NULL COMMENT '',
  `Courses_Id` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  INDEX `fk_Proffesors_Titles1_idx` (`Titles_Id` ASC)  COMMENT '',
  INDEX `fk_Proffesors_Courses1_idx` (`Courses_Id` ASC)  COMMENT '',
  CONSTRAINT `fk_Proffesors_Titles1`
    FOREIGN KEY (`Titles_Id`)
    REFERENCES `Universities`.`Titles` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Proffesors_Courses1`
    FOREIGN KEY (`Courses_Id`)
    REFERENCES `Universities`.`Courses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Universities`.`Departments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Universities`.`Departments` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(45) NOT NULL COMMENT '',
  `Proffesors_Id` INT NOT NULL COMMENT '',
  `Courses_Id` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  INDEX `fk_Departments_Proffesors1_idx` (`Proffesors_Id` ASC)  COMMENT '',
  INDEX `fk_Departments_Courses1_idx` (`Courses_Id` ASC)  COMMENT '',
  CONSTRAINT `fk_Departments_Proffesors1`
    FOREIGN KEY (`Proffesors_Id`)
    REFERENCES `Universities`.`Proffesors` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Departments_Courses1`
    FOREIGN KEY (`Courses_Id`)
    REFERENCES `Universities`.`Courses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Universities`.`Faculties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Universities`.`Faculties` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(45) NOT NULL COMMENT '',
  `Departments_Id` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  INDEX `fk_Faculties_Departments_idx` (`Departments_Id` ASC)  COMMENT '',
  CONSTRAINT `fk_Faculties_Departments`
    FOREIGN KEY (`Departments_Id`)
    REFERENCES `Universities`.`Departments` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Universities`.`Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Universities`.`Students` (
  `Id` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(45) NOT NULL COMMENT '',
  `Faculties_Id` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  INDEX `fk_Students_Faculties1_idx` (`Faculties_Id` ASC)  COMMENT '',
  CONSTRAINT `fk_Students_Faculties1`
    FOREIGN KEY (`Faculties_Id`)
    REFERENCES `Universities`.`Faculties` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Universities`.`Students_Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Universities`.`Students_Courses` (
  `Students_Id` INT NOT NULL COMMENT '',
  `Courses_Id` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Students_Id`, `Courses_Id`)  COMMENT '',
  INDEX `fk_Students_Courses_Students1_idx` (`Students_Id` ASC)  COMMENT '',
  INDEX `fk_Students_Courses_Courses1_idx` (`Courses_Id` ASC)  COMMENT '',
  CONSTRAINT `fk_Students_Courses_Students1`
    FOREIGN KEY (`Students_Id`)
    REFERENCES `Universities`.`Students` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Students_Courses_Courses1`
    FOREIGN KEY (`Courses_Id`)
    REFERENCES `Universities`.`Courses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
