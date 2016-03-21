ALTER TABLE `dispositivo` DROP FOREIGN KEY `ref_dispositivo_modelo_dispositivo`;
ALTER TABLE `dispositivo` DROP INDEX `ref_dispositivo_modelo_dispositivo`;

ALTER TABLE `dispositivo` DROP FOREIGN KEY `ref_dispositivo_tipo_dispositivo`;
ALTER TABLE `dispositivo` DROP INDEX `ref_dispositivo_tipo_dispositivo`;

ALTER TABLE `plantilla_revision` DROP FOREIGN KEY `ref_plantilla_revision_tipo_dispositivo`;
ALTER TABLE `plantilla_revision` DROP INDEX `ref_plantilla_revision_tipo_dispositivo`;

-- Column was read from database as: `modelo_id` INTEGER null
-- modify column for field _modeloDispositivo
ALTER TABLE `dispositivo` CHANGE COLUMN `modelo_id` `modelo_id` integer(11) NULL;

-- Column was read from database as: `tipo_id` INTEGER null
-- modify column for field _tipoDispositivo
ALTER TABLE `dispositivo` CHANGE COLUMN `tipo_id` `tipo_id` integer(11) NULL;

-- Column was read from database as: `modelo_id` INTEGER not null autoinc
-- modify column for field _modeloId
ALTER TABLE `modelo_dispositivo` CHANGE COLUMN `modelo_id` `modelo_id` integer(11) NOT NULL AUTO_INCREMENT;

-- Column was read from database as: `tipo_id` INTEGER null
-- modify column for field _tipoDispositivo
ALTER TABLE `plantilla_revision` CHANGE COLUMN `tipo_id` `tipo_id` integer(11) NULL;

-- Column was read from database as: `tipo_id` INTEGER not null autoinc
-- modify column for field _tipoId
ALTER TABLE `tipo_dispositivo` CHANGE COLUMN `tipo_id` `tipo_id` integer(11) NOT NULL AUTO_INCREMENT;

-- add column for field _empresa
ALTER TABLE `usuario` ADD COLUMN `empresa_id` INTEGER NULL;

-- add column for field _instalacion
ALTER TABLE `usuario` ADD COLUMN `instalacion_id` integer NULL;

ALTER TABLE `usuario` ADD INDEX `idx_usuario_empresa_id`(`empresa_id`);

ALTER TABLE `usuario` ADD INDEX `idx_usuario_instalacion_id`(`instalacion_id`);

ALTER TABLE `dispositivo` ADD CONSTRAINT `ref_dispositivo_modelo_dispositivo` FOREIGN KEY `ref_dispositivo_modelo_dispositivo` (`modelo_id`) REFERENCES `modelo_dispositivo` (`modelo_id`);

ALTER TABLE `dispositivo` ADD CONSTRAINT `ref_dispositivo_tipo_dispositivo` FOREIGN KEY `ref_dispositivo_tipo_dispositivo` (`tipo_id`) REFERENCES `tipo_dispositivo` (`tipo_id`);

ALTER TABLE `plantilla_revision` ADD CONSTRAINT `ref_plantilla_revision_tipo_dispositivo` FOREIGN KEY `ref_plantilla_revision_tipo_dispositivo` (`tipo_id`) REFERENCES `tipo_dispositivo` (`tipo_id`);

ALTER TABLE `usuario` ADD CONSTRAINT `ref_usuario_empresa` FOREIGN KEY `ref_usuario_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

ALTER TABLE `usuario` ADD CONSTRAINT `ref_usuario_instalacion` FOREIGN KEY `ref_usuario_instalacion` (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`);

