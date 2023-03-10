USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Comprobante]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comprobante](
	[Version] [text] NULL,
	[Serie] [varchar](25) NULL,
	[Folio] [varchar](40) NULL,
	[Fecha] [datetime] NOT NULL,
	[Sello] [text] NULL,
	[FormaPago] [text] NULL,
	[NoCertificado] [text] NULL,
	[Certificado] [text] NULL,
	[CondicionesDePago] [varchar](1000) NULL,
	[SubTotal] [real] NOT NULL,
	[Descuento] [real] NULL,
	[Moneda] [text] NULL,
	[TipoCambio] [real] NULL,
	[Total] [real] NOT NULL,
	[TipoDeComprobante] [text] NULL,
	[MetodoPago] [text] NULL,
	[LugarExpedicion] [text] NULL,
	[Confirmacion] [text] NULL,
	[Comprobante_Id] [int] NOT NULL,
	[TipoEmision_Id] [int] NULL,
	[EstadoFactura_Id] [int] NULL,
	[EstatusCancelacion_Id] [int] NULL,
	[TipoSolicitud_Id] [int] NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_Comprobante] PRIMARY KEY CLUSTERED 
(
	[Comprobante_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comprobante]  WITH CHECK ADD  CONSTRAINT [Comprobante_EstadoFactura] FOREIGN KEY([EstadoFactura_Id])
REFERENCES [dbo].[EstadoFactura] ([EstadoFactura_Id])
GO
ALTER TABLE [dbo].[Comprobante] CHECK CONSTRAINT [Comprobante_EstadoFactura]
GO
ALTER TABLE [dbo].[Comprobante]  WITH CHECK ADD  CONSTRAINT [Comprobante_EstatusCancelacion] FOREIGN KEY([EstatusCancelacion_Id])
REFERENCES [dbo].[EstatusCancelacion] ([EstatusCancelacion_Id])
GO
ALTER TABLE [dbo].[Comprobante] CHECK CONSTRAINT [Comprobante_EstatusCancelacion]
GO
ALTER TABLE [dbo].[Comprobante]  WITH CHECK ADD  CONSTRAINT [Comprobante_TipoEmision] FOREIGN KEY([TipoEmision_Id])
REFERENCES [dbo].[TipoEmision] ([TipoEmision_Id])
GO
ALTER TABLE [dbo].[Comprobante] CHECK CONSTRAINT [Comprobante_TipoEmision]
GO
ALTER TABLE [dbo].[Comprobante]  WITH CHECK ADD  CONSTRAINT [Comprobante_TipoSolicitud] FOREIGN KEY([TipoSolicitud_Id])
REFERENCES [dbo].[TipoSolicitud] ([TipoSolicitud_Id])
GO
ALTER TABLE [dbo].[Comprobante] CHECK CONSTRAINT [Comprobante_TipoSolicitud]
GO
