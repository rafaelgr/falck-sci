-- LainsaSciModelo.CargaTerminal
CREATE TABLE `carga_terminal` (
    `carga_terminal_id` integer AUTO_INCREMENT NOT NULL, -- _cargaTerminalId
    `fecha` datetime NOT NULL,              -- _fecha
    `fichero` varchar NULL,                 -- _fichero
    `observaciones` text NULL,              -- _observaciones
    `terminal_id` integer NULL,             -- _terminal
    CONSTRAINT `pk_carga_terminal` PRIMARY KEY (`carga_terminal_id`)
) ENGINE = InnoDB
;

-- Column was read from database as: `caducado` tinyint not null
-- modify column for field _caducado
ALTER TABLE `dispositivo` CHANGE COLUMN `caducado` `caducado` bit NOT NULL
;

-- Column was read from database as: `carga_kg` decimal(20,10) not null
-- modify column for field _cargaKg
ALTER TABLE `dispositivo` CHANGE COLUMN `carga_kg` `carga_kg` decimal(10,2) NOT NULL
;

-- Column was read from database as: `cod_barras` varchar(255) not null
-- modify column for field _codBarras
ALTER TABLE `dispositivo` CHANGE COLUMN `cod_barras` `cod_barras` varchar(255) NULL
;

-- Column was read from database as: `estado` varchar(255) not null
-- modify column for field _estado
ALTER TABLE `dispositivo` CHANGE COLUMN `estado` `estado` varchar(255) NULL
;

-- Column was read from database as: `fecha_baja` datetime null
-- modify column for field _fechaBaja
UPDATE `dispositivo`
   SET `fecha_baja` = ' '
 WHERE `fecha_baja` IS NULL
;

ALTER TABLE `dispositivo` CHANGE COLUMN `fecha_baja` `fecha_baja` datetime NOT NULL
;

-- Column was read from database as: `funcion` varchar(255) not null
-- modify column for field _funcion
ALTER TABLE `dispositivo` CHANGE COLUMN `funcion` `funcion` varchar(255) NULL
;

-- add column for field _fechaApertura
ALTER TABLE `incidencia` ADD COLUMN `fecha_apertura` datetime NULL
;

UPDATE `incidencia` SET `fecha_apertura` = ' '
;

ALTER TABLE `incidencia` CHANGE COLUMN `fecha_apertura` `fecha_apertura` datetime NOT NULL
;

-- add column for field _fechaCierre
ALTER TABLE `incidencia` ADD COLUMN `fecha_cierre` datetime NULL
;

-- dropping unknown column `fecha`
ALTER TABLE `incidencia` DROP COLUMN `fecha`
;

-- Column was read from database as: `carga_kg` decimal(20,10) not null
-- modify column for field _cargaKg
ALTER TABLE `modelo_dispositivo` CHANGE COLUMN `carga_kg` `carga_kg` decimal(10,2) NOT NULL
;

-- Column was read from database as: `con_sustitucion` tinyint not null
-- modify column for field _conSustitucion
ALTER TABLE `plantilla_revision` CHANGE COLUMN `con_sustitucion` `con_sustitucion` boolean NOT NULL
;

-- Column was read from database as: `facturable` tinyint not null
-- modify column for field _facturable
ALTER TABLE `plantilla_revision` CHANGE COLUMN `facturable` `facturable` boolean NOT NULL
;

-- Column was read from database as: `no_periodica` tinyint not null
-- modify column for field _noPeriodica
ALTER TABLE `plantilla_revision` CHANGE COLUMN `no_periodica` `no_periodica` boolean NOT NULL
;

-- Column was read from database as: `cadu_prox` tinyint not null
-- modify column for field _caduProx
ALTER TABLE `revision` CHANGE COLUMN `cadu_prox` `cadu_prox` boolean NOT NULL
;

ALTER TABLE `carga_terminal` ADD CONSTRAINT `ref_carga_terminal_terminal` FOREIGN KEY `ref_carga_terminal_terminal` (`terminal_id`) REFERENCES `terminal` (`terminal_id`)
;

ALTER TABLE `programa` ADD CONSTRAINT `ref_programa_carga_terminal` FOREIGN KEY `ref_programa_carga_terminal` (`carga_terminal_id`) REFERENCES `carga_terminal` (`carga_terminal_id`)
;

-- Index 'idx_carga_terminal_terminal_id' was not detected in the database. It will be created
ALTER TABLE `carga_terminal` ADD INDEX `idx_carga_terminal_terminal_id`(`terminal_id`)
;

