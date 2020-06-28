/*
SQLyog Ultimate v12.4.3 (64 bit)
MySQL - 8.0.20 : Database - cafemanagement
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`cafemanagement` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `cafemanagement`;

/*Table structure for table `menu` */

DROP TABLE IF EXISTS `menu`;

CREATE TABLE `menu` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Code` varchar(8) COLLATE utf8_unicode_ci NOT NULL,
  `Name` varchar(25) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Price` float NOT NULL,
  `Mark` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `IsFood` char(1) COLLATE utf8_unicode_ci DEFAULT NULL COMMENT '0: is food, 1: is drink',
  `IsActive` char(1) COLLATE utf8_unicode_ci DEFAULT NULL COMMENT '0: active, 1: inactive',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `menu` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
