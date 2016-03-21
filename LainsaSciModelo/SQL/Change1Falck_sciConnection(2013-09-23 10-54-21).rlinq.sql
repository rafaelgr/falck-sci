-- LainsaSciModelo.AgenteExtintor
CREATE TABLE `agente_extintor` (
    `descripcion` varchar(255) NULL,        -- _descripcion
    `agente_extintor_id` integer AUTO_INCREMENT NOT NULL, -- _agenteExtintorId
    CONSTRAINT `pk_agente_extintor` PRIMARY KEY (`agente_extintor_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Campo
CREATE TABLE `campo` (
    `tipo_id` integer NULL,                 -- _tipoCampo
    `posicion` integer NOT NULL,            -- _posicion
    `plantilla_id` integer NULL,            -- _plantillaRevision1
    `nombre` varchar(255) NULL,             -- _nombre
    `informa_de` varchar(255) NULL,         -- _informaDe
    `campo_id` integer AUTO_INCREMENT NOT NULL, -- _campoId
    CONSTRAINT `pk_campo` PRIMARY KEY (`campo_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.CargaTerminal
CREATE TABLE `carga_terminal` (
    `terminal_id` integer NULL,             -- _terminal
    `observaciones` text NULL,              -- _observaciones
    `fichero` varchar(255) NULL,            -- _fichero
    `fecha` datetime NOT NULL,              -- _fecha
    `carga_terminal_id` integer AUTO_INCREMENT NOT NULL, -- _cargaTerminalId
    CONSTRAINT `pk_carga_terminal` PRIMARY KEY (`carga_terminal_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.CargaTerminales
CREATE TABLE `carga_terminales` (
    `id` integer AUTO_INCREMENT NOT NULL,   -- _id
    `fecha` datetime NOT NULL,              -- _fecha
    `empresa_id` integer NULL,              -- _empresa
    `archivo` varchar(255) NULL,            -- _archivo
    CONSTRAINT `pk_carga_terminales` PRIMARY KEY (`id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.CarnetRadiologico
CREATE TABLE `carnet_radiologico` (
    `numero` varchar(255) NULL,             -- _numero
    `fecha_emision` datetime NOT NULL,      -- _fechaEmision
    `carnet_id` integer AUTO_INCREMENT NOT NULL, -- _carnetId
    CONSTRAINT `pk_carnet_radiologico` PRIMARY KEY (`carnet_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Categoria
CREATE TABLE `categoria` (
    `nombre` varchar(255) NULL,             -- _nombre
    `categoria_id` integer AUTO_INCREMENT NOT NULL, -- _categoriaId
    CONSTRAINT `pk_categoria` PRIMARY KEY (`categoria_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.DatosRevision
CREATE TABLE `datos_revision` (
    `valor` text NULL,                      -- _valor
    `revision_id` integer NULL,             -- _revision
    `datos_id` integer AUTO_INCREMENT NOT NULL, -- _datosId
    `campo_id` integer NULL,                -- _campo
    CONSTRAINT `pk_datos_revision` PRIMARY KEY (`datos_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Direccion
CREATE TABLE `direccion` (
    `provincia` varchar(255) NULL,          -- _provincia
    `poblacion` varchar(255) NULL,          -- _poblacion
    `pais` varchar(255) NULL,               -- _pais
    `instalacion_id` integer NULL,          -- _instalacion
    `empresa_id` integer NULL,              -- _empresa
    `dir_postal` varchar(255) NULL,         -- _dirPostal
    `direccion_id` integer AUTO_INCREMENT NOT NULL, -- _direccionId
    `descripcion` varchar(255) NULL,        -- _descripcion
    `cod_postal` varchar(255) NULL,         -- _codPostal
    CONSTRAINT `pk_direccion` PRIMARY KEY (`direccion_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Dispositivo
CREATE TABLE `dispositivo` (
    `tipo_id` integer NULL,                 -- _tipoDispositivo
    `posicion` varchar(255) NULL,           -- _posicion
    `operativo` bit NOT NULL,               -- _operativo
    `numero_industria` varchar(255) NULL,   -- _numeroIndustria
    `nombre` varchar(255) NULL,             -- _nombre
    `modelo_id` integer NULL,               -- _modeloDispositivo
    `instalacion_id` integer NULL,          -- _instalacion
    `funcion` varchar(255) NOT NULL,        -- _funcion
    `fecha_inicio_revision` datetime NOT NULL, -- _fechaInicioRevision
    `fecha_fabricacion` datetime NOT NULL,  -- _fechaFabricacion
    `fecha_caducidad` datetime NOT NULL,    -- _fechaCaducidad
    `fecha_baja` datetime NULL,             -- _fechaBaja
    `fabricante_id` integer NULL,           -- _fabricante
    `estado` varchar(255) NOT NULL,         -- _estado
    `dispositivo_padre_dispositivo_id` integer NULL, -- _dispositivoPadre
    `dispositivo_id` integer AUTO_INCREMENT NOT NULL, -- _dispositivoId
    `comentarios` varchar(255) NULL,        -- _comentarios
    `cod_barras` varchar(255) NOT NULL,     -- _codBarras
    `carga_kg` decimal(20,10) NOT NULL,     -- _cargaKg
    `caducado` tinyint NOT NULL,            -- _caducado
    `agente_extintor_id` integer NULL,      -- _agenteExtintor
    CONSTRAINT `pk_dispositivo` PRIMARY KEY (`dispositivo_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Documento
CREATE TABLE `documento` (
    `tipo_id` integer NULL,                 -- _tipoDispositivo
    `subcategoria_id` integer NULL,         -- _subcategoria
    `nombre` varchar(255) NULL,             -- _nombre
    `instalacion_id` integer NULL,          -- _instalacion
    `fecha` datetime NOT NULL,              -- _fecha
    `extension` varchar(255) NULL,          -- _extension
    `empresa_id` integer NULL,              -- _empresa
    `documento_id` integer AUTO_INCREMENT NOT NULL, -- _documentoId
    `comentarios` varchar(255) NULL,        -- _comentarios
    `categoria_id` integer NULL,            -- _categoria
    CONSTRAINT `pk_documento` PRIMARY KEY (`documento_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Email
CREATE TABLE `email` (
    `mail` varchar(255) NULL,               -- _mail
    `instalacion_id` integer NULL,          -- _instalacion
    `envio` bit NOT NULL,                   -- _envio
    `empresa_id` integer NULL,              -- _empresa
    `email_id` integer AUTO_INCREMENT NOT NULL, -- _emailId
    `descripcion` varchar(255) NULL,        -- _descripcion
    CONSTRAINT `pk_email` PRIMARY KEY (`email_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Empresa
CREATE TABLE `empresa` (
    `persona_contacto` varchar(255) NULL,   -- _personaContacto
    `nombre` varchar(255) NULL,             -- _nombre
    `empresa_id` integer AUTO_INCREMENT NOT NULL, -- _empresaId
    `cod_ax` varchar(255) NULL,             -- _codAx
    CONSTRAINT `pk_empresa` PRIMARY KEY (`empresa_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Estado
CREATE TABLE `estado` (
    `nombre` varchar(255) NULL,             -- _nombre
    `estado_id` integer AUTO_INCREMENT NOT NULL, -- _estadoId
    `en_cierre` bit NOT NULL,               -- _enCierre
    `en_apertura` bit NOT NULL,             -- _enApertura
    `empresa_id` integer NULL,              -- _empresa
    CONSTRAINT `pk_estado` PRIMARY KEY (`estado_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Fabricante
CREATE TABLE `fabricante` (
    `nombre` varchar(255) NULL,             -- _nombre
    `fabricante_id` integer AUTO_INCREMENT NOT NULL, -- _fabricanteId
    CONSTRAINT `pk_fabricante` PRIMARY KEY (`fabricante_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Filtro
CREATE TABLE `filtro` (
    `usuario_id` integer NULL,              -- _usuario
    `tipo` varchar(255) NULL,               -- _tipo
    `nombre` varchar(255) NULL,             -- _nombre
    `filtro_id` integer AUTO_INCREMENT NOT NULL, -- _filtroId
    `expresion` text NULL,                  -- _expresion
    CONSTRAINT `pk_filtro` PRIMARY KEY (`filtro_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.GrupoMensajes
CREATE TABLE `grupo_mensajes` (
    `nombre` varchar(255) NULL,             -- _nombre
    `grupo_mensajes_id` integer AUTO_INCREMENT NOT NULL, -- _grupoMensajesId
    CONSTRAINT `pk_grupo_mensajes` PRIMARY KEY (`grupo_mensajes_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.GrupoTrabajo
CREATE TABLE `grupo_trabajo` (
    `nombre` varchar(255) NULL,             -- _nombre
    `grupo_trabajo_id` integer AUTO_INCREMENT NOT NULL, -- _grupoTrabajoId
    CONSTRAINT `pk_grupo_trabajo` PRIMARY KEY (`grupo_trabajo_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.GrupoUsuario
CREATE TABLE `grupo_usuario` (
    `nombre` varchar(255) NULL,             -- _nombre
    `grupo_usuario_id` integer AUTO_INCREMENT NOT NULL, -- _grupoUsuarioId
    CONSTRAINT `pk_grupo_usuario` PRIMARY KEY (`grupo_usuario_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Incidencia
CREATE TABLE `incidencia` (
    `usuario_id` integer NULL,              -- _usuario
    `responsable_id` integer NULL,          -- _responsable
    `prioridad_id` integer NULL,            -- _prioridad
    `operativo` bit NOT NULL,               -- _operativo
    `incidencia_id` integer AUTO_INCREMENT NOT NULL, -- _incidenciaId
    `fecha_cierre` datetime NULL,           -- _fechaCierre
    `fecha_apertura` datetime NOT NULL,     -- _fechaApertura
    `estado_id` integer NULL,               -- _estado
    `dispositivo_id` integer NULL,          -- _dispositivo
    `comentarios` varchar(255) NULL,        -- _comentarios
    CONSTRAINT `pk_incidencia` PRIMARY KEY (`incidencia_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.IncidenciaEvolucion
CREATE TABLE `incidencia_evolucion` (
    `usuario_id` integer NULL,              -- _usuario
    `operativo` bit NULL,                   -- _operativo
    `incidencia_evolucion_id` integer AUTO_INCREMENT NOT NULL, -- _incidenciaEvolucionId
    `incidencia_id` integer NULL,           -- _incidencia
    `fecha_evolucion` datetime NOT NULL,    -- _fechaEvolucion
    `comentarios` varchar(255) NULL,        -- _comentarios
    CONSTRAINT `pk_incidencia_evolucion` PRIMARY KEY (`incidencia_evolucion_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.InformeProgramado
CREATE TABLE `informe_programado` (
    `programacion_informe_id` integer NULL, -- _programacionInforme
    `instalacion_id` integer NULL,          -- _instalacion
    `informe_programado_id` integer AUTO_INCREMENT NOT NULL, -- _informeProgramadoId
    `fecha_inicial` datetime NOT NULL,      -- _fechaInicial
    `fecha_final` datetime NOT NULL,        -- _fechaFinal
    `empresa_id` integer NULL,              -- _empresa
    `documento_id` integer NULL,            -- _documento
    CONSTRAINT `pk_informe_programado` PRIMARY KEY (`informe_programado_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Instalacion
CREATE TABLE `instalacion` (
    `nombre` varchar(255) NULL,             -- _nombre
    `instalacion_id` integer AUTO_INCREMENT NOT NULL, -- _instalacionId
    `empresa_id` integer NULL,              -- _empresa
    `cod_ax` varchar(50) NULL,              -- _codAx
    CONSTRAINT `pk_instalacion` PRIMARY KEY (`instalacion_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Mensaje
CREATE TABLE `mensaje` (
    `urgente` bit NOT NULL,                 -- _urgente
    `titulo` varchar(255) NULL,             -- _titulo
    `mensaje_id` integer AUTO_INCREMENT NOT NULL, -- _mensajeId
    `grupo_mensajes_id` integer NULL,       -- _grupoMensajes
    `fecha_inicio` datetime NOT NULL,       -- _fechaInicio
    `fecha_final` datetime NOT NULL,        -- _fechaFinal
    `cuerpo` varchar(255) NULL,             -- _cuerpo
    CONSTRAINT `pk_mensaje` PRIMARY KEY (`mensaje_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.ModeloDispositivo
CREATE TABLE `modelo_dispositivo` (
    `tipo_id` integer NULL,                 -- _tipoDispositivo
    `nombre` varchar(255) NULL,             -- _nombre
    `modelo_id` integer AUTO_INCREMENT NOT NULL, -- _modeloId
    `instalacion_id` integer NULL,          -- _instalacion
    `empresa_id` integer NULL,              -- _empresa
    `carga_kg` decimal(20,10) NOT NULL,     -- _cargaKg
    CONSTRAINT `pk_modelo_dispositivo` PRIMARY KEY (`modelo_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Operario
CREATE TABLE `operario` (
    `sexo` char(1) NULL,                    -- _sexo
    `operario_id` integer AUTO_INCREMENT NOT NULL, -- _operarioId
    `nombre` varchar(255) NULL,             -- _nombre
    `instalacion_id` integer NULL,          -- _instalacion
    `fecha_nacimiento` datetime NOT NULL,   -- _fechaNacimiento
    `dni` varchar(255) NULL,                -- _dni
    `cod_ax` varchar(50) NULL,              -- _codAx
    `carnet_id` integer NULL,               -- _carnetRadiologico
    CONSTRAINT `pk_operario` PRIMARY KEY (`operario_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Permiso
CREATE TABLE `permiso` (
    `ver` bit NOT NULL,                     -- _ver
    `nombre` varchar(255) NULL,             -- _proceso1
    `permiso_id` integer AUTO_INCREMENT NOT NULL, -- _permisoId
    `modificar` bit NOT NULL,               -- _modificar
    `grupo_usuario_id` integer NULL,        -- _grupoUsuario
    `especial` bit NOT NULL,                -- _especial
    `crear` bit NOT NULL,                   -- _crear
    CONSTRAINT `pk_permiso` PRIMARY KEY (`permiso_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Plantilla
CREATE TABLE `plantilla` (
    `plantilla_id` integer NOT NULL,        -- _plantillaId
    `nombre` varchar(255) NULL,             -- _nombre
    `contenido` text NULL,                  -- _contenido
    CONSTRAINT `pk_plantilla` PRIMARY KEY (`plantilla_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.PlantillaRevision
CREATE TABLE `plantilla_revision` (
    `tipo_periodo` varchar(255) NULL,       -- _tipoPeriodo
    `tipo_id` integer NULL,                 -- _tipoDispositivo
    `plantilla_id` integer AUTO_INCREMENT NOT NULL, -- _plantillaId
    `numero_periodos` integer NOT NULL,     -- _numeroPeriodos
    `no_periodica` tinyint NOT NULL,        -- _noPeriodica
    `facturable` tinyint NOT NULL,          -- _facturable
    `descripcion` varchar(255) NULL,        -- _descripcion
    `con_sustitucion` tinyint NOT NULL,     -- _conSustitucion
    `comentarios` varchar(255) NULL,        -- _comentarios
    CONSTRAINT `pk_plantilla_revision` PRIMARY KEY (`plantilla_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Prioridad
CREATE TABLE `prioridad` (
    `prioridad_id` integer AUTO_INCREMENT NOT NULL, -- _prioridadId
    `nombre` varchar(255) NULL,             -- _nombre
    `empresa_id` integer NULL,              -- _empresa
    CONSTRAINT `pk_prioridad` PRIMARY KEY (`prioridad_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Proceso
CREATE TABLE `proceso` (
    `proceso_padre_nombre` varchar(255) NULL, -- _procesoPadre
    `nombre` varchar(255) NOT NULL,         -- _nombre
    `descripcion` varchar(255) NULL,        -- _descripcion
    CONSTRAINT `pk_proceso` PRIMARY KEY (`nombre`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Programa
CREATE TABLE `programa` (
    `usuario_id` integer NULL,              -- _usuario
    `terminal_id` integer NULL,             -- _terminal
    `programa_id` integer AUTO_INCREMENT NOT NULL, -- _programaId
    `fecha_programada` datetime NOT NULL,   -- _fechaProgramada
    `estado` varchar(255) NULL,             -- _estado
    `comentarios` text NULL,                -- _comentarios
    `carga_terminal_id` integer NULL,       -- _cargaTerminal
    CONSTRAINT `pk_programa` PRIMARY KEY (`programa_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.ProgramacionInforme
CREATE TABLE `programacion_informe` (
    `programacion_informe_id` integer AUTO_INCREMENT NOT NULL, -- _programacionInformeId
    `periodicidad` varchar(255) NULL,       -- _periodicidad
    `informe` varchar(255) NULL,            -- _informe
    `fecha_inicial` datetime NOT NULL,      -- _fechaInicial
    CONSTRAINT `pk_programacion_informe` PRIMARY KEY (`programacion_informe_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Responsable
CREATE TABLE `responsable` (
    `responsable_id` integer AUTO_INCREMENT NOT NULL, -- _responsableId
    `nombre` varchar(255) NULL,             -- _nombre
    `empresa_id` integer NULL,              -- _empresa
    CONSTRAINT `pk_responsable` PRIMARY KEY (`responsable_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.ResumenRevision
CREATE TABLE `resumen_revision` (
    `resumen_revision_id` integer AUTO_INCREMENT NOT NULL, -- _resumenRevisionId
    `plantilla_id` integer NULL,            -- _plantillaRevision
    `fecha_ultima` datetime NOT NULL,       -- _fechaUltima
    `fecha_siguiente` datetime NOT NULL,    -- _fechaSiguiente
    `fecha_inicio` datetime NOT NULL,       -- _fechaInicio
    `dispositivo_id` integer NULL,          -- _dispositivo
    CONSTRAINT `pk_resumen_revision` PRIMARY KEY (`resumen_revision_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Revision
CREATE TABLE `revision` (
    `usuario_id` integer NULL,              -- _usuario
    `tipo_anomalia_id` integer NULL,        -- _tipoAnomalia
    `revision_id` integer AUTO_INCREMENT NOT NULL, -- _revisionId
    `resumen_informe` text NULL,            -- _resumenInforme
    `resultado` varchar(255) NULL,          -- _resultado
    `programa_id` integer NULL,             -- _programa
    `plantilla_id` integer NULL,            -- _plantillaRevision
    `observaciones` varchar(255) NULL,      -- _observaciones
    `grupo_programacion` integer NOT NULL,  -- _grupoProgramacion
    `fecha_revision` datetime NULL,         -- _fechaRevision
    `fecha_programada` datetime NULL,       -- _fechaProgramada
    `fecha_planificada` datetime NULL,      -- _fechaPlanificada
    `estado` varchar(50) NULL,              -- _estado
    `dispositivo_id` integer NULL,          -- _dispositivo
    `cod_barras` varchar(255) NULL,         -- _codBarras
    `cadu_prox` tinyint NOT NULL,           -- _caduProx
    CONSTRAINT `pk_revision` PRIMARY KEY (`revision_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Subcategoria
CREATE TABLE `subcategoria` (
    `subcategoria_id` integer AUTO_INCREMENT NOT NULL, -- _subcategoriaId
    `nombre` varchar(255) NULL,             -- _nombre
    `categoria_id` integer NULL,            -- _categoria
    CONSTRAINT `pk_subcategoria` PRIMARY KEY (`subcategoria_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Sustitucion
CREATE TABLE `sustitucion` (
    `usuario_id` integer NULL,              -- _usuario
    `sustitucion_id` integer AUTO_INCREMENT NOT NULL, -- _sustitucionId
    `revision_id` integer NULL,             -- _revision
    `programa_id` integer NULL,             -- _programa
    `fecha` datetime NOT NULL,              -- _fecha
    `estado` varchar(255) NOT NULL,         -- _estado
    `dispositivo1_dispositivo_id` integer NULL, -- _dispositivo1
    `dispositivo_dispositivo_id` integer NULL, -- _dispositivo
    `comentarios` text NULL,                -- _comentarios
    CONSTRAINT `pk_sustitucion` PRIMARY KEY (`sustitucion_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Telefono
CREATE TABLE `telefono` (
    `tipo` varchar(255) NULL,               -- _tipo
    `telefono_id` integer AUTO_INCREMENT NOT NULL, -- _telefonoId
    `numero` varchar(255) NULL,             -- _numero
    `instalacion_id` integer NULL,          -- _instalacion
    `empresa_id` integer NULL,              -- _empresa
    `descripcion` varchar(255) NULL,        -- _descripcion
    CONSTRAINT `pk_telefono` PRIMARY KEY (`telefono_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Terminal
CREATE TABLE `terminal` (
    `tipo` varchar(255) NULL,               -- _tipo
    `terminal_id` integer AUTO_INCREMENT NOT NULL, -- _terminalId
    `observaciones` text NULL,              -- _observaciones
    `numero_serie` varchar(255) NULL,       -- _numeroSerie
    `nombre` varchar(255) NULL,             -- _nombre
    `empresa_id` integer NULL,              -- _empresa
    CONSTRAINT `pk_terminal` PRIMARY KEY (`terminal_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.TipoAnomalia
CREATE TABLE `tipo_anomalia` (
    `tipo_anomalia_id` integer AUTO_INCREMENT NOT NULL, -- _tipoAnomaliaId
    `nombre` varchar(255) NULL,             -- _nombre
    CONSTRAINT `pk_tipo_anomalia` PRIMARY KEY (`tipo_anomalia_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.TipoCampo
CREATE TABLE `tipo_campo` (
    `tipo_id` integer NOT NULL,             -- _tipoId
    `descripcion` varchar(255) NULL,        -- _descripcion
    CONSTRAINT `pk_tipo_campo` PRIMARY KEY (`tipo_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.TipoDispositivo
CREATE TABLE `tipo_dispositivo` (
    `tipo_id` integer AUTO_INCREMENT NOT NULL, -- _tipoId
    `nombre` varchar(255) NULL,             -- _nombre
    `instalacion_id` integer NULL,          -- _instalacion
    `empresa_id` integer NULL,              -- _empresa
    `caduca` integer NOT NULL,              -- _caduca
    CONSTRAINT `pk_tipo_dispositivo` PRIMARY KEY (`tipo_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.Usuario
CREATE TABLE `usuario` (
    `usuario_id` integer AUTO_INCREMENT NOT NULL, -- _usuarioId
    `passwd` varchar(255) NULL,             -- _password
    `nombre` varchar(255) NULL,             -- _nombre
    `login` varchar(255) NULL,              -- _login
    `instalacion_id` integer NULL,          -- _instalacion
    `grupo_usuario_id` integer NULL,        -- _grupoUsuario1
    `grupo_trabajo_id` integer NULL,        -- _grupoTrabajo
    `empresa_id` integer NULL,              -- _empresa
    CONSTRAINT `pk_usuario` PRIMARY KEY (`usuario_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.UsuarioExtranet
CREATE TABLE `usuario_extranet` (
    `usuario_extranet_id` integer AUTO_INCREMENT NOT NULL, -- _usuarioExtranetId
    `plain_password` varchar(255) NULL,     -- _plainPassword
    `passwd` varchar(255) NULL,             -- _password
    `nombre` varchar(255) NULL,             -- _nombre
    `login` varchar(255) NULL,              -- _login
    `instalacion_id` integer NULL,          -- _instalacion
    `empresa_id` integer NULL,              -- _empresa
    `correo` varchar(255) NULL,             -- _correo
    CONSTRAINT `pk_usuario_extranet` PRIMARY KEY (`usuario_extranet_id`)
) ENGINE = InnoDB;

-- LainsaSciModelo.UTPParametros
CREATE TABLE `utp_parametros` (
    `utp_parametros_id` integer AUTO_INCREMENT NOT NULL, -- _uTPParametrosId
    `telefono` varchar(20) NULL,            -- _telefono
    `nombre` varchar(50) NULL,              -- _nombre
    `max_dosis_superficial` decimal(20,10) NOT NULL, -- _maxDosisSuperficial
    `max_dosis_superfical_periodo` decimal(20,10) NOT NULL, -- _maxDosisSuperficalPeriodo
    `max_dosis_profunda_periodo` decimal(20,10) NOT NULL, -- _maxDosisProfundaPeriodo
    `max_dosis_profunda` decimal(20,10) NOT NULL, -- _maxDosisProfunda
    `mail` varchar(50) NULL,                -- _mail
    `direccion` varchar(100) NULL,          -- _direccion
    CONSTRAINT `pk_utp_parametros` PRIMARY KEY (`utp_parametros_id`)
) ENGINE = InnoDB;

ALTER TABLE `campo` ADD INDEX `idx_campo_plantilla_id`(`plantilla_id`);

ALTER TABLE `carga_terminal` ADD INDEX `idx_carga_terminal_terminal_id`(`terminal_id`);

ALTER TABLE `carga_terminales` ADD INDEX `idx_carga_terminales_empresa_id`(`empresa_id`);

ALTER TABLE `datos_revision` ADD INDEX `idx_datos_revision_campo_id`(`campo_id`);

ALTER TABLE `datos_revision` ADD INDEX `idx_datos_revision_revision_id`(`revision_id`);

ALTER TABLE `direccion` ADD INDEX `idx_direccion_empresa_id`(`empresa_id`);

ALTER TABLE `direccion` ADD INDEX `idx_direccion_instalacion_id`(`instalacion_id`);

ALTER TABLE `dispositivo` ADD INDEX `idx_dispositivo_agente_extintor_id`(`agente_extintor_id`);

ALTER TABLE `dispositivo` ADD INDEX `idx_dispositivo_dispositivo_padre_dispositivo_id`(`dispositivo_padre_dispositivo_id`);

ALTER TABLE `dispositivo` ADD INDEX `idx_dispositivo_fabricante_id`(`fabricante_id`);

ALTER TABLE `dispositivo` ADD INDEX `idx_dispositivo_instalacion_id`(`instalacion_id`);

ALTER TABLE `documento` ADD INDEX `idx_documento_categoria_id`(`categoria_id`);

ALTER TABLE `documento` ADD INDEX `idx_documento_empresa_id`(`empresa_id`);

ALTER TABLE `documento` ADD INDEX `idx_documento_instalacion_id`(`instalacion_id`);

ALTER TABLE `documento` ADD INDEX `idx_documento_subcategoria_id`(`subcategoria_id`);

ALTER TABLE `documento` ADD INDEX `idx_documento_tipo_id`(`tipo_id`);

ALTER TABLE `email` ADD INDEX `idx_email_empresa_id`(`empresa_id`);

ALTER TABLE `email` ADD INDEX `idx_email_instalacion_id`(`instalacion_id`);

ALTER TABLE `estado` ADD INDEX `idx_estado_empresa_id`(`empresa_id`);

ALTER TABLE `filtro` ADD INDEX `idx_filtro_usuario_id`(`usuario_id`);

ALTER TABLE `incidencia` ADD INDEX `idx_incidencia_dispositivo_id`(`dispositivo_id`);

ALTER TABLE `incidencia` ADD INDEX `idx_incidencia_estado_id`(`estado_id`);

ALTER TABLE `incidencia` ADD INDEX `idx_incidencia_prioridad_id`(`prioridad_id`);

ALTER TABLE `incidencia` ADD INDEX `idx_incidencia_responsable_id`(`responsable_id`);

ALTER TABLE `incidencia` ADD INDEX `idx_incidencia_usuario_id`(`usuario_id`);

ALTER TABLE `incidencia_evolucion` ADD INDEX `idx_incidencia_evolucion_incidencia_id`(`incidencia_id`);

ALTER TABLE `incidencia_evolucion` ADD INDEX `idx_incidencia_evolucion_usuario_id`(`usuario_id`);

ALTER TABLE `informe_programado` ADD INDEX `idx_informe_programado_documento_id`(`documento_id`);

ALTER TABLE `informe_programado` ADD INDEX `idx_informe_programado_empresa_id`(`empresa_id`);

ALTER TABLE `informe_programado` ADD INDEX `idx_informe_programado_instalacion_id`(`instalacion_id`);

ALTER TABLE `informe_programado` ADD INDEX `idx_informe_programado_programacion_informe_id`(`programacion_informe_id`);

ALTER TABLE `instalacion` ADD INDEX `idx_instalacion_empresa_id`(`empresa_id`);

ALTER TABLE `mensaje` ADD INDEX `idx_mensaje_grupo_mensajes_id`(`grupo_mensajes_id`);

ALTER TABLE `modelo_dispositivo` ADD INDEX `idx_modelo_dispositivo_empresa_id`(`empresa_id`);

ALTER TABLE `modelo_dispositivo` ADD INDEX `idx_modelo_dispositivo_instalacion_id`(`instalacion_id`);

ALTER TABLE `modelo_dispositivo` ADD INDEX `idx_modelo_dispositivo_tipo_id`(`tipo_id`);

ALTER TABLE `operario` ADD INDEX `idx_operario_instalacion_id`(`instalacion_id`);

ALTER TABLE `permiso` ADD INDEX `idx_permiso_grupo_usuario_id`(`grupo_usuario_id`);

ALTER TABLE `plantilla_revision` ADD INDEX `idx_plantilla_revision_tipo_id`(`tipo_id`);

ALTER TABLE `prioridad` ADD INDEX `idx_prioridad_empresa_id`(`empresa_id`);

ALTER TABLE `proceso` ADD INDEX `idx_proceso_proceso_padre_nombre`(`proceso_padre_nombre`);

ALTER TABLE `programa` ADD INDEX `idx_programa_carga_terminal_id`(`carga_terminal_id`);

ALTER TABLE `programa` ADD INDEX `idx_programa_terminal_id`(`terminal_id`);

ALTER TABLE `programa` ADD INDEX `idx_programa_usuario_id`(`usuario_id`);

ALTER TABLE `responsable` ADD INDEX `idx_responsable_empresa_id`(`empresa_id`);

ALTER TABLE `resumen_revision` ADD INDEX `idx_resumen_revision_dispositivo_id`(`dispositivo_id`);

ALTER TABLE `resumen_revision` ADD INDEX `idx_resumen_revision_plantilla_id`(`plantilla_id`);

ALTER TABLE `revision` ADD INDEX `idx_revision_dispositivo_id`(`dispositivo_id`);

ALTER TABLE `revision` ADD INDEX `idx_revision_plantilla_id`(`plantilla_id`);

ALTER TABLE `revision` ADD INDEX `idx_revision_programa_id`(`programa_id`);

ALTER TABLE `revision` ADD INDEX `idx_revision_tipo_anomalia_id`(`tipo_anomalia_id`);

ALTER TABLE `revision` ADD INDEX `idx_revision_usuario_id`(`usuario_id`);

ALTER TABLE `subcategoria` ADD INDEX `idx_subcategoria_categoria_id`(`categoria_id`);

ALTER TABLE `sustitucion` ADD INDEX `idx_sustitucion_programa_id`(`programa_id`);

ALTER TABLE `sustitucion` ADD INDEX `idx_sustitucion_revision_id`(`revision_id`);

ALTER TABLE `sustitucion` ADD INDEX `idx_sustitucion_usuario_id`(`usuario_id`);

ALTER TABLE `telefono` ADD INDEX `idx_telefono_empresa_id`(`empresa_id`);

ALTER TABLE `telefono` ADD INDEX `idx_telefono_instalacion_id`(`instalacion_id`);

ALTER TABLE `terminal` ADD INDEX `idx_terminal_empresa_id`(`empresa_id`);

ALTER TABLE `tipo_dispositivo` ADD INDEX `idx_tipo_dispositivo_empresa_id`(`empresa_id`);

ALTER TABLE `tipo_dispositivo` ADD INDEX `idx_tipo_dispositivo_instalacion_id`(`instalacion_id`);

ALTER TABLE `usuario` ADD INDEX `idx_usuario_empresa_id`(`empresa_id`);

ALTER TABLE `usuario` ADD INDEX `idx_usuario_grupo_trabajo_id`(`grupo_trabajo_id`);

ALTER TABLE `usuario` ADD INDEX `idx_usuario_grupo_usuario_id`(`grupo_usuario_id`);

ALTER TABLE `usuario` ADD INDEX `idx_usuario_instalacion_id`(`instalacion_id`);

ALTER TABLE `usuario_extranet` ADD INDEX `idx_usuario_extranet_empresa_id`(`empresa_id`);

ALTER TABLE `usuario_extranet` ADD INDEX `idx_usuario_extranet_instalacion_id`(`instalacion_id`);

ALTER TABLE `campo` ADD CONSTRAINT `ref_campo_plantilla_revision` FOREIGN KEY `ref_campo_plantilla_revision` (`plantilla_id`) REFERENCES `plantilla_revision` (`plantilla_id`);

ALTER TABLE `campo` ADD CONSTRAINT `ref_campo_tipo_campo` FOREIGN KEY `ref_campo_tipo_campo` (`tipo_id`) REFERENCES `tipo_campo` (`tipo_id`);

ALTER TABLE `carga_terminal` ADD CONSTRAINT `ref_carga_terminal_terminal` FOREIGN KEY `ref_carga_terminal_terminal` (`terminal_id`) REFERENCES `terminal` (`terminal_id`);

ALTER TABLE `carga_terminales` ADD CONSTRAINT `ref_carga_terminales_empresa` FOREIGN KEY `ref_carga_terminales_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

ALTER TABLE `datos_revision` ADD CONSTRAINT `ref_datos_revision_campo` FOREIGN KEY `ref_datos_revision_campo` (`campo_id`) REFERENCES `campo` (`campo_id`);

ALTER TABLE `datos_revision` ADD CONSTRAINT `ref_datos_revision_revision` FOREIGN KEY `ref_datos_revision_revision` (`revision_id`) REFERENCES `revision` (`revision_id`);

ALTER TABLE `direccion` ADD CONSTRAINT `ref_direccion_empresa` FOREIGN KEY `ref_direccion_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

ALTER TABLE `direccion` ADD CONSTRAINT `ref_direccion_instalacion` FOREIGN KEY `ref_direccion_instalacion` (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`);

ALTER TABLE `dispositivo` ADD CONSTRAINT `ref_dispositivo_agente_extintor` FOREIGN KEY `ref_dispositivo_agente_extintor` (`agente_extintor_id`) REFERENCES `agente_extintor` (`agente_extintor_id`);

ALTER TABLE `dispositivo` ADD CONSTRAINT `ref_dispositivo_fabricante` FOREIGN KEY `ref_dispositivo_fabricante` (`fabricante_id`) REFERENCES `fabricante` (`fabricante_id`);

ALTER TABLE `dispositivo` ADD CONSTRAINT `ref_dispositivo_instalacion` FOREIGN KEY `ref_dispositivo_instalacion` (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`);

ALTER TABLE `dispositivo` ADD CONSTRAINT `ref_dispositivo_modelo_dispositivo` FOREIGN KEY `ref_dispositivo_modelo_dispositivo` (`modelo_id`) REFERENCES `modelo_dispositivo` (`modelo_id`);

ALTER TABLE `dispositivo` ADD CONSTRAINT `ref_dispositivo_tipo_dispositivo` FOREIGN KEY `ref_dispositivo_tipo_dispositivo` (`tipo_id`) REFERENCES `tipo_dispositivo` (`tipo_id`);

ALTER TABLE `documento` ADD CONSTRAINT `ref_documento_categoria` FOREIGN KEY `ref_documento_categoria` (`categoria_id`) REFERENCES `categoria` (`categoria_id`);

ALTER TABLE `documento` ADD CONSTRAINT `ref_documento_empresa` FOREIGN KEY `ref_documento_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

ALTER TABLE `documento` ADD CONSTRAINT `ref_documento_instalacion` FOREIGN KEY `ref_documento_instalacion` (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`);

ALTER TABLE `documento` ADD CONSTRAINT `ref_documento_subcategoria` FOREIGN KEY `ref_documento_subcategoria` (`subcategoria_id`) REFERENCES `subcategoria` (`subcategoria_id`);

ALTER TABLE `documento` ADD CONSTRAINT `ref_documento_tipo_dispositivo` FOREIGN KEY `ref_documento_tipo_dispositivo` (`tipo_id`) REFERENCES `tipo_dispositivo` (`tipo_id`);

ALTER TABLE `email` ADD CONSTRAINT `ref_email_empresa` FOREIGN KEY `ref_email_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

ALTER TABLE `email` ADD CONSTRAINT `ref_email_instalacion` FOREIGN KEY `ref_email_instalacion` (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`);

ALTER TABLE `estado` ADD CONSTRAINT `ref_estado_empresa` FOREIGN KEY `ref_estado_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

ALTER TABLE `filtro` ADD CONSTRAINT `ref_filtro_usuario` FOREIGN KEY `ref_filtro_usuario` (`usuario_id`) REFERENCES `usuario` (`usuario_id`);

ALTER TABLE `incidencia` ADD CONSTRAINT `ref_incidencia_dispositivo` FOREIGN KEY `ref_incidencia_dispositivo` (`dispositivo_id`) REFERENCES `dispositivo` (`dispositivo_id`);

ALTER TABLE `incidencia` ADD CONSTRAINT `ref_incidencia_estado` FOREIGN KEY `ref_incidencia_estado` (`estado_id`) REFERENCES `estado` (`estado_id`);

ALTER TABLE `incidencia` ADD CONSTRAINT `ref_incidencia_prioridad` FOREIGN KEY `ref_incidencia_prioridad` (`prioridad_id`) REFERENCES `prioridad` (`prioridad_id`);

ALTER TABLE `incidencia` ADD CONSTRAINT `ref_incidencia_responsable` FOREIGN KEY `ref_incidencia_responsable` (`responsable_id`) REFERENCES `responsable` (`responsable_id`);

ALTER TABLE `incidencia` ADD CONSTRAINT `ref_incidencia_usuario` FOREIGN KEY `ref_incidencia_usuario` (`usuario_id`) REFERENCES `usuario` (`usuario_id`);

ALTER TABLE `incidencia_evolucion` ADD CONSTRAINT `ref_incidencia_evolucion_incidencia` FOREIGN KEY `ref_incidencia_evolucion_incidencia` (`incidencia_id`) REFERENCES `incidencia` (`incidencia_id`);

ALTER TABLE `incidencia_evolucion` ADD CONSTRAINT `ref_incidencia_evolucion_usuario` FOREIGN KEY `ref_incidencia_evolucion_usuario` (`usuario_id`) REFERENCES `usuario` (`usuario_id`);

ALTER TABLE `informe_programado` ADD CONSTRAINT `ref_informe_programado_documento` FOREIGN KEY `ref_informe_programado_documento` (`documento_id`) REFERENCES `documento` (`documento_id`);

ALTER TABLE `informe_programado` ADD CONSTRAINT `ref_informe_programado_empresa` FOREIGN KEY `ref_informe_programado_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

ALTER TABLE `informe_programado` ADD CONSTRAINT `ref_informe_programado_instalacion` FOREIGN KEY `ref_informe_programado_instalacion` (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`);

ALTER TABLE `informe_programado` ADD CONSTRAINT `ref_informe_programado_programacion_informe` FOREIGN KEY `ref_informe_programado_programacion_informe` (`programacion_informe_id`) REFERENCES `programacion_informe` (`programacion_informe_id`);

ALTER TABLE `instalacion` ADD CONSTRAINT `ref_instalacion_empresa` FOREIGN KEY `ref_instalacion_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

ALTER TABLE `mensaje` ADD CONSTRAINT `ref_mensaje_grupo_mensajes` FOREIGN KEY `ref_mensaje_grupo_mensajes` (`grupo_mensajes_id`) REFERENCES `grupo_mensajes` (`grupo_mensajes_id`);

ALTER TABLE `modelo_dispositivo` ADD CONSTRAINT `ref_modelo_dispositivo_empresa` FOREIGN KEY `ref_modelo_dispositivo_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

ALTER TABLE `modelo_dispositivo` ADD CONSTRAINT `ref_modelo_dispositivo_instalacion` FOREIGN KEY `ref_modelo_dispositivo_instalacion` (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`);

ALTER TABLE `modelo_dispositivo` ADD CONSTRAINT `ref_modelo_dispositivo_tipo_dispositivo` FOREIGN KEY `ref_modelo_dispositivo_tipo_dispositivo` (`tipo_id`) REFERENCES `tipo_dispositivo` (`tipo_id`);

ALTER TABLE `operario` ADD CONSTRAINT `ref_operario_carnet_radiologico` FOREIGN KEY `ref_operario_carnet_radiologico` (`carnet_id`) REFERENCES `carnet_radiologico` (`carnet_id`);

ALTER TABLE `operario` ADD CONSTRAINT `ref_operario_instalacion` FOREIGN KEY `ref_operario_instalacion` (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`);

ALTER TABLE `permiso` ADD CONSTRAINT `ref_permiso_grupo_usuario` FOREIGN KEY `ref_permiso_grupo_usuario` (`grupo_usuario_id`) REFERENCES `grupo_usuario` (`grupo_usuario_id`);

ALTER TABLE `permiso` ADD CONSTRAINT `ref_permiso_proceso` FOREIGN KEY `ref_permiso_proceso` (`nombre`) REFERENCES `proceso` (`nombre`);

ALTER TABLE `plantilla_revision` ADD CONSTRAINT `ref_plantilla_revision_tipo_dispositivo` FOREIGN KEY `ref_plantilla_revision_tipo_dispositivo` (`tipo_id`) REFERENCES `tipo_dispositivo` (`tipo_id`);

ALTER TABLE `prioridad` ADD CONSTRAINT `ref_prioridad_empresa` FOREIGN KEY `ref_prioridad_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

ALTER TABLE `programa` ADD CONSTRAINT `ref_programa_carga_terminal` FOREIGN KEY `ref_programa_carga_terminal` (`carga_terminal_id`) REFERENCES `carga_terminal` (`carga_terminal_id`);

ALTER TABLE `programa` ADD CONSTRAINT `ref_programa_terminal` FOREIGN KEY `ref_programa_terminal` (`terminal_id`) REFERENCES `terminal` (`terminal_id`);

ALTER TABLE `programa` ADD CONSTRAINT `ref_programa_usuario` FOREIGN KEY `ref_programa_usuario` (`usuario_id`) REFERENCES `usuario` (`usuario_id`);

ALTER TABLE `responsable` ADD CONSTRAINT `ref_responsable_empresa` FOREIGN KEY `ref_responsable_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

ALTER TABLE `resumen_revision` ADD CONSTRAINT `ref_resumen_revision_dispositivo` FOREIGN KEY `ref_resumen_revision_dispositivo` (`dispositivo_id`) REFERENCES `dispositivo` (`dispositivo_id`);

ALTER TABLE `resumen_revision` ADD CONSTRAINT `ref_resumen_revision_plantilla_revision` FOREIGN KEY `ref_resumen_revision_plantilla_revision` (`plantilla_id`) REFERENCES `plantilla_revision` (`plantilla_id`);

ALTER TABLE `revision` ADD CONSTRAINT `ref_revision_dispositivo` FOREIGN KEY `ref_revision_dispositivo` (`dispositivo_id`) REFERENCES `dispositivo` (`dispositivo_id`);

ALTER TABLE `revision` ADD CONSTRAINT `ref_revision_plantilla_revision` FOREIGN KEY `ref_revision_plantilla_revision` (`plantilla_id`) REFERENCES `plantilla_revision` (`plantilla_id`);

ALTER TABLE `revision` ADD CONSTRAINT `ref_revision_programa` FOREIGN KEY `ref_revision_programa` (`programa_id`) REFERENCES `programa` (`programa_id`);

ALTER TABLE `revision` ADD CONSTRAINT `ref_revision_tipo_anomalia` FOREIGN KEY `ref_revision_tipo_anomalia` (`tipo_anomalia_id`) REFERENCES `tipo_anomalia` (`tipo_anomalia_id`);

ALTER TABLE `revision` ADD CONSTRAINT `ref_revision_usuario` FOREIGN KEY `ref_revision_usuario` (`usuario_id`) REFERENCES `usuario` (`usuario_id`);

ALTER TABLE `subcategoria` ADD CONSTRAINT `ref_subcategoria_categoria` FOREIGN KEY `ref_subcategoria_categoria` (`categoria_id`) REFERENCES `categoria` (`categoria_id`);

ALTER TABLE `sustitucion` ADD CONSTRAINT `ref_sustitucion_dispositivo` FOREIGN KEY `ref_sustitucion_dispositivo` (`dispositivo_dispositivo_id`) REFERENCES `dispositivo` (`dispositivo_id`);

ALTER TABLE `sustitucion` ADD CONSTRAINT `ref_sustitucion_dispositivo2` FOREIGN KEY `ref_sustitucion_dispositivo2` (`dispositivo1_dispositivo_id`) REFERENCES `dispositivo` (`dispositivo_id`);

ALTER TABLE `sustitucion` ADD CONSTRAINT `ref_sustitucion_programa` FOREIGN KEY `ref_sustitucion_programa` (`programa_id`) REFERENCES `programa` (`programa_id`);

ALTER TABLE `sustitucion` ADD CONSTRAINT `ref_sustitucion_revision` FOREIGN KEY `ref_sustitucion_revision` (`revision_id`) REFERENCES `revision` (`revision_id`);

ALTER TABLE `sustitucion` ADD CONSTRAINT `ref_sustitucion_usuario` FOREIGN KEY `ref_sustitucion_usuario` (`usuario_id`) REFERENCES `usuario` (`usuario_id`);

ALTER TABLE `telefono` ADD CONSTRAINT `ref_telefono_empresa` FOREIGN KEY `ref_telefono_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

ALTER TABLE `telefono` ADD CONSTRAINT `ref_telefono_instalacion` FOREIGN KEY `ref_telefono_instalacion` (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`);

ALTER TABLE `terminal` ADD CONSTRAINT `ref_terminal_empresa` FOREIGN KEY `ref_terminal_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

ALTER TABLE `tipo_dispositivo` ADD CONSTRAINT `ref_tipo_dispositivo_empresa` FOREIGN KEY `ref_tipo_dispositivo_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

ALTER TABLE `tipo_dispositivo` ADD CONSTRAINT `ref_tipo_dispositivo_instalacion` FOREIGN KEY `ref_tipo_dispositivo_instalacion` (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`);

ALTER TABLE `usuario` ADD CONSTRAINT `ref_usuario_empresa` FOREIGN KEY `ref_usuario_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

ALTER TABLE `usuario` ADD CONSTRAINT `ref_usuario_grupo_trabajo` FOREIGN KEY `ref_usuario_grupo_trabajo` (`grupo_trabajo_id`) REFERENCES `grupo_trabajo` (`grupo_trabajo_id`);

ALTER TABLE `usuario` ADD CONSTRAINT `ref_usuario_grupo_usuario` FOREIGN KEY `ref_usuario_grupo_usuario` (`grupo_usuario_id`) REFERENCES `grupo_usuario` (`grupo_usuario_id`);

ALTER TABLE `usuario` ADD CONSTRAINT `ref_usuario_instalacion` FOREIGN KEY `ref_usuario_instalacion` (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`);

ALTER TABLE `usuario_extranet` ADD CONSTRAINT `ref_usuario_extranet_empresa` FOREIGN KEY `ref_usuario_extranet_empresa` (`empresa_id`) REFERENCES `empresa` (`empresa_id`);

ALTER TABLE `usuario_extranet` ADD CONSTRAINT `ref_usuario_extranet_instalacion` FOREIGN KEY `ref_usuario_extranet_instalacion` (`instalacion_id`) REFERENCES `instalacion` (`instalacion_id`);

