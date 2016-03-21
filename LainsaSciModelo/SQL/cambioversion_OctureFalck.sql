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
-- Añadir la columna
ALTER TABLE `falck_sci`.`dispositivo` ADD COLUMN `sigue_plan` BIT(1) DEFAULT b'1' NOT NULL AFTER `operativo`;
-- LainsaSciModelo.Estado
CREATE TABLE `estado` (
    `nombre` varchar(255) NULL,             -- _nombre
    `estado_id` integer AUTO_INCREMENT NOT NULL, -- _estadoId
    `en_cierre` bit NOT NULL,               -- _enCierre
    `en_apertura` bit NOT NULL,             -- _enApertura
    CONSTRAINT `pk_estado` PRIMARY KEY (`estado_id`)
) ENGINE = InnoDB;

-- Referencia en la tabla de incidencias para llevar el estado
ALTER TABLE incidencia ADD estado_id integer;

-- Hacer que la referencia sea índice para mejorar búsquedas
ALTER TABLE `incidencia` ADD INDEX `idx_incidencia_estado_id`(`estado_id`);

-- Hañadir la clave refrencial
ALTER TABLE `incidencia` ADD CONSTRAINT `ref_incidencia_estado` FOREIGN KEY `ref_incidencia_estado` (`estado_id`) REFERENCES `estado` (`estado_id`);
CREATE TABLE `Prioridad` (
    `nombre` varchar(255) NULL,             -- _nombre
    `prioridad_id` integer AUTO_INCREMENT NOT NULL, -- _PrioridadId
    CONSTRAINT `pk_Prioridad` PRIMARY KEY (`prioridad_id`)
) ENGINE = InnoDB;

-- Referencia en la tabla de incidencias para llevar el Prioridad
ALTER TABLE incidencia ADD prioridad_id integer;

-- Hacer que la referencia sea índice para mejorar búsquedas
ALTER TABLE `incidencia` ADD INDEX `idx_incidencia_prioridad_id`(`prioridad_id`);

-- Hañadir la clave refrencial
ALTER TABLE `incidencia` ADD CONSTRAINT `ref_incidencia_prioridad` FOREIGN KEY `ref_incidencia_prioridad` (`prioridad_id`) REFERENCES `prioridad` (`prioridad_id`);
-- LainsaSciModelo.responsable
CREATE TABLE `responsable` (
    `nombre` varchar(255) NULL,             -- _nombre
    `responsable_id` integer AUTO_INCREMENT NOT NULL, -- _responsableId
    CONSTRAINT `pk_responsable` PRIMARY KEY (`responsable_id`)
) ENGINE = InnoDB;

-- Referencia en la tabla de incidencias para llevar el responsable
ALTER TABLE incidencia ADD responsable_id integer;

-- Hacer que la referencia sea índice para mejorar búsquedas
ALTER TABLE `incidencia` ADD INDEX `idx_incidencia_responsable_id`(`responsable_id`);

-- Hañadir la clave refrencial
ALTER TABLE `incidencia` ADD CONSTRAINT `ref_incidencia_responsable` FOREIGN KEY `ref_incidencia_responsable` (`responsable_id`) REFERENCES `responsable` (`responsable_id`);