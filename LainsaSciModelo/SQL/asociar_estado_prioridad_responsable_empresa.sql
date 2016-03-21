-- Crear la columna en la tabla
ALTER TABLE `estado` ADD `empresa_id` INT NULL;
-- Añadir el índice
ALTER TABLE `estado` ADD INDEX `idx_estado_empresa_id`(`empresa_id`);
-- Añadir la clave referencial.
ALTER TABLE `estado` ADD CONSTRAINT `ref_estado_empresa` FOREIGN KEY `ref_estado_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

-- Crear la columna en la tabla
ALTER TABLE `responsable` ADD `empresa_id` INT NULL;
-- Añadir el índice
ALTER TABLE `responsable` ADD INDEX `idx_responsable_empresa_id`(`empresa_id`);
-- Añadir la clave referencial.
ALTER TABLE `responsable` ADD CONSTRAINT `ref_responsable_empresa` FOREIGN KEY `ref_responsable_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

-- Crear la columna en la tabla
ALTER TABLE `prioridad` ADD `empresa_id` INT NULL;
-- Añadir el índice
ALTER TABLE `prioridad` ADD INDEX `idx_prioridad_empresa_id`(`empresa_id`);
-- Añadir la clave referencial.
ALTER TABLE `prioridad` ADD CONSTRAINT `ref_prioridad_empresa` FOREIGN KEY `ref_prioridad_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);