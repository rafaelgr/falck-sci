/*
SQLyog Community v9.50 
MySQL - 5.5.19 : Database - sci_dosimetria
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`sci_dosimetria` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `sci_dosimetria`;

/*Table structure for table `agente_extintor` */

DROP TABLE IF EXISTS `agente_extintor`;

CREATE TABLE `agente_extintor` (
  `descripcion` varchar(255) DEFAULT NULL,
  `agente_extintor_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`agente_extintor_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

/*Data for the table `agente_extintor` */

insert  into `agente_extintor`(`descripcion`,`agente_extintor_id`) values ('POLVO QUIMICO SECO',11);
insert  into `agente_extintor`(`descripcion`,`agente_extintor_id`) values ('CO2',12);
insert  into `agente_extintor`(`descripcion`,`agente_extintor_id`) values ('Nitrogeno',13);
insert  into `agente_extintor`(`descripcion`,`agente_extintor_id`) values ('AGUA',14);

/*Table structure for table `campo` */

DROP TABLE IF EXISTS `campo`;

CREATE TABLE `campo` (
  `tipo_id` int(11) DEFAULT NULL,
  `posicion` int(11) NOT NULL,
  `plantilla_id` int(11) DEFAULT NULL,
  `nombre` varchar(255) DEFAULT NULL,
  `campo_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`campo_id`),
  KEY `idx_campo_plantilla_id` (`plantilla_id`),
  KEY `ref_campo_tipo_campo` (`tipo_id`),
  CONSTRAINT `ref_campo_plantilla_revision` FOREIGN KEY (`plantilla_id`) REFERENCES `plantilla_revision` (`plantilla_id`),
  CONSTRAINT `ref_campo_tipo_campo` FOREIGN KEY (`tipo_id`) REFERENCES `tipo_campo` (`tipo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=135 DEFAULT CHARSET=latin1;

/*Data for the table `campo` */

insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,1,42,'¿ES VISIBLE Y ACCESIBLE?',77);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,2,42,'¿SU SITUACION ES CORRECTA?',78);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,3,42,'¿SU SEÑALIZACION ES ADECUADA?',79);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,4,42,'¿EL ANCLAJE Y SOPORTE SON CORRECTOS?',80);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,5,42,'¿LA ALTURA DESDE EL SUELO ES CORRECTA? (máximo 1,70 m)',81);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,6,42,'ASPECTO EXTERNO ¿ESTA EXENTO DE CORROSION, GOLPES O ABOLLADURAS?',82);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,7,42,'¿LOS PRECINTOS Y/O SEGUROS ESTAN INTACTOS?',83);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (5,8,42,'PESO DEL EXTINTOR',86);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,10,42,'Presion Adosada, ¿ES CORRECTO EL PESO DEL BOTELLÍN?',88);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,11,42,'¿LA PRESIÓN INTERIOR ES CORRECTA? (POLVO)',89);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (1,1,45,'QUITAR DEL RECIPIENTE TODOS LOS ACCESORIOS QUE SE COMUNIQUEN DIRECTAMENTE CON EL RECIPIENTE',90);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,2,45,'SE COLOCA EL RECIPIENTE EN SU SOPORTE Y SE LLENA CON AGUA (POLVO)',91);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,1,44,'¿ES VISIBLE Y ACCESIBLE?',92);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,2,44,'¿SU STUTACIÓN ES CORRECTA?',93);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,3,44,'¿SU SEÑALIZACIÓN ES ADECUADA?',94);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,4,44,'¿EL ANCLAJE Y SOPORTE SON CORRECTOS?',95);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,5,44,'¿LA ALTURA DESDE EL SUELO ES CORRECTA? (máximo 1,70 m)',96);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,6,44,'ASPECTO EXTERNO ¿ESTÁ EXENTO DE CORROSIÓN, GOLPES O ABOLLADURAS?',97);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,7,44,'¿LOS PRECINTOS Y/O SEGUROS ESTÁN INTACTOS?',98);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (5,8,44,'PESO DEL EXTINTOR',99);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,9,44,'ESTADO DEL AGENTE ¿ESTÁ EXENTO DE ANOMALÍAS? ',100);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,10,44,'Presion Adosada, ¿ES CORRECTO EL PESO DEL BOTELLÍN?',101);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,1,48,'¿ES VISIBLE Y ACCESIBLE?',102);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,2,48,'¿SU SITUACIÓN ES CORRECTA?',103);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,3,48,'¿SU SEÑALIZACIÓN ES ADECUADA?',104);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,4,48,'¿EL ANCLAJE Y SOPORTE SON CORRECTOS?',105);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,5,48,'¿LA ALTURA DESDE EL SUELO ES CORRECTA? (máximo 1.70 m)',106);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,6,48,'ASPECTO EXTERNO ¿ESTA EXENTO DE CORROSIÓN, GOLPES O ABOLLADURAS?',107);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (5,8,48,'PESO DEL EXTINTOR',108);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,9,48,'¿TIENE LA PRESIÓN CORRECTA?',109);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,1,49,'¿ES VISIBLE Y ACCESIBLE?',110);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,4,49,'¿EL ANCLAJE Y SOPORTE SON CORRECTOS?',111);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,3,49,'¿SU SEÑALIZACIÓN ES ADECUADA?',112);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,2,49,'¿SU SITUACIÓN ES CORRECTA?',113);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,5,49,'¿LA ALTURA DESDE EL SUELO ES CORRECTA? (máximo 1.70 m)',114);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,6,49,'ASPECTO EXTERNO ¿ESTA EXENTO DE CORROSIÓN, GOLPES O ABOLLADURAS?',115);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,7,49,'¿LOS PRECINTOS Y/O SEGUROS ESTÁN INTACTOS?',116);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,7,48,'¿LOS PRECINTOS Y/O SEGUROS ESTÁN INTACTOS?',117);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (5,8,49,'PESO DEL EXTINTOR',118);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,9,49,'¿TIENE LA PRESIÓN CORRECTA?',119);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,1,50,'¿ES VISIBLE Y ACCESIBLE?',120);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,2,50,'¿SU SEÑALIZACIÓN ES ADECUADA?',121);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,4,50,'¿ES CORRECTA LA PRESIÓN DE SERVICIO QUE MARCA EL MANÓMETRO?',122);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (1,3,50,'INSPECCIÓN DE TODOS LOS COMPONENTES PROCEDIENDO A DESENROLLAR LA MANGUERA EN TODA SU EXTENSIÓN ',123);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,5,50,'LIMPIAR EL CONJUNTO Y ENGRASAR CIERRES Y BISAGRAS  EN PUERTAS DE ARMARIO',124);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,1,52,'COMRPROBAR ARNES',125);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,2,52,'COMPROBAR PULMO',126);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (1,1,53,'Acceso, visibilidad y estado general',127);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,2,53,'Peso correto',128);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,10,48,'¿LA IDENTIFICACIÓN ES CORRECTA?',129);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,11,48,'¿VIENEN LAS FECHAS DE LAS ANTERIORES REVISIONES?',130);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,12,48,'ESTADO DE LA BOQUILLA',131);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,13,48,'¿TIENE MARCA DE CONFORMIDAD A NORMALS?',132);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (4,14,48,'¿ESTA RETIMBRADO EL BOTELLIN CONFORME AL RAP?',133);
insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (1,1,54,'¿Trabajo realizado?',134);

/*Table structure for table `carnet_radiologico` */

DROP TABLE IF EXISTS `carnet_radiologico`;

CREATE TABLE `carnet_radiologico` (
  `numero` varchar(255) DEFAULT NULL,
  `fecha_emision` datetime NOT NULL,
  `carnet_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`carnet_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `carnet_radiologico` */

/*Table structure for table `categoria` */

DROP TABLE IF EXISTS `categoria`;

CREATE TABLE `categoria` (
  `categoria_id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`categoria_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `categoria` */

insert  into `categoria`(`categoria_id`,`nombre`) values (1,'Revisiones');
insert  into `categoria`(`categoria_id`,`nombre`) values (2,'Comunicaciones oficiales');

/*Table structure for table `datos_revision` */

DROP TABLE IF EXISTS `datos_revision`;

CREATE TABLE `datos_revision` (
  `valor` text,
  `revision_id` int(11) DEFAULT NULL,
  `datos_id` int(11) NOT NULL AUTO_INCREMENT,
  `campo_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`datos_id`),
  KEY `idx_datos_revision_campo_id` (`campo_id`),
  KEY `idx_datos_revision_revision_id` (`revision_id`),
  CONSTRAINT `ref_datos_revision_campo` FOREIGN KEY (`campo_id`) REFERENCES `campo` (`campo_id`),
  CONSTRAINT `ref_datos_revision_revision` FOREIGN KEY (`revision_id`) REFERENCES `revision` (`revision_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2798 DEFAULT CHARSET=latin1;

/*Data for the table `datos_revision` */

insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('False|',306,1080,90);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|jnb',306,1081,91);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',315,1146,82);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',315,1147,83);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',315,1148,86);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',315,1149,88);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',315,1150,81);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',315,1151,79);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',315,1152,80);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',315,1153,77);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',315,1154,78);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',315,1155,89);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,316,1156,97);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,316,1157,98);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,316,1158,99);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,316,1159,100);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,316,1160,96);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,316,1161,94);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,316,1162,95);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,316,1163,92);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,316,1164,93);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,316,1165,101);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,317,1166,90);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',317,1167,91);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,321,1195,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,321,1196,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,321,1197,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,321,1198,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,321,1199,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,321,1200,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,321,1201,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,321,1202,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,321,1203,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('13,8|',325,1231,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',325,1232,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',325,1233,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',325,1234,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|Falta señal. Se repone.',325,1235,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('NA|',325,1236,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',325,1237,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',325,1238,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',325,1239,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,327,1249,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,327,1250,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,327,1251,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,327,1252,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,327,1253,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,327,1254,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,327,1255,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,327,1256,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,327,1257,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('13,7|',328,1258,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',328,1259,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',328,1260,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|Anclaje roto. Se coloca uno nuevo',328,1261,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',328,1262,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('NA|',328,1263,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|Se encuentra en el suelo. Se coloca en su sitio',328,1264,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',328,1265,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',328,1266,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,329,1267,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,329,1268,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,329,1269,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,329,1270,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,329,1271,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,329,1272,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,329,1273,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,329,1274,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,329,1275,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,330,1276,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,330,1277,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,330,1278,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,330,1279,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,330,1280,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,330,1281,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,330,1282,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,330,1283,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,330,1284,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,331,1285,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,331,1286,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,331,1287,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,331,1288,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,331,1289,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,331,1290,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,331,1291,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,331,1292,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,331,1293,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('13,8|',341,1375,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',341,1376,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',341,1377,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',341,1378,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',341,1379,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',341,1380,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',341,1381,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',341,1382,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',341,1383,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('13,7|',342,1384,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',342,1385,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',342,1386,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',342,1387,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',342,1388,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',342,1389,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',342,1390,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',342,1391,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',342,1392,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('13,8|',344,1402,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',344,1403,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',344,1404,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',344,1405,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',344,1406,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',344,1407,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',344,1408,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',344,1409,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',344,1410,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('13,4|',346,1420,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',346,1421,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',346,1422,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',346,1423,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',346,1424,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',346,1425,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',346,1426,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',346,1427,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',346,1428,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,347,1429,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,347,1430,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,347,1431,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,347,1432,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,347,1433,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,347,1434,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,347,1435,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,347,1436,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,347,1437,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,348,1438,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,348,1439,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,348,1440,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,348,1441,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,348,1442,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,348,1443,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,348,1444,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,348,1445,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,348,1446,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,350,1456,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,350,1457,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,350,1458,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,350,1459,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,350,1460,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,350,1461,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,350,1462,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,350,1463,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,350,1464,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,351,1465,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,351,1466,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,351,1467,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,351,1468,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,351,1469,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,351,1470,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,351,1471,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,351,1472,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,351,1473,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,352,1474,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,352,1475,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,352,1476,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,352,1477,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,352,1478,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,352,1479,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,352,1480,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,352,1481,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,352,1482,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,353,1483,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,353,1484,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,353,1485,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,353,1486,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,353,1487,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,353,1488,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,353,1489,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,353,1490,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,353,1491,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,354,1492,122);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,354,1493,121);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,354,1494,120);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,354,1495,123);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,354,1496,124);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',356,1497,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',356,1498,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',356,1499,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|',356,1500,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',356,1501,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',356,1502,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|',356,1503,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|',356,1504,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',356,1505,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,357,1506,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,357,1507,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,357,1508,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,357,1509,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,357,1510,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,357,1511,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',357,1512,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,357,1513,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,357,1514,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,358,1515,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,358,1516,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,358,1517,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',358,1518,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',358,1519,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,358,1520,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',358,1521,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,358,1522,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,358,1523,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('13,8|',359,1524,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',359,1525,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',359,1526,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',359,1527,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|Falta señal. Se repone.',359,1528,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('NA|',359,1529,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',359,1530,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',359,1531,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',359,1532,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('13,7|ok',360,1533,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|pintura mal estado',360,1534,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',360,1535,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',360,1536,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',360,1537,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',360,1538,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|Se encuentra en el suelo. Se coloca en su sitio',360,1539,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',360,1540,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|',360,1541,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('13,7|',361,1542,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',361,1543,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',361,1544,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',361,1545,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',361,1546,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',361,1547,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|no visivlw',361,1548,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',361,1549,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',361,1550,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('13,8|',362,1551,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',362,1552,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',362,1553,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',362,1554,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',362,1555,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',362,1556,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',362,1557,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',362,1558,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',362,1559,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('13,4|',363,1560,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',363,1561,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',363,1562,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',363,1563,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',363,1564,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',363,1565,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',363,1566,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',363,1567,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',363,1568,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',364,1569,82);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',364,1570,83);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',364,1571,86);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',364,1572,88);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',364,1573,81);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',364,1574,79);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',364,1575,80);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',364,1576,77);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',364,1577,78);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',364,1578,89);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('13,8|',365,1579,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',365,1580,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',365,1581,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',365,1582,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|Falta señal. Se repone.',365,1583,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('NA|',365,1584,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',365,1585,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',365,1586,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',365,1587,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('13,7|',366,1588,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',366,1589,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',366,1590,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|Anclaje roto. Se coloca uno nuevo',366,1591,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',366,1592,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('NA|',366,1593,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|Se encuentra en el suelo. Se coloca en su sitio',366,1594,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',366,1595,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',366,1596,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,367,1597,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,367,1598,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,367,1599,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,367,1600,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,367,1601,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,367,1602,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,367,1603,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,367,1604,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,367,1605,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,368,1606,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,368,1607,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,368,1608,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,368,1609,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,368,1610,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,368,1611,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,368,1612,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,368,1613,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,368,1614,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,369,1615,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,369,1616,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,370,1617,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,370,1618,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,370,1619,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,370,1620,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,370,1621,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,370,1622,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,370,1623,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,370,1624,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,370,1625,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',371,1626,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',371,1627,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',371,1628,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',371,1629,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',371,1630,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',371,1631,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',371,1632,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',371,1633,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',371,1634,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,372,1635,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|',372,1636,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,376,1657,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,376,1658,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,376,1659,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,376,1660,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,376,1661,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,376,1662,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,376,1663,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,376,1664,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,376,1665,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,377,1666,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,377,1667,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,377,1668,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,377,1669,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,377,1670,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,377,1671,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,377,1672,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,377,1673,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,377,1674,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,378,1675,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|',378,1676,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,379,1677,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,379,1678,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,379,1679,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,379,1680,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,379,1681,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,379,1682,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,379,1683,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,379,1684,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,379,1685,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,380,1686,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,380,1687,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,380,1688,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,380,1689,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,380,1690,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,380,1691,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,380,1692,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,380,1693,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,380,1694,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,381,1695,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,381,1696,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,382,1697,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,382,1698,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,382,1699,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,382,1700,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,382,1701,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,382,1702,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,382,1703,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,382,1704,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,382,1705,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,383,1706,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,383,1707,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,383,1708,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,383,1709,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,383,1710,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,383,1711,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,383,1712,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,383,1713,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,383,1714,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,384,1715,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,384,1716,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,385,1717,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,385,1718,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,385,1719,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,385,1720,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,385,1721,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,385,1722,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,385,1723,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,385,1724,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,385,1725,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,386,1726,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,386,1727,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,386,1728,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,386,1729,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,386,1730,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,386,1731,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,386,1732,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,386,1733,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,386,1734,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,387,1735,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,387,1736,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,388,1737,82);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,388,1738,83);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,388,1739,86);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,388,1740,88);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,388,1741,81);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,388,1742,79);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,388,1743,80);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,388,1744,77);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,388,1745,78);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,388,1746,89);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,389,1747,97);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,389,1748,98);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,389,1749,99);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,389,1750,100);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,389,1751,96);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,389,1752,94);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,389,1753,95);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,389,1754,92);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,389,1755,93);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,389,1756,101);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,390,1757,90);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|',390,1758,91);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,392,1769,82);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,392,1770,83);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,392,1771,86);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,392,1772,88);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,392,1773,81);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,392,1774,79);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,392,1775,80);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,392,1776,77);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,392,1777,78);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,392,1778,89);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,393,1779,97);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,393,1780,98);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,393,1781,99);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,393,1782,100);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,393,1783,96);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,393,1784,94);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,393,1785,95);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,393,1786,92);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,393,1787,93);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,393,1788,101);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,395,1791,90);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,395,1792,91);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,396,1793,82);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,396,1794,83);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,396,1795,86);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,396,1796,88);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,396,1797,81);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,396,1798,79);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,396,1799,80);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,396,1800,77);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,396,1801,78);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,396,1802,89);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,397,1803,97);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,397,1804,98);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,397,1805,99);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,397,1806,100);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,397,1807,96);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,397,1808,94);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,397,1809,95);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,397,1810,92);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,397,1811,93);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,397,1812,101);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,398,1813,90);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,398,1814,91);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,399,1815,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,399,1816,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,399,1817,129);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,399,1818,131);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,399,1819,130);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,399,1820,132);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,399,1821,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,399,1822,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,399,1823,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,399,1824,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,399,1825,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,399,1826,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,399,1827,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,399,1828,133);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,400,1829,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,400,1830,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,400,1831,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,400,1832,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,400,1833,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,400,1834,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,400,1835,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,400,1836,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,400,1837,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,401,1838,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,401,1839,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,416,1956,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,416,1957,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,416,1958,129);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,416,1959,131);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,416,1960,130);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,416,1961,132);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,416,1962,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,416,1963,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,416,1964,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,416,1965,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,416,1966,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,416,1967,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,416,1968,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,416,1969,133);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',418,1972,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',418,1973,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',418,1974,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',418,1975,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',418,1976,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',418,1977,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',418,1978,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',418,1979,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',418,1980,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,419,1981,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,419,1982,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',420,1983,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',420,1984,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',420,1985,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',420,1986,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',420,1987,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',420,1988,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',420,1989,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',420,1990,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',420,1991,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,421,1992,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,421,1993,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,421,1994,129);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,421,1995,131);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,421,1996,130);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,421,1997,132);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,421,1998,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,421,1999,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,421,2000,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,421,2001,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,421,2002,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,421,2003,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,421,2004,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,421,2005,133);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,422,2006,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,422,2007,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,433,2085,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,433,2086,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,433,2087,129);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,433,2088,131);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,433,2089,130);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,433,2090,132);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,433,2091,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,433,2092,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,433,2093,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,433,2094,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,433,2095,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,433,2096,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,433,2097,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,433,2098,133);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,434,2099,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,434,2100,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,434,2101,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,434,2102,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,434,2103,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,434,2104,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,434,2105,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,434,2106,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,434,2107,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,435,2108,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,435,2109,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,442,2160,82);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,442,2161,83);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,442,2162,86);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,442,2163,88);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,442,2164,81);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,442,2165,79);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,442,2166,80);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,442,2167,77);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,442,2168,78);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,442,2169,89);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,443,2170,97);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,443,2171,98);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,443,2172,99);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,443,2173,100);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,443,2174,96);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,443,2175,94);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,443,2176,95);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,443,2177,92);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,443,2178,93);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,443,2179,101);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,444,2180,90);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',444,2181,91);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,445,2182,90);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',445,2183,91);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,446,2184,82);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,446,2185,83);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,446,2186,86);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,446,2187,88);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,446,2188,81);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,446,2189,79);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,446,2190,80);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,446,2191,77);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,446,2192,78);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,446,2193,89);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,447,2194,97);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,447,2195,98);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,447,2196,99);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,447,2197,100);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,447,2198,96);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,447,2199,94);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,447,2200,95);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,447,2201,92);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,447,2202,93);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,447,2203,101);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',452,2243,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',452,2244,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',452,2245,129);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',452,2246,131);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',452,2247,130);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',452,2248,132);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',452,2249,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|',452,2250,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',452,2251,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',452,2252,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',452,2253,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',452,2254,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',452,2255,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',452,2256,133);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,455,2277,90);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,455,2278,91);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',457,2293,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',457,2294,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',457,2295,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|',457,2296,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',457,2297,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',457,2298,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',457,2299,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',457,2300,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',457,2301,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',459,2304,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',459,2305,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',459,2306,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|',459,2307,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',459,2308,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',459,2309,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',459,2310,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',459,2311,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',459,2312,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,460,2313,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,460,2314,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,460,2315,129);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,460,2316,131);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,460,2317,130);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,460,2318,132);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,460,2319,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,460,2320,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,460,2321,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,460,2322,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,460,2323,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,460,2324,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,460,2325,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,460,2326,133);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,461,2327,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|',461,2328,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',463,2331,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',463,2332,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',463,2333,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|',463,2334,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',463,2335,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',463,2336,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',463,2337,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',463,2338,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',463,2339,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,465,2354,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,465,2355,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',466,2356,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',466,2357,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',466,2358,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|',466,2359,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',466,2360,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',466,2361,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',466,2362,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',466,2363,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',466,2364,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,467,2365,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,467,2366,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,467,2367,129);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,467,2368,131);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,467,2369,130);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,467,2370,132);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,467,2371,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,467,2372,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,467,2373,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,467,2374,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,467,2375,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,467,2376,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,467,2377,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,467,2378,133);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,468,2379,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,468,2380,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',469,2381,82);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',469,2382,83);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',469,2383,86);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',469,2384,88);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',469,2385,81);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',469,2386,79);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',469,2387,80);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',469,2388,77);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',469,2389,78);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',469,2390,89);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,471,2401,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,471,2402,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,471,2403,129);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,471,2404,131);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,471,2405,130);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,471,2406,132);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,471,2407,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,471,2408,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,471,2409,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,471,2410,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,471,2411,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,471,2412,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,471,2413,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,471,2414,133);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',472,2415,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',472,2416,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',472,2417,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',472,2418,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',472,2419,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',472,2420,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|',472,2421,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',472,2422,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',472,2423,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',474,2426,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',474,2427,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',474,2428,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',474,2429,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',474,2430,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',474,2431,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('N|',474,2432,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',474,2433,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',474,2434,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,475,2435,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,475,2436,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,475,2437,129);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,475,2438,131);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,475,2439,130);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,475,2440,132);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,475,2441,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,475,2442,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,475,2443,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,475,2444,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,475,2445,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,475,2446,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,475,2447,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,475,2448,133);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,476,2449,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,476,2450,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,477,2451,82);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,477,2452,83);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,477,2453,86);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,477,2454,88);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,477,2455,81);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,477,2456,79);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,477,2457,80);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,477,2458,77);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,477,2459,78);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,477,2460,89);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,478,2461,90);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',478,2462,91);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,479,2463,82);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,479,2464,83);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,479,2465,86);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,479,2466,88);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,479,2467,81);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,479,2468,79);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,479,2469,80);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,479,2470,77);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,479,2471,78);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,479,2472,89);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,480,2473,97);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,480,2474,98);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,480,2475,99);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,480,2476,100);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,480,2477,96);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,480,2478,94);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,480,2479,95);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,480,2480,92);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,480,2481,93);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,480,2482,101);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',484,2508,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',484,2509,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',484,2510,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',484,2511,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',484,2512,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',484,2513,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',484,2514,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',484,2515,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',484,2516,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,485,2517,90);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',485,2518,91);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,486,2519,82);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,486,2520,83);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,486,2521,86);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,486,2522,88);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,486,2523,81);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,486,2524,79);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,486,2525,80);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,486,2526,77);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,486,2527,78);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,486,2528,89);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,487,2529,97);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,487,2530,98);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,487,2531,99);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,487,2532,100);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,487,2533,96);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,487,2534,94);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,487,2535,95);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,487,2536,92);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,487,2537,93);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,487,2538,101);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',488,2539,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',488,2540,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',488,2541,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',488,2542,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',488,2543,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',488,2544,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',488,2545,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',488,2546,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',488,2547,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,490,2562,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,490,2563,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',491,2564,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',491,2565,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',491,2566,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',491,2567,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',491,2568,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',491,2569,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',491,2570,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',491,2571,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',491,2572,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,493,2587,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,493,2588,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',494,2589,116);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',494,2590,115);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',494,2591,114);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',494,2592,113);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',494,2593,112);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',494,2594,118);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',494,2595,110);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',494,2596,111);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',494,2597,119);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,496,2612,127);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,496,2613,128);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,497,2614,117);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,497,2615,109);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,497,2616,129);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,497,2617,131);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,497,2618,130);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,497,2619,132);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,497,2620,108);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,497,2621,106);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,497,2622,102);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,497,2623,107);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,497,2624,103);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,497,2625,105);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,497,2626,104);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,497,2627,133);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,500,2648,90);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',500,2649,91);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,501,2650,90);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',501,2651,91);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,502,2652,82);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,502,2653,83);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,502,2654,86);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,502,2655,88);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,502,2656,81);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,502,2657,79);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,502,2658,80);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,502,2659,77);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,502,2660,78);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,502,2661,89);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,503,2662,97);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,503,2663,98);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,503,2664,99);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,503,2665,100);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,503,2666,96);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,503,2667,94);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,503,2668,95);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,503,2669,92);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,503,2670,93);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,503,2671,101);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,506,2692,90);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('S|',506,2693,91);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',512,2736,97);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',512,2737,98);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',512,2738,99);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',512,2739,100);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',512,2740,96);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',512,2741,94);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',512,2742,95);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',512,2743,92);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',512,2744,93);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',512,2745,101);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,513,2746,90);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,513,2747,91);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',514,2748,97);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',514,2749,98);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',514,2750,99);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',514,2751,100);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',514,2752,96);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',514,2753,94);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',514,2754,95);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',514,2755,92);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',514,2756,93);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',514,2757,101);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',516,2768,97);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',516,2769,98);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',516,2770,99);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',516,2771,100);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',516,2772,96);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',516,2773,94);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',516,2774,95);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',516,2775,92);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',516,2776,93);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',516,2777,101);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,517,2778,82);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,517,2779,83);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,517,2780,86);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,517,2781,88);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,517,2782,81);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,517,2783,79);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,517,2784,80);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,517,2785,77);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,517,2786,78);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values (NULL,517,2787,89);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',518,2788,82);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',518,2789,83);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',518,2790,86);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',518,2791,88);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',518,2792,81);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',518,2793,79);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',518,2794,80);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',518,2795,77);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',518,2796,78);
insert  into `datos_revision`(`valor`,`revision_id`,`datos_id`,`campo_id`) values ('|',518,2797,89);

/*Table structure for table `direccion` */

DROP TABLE IF EXISTS `direccion`;

CREATE TABLE `direccion` (
  `provincia` varchar(255) DEFAULT NULL,
  `poblacion` varchar(255) DEFAULT NULL,
  `pais` varchar(255) DEFAULT NULL,
  `instalacion_id` int(11) DEFAULT NULL,
  `empresa_id` int(11) DEFAULT NULL,
  `direccion_id` int(11) NOT NULL AUTO_INCREMENT,
  `dir_postal` varchar(255) DEFAULT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `cod_postal` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`direccion_id`),
  KEY `idx_direccion_instalacion_id` (`instalacion_id`),
  KEY `idx_direccion_empresa_id` (`empresa_id`),
  CONSTRAINT `ref_direccion_empresa` FOREIGN KEY (`empresa_id`) REFERENCES `empresa` (`empresa_id`),
  CONSTRAINT `ref_direccion_instalacion` FOREIGN KEY (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;

/*Data for the table `direccion` */

insert  into `direccion`(`provincia`,`poblacion`,`pais`,`instalacion_id`,`empresa_id`,`direccion_id`,`dir_postal`,`descripcion`,`cod_postal`) values ('Madrid','Madrid','España',NULL,28,20,'Campo de las Naciones Avenida del Partenón 12','Domicilio Social','28042');
insert  into `direccion`(`provincia`,`poblacion`,`pais`,`instalacion_id`,`empresa_id`,`direccion_id`,`dir_postal`,`descripcion`,`cod_postal`) values ('Tenerife','Santa Cruz de Tenerife','España',46,NULL,21,'Avenida Manuel Hermoso Rojas 3','','38005');

/*Table structure for table `dispositivo` */

DROP TABLE IF EXISTS `dispositivo`;

CREATE TABLE `dispositivo` (
  `tipo_id` int(11) DEFAULT NULL,
  `posicion` varchar(255) DEFAULT NULL,
  `modelo_id` int(11) DEFAULT NULL,
  `instalacion_id` int(11) DEFAULT NULL,
  `fecha_inicio_revision` datetime NOT NULL,
  `fecha_fabricacion` datetime NOT NULL,
  `fecha_caducidad` datetime NOT NULL,
  `dispositivo_id` int(11) NOT NULL AUTO_INCREMENT,
  `comentarios` varchar(255) DEFAULT NULL,
  `nombre` varchar(255) DEFAULT NULL,
  `numero_industria` varchar(255) DEFAULT NULL,
  `fabricante_id` int(11) DEFAULT NULL,
  `agente_extintor_id` int(11) DEFAULT NULL,
  `dispositivo_padre_id` int(11) DEFAULT NULL,
  `caducado` tinyint(1) NOT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  `estado` varchar(255) NOT NULL,
  `funcion` varchar(255) NOT NULL,
  `cod_barras` varchar(255) NOT NULL,
  PRIMARY KEY (`dispositivo_id`),
  KEY `idx_dispositivo_instalacion_id` (`instalacion_id`),
  KEY `idx_dispositivo_agente_extintor_id` (`agente_extintor_id`),
  KEY `idx_dispositivo_fabricante_id` (`fabricante_id`),
  KEY `idx_dispositivo_dispositivo_padre_dispositivo_id` (`dispositivo_padre_id`),
  KEY `ref_dispositivo_modelo_dispositivo` (`modelo_id`),
  KEY `ref_dispositivo_tipo_dispositivo` (`tipo_id`),
  CONSTRAINT `ref_dispositivo_tipo_dispositivo` FOREIGN KEY (`tipo_id`) REFERENCES `tipo_dispositivo` (`tipo_id`),
  CONSTRAINT `ref_dispositivo_agente_extintor` FOREIGN KEY (`agente_extintor_id`) REFERENCES `agente_extintor` (`agente_extintor_id`),
  CONSTRAINT `ref_dispositivo_fabricante` FOREIGN KEY (`fabricante_id`) REFERENCES `fabricante` (`fabricante_id`),
  CONSTRAINT `ref_dispositivo_instalacion` FOREIGN KEY (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`),
  CONSTRAINT `ref_dispositivo_modelo_dispositivo` FOREIGN KEY (`modelo_id`) REFERENCES `modelo_dispositivo` (`modelo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=290 DEFAULT CHARSET=latin1;

/*Data for the table `dispositivo` */

insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',34,22,'0000-00-00 00:00:00','2003-09-30 00:00:00','2023-09-30 00:00:00',100,'SIN CARTEL NI SE¥ALIZACION','9','3070431',NULL,11,NULL,0,NULL,'A','R','9');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL ESTE DEL DEP-15',34,22,'0000-00-00 00:00:00','2003-09-30 00:00:00','2023-09-30 00:00:00',101,'','79','3070435',NULL,11,NULL,0,NULL,'S','R','79');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL SUR DEL D-4115',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',102,'','80','169',NULL,11,NULL,0,NULL,'N','O','80');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',103,'','81','100',NULL,11,NULL,0,NULL,'A','O','81');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL ESTE TALLER SEGURIDAD',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',104,'','83','104',NULL,11,NULL,0,NULL,'N','O','83');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL SUR DP 13',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',105,'','84','123',NULL,11,NULL,0,NULL,'N','O','84');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',106,'se cambia manguera','85','108',NULL,11,NULL,0,NULL,'A','O','85');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUR SALA RACK SE 17',35,22,'0000-00-00 00:00:00','2007-12-01 00:00:00','2027-12-01 00:00:00',107,'','86','719262',NULL,11,NULL,0,NULL,'N','O','86');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',34,22,'0000-00-00 00:00:00','2001-03-30 00:00:00','2021-03-30 00:00:00',108,'','87','3035431',NULL,11,NULL,0,NULL,'A','O','87');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',31,22,'0000-00-00 00:00:00','1992-06-09 00:00:00','2012-06-09 00:00:00',109,'','143','261111',NULL,12,NULL,1,'2012-02-17 00:00:00','N','O','143');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUB17 PLANTA BAJA',31,22,'0000-00-00 00:00:00','1999-06-30 00:00:00','2019-06-30 00:00:00',110,'','144','288587',NULL,12,NULL,0,NULL,'N','O','144');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'ALMACEN SEGURIDAD (POLIOLES SUB 17)',31,22,'0000-00-00 00:00:00','1999-06-30 00:00:00','2019-06-30 00:00:00',111,'','145','284537',NULL,12,NULL,0,NULL,'N','O','145');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'ALMACEN SEGURIDAD (POLIOLES SUB 17)',31,22,'0000-00-00 00:00:00','1999-06-30 00:00:00','2019-06-30 00:00:00',112,'','146','284510',NULL,12,NULL,0,NULL,'N','O','146');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUB 17 1¦ PLANTA',31,22,'0000-00-00 00:00:00','1999-06-30 00:00:00','2019-06-30 00:00:00',113,'SIN CARTEL NI SE¥ALIZACION','147','284498',NULL,12,NULL,0,NULL,'N','O','147');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 1¦ PLANTA',31,22,'0000-00-00 00:00:00','1999-06-30 00:00:00','2019-06-30 00:00:00',114,'SIN CARTEL NI SE¥ALIZACION','148','284564',NULL,12,NULL,0,NULL,'N','O','148');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUB 17 1¦ PLANTA',31,22,'0000-00-00 00:00:00','1999-03-30 00:00:00','2019-03-30 00:00:00',115,'','149','261050',NULL,12,NULL,0,NULL,'N','O','149');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUBESTACION 17',31,22,'0000-00-00 00:00:00','1999-03-30 00:00:00','2019-03-30 00:00:00',116,'','153','261086',NULL,12,NULL,0,NULL,'N','O','153');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES DESCARGA DE OE AL N',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',117,'','183','125',NULL,11,NULL,0,NULL,'N','O','183');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES DESCARGA DE OE AL O',34,22,'0000-00-00 00:00:00','2000-03-30 00:00:00','2020-03-30 00:00:00',118,'','184','1681483',NULL,11,NULL,0,NULL,'N','O','184');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES DESCARGA DE OE AL SO',34,22,'0000-00-00 00:00:00','2000-03-30 00:00:00','2020-03-30 00:00:00',119,'se pone precinto','185','1681486',NULL,11,NULL,0,NULL,'N','O','185');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES DESCARGA DE OE AL S',34,22,'0000-00-00 00:00:00','2000-03-30 00:00:00','2020-03-30 00:00:00',120,'','186','1681481',NULL,11,NULL,0,NULL,'N','O','186');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE PUERTA ALM. MAT PRIMAS',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',121,'','187','10',NULL,11,NULL,0,NULL,'N','O','187');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES PASILLO BOMBAS GLECERINA',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',122,'','188','28',NULL,11,NULL,0,NULL,'N','O','188');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE CASETA OPERADORES',35,22,'0000-00-00 00:00:00','2004-10-30 00:00:00','2024-10-30 00:00:00',123,'Desplazado de su lugar por contenedores ','189','3650374',NULL,11,NULL,0,NULL,'N','O','189');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE ESCALERA SUBESTACION',35,22,'0000-00-00 00:00:00','2004-10-30 00:00:00','2024-10-30 00:00:00',124,'sin cartel','190','3650368',NULL,11,NULL,0,NULL,'N','O','190');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE PUERTA SALA RACK',35,22,'0000-00-00 00:00:00','2010-12-30 00:00:00','2030-12-30 00:00:00',125,'','191','5',NULL,11,NULL,0,NULL,'N','O','191');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE TANQUE D-4150-M',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',126,'cartel descolorido','192','132',NULL,11,NULL,0,NULL,'N','O','192');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE TANQUE D-4150-J',35,22,'0000-00-00 00:00:00','2010-01-01 00:00:00','2030-01-01 00:00:00',127,'','193','10',NULL,11,NULL,0,NULL,'N','O','193');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES MURO ESTACION DE CARGA AL S',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',128,'','194','102',NULL,11,NULL,0,NULL,'N','O','194');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES MURO ESTACION CARGA AL S',34,22,'0000-00-00 00:00:00','1999-03-30 00:00:00','2019-03-30 00:00:00',129,'','195','1670265',NULL,11,NULL,0,NULL,'N','O','195');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES TRAFOS SUBESTAC 17',35,22,'0000-00-00 00:00:00','2010-09-30 00:00:00','2030-09-30 00:00:00',130,'cambio de manguera','197','14',NULL,11,NULL,0,NULL,'N','O','197');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUBESTACION 17',35,22,'0000-00-00 00:00:00','2010-09-30 00:00:00','2030-09-30 00:00:00',131,'se  cambia manguera i se repone precinto','198','11',NULL,11,NULL,0,NULL,'N','O','198');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALM MATERIAS PREIMAS',32,22,'0000-00-00 00:00:00','2008-03-30 00:00:00','2028-03-30 00:00:00',132,'','290','10080500',NULL,12,NULL,0,NULL,'N','O','290');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE MURO ESTACION DE CARGA',32,22,'0000-00-00 00:00:00','2000-02-28 00:00:00','2020-02-28 00:00:00',133,'','291','38639',NULL,12,NULL,0,NULL,'N','O','291');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE MURO ESTACION CARGA',32,22,'0000-00-00 00:00:00','2006-06-30 00:00:00','2026-06-30 00:00:00',134,'','292','S/N292',NULL,12,NULL,0,NULL,'N','O','292');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE MURO ESTACION DE CARGA',32,22,'0000-00-00 00:00:00','2000-02-28 00:00:00','2020-02-28 00:00:00',135,'','293','34232',NULL,12,NULL,0,NULL,'N','O','293');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUBESTACION 17 PLANTA BAJA',32,22,'0000-00-00 00:00:00','2000-01-30 00:00:00','2020-01-30 00:00:00',136,'','295','34245',NULL,12,NULL,0,NULL,'N','O','295');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUB17',32,22,'0000-00-00 00:00:00','2000-02-28 00:00:00','2020-02-28 00:00:00',137,'','297','38803',NULL,12,NULL,0,NULL,'N','O','297');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUB 17',32,22,'0000-00-00 00:00:00','2000-02-28 00:00:00','2020-02-28 00:00:00',138,'','298','38798',NULL,12,NULL,0,NULL,'N','O','298');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUB 17 1¦PLANTA',32,22,'0000-00-00 00:00:00','2000-02-28 00:00:00','2020-02-28 00:00:00',139,'','299','38807',NULL,12,NULL,0,NULL,'N','O','299');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUB 17 1¦ PLANTA',32,22,'0000-00-00 00:00:00','2000-02-28 00:00:00','2020-02-28 00:00:00',140,'','300','38648',NULL,12,NULL,0,NULL,'N','O','300');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUB 17',32,22,'0000-00-00 00:00:00','2000-02-28 00:00:00','2020-02-28 00:00:00',141,'','314','38640',NULL,12,NULL,0,NULL,'N','O','314');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUBESTACION 17 SOTANO',32,22,'0000-00-00 00:00:00','2000-02-28 00:00:00','2020-02-28 00:00:00',142,'','315','38654',NULL,12,NULL,0,NULL,'N','O','315');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUBESTACION 17 PLANTA BAJA',32,22,'0000-00-00 00:00:00','2008-12-31 00:00:00','2028-12-31 00:00:00',143,'','510','10080181',NULL,12,NULL,0,NULL,'N','O','510');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES TANQUES DE OE G4104 AL O',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',144,'','801','676',NULL,11,NULL,0,NULL,'N','O','801');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES TANQUE DE OE ESCAL CUBETO',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',145,'','802','1358',NULL,11,NULL,0,NULL,'N','O','802');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES TANQUE DE OE ESCAL CUBETO SO',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',146,'','803','1435',NULL,11,NULL,0,NULL,'N','O','803');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES BOMBAS SG4127 AL NO',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',147,'','804','551',NULL,11,NULL,0,NULL,'N','O','804');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES BOMBAS SG4127 AL SO',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',148,'','805','1600',NULL,11,NULL,0,NULL,'N','O','805');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES TANQUE DE OP ESC CUBETO',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',149,'','806','1607',NULL,11,NULL,0,NULL,'N','O','806');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES TANQUE DE OP ESC CUBETO',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',150,'','807','468',NULL,11,NULL,0,NULL,'N','O','807');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES PUERTA ALMACEN AL SO',36,22,'0000-00-00 00:00:00','2010-06-30 00:00:00','2030-06-30 00:00:00',151,'','808','70',NULL,11,NULL,0,NULL,'N','O','808');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES JUNTO BOMBA G4101',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',152,'','809','1431',NULL,11,NULL,0,NULL,'N','O','809');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES JUNTO BOMBA G4110/A',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',153,'','810','382',NULL,11,NULL,0,NULL,'N','O','810');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',154,'','811','1367',NULL,11,NULL,0,NULL,'N','O','811');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES TRAS BOMBAS G4105',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',155,'','812','607',NULL,11,NULL,0,NULL,'N','O','812');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE BOMBA G4105',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',156,'','813','1532',NULL,11,NULL,0,NULL,'N','O','813');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES JUNTO BOMBA G4117/A',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',157,'','814','1059',NULL,11,NULL,0,NULL,'N','O','814');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES EXTERIOR SUBEST 17 AL O',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',158,'','815','1982',NULL,11,NULL,0,NULL,'N','O','815');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 1¦ PLANTA EDIF AL N',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',159,'','816','1441',NULL,11,NULL,0,NULL,'N','O','816');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 1¦ PLANTA EDIF AL S',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',160,'','817','1137',NULL,11,NULL,0,NULL,'N','O','817');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 2¦ PLANTA EDIF AL N',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',161,'','818','627',NULL,11,NULL,0,NULL,'N','O','818');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 2¦ PLANTA EDIF AL S',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',162,'','819','1095',NULL,11,NULL,0,NULL,'N','O','819');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 2¦ PLANTA EDIF AL N',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',163,'','820','1',NULL,11,NULL,0,NULL,'N','O','820');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 2¦ PLANTA EDIF AL SE',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',164,'','821','531',NULL,11,NULL,0,NULL,'N','O','821');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 3¦ PLANTA EDIF AL N',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',165,'','822','607',NULL,11,NULL,0,NULL,'N','O','822');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 3¦ PLANTA EDIF AL S',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',166,'','823','596',NULL,11,NULL,0,NULL,'N','O','823');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 3¦ PLANTA EDIF AL N',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',167,'','824','1007',NULL,11,NULL,0,NULL,'N','O','824');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 3¦ PLANTA EDIF AL O',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',168,'','825','1046',NULL,11,NULL,0,NULL,'N','O','825');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 4¦ PLANTA EDIF AL N',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',169,'','826','1090',NULL,11,NULL,0,NULL,'N','O','826');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 4¦ PLANTA EDIF',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',170,'','827','223',NULL,11,NULL,0,NULL,'N','O','827');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 4¦ PLANTA EDIF AL N',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',171,'','828','701',NULL,11,NULL,0,NULL,'N','O','828');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 4¦ PLANTA EDIF AL S',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',172,'','829','1088',NULL,11,NULL,0,NULL,'N','O','829');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 5¦ PLANTA EDIF AL N',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',173,'','830','1053',NULL,11,NULL,0,NULL,'N','O','830');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 5¦ PLANTA EDIF AL S',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',174,'','831','998',NULL,11,NULL,0,NULL,'N','O','831');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA CUBETO ALMAC. AL E',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',175,'','832','242',NULL,11,NULL,0,NULL,'N','O','832');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA CUBETO ALMAC. AL. E.',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',176,'sin cartel','833','SN',NULL,11,NULL,1,'2012-02-16 00:00:00','N','O','833');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA CUBETO D 4150/L',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',177,'','834','1425',NULL,11,NULL,0,NULL,'N','O','834');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA CUBETO D4150/C',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',178,'','835','820',NULL,11,NULL,0,NULL,'N','O','835');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA CUBETO D4150/C',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',179,'','836','340',NULL,11,NULL,0,NULL,'N','O','836');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA CUBETO AL O',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',180,'','837','1133',NULL,11,NULL,0,NULL,'N','O','837');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES CUBETO AL.O.',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',181,'sin cartel','838','1195',NULL,11,NULL,0,NULL,'N','O','838');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL O DEL DEP-15',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',182,'','839','1747',NULL,11,NULL,0,NULL,'N','O','839');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMACEN POLIMERICOS',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',183,'','840','657',NULL,11,NULL,0,NULL,'N','O','840');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIMERICOS ULTIMA PLANTA',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',184,'no se encuentra','840','1877',NULL,11,NULL,0,NULL,'N','O','840');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES PAS. BOMBAS ALMAC. POLIME.',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',185,'','841','1727',NULL,11,NULL,0,NULL,'N','O','841');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES PAS. BOMBAS ALMAC. POLIME.',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',186,'','842','1913',NULL,11,NULL,0,NULL,'N','O','842');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMAC. POLIMERICOS AL NO',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',187,'','843','263',NULL,11,NULL,0,NULL,'N','O','843');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMAC. POLIMERICOS AL NE',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',188,'cambio de manometro y precinto','844','1436',NULL,11,NULL,0,NULL,'N','O','844');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMACEN MATERIAS PRIMAS',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',189,'','847','756',NULL,11,NULL,0,NULL,'N','O','847');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMACEN MATERIAS PRIMAS',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',190,'','848','699',NULL,11,NULL,0,NULL,'N','O','848');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMACEN MATERIAS PRIMAS',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',191,'','849','141',NULL,11,NULL,0,NULL,'N','O','849');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMAC. MATERIAS PRIMAS',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',192,'','850','1060',NULL,11,NULL,0,NULL,'N','O','850');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMACEN MATERIAS PRIMAS',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',193,'','851','545',NULL,11,NULL,0,NULL,'N','O','851');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMACEN MATERIAS PRIMAS',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',194,'','851','1731',NULL,11,NULL,0,NULL,'N','O','851');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL SUR DE LOS F-4204/A/B',36,22,'0000-00-00 00:00:00','2011-03-31 00:00:00','2031-03-31 00:00:00',195,'','859','14041963',NULL,11,NULL,0,NULL,'N','O','859');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ENTRE G4281/A/B',36,22,'0000-00-00 00:00:00','2007-12-31 00:00:00','2027-12-31 00:00:00',196,'','860','728198',NULL,11,NULL,0,NULL,'N','O','860');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL ESTE DE G-4251/B',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',197,'','861','128',NULL,11,NULL,0,NULL,'N','O','861');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA ACCESO POLIMERICOS',36,22,'0000-00-00 00:00:00','2000-03-12 00:00:00','2020-03-12 00:00:00',198,'','862','2292088',NULL,11,NULL,0,NULL,'N','O','862');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL NORTE DEL D 4285',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',199,'','863','128',NULL,11,NULL,0,NULL,'N','O','863');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL OESTE D4226',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',200,'cartel descolorido','864','1722',NULL,11,NULL,0,NULL,'N','O','864');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL O DEL SP 4280',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',201,'se repone precinto','865','29',NULL,11,NULL,0,NULL,'N','O','865');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL S DP13',36,22,'0000-00-00 00:00:00','2011-03-31 00:00:00','2031-03-31 00:00:00',202,'','866','1046961',NULL,11,NULL,0,NULL,'N','O','866');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES CUBETO ACCESO S COS D4220/21',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',203,'','867','316',NULL,11,NULL,0,NULL,'N','O','867');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ACCESO SUR CUBETO D4225',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',204,'','868','1722',NULL,11,NULL,0,NULL,'N','O','868');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES  ACCESO AL CUBETO N D4223',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',205,'','869','83',NULL,11,NULL,0,NULL,'N','O','869');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA ELEV 6',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',206,'','870','35',NULL,11,NULL,0,NULL,'N','O','870');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES CENTRO ELEV 6',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',207,'','871','1954',NULL,11,NULL,0,NULL,'N','O','871');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 6 AL E',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',208,'','872','1759',NULL,11,NULL,0,NULL,'N','O','872');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA ELEV 10',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',209,'','873','1555',NULL,11,NULL,0,NULL,'N','O','873');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES CENTRO ELEV 10',36,22,'0000-00-00 00:00:00','2007-12-31 00:00:00','2027-12-31 00:00:00',210,'','874','728204',NULL,11,NULL,0,NULL,'N','O','874');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL ESTE ELEV 10',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',211,'','875','952',NULL,11,NULL,0,NULL,'N','O','875');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA ELEV 14',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',212,'','876','1949',NULL,11,NULL,0,NULL,'N','O','876');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES CENTRO ELEV 14',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',213,'','877','723',NULL,11,NULL,0,NULL,'N','O','877');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL ESTE ELV 14',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',214,'','878','135',NULL,11,NULL,0,NULL,'N','O','878');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA ELEV 38',36,22,'0000-00-00 00:00:00','2007-12-31 00:00:00','2027-12-31 00:00:00',215,'','879','728207',NULL,11,NULL,0,NULL,'N','O','879');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES CENTRO ELV 18',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',216,'','880','640',NULL,11,NULL,0,NULL,'N','O','880');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL ESTE ELEV 18',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',217,'','881','55',NULL,11,NULL,0,NULL,'N','O','881');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA ELEV 22',36,22,'0000-00-00 00:00:00','2007-12-31 00:00:00','2027-12-31 00:00:00',218,'','882','728211',NULL,11,NULL,0,NULL,'N','O','882');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 22 TOLVAS SOLIDOS',36,22,'0000-00-00 00:00:00','2011-03-31 00:00:00','2031-03-31 00:00:00',219,'','883','1041959',NULL,11,NULL,0,NULL,'N','O','883');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 22 AL SE',36,22,'0000-00-00 00:00:00','2007-12-31 00:00:00','2027-12-31 00:00:00',220,'','884','728113',NULL,11,NULL,0,NULL,'N','O','884');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 26 AL SE',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',221,'se repone precinto','885','762',NULL,11,NULL,0,NULL,'N','O','885');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 26 AL E',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',222,'se cambia manometro','886','1641',NULL,11,NULL,0,NULL,'N','O','886');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 30 AL N',36,22,'0000-00-00 00:00:00','2007-12-31 00:00:00','2027-12-31 00:00:00',223,'se cambia manometro','887','728206',NULL,11,NULL,0,NULL,'N','O','887');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 30 AL S',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',224,'','888','425',NULL,11,NULL,0,NULL,'N','O','888');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 34',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',225,'','889','195',NULL,11,NULL,0,NULL,'N','O','889');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ACCESO N CUBETO D4251/A/B',36,22,'0000-00-00 00:00:00','2008-12-31 00:00:00','2028-12-31 00:00:00',226,'','890','1857',NULL,11,NULL,0,NULL,'N','O','890');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 38',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',227,'','891','956',NULL,11,NULL,0,NULL,'N','O','891');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUBESTACION 17 PLANTA BAJA JUNTO 144',31,22,'0000-00-00 00:00:00','2008-12-30 00:00:00','2028-12-30 00:00:00',228,'','S/N','308106',NULL,12,NULL,0,NULL,'N','O','S/N');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUBESTACION 17 PLANTA BAJA JUNTO 144',31,22,'0000-00-00 00:00:00','1997-02-28 00:00:00','2017-02-28 00:00:00',229,'','S/N','502476',NULL,12,NULL,0,NULL,'N','O','S/N');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'',38,22,'0001-01-01 00:00:00','1992-01-06 00:00:00','2012-01-06 00:00:00',233,'','11111111','11111111',NULL,11,NULL,1,'2012-01-23 00:00:00','N','O','11111111');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',38,22,'0001-01-01 00:00:00','2003-10-08 00:00:00','2023-10-08 00:00:00',234,'','22222','2222',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','22222');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'',43,22,'0001-01-01 00:00:00','2012-01-16 00:00:00','2032-01-16 00:00:00',236,'','2222-1','2222-1',NULL,13,234,0,'0001-01-01 00:00:00','N','O','2222-1');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',53,46,'0001-01-01 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',238,'','102','102',NULL,12,NULL,1,'2012-02-07 00:00:00','N','O','102');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'SUSTITUIDOS',53,46,'0001-01-01 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',239,'','103','103',NULL,12,NULL,1,'2012-02-14 00:00:00','N','O','103');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',53,46,'0001-01-01 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',240,'','104','104',NULL,12,NULL,0,'0001-01-01 00:00:00','N','O','104');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',53,46,'0001-01-01 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',241,'','105','105',NULL,12,NULL,0,'0001-01-01 00:00:00','N','O','105');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',50,46,'0001-01-01 00:00:00','2006-01-31 00:00:00','2026-01-31 00:00:00',242,'','201','201',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','201');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',50,46,'0001-01-01 00:00:00','2006-01-31 00:00:00','2026-01-31 00:00:00',243,'','202','202',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','202');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',50,46,'0001-01-01 00:00:00','2006-01-31 00:00:00','2026-01-31 00:00:00',244,'','203','203',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','203');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',50,46,'0001-01-01 00:00:00','1992-02-12 00:00:00','2012-02-12 00:00:00',245,'','204','204',NULL,11,NULL,1,'2012-02-08 00:00:00','N','O','204');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',51,46,'0001-01-01 00:00:00','2000-12-29 00:00:00','2020-12-29 00:00:00',246,'','221','221',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','221');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',51,46,'0001-01-01 00:00:00','2000-12-29 00:00:00','2020-12-29 00:00:00',247,'','222','222',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','222');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (38,'',52,46,'0001-01-01 00:00:00','2010-04-30 00:00:00','2030-04-30 00:00:00',248,'','301','301',NULL,14,NULL,0,'0001-01-01 00:00:00','N','O','301');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',53,46,'0001-01-01 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',249,'','106','106',NULL,12,NULL,0,'0001-01-01 00:00:00','N','O','106');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',53,46,'0001-01-01 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',250,'','107','107',NULL,12,NULL,0,'0001-01-01 00:00:00','N','O','107');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',53,46,'0001-01-01 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',251,'','108','108',NULL,12,NULL,0,'0001-01-01 00:00:00','N','O','108');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',53,46,'0001-01-01 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',252,'','109','109',NULL,12,NULL,0,'0001-01-01 00:00:00','N','O','109');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',53,46,'0001-01-01 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',253,'','110','110',NULL,12,NULL,0,'0001-01-01 00:00:00','N','O','110');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',50,46,'0001-01-01 00:00:00','1992-01-26 00:00:00','2012-01-26 00:00:00',254,'','205','205',NULL,11,NULL,1,'2012-01-01 00:00:00','N','O','205');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',50,46,'0001-01-01 00:00:00','2006-01-30 00:00:00','2026-01-30 00:00:00',255,'','206','206',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','206');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',50,46,'0001-01-01 00:00:00','2006-01-30 00:00:00','2026-01-30 00:00:00',256,'','207','207',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','207');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',50,46,'0001-01-01 00:00:00','2006-01-30 00:00:00','2026-01-30 00:00:00',257,'','208','208',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','208');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',50,46,'0001-01-01 00:00:00','1992-02-28 00:00:00','2012-02-28 00:00:00',258,'','209','209',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','209');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',50,46,'0001-01-01 00:00:00','1992-02-28 00:00:00','2012-02-28 00:00:00',259,'','210','210',NULL,11,NULL,1,'2012-02-16 00:00:00','N','O','210');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',51,46,'0001-01-01 00:00:00','2001-09-30 00:00:00','2021-09-30 00:00:00',260,'','223','223',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','223');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',51,46,'0001-01-01 00:00:00','2001-09-30 00:00:00','2021-09-30 00:00:00',261,'','224','224',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','224');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',51,46,'0001-01-01 00:00:00','2001-09-30 00:00:00','2021-09-30 00:00:00',262,'','225','225',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','225');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',51,46,'0001-01-01 00:00:00','2001-09-30 00:00:00','2021-09-30 00:00:00',263,'','226','226',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','226');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',51,46,'0001-01-01 00:00:00','2001-09-30 00:00:00','2021-09-30 00:00:00',264,'','227','227',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','227');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',51,46,'0001-01-01 00:00:00','2001-09-30 00:00:00','2021-09-30 00:00:00',265,'','228','228',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','228');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',51,46,'0001-01-01 00:00:00','2001-09-30 00:00:00','2021-09-30 00:00:00',266,'','229','229',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','229');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',51,46,'0001-01-01 00:00:00','2001-09-30 00:00:00','2021-09-30 00:00:00',267,'','230','230',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','230');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (38,'',52,46,'0001-01-01 00:00:00','2010-04-30 00:00:00','2030-04-30 00:00:00',268,'','302','302',NULL,14,NULL,0,'0001-01-01 00:00:00','N','O','302');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (38,'',52,46,'0001-01-01 00:00:00','2010-04-30 00:00:00','2030-04-30 00:00:00',269,'','303','303',NULL,14,NULL,0,'0001-01-01 00:00:00','N','O','303');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (38,'',52,46,'0001-01-01 00:00:00','2010-04-30 00:00:00','2030-04-30 00:00:00',270,'','304','304',NULL,14,NULL,0,'0001-01-01 00:00:00','N','O','304');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (38,'',52,46,'0001-01-01 00:00:00','2010-04-30 00:00:00','2030-04-30 00:00:00',271,'','305','305',NULL,14,NULL,0,'0001-01-01 00:00:00','N','O','305');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',50,46,'0001-01-01 00:00:00','1992-01-13 00:00:00','2012-01-13 00:00:00',272,'','567','567',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','567');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',51,46,'0001-01-01 00:00:00','1992-03-25 00:00:00','2012-03-25 00:00:00',273,'','9876','9876',NULL,11,NULL,1,'2012-02-06 00:00:00','N','O','9876');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',53,46,'0001-01-01 00:00:00','1992-02-25 00:00:00','2012-02-25 00:00:00',274,'','120','120',NULL,12,NULL,1,'2012-02-07 00:00:00','N','O','120');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'',34,22,'0001-01-01 00:00:00','1992-02-28 00:00:00','2012-02-28 00:00:00',275,'','130','130',NULL,11,NULL,1,'2012-02-08 00:00:00','N','O','130');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'',35,22,'0001-01-01 00:00:00','2007-02-15 00:00:00','2027-02-15 00:00:00',276,'','131','131',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','131');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'',46,22,'0001-01-01 00:00:00','2002-02-12 00:00:00','2022-02-12 00:00:00',277,'','132','132',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','132');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',51,46,'0001-01-01 00:00:00','2005-10-11 00:00:00','2025-10-11 00:00:00',278,'','125','125',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','125');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'',33,22,'0001-01-01 00:00:00','1992-02-12 00:00:00','2012-02-12 00:00:00',279,'','133','133',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','133');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',NULL,46,'0001-01-01 00:00:00','2011-01-01 00:00:00','2031-01-01 00:00:00',281,'','rafaaaaa','1',NULL,NULL,NULL,0,'0001-01-01 00:00:00','N','O','rafaaaaa');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',51,46,'0001-01-01 00:00:00','2008-02-01 00:00:00','2028-02-01 00:00:00',282,'','141','141',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','141');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'',38,22,'0001-01-01 00:00:00','1992-02-12 00:00:00','2012-02-12 00:00:00',283,'','211','211',NULL,11,NULL,1,'2012-02-01 00:00:00','N','O','211');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'SUSTITUIDOS',50,46,'0001-01-01 00:00:00','2009-02-03 00:00:00','2029-02-03 00:00:00',284,'','103 repuesto','103-2',NULL,11,NULL,0,'0001-01-01 00:00:00','A','R','103 repuesto');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'',50,46,'0001-01-01 00:00:00','2007-02-05 00:00:00','2027-02-05 00:00:00',285,'','160','160',NULL,11,NULL,0,'0001-01-01 00:00:00','S','R','160');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (37,'SUSTITUIDOS',50,46,'0001-01-01 00:00:00','2010-02-15 00:00:00','2030-02-15 00:00:00',287,'','250','250',NULL,11,NULL,0,'0001-01-01 00:00:00','A','O','250');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',34,24,'0001-01-01 00:00:00','2007-02-12 00:00:00','2027-02-12 00:00:00',288,'','300','300',NULL,11,NULL,0,'0001-01-01 00:00:00','A','O','300');
insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',34,24,'0001-01-01 00:00:00','2007-02-27 00:00:00','2027-02-27 00:00:00',289,'','301','301',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','301');

/*Table structure for table `documento` */

DROP TABLE IF EXISTS `documento`;

CREATE TABLE `documento` (
  `categoria_id` int(11) DEFAULT NULL,
  `comentarios` varchar(255) DEFAULT NULL,
  `documento_id` int(11) NOT NULL AUTO_INCREMENT,
  `empresa_id` int(11) DEFAULT NULL,
  `extension` varchar(255) DEFAULT NULL,
  `fecha` datetime NOT NULL,
  `instalacion_id` int(11) DEFAULT NULL,
  `nombre` varchar(255) DEFAULT NULL,
  `subcategoria_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`documento_id`),
  KEY `idx_documento_categoria_id` (`categoria_id`),
  KEY `idx_documento_empresa_id` (`empresa_id`),
  KEY `idx_documento_instalacion_id` (`instalacion_id`),
  KEY `idx_documento_subcategoria_id` (`subcategoria_id`),
  CONSTRAINT `ref_documento_categoria` FOREIGN KEY (`categoria_id`) REFERENCES `categoria` (`categoria_id`),
  CONSTRAINT `ref_documento_empresa` FOREIGN KEY (`empresa_id`) REFERENCES `empresa` (`empresa_id`),
  CONSTRAINT `ref_documento_instalacion` FOREIGN KEY (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`),
  CONSTRAINT `ref_documento_subcategoria` FOREIGN KEY (`subcategoria_id`) REFERENCES `subcategoria` (`subcategoria_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `documento` */

insert  into `documento`(`categoria_id`,`comentarios`,`documento_id`,`empresa_id`,`extension`,`fecha`,`instalacion_id`,`nombre`,`subcategoria_id`) values (1,'comentarios a tramo',5,24,'.pdf','0001-01-01 00:00:00',NULL,'Resumen Revisiones 01/01/2000 31/03/2012',2);

/*Table structure for table `email` */

DROP TABLE IF EXISTS `email`;

CREATE TABLE `email` (
  `mail` varchar(255) DEFAULT NULL,
  `instalacion_id` int(11) DEFAULT NULL,
  `envio` bit(1) NOT NULL,
  `empresa_id` int(11) DEFAULT NULL,
  `email_id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`email_id`),
  KEY `idx_email_instalacion_id` (`instalacion_id`),
  KEY `idx_email_empresa_id` (`empresa_id`),
  CONSTRAINT `ref_email_empresa` FOREIGN KEY (`empresa_id`) REFERENCES `empresa` (`empresa_id`),
  CONSTRAINT `ref_email_instalacion` FOREIGN KEY (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

/*Data for the table `email` */

insert  into `email`(`mail`,`instalacion_id`,`envio`,`empresa_id`,`email_id`,`descripcion`) values ('romerox@carburos.com',44,'',NULL,10,'');
insert  into `email`(`mail`,`instalacion_id`,`envio`,`empresa_id`,`email_id`,`descripcion`) values ('ICAREAGE@DOW.COM',24,'',NULL,11,'');
insert  into `email`(`mail`,`instalacion_id`,`envio`,`empresa_id`,`email_id`,`descripcion`) values ('mmforte@dow.com',41,'',NULL,12,'Mercedes Forte');
insert  into `email`(`mail`,`instalacion_id`,`envio`,`empresa_id`,`email_id`,`descripcion`) values ('rgarcia2@dow.com',42,'',NULL,13,'Rafael García');
insert  into `email`(`mail`,`instalacion_id`,`envio`,`empresa_id`,`email_id`,`descripcion`) values ('psanchez2@dow.com',24,'',NULL,14,'Patricia Sanchez');
insert  into `email`(`mail`,`instalacion_id`,`envio`,`empresa_id`,`email_id`,`descripcion`) values ('psanchez2@dow.com',41,'',NULL,15,'Patricia Sanchez');
insert  into `email`(`mail`,`instalacion_id`,`envio`,`empresa_id`,`email_id`,`descripcion`) values ('psanchez2@dow.com',42,'',NULL,16,'Patricia Sanchez');
insert  into `email`(`mail`,`instalacion_id`,`envio`,`empresa_id`,`email_id`,`descripcion`) values ('enrique.turegano@cepsa.com',46,'',NULL,18,'CONTACTO\r\nTurégano García, Enrique Manuel\r\n');

/*Table structure for table `empresa` */

DROP TABLE IF EXISTS `empresa`;

CREATE TABLE `empresa` (
  `persona_contacto` varchar(255) DEFAULT NULL,
  `nombre` varchar(255) DEFAULT NULL,
  `empresa_id` int(11) NOT NULL AUTO_INCREMENT,
  `cod_ax` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`empresa_id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;

/*Data for the table `empresa` */

insert  into `empresa`(`persona_contacto`,`nombre`,`empresa_id`,`cod_ax`) values ('IVAN GIL BUENO','AEQT PARC QUIMIC NORD',24,'SCI0112');
insert  into `empresa`(`persona_contacto`,`nombre`,`empresa_id`,`cod_ax`) values ('ISIDRI HERRERA','AEQT PARC QUIMIC SUD',25,'SCI0111');
insert  into `empresa`(`persona_contacto`,`nombre`,`empresa_id`,`cod_ax`) values ('Isidro Herrera','AEQT PARC QUIMIC PORT',26,'SCI0113');
insert  into `empresa`(`persona_contacto`,`nombre`,`empresa_id`,`cod_ax`) values ('Ivan Gil Bueno','AEQT PARC QUIMIC RECARGA',27,'SCI0126');
insert  into `empresa`(`persona_contacto`,`nombre`,`empresa_id`,`cod_ax`) values ('','COMPAÑIA ESPAÑOLA DE PETROLEOS, S.A.',28,'');

/*Table structure for table `fabricante` */

DROP TABLE IF EXISTS `fabricante`;

CREATE TABLE `fabricante` (
  `nombre` varchar(255) DEFAULT NULL,
  `fabricante_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`fabricante_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `fabricante` */

/*Table structure for table `filtro` */

DROP TABLE IF EXISTS `filtro`;

CREATE TABLE `filtro` (
  `expresion` text,
  `filtro_id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) DEFAULT NULL,
  `tipo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`filtro_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Data for the table `filtro` */

insert  into `filtro`(`expresion`,`filtro_id`,`nombre`,`tipo`) values ('AAEAAAD/////AQAAAAAAAAAQAQAAAAMAAAAKCQIAAAAJAwAAABACAAAAAgAAAAkEAAAACQUAAAAMBgAAAFhUZWxlcmlrLldlYi5VSSwgVmVyc2lvbj0yMDExLjMuMTExNS40MCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj0xMjFmYWU3ODE2NWJhM2Q0BQMAAAAmVGVsZXJpay5XZWIuVUkuUmFkRmlsdGVyR3JvdXBPcGVyYXRpb24BAAAAB3ZhbHVlX18ACAYAAAAAAAAADAcAAABNU3lzdGVtLldlYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFBAAAABJTeXN0ZW0uV2ViLlVJLlBhaXICAAAABUZpcnN0BlNlY29uZAICBwAAAAgIAQAAAAgIAAAAAAEFAAAABAAAAAkIAAAACQkAAAABCAAAAAQAAAAGCgAAACJSYWRGaWx0ZXJFcXVhbFRvRmlsdGVyRXhwcmVzc2lvbmAxBgsAAAANU3lzdGVtLlN0cmluZxAJAAAAAgAAAAkMAAAABg0AAAAGRXN0YWRvBAwAAAAcU3lzdGVtLkNvbGxlY3Rpb25zLkFycmF5TGlzdAMAAAAGX2l0ZW1zBV9zaXplCF92ZXJzaW9uBQAACAgJDgAAAAIAAAACAAAAEA4AAAAEAAAACQ8AAAAGEAAAAApQUk9HUkFNQURBDQIFDwAAABtTeXN0ZW0uV2ViLlVJLkluZGV4ZWRTdHJpbmcBAAAABl92YWx1ZQEHAAAABhEAAAAFVmFsdWUL',5,'REVISIONES PROGRAMADAS','Revision');
insert  into `filtro`(`expresion`,`filtro_id`,`nombre`,`tipo`) values ('AAEAAAD/////AQAAAAAAAAAQAQAAAAMAAAAKCQIAAAAJAwAAABACAAAAAgAAAAkEAAAACQUAAAAMBgAAAFhUZWxlcmlrLldlYi5VSSwgVmVyc2lvbj0yMDExLjMuMTExNS40MCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj0xMjFmYWU3ODE2NWJhM2Q0BQMAAAAmVGVsZXJpay5XZWIuVUkuUmFkRmlsdGVyR3JvdXBPcGVyYXRpb24BAAAAB3ZhbHVlX18ACAYAAAAAAAAADAcAAABNU3lzdGVtLldlYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFBAAAABJTeXN0ZW0uV2ViLlVJLlBhaXICAAAABUZpcnN0BlNlY29uZAICBwAAAAgIAQAAAAgIAAAAAAEFAAAABAAAAAkIAAAACQkAAAABCAAAAAQAAAAGCgAAACJSYWRGaWx0ZXJFcXVhbFRvRmlsdGVyRXhwcmVzc2lvbmAxBgsAAAANU3lzdGVtLlN0cmluZxAJAAAAAgAAAAkMAAAABg0AAAAGRXN0YWRvBAwAAAAcU3lzdGVtLkNvbGxlY3Rpb25zLkFycmF5TGlzdAMAAAAGX2l0ZW1zBV9zaXplCF92ZXJzaW9uBQAACAgJDgAAAAIAAAACAAAAEA4AAAAEAAAACQ8AAAAGEAAAAApQUk9HUkFNQURBDQIFDwAAABtTeXN0ZW0uV2ViLlVJLkluZGV4ZWRTdHJpbmcBAAAABl92YWx1ZQEHAAAABhEAAAAFVmFsdWUL',6,'PLANIFICADA','Revision');
insert  into `filtro`(`expresion`,`filtro_id`,`nombre`,`tipo`) values ('AAEAAAD/////AQAAAAAAAAAQAQAAAAMAAAAKCQIAAAAJAwAAABACAAAAAgAAAAkEAAAACQUAAAAMBgAAAFhUZWxlcmlrLldlYi5VSSwgVmVyc2lvbj0yMDExLjMuMTExNS40MCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj0xMjFmYWU3ODE2NWJhM2Q0BQMAAAAmVGVsZXJpay5XZWIuVUkuUmFkRmlsdGVyR3JvdXBPcGVyYXRpb24BAAAAB3ZhbHVlX18ACAYAAAAAAAAADAcAAABNU3lzdGVtLldlYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFBAAAABJTeXN0ZW0uV2ViLlVJLlBhaXICAAAABUZpcnN0BlNlY29uZAICBwAAAAgIAQAAAAgIAAAAAAEFAAAABAAAAAkIAAAACQkAAAABCAAAAAQAAAAGCgAAACJSYWRGaWx0ZXJFcXVhbFRvRmlsdGVyRXhwcmVzc2lvbmAxBgsAAAANU3lzdGVtLlN0cmluZxAJAAAAAgAAAAkMAAAABg0AAAAGRXN0YWRvBAwAAAAcU3lzdGVtLkNvbGxlY3Rpb25zLkFycmF5TGlzdAMAAAAGX2l0ZW1zBV9zaXplCF92ZXJzaW9uBQAACAgJDgAAAAIAAAACAAAAEA4AAAAEAAAACQ8AAAAGEAAAAAlSRUFMSVpBREENAgUPAAAAG1N5c3RlbS5XZWIuVUkuSW5kZXhlZFN0cmluZwEAAAAGX3ZhbHVlAQcAAAAGEQAAAAVWYWx1ZQs=',7,'REALIZADA','Revision');

/*Table structure for table `grupo_mensajes` */

DROP TABLE IF EXISTS `grupo_mensajes`;

CREATE TABLE `grupo_mensajes` (
  `grupo_mensajes_id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`grupo_mensajes_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `grupo_mensajes` */

insert  into `grupo_mensajes`(`grupo_mensajes_id`,`nombre`) values (1,'Avisos de formación');
insert  into `grupo_mensajes`(`grupo_mensajes_id`,`nombre`) values (2,'Avisos generales');

/*Table structure for table `grupo_usuario` */

DROP TABLE IF EXISTS `grupo_usuario`;

CREATE TABLE `grupo_usuario` (
  `nombre` varchar(255) DEFAULT NULL,
  `grupo_usuario_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`grupo_usuario_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

/*Data for the table `grupo_usuario` */

insert  into `grupo_usuario`(`nombre`,`grupo_usuario_id`) values ('Administradores',1);
insert  into `grupo_usuario`(`nombre`,`grupo_usuario_id`) values ('Usuarios',2);
insert  into `grupo_usuario`(`nombre`,`grupo_usuario_id`) values ('Super usuario (new admin)',5);
insert  into `grupo_usuario`(`nombre`,`grupo_usuario_id`) values ('JEFE SERVICIO AEQT',7);
insert  into `grupo_usuario`(`nombre`,`grupo_usuario_id`) values ('ESPECIALISTAS CI AEQT',8);
insert  into `grupo_usuario`(`nombre`,`grupo_usuario_id`) values ('JEFE SERVICIO CEPSA TENERIFE',9);
insert  into `grupo_usuario`(`nombre`,`grupo_usuario_id`) values ('ESPECIALISTAS CI CEPSA TENERIFE',10);

/*Table structure for table `instalacion` */

DROP TABLE IF EXISTS `instalacion`;

CREATE TABLE `instalacion` (
  `nombre` varchar(255) DEFAULT NULL,
  `instalacion_id` int(11) NOT NULL AUTO_INCREMENT,
  `empresa_id` int(11) DEFAULT NULL,
  `cod_ax` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`instalacion_id`),
  KEY `idx_instalacion_empresa_id` (`empresa_id`),
  CONSTRAINT `ref_instalacion_empresa` FOREIGN KEY (`empresa_id`) REFERENCES `empresa` (`empresa_id`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=latin1;

/*Data for the table `instalacion` */

insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA POLIOLES',22,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA MMA',23,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('DOW CRACKER',24,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('CARBUROS METALICOS HYCO',25,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA PP2',26,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA TAR',27,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA E.CARGA',28,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA GLICOLES',29,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA VARIOS',30,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA ALMACEN',31,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA CONG-1',32,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA ACN',33,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA OPSM',34,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA PP3',35,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA CONG-2',36,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA BN',37,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA PAD',38,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA PBD',39,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('DOW CRACKER MTO',41,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('DOW CRACKER OCTENO',42,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('CARBUROS METALICOS LA POBLA',44,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('CARBUROS METALICOS MORELL',45,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('CEPSA TENERIFE',46,28,'SCI0211');

/*Table structure for table `mensaje` */

DROP TABLE IF EXISTS `mensaje`;

CREATE TABLE `mensaje` (
  `cuerpo` varchar(255) DEFAULT NULL,
  `fecha_final` datetime NOT NULL,
  `fecha_inicio` datetime NOT NULL,
  `grupo_mensajes_id` int(11) DEFAULT NULL,
  `mensaje_id` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(255) DEFAULT NULL,
  `urgente` bit(1) NOT NULL,
  PRIMARY KEY (`mensaje_id`),
  KEY `idx_mensaje_grupo_mensajes_id` (`grupo_mensajes_id`),
  CONSTRAINT `ref_mensaje_grupo_mensajes` FOREIGN KEY (`grupo_mensajes_id`) REFERENCES `grupo_mensajes` (`grupo_mensajes_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `mensaje` */

insert  into `mensaje`(`cuerpo`,`fecha_final`,`fecha_inicio`,`grupo_mensajes_id`,`mensaje_id`,`titulo`,`urgente`) values ('Bienvenidos a la nueva extranet','0001-01-01 00:00:00','2012-03-12 00:00:00',2,1,'Bienvenidos a la nueva extranet','\0');

/*Table structure for table `modelo_dispositivo` */

DROP TABLE IF EXISTS `modelo_dispositivo`;

CREATE TABLE `modelo_dispositivo` (
  `nombre` varchar(255) DEFAULT NULL,
  `modelo_id` int(11) NOT NULL AUTO_INCREMENT,
  `empresa_id` int(11) DEFAULT NULL,
  `instalacion_id` int(11) DEFAULT NULL,
  `tipo_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`modelo_id`),
  KEY `idx_modelo_dispositivo_empresa_id` (`empresa_id`),
  KEY `idx_modelo_dispositivo_instalacion_id` (`instalacion_id`),
  KEY `idx_modelo_dispositivo_tipo_id` (`tipo_id`),
  CONSTRAINT `ref_modelo_dispositivo_tipo_dispositivo` FOREIGN KEY (`tipo_id`) REFERENCES `tipo_dispositivo` (`tipo_id`),
  CONSTRAINT `ref_modelo_dispositivo_empresa` FOREIGN KEY (`empresa_id`) REFERENCES `empresa` (`empresa_id`),
  CONSTRAINT `ref_modelo_dispositivo_instalacion` FOREIGN KEY (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=latin1;

/*Data for the table `modelo_dispositivo` */

insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('NC10',31,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('NC5',32,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('PA12',33,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('P50',34,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('PI50',35,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('PI9',36,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('P25',37,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('P9',38,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('PI6',39,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('PI25',40,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('NC3,5',41,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('G1700',43,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('P12',44,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('PI50',45,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('PI9',46,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('P-9',50,28,46,37);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('P-6',51,28,46,37);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('BIE 45',52,28,46,38);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('C-5',53,28,46,37);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('P50D',54,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('PI9D',55,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('PI50D',56,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('PI3',57,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('NC45',58,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('NC30',59,24,NULL,34);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('HFC23',60,24,NULL,34);

/*Table structure for table `operario` */

DROP TABLE IF EXISTS `operario`;

CREATE TABLE `operario` (
  `sexo` char(1) DEFAULT NULL,
  `operario_id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) DEFAULT NULL,
  `instalacion_id` int(11) DEFAULT NULL,
  `fecha_nacimiento` datetime NOT NULL,
  `dni` varchar(255) DEFAULT NULL,
  `cod_ax` varchar(50) DEFAULT NULL,
  `carnet_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`operario_id`),
  KEY `idx_operario_instalacion_id` (`instalacion_id`),
  KEY `ref_operario_carnet_radiologico` (`carnet_id`),
  CONSTRAINT `ref_operario_carnet_radiologico` FOREIGN KEY (`carnet_id`) REFERENCES `carnet_radiologico` (`carnet_id`),
  CONSTRAINT `ref_operario_instalacion` FOREIGN KEY (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `operario` */

/*Table structure for table `permiso` */

DROP TABLE IF EXISTS `permiso`;

CREATE TABLE `permiso` (
  `ver` bit(1) NOT NULL,
  `permiso_id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) DEFAULT NULL,
  `modificar` bit(1) NOT NULL,
  `grupo_usuario_id` int(11) DEFAULT NULL,
  `especial` bit(1) NOT NULL,
  `crear` bit(1) NOT NULL,
  PRIMARY KEY (`permiso_id`),
  KEY `idx_permiso_grupo_usuario_id` (`grupo_usuario_id`),
  KEY `ref_permiso_proceso` (`nombre`),
  CONSTRAINT `ref_permiso_grupo_usuario` FOREIGN KEY (`grupo_usuario_id`) REFERENCES `grupo_usuario` (`grupo_usuario_id`),
  CONSTRAINT `ref_permiso_proceso` FOREIGN KEY (`nombre`) REFERENCES `proceso` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=412 DEFAULT CHARSET=latin1;

/*Data for the table `permiso` */

insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',1,'administracion','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',2,'grupousuariogrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',3,'usuariogrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',4,'procesogrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',5,'permisogrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',6,'administracion','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',7,'procesogrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',8,'permisogrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',9,'grupousuariogrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',10,'usuariogrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',11,'datos','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',12,'datos','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',13,'EmpresaGrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',14,'EmpresaGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',15,'InstalacionGrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',16,'InstalacionGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',17,'OperarioGrid','\0',1,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',18,'OperarioGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',19,'dispositivoGrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',20,'dispositivoGrid','',2,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',21,'TipoGrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',22,'TipoGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',23,'ModeloGrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',24,'ModeloGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',25,'AccesorioGrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',26,'AccesorioGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',27,'PlantillaRevisionGrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',28,'PlantillaRevisionGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',29,'DatosDispositivos','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',30,'DatosDispositivos','',2,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',31,'DatosPlantillas','\0',1,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',32,'DatosPlantillas','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',33,'CampoGrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',34,'CampoGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',35,'TipoCampoGrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',36,'TipoCampoGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',37,'AgenteExtintorGrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',38,'AgenteExtintorGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',39,'FabricanteGrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',40,'FabricanteGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',41,'Revisiones','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',42,'Revisiones','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',43,'ProgramarGrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',44,'ProgramarGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',45,'revisiongrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',46,'revisiongrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',93,'windows','\0',1,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',94,'windows','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',97,'tile','\0',1,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',98,'tile','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',101,'cascade','\0',1,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',102,'cascade','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',105,'programagrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',106,'programagrid','',2,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',109,'AccesorioGrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',110,'procesogrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',111,'PlantillaRevisionGrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',112,'permisogrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',113,'programagrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',114,'OperarioGrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',115,'ProgramarGrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',116,'revisiongrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',117,'TipoGrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',118,'TipoCampoGrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',119,'tile','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',120,'Revisiones','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',121,'usuariogrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',122,'ModeloGrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',123,'grupousuariogrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',124,'CampoGrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',125,'AgenteExtintorGrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',126,'administracion','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',127,'cascade','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',128,'InstalacionGrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',129,'datos','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',130,'DatosPlantillas','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',131,'FabricanteGrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',132,'EmpresaGrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',133,'dispositivoGrid','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',134,'DatosDispositivos','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',135,'windows','',5,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',163,'consultas','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',164,'consultas','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',167,'consultas','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',169,'consultarevisiones','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',170,'consultarevisiones','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',173,'consultarevisiones','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',175,'consultadispositivos','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',176,'consultadispositivos','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',178,'consultadispositivos','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',180,'AccesorioGrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',181,'PlantillaRevisionGrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',182,'permisogrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',183,'OperarioGrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',184,'procesogrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',185,'programagrid','',8,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',186,'ProgramarGrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',187,'Revisiones','',8,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',188,'TipoGrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',189,'ModeloGrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',190,'TipoCampoGrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',191,'revisiongrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',192,'tile','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',193,'InstalacionGrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',194,'grupousuariogrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',195,'FabricanteGrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',196,'cascade','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',197,'consultadispositivos','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',198,'CampoGrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',199,'administracion','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',200,'AgenteExtintorGrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',201,'usuariogrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',202,'consultarevisiones','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',203,'datos','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',204,'EmpresaGrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',205,'consultas','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',206,'dispositivoGrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',207,'DatosDispositivos','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',208,'DatosPlantillas','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',209,'windows','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',210,'AccesorioGrid','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',211,'PlantillaRevisionGrid','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',212,'permisogrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',213,'OperarioGrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',214,'procesogrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',215,'programagrid','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',216,'ProgramarGrid','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',217,'Revisiones','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',218,'TipoGrid','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',219,'ModeloGrid','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',220,'TipoCampoGrid','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',221,'revisiongrid','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',222,'tile','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',223,'InstalacionGrid','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',224,'grupousuariogrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',225,'FabricanteGrid','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',226,'cascade','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',227,'consultadispositivos','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',228,'CampoGrid','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',229,'administracion','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',230,'AgenteExtintorGrid','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',231,'usuariogrid','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',232,'consultarevisiones','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',233,'datos','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',234,'EmpresaGrid','',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',235,'consultas','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',236,'dispositivoGrid','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',237,'DatosDispositivos','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',238,'DatosPlantillas','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',239,'windows','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',240,'AccesorioGrid','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',241,'PlantillaRevisionGrid','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',242,'permisogrid','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',243,'OperarioGrid','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',244,'procesogrid','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',245,'programagrid','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',246,'ProgramarGrid','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',247,'Revisiones','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',248,'TipoGrid','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',249,'ModeloGrid','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',250,'TipoCampoGrid','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',251,'revisiongrid','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',252,'tile','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',253,'InstalacionGrid','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',254,'grupousuariogrid','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',255,'FabricanteGrid','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',256,'cascade','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',257,'consultadispositivos','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',258,'CampoGrid','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',259,'administracion','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',260,'AgenteExtintorGrid','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',261,'usuariogrid','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',262,'consultarevisiones','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',263,'datos','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',264,'EmpresaGrid','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',265,'consultas','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',266,'dispositivoGrid','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',267,'DatosDispositivos','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',268,'DatosPlantillas','',9,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',269,'windows','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',270,'AccesorioGrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',271,'PlantillaRevisionGrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',272,'permisogrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',273,'OperarioGrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',274,'procesogrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',275,'programagrid','',10,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',276,'ProgramarGrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',277,'Revisiones','',10,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',278,'TipoGrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',279,'ModeloGrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',280,'TipoCampoGrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',281,'revisiongrid','',10,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',282,'tile','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',283,'InstalacionGrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',284,'grupousuariogrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',285,'FabricanteGrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',286,'cascade','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',287,'consultadispositivos','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',288,'CampoGrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',289,'administracion','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',290,'AgenteExtintorGrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',291,'usuariogrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',292,'consultarevisiones','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',293,'datos','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',294,'EmpresaGrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',295,'consultas','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',296,'dispositivoGrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',297,'DatosDispositivos','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',298,'DatosPlantillas','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',299,'windows','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',300,'sustituciongrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',301,'sustituciongrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',302,'sustituciongrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',303,'sustituciongrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',304,'sustituciongrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',305,'sustituciongrid','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',306,'sustituciongrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',307,'terminales','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',308,'terminales','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',309,'terminales','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',310,'terminales','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',311,'terminales','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',312,'terminales','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',313,'terminales','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',314,'terminalgrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',315,'terminalgrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',316,'terminalgrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',317,'terminalgrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',318,'terminalgrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',319,'terminalgrid','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',320,'terminalgrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',321,'extranet','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',322,'extranet','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',323,'extranet','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',324,'extranet','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',325,'extranet','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',326,'extranet','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',327,'extranet','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',335,'categoriagrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',336,'categoriagrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',337,'categoriagrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',338,'categoriagrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',339,'categoriagrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',340,'categoriagrid','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',341,'categoriagrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',342,'subcategoriagrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',343,'subcategoriagrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',344,'subcategoriagrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',345,'subcategoriagrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',346,'subcategoriagrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',347,'subcategoriagrid','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',348,'subcategoriagrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',356,'mensajegrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',357,'mensajegrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',358,'mensajegrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',359,'mensajegrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',360,'mensajegrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',361,'mensajegrid','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',362,'mensajegrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',363,'usuarioextranetgrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',364,'usuarioextranetgrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',365,'usuarioextranetgrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',366,'usuarioextranetgrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',367,'usuarioextranetgrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',368,'usuarioextranetgrid','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',369,'usuarioextranetgrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',370,'grupomensajesgrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',371,'grupomensajesgrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',372,'grupomensajesgrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',373,'grupomensajesgrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',374,'grupomensajesgrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',375,'grupomensajesgrid','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',376,'grupomensajesgrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',377,'documentogrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',378,'documentogrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',379,'documentogrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',380,'documentogrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',381,'documentogrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',382,'documentogrid','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',383,'documentogrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',384,'repositoriotmpform','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',385,'repositoriotmpform','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',386,'repositoriotmpform','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',387,'repositoriotmpform','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',388,'repositoriotmpform','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',389,'repositoriotmpform','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',390,'repositoriotmpform','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',391,'tipoanomaliagrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',392,'tipoanomaliagrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',393,'tipoanomaliagrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',394,'tipoanomaliagrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',395,'tipoanomaliagrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',396,'tipoanomaliagrid','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',397,'tipoanomaliagrid','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',398,'informes','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',399,'informes','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',400,'informes','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',401,'informes','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',402,'informes','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',403,'informes','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',404,'informes','\0',10,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',405,'RptResumenEmpresaInstalación','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',406,'RptResumenEmpresaInstalación','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',407,'RptResumenEmpresaInstalación','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',408,'RptResumenEmpresaInstalación','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',409,'RptResumenEmpresaInstalación','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',410,'RptResumenEmpresaInstalación','\0',9,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',411,'RptResumenEmpresaInstalación','\0',10,'\0','\0');

/*Table structure for table `planificacion_revision` */

DROP TABLE IF EXISTS `planificacion_revision`;

CREATE TABLE `planificacion_revision` (
  `tipo_periodo` varchar(255) DEFAULT NULL,
  `plantilla_id` int(11) DEFAULT NULL,
  `planificacion_id` int(11) NOT NULL AUTO_INCREMENT,
  `periodo` int(11) NOT NULL,
  `dispositivo_id` int(11) DEFAULT NULL,
  `fechaUltimaRevision` datetime NOT NULL,
  PRIMARY KEY (`planificacion_id`),
  KEY `idx_planificacion_revision_dispositivo_id` (`dispositivo_id`),
  KEY `idx_planificacion_revision_plantilla_id` (`plantilla_id`),
  CONSTRAINT `ref_planificacion_revision_dispositivo` FOREIGN KEY (`dispositivo_id`) REFERENCES `dispositivo` (`dispositivo_id`),
  CONSTRAINT `ref_planificacion_revision_plantilla_revision` FOREIGN KEY (`plantilla_id`) REFERENCES `plantilla_revision` (`plantilla_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `planificacion_revision` */

/*Table structure for table `plantilla_revision` */

DROP TABLE IF EXISTS `plantilla_revision`;

CREATE TABLE `plantilla_revision` (
  `plantilla_id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(255) DEFAULT NULL,
  `comentarios` varchar(255) DEFAULT NULL,
  `tipo_periodo` varchar(255) DEFAULT NULL,
  `tipo_id` int(11) DEFAULT NULL,
  `numero_periodos` int(11) NOT NULL,
  `con_sustitucion` tinyint(1) NOT NULL,
  `facturable` tinyint(1) NOT NULL,
  `no_periodica` tinyint(1) NOT NULL,
  PRIMARY KEY (`plantilla_id`),
  KEY `idx_plantilla_revision_tipo_id` (`tipo_id`),
  CONSTRAINT `ref_plantilla_revision_tipo_dispositivo` FOREIGN KEY (`tipo_id`) REFERENCES `tipo_dispositivo` (`tipo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=latin1;

/*Data for the table `plantilla_revision` */

insert  into `plantilla_revision`(`plantilla_id`,`descripcion`,`comentarios`,`tipo_periodo`,`tipo_id`,`numero_periodos`,`con_sustitucion`,`facturable`,`no_periodica`) values (42,'REVISION TRIMESTRAL EXTINTORES','','M',34,3,0,0,0);
insert  into `plantilla_revision`(`plantilla_id`,`descripcion`,`comentarios`,`tipo_periodo`,`tipo_id`,`numero_periodos`,`con_sustitucion`,`facturable`,`no_periodica`) values (44,'REVISIÓN ANUAL EXTINTORES','','A',34,1,0,0,0);
insert  into `plantilla_revision`(`plantilla_id`,`descripcion`,`comentarios`,`tipo_periodo`,`tipo_id`,`numero_periodos`,`con_sustitucion`,`facturable`,`no_periodica`) values (45,'QUINQUENAL. PRUEBA HIDROSTÁTICA','Entregar ACTAS A INDUSTRIA.\r\nRecipientes de polvo\r\nRecipientes de agua\r\nRecipientes de CO2\r\nRecipientes de Nitrógeno','A',34,5,1,0,0);
insert  into `plantilla_revision`(`plantilla_id`,`descripcion`,`comentarios`,`tipo_periodo`,`tipo_id`,`numero_periodos`,`con_sustitucion`,`facturable`,`no_periodica`) values (48,'REVISIÓN TRIMESTRAL EXTINTORES ','CEPSA TENERIFE','M',37,3,0,0,0);
insert  into `plantilla_revision`(`plantilla_id`,`descripcion`,`comentarios`,`tipo_periodo`,`tipo_id`,`numero_periodos`,`con_sustitucion`,`facturable`,`no_periodica`) values (49,'REVISIÓN ANUAL EXTINTORES','CEPSA TENERIFE ','A',37,1,0,0,0);
insert  into `plantilla_revision`(`plantilla_id`,`descripcion`,`comentarios`,`tipo_periodo`,`tipo_id`,`numero_periodos`,`con_sustitucion`,`facturable`,`no_periodica`) values (50,'REVISIÓN TRIMESTRAL BIE','CEPSA TENERIFE','M',38,3,0,0,0);
insert  into `plantilla_revision`(`plantilla_id`,`descripcion`,`comentarios`,`tipo_periodo`,`tipo_id`,`numero_periodos`,`con_sustitucion`,`facturable`,`no_periodica`) values (51,'REVISION ANUAL BIE','CEPSA TENERIFE','A',38,1,0,0,0);
insert  into `plantilla_revision`(`plantilla_id`,`descripcion`,`comentarios`,`tipo_periodo`,`tipo_id`,`numero_periodos`,`con_sustitucion`,`facturable`,`no_periodica`) values (52,'REVISON TRIMESTRAL ESPALDERAS','OJO, REVISAR MANOMETOS','M',39,3,0,0,0);
insert  into `plantilla_revision`(`plantilla_id`,`descripcion`,`comentarios`,`tipo_periodo`,`tipo_id`,`numero_periodos`,`con_sustitucion`,`facturable`,`no_periodica`) values (53,'Mensual','Revisión Mensual Extintores','M',37,1,0,0,0);
insert  into `plantilla_revision`(`plantilla_id`,`descripcion`,`comentarios`,`tipo_periodo`,`tipo_id`,`numero_periodos`,`con_sustitucion`,`facturable`,`no_periodica`) values (54,'Intervenciones facturables en extintor','Es para trabajaos no programados','D',34,0,0,1,1);

/*Table structure for table `proceso` */

DROP TABLE IF EXISTS `proceso`;

CREATE TABLE `proceso` (
  `proceso_padre_nombre` varchar(255) DEFAULT NULL,
  `nombre` varchar(255) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`nombre`),
  KEY `idx_proceso_proceso_padre_nombre` (`proceso_padre_nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `proceso` */

insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosDispositivos','AccesorioGrid','Lista de accesorios aplicables a dispositivos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'administracion','Menú Administracion');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosDispositivos','AgenteExtintorGrid','Lista con los agentes de extinción disponibles');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosPlantillas','CampoGrid','Lista de campos registrados');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('windows','cascade','Organizar en cascada');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('extranet','categoriagrid','Categorias de documentos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('consultas','consultadispositivos','Consulta dispositivos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'consultarevisiones','Consulta de revisiones');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'consultas','Consultas (Punto de menu)');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'datos','Datos del sistema');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','DatosDispositivos','Agrupa todos los datos referidos a los dispositivos.');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','DatosPlantillas','Agrupa todos los datos referidos a las plantillas');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosDispositivos','dispositivoGrid','Lista de dispositivos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('extranet','documentogrid','Documentos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','EmpresaGrid','Lista de empresas');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'extranet','Menú de extranet');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosDispositivos','FabricanteGrid','Lista de los fabricantes de dispositivos.');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('extranet','grupomensajesgrid','Grupos / Carpetas de mensajes');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('administracion','grupousuariogrid','Grupos de usuarios');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'informes','Informes');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','InstalacionGrid','Instalaciones');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('extranet','mensajegrid','Mensajes');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosDispositivos','ModeloGrid','Lista de los modelos de dispositivos.');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','OperarioGrid','Operarios');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('administracion','permisogrid','Permisos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','PlantillaRevisionGrid','Lista de plantillas de revisión');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('administracion','procesogrid','Procesos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('Revisiones','programagrid','Programas de revisión');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('Revisiones','ProgramarGrid','Programar revisiones');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('extranet','repositoriotmpform','Repositorio temporal');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'Revisiones','Gestión de revisiones');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('Revisiones','revisiongrid','Revisiones');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('informes','RptResumenEmpresaInstalación','Resumen de revisiones y anomalías');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('extranet','subcategoriagrid','Subcategorias de documentos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('Revisiones','sustituciongrid','Sustituciones de dispositivos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'terminales','Menú de terminales');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('terminales','terminalgrid','Mantenimiento de terminales');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('windows','tile','Organizar sin solapar');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','tipoanomaliagrid','Tipos de anomalía');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosPlantillas','TipoCampoGrid','Lista de tipos de campo posibles');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosDispositivos','TipoGrid','Lista de los tipos de dispositivos.');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('extranet','usuarioextranetgrid','Usuarios de la extranet');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('administracion','usuariogrid','Usuarios');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'windows','Ventanas');

/*Table structure for table `programa` */

DROP TABLE IF EXISTS `programa`;

CREATE TABLE `programa` (
  `comentarios` text,
  `programa_id` int(11) NOT NULL AUTO_INCREMENT,
  `usuario_id` int(11) DEFAULT NULL,
  `fecha_programada` datetime NOT NULL,
  `estado` varchar(255) DEFAULT NULL,
  `carga_terminal_id` int(11) DEFAULT NULL,
  `terminal_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`programa_id`),
  KEY `idx_programa_usuario_id` (`usuario_id`),
  KEY `idx_programa_carga_terminal_id` (`carga_terminal_id`),
  KEY `idx_programa_terminal_id` (`terminal_id`),
  CONSTRAINT `ref_programa_terminal` FOREIGN KEY (`terminal_id`) REFERENCES `terminal` (`terminal_id`),
  CONSTRAINT `ref_programa_usuario` FOREIGN KEY (`usuario_id`) REFERENCES `usuario` (`usuario_id`)
) ENGINE=InnoDB AUTO_INCREMENT=131 DEFAULT CHARSET=latin1;

/*Data for the table `programa` */

insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Agrupacion de revisiones 1',100,1,'2012-02-10 00:00:00','SIN COMENZAR',NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Agrupacion Revisiones 3',102,1,'2012-02-09 00:00:00','SIN COMENZAR',NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Programación creada el 08/02/2012 08:57:00',109,1,'2012-03-01 00:00:00','EN CURSO',NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Programación creada el 08/02/2012 03:44:54',112,1,'2012-08-01 00:00:00','FINALIZADA',NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Programación creada el 08/02/2012 04:54:14',116,1,'2012-06-01 00:00:00','FINALIZADA',NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Programación creada el 08/02/2012 04:59:09',117,1,'2012-10-05 00:00:00','FINALIZADA',NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Pruebas 11',119,1,'2012-02-15 00:00:00','FINALIZADA',NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Programación creada el 16/02/2012 08:37:50',120,1,'0001-01-01 00:00:00','EN CURSO',NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Programación creada el 16/02/2012 09:49:24',121,1,'2012-02-16 00:00:00','FINALIZADA',NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Programación creada el 16/02/2012 10:15:02',122,1,'2012-02-16 00:00:00','SIN COMENZAR',NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Programación creada el 16/02/2012 11:01:13',123,1,'2012-02-17 00:00:00','FINALIZADA',NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Programación creada el 16/02/2012 04:01:43',124,1,'0001-01-01 00:00:00',NULL,NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Programación creada el 16/02/2012 04:01:44',125,1,'2012-02-29 00:00:00','SIN COMENZAR',NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Programación creada el 16/02/2012 05:05:06',126,1,'2012-02-17 00:00:00','FINALIZADA',NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Programación creada el 17/02/2012 07:48:17',127,1,'2012-02-17 00:00:00','FINALIZADA',NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Programación creada el 22/02/2012 04:30:07',128,1,'2012-02-24 00:00:00','SIN COMENZAR',NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Programación creada el 22/02/2012 04:32:14',129,1,'0001-01-01 00:00:00',NULL,NULL,NULL);
insert  into `programa`(`comentarios`,`programa_id`,`usuario_id`,`fecha_programada`,`estado`,`carga_terminal_id`,`terminal_id`) values ('Programación creada el 22/02/2012 04:33:59',130,15,'2012-02-28 00:00:00','SIN COMENZAR',NULL,NULL);

/*Table structure for table `resumen_revision` */

DROP TABLE IF EXISTS `resumen_revision`;

CREATE TABLE `resumen_revision` (
  `resumen_revision_id` int(11) NOT NULL AUTO_INCREMENT,
  `plantilla_id` int(11) DEFAULT NULL,
  `fecha_ultima` datetime NOT NULL,
  `fecha_siguiente` datetime NOT NULL,
  `fecha_inicio` datetime NOT NULL,
  `dispositivo_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`resumen_revision_id`),
  KEY `idx_resumen_revision_plantilla_id` (`plantilla_id`),
  KEY `idx_resumen_revision_dispositivo_id` (`dispositivo_id`),
  CONSTRAINT `ref_resumen_revision_dispositivo` FOREIGN KEY (`dispositivo_id`) REFERENCES `dispositivo` (`dispositivo_id`),
  CONSTRAINT `ref_resumen_revision_plantilla_revision` FOREIGN KEY (`plantilla_id`) REFERENCES `plantilla_revision` (`plantilla_id`)
) ENGINE=InnoDB AUTO_INCREMENT=521 DEFAULT CHARSET=latin1;

/*Data for the table `resumen_revision` */

insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (114,42,'2012-03-02 00:00:00','2012-06-02 00:00:00','0000-00-00 00:00:00',100);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (115,42,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',101);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (116,42,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',102);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (117,42,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',103);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (118,42,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',104);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (119,42,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',105);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (120,42,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',106);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (121,42,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',107);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (122,42,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',108);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (123,42,'2012-02-17 00:00:00','2012-05-17 00:00:00','2011-11-18 00:00:00',109);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (124,42,'2012-02-29 00:00:00','2012-05-29 00:00:00','2012-01-01 00:00:00',110);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (125,42,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',111);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (126,42,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',112);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (127,42,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',113);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (128,42,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',114);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (129,42,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',115);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (130,42,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',116);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (131,42,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',117);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (132,42,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',118);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (133,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (134,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (135,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (136,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (137,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (138,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (139,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (140,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (141,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (142,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (143,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (144,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (145,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (146,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (147,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (148,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (149,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (150,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (151,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (152,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (153,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (154,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (155,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (156,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (157,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (158,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (159,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (160,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (161,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (162,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (163,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (164,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (165,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (166,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (167,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (168,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (169,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (170,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (171,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (172,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (173,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (174,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (175,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (176,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (177,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (178,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (179,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (180,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (181,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (182,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (183,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (184,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (185,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (186,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (187,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (188,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (189,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (190,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (191,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (192,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (193,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (194,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (195,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (196,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (197,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (198,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (199,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (200,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (201,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (202,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (203,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (204,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (205,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (206,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (207,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (208,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (209,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (210,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (211,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (212,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (213,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (214,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (215,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (216,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (217,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (218,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (219,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (220,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (221,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (222,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (223,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (224,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (225,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (226,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (227,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (228,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (229,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (230,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (231,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (232,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (233,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (234,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (235,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (236,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (237,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (238,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (239,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (240,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (241,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (242,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (243,NULL,'0000-00-00 00:00:00','0000-00-00 00:00:00','0000-00-00 00:00:00',NULL);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (244,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',205);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (245,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',206);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (246,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',207);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (247,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',208);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (248,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',209);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (249,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',210);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (250,44,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',104);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (251,45,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',104);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (252,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',213);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (253,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',214);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (254,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',215);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (255,44,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',101);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (256,45,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',101);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (257,42,'2011-10-10 00:00:00','2012-01-10 00:00:00','2011-10-10 00:00:00',233);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (258,44,'2011-01-03 00:00:00','2012-01-03 00:00:00','2011-01-03 00:00:00',233);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (259,45,'2008-01-07 00:00:00','2013-01-07 00:00:00','2008-01-07 00:00:00',233);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (260,42,'2012-02-16 00:00:00','2012-05-16 00:00:00','2011-10-03 00:00:00',234);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (261,44,'2012-02-16 00:00:00','2013-02-16 00:00:00','2011-03-22 00:00:00',234);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (262,45,'2012-02-16 00:00:00','2017-02-16 00:00:00','2008-11-25 00:00:00',234);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (263,42,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',236);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (264,44,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',236);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (265,45,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',236);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (266,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',227);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (267,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',228);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (268,48,'2011-11-15 00:00:00','2012-02-15 00:00:00','2011-11-15 00:00:00',262);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (269,49,'2011-11-15 00:00:00','2012-11-15 00:00:00','2011-11-15 00:00:00',262);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (270,48,'2011-12-30 00:00:00','2012-03-30 00:00:00','2011-12-30 00:00:00',238);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (271,49,'2011-09-30 00:00:00','2012-09-30 00:00:00','2011-09-30 00:00:00',238);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (272,48,'2011-12-30 00:00:00','2012-03-30 00:00:00','2011-12-30 00:00:00',239);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (273,49,'2011-09-30 00:00:00','2012-09-30 00:00:00','2011-09-30 00:00:00',239);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (274,48,'2012-01-26 00:00:00','2012-04-26 00:00:00','2011-11-15 00:00:00',240);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (275,49,'2011-08-15 00:00:00','2012-08-15 00:00:00','2011-10-15 00:00:00',240);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (276,48,'2012-01-26 00:00:00','2012-04-26 00:00:00','2011-11-15 00:00:00',241);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (277,49,'2011-08-15 00:00:00','2012-08-15 00:00:00','2011-08-15 00:00:00',241);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (278,48,'2012-01-30 00:00:00','2012-04-30 00:00:00','2012-01-30 00:00:00',242);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (279,49,'2012-01-30 00:00:00','2013-01-30 00:00:00','2012-01-30 00:00:00',242);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (280,48,'2011-11-10 00:00:00','2012-02-10 00:00:00','2011-11-10 00:00:00',249);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (281,49,'2011-02-10 00:00:00','2012-02-10 00:00:00','2011-02-10 00:00:00',249);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (282,48,'2011-11-02 00:00:00','2012-02-02 00:00:00','2011-11-30 00:00:00',258);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (283,49,'2011-02-02 00:00:00','2012-02-02 00:00:00','2011-01-28 00:00:00',258);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (284,48,'2011-11-28 00:00:00','2012-02-28 00:00:00','2011-11-30 00:00:00',259);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (285,49,'2011-01-28 00:00:00','2012-01-28 00:00:00','2011-01-28 00:00:00',259);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (286,48,'2012-01-26 00:00:00','2012-04-26 00:00:00','2011-11-15 00:00:00',246);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (287,49,'2011-02-15 00:00:00','2012-02-15 00:00:00','2011-11-15 00:00:00',246);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (288,48,'2012-01-26 00:00:00','2012-04-26 00:00:00','2011-11-15 00:00:00',247);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (289,49,'2011-02-15 00:00:00','2012-02-15 00:00:00','2011-11-15 00:00:00',247);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (290,48,'2012-01-26 00:00:00','2012-04-26 00:00:00','2011-11-15 00:00:00',244);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (291,49,'2011-11-15 00:00:00','2012-11-15 00:00:00','2011-11-15 00:00:00',244);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (292,48,'2011-11-15 00:00:00','2012-02-15 00:00:00','2011-11-15 00:00:00',260);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (293,49,'2011-02-15 00:00:00','2012-02-15 00:00:00','2011-11-15 00:00:00',260);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (294,48,'2011-11-15 00:00:00','2012-02-15 00:00:00','2011-11-15 00:00:00',261);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (295,49,'2011-11-15 00:00:00','2012-11-15 00:00:00','2011-11-15 00:00:00',261);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (296,50,'2011-11-30 00:00:00','2012-02-29 00:00:00','2011-11-30 00:00:00',268);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (297,51,'2011-05-30 00:00:00','2012-05-30 00:00:00','2011-05-30 00:00:00',268);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (300,42,'2001-01-01 00:00:00','2001-04-01 00:00:00','2011-12-13 00:00:00',100);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (301,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',101);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (302,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',102);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (303,42,'2001-01-01 00:00:00','2001-04-01 00:00:00','2011-12-13 00:00:00',103);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (304,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',104);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (305,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',105);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (306,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',106);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (307,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',107);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (308,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',108);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (309,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',109);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (310,42,'2012-01-01 00:00:00','2012-04-01 00:00:00','2011-12-13 00:00:00',110);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (311,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',111);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (312,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',112);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (313,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',113);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (314,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',114);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (315,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',115);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (316,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',116);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (317,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',117);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (318,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',118);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (319,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',119);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (320,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',120);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (321,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',121);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (322,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',122);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (323,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',123);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (324,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',124);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (325,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',125);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (326,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',126);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (327,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',127);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (328,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',128);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (329,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',129);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (330,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',130);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (331,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',131);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (332,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',132);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (333,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',133);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (334,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',134);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (335,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',135);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (336,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',136);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (337,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',137);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (338,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',138);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (339,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',139);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (340,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',140);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (341,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',141);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (342,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',142);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (343,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',143);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (344,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',144);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (345,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',145);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (346,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',146);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (347,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',147);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (348,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',148);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (349,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',149);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (350,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',150);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (351,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',151);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (352,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',152);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (353,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',153);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (354,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',154);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (355,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',155);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (356,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',156);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (357,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',157);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (358,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',158);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (359,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',159);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (360,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',160);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (361,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',161);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (362,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',162);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (363,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',163);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (364,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',164);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (365,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',165);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (366,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',166);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (367,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',167);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (368,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',168);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (369,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',169);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (370,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',170);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (371,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',171);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (372,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',172);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (373,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',173);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (374,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',174);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (375,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',175);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (376,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',176);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (377,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',177);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (378,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',178);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (379,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',179);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (380,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',180);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (381,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',181);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (382,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',182);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (383,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',183);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (384,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',184);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (385,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',185);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (386,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',186);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (387,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',187);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (388,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',188);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (389,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',189);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (390,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',190);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (391,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',191);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (392,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',192);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (393,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',193);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (394,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',194);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (395,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',195);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (396,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',196);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (397,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',197);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (398,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',198);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (399,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',199);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (400,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',200);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (401,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',201);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (402,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',202);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (403,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',203);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (404,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',204);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (405,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',205);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (406,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',206);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (407,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',207);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (408,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',208);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (409,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',209);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (410,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',210);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (411,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',211);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (412,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',212);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (413,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',213);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (414,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',214);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (415,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',215);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (416,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',216);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (417,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',217);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (418,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',218);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (419,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',219);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (420,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',220);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (421,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',221);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (422,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',222);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (423,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',223);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (424,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',224);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (425,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',225);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (426,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',226);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (427,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',227);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (428,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',228);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (429,42,'2001-01-01 00:00:00','2001-01-01 00:00:00','2011-12-13 00:00:00',229);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (430,44,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',108);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (431,45,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',108);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (432,50,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',271);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (433,51,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',271);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (434,44,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',105);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (435,45,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',105);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (436,44,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',100);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (437,45,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',100);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (438,48,'2012-01-11 00:00:00','2012-04-11 00:00:00','2012-01-11 00:00:00',272);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (439,49,'2011-02-01 00:00:00','2012-02-01 00:00:00','2011-02-01 00:00:00',272);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (440,53,'2012-01-05 00:00:00','2012-02-05 00:00:00','2012-01-05 00:00:00',272);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (441,48,'2011-12-30 00:00:00','2012-03-30 00:00:00','2011-12-30 00:00:00',273);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (442,49,'2011-12-30 00:00:00','2012-12-30 00:00:00','2011-12-30 00:00:00',273);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (443,53,'2012-01-30 00:00:00','2012-02-29 00:00:00','2012-01-30 00:00:00',273);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (444,53,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',238);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (445,48,'2011-11-10 00:00:00','2012-02-10 00:00:00','2011-11-10 00:00:00',274);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (446,49,'2011-02-15 00:00:00','2012-02-15 00:00:00','2011-02-15 00:00:00',274);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (447,53,'2012-01-10 00:00:00','2012-02-10 00:00:00','2012-01-10 00:00:00',274);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (448,53,'2012-01-10 00:00:00','2012-02-10 00:00:00','2012-01-10 00:00:00',249);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (449,48,'2011-11-10 00:00:00','2012-02-10 00:00:00','2011-11-10 00:00:00',250);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (450,49,'2011-02-10 00:00:00','2012-02-10 00:00:00','2011-02-10 00:00:00',250);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (451,53,'2012-02-01 00:00:00','2012-03-01 00:00:00','2012-02-01 00:00:00',250);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (452,48,'2011-11-15 00:00:00','2012-02-15 00:00:00','2011-11-15 00:00:00',251);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (453,49,'2011-05-15 00:00:00','2012-05-15 00:00:00','2011-05-15 00:00:00',251);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (454,53,'2012-01-15 00:00:00','2012-02-15 00:00:00','2012-01-15 00:00:00',251);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (455,42,'2011-11-15 00:00:00','2012-02-15 00:00:00','2011-11-15 00:00:00',275);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (456,44,'2011-02-15 00:00:00','2012-02-15 00:00:00','2011-02-15 00:00:00',275);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (457,45,'2007-02-15 00:00:00','2012-02-15 00:00:00','2007-02-15 00:00:00',275);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (458,42,'2011-11-10 00:00:00','2012-02-10 00:00:00','2012-01-10 00:00:00',276);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (459,44,'2011-11-10 00:00:00','2012-11-10 00:00:00','2011-11-10 00:00:00',276);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (460,45,'2007-02-15 00:00:00','2012-02-15 00:00:00','2007-11-10 00:00:00',276);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (461,42,'2011-11-11 00:00:00','2012-02-11 00:00:00','2011-11-11 00:00:00',277);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (462,44,'2011-02-10 00:00:00','2012-02-10 00:00:00','2011-02-10 00:00:00',277);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (463,45,'2007-02-12 00:00:00','2012-02-12 00:00:00','2007-02-12 00:00:00',277);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (464,48,'2011-11-15 00:00:00','2012-02-15 00:00:00','2011-11-15 00:00:00',278);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (465,49,'2011-02-10 00:00:00','2012-02-10 00:00:00','2011-02-10 00:00:00',278);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (466,53,'2012-01-15 00:00:00','2012-02-15 00:00:00','2012-01-15 00:00:00',278);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (467,44,'2012-02-17 00:00:00','2013-02-17 00:00:00','2012-02-14 00:00:00',109);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (468,45,'2012-02-17 00:00:00','2017-02-17 00:00:00','2012-02-10 00:00:00',109);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (472,48,'2012-10-05 00:00:00','2013-01-05 00:00:00','2012-01-01 00:00:00',281);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (473,49,'2012-10-05 00:00:00','2013-10-05 00:00:00','2012-01-01 00:00:00',281);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (474,53,'2012-10-05 00:00:00','2012-11-05 00:00:00','2012-01-01 00:00:00',281);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (475,48,'2012-02-08 00:00:00','2012-05-08 00:00:00','2011-11-10 00:00:00',282);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (476,49,'2012-02-08 00:00:00','2013-02-08 00:00:00','2011-02-10 00:00:00',282);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (477,53,'2012-02-08 00:00:00','2012-03-08 00:00:00','2012-01-30 00:00:00',282);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (478,48,'2011-11-08 00:00:00','2012-02-08 00:00:00','2011-11-08 00:00:00',253);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (479,49,'2011-02-12 00:00:00','2012-02-12 00:00:00','2011-02-12 00:00:00',253);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (480,53,'2012-02-01 00:00:00','2012-03-01 00:00:00','2012-02-01 00:00:00',253);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (481,42,'2012-02-08 00:00:00','2012-05-08 00:00:00','2011-11-10 00:00:00',279);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (482,44,'2012-02-08 00:00:00','2013-02-08 00:00:00','2011-05-10 00:00:00',279);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (483,45,'2012-02-08 00:00:00','2017-02-08 00:00:00','2007-02-10 00:00:00',279);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (484,48,'2011-11-15 00:00:00','2012-02-15 00:00:00','2011-11-15 00:00:00',245);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (485,49,'2011-02-15 00:00:00','2012-02-15 00:00:00','2011-02-15 00:00:00',245);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (486,53,'2012-01-13 00:00:00','2012-02-13 00:00:00','2012-01-13 00:00:00',245);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (487,48,'2011-11-15 00:00:00','2012-02-15 00:00:00','2011-11-15 00:00:00',254);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (488,49,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',254);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (489,53,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',254);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (490,42,'2011-11-15 00:00:00','2012-02-15 00:00:00','2011-11-15 00:00:00',283);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (491,44,'2011-02-10 00:00:00','2012-02-10 00:00:00','2011-02-10 00:00:00',283);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (492,45,'2009-02-11 00:00:00','2014-02-11 00:00:00','2009-02-11 00:00:00',283);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (493,44,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',106);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (494,45,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',106);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (495,44,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',103);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (496,45,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',103);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (497,53,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',239);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (498,44,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',215);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (499,45,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',215);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (500,48,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',284);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (501,49,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',284);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (502,53,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',284);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (503,44,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',102);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (504,45,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',102);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (505,44,'2012-02-24 00:00:00','2013-02-24 00:00:00','2012-02-24 00:00:00',176);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (506,45,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',176);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (507,48,'2012-02-14 00:00:00','2012-05-14 00:00:00','2011-11-16 00:00:00',285);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (508,49,'2012-02-14 00:00:00','2013-02-14 00:00:00','2011-02-15 00:00:00',285);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (509,53,'2012-02-14 00:00:00','2012-03-14 00:00:00','2012-01-10 00:00:00',285);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (510,53,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',259);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (511,48,'2012-02-16 00:00:00','2012-05-16 00:00:00','2011-12-13 00:00:00',287);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (512,49,'2012-02-16 00:00:00','2013-02-16 00:00:00','2011-02-23 00:00:00',287);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (513,53,'2012-02-16 00:00:00','2012-03-16 00:00:00','2012-01-18 00:00:00',287);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (514,42,'2012-02-16 00:00:00','2012-05-16 00:00:00','2011-11-15 00:00:00',288);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (515,44,'2012-02-16 00:00:00','2013-02-16 00:00:00','2011-02-18 00:00:00',288);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (516,45,'2012-02-16 00:00:00','2017-02-16 00:00:00','2007-02-28 00:00:00',288);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (517,44,'2012-02-29 00:00:00','2013-02-28 00:00:00','2012-01-01 00:00:00',110);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (518,45,'2012-01-01 00:00:00','2017-01-01 00:00:00','2012-01-01 00:00:00',110);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (519,53,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',240);
insert  into `resumen_revision`(`resumen_revision_id`,`plantilla_id`,`fecha_ultima`,`fecha_siguiente`,`fecha_inicio`,`dispositivo_id`) values (520,54,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',101);

/*Table structure for table `revision` */

DROP TABLE IF EXISTS `revision`;

CREATE TABLE `revision` (
  `usuario_id` int(11) DEFAULT NULL,
  `revision_id` int(11) NOT NULL AUTO_INCREMENT,
  `resultado` varchar(255) DEFAULT NULL,
  `observaciones` varchar(255) DEFAULT NULL,
  `fecha_revision` datetime DEFAULT NULL,
  `estado` varchar(50) DEFAULT NULL,
  `fecha_programada` datetime DEFAULT NULL,
  `plantilla_id` int(11) DEFAULT NULL,
  `fecha_planificada` datetime DEFAULT NULL,
  `dispositivo_id` int(11) DEFAULT NULL,
  `programa_id` int(11) DEFAULT NULL,
  `cadu_prox` tinyint(1) NOT NULL,
  `resumen_informe` text,
  `grupo_programacion` int(11) NOT NULL,
  `tipo_anomalia_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`revision_id`),
  KEY `idx_revision_usuario_id` (`usuario_id`),
  KEY `idx_revision_dispositivo_id` (`dispositivo_id`),
  KEY `idx_revision_plantilla_id` (`plantilla_id`),
  KEY `idx_revision_programa_id` (`programa_id`),
  KEY `idx_revision_tipo_anomalia_id` (`tipo_anomalia_id`),
  CONSTRAINT `ref_revision_dispositivo` FOREIGN KEY (`dispositivo_id`) REFERENCES `dispositivo` (`dispositivo_id`),
  CONSTRAINT `ref_revision_plantilla_revision` FOREIGN KEY (`plantilla_id`) REFERENCES `plantilla_revision` (`plantilla_id`),
  CONSTRAINT `ref_revision_programa` FOREIGN KEY (`programa_id`) REFERENCES `programa` (`programa_id`),
  CONSTRAINT `ref_revision_tipo_anomalia` FOREIGN KEY (`tipo_anomalia_id`) REFERENCES `tipo_anomalia` (`tipo_anomalia_id`),
  CONSTRAINT `ref_revision_usuario` FOREIGN KEY (`usuario_id`) REFERENCES `usuario` (`usuario_id`)
) ENGINE=InnoDB AUTO_INCREMENT=519 DEFAULT CHARSET=latin1;

/*Data for the table `revision` */

insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,306,'ok','','2012-02-03 00:00:00','REALIZADA','0001-01-01 00:00:00',45,'2013-01-07 00:00:00',233,NULL,1,'',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,315,'okk','','2012-02-02 00:00:00','PLANIFICADA','2012-02-25 00:00:00',42,'2012-04-24 00:00:00',234,NULL,0,'PESO DEL EXTINTOR: |<br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,316,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-25 00:00:00',44,'2012-03-22 00:00:00',234,120,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,317,'Perfecto','','2012-02-16 00:00:00','REALIZADA','2012-02-16 00:00:00',45,'2013-11-25 00:00:00',234,121,0,'',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,321,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-03 00:00:00',48,'2012-03-30 00:00:00',238,NULL,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (15,325,'Correcto','Se le pone cartel nuevo','2012-01-26 00:00:00','PLANIFICADA','2012-02-06 00:00:00',48,'2012-02-15 00:00:00',240,NULL,0,'PESO DEL EXTINTOR: 13,8|<br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,327,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-06 00:00:00',49,'2012-08-15 00:00:00',240,NULL,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (15,328,'Ok','Se pone soporte nuevo. Quedan 3 en stock. Pedir a fábrica','2012-01-26 00:00:00','PLANIFICADA','2012-02-06 00:00:00',48,'2012-02-15 00:00:00',241,NULL,0,'PESO DEL EXTINTOR: 13,7|<br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,329,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-06 00:00:00',49,'2012-08-15 00:00:00',241,NULL,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,330,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-06 00:00:00',48,'2012-04-30 00:00:00',242,NULL,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,331,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-06 00:00:00',49,'2013-01-30 00:00:00',242,NULL,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (15,341,'Ok','','2012-01-26 00:00:00','PROGRAMADA','2012-02-24 00:00:00',48,'2012-02-02 00:00:00',258,128,1,'PESO DEL EXTINTOR: 13,8|<br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (15,342,'Apto','','2012-01-26 00:00:00','PLANIFICADA','2012-02-08 00:00:00',48,'2012-02-15 00:00:00',246,NULL,0,'PESO DEL EXTINTOR: 13,7|<br/>',1,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (15,344,'Apto','Se le coloca tarjeta nueva','2012-01-26 00:00:00','PLANIFICADA','2012-02-08 00:00:00',48,'2012-02-15 00:00:00',247,NULL,0,'PESO DEL EXTINTOR: 13,8|<br/>',1,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (15,346,'Ok','','2012-01-26 00:00:00','PROGRAMADA','2012-02-24 00:00:00',48,'2012-02-15 00:00:00',244,128,0,'PESO DEL EXTINTOR: 13,4|<br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,347,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-06 00:00:00',49,'2012-11-15 00:00:00',244,NULL,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,348,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-01 00:00:00',48,'2012-02-15 00:00:00',260,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,350,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-03 00:00:00',48,'2012-02-15 00:00:00',261,NULL,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,351,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-06 00:00:00',49,'2012-11-15 00:00:00',261,NULL,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,352,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-24 00:00:00',48,'2012-02-15 00:00:00',262,128,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,353,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-06 00:00:00',49,'2012-11-15 00:00:00',262,NULL,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,354,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-06 00:00:00',50,'2012-02-29 00:00:00',268,NULL,0,'',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,355,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-06 00:00:00',51,'2012-05-30 00:00:00',268,NULL,0,'',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,356,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-08 00:00:00',49,'2012-02-15 00:00:00',246,NULL,0,'PESO DEL EXTINTOR: |<br/>',1,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,357,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-08 00:00:00',49,'2012-02-15 00:00:00',247,NULL,0,'PESO DEL EXTINTOR: <br/>',1,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,358,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-02 00:00:00',49,'2012-02-15 00:00:00',260,NULL,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,359,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','0001-01-01 00:00:00',48,'2012-04-26 00:00:00',240,129,0,NULL,10,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,360,'OK con deficiencias','se encuetra pintura mnkdlv','2012-02-29 00:00:00','REALIZADA','2012-02-28 00:00:00',48,'2012-04-26 00:00:00',241,130,0,NULL,11,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,361,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-28 00:00:00',48,'2012-04-26 00:00:00',246,130,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,362,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-28 00:00:00',48,'2012-04-26 00:00:00',247,130,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,363,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',48,'2012-04-26 00:00:00',244,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,364,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',42,'2012-05-02 00:00:00',234,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,365,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',48,'2012-04-26 00:00:00',240,129,0,NULL,10,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,366,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-28 00:00:00',48,'2012-04-26 00:00:00',241,130,0,NULL,11,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,367,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-06 00:00:00',48,'2012-04-11 00:00:00',272,NULL,1,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,368,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-06 00:00:00',49,'2012-02-01 00:00:00',272,NULL,1,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,369,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-06 00:00:00',53,'2012-02-05 00:00:00',272,NULL,1,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,370,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-24 00:00:00',48,'2012-03-30 00:00:00',273,128,1,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (15,371,'Mal','','2012-02-06 00:00:00','REALIZADA','0001-01-01 00:00:00',49,'2012-12-30 00:00:00',273,NULL,1,'PESO DEL EXTINTOR: |<br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (15,372,'Baja','','2012-02-06 00:00:00','PLANIFICADA','0001-01-01 00:00:00',53,'2012-02-29 00:00:00',273,NULL,1,'',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,376,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-08 00:00:00',48,'2012-02-10 00:00:00',274,NULL,1,NULL,1,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,377,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-08 00:00:00',49,'2012-02-15 00:00:00',274,NULL,1,NULL,1,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (15,378,'mal','','2012-02-07 00:00:00','REALIZADA','0001-01-01 00:00:00',53,'2012-02-10 00:00:00',274,NULL,1,'',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,379,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-10 00:00:00',48,'2012-02-10 00:00:00',249,100,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,380,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-10 00:00:00',49,'2012-02-10 00:00:00',249,100,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,381,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-10 00:00:00',53,'2012-02-10 00:00:00',249,100,0,'',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,382,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-10 00:00:00',48,'2012-02-10 00:00:00',250,100,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,383,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-10 00:00:00',49,'2012-02-10 00:00:00',250,100,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,384,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',53,'2012-03-01 00:00:00',250,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,385,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-10 00:00:00',48,'2012-02-15 00:00:00',251,100,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,386,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',49,'2012-05-15 00:00:00',251,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,387,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-10 00:00:00',53,'2012-02-15 00:00:00',251,100,0,'',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,388,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-08 00:00:00',42,'2012-02-15 00:00:00',275,NULL,1,NULL,7,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,389,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-08 00:00:00',44,'2012-02-15 00:00:00',275,NULL,1,NULL,7,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,390,'Baja','','2012-02-08 00:00:00','PROGRAMADA','2012-02-08 00:00:00',45,'2012-02-15 00:00:00',275,120,1,'',7,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,392,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-08 00:00:00',42,'2012-02-10 00:00:00',276,NULL,0,NULL,7,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,393,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',44,'2012-11-10 00:00:00',276,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,395,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-08 00:00:00',45,'2012-02-15 00:00:00',276,120,0,NULL,7,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,396,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-09 00:00:00',42,'2012-02-11 00:00:00',277,102,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,397,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-09 00:00:00',44,'2012-02-10 00:00:00',277,102,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,398,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-09 00:00:00',45,'2012-02-12 00:00:00',277,102,0,'',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,399,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-07 00:00:00',48,'2012-02-15 00:00:00',278,NULL,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,400,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',49,'2012-02-10 00:00:00',278,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,401,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',53,'2012-02-15 00:00:00',278,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,416,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-09 00:00:00',48,'2012-02-10 00:00:00',282,NULL,0,NULL,2,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,418,'ooooookkkkkkk','','2012-02-08 00:00:00','PLANIFICADA','2012-02-09 00:00:00',49,'2012-02-10 00:00:00',282,NULL,0,'PESO DEL EXTINTOR: |<br/>',2,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,419,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-09 00:00:00',53,'2012-02-29 00:00:00',282,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,420,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',49,'2013-02-08 00:00:00',282,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,421,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',48,'2012-05-08 00:00:00',282,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,422,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',53,'2012-03-08 00:00:00',282,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,433,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-10 00:00:00',48,'2012-02-08 00:00:00',253,NULL,0,NULL,3,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,434,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','2012-02-10 00:00:00',49,'2012-02-12 00:00:00',253,NULL,0,NULL,3,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,435,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',53,'2012-03-01 00:00:00',253,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,442,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-09 00:00:00',42,'2012-02-10 00:00:00',279,NULL,0,NULL,4,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,443,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',44,'2012-05-10 00:00:00',279,NULL,0,NULL,5,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,444,'correcto','','2012-02-08 00:00:00','PROGRAMADA','2012-02-09 00:00:00',45,'2012-02-10 00:00:00',279,120,0,'',4,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,445,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',45,'2017-02-08 00:00:00',279,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,446,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',42,'2012-05-08 00:00:00',279,NULL,0,NULL,5,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,447,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',44,'2013-02-08 00:00:00',279,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,452,'nifgioclhnvb ','','2012-02-29 00:00:00','REALIZADA','0001-01-01 00:00:00',48,'2012-02-15 00:00:00',254,NULL,1,'PESO DEL EXTINTOR: |<br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,455,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',45,'2014-02-11 00:00:00',283,NULL,1,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,457,'jdfkñaflk','','2012-08-16 00:00:00','REALIZADA','2012-06-01 00:00:00',49,'2013-02-08 00:00:00',281,116,0,'PESO DEL EXTINTOR: |<br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,459,'jjjjj','','2012-10-05 00:00:00','REALIZADA','2012-10-05 00:00:00',49,'2013-08-16 00:00:00',281,117,0,'PESO DEL EXTINTOR: |<br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,460,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',48,'2012-11-16 00:00:00',281,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,461,'jjk','','2012-02-08 00:00:00','REALIZADA','2012-10-05 00:00:00',53,'2012-09-16 00:00:00',281,117,0,'',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,463,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',49,'2013-02-08 00:00:00',281,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,465,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',53,'2012-03-08 00:00:00',281,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,466,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',49,'2013-10-05 00:00:00',281,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,467,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',48,'2013-01-05 00:00:00',281,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,468,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',53,'2012-11-05 00:00:00',281,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,469,'OK','','2012-03-02 00:00:00','REALIZADA','0001-01-01 00:00:00',42,'2001-04-01 00:00:00',100,120,0,'PESO DEL EXTINTOR: |<br/>',0,1);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,471,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','0001-01-01 00:00:00',48,'2012-02-16 00:00:00',285,NULL,0,NULL,6,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,472,'Molt be','','2012-02-14 00:00:00','REALIZADA','2012-02-15 00:00:00',49,'2012-02-15 00:00:00',285,119,0,'PESO DEL EXTINTOR: |<br/>',6,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,474,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',49,'2013-02-14 00:00:00',285,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,475,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',48,'2012-05-14 00:00:00',285,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,476,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',53,'2012-03-14 00:00:00',285,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,477,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',42,'2001-04-01 00:00:00',103,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,478,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',45,'2017-02-16 00:00:00',234,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,479,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',42,'2012-05-16 00:00:00',234,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,480,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',44,'2013-02-16 00:00:00',234,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,484,'perfecto','','2012-02-16 00:00:00','REALIZADA','2012-02-17 00:00:00',49,'2012-02-08 00:00:00',287,123,0,'PESO DEL EXTINTOR: |<br/>',8,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,485,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',45,'2017-02-16 00:00:00',234,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,486,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',42,'2012-05-16 00:00:00',234,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,487,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',44,'2013-02-16 00:00:00',234,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,488,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',49,'2013-02-16 00:00:00',287,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,490,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-29 00:00:00',53,'2012-03-16 00:00:00',287,125,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,491,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',49,'2013-02-16 00:00:00',287,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,493,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',53,'2012-03-16 00:00:00',287,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,494,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',49,'2013-02-16 00:00:00',287,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,496,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',53,'2012-03-16 00:00:00',287,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,497,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',48,'2012-05-16 00:00:00',287,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,500,'oooooooookkkkk','','2012-02-16 00:00:00','REALIZADA','2012-02-17 00:00:00',45,'2012-02-28 00:00:00',288,126,0,'',9,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,501,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',45,'2017-02-16 00:00:00',288,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,502,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',42,'2012-05-16 00:00:00',288,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,503,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',44,'2013-02-16 00:00:00',288,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,506,'oook','','2012-02-17 00:00:00','REALIZADA','2012-02-17 00:00:00',45,'2017-02-10 00:00:00',109,127,1,'',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,512,'SUPERBIEN','','2012-02-29 00:00:00','REALIZADA','0001-01-01 00:00:00',44,'2013-01-01 00:00:00',110,NULL,0,'PESO DEL EXTINTOR: |<br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,513,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',45,'2017-01-01 00:00:00',110,NULL,1,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,514,'VA BENE DUE','','2012-02-29 00:00:00','REALIZADA','0001-01-01 00:00:00',44,'2013-02-28 00:00:00',110,NULL,0,'PESO DEL EXTINTOR: |<br/>',0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,516,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',44,'2013-02-28 00:00:00',110,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,517,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',42,'2012-05-29 00:00:00',110,NULL,0,NULL,0,NULL);
insert  into `revision`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,518,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',42,'2012-06-02 00:00:00',100,NULL,0,NULL,0,NULL);

/*Table structure for table `subcategoria` */

DROP TABLE IF EXISTS `subcategoria`;

CREATE TABLE `subcategoria` (
  `categoria_id` int(11) DEFAULT NULL,
  `nombre` varchar(255) DEFAULT NULL,
  `subcategoria_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`subcategoria_id`),
  KEY `idx_subcategoria_categoria_id` (`categoria_id`),
  CONSTRAINT `ref_subcategoria_categoria` FOREIGN KEY (`categoria_id`) REFERENCES `categoria` (`categoria_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `subcategoria` */

insert  into `subcategoria`(`categoria_id`,`nombre`,`subcategoria_id`) values (2,'Informe general de prevención',1);
insert  into `subcategoria`(`categoria_id`,`nombre`,`subcategoria_id`) values (1,'Revisiones trimestrales',2);
insert  into `subcategoria`(`categoria_id`,`nombre`,`subcategoria_id`) values (1,'Revisiones anuales',3);

/*Table structure for table `sustitucion` */

DROP TABLE IF EXISTS `sustitucion`;

CREATE TABLE `sustitucion` (
  `comentarios` text,
  `dispositivo_dispositivo_id` int(11) DEFAULT NULL,
  `dispositivo1_dispositivo_id` int(11) DEFAULT NULL,
  `fecha` datetime NOT NULL,
  `sustitucion_id` int(11) NOT NULL AUTO_INCREMENT,
  `usuario_id` int(11) DEFAULT NULL,
  `estado` varchar(255) NOT NULL,
  `programa_id` int(11) DEFAULT NULL,
  `revision_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`sustitucion_id`),
  KEY `idx_sustitucion_usuario_id` (`usuario_id`),
  KEY `ref_sustitucion_dispositivo` (`dispositivo_dispositivo_id`),
  KEY `ref_sustitucion_dispositivo2` (`dispositivo1_dispositivo_id`),
  KEY `idx_sustitucion_programa_id` (`programa_id`),
  KEY `idx_sustitucion_revision_id` (`revision_id`),
  CONSTRAINT `ref_sustitucion_dispositivo` FOREIGN KEY (`dispositivo_dispositivo_id`) REFERENCES `dispositivo` (`dispositivo_id`),
  CONSTRAINT `ref_sustitucion_dispositivo2` FOREIGN KEY (`dispositivo1_dispositivo_id`) REFERENCES `dispositivo` (`dispositivo_id`),
  CONSTRAINT `ref_sustitucion_programa` FOREIGN KEY (`programa_id`) REFERENCES `programa` (`programa_id`),
  CONSTRAINT `ref_sustitucion_revision` FOREIGN KEY (`revision_id`) REFERENCES `revision` (`revision_id`),
  CONSTRAINT `ref_sustitucion_usuario` FOREIGN KEY (`usuario_id`) REFERENCES `usuario` (`usuario_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

/*Data for the table `sustitucion` */

insert  into `sustitucion`(`comentarios`,`dispositivo_dispositivo_id`,`dispositivo1_dispositivo_id`,`fecha`,`sustitucion_id`,`usuario_id`,`estado`,`programa_id`,`revision_id`) values ('primera prueba',106,100,'2012-02-15 00:00:00',1,1,' ',NULL,NULL);
insert  into `sustitucion`(`comentarios`,`dispositivo_dispositivo_id`,`dispositivo1_dispositivo_id`,`fecha`,`sustitucion_id`,`usuario_id`,`estado`,`programa_id`,`revision_id`) values ('jfhlqdf',103,101,'2012-02-29 00:00:00',2,10,' ',NULL,NULL);
insert  into `sustitucion`(`comentarios`,`dispositivo_dispositivo_id`,`dispositivo1_dispositivo_id`,`fecha`,`sustitucion_id`,`usuario_id`,`estado`,`programa_id`,`revision_id`) values ('',239,284,'2012-02-14 00:00:00',3,1,' ',NULL,NULL);
insert  into `sustitucion`(`comentarios`,`dispositivo_dispositivo_id`,`dispositivo1_dispositivo_id`,`fecha`,`sustitucion_id`,`usuario_id`,`estado`,`programa_id`,`revision_id`) values ('',284,239,'2012-02-16 00:00:00',4,1,'REALIZADA',NULL,NULL);
insert  into `sustitucion`(`comentarios`,`dispositivo_dispositivo_id`,`dispositivo1_dispositivo_id`,`fecha`,`sustitucion_id`,`usuario_id`,`estado`,`programa_id`,`revision_id`) values (NULL,275,NULL,'0001-01-01 00:00:00',5,NULL,'PROGRAMADA',120,390);
insert  into `sustitucion`(`comentarios`,`dispositivo_dispositivo_id`,`dispositivo1_dispositivo_id`,`fecha`,`sustitucion_id`,`usuario_id`,`estado`,`programa_id`,`revision_id`) values (NULL,276,NULL,'0001-01-01 00:00:00',6,NULL,'PROGRAMADA',120,395);
insert  into `sustitucion`(`comentarios`,`dispositivo_dispositivo_id`,`dispositivo1_dispositivo_id`,`fecha`,`sustitucion_id`,`usuario_id`,`estado`,`programa_id`,`revision_id`) values (NULL,279,NULL,'0001-01-01 00:00:00',7,NULL,'PROGRAMADA',120,444);
insert  into `sustitucion`(`comentarios`,`dispositivo_dispositivo_id`,`dispositivo1_dispositivo_id`,`fecha`,`sustitucion_id`,`usuario_id`,`estado`,`programa_id`,`revision_id`) values ('',234,100,'2012-02-16 00:00:00',8,1,'REALIZADA',121,317);
insert  into `sustitucion`(`comentarios`,`dispositivo_dispositivo_id`,`dispositivo1_dispositivo_id`,`fecha`,`sustitucion_id`,`usuario_id`,`estado`,`programa_id`,`revision_id`) values (NULL,100,234,'2012-02-16 10:10:03',9,NULL,'REALIZADA',NULL,317);
insert  into `sustitucion`(`comentarios`,`dispositivo_dispositivo_id`,`dispositivo1_dispositivo_id`,`fecha`,`sustitucion_id`,`usuario_id`,`estado`,`programa_id`,`revision_id`) values ('',287,285,'2012-02-17 00:00:00',10,1,'REALIZADA',NULL,490);
insert  into `sustitucion`(`comentarios`,`dispositivo_dispositivo_id`,`dispositivo1_dispositivo_id`,`fecha`,`sustitucion_id`,`usuario_id`,`estado`,`programa_id`,`revision_id`) values ('',288,289,'2012-02-20 00:00:00',11,1,'REALIZADA',126,500);
insert  into `sustitucion`(`comentarios`,`dispositivo_dispositivo_id`,`dispositivo1_dispositivo_id`,`fecha`,`sustitucion_id`,`usuario_id`,`estado`,`programa_id`,`revision_id`) values (NULL,289,288,'2012-02-16 17:13:10',12,NULL,'REALIZADA',NULL,500);
insert  into `sustitucion`(`comentarios`,`dispositivo_dispositivo_id`,`dispositivo1_dispositivo_id`,`fecha`,`sustitucion_id`,`usuario_id`,`estado`,`programa_id`,`revision_id`) values ('',109,108,'2012-02-14 00:00:00',13,1,'REALIZADA',127,506);
insert  into `sustitucion`(`comentarios`,`dispositivo_dispositivo_id`,`dispositivo1_dispositivo_id`,`fecha`,`sustitucion_id`,`usuario_id`,`estado`,`programa_id`,`revision_id`) values (NULL,108,109,'2012-02-17 19:52:51',14,NULL,'REALIZADA',NULL,506);

/*Table structure for table `telefono` */

DROP TABLE IF EXISTS `telefono`;

CREATE TABLE `telefono` (
  `tipo` varchar(255) DEFAULT NULL,
  `telefono_id` int(11) NOT NULL AUTO_INCREMENT,
  `numero` varchar(255) DEFAULT NULL,
  `instalacion_id` int(11) DEFAULT NULL,
  `empresa_id` int(11) DEFAULT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`telefono_id`),
  KEY `idx_telefono_instalacion_id` (`instalacion_id`),
  KEY `idx_telefono_empresa_id` (`empresa_id`),
  CONSTRAINT `ref_telefono_empresa` FOREIGN KEY (`empresa_id`) REFERENCES `empresa` (`empresa_id`),
  CONSTRAINT `ref_telefono_instalacion` FOREIGN KEY (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Data for the table `telefono` */

insert  into `telefono`(`tipo`,`telefono_id`,`numero`,`instalacion_id`,`empresa_id`,`descripcion`) values (NULL,7,'91 337 60 00',NULL,28,'');

/*Table structure for table `terminal` */

DROP TABLE IF EXISTS `terminal`;

CREATE TABLE `terminal` (
  `empresa_id` int(11) DEFAULT NULL,
  `nombre` varchar(255) DEFAULT NULL,
  `numero_serie` varchar(255) DEFAULT NULL,
  `observaciones` text,
  `terminal_id` int(11) NOT NULL AUTO_INCREMENT,
  `tipo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`terminal_id`),
  KEY `idx_terminal_empresa_id` (`empresa_id`),
  CONSTRAINT `ref_terminal_empresa` FOREIGN KEY (`empresa_id`) REFERENCES `empresa` (`empresa_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `terminal` */

insert  into `terminal`(`empresa_id`,`nombre`,`numero_serie`,`observaciones`,`terminal_id`,`tipo`) values (24,'Intermec CN3 - SN 2215546','2215546','',1,'WINDOWS MOBILE');

/*Table structure for table `tipo_anomalia` */

DROP TABLE IF EXISTS `tipo_anomalia`;

CREATE TABLE `tipo_anomalia` (
  `nombre` varchar(255) DEFAULT NULL,
  `tipo_anomalia_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`tipo_anomalia_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `tipo_anomalia` */

insert  into `tipo_anomalia`(`nombre`,`tipo_anomalia_id`) values ('Oxidación visible',1);
insert  into `tipo_anomalia`(`nombre`,`tipo_anomalia_id`) values ('Sin etiquetado correcto',2);

/*Table structure for table `tipo_campo` */

DROP TABLE IF EXISTS `tipo_campo`;

CREATE TABLE `tipo_campo` (
  `tipo_id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`tipo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*Data for the table `tipo_campo` */

insert  into `tipo_campo`(`tipo_id`,`descripcion`) values (1,'Campo OK/MAL');
insert  into `tipo_campo`(`tipo_id`,`descripcion`) values (3,'Texto');
insert  into `tipo_campo`(`tipo_id`,`descripcion`) values (4,'Tetra');
insert  into `tipo_campo`(`tipo_id`,`descripcion`) values (5,'Numerico');
insert  into `tipo_campo`(`tipo_id`,`descripcion`) values (6,'Fecha');

/*Table structure for table `tipo_dispositivo` */

DROP TABLE IF EXISTS `tipo_dispositivo`;

CREATE TABLE `tipo_dispositivo` (
  `tipo_id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) DEFAULT NULL,
  `caduca` int(11) NOT NULL,
  `empresa_id` int(11) DEFAULT NULL,
  `instalacion_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`tipo_id`),
  KEY `idx_tipo_dispositivo_empresa_id` (`empresa_id`),
  KEY `idx_tipo_dispositivo_instalacion_id` (`instalacion_id`),
  CONSTRAINT `ref_tipo_dispositivo_empresa` FOREIGN KEY (`empresa_id`) REFERENCES `empresa` (`empresa_id`),
  CONSTRAINT `ref_tipo_dispositivo_instalacion` FOREIGN KEY (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=latin1;

/*Data for the table `tipo_dispositivo` */

insert  into `tipo_dispositivo`(`tipo_id`,`nombre`,`caduca`,`empresa_id`,`instalacion_id`) values (34,'EXTINTOR AEQT',20,24,NULL);
insert  into `tipo_dispositivo`(`tipo_id`,`nombre`,`caduca`,`empresa_id`,`instalacion_id`) values (37,'EXTINTOR CEPSA',20,28,46);
insert  into `tipo_dispositivo`(`tipo_id`,`nombre`,`caduca`,`empresa_id`,`instalacion_id`) values (38,'BOCAS DE INCENDIO EQUIPADAS (BIE) CEPSA',20,28,46);
insert  into `tipo_dispositivo`(`tipo_id`,`nombre`,`caduca`,`empresa_id`,`instalacion_id`) values (39,'ESPALDERA EAR',6,28,46);
insert  into `tipo_dispositivo`(`tipo_id`,`nombre`,`caduca`,`empresa_id`,`instalacion_id`) values (40,'BOCAS DE INCENDIO EQUIPADAS (BIE) AEQT',50,24,NULL);

/*Table structure for table `usuario` */

DROP TABLE IF EXISTS `usuario`;

CREATE TABLE `usuario` (
  `usuario_id` int(11) NOT NULL AUTO_INCREMENT,
  `passwd` varchar(255) DEFAULT NULL,
  `nombre` varchar(255) DEFAULT NULL,
  `login` varchar(255) DEFAULT NULL,
  `grupo_usuario_id` int(11) NOT NULL,
  `empresa_id` int(11) DEFAULT NULL,
  `instalacion_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`usuario_id`),
  KEY `idx_usuario_grupo_usuario_id` (`grupo_usuario_id`),
  KEY `idx_usuario_empresa_id` (`empresa_id`),
  KEY `idx_usuario_instalacion_id` (`instalacion_id`),
  CONSTRAINT `ref_usuario_empresa` FOREIGN KEY (`empresa_id`) REFERENCES `empresa` (`empresa_id`),
  CONSTRAINT `ref_usuario_grupo_usuario` FOREIGN KEY (`grupo_usuario_id`) REFERENCES `grupo_usuario` (`grupo_usuario_id`),
  CONSTRAINT `ref_usuario_instalacion` FOREIGN KEY (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

/*Data for the table `usuario` */

insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (1,'21232F297A57A5A743894A0E4A801F','Administrador','admin',1,NULL,NULL);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (6,NULL,'Super usuario (new admin)','super',1,NULL,NULL);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (10,'6B841A2635FFCC390884854E672197','IVAN GIL BUENO','ivan',7,24,NULL);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (11,'6B841A2635FFCC390884854E672197','ISIDRO HERRERA RODRIGUEZ','isidro',7,25,NULL);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (12,'31AD2F10870BB5E4C517357BF9F95E','PQN EQUIPO A','PQNA',8,24,NULL);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (13,'495559A7854295EC51E5B3178EAC8F','PQN EQUIPO B','PQNB',8,24,NULL);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (14,'82EB39C65C8451DE26C08530F1CC42','PQN EQUIPO C','PQNC',8,24,NULL);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (15,'81DC9BDB52D04DC20036DBD8313ED0','RAFAEL SANTANA PEREIRA','rafa',9,28,46);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (16,'828C88F34ECB4C1CA8D89E018C6FAD','CEPSA TENERIFE EQUIPO A','equipoa',10,28,46);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (17,NULL,'CEPSA TENERIFE EQUIPO B','equipob',10,28,46);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (18,'ED1D856DCB0C51EA82EBC896AB01E5','CEPSA TENERIFE EQUIPO C','equipoc',10,28,46);

/*Table structure for table `usuario_extranet` */

DROP TABLE IF EXISTS `usuario_extranet`;

CREATE TABLE `usuario_extranet` (
  `correo` varchar(255) DEFAULT NULL,
  `empresa_id` int(11) DEFAULT NULL,
  `instalacion_id` int(11) DEFAULT NULL,
  `login` varchar(255) DEFAULT NULL,
  `nombre` varchar(255) DEFAULT NULL,
  `passwd` varchar(255) DEFAULT NULL,
  `plain_password` varchar(255) DEFAULT NULL,
  `usuario_extranet_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`usuario_extranet_id`),
  KEY `idx_usuario_extranet_empresa_id` (`empresa_id`),
  KEY `idx_usuario_extranet_instalacion_id` (`instalacion_id`),
  CONSTRAINT `ref_usuario_extranet_empresa` FOREIGN KEY (`empresa_id`) REFERENCES `empresa` (`empresa_id`),
  CONSTRAINT `ref_usuario_extranet_instalacion` FOREIGN KEY (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `usuario_extranet` */

insert  into `usuario_extranet`(`correo`,`empresa_id`,`instalacion_id`,`login`,`nombre`,`passwd`,`plain_password`,`usuario_extranet_id`) values ('ragare@gmail.com',24,41,'rgarcia','Rafael Garcia','81DC9BDB52D04DC20036DBD8313ED0',NULL,2);
insert  into `usuario_extranet`(`correo`,`empresa_id`,`instalacion_id`,`login`,`nombre`,`passwd`,`plain_password`,`usuario_extranet_id`) values ('',28,46,'jmartinez','Juan Martinez Osca','81DC9BDB52D04DC20036DBD8313ED0',NULL,3);

/*Table structure for table `utp_parametros` */

DROP TABLE IF EXISTS `utp_parametros`;

CREATE TABLE `utp_parametros` (
  `utp_parametros_id` int(11) NOT NULL AUTO_INCREMENT,
  `telefono` varchar(20) DEFAULT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `max_dosis_superficial` decimal(20,10) NOT NULL,
  `max_dosis_superfical_periodo` decimal(20,10) NOT NULL,
  `max_dosis_profunda_periodo` decimal(20,10) NOT NULL,
  `max_dosis_profunda` decimal(20,10) NOT NULL,
  `mail` varchar(50) DEFAULT NULL,
  `direccion` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`utp_parametros_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `utp_parametros` */

/*Table structure for table `v_dispositivos_en _almacen` */

DROP TABLE IF EXISTS `v_dispositivos_en _almacen`;

/*!50001 DROP VIEW IF EXISTS `v_dispositivos_en _almacen` */;
/*!50001 DROP TABLE IF EXISTS `v_dispositivos_en _almacen` */;

/*!50001 CREATE TABLE  `v_dispositivos_en _almacen`(
 `id` int(11) ,
 `nombre` varchar(255) ,
 `funcion` varchar(255) ,
 `estado` varchar(255) ,
 `ntipo` varchar(255) ,
 `nempresa` varchar(255) ,
 `ninstalacion` varchar(255) 
)*/;

/*Table structure for table `v_revisiones` */

DROP TABLE IF EXISTS `v_revisiones`;

/*!50001 DROP VIEW IF EXISTS `v_revisiones` */;
/*!50001 DROP TABLE IF EXISTS `v_revisiones` */;

/*!50001 CREATE TABLE  `v_revisiones`(
 `id` int(11) ,
 `fecha` datetime ,
 `dispositivo` varchar(255) ,
 `instalacion` varchar(255) ,
 `resultado` varchar(255) ,
 `estado` varchar(50) ,
 `anomalia` varchar(255) 
)*/;

/*View structure for view v_dispositivos_en _almacen */

/*!50001 DROP TABLE IF EXISTS `v_dispositivos_en _almacen` */;
/*!50001 DROP VIEW IF EXISTS `v_dispositivos_en _almacen` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_dispositivos_en _almacen` AS (select `dispositivo`.`dispositivo_id` AS `id`,`dispositivo`.`nombre` AS `nombre`,`dispositivo`.`funcion` AS `funcion`,`dispositivo`.`estado` AS `estado`,`tipo_dispositivo`.`nombre` AS `ntipo`,`empresa`.`nombre` AS `nempresa`,`instalacion`.`nombre` AS `ninstalacion` from (((`dispositivo` join `tipo_dispositivo` on((`tipo_dispositivo`.`tipo_id` = `dispositivo`.`tipo_id`))) join `instalacion` on((`instalacion`.`instalacion_id` = `dispositivo`.`instalacion_id`))) join `empresa` on((`empresa`.`empresa_id` = `instalacion`.`empresa_id`))) where (`dispositivo`.`estado` = 'A')) */;

/*View structure for view v_revisiones */

/*!50001 DROP TABLE IF EXISTS `v_revisiones` */;
/*!50001 DROP VIEW IF EXISTS `v_revisiones` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_revisiones` AS (select `r`.`revision_id` AS `id`,`r`.`fecha_revision` AS `fecha`,`d`.`nombre` AS `dispositivo`,`i`.`nombre` AS `instalacion`,`r`.`resultado` AS `resultado`,`r`.`estado` AS `estado`,`ta`.`nombre` AS `anomalia` from (((`revision` `r` left join `dispositivo` `d` on((`d`.`dispositivo_id` = `r`.`dispositivo_id`))) left join `tipo_anomalia` `ta` on((`ta`.`tipo_anomalia_id` = `r`.`tipo_anomalia_id`))) left join `instalacion` `i` on((`i`.`instalacion_id` = `d`.`instalacion_id`)))) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
