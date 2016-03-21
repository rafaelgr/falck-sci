ALTER TABLE `incidencia` CHANGE COLUMN `fecha` `fecha_apertura` datetime NOT NULL
;
-- add column for field _fechaCierre
ALTER TABLE `incidencia` ADD COLUMN `fecha_cierre` datetime NULL
;
-- LainsaSciModelo.IncidenciaEvolucion
CREATE TABLE `incidencia_evolucion` (
    `comentarios` varchar(255) NULL,        -- _comentarios
    `fecha_evolucion` datetime NOT NULL,    -- _fechaEvolucion
    `incidencia_id` integer NULL,           -- _incidencia
    `incidencia_evolucion_id` integer NOT NULL AUTO_INCREMENT, -- _incidenciaEvolucionId
    `usuario_id` integer NULL,              -- _usuario
    CONSTRAINT `pk_incidencia_evolucion` PRIMARY KEY (`incidencia_evolucion_id`)
) ENGINE = InnoDB
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
