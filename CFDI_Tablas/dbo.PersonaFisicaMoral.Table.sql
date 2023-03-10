USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[PersonaFisicaMoral]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonaFisicaMoral](
	[RFC] [varchar](80) NOT NULL,
	[RazonSocial] [varchar](80) NULL,
	[Alias] [varchar](80) NULL,
	[Usuario] [varchar](80) NULL,
	[Clave] [varchar](80) NULL,
	[Certificado] [varchar](2000) NULL,
	[Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RFC] ASC,
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
