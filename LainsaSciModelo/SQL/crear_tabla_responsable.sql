-- Seleccionar la base de datos con la que trabajar.
USE falck_sci;

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