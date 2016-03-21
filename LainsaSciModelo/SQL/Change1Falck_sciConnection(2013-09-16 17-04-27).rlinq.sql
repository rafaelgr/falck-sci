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

-- LainsaSciModelo.IncidenciaEvolucion
CREATE TABLE `incidencia_evolucion` (
    `comentarios` varchar(255) NULL,        -- _comentarios
    `fecha_evolucion` datetime NOT NULL,    -- _fechaEvolucion
    `incidencia_id` integer NULL,           -- _incidencia
    `incidencia_evolucion_id` integer NOT NULL, -- _incidenciaEvolucionId
    `usuario_id` integer NULL,              -- _usuario
    CONSTRAINT `pk_incidencia_evolucion` PRIMARY KEY (`incidencia_evolucion_id`)
) ENGINE = InnoDB
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

-- Index 'idx_incidencia_evolucion_incidencia_id' was not detected in the database. It will be created
ALTER TABLE `incidencia_evolucion` ADD INDEX `idx_incidencia_evolucion_incidencia_id`(`incidencia_id`)
;

-- Index 'idx_incidencia_evolucion_usuario_id' was not detected in the database. It will be created
ALTER TABLE `incidencia_evolucion` ADD INDEX `idx_incidencia_evolucion_usuario_id`(`usuario_id`)
;

