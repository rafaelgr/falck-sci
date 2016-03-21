/*
SQLyog Community Edition- MySQL GUI v8.03 
MySQL - 5.0.51b-community-nt : Database - lainsa_sci
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

USE `lainsa_sci`;

/*Table structure for table `resumen_revision` */

DROP TABLE IF EXISTS `resumen_revision`;

CREATE TABLE `resumen_revision` (
  `resumen_revision_id` int(11) NOT NULL auto_increment,
  `plantilla_id` int(11) default NULL,
  `fecha_ultima` datetime NOT NULL,
  `fecha_siguiente` datetime NOT NULL,
  `fecha_inicio` datetime NOT NULL,
  `dispositivo_id` int(11) default NULL,
  PRIMARY KEY  (`resumen_revision_id`),
  KEY `idx_resumen_revision_plantilla_id` (`plantilla_id`),
  KEY `idx_resumen_revision_dispositivo_id` (`dispositivo_id`),
  CONSTRAINT `ref_resumen_revision_dispositivo` FOREIGN KEY (`dispositivo_id`) REFERENCES `dispositivo` (`dispositivo_id`),
  CONSTRAINT `ref_resumen_revision_plantilla_revision` FOREIGN KEY (`plantilla_id`) REFERENCES `plantilla_revision` (`plantilla_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `resumen_revision` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
