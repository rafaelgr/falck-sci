-- Seleccionar la base de datos con la que trabajar.
USE falck_sci;

-- LainsaSciModelo.Prioridad
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