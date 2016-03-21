/*
SQLyog Community Edition- MySQL GUI v8.03 
MySQL - 5.0.45-community-nt : Database - sci_dosimetria
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

USE `sci_dosimetria`;

/*Table structure for table `grupo_usuario` */

DROP TABLE IF EXISTS `grupo_usuario`;

CREATE TABLE `grupo_usuario` (
  `nombre` varchar(255) default NULL,
  `grupo_usuario_id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`grupo_usuario_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `grupo_usuario` */

insert  into `grupo_usuario`(`nombre`,`grupo_usuario_id`) values ('Administradores',1);
insert  into `grupo_usuario`(`nombre`,`grupo_usuario_id`) values ('Usuarios',2);

/*Table structure for table `permiso` */

DROP TABLE IF EXISTS `permiso`;

CREATE TABLE `permiso` (
  `ver` bit(1) NOT NULL,
  `permiso_id` int(11) NOT NULL auto_increment,
  `nombre` varchar(255) default NULL,
  `modificar` bit(1) NOT NULL,
  `grupo_usuario_id` int(11) default NULL,
  `especial` bit(1) NOT NULL,
  `crear` bit(1) NOT NULL,
  PRIMARY KEY  (`permiso_id`),
  KEY `idx_permiso_grupo_usuario_id` (`grupo_usuario_id`),
  KEY `ref_permiso_proceso` (`nombre`),
  CONSTRAINT `ref_permiso_grupo_usuario` FOREIGN KEY (`grupo_usuario_id`) REFERENCES `grupo_usuario` (`grupo_usuario_id`),
  CONSTRAINT `ref_permiso_proceso` FOREIGN KEY (`nombre`) REFERENCES `proceso` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=latin1;

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
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',20,'dispositivoGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',21,'TipoGrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',22,'TipoGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',23,'ModeloGrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',24,'ModeloGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',25,'AccesorioGrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',26,'AccesorioGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',27,'PlantillaRevisionGrid','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',28,'PlantillaRevisionGrid','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',29,'DatosDispositivos','',1,'','');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('',30,'DatosDispositivos','\0',2,'\0','\0');
insert  into `permiso`(`ver`,`permiso_id`,`nombre`,`modificar`,`grupo_usuario_id`,`especial`,`crear`) values ('\0',31,'DatosPlantillas','',1,'','');
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

/*Table structure for table `proceso` */

DROP TABLE IF EXISTS `proceso`;

CREATE TABLE `proceso` (
  `proceso_padre_nombre` varchar(255) default NULL,
  `nombre` varchar(255) NOT NULL,
  `descripcion` varchar(255) default NULL,
  PRIMARY KEY  (`nombre`),
  KEY `idx_proceso_proceso_padre_nombre` (`proceso_padre_nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `proceso` */

insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosDispositivos','AccesorioGrid','Lista de accesorios aplicables a dispositivos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'administracion','Menú Administracion');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosDispositivos','AgenteExtintorGrid','Lista con los agentes de extinción disponibles');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosPlantillas','CampoGrid','Lista de campos registrados');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'datos','Datos del sistema');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','DatosDispositivos','Agrupa todos los datos referidos a los dispositivos.');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','DatosPlantillas','Agrupa todos los datos referidos a las plantillas');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosDispositivos','dispositivoGrid','Lista de dispositivos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','EmpresaGrid','Lista de empresas');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosDispositivos','FabricanteGrid','Lista de los fabricantes de dispositivos.');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('administracion','grupousuariogrid','Grupos de usuarios');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','InstalacionGrid','Instalaciones');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosDispositivos','ModeloGrid','Lista de los modelos de dispositivos.');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','OperarioGrid','Operarios');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('administracion','permisogrid','Permisos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('datos','PlantillaRevisionGrid','Lista de plantillas de revisión');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('administracion','procesogrid','Procesos');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('Revisiones','ProgramarGrid','Programar revisiones');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values (NULL,'Revisiones','Gestión de revisiones');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosPlantillas','TipoCampoGrid','Lista de tipos de campo posibles');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('DatosDispositivos','TipoGrid','Lista de los tipos de dispositivos.');
insert  into `proceso`(`proceso_padre_nombre`,`nombre`,`descripcion`) values ('administracion','usuariogrid','Usuarios');

/*Table structure for table `usuario` */

DROP TABLE IF EXISTS `usuario`;

CREATE TABLE `usuario` (
  `usuario_id` int(11) NOT NULL auto_increment,
  `passwd` varchar(255) default NULL,
  `nombre` varchar(255) default NULL,
  `login` varchar(255) default NULL,
  `grupo_usuario_id` int(11) NOT NULL,
  PRIMARY KEY  (`usuario_id`),
  KEY `idx_usuario_grupo_usuario_id` (`grupo_usuario_id`),
  CONSTRAINT `ref_usuario_grupo_usuario` FOREIGN KEY (`grupo_usuario_id`) REFERENCES `grupo_usuario` (`grupo_usuario_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `usuario` */

insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`) values (1,'21232F297A57A5A743894A0E4A801F','Administrador','admin',1);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`) values (2,'35CD2D0D62D9BC5E60A3CA9F7593B0','Rafael Garcia','rafa',2);
insert  into `usuario`(`usuario_id`,`passwd`,`nombre`,`login`,`grupo_usuario_id`) values (3,'A14F8A540E78DAE706D255750010A0','Javier Sanchez','javi',2);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
