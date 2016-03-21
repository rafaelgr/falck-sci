-- Seleccionar la base de datos con la que trabajar.
USE falck_sci;

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