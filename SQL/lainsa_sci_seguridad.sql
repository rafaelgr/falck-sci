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
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

/*Data for the table `agente_extintor` */

insert  into `agente_extintor`(`descripcion`,`agente_extintor_id`) values ('CO2',16);
insert  into `agente_extintor`(`descripcion`,`agente_extintor_id`) values ('Polvo Quimico Seco',17);

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
) ENGINE=InnoDB AUTO_INCREMENT=154 DEFAULT CHARSET=latin1;

/*Data for the table `campo` */

insert  into `campo`(`tipo_id`,`posicion`,`plantilla_id`,`nombre`,`campo_id`) values (1,1,71,'¿LA IDENTIFICACIÓN ES CORRECTA?',153);

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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `categoria` */

insert  into `categoria`(`categoria_id`,`nombre`) values (1,'Revisiones');
insert  into `categoria`(`categoria_id`,`nombre`) values (2,'Informes oficiales');
insert  into `categoria`(`categoria_id`,`nombre`) values (3,'Certificados');
insert  into `categoria`(`categoria_id`,`nombre`) values (4,'Actas industria');

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `datos_revision` */

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `direccion` */

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
  CONSTRAINT `ref_dispositivo_agente_extintor` FOREIGN KEY (`agente_extintor_id`) REFERENCES `agente_extintor` (`agente_extintor_id`),
  CONSTRAINT `ref_dispositivo_fabricante` FOREIGN KEY (`fabricante_id`) REFERENCES `fabricante` (`fabricante_id`),
  CONSTRAINT `ref_dispositivo_instalacion` FOREIGN KEY (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`),
  CONSTRAINT `ref_dispositivo_modelo_dispositivo` FOREIGN KEY (`modelo_id`) REFERENCES `modelo_dispositivo` (`modelo_id`),
  CONSTRAINT `ref_dispositivo_tipo_dispositivo` FOREIGN KEY (`tipo_id`) REFERENCES `tipo_dispositivo` (`tipo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=304 DEFAULT CHARSET=latin1;

/*Data for the table `dispositivo` */

insert  into `dispositivo`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (49,'',NULL,24,'0001-01-01 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',303,'','1122','',NULL,NULL,NULL,0,'0001-01-01 00:00:00','N','O','1122');

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `documento` */

insert  into `documento`(`categoria_id`,`comentarios`,`documento_id`,`empresa_id`,`extension`,`fecha`,`instalacion_id`,`nombre`,`subcategoria_id`) values (1,'Esto de verdad es....',1,24,'.pdf','0001-01-01 00:00:00',22,'Revision del hidrante 20122',2);

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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

/*Data for the table `email` */

insert  into `email`(`mail`,`instalacion_id`,`envio`,`empresa_id`,`email_id`,`descripcion`) values ('romerox@carburos.com',44,'',NULL,10,'');
insert  into `email`(`mail`,`instalacion_id`,`envio`,`empresa_id`,`email_id`,`descripcion`) values ('ICAREAGE@DOW.COM',24,'',NULL,11,'');
insert  into `email`(`mail`,`instalacion_id`,`envio`,`empresa_id`,`email_id`,`descripcion`) values ('mmforte@dow.com',41,'',NULL,12,'Mercedes Forte');
insert  into `email`(`mail`,`instalacion_id`,`envio`,`empresa_id`,`email_id`,`descripcion`) values ('rgarcia2@dow.com',42,'',NULL,13,'Rafael García');
insert  into `email`(`mail`,`instalacion_id`,`envio`,`empresa_id`,`email_id`,`descripcion`) values ('psanchez2@dow.com',24,'',NULL,14,'Patricia Sanchez');
insert  into `email`(`mail`,`instalacion_id`,`envio`,`empresa_id`,`email_id`,`descripcion`) values ('psanchez2@dow.com',41,'',NULL,15,'Patricia Sanchez');
insert  into `email`(`mail`,`instalacion_id`,`envio`,`empresa_id`,`email_id`,`descripcion`) values ('psanchez2@dow.com',42,'',NULL,16,'Patricia Sanchez');

/*Table structure for table `empresa` */

DROP TABLE IF EXISTS `empresa`;

CREATE TABLE `empresa` (
  `persona_contacto` varchar(255) DEFAULT NULL,
  `nombre` varchar(255) DEFAULT NULL,
  `empresa_id` int(11) NOT NULL AUTO_INCREMENT,
  `cod_ax` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`empresa_id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;

/*Data for the table `empresa` */

insert  into `empresa`(`persona_contacto`,`nombre`,`empresa_id`,`cod_ax`) values ('IVAN GIL BUENO','AEQT PARC QUIMIC NORD',24,'SCI0112');

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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

/*Data for the table `filtro` */

insert  into `filtro`(`expresion`,`filtro_id`,`nombre`,`tipo`) values ('AAEAAAD/////AQAAAAAAAAAQAQAAAAMAAAAKCQIAAAAJAwAAABACAAAAAgAAAAkEAAAACQUAAAAMBgAAAFhUZWxlcmlrLldlYi5VSSwgVmVyc2lvbj0yMDExLjMuMTExNS40MCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj0xMjFmYWU3ODE2NWJhM2Q0BQMAAAAmVGVsZXJpay5XZWIuVUkuUmFkRmlsdGVyR3JvdXBPcGVyYXRpb24BAAAAB3ZhbHVlX18ACAYAAAAAAAAADAcAAABNU3lzdGVtLldlYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFBAAAABJTeXN0ZW0uV2ViLlVJLlBhaXICAAAABUZpcnN0BlNlY29uZAICBwAAAAgIAQAAAAgIAAAAAAEFAAAABAAAAAkIAAAACQkAAAABCAAAAAQAAAAGCgAAACJSYWRGaWx0ZXJFcXVhbFRvRmlsdGVyRXhwcmVzc2lvbmAxBgsAAAANU3lzdGVtLlN0cmluZxAJAAAAAgAAAAkMAAAABg0AAAAGRXN0YWRvBAwAAAAcU3lzdGVtLkNvbGxlY3Rpb25zLkFycmF5TGlzdAMAAAAGX2l0ZW1zBV9zaXplCF92ZXJzaW9uBQAACAgJDgAAAAIAAAACAAAAEA4AAAAEAAAACQ8AAAAGEAAAAApQUk9HUkFNQURBDQIFDwAAABtTeXN0ZW0uV2ViLlVJLkluZGV4ZWRTdHJpbmcBAAAABl92YWx1ZQEHAAAABhEAAAAFVmFsdWUL',5,'REVISIONES PROGRAMADAS','Revision');
insert  into `filtro`(`expresion`,`filtro_id`,`nombre`,`tipo`) values ('AAEAAAD/////AQAAAAAAAAAQAQAAAAMAAAAKCQIAAAAJAwAAABACAAAAAgAAAAkEAAAACQUAAAAMBgAAAFhUZWxlcmlrLldlYi5VSSwgVmVyc2lvbj0yMDExLjMuMTExNS40MCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj0xMjFmYWU3ODE2NWJhM2Q0BQMAAAAmVGVsZXJpay5XZWIuVUkuUmFkRmlsdGVyR3JvdXBPcGVyYXRpb24BAAAAB3ZhbHVlX18ACAYAAAAAAAAADAcAAABNU3lzdGVtLldlYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFBAAAABJTeXN0ZW0uV2ViLlVJLlBhaXICAAAABUZpcnN0BlNlY29uZAICBwAAAAgIAQAAAAgIAAAAAAEFAAAABAAAAAkIAAAACQkAAAABCAAAAAQAAAAGCgAAACJSYWRGaWx0ZXJFcXVhbFRvRmlsdGVyRXhwcmVzc2lvbmAxBgsAAAANU3lzdGVtLlN0cmluZxAJAAAAAgAAAAkMAAAABg0AAAAGRXN0YWRvBAwAAAAcU3lzdGVtLkNvbGxlY3Rpb25zLkFycmF5TGlzdAMAAAAGX2l0ZW1zBV9zaXplCF92ZXJzaW9uBQAACAgJDgAAAAIAAAACAAAAEA4AAAAEAAAACQ8AAAAGEAAAAApQUk9HUkFNQURBDQIFDwAAABtTeXN0ZW0uV2ViLlVJLkluZGV4ZWRTdHJpbmcBAAAABl92YWx1ZQEHAAAABhEAAAAFVmFsdWUL',6,'PLANIFICADA','Revision');
insert  into `filtro`(`expresion`,`filtro_id`,`nombre`,`tipo`) values ('AAEAAAD/////AQAAAAAAAAAQAQAAAAMAAAAKCQIAAAAJAwAAABACAAAAAgAAAAkEAAAACQUAAAAMBgAAAFhUZWxlcmlrLldlYi5VSSwgVmVyc2lvbj0yMDExLjMuMTExNS40MCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj0xMjFmYWU3ODE2NWJhM2Q0BQMAAAAmVGVsZXJpay5XZWIuVUkuUmFkRmlsdGVyR3JvdXBPcGVyYXRpb24BAAAAB3ZhbHVlX18ACAYAAAAAAAAADAcAAABNU3lzdGVtLldlYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFBAAAABJTeXN0ZW0uV2ViLlVJLlBhaXICAAAABUZpcnN0BlNlY29uZAICBwAAAAgIAQAAAAgIAAAAAAEFAAAABAAAAAkIAAAACQkAAAABCAAAAAQAAAAGCgAAACJSYWRGaWx0ZXJFcXVhbFRvRmlsdGVyRXhwcmVzc2lvbmAxBgsAAAANU3lzdGVtLlN0cmluZxAJAAAAAgAAAAkMAAAABg0AAAAGRXN0YWRvBAwAAAAcU3lzdGVtLkNvbGxlY3Rpb25zLkFycmF5TGlzdAMAAAAGX2l0ZW1zBV9zaXplCF92ZXJzaW9uBQAACAgJDgAAAAIAAAACAAAAEA4AAAAEAAAACQ8AAAAGEAAAAAlSRUFMSVpBREENAgUPAAAAG1N5c3RlbS5XZWIuVUkuSW5kZXhlZFN0cmluZwEAAAAGX3ZhbHVlAQcAAAAGEQAAAAVWYWx1ZQs=',7,'REALIZADA','Revision');
insert  into `filtro`(`expresion`,`filtro_id`,`nombre`,`tipo`) values ('AAEAAAD/////AQAAAAAAAAAQAQAAAAMAAAAKCQIAAAAJAwAAABACAAAAAgAAAAkEAAAACQUAAAAMBgAAAFhUZWxlcmlrLldlYi5VSSwgVmVyc2lvbj0yMDExLjMuMTExNS40MCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj0xMjFmYWU3ODE2NWJhM2Q0BQMAAAAmVGVsZXJpay5XZWIuVUkuUmFkRmlsdGVyR3JvdXBPcGVyYXRpb24BAAAAB3ZhbHVlX18ACAYAAAAAAAAADAcAAABNU3lzdGVtLldlYiwgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFBAAAABJTeXN0ZW0uV2ViLlVJLlBhaXICAAAABUZpcnN0BlNlY29uZAICBwAAAAgIAQAAAAgIAAAAAAEFAAAABAAAAAkIAAAACQkAAAABCAAAAAQAAAAGCgAAABhSYWRGaWx0ZXJHcm91cEV4cHJlc3Npb24GCwAAAAAQCQAAAAMAAAAKCQwAAAAJDQAAABAMAAAAAwAAAAkOAAAACQ8AAAAJEAAAAAENAAAAAwAAAAAAAAABDgAAAAQAAAAICAIAAAAICAAAAAABDwAAAAQAAAAJEQAAAAkSAAAAARAAAAAEAAAACRMAAAAJFAAAAAERAAAABAAAAAYVAAAAIVJhZEZpbHRlckNvbnRhaW5zRmlsdGVyRXhwcmVzc2lvbgYWAAAADVN5c3RlbS5TdHJpbmcQEgAAAAIAAAAJFwAAAAYYAAAAEkluc3RhbGFjaW9uLk5vbWJyZQETAAAABAAAAAYZAAAAIlJhZEZpbHRlckVxdWFsVG9GaWx0ZXJFeHByZXNzaW9uYDEJFgAAABAUAAAAAgAAAAkbAAAABhwAAAAIUG9zaWNpb24EFwAAABxTeXN0ZW0uQ29sbGVjdGlvbnMuQXJyYXlMaXN0AwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24FAAAICAkdAAAAAgAAAAIAAAABGwAAABcAAAAJHgAAAAIAAAACAAAAEB0AAAAEAAAACR8AAAAGIAAAAAhwb2xpb2xlcw0CEB4AAAAEAAAACSEAAAAGIgAAAAtTVVNUSVRVSURPUw0CBR8AAAAbU3lzdGVtLldlYi5VSS5JbmRleGVkU3RyaW5nAQAAAAZfdmFsdWUBBwAAAAYjAAAABVZhbHVlASEAAAAfAAAACSMAAAAL',9,'Ext Polioles Sustiuidos','Dispositivo');

/*Table structure for table `grupo_mensajes` */

DROP TABLE IF EXISTS `grupo_mensajes`;

CREATE TABLE `grupo_mensajes` (
  `grupo_mensajes_id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`grupo_mensajes_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `grupo_mensajes` */

insert  into `grupo_mensajes`(`grupo_mensajes_id`,`nombre`) values (1,'Avisos urgentes');
insert  into `grupo_mensajes`(`grupo_mensajes_id`,`nombre`) values (2,'Información de cursos');

/*Table structure for table `grupo_usuario` */

DROP TABLE IF EXISTS `grupo_usuario`;

CREATE TABLE `grupo_usuario` (
  `nombre` varchar(255) DEFAULT NULL,
  `grupo_usuario_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`grupo_usuario_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Data for the table `grupo_usuario` */

insert  into `grupo_usuario`(`nombre`,`grupo_usuario_id`) values ('Administradores',1);
insert  into `grupo_usuario`(`nombre`,`grupo_usuario_id`) values ('Usuarios',2);
insert  into `grupo_usuario`(`nombre`,`grupo_usuario_id`) values ('Super usuario (new admin)',5);
insert  into `grupo_usuario`(`nombre`,`grupo_usuario_id`) values ('JEFE SERVICIO AEQT',7);
insert  into `grupo_usuario`(`nombre`,`grupo_usuario_id`) values ('ESPECIALISTAS CI AEQT',8);

/*Table structure for table `informe_programado` */

DROP TABLE IF EXISTS `informe_programado`;

CREATE TABLE `informe_programado` (
  `documento_id` int(11) DEFAULT NULL,
  `empresa_id` int(11) DEFAULT NULL,
  `fecha_final` datetime NOT NULL,
  `fecha_inicial` datetime NOT NULL,
  `informe_programado_id` int(11) NOT NULL AUTO_INCREMENT,
  `programacion_informe_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`informe_programado_id`),
  KEY `idx_informe_programado_documento_id` (`documento_id`),
  KEY `idx_informe_programado_empresa_id` (`empresa_id`),
  KEY `idx_informe_programado_programacion_informe_id` (`programacion_informe_id`),
  CONSTRAINT `ref_informe_programado_documento` FOREIGN KEY (`documento_id`) REFERENCES `documento` (`documento_id`),
  CONSTRAINT `ref_informe_programado_empresa` FOREIGN KEY (`empresa_id`) REFERENCES `empresa` (`empresa_id`),
  CONSTRAINT `ref_informe_programado_programacion_informe` FOREIGN KEY (`programacion_informe_id`) REFERENCES `programacion_informe` (`programacion_informe_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `informe_programado` */

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
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=latin1;

/*Data for the table `instalacion` */

insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA POLIOLES',22,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('DOW CRACKER',24,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('CARBUROS METALICOS HYCO',25,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('DOW CRACKER MTO',41,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('DOW CRACKER OCTENO',42,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('CARBUROS METALICOS LA POBLA',44,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('CARBUROS METALICOS MORELL',45,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('ESTACION DE RECARGA PARC NORD',49,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA BN',53,24,'');
insert  into `instalacion`(`nombre`,`instalacion_id`,`empresa_id`,`cod_ax`) values ('REPSOL QUIMICA PAD',54,24,'');

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

insert  into `mensaje`(`cuerpo`,`fecha_final`,`fecha_inicio`,`grupo_mensajes_id`,`mensaje_id`,`titulo`,`urgente`) values ('<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" style=\"width: 100%; background-color: white; border-collapse: collapse;\">\r\n    <tbody>\r\n        <tr>\r\n            <td colspan=\"2\" valign=\"top\" style=\"border:1pt solid #cccccc;width: 100%;     ','2012-03-10 00:00:00','2012-03-05 00:00:00',1,1,'La instalación comenzará el 9 de Marzo de 2012','\0');

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
  CONSTRAINT `ref_modelo_dispositivo_empresa` FOREIGN KEY (`empresa_id`) REFERENCES `empresa` (`empresa_id`),
  CONSTRAINT `ref_modelo_dispositivo_instalacion` FOREIGN KEY (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`),
  CONSTRAINT `ref_modelo_dispositivo_tipo_dispositivo` FOREIGN KEY (`tipo_id`) REFERENCES `tipo_dispositivo` (`tipo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=110 DEFAULT CHARSET=latin1;

/*Data for the table `modelo_dispositivo` */

insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('NC10',104,24,53,49);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('NC5',105,24,53,49);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('P12',106,24,53,49);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('P50',107,24,53,49);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('PI50',108,24,53,49);
insert  into `modelo_dispositivo`(`nombre`,`modelo_id`,`empresa_id`,`instalacion_id`,`tipo_id`) values ('PI9',109,24,53,49);

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
) ENGINE=InnoDB AUTO_INCREMENT=417 DEFAULT CHARSET=latin1;

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
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',300,'sustituciongrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',301,'sustituciongrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',302,'sustituciongrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',303,'sustituciongrid','',7,'\0','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',304,'sustituciongrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',307,'extranet','\0',1,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',308,'extranet','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',309,'extranet','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',310,'extranet','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',311,'extranet','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',314,'grupomensajesgrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',315,'grupomensajesgrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',316,'grupomensajesgrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',317,'grupomensajesgrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',318,'grupomensajesgrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',321,'mensajegrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',322,'mensajegrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',323,'mensajegrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',324,'mensajegrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',325,'mensajegrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',328,'categoria','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',329,'categoria','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',330,'categoria','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',331,'categoria','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',332,'categoria','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',335,'categoriagrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',336,'categoriagrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',337,'categoriagrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',338,'categoriagrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',339,'categoriagrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',342,'subcategoriagrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',343,'subcategoriagrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',344,'subcategoriagrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',345,'subcategoriagrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',346,'subcategoriagrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',349,'documentogrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',350,'documentogrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',351,'documentogrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',352,'documentogrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',353,'documentogrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',356,'usuarioextranetgrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',357,'usuarioextranetgrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',358,'usuarioextranetgrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',359,'usuarioextranetgrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',360,'usuarioextranetgrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',363,'repositoriotmpform','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',364,'repositoriotmpform','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',365,'repositoriotmpform','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',366,'repositoriotmpform','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',367,'repositoriotmpform','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',370,'tipoanomaliagrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',371,'tipoanomaliagrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',372,'tipoanomaliagrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',373,'tipoanomaliagrid','',7,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',374,'tipoanomaliagrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',377,'informes','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',378,'informes','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',379,'informes','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',380,'informes','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',381,'informes','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',384,'rptresumenempresainstalacion','',1,'\0','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',385,'rptresumenempresainstalacion','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',386,'rptresumenempresainstalacion','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',387,'rptresumenempresainstalacion','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',388,'rptresumenempresainstalacion','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',391,'rptfacturableempresainstalacion','\0',1,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',392,'rptfacturableempresainstalacion','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',393,'rptfacturableempresainstalacion','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',394,'rptfacturableempresainstalacion','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',395,'rptfacturableempresainstalacion','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',398,'programacion','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',399,'programacion','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',400,'programacion','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',401,'programacion','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',402,'programacion','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',405,'programacioninformegrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',406,'programacioninformegrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',407,'programacioninformegrid','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',408,'programacioninformegrid','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',409,'programacioninformegrid','\0',8,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',412,'programacionexe','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',413,'programacionexe','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',414,'programacionexe','\0',5,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',415,'programacionexe','\0',7,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',416,'programacionexe','\0',8,'\0','\0');

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
) ENGINE=InnoDB AUTO_INCREMENT=74 DEFAULT CHARSET=latin1;

/*Data for the table `plantilla_revision` */

insert  into `plantilla_revision`(`plantilla_id`,`descripcion`,`comentarios`,`tipo_periodo`,`tipo_id`,`numero_periodos`,`con_sustitucion`,`facturable`,`no_periodica`) values (71,'Trimestral','','M',49,3,0,0,0);
insert  into `plantilla_revision`(`plantilla_id`,`descripcion`,`comentarios`,`tipo_periodo`,`tipo_id`,`numero_periodos`,`con_sustitucion`,`facturable`,`no_periodica`) values (72,'Anual','','A',49,1,0,0,0);
insert  into `plantilla_revision`(`plantilla_id`,`descripcion`,`comentarios`,`tipo_periodo`,`tipo_id`,`numero_periodos`,`con_sustitucion`,`facturable`,`no_periodica`) values (73,'Quinquenal','','A',49,5,1,0,0);

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
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('extranet','categoria','Categorias de documentos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('extranet','categoriagrid','Categorías de documentos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('consultas','consultadispositivos','Consulta dispositivos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'consultarevisiones','Consulta de revisiones');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'consultas','Consultas (Punto de menu)');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'datos','Datos del sistema');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','DatosDispositivos','Agrupa todos los datos referidos a los dispositivos.');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','DatosPlantillas','Agrupa todos los datos referidos a las plantillas');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosDispositivos','dispositivoGrid','Lista de dispositivos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('extranet','documentogrid','Documentos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','EmpresaGrid','Lista de empresas');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'extranet','Administracion Extranet');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosDispositivos','FabricanteGrid','Lista de los fabricantes de dispositivos.');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('extranet','grupomensajesgrid','Grupos de mensajes');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('administracion','grupousuariogrid','Grupos de usuarios');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'informes','Informes');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','InstalacionGrid','Instalaciones');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('extranet','mensajegrid','Mensajes');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosDispositivos','ModeloGrid','Lista de los modelos de dispositivos.');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','OperarioGrid','Operarios');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('administracion','permisogrid','Permisos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','PlantillaRevisionGrid','Lista de plantillas de revisión');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('administracion','procesogrid','Procesos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('informes','programacion','Programacion');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('programacion','programacionexe','Ejecutar programacion');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('programacion','programacioninformegrid','Programacion de informes');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('Revisiones','programagrid','Programas de revisión');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('Revisiones','ProgramarGrid','Programar revisiones');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('extranet','repositoriotmpform','Repositorio temporal');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'Revisiones','Gestión de revisiones');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('Revisiones','revisiongrid','Revisiones');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('informes','rptfacturableempresainstalacion','Revisiones fcaturables');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('informes','rptresumenempresainstalacion','Resumen revisiones y anomalias');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('extranet','subcategoriagrid','Subcategorias de documentos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('Revisiones','sustituciongrid','Sustituciones de dispositivos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('windows','tile','Organizar sin solapar');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('Revisiones','tipoanomaliagrid','Tipos anomalia');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosPlantillas','TipoCampoGrid','Lista de tipos de campo posibles');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosDispositivos','TipoGrid','Lista de los tipos de dispositivos.');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('extranet','usuarioextranetgrid','Usuarios de extranet');
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `programa` */

/*Table structure for table `programacion_informe` */

DROP TABLE IF EXISTS `programacion_informe`;

CREATE TABLE `programacion_informe` (
  `fecha_inicial` datetime NOT NULL,
  `informe` varchar(255) DEFAULT NULL,
  `periodicidad` varchar(255) DEFAULT NULL,
  `programacion_informe_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`programacion_informe_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `programacion_informe` */

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `resumen_revision` */

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `revision` */

/*Table structure for table `subcategoria` */

DROP TABLE IF EXISTS `subcategoria`;

CREATE TABLE `subcategoria` (
  `categoria_id` int(11) DEFAULT NULL,
  `nombre` varchar(255) DEFAULT NULL,
  `subcategoria_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`subcategoria_id`),
  KEY `idx_subcategoria_categoria_id` (`categoria_id`),
  CONSTRAINT `ref_subcategoria_categoria` FOREIGN KEY (`categoria_id`) REFERENCES `categoria` (`categoria_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `subcategoria` */

insert  into `subcategoria`(`categoria_id`,`nombre`,`subcategoria_id`) values (1,'Revisiones de extintores',1);
insert  into `subcategoria`(`categoria_id`,`nombre`,`subcategoria_id`) values (1,'Revisiones de hidrantes',2);
insert  into `subcategoria`(`categoria_id`,`nombre`,`subcategoria_id`) values (3,'ISO 9001:2008',3);
insert  into `subcategoria`(`categoria_id`,`nombre`,`subcategoria_id`) values (3,'ISO 14001:2008',4);

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `sustitucion` */

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `telefono` */

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `terminal` */

/*Table structure for table `tipo_anomalia` */

DROP TABLE IF EXISTS `tipo_anomalia`;

CREATE TABLE `tipo_anomalia` (
  `nombre` varchar(255) DEFAULT NULL,
  `tipo_anomalia_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`tipo_anomalia_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Data for the table `tipo_anomalia` */

insert  into `tipo_anomalia`(`nombre`,`tipo_anomalia_id`) values ('NECESITA PH',5);
insert  into `tipo_anomalia`(`nombre`,`tipo_anomalia_id`) values ('BAJA ',6);
insert  into `tipo_anomalia`(`nombre`,`tipo_anomalia_id`) values ('NECESITA REPARACIÓN Y/O REPUESTO',7);
insert  into `tipo_anomalia`(`nombre`,`tipo_anomalia_id`) values ('RECIPIENTE VACÍO',8);

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
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=latin1;

/*Data for the table `tipo_dispositivo` */

insert  into `tipo_dispositivo`(`tipo_id`,`nombre`,`caduca`,`empresa_id`,`instalacion_id`) values (49,'EXTINTOR PARC NORD ',20,24,NULL);

/*Table structure for table `tmp_dispositivo_empresa` */

DROP TABLE IF EXISTS `tmp_dispositivo_empresa`;

CREATE TABLE `tmp_dispositivo_empresa` (
  `tipo_id` int(11) DEFAULT NULL,
  `posicion` varchar(255) DEFAULT NULL,
  `modelo_id` int(11) DEFAULT NULL,
  `instalacion_id` int(11) DEFAULT NULL,
  `fecha_inicio_revision` datetime NOT NULL,
  `fecha_fabricacion` datetime NOT NULL,
  `fecha_caducidad` datetime NOT NULL,
  `dispositivo_id` int(11) NOT NULL DEFAULT '0',
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
  `cod_barras` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tmp_dispositivo_empresa` */

insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',34,22,'0000-00-00 00:00:00','2003-09-30 00:00:00','2023-09-30 00:00:00',100,'SIN CARTEL NI SE¥ALIZACION','9','3070431',NULL,11,NULL,0,NULL,'S','R',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',34,22,'0000-00-00 00:00:00','2003-09-30 00:00:00','2023-09-30 00:00:00',101,'','79','3070435',NULL,11,NULL,0,NULL,'A','R',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL SUR DEL D-4115',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',102,'','80','169',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',103,'','81','100',NULL,11,NULL,0,NULL,'A','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL ESTE TALLER SEGURIDAD',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',104,'','83','104',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL SUR DP 13',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',105,'','84','123',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',106,'se cambia manguera','85','108',NULL,11,NULL,0,NULL,'A','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUR SALA RACK SE 17',35,22,'0000-00-00 00:00:00','2007-12-01 00:00:00','2027-12-01 00:00:00',107,'','86','719262',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',34,22,'0000-00-00 00:00:00','2001-03-30 00:00:00','2021-03-30 00:00:00',108,'','87','3035431',NULL,11,NULL,0,NULL,'A','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',31,22,'0000-00-00 00:00:00','1992-06-09 00:00:00','2012-06-09 00:00:00',109,'','143','261111',NULL,12,NULL,1,'2012-02-17 00:00:00','N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUB17 PLANTA BAJA',31,22,'0000-00-00 00:00:00','1999-06-30 00:00:00','2019-06-30 00:00:00',110,'','144','288587',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'ALMACEN SEGURIDAD (POLIOLES SUB 17)',31,22,'0000-00-00 00:00:00','1999-06-30 00:00:00','2019-06-30 00:00:00',111,'','145','284537',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'ALMACEN SEGURIDAD (POLIOLES SUB 17)',31,22,'0000-00-00 00:00:00','1999-06-30 00:00:00','2019-06-30 00:00:00',112,'','146','284510',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUB 17 1¦ PLANTA',31,22,'0000-00-00 00:00:00','1999-06-30 00:00:00','2019-06-30 00:00:00',113,'SIN CARTEL NI SE¥ALIZACION','147','284498',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 1¦ PLANTA',31,22,'0000-00-00 00:00:00','1999-06-30 00:00:00','2019-06-30 00:00:00',114,'SIN CARTEL NI SE¥ALIZACION','148','284564',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUB 17 1¦ PLANTA',31,22,'0000-00-00 00:00:00','1999-03-30 00:00:00','2019-03-30 00:00:00',115,'','149','261050',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUBESTACION 17',31,22,'0000-00-00 00:00:00','1999-03-30 00:00:00','2019-03-30 00:00:00',116,'','153','261086',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES DESCARGA DE OE AL N',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',117,'','183','125',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES DESCARGA DE OE AL O',34,22,'0000-00-00 00:00:00','2000-03-30 00:00:00','2020-03-30 00:00:00',118,'','184','1681483',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES DESCARGA DE OE AL SO',34,22,'0000-00-00 00:00:00','2000-03-30 00:00:00','2020-03-30 00:00:00',119,'se pone precinto','185','1681486',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES DESCARGA DE OE AL S',34,22,'0000-00-00 00:00:00','2000-03-30 00:00:00','2020-03-30 00:00:00',120,'','186','1681481',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE PUERTA ALM. MAT PRIMAS',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',121,'','187','10',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES PASILLO BOMBAS GLECERINA',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',122,'','188','28',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE CASETA OPERADORES',35,22,'0000-00-00 00:00:00','2004-10-30 00:00:00','2024-10-30 00:00:00',123,'Desplazado de su lugar por contenedores ','189','3650374',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE ESCALERA SUBESTACION',35,22,'0000-00-00 00:00:00','2004-10-30 00:00:00','2024-10-30 00:00:00',124,'sin cartel','190','3650368',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE PUERTA SALA RACK',35,22,'0000-00-00 00:00:00','2010-12-30 00:00:00','2030-12-30 00:00:00',125,'','191','5',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE TANQUE D-4150-M',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',126,'cartel descolorido','192','132',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE TANQUE D-4150-J',35,22,'0000-00-00 00:00:00','2010-01-01 00:00:00','2030-01-01 00:00:00',127,'','193','10',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES MURO ESTACION DE CARGA AL S',35,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',128,'','194','102',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES MURO ESTACION CARGA AL S',34,22,'0000-00-00 00:00:00','1999-03-30 00:00:00','2019-03-30 00:00:00',129,'','195','1670265',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES TRAFOS SUBESTAC 17',35,22,'0000-00-00 00:00:00','2010-09-30 00:00:00','2030-09-30 00:00:00',130,'cambio de manguera','197','14',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUBESTACION 17',35,22,'0000-00-00 00:00:00','2010-09-30 00:00:00','2030-09-30 00:00:00',131,'se  cambia manguera i se repone precinto','198','11',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALM MATERIAS PREIMAS',32,22,'0000-00-00 00:00:00','2008-03-30 00:00:00','2028-03-30 00:00:00',132,'','290','10080500',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE MURO ESTACION DE CARGA',32,22,'0000-00-00 00:00:00','2000-02-28 00:00:00','2020-02-28 00:00:00',133,'','291','38639',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE MURO ESTACION CARGA',32,22,'0000-00-00 00:00:00','2006-06-30 00:00:00','2026-06-30 00:00:00',134,'','292','S/N292',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE MURO ESTACION DE CARGA',32,22,'0000-00-00 00:00:00','2000-02-28 00:00:00','2020-02-28 00:00:00',135,'','293','34232',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUBESTACION 17 PLANTA BAJA',32,22,'0000-00-00 00:00:00','2000-01-30 00:00:00','2020-01-30 00:00:00',136,'','295','34245',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUB17',32,22,'0000-00-00 00:00:00','2000-02-28 00:00:00','2020-02-28 00:00:00',137,'','297','38803',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUB 17',32,22,'0000-00-00 00:00:00','2000-02-28 00:00:00','2020-02-28 00:00:00',138,'','298','38798',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUB 17 1¦PLANTA',32,22,'0000-00-00 00:00:00','2000-02-28 00:00:00','2020-02-28 00:00:00',139,'','299','38807',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUB 17 1¦ PLANTA',32,22,'0000-00-00 00:00:00','2000-02-28 00:00:00','2020-02-28 00:00:00',140,'','300','38648',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUB 17',32,22,'0000-00-00 00:00:00','2000-02-28 00:00:00','2020-02-28 00:00:00',141,'','314','38640',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUBESTACION 17 SOTANO',32,22,'0000-00-00 00:00:00','2000-02-28 00:00:00','2020-02-28 00:00:00',142,'','315','38654',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES SUBESTACION 17 PLANTA BAJA',32,22,'0000-00-00 00:00:00','2008-12-31 00:00:00','2028-12-31 00:00:00',143,'','510','10080181',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES TANQUES DE OE G4104 AL O',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',144,'','801','676',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES TANQUE DE OE ESCAL CUBETO',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',145,'','802','1358',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES TANQUE DE OE ESCAL CUBETO SO',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',146,'','803','1435',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES BOMBAS SG4127 AL NO',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',147,'','804','551',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES BOMBAS SG4127 AL SO',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',148,'','805','1600',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES TANQUE DE OP ESC CUBETO',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',149,'','806','1607',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES TANQUE DE OP ESC CUBETO',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',150,'','807','468',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES PUERTA ALMACEN AL SO',36,22,'0000-00-00 00:00:00','2010-06-30 00:00:00','2030-06-30 00:00:00',151,'','808','70',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES JUNTO BOMBA G4101',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',152,'','809','1431',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES JUNTO BOMBA G4110/A',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',153,'','810','382',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',154,'','811','1367',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES TRAS BOMBAS G4105',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',155,'','812','607',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES FRENTE BOMBA G4105',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',156,'','813','1532',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES JUNTO BOMBA G4117/A',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',157,'','814','1059',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES EXTERIOR SUBEST 17 AL O',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',158,'','815','1982',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 1¦ PLANTA EDIF AL N',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',159,'','816','1441',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 1¦ PLANTA EDIF AL S',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',160,'','817','1137',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 2¦ PLANTA EDIF AL N',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',161,'','818','627',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 2¦ PLANTA EDIF AL S',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',162,'','819','1095',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 2¦ PLANTA EDIF AL N',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',163,'','820','1',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 2¦ PLANTA EDIF AL SE',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',164,'','821','531',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 3¦ PLANTA EDIF AL N',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',165,'','822','607',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 3¦ PLANTA EDIF AL S',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',166,'','823','596',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 3¦ PLANTA EDIF AL N',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',167,'','824','1007',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 3¦ PLANTA EDIF AL O',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',168,'','825','1046',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 4¦ PLANTA EDIF AL N',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',169,'','826','1090',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 4¦ PLANTA EDIF',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',170,'','827','223',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 4¦ PLANTA EDIF AL N',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',171,'','828','701',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 4¦ PLANTA EDIF AL S',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',172,'','829','1088',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 5¦ PLANTA EDIF AL N',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',173,'','830','1053',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES 5¦ PLANTA EDIF AL S',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',174,'','831','998',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA CUBETO ALMAC. AL E',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',175,'','832','242',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA CUBETO ALMAC. AL. E.',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',176,'sin cartel','833','SN',NULL,11,NULL,1,'2012-02-16 00:00:00','N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA CUBETO D 4150/L',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',177,'','834','1425',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA CUBETO D4150/C',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',178,'','835','820',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA CUBETO D4150/C',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',179,'','836','340',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA CUBETO AL O',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',180,'','837','1133',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES CUBETO AL.O.',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',181,'sin cartel','838','1195',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL O DEL DEP-15',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',182,'','839','1747',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMACEN POLIMERICOS',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',183,'','840','657',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIMERICOS ULTIMA PLANTA',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',184,'no se encuentra','840','1877',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES PAS. BOMBAS ALMAC. POLIME.',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',185,'','841','1727',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES PAS. BOMBAS ALMAC. POLIME.',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',186,'','842','1913',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMAC. POLIMERICOS AL NO',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',187,'','843','263',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMAC. POLIMERICOS AL NE',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',188,'cambio de manometro y precinto','844','1436',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMACEN MATERIAS PRIMAS',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',189,'','847','756',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMACEN MATERIAS PRIMAS',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',190,'','848','699',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMACEN MATERIAS PRIMAS',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',191,'','849','141',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMAC. MATERIAS PRIMAS',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',192,'','850','1060',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMACEN MATERIAS PRIMAS',36,22,'0000-00-00 00:00:00','2010-12-31 00:00:00','2030-12-31 00:00:00',193,'','851','545',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ALMACEN MATERIAS PRIMAS',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',194,'','851','1731',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL SUR DE LOS F-4204/A/B',36,22,'0000-00-00 00:00:00','2011-03-31 00:00:00','2031-03-31 00:00:00',195,'','859','14041963',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ENTRE G4281/A/B',36,22,'0000-00-00 00:00:00','2007-12-31 00:00:00','2027-12-31 00:00:00',196,'','860','728198',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL ESTE DE G-4251/B',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',197,'','861','128',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA ACCESO POLIMERICOS',36,22,'0000-00-00 00:00:00','2000-03-12 00:00:00','2020-03-12 00:00:00',198,'','862','2292088',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL NORTE DEL D 4285',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',199,'','863','128',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL OESTE D4226',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',200,'cartel descolorido','864','1722',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL O DEL SP 4280',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',201,'se repone precinto','865','29',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL S DP13',36,22,'0000-00-00 00:00:00','2011-03-31 00:00:00','2031-03-31 00:00:00',202,'','866','1046961',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES CUBETO ACCESO S COS D4220/21',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',203,'','867','316',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ACCESO SUR CUBETO D4225',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',204,'','868','1722',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES  ACCESO AL CUBETO N D4223',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',205,'','869','83',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA ELEV 6',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',206,'','870','35',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES CENTRO ELEV 6',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',207,'','871','1954',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 6 AL E',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',208,'','872','1759',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA ELEV 10',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',209,'','873','1555',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES CENTRO ELEV 10',36,22,'0000-00-00 00:00:00','2007-12-31 00:00:00','2027-12-31 00:00:00',210,'','874','728204',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL ESTE ELEV 10',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',211,'','875','952',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA ELEV 14',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',212,'','876','1949',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES CENTRO ELEV 14',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',213,'','877','723',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL ESTE ELV 14',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',214,'','878','135',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA ELEV 38',36,22,'0000-00-00 00:00:00','2007-12-31 00:00:00','2027-12-31 00:00:00',215,'','879','728207',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES CENTRO ELV 18',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',216,'','880','640',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES AL ESTE ELEV 18',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',217,'','881','55',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ESCALERA ELEV 22',36,22,'0000-00-00 00:00:00','2007-12-31 00:00:00','2027-12-31 00:00:00',218,'','882','728211',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 22 TOLVAS SOLIDOS',36,22,'0000-00-00 00:00:00','2011-03-31 00:00:00','2031-03-31 00:00:00',219,'','883','1041959',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 22 AL SE',36,22,'0000-00-00 00:00:00','2007-12-31 00:00:00','2027-12-31 00:00:00',220,'','884','728113',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 26 AL SE',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',221,'se repone precinto','885','762',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 26 AL E',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',222,'se cambia manometro','886','1641',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 30 AL N',36,22,'0000-00-00 00:00:00','2007-12-31 00:00:00','2027-12-31 00:00:00',223,'se cambia manometro','887','728206',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 30 AL S',36,22,'0000-00-00 00:00:00','2008-09-30 00:00:00','2028-09-30 00:00:00',224,'','888','425',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 34',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',225,'','889','195',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ACCESO N CUBETO D4251/A/B',36,22,'0000-00-00 00:00:00','2008-12-31 00:00:00','2028-12-31 00:00:00',226,'','890','1857',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'POLIOLES ELEV 38',36,22,'0000-00-00 00:00:00','2011-06-30 00:00:00','2031-06-30 00:00:00',227,'','891','956',NULL,11,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUBESTACION 17 PLANTA BAJA JUNTO 144',31,22,'0000-00-00 00:00:00','2008-12-30 00:00:00','2028-12-30 00:00:00',228,'','S/N','308106',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUBESTACION 17 PLANTA BAJA JUNTO 144',31,22,'0000-00-00 00:00:00','1997-02-28 00:00:00','2017-02-28 00:00:00',229,'','S/N','502476',NULL,12,NULL,0,NULL,'N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'',38,22,'0001-01-01 00:00:00','1992-01-06 00:00:00','2012-01-06 00:00:00',233,'','11111111','11111111',NULL,11,NULL,1,'2012-01-23 00:00:00','N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',38,22,'0001-01-01 00:00:00','2003-10-08 00:00:00','2023-10-08 00:00:00',234,'','22222','2222',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'',43,22,'0001-01-01 00:00:00','2012-01-16 00:00:00','2032-01-16 00:00:00',236,'','2222-1','2222-1',NULL,13,234,0,'0001-01-01 00:00:00','N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'',34,22,'0001-01-01 00:00:00','1992-02-28 00:00:00','2012-02-28 00:00:00',275,'','130','130',NULL,11,NULL,1,'2012-02-08 00:00:00','N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'',35,22,'0001-01-01 00:00:00','2007-02-15 00:00:00','2027-02-15 00:00:00',276,'','131','131',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'',46,22,'0001-01-01 00:00:00','2002-02-12 00:00:00','2022-02-12 00:00:00',277,'','132','132',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'',33,22,'0001-01-01 00:00:00','1992-02-12 00:00:00','2012-02-12 00:00:00',279,'','133','133',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'',38,22,'0001-01-01 00:00:00','1992-02-12 00:00:00','2012-02-12 00:00:00',283,'','211','211',NULL,11,NULL,1,'2012-02-01 00:00:00','N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',34,24,'0001-01-01 00:00:00','2007-02-12 00:00:00','2027-02-12 00:00:00',288,'','300','300',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (34,'SUSTITUIDOS',34,24,'0001-01-01 00:00:00','2007-02-27 00:00:00','2027-02-27 00:00:00',289,'','301','301',NULL,11,NULL,0,'0001-01-01 00:00:00','A','O',' ');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (43,'U654',66,48,'0001-01-01 00:00:00','2012-03-02 00:00:00','2022-03-02 00:00:00',290,'NUEVO','22','11111111111',NULL,11,NULL,0,'0001-01-01 00:00:00','N','O','9');
insert  into `tmp_dispositivo_empresa`(`tipo_id`,`posicion`,`modelo_id`,`instalacion_id`,`fecha_inicio_revision`,`fecha_fabricacion`,`fecha_caducidad`,`dispositivo_id`,`comentarios`,`nombre`,`numero_industria`,`fabricante_id`,`agente_extintor_id`,`dispositivo_padre_id`,`caducado`,`fecha_baja`,`estado`,`funcion`,`cod_barras`) values (44,'AQUI',68,48,'0001-01-01 00:00:00','2012-03-07 00:00:00','2032-03-07 00:00:00',291,'','567','222223',NULL,13,NULL,0,'0001-01-01 00:00:00','N','O','098876');

/*Table structure for table `tmp_revisiones` */

DROP TABLE IF EXISTS `tmp_revisiones`;

CREATE TABLE `tmp_revisiones` (
  `usuario_id` int(11) DEFAULT NULL,
  `revision_id` int(11) NOT NULL DEFAULT '0',
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
  `tipo_anomalia_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tmp_revisiones` */

insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,306,'ok','','2012-02-03 00:00:00','REALIZADA','0001-01-01 00:00:00',45,'2013-01-07 00:00:00',233,NULL,1,'',0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,315,'okk','','2012-02-02 00:00:00','PLANIFICADA','2012-02-25 00:00:00',42,'2012-04-24 00:00:00',234,NULL,0,'PESO DEL EXTINTOR: |<br/>',0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,316,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-25 00:00:00',44,'2012-03-22 00:00:00',234,120,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,317,'Perfecto','','2012-02-16 00:00:00','REALIZADA','2012-02-16 00:00:00',45,'2013-11-25 00:00:00',234,121,0,'',0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,364,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',42,'2012-05-02 00:00:00',234,NULL,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,388,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-08 00:00:00',42,'2012-02-15 00:00:00',275,NULL,1,NULL,7,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,389,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-08 00:00:00',44,'2012-02-15 00:00:00',275,NULL,1,NULL,7,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,390,'Baja','','2012-02-08 00:00:00','PROGRAMADA','2012-02-08 00:00:00',45,'2012-02-15 00:00:00',275,120,1,'',7,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,392,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-08 00:00:00',42,'2012-02-10 00:00:00',276,NULL,0,NULL,7,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,393,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',44,'2012-11-10 00:00:00',276,NULL,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,395,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-08 00:00:00',45,'2012-02-15 00:00:00',276,120,0,NULL,7,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,396,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-09 00:00:00',42,'2012-02-11 00:00:00',277,102,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,397,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-09 00:00:00',44,'2012-02-10 00:00:00',277,102,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,398,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-09 00:00:00',45,'2012-02-12 00:00:00',277,102,0,'',0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,442,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-02-09 00:00:00',42,'2012-02-10 00:00:00',279,NULL,0,NULL,4,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,443,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',44,'2012-05-10 00:00:00',279,NULL,0,NULL,5,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,444,'correcto','','2012-02-08 00:00:00','PROGRAMADA','2012-02-09 00:00:00',45,'2012-02-10 00:00:00',279,120,0,'',4,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,445,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',45,'2017-02-08 00:00:00',279,NULL,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,446,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',42,'2012-05-08 00:00:00',279,NULL,0,NULL,5,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,447,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',44,'2013-02-08 00:00:00',279,NULL,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,455,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',45,'2014-02-11 00:00:00',283,NULL,1,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,469,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','0001-01-01 00:00:00',42,'2001-04-01 00:00:00',100,120,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,477,'MAL','Mala sdfadsf','2012-03-06 00:00:00','REALIZADA','2012-03-26 00:00:00',42,'2001-04-01 00:00:00',103,131,0,'PESO DEL EXTINTOR: |<br/>',0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,478,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',45,'2017-02-16 00:00:00',234,NULL,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,479,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',42,'2012-05-16 00:00:00',234,NULL,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,480,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',44,'2013-02-16 00:00:00',234,NULL,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,485,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',45,'2017-02-16 00:00:00',234,NULL,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,486,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',42,'2012-05-16 00:00:00',234,NULL,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,487,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',44,'2013-02-16 00:00:00',234,NULL,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,500,'oooooooookkkkk','','2012-02-16 00:00:00','REALIZADA','2012-02-17 00:00:00',45,'2012-02-28 00:00:00',288,126,0,'',9,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,501,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',45,'2017-02-16 00:00:00',288,NULL,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,502,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',42,'2012-05-16 00:00:00',288,NULL,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,503,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',44,'2013-02-16 00:00:00',288,NULL,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (1,506,'oook','','2012-02-17 00:00:00','REALIZADA','2012-02-17 00:00:00',45,'2017-02-10 00:00:00',109,127,1,'',0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,507,NULL,NULL,'0001-01-01 00:00:00','PROGRAMADA','2012-03-26 00:00:00',42,'2012-03-30 00:00:00',101,131,0,'PESO DEL EXTINTOR: <br/>',0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,508,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',44,'2012-12-30 00:00:00',101,NULL,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,509,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',45,'2015-03-04 00:00:00',101,NULL,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,510,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',44,'2013-03-13 00:00:00',107,NULL,0,NULL,0,NULL);
insert  into `tmp_revisiones`(`usuario_id`,`revision_id`,`resultado`,`observaciones`,`fecha_revision`,`estado`,`fecha_programada`,`plantilla_id`,`fecha_planificada`,`dispositivo_id`,`programa_id`,`cadu_prox`,`resumen_informe`,`grupo_programacion`,`tipo_anomalia_id`) values (NULL,511,NULL,NULL,'0001-01-01 00:00:00','PLANIFICADA','0001-01-01 00:00:00',42,'2012-06-06 00:00:00',103,NULL,0,NULL,0,NULL);

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
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

/*Data for the table `usuario` */

insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (1,'21232F297A57A5A743894A0E4A801F','Administrador','admin',1,NULL,NULL);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (6,NULL,'Super usuario (new admin)','super',1,NULL,NULL);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (10,'81DC9BDB52D04DC20036DBD8313ED0','IVAN GIL BUENO','ivan',7,24,NULL);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (12,'81DC9BDB52D04DC20036DBD8313ED0','PQN EQUIPO A','PQNA',8,24,NULL);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (13,'495559A7854295EC51E5B3178EAC8F','PQN EQUIPO B','PQNB',8,24,NULL);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`,`empresa_id`,`instalacion_id`) values (14,'82EB39C65C8451DE26C08530F1CC42','PQN EQUIPO C','PQNC',8,24,NULL);

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `usuario_extranet` */

insert  into `usuario_extranet`(`correo`,`empresa_id`,`instalacion_id`,`login`,`nombre`,`passwd`,`plain_password`,`usuario_extranet_id`) values ('rafa@gmail.com',24,NULL,'rafa','Rafa Garcia','81DC9BDB52D04DC20036DBD8313ED0',NULL,1);

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

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
