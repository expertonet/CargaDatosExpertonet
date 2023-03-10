USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[AUTOMATICO]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUTOMATICO](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_solicitud] [varchar](250) NULL,
	[rfc] [varchar](250) NOT NULL,
	[rfc_emisor] [varchar](250) NULL,
	[rfc_receptor] [varchar](250) NULL,
	[tipo_solicitud] [int] NOT NULL,
	[tipo_emision] [int] NOT NULL,
	[fecha_inicial] [date] NULL,
	[fecha_final] [date] NULL,
	[fecha_programacion] [date] NULL,
	[hora_programacion] [time](7) NULL,
	[TipoAutomatico_id] [int] NULL,
	[estado_id] [int] NULL,
	[EstadoEjecucion_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AUTOMATICO]  WITH CHECK ADD  CONSTRAINT [fk_EstadoAutomatico] FOREIGN KEY([estado_id])
REFERENCES [dbo].[estado_automatico] ([estado_id])
GO
ALTER TABLE [dbo].[AUTOMATICO] CHECK CONSTRAINT [fk_EstadoAutomatico]
GO
ALTER TABLE [dbo].[AUTOMATICO]  WITH CHECK ADD  CONSTRAINT [fk_EstadoEjecucion] FOREIGN KEY([EstadoEjecucion_id])
REFERENCES [dbo].[estado_ejecucion] ([EstadoEjecucion_id])
GO
ALTER TABLE [dbo].[AUTOMATICO] CHECK CONSTRAINT [fk_EstadoEjecucion]
GO
ALTER TABLE [dbo].[AUTOMATICO]  WITH CHECK ADD  CONSTRAINT [fk_TipoAutomatico] FOREIGN KEY([TipoAutomatico_id])
REFERENCES [dbo].[tipo_automatico] ([TipoAutomatico_id])
GO
ALTER TABLE [dbo].[AUTOMATICO] CHECK CONSTRAINT [fk_TipoAutomatico]
GO
