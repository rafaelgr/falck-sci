DELETE FROM sustitucion;
DELETE FROM datos_revision;
DELETE FROM revision;
DELETE FROM programa;
DELETE FROM dispositivo;

DELETE FROM agente_extintor;
DELETE FROM fabricante;
DELETE FROM campo;
DELETE FROM plantilla_revision;
DELETE FROM tipo_dispositivo;
DELETE FROM modelo_dispositivo;
DELETE FROM resumen_revision;

# -- Borra empresa  instalaciones --
DELETE FROM direccion;
DELETE FROM email;
DELETE FROM telefono;
DELETE FROM usuario WHERE NOT (instalacion_id IS NULL);
DELETE FROM instalacion;
DELETE FROM usuario WHERE NOT (empresa_id IS NULL);
DELETE FROM empresa;


