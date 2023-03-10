USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Solicitud]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud](
	[Solicitud_Id] [varchar](80) NOT NULL,
	[EstadoSolicitud_Id] [int] NULL,
	[Fecha] [varchar](80) NULL,
	[FechaInicio] [varchar](80) NULL,
	[FechaFin] [varchar](80) NULL,
	[RFCEmisor] [varchar](80) NULL,
	[RFCReceptor] [varchar](80) NULL,
	[TipoEmision_Id] [int] NULL,
	[RFCSolicitante] [varchar](80) NULL,
	[TipoSolicitud_Id] [int] NULL,
	[Fehca_Creacion] [datetime] NULL,
	[IdPaquete] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Solicitud_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD FOREIGN KEY([TipoEmision_Id])
REFERENCES [dbo].[TipoEmision] ([TipoEmision_Id])
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD FOREIGN KEY([TipoSolicitud_Id])
REFERENCES [dbo].[TipoSolicitud] ([TipoSolicitud_Id])
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_EstadoSolicitud] FOREIGN KEY([EstadoSolicitud_Id])
REFERENCES [dbo].[EstadoSolicitud] ([EstadoSolicitud_Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_EstadoSolicitud]
GO
