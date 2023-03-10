USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[MetadataSAT]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MetadataSAT](
	[UUID] [varchar](900) NOT NULL,
	[RfcEmisor] [varchar](20) NULL,
	[NombreEmisor] [varchar](1000) NULL,
	[RfcReceptor] [varchar](20) NULL,
	[NombreReceptor] [varchar](1000) NULL,
	[RfcPac] [varchar](20) NULL,
	[FechaEmision] [datetime] NULL,
	[FechaCertificacionSat] [datetime] NULL,
	[Monto] [real] NULL,
	[EfectoComprobante] [varchar](20) NULL,
	[Estatus] [varchar](20) NULL,
	[FechaCancelacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
