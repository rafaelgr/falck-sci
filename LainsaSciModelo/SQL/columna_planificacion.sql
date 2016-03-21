-- Seleccionar la base de datos con la que trabajar.
USE falck_sci;

-- Añadir la columna
ALTER TABLE `falck_sci`.`dispositivo` ADD COLUMN `sigue_plan` BIT(1) DEFAULT b'1' NOT NULL AFTER `operativo`;