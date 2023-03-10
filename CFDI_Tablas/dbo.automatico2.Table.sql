USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[automatico2]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[automatico2](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rfc] [varchar](250) NOT NULL,
	[tipo_solicitud] [int] NOT NULL,
	[tipo_emision] [int] NOT NULL,
	[fecha_inicial] [date] NULL,
	[fecha_final] [date] NULL,
	[fecha_programacion] [date] NULL,
	[hora_programacion] [time](7) NULL,
	[TipoAutomatico_id] [int] NULL,
	[estado_id] [int] NULL
) ON [PRIMARY]
GO
