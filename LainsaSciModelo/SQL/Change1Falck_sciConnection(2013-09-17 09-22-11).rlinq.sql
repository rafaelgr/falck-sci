-- Column was read from database as: `fecha_baja` datetime null
-- modify column for field _fechaBaja
UPDATE `dispositivo`
   SET `fecha_baja` = ' '
 WHERE `fecha_baja` IS NULL
;

ALTER TABLE `dispositivo` CHANGE COLUMN `fecha_baja` `fecha_baja` datetime NOT NULL
;

-- Column was read from database as: `fecha_apertura` datetime null
-- modify column for field _fechaApertura
UPDATE `incidencia`
   SET `fecha_apertura` = ' '
 WHERE `fecha_apertura` IS NULL
;

ALTER TABLE `incidencia` CHANGE COLUMN `fecha_apertura` `fecha_apertura` datetime NOT NULL
;

-- add column for field _operativo
ALTER TABLE `incidencia_evolucion` ADD COLUMN `operativo` bit(1) NULL
;

UPDATE `incidencia_evolucion` SET `operativo` = 0
;

ALTER TABLE `incidencia_evolucion` CHANGE COLUMN `operativo` `operativo` bit(1) NOT NULL
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

ALTER TABLE `incidencia_evolucion` ADD CONSTRAINT `ref_incidencia_evolucion_incidencia` FOREIGN KEY `ref_incidencia_evolucion_incidencia` (`incidencia_id`) REFERENCES `incidencia` (`incidencia_id`)
;

ALTER TABLE `incidencia_evolucion` ADD CONSTRAINT `ref_incidencia_evolucion_usuario` FOREIGN KEY `ref_incidencia_evolucion_usuario` (`usuario_id`) REFERENCES `usuario` (`usuario_id`)
;

-- Index 'idx_incidencia_evolucion_usuario_id' was not detected in the database. It will be created
ALTER TABLE `incidencia_evolucion` ADD INDEX `idx_incidencia_evolucion_usuario_id`(`usuario_id`)
;

-- Index 'idx_incidencia_evolucion_incidencia_id' was not detected in the database. It will be created
ALTER TABLE `incidencia_evolucion` ADD INDEX `idx_incidencia_evolucion_incidencia_id`(`incidencia_id`)
;

