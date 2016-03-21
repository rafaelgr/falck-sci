SELECT * FROM empresa;

SELECT * FROM revisiones WHERE dispositivo_id IN (
SELECT dispositivo_id FROM dispositivo WHERE instalacion_id IN
(SELECT instalacion_id FROM instalacion WHERE empresa_id = 24));

CREATE TABLE tmp_dispositivo_empresa
SELECT * FROM dispositivo WHERE instalacion_id IN
(SELECT instalacion_id FROM instalacion WHERE empresa_id = 24);
CREATE TABLE tmp_revisiones
SELECT * FROM revision WHERE dispositivo_id IN (SELECT dispositivo_id FROM tmp_dispositivo_empresa);

DELETE FROM datos_revision
WHERE revision_id IN (SELECT revision_id FROM tmp_revisiones);
DELETE FROM revision
WHERE revision_id IN (SELECT revision_id FROM tmp_revisiones);
DELETE FROM programa
WHERE programa_id IN (SELECT programa_id FROM tmp_revisiones);

DELETE FROM sustitucion
WHERE `dispositivo_dispositivo_id` IN (SELECT dispositivo_id FROM `tmp_dispositivo_empresa`)
OR `dispositivo1_dispositivo_id` IN (SELECT dispositivo_id FROM `tmp_dispositivo_empresa`);

DELETE FROM resumen_revision
WHERE dispositivo_id IN (SELECT dispositivo_id FROM tmp_dispositivo_empresa);

DELETE FROM dispositivo WHERE dispositivo_id IN
(SELECT dispositivo_id FROM `tmp_dispositivo_empresa`);

DELETE FROM modelo_dispositivo WHERE tipo_id IN
(SELECT tipo_id FROM tipo_dispositivo WHERE empresa_id = 24);

DELETE FROM campo WHERE plantilla_id IN (SELECT plantilla_id FROM plantilla_revision WHERE tipo_id IN
(SELECT tipo_id FROM tipo_dispositivo WHERE empresa_id = 24));

DELETE FROM plantilla_revision WHERE tipo_id IN
(SELECT tipo_id FROM tipo_dispositivo WHERE empresa_id = 24);

DELETE FROM plantilla_revision WHERE tipo_id IN
(SELECT tipo_id FROM tipo_dispositivo WHERE empresa_id = 24);

DELETE FROM tipo_dispositivo WHERE empresa_id = 24;



