-- ----------------------------------------------------------------------------
-- MySQL Workbench Migration
-- Migrated Schemata: dbo
-- Source Schemata: dbo
-- Created: Sun Apr 24 00:31:05 2022
-- Workbench Version: 8.0.23
-- ----------------------------------------------------------------------------


-- ----------------------------------------------------------------------------
-- Table dbo.estado_automatico
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.estado_automatico (
  estado_id INT NOT NULL,
  estado VARCHAR(250) NOT NULL,
  PRIMARY KEY (estado_id));
  
  
  -- ----------------------------------------------------------------------------
-- Table dbo.EstadoSolicitud
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.EstadoSolicitud (
  EstadoSolicitud_Id INT NOT NULL,
  EstadoSolicitud VARCHAR(80) NULL,
  PRIMARY KEY (EstadoSolicitud_Id));
  
  
  -- ----------------------------------------------------------------------------
-- Table dbo.TipoSolicitud
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.TipoSolicitud (
  TipoSolicitud_Id INT NOT NULL,
  TipoSolicitud VARCHAR(250) NULL,
  PRIMARY KEY (TipoSolicitud_Id));
  
  
  -- ----------------------------------------------------------------------------
-- Table dbo.TipoEmision
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.TipoEmision (
  TipoEmision_Id INT NOT NULL,
  TipoEmision VARCHAR(50) NULL,
  PRIMARY KEY (TipoEmision_Id));
  
  -- ----------------------------------------------------------------------------
-- Table dbo.Solicitud
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Solicitud (
  Solicitud_Id VARCHAR(80) NOT NULL,
  EstadoSolicitud_Id INT NULL,
  Fecha VARCHAR(80) NULL,
  FechaInicio VARCHAR(80) NULL,
  FechaFin VARCHAR(80) NULL,
  RFCEmisor VARCHAR(80) NULL,
  RFCReceptor VARCHAR(80) NULL,
  TipoEmision_Id INT NULL,
  RFCSolicitante VARCHAR(80) NULL,
  TipoSolicitud_Id INT NULL,
  Fehca_Creacion VARCHAR(80) NULL,
  IdPaquete VARCHAR(250) NULL,
  PRIMARY KEY (Solicitud_Id),
  CONSTRAINT FK_Solicitud_EstadoSolicitud
    FOREIGN KEY (EstadoSolicitud_Id)
    REFERENCES nominame_CFDI33.EstadoSolicitud (EstadoSolicitud_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT FK__Solicitud__TipoE__607251E5
    FOREIGN KEY (TipoEmision_Id)
    REFERENCES nominame_CFDI33.TipoEmision (TipoEmision_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT FK__Solicitud__TipoS__65370702
    FOREIGN KEY (TipoSolicitud_Id)
    REFERENCES nominame_CFDI33.TipoSolicitud (TipoSolicitud_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    

    
    
    -- ----------------------------------------------------------------------------
-- Table dbo.automatico2
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.automatico2 (
  id INT NOT NULL,
  rfc VARCHAR(250) NOT NULL,
  tipo_solicitud INT NOT NULL,
  tipo_emision INT NOT NULL,
  fecha_inicial DATE NULL,
  fecha_final DATE NULL,
  fecha_programacion DATE NULL,
  hora_programacion TIME(6) NULL,
  TipoAutomatico_id INT NULL,
  estado_id INT NULL);

  -- ----------------------------------------------------------------------------
-- Table dbo.estado_ejecucion
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.estado_ejecucion (
  EstadoEjecucion_id INT NOT NULL,
  EstadoEjecucion VARCHAR(250) NOT NULL,
  PRIMARY KEY (EstadoEjecucion_id));


-- ----------------------------------------------------------------------------
-- Table dbo.tipo_automatico
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.tipo_automatico (
  TipoAutomatico_id INT NOT NULL,
  TipoAutomatico VARCHAR(250) NOT NULL,
  PRIMARY KEY (TipoAutomatico_id));
  
  
  
-- ----------------------------------------------------------------------------
-- Table dbo.AUTOMATICO
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.AUTOMATICO (
  id INT NOT NULL,
  id_solicitud VARCHAR(250) NULL,
  rfc VARCHAR(250) NOT NULL,
  rfc_emisor VARCHAR(250) NULL,
  rfc_receptor VARCHAR(250) NULL,
  tipo_solicitud INT NOT NULL,
  tipo_emision INT NOT NULL,
  fecha_inicial DATE NULL,
  fecha_final DATE NULL,
  fecha_programacion DATE NULL,
  hora_programacion TIME(6) NULL,
  TipoAutomatico_id INT NULL,
  estado_id INT NULL,
  EstadoEjecucion_id INT NULL,
  PRIMARY KEY (id),
  CONSTRAINT fk_TipoAutomatico
    FOREIGN KEY (TipoAutomatico_id)
    REFERENCES nominame_CFDI33.tipo_automatico (TipoAutomatico_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_EstadoAutomatico
    FOREIGN KEY (estado_id)
    REFERENCES nominame_CFDI33.estado_automatico (estado_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_EstadoEjecucion
    FOREIGN KEY (EstadoEjecucion_id)
    REFERENCES nominame_CFDI33.estado_ejecucion (EstadoEjecucion_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.EstatusCancelacion
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.EstatusCancelacion (
  EstatusCancelacion_Id INT NOT NULL,
  EstatusCancelacion VARCHAR(50) NULL,
  PRIMARY KEY (EstatusCancelacion_Id));
  
  

-- ----------------------------------------------------------------------------
-- Table dbo.EstadoFactura
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.EstadoFactura (
  EstadoFactura_Id INT NOT NULL,
  EstadoFactura VARCHAR(50) NULL,
  PRIMARY KEY (EstadoFactura_Id));
  
  -- ----------------------------------------------------------------------------
-- Table dbo.sysdiagrams
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.sysdiagrams (
  name VARCHAR(160) NOT NULL,
  principal_id INT NOT NULL,
  diagram_id INT NOT NULL,
  version INT NULL,
  definition LONGBLOB NULL,
  PRIMARY KEY (diagram_id),
  UNIQUE INDEX UK_principal_name (principal_id ASC, name ASC));
  
  
-- ----------------------------------------------------------------------------
-- Table dbo.PersonaFisicaMoral
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.PersonaFisicaMoral (
  RFC VARCHAR(80) NOT NULL,
  RazonSocial VARCHAR(80) NULL,
  Alias VARCHAR(80) NULL,
  Usuario VARCHAR(80) NULL,
  Clave VARCHAR(80) NULL,
  Certificado VARCHAR(2000) NULL,
  Id INT NOT NULL,
  PRIMARY KEY (RFC, Id));
  
  
-- ----------------------------------------------------------------------------
-- Table dbo.MetadataSAT
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.MetadataSAT (
  UUID VARCHAR(900) NOT NULL,
  RfcEmisor VARCHAR(20) NULL,
  NombreEmisor VARCHAR(1000) NULL,
  RfcReceptor VARCHAR(20) NULL,
  NombreReceptor VARCHAR(1000) NULL,
  RfcPac VARCHAR(20) NULL,
  FechaEmision DATETIME NULL,
  FechaCertificacionSat DATETIME NULL,
  Monto FLOAT(24,0) NULL,
  EfectoComprobante VARCHAR(20) NULL,
  Estatus VARCHAR(20) NULL,
  FechaCancelacion DATETIME NULL,
  PRIMARY KEY (UUID(255)));
  
  
  
-- ----------------------------------------------------------------------------
-- Table dbo.Comprobante
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Comprobante (
  Version LONGTEXT NULL,
  Serie VARCHAR(25) NULL,
  Folio VARCHAR(40) NULL,
  Fecha DATETIME NOT NULL,
  Sello LONGTEXT NULL,
  FormaPago LONGTEXT NULL,
  NoCertificado LONGTEXT NULL,
  Certificado LONGTEXT NULL,
  CondicionesDePago VARCHAR(1000) NULL,
  SubTotal FLOAT(24,0) NOT NULL,
  Descuento FLOAT(24,0) NULL,
  Moneda LONGTEXT NULL,
  TipoCambio FLOAT(24,0) NULL,
  Total FLOAT(24,0) NOT NULL,
  TipoDeComprobante LONGTEXT NULL,
  MetodoPago LONGTEXT NULL,
  LugarExpedicion LONGTEXT NULL,
  Confirmacion LONGTEXT NULL,
  Comprobante_Id INT NOT NULL,
  TipoEmision_Id INT NULL,
  EstadoFactura_Id INT NULL,
  EstatusCancelacion_Id INT NULL,
  TipoSolicitud_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Comprobante_Id),
  CONSTRAINT Comprobante_TipoEmision
    FOREIGN KEY (TipoEmision_Id)
    REFERENCES nominame_CFDI33.TipoEmision (TipoEmision_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT Comprobante_EstadoFactura
    FOREIGN KEY (EstadoFactura_Id)
    REFERENCES nominame_CFDI33.EstadoFactura (EstadoFactura_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT Comprobante_EstatusCancelacion
    FOREIGN KEY (EstatusCancelacion_Id)
    REFERENCES nominame_CFDI33.EstatusCancelacion (EstatusCancelacion_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT Comprobante_TipoSolicitud
    FOREIGN KEY (TipoSolicitud_Id)
    REFERENCES nominame_CFDI33.TipoSolicitud (TipoSolicitud_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- ----------------------------------------------------------------------------
-- Table dbo.CfdiRelacionados
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.CfdiRelacionados (
  TipoRelacion LONGTEXT NULL,
  CfdiRelacionados_Id INT NOT NULL,
  Comprobante_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (CfdiRelacionados_Id),
  CONSTRAINT Comprobante_CfdiRelacionados
    FOREIGN KEY (Comprobante_Id)
    REFERENCES nominame_CFDI33.Comprobante (Comprobante_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- ----------------------------------------------------------------------------
-- Table dbo.CfdiRelacionado
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.CfdiRelacionado (
  UUID_REL LONGTEXT NULL,
  CfdiRelacionados_Id INT NULL,
  UUID LONGTEXT NULL,
  CONSTRAINT CfdiRelacionados_CfdiRelacionado
    FOREIGN KEY (CfdiRelacionados_Id)
    REFERENCES nominame_CFDI33.CfdiRelacionados (CfdiRelacionados_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.Emisor
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Emisor (
  Rfc VARCHAR(13) NOT NULL,
  Nombre VARCHAR(254) NULL,
  RegimenFiscal LONGTEXT NULL,
  Comprobante_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT Comprobante_Emisor
    FOREIGN KEY (Comprobante_Id)
    REFERENCES nominame_CFDI33.Comprobante (Comprobante_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.Receptor
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Receptor (
  Rfc VARCHAR(13) NOT NULL,
  Nombre VARCHAR(254) NULL,
  ResidenciaFiscal LONGTEXT NULL,
  NumRegIdTrib VARCHAR(40) NULL,
  UsoCFDI LONGTEXT NULL,
  Comprobante_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT Comprobante_Receptor
    FOREIGN KEY (Comprobante_Id)
    REFERENCES nominame_CFDI33.Comprobante (Comprobante_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.Conceptos
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Conceptos (
  Conceptos_Id INT NOT NULL,
  Comprobante_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Conceptos_Id),
  CONSTRAINT Comprobante_Conceptos
    FOREIGN KEY (Comprobante_Id)
    REFERENCES nominame_CFDI33.Comprobante (Comprobante_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.Concepto
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Concepto (
  ClaveProdServ LONGTEXT NULL,
  NoIdentificacion VARCHAR(100) NULL,
  Cantidad FLOAT(24,0) NOT NULL,
  ClaveUnidad LONGTEXT NULL,
  Unidad VARCHAR(20) NULL,
  Descripcion VARCHAR(1000) NOT NULL,
  ValorUnitario FLOAT(24,0) NOT NULL,
  Importe FLOAT(24,0) NOT NULL,
  Descuento FLOAT(24,0) NULL,
  Concepto_Id INT NOT NULL,
  Conceptos_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Concepto_Id),
  CONSTRAINT Conceptos_Concepto
    FOREIGN KEY (Conceptos_Id)
    REFERENCES nominame_CFDI33.Conceptos (Conceptos_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.Impuestos
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Impuestos (
  Impuestos_Id INT NOT NULL,
  Concepto_Id INT NULL,
  Comprobante_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Impuestos_Id),
  CONSTRAINT Concepto_Impuestos
    FOREIGN KEY (Concepto_Id)
    REFERENCES nominame_CFDI33.Concepto (Concepto_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT Comprobante_Impuestos
    FOREIGN KEY (Comprobante_Id)
    REFERENCES nominame_CFDI33.Comprobante (Comprobante_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.Traslados
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Traslados (
  Traslados_Id INT NOT NULL,
  Impuestos_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Traslados_Id),
  CONSTRAINT Impuestos_Traslados
    FOREIGN KEY (Impuestos_Id)
    REFERENCES nominame_CFDI33.Impuestos (Impuestos_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    

    
    
-- ----------------------------------------------------------------------------
-- Table dbo.Traslado
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Traslado (
  Base FLOAT(24,0) NOT NULL,
  Impuesto LONGTEXT NULL,
  TipoFactor LONGTEXT NULL,
  TasaOCuota FLOAT(24,0) NULL,
  Importe FLOAT(24,0) NULL,
  Traslados_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT Traslados_Traslado
    FOREIGN KEY (Traslados_Id)
    REFERENCES nominame_CFDI33.Traslados (Traslados_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.Retenciones
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Retenciones (
  Retenciones_Id INT NOT NULL,
  Impuestos_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Retenciones_Id),
  CONSTRAINT Impuestos_Retenciones
    FOREIGN KEY (Impuestos_Id)
    REFERENCES nominame_CFDI33.Impuestos (Impuestos_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.Retencion
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Retencion (
  Base FLOAT(24,0) NOT NULL,
  Impuesto LONGTEXT NULL,
  TipoFactor LONGTEXT NULL,
  TasaOCuota FLOAT(24,0) NOT NULL,
  Importe FLOAT(24,0) NOT NULL,
  Retenciones_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT Retenciones_Retencion
    FOREIGN KEY (Retenciones_Id)
    REFERENCES nominame_CFDI33.Retenciones (Retenciones_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.CuentaPredial
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.CuentaPredial (
  Numero VARCHAR(150) NOT NULL,
  Concepto_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT Concepto_CuentaPredial
    FOREIGN KEY (Concepto_Id)
    REFERENCES nominame_CFDI33.Concepto (Concepto_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
 
-- ----------------------------------------------------------------------------
-- Table dbo.ComplementoConcepto
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.ComplementoConcepto (
  Concepto_Id INT NULL,
  UUID VARCHAR(900) NULL,
  ComplementoConcepto_Id INT NULL,
  CONSTRAINT Concepto_ComplementoConcepto
    FOREIGN KEY (Concepto_Id)
    REFERENCES nominame_CFDI33.Concepto (Concepto_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.Parte
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Parte (
  ClaveProdServ LONGTEXT NULL,
  NoIdentificacion VARCHAR(100) NULL,
  Cantidad FLOAT(24,0) NOT NULL,
  Unidad VARCHAR(20) NULL,
  Descripcion VARCHAR(1000) NOT NULL,
  ValorUnitario FLOAT(24,0) NULL,
  Importe FLOAT(24,0) NULL,
  Parte_Id INT NOT NULL,
  Concepto_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Parte_Id),
  CONSTRAINT Concepto_Parte
    FOREIGN KEY (Concepto_Id)
    REFERENCES nominame_CFDI33.Concepto (Concepto_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.Complemento
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Complemento (
  Comprobante_Id INT NULL,
  Complemento_Id INT NOT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Complemento_Id),
  CONSTRAINT Comprobante_Complemento
    FOREIGN KEY (Comprobante_Id)
    REFERENCES nominame_CFDI33.Comprobante (Comprobante_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- ----------------------------------------------------------------------------
-- Table dbo.Addenda
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Addenda (
  Comprobante_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT Comprobante_Addenda
    FOREIGN KEY (Comprobante_Id)
    REFERENCES nominame_CFDI33.Comprobante (Comprobante_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- ----------------------------------------------------------------------------
-- Table dbo.Nomina
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Nomina (
  Version LONGTEXT NULL,
  TipoNomina LONGTEXT NULL,
  FechaPago DATETIME NOT NULL,
  FechaInicialPago DATETIME NOT NULL,
  FechaFinalPago DATETIME NOT NULL,
  NumDiasPagados FLOAT(24,0) NOT NULL,
  TotalPercepciones FLOAT(24,0) NULL,
  TotalDeducciones FLOAT(24,0) NULL,
  TotalOtrosPagos FLOAT(24,0) NULL,
  Nomina_Id INT NOT NULL,
  Complemento_Id INT NOT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Nomina_Id),
  CONSTRAINT Complemento_Nomina
    FOREIGN KEY (Complemento_Id)
    REFERENCES nominame_CFDI33.Complemento (Complemento_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.TimbreFiscalDigital
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.TimbreFiscalDigital (
  Version LONGTEXT NULL,
  FechaTimbrado DATETIME NOT NULL,
  RfcProvCertif LONGTEXT NULL,
  Leyenda VARCHAR(150) NULL,
  SelloCFD LONGTEXT NULL,
  NoCertificadoSAT LONGTEXT NULL,
  SelloSAT LONGTEXT NULL,
  Complemento_Id INT NOT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Complemento_Id),
  CONSTRAINT Complemento_TimbreFiscalDigital
    FOREIGN KEY (Complemento_Id)
    REFERENCES nominame_CFDI33.Complemento (Complemento_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.Pagos
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Pagos (
  Version LONGTEXT NULL,
  Pagos_Id INT NOT NULL,
  Complemento_Id INT NOT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Pagos_Id),
  CONSTRAINT Complemento_Pagos
    FOREIGN KEY (Complemento_Id)
    REFERENCES nominame_CFDI33.Complemento (Complemento_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.Pago
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Pago (
  FechaPago DATETIME NOT NULL,
  FormaDePagoP LONGTEXT NULL,
  MonedaP LONGTEXT NULL,
  TipoCambioP FLOAT(24,0) NULL,
  Monto FLOAT(24,0) NOT NULL,
  NumOperacion VARCHAR(100) NULL,
  RfcEmisorCtaOrd VARCHAR(13) NULL,
  NomBancoOrdExt VARCHAR(300) NULL,
  CtaOrdenante VARCHAR(50) NULL,
  RfcEmisorCtaBen LONGTEXT NULL,
  CtaBeneficiario VARCHAR(50) NULL,
  TipoCadPago LONGTEXT NULL,
  CertPago VARBINARY(1) NULL,
  CadPago VARCHAR(80) NULL,
  SelloPago VARBINARY(1) NULL,
  Pago_Id INT NOT NULL,
  Pagos_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Pago_Id),
  CONSTRAINT Pagos_Pago
    FOREIGN KEY (Pagos_Id)
    REFERENCES nominame_CFDI33.Pagos (Pagos_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
    

-- ----------------------------------------------------------------------------
-- Table dbo.DoctoRelacionado
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.DoctoRelacionado (
  IdDocumento VARCHAR(36) NOT NULL,
  Serie VARCHAR(25) NULL,
  Folio VARCHAR(40) NULL,
  MonedaDR LONGTEXT NULL,
  TipoCambioDR FLOAT(24,0) NULL,
  MetodoDePagoDR LONGTEXT NULL,
  NumParcialidad BIGINT NULL,
  ImpSaldoAnt FLOAT(24,0) NULL,
  ImpPagado FLOAT(24,0) NULL,
  ImpSaldoInsoluto FLOAT(24,0) NULL,
  Pago_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT Pago_DoctoRelacionado
    FOREIGN KEY (Pago_Id)
    REFERENCES nominame_CFDI33.Pago (Pago_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.ImpuestosNodo0
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.ImpuestosNodo0 (
  TotalImpuestosRetenidos FLOAT(24,0) NULL,
  TotalImpuestosTrasladados FLOAT(24,0) NULL,
  Impuestos_Id INT NOT NULL,
  Pago_Id INT NULL,
  Comprobante_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Impuestos_Id),
  CONSTRAINT Comprobante_ImpuestosNodo0
    FOREIGN KEY (Comprobante_Id)
    REFERENCES nominame_CFDI33.Comprobante (Comprobante_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.TrasladosNodo0
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.TrasladosNodo0 (
  Traslados_Id INT NOT NULL,
  Impuestos_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Traslados_Id),
  CONSTRAINT Impuestos_TrasladosNodo0
    FOREIGN KEY (Impuestos_Id)
    REFERENCES nominame_CFDI33.ImpuestosNodo0 (Impuestos_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.TrasladoNodo0
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.TrasladoNodo0 (
  Impuesto LONGTEXT NULL,
  TipoFactor LONGTEXT NULL,
  TasaOCuota FLOAT(24,0) NOT NULL,
  Importe FLOAT(24,0) NOT NULL,
  Traslados_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT TrasladosNodo0_TrasladoNodo0
    FOREIGN KEY (Traslados_Id)
    REFERENCES nominame_CFDI33.TrasladosNodo0 (Traslados_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    


-- ----------------------------------------------------------------------------
-- Table dbo.RetencionesNodo0
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.RetencionesNodo0 (
  Retenciones_Id INT NOT NULL,
  Impuestos_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Retenciones_Id),
  CONSTRAINT ImpuestosNodo0_RetencionesNodo0
    FOREIGN KEY (Impuestos_Id)
    REFERENCES nominame_CFDI33.ImpuestosNodo0 (Impuestos_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.RetencionNodo0
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.RetencionNodo0 (
  Impuesto LONGTEXT NULL,
  Importe FLOAT(24,0) NOT NULL,
  Retenciones_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT RetencionesNodo0_RetencionNodo0
    FOREIGN KEY (Retenciones_Id)
    REFERENCES nominame_CFDI33.RetencionesNodo0 (Retenciones_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.EmisorNomina
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.EmisorNomina (
  Curp LONGTEXT NULL,
  RegistroPatronal VARCHAR(20) NULL,
  RfcPatronOrigen VARCHAR(13) NULL,
  Emisor_Id INT NOT NULL,
  Nomina_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Emisor_Id),
  CONSTRAINT Nomina_Emisor
    FOREIGN KEY (Nomina_Id)
    REFERENCES nominame_CFDI33.Nomina (Nomina_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.EntidadSNCF
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.EntidadSNCF (
  OrigenRecurso LONGTEXT NULL,
  MontoRecursoPropio FLOAT(24,0) NULL,
  Emisor_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT Emisor_EntidadSNCF
    FOREIGN KEY (Emisor_Id)
    REFERENCES nominame_CFDI33.EmisorNomina (Emisor_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
    

-- ----------------------------------------------------------------------------
-- Table dbo.Deducciones
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Deducciones (
  TotalOtrasDeducciones FLOAT(24,0) NULL,
  TotalImpuestosRetenidos FLOAT(24,0) NULL,
  Deducciones_Id INT NOT NULL,
  Nomina_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Deducciones_Id),
  CONSTRAINT Nomina_Deducciones
    FOREIGN KEY (Nomina_Id)
    REFERENCES nominame_CFDI33.Nomina (Nomina_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    

-- ----------------------------------------------------------------------------
-- Table dbo.Deduccion
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Deduccion (
  TipoDeduccion LONGTEXT NULL,
  Clave VARCHAR(15) NOT NULL,
  Concepto VARCHAR(100) NOT NULL,
  Importe FLOAT(24,0) NOT NULL,
  Deducciones_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT Deducciones_Deduccion
    FOREIGN KEY (Deducciones_Id)
    REFERENCES nominame_CFDI33.Deducciones (Deducciones_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.Incapacidades
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Incapacidades (
  Incapacidades_Id INT NOT NULL,
  Nomina_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Incapacidades_Id),
  CONSTRAINT Nomina_Incapacidades
    FOREIGN KEY (Nomina_Id)
    REFERENCES nominame_CFDI33.Nomina (Nomina_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
    

-- ----------------------------------------------------------------------------
-- Table dbo.Incapacidad
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Incapacidad (
  DiasIncapacidad INT NOT NULL,
  TipoIncapacidad LONGTEXT NULL,
  ImporteMonetario FLOAT(24,0) NULL,
  Incapacidades_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT Incapacidades_Incapacidad
    FOREIGN KEY (Incapacidades_Id)
    REFERENCES nominame_CFDI33.Incapacidades (Incapacidades_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
    

-- ----------------------------------------------------------------------------
-- Table dbo.Percepciones
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Percepciones (
  TotalSueldos FLOAT(24,0) NULL,
  TotalSeparacionIndemnizacion FLOAT(24,0) NULL,
  TotalJubilacionPensionRetiro FLOAT(24,0) NULL,
  TotalGravado FLOAT(24,0) NOT NULL,
  TotalExento FLOAT(24,0) NOT NULL,
  Percepciones_Id INT NOT NULL,
  Nomina_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Percepciones_Id),
  CONSTRAINT Nomina_Percepciones
    FOREIGN KEY (Nomina_Id)
    REFERENCES nominame_CFDI33.Nomina (Nomina_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.Percepcion
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.Percepcion (
  TipoPercepcion LONGTEXT NULL,
  Clave VARCHAR(15) NOT NULL,
  Concepto VARCHAR(100) NOT NULL,
  ImporteGravado FLOAT(24,0) NOT NULL,
  ImporteExento FLOAT(24,0) NOT NULL,
  Percepcion_Id INT NOT NULL,
  Percepciones_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Percepcion_Id),
  CONSTRAINT Percepciones_Percepcion
    FOREIGN KEY (Percepciones_Id)
    REFERENCES nominame_CFDI33.Percepciones (Percepciones_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    

-- ----------------------------------------------------------------------------
-- Table dbo.AccionesOTitulos
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.AccionesOTitulos (
  ValorMercado FLOAT(24,0) NOT NULL,
  PrecioAlOtorgarse FLOAT(24,0) NOT NULL,
  Percepcion_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT Percepcion_AccionesOTitulos
    FOREIGN KEY (Percepcion_Id)
    REFERENCES nominame_CFDI33.Percepcion (Percepcion_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    

-- ----------------------------------------------------------------------------
-- Table dbo.HorasExtra
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.HorasExtra (
  Dias INT NOT NULL,
  TipoHoras LONGTEXT NULL,
  HorasExtra INT NOT NULL,
  ImportePagado FLOAT(24,0) NOT NULL,
  Percepcion_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT Percepcion_HorasExtra
    FOREIGN KEY (Percepcion_Id)
    REFERENCES nominame_CFDI33.Percepcion (Percepcion_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    

-- ----------------------------------------------------------------------------
-- Table dbo.SeparacionIndemnizacion
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.SeparacionIndemnizacion (
  TotalPagado FLOAT(24,0) NOT NULL,
  NumAñosServicio INT NOT NULL,
  UltimoSueldoMensOrd FLOAT(24,0) NOT NULL,
  IngresoAcumulable FLOAT(24,0) NOT NULL,
  IngresoNoAcumulable FLOAT(24,0) NOT NULL,
  Percepciones_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT Percepciones_SeparacionIndemnizacion
    FOREIGN KEY (Percepciones_Id)
    REFERENCES nominame_CFDI33.Percepciones (Percepciones_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    

-- ----------------------------------------------------------------------------
-- Table dbo.JubilacionPensionRetiro
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.JubilacionPensionRetiro (
  TotalUnaExhibicion FLOAT(24,0) NULL,
  TotalParcialidad FLOAT(24,0) NULL,
  MontoDiario FLOAT(24,0) NULL,
  IngresoAcumulable FLOAT(24,0) NOT NULL,
  IngresoNoAcumulable FLOAT(24,0) NOT NULL,
  Percepciones_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT Percepciones_JubilacionPensionRetiro
    FOREIGN KEY (Percepciones_Id)
    REFERENCES nominame_CFDI33.Percepciones (Percepciones_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    


-- ----------------------------------------------------------------------------
-- Table dbo.OtrosPagos
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.OtrosPagos (
  OtrosPagos_Id INT NOT NULL,
  Nomina_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (OtrosPagos_Id),
  CONSTRAINT Nomina_OtrosPagos
    FOREIGN KEY (Nomina_Id)
    REFERENCES nominame_CFDI33.Nomina (Nomina_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table dbo.OtroPago
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.OtroPago (
  TipoOtroPago LONGTEXT NULL,
  Clave VARCHAR(15) NOT NULL,
  Concepto VARCHAR(100) NOT NULL,
  Importe FLOAT(24,0) NOT NULL,
  OtroPago_Id INT NOT NULL,
  OtrosPagos_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (OtroPago_Id),
  CONSTRAINT OtrosPagos_OtroPago
    FOREIGN KEY (OtrosPagos_Id)
    REFERENCES nominame_CFDI33.OtrosPagos (OtrosPagos_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.CompensacionSaldosAFavor
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.CompensacionSaldosAFavor (
  SaldoAFavor FLOAT(24,0) NOT NULL,
  Año SMALLINT NOT NULL,
  RemanenteSalFav FLOAT(24,0) NOT NULL,
  OtroPago_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT OtroPago_CompensacionSaldosAFavor
    FOREIGN KEY (OtroPago_Id)
    REFERENCES nominame_CFDI33.OtroPago (OtroPago_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.InformacionAduanera
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.InformacionAduanera (
  NumeroPedimento LONGTEXT NULL,
  Parte_Id INT NULL,
  Concepto_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT Parte_InformacionAduanera
    FOREIGN KEY (Parte_Id)
    REFERENCES nominame_CFDI33.Parte (Parte_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT Concepto_InformacionAduanera
    FOREIGN KEY (Concepto_Id)
    REFERENCES nominame_CFDI33.Concepto (Concepto_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.ReceptorNomina
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.ReceptorNomina (
  Curp LONGTEXT NULL,
  NumSeguridadSocial VARCHAR(15) NULL,
  FechaInicioRelLaboral DATETIME NULL,
  Antigüedad LONGTEXT NULL,
  TipoContrato LONGTEXT NULL,
  Sindicalizado LONGTEXT NULL,
  TipoJornada LONGTEXT NULL,
  TipoRegimen LONGTEXT NULL,
  NumEmpleado VARCHAR(15) NOT NULL,
  Departamento VARCHAR(100) NULL,
  Puesto VARCHAR(100) NULL,
  RiesgoPuesto LONGTEXT NULL,
  PeriodicidadPago LONGTEXT NULL,
  Banco LONGTEXT NULL,
  CuentaBancaria BIGINT NULL,
  SalarioBaseCotApor FLOAT(24,0) NULL,
  SalarioDiarioIntegrado FLOAT(24,0) NULL,
  ClaveEntFed LONGTEXT NULL,
  Receptor_Id INT NOT NULL,
  Nomina_Id INT NULL,
  UUID VARCHAR(900) NULL,
  PRIMARY KEY (Receptor_Id),
  CONSTRAINT Nomina_Receptor
    FOREIGN KEY (Nomina_Id)
    REFERENCES nominame_CFDI33.Nomina (Nomina_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
    
-- ----------------------------------------------------------------------------
-- Table dbo.SubContratacion
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.SubContratacion (
  RfcLabora VARCHAR(13) NOT NULL,
  PorcentajeTiempo FLOAT(24,0) NOT NULL,
  Receptor_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT Receptor_SubContratacion
    FOREIGN KEY (Receptor_Id)
    REFERENCES nominame_CFDI33.ReceptorNomina (Receptor_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table dbo.SubsidioAlEmpleo
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS nominame_CFDI33.SubsidioAlEmpleo (
  SubsidioCausado FLOAT(24,0) NOT NULL,
  OtroPago_Id INT NULL,
  UUID VARCHAR(900) NULL,
  CONSTRAINT OtroPago_SubsidioAlEmpleo
    FOREIGN KEY (OtroPago_Id)
    REFERENCES nominame_CFDI33.OtroPago (OtroPago_Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
   
CREATE TABLE nominame_CFDI33.CAT_FORMAPAGO (
	Id_FormaPago VARCHAR(10) NOT NULL,
	FormaPago VARCHAR(1000) NULL,
	PRIMARY KEY (Id_FormaPago)
);

CREATE TABLE nominame_CFDI33.CAT_METODO_PAGO (
	Id_MetodoPago varchar(10) NULL,
	MetodoPago varchar(100) NULL
);



   