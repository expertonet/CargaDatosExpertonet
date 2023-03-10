USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Traslado]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Traslado](
	[Base] [real] NOT NULL,
	[Impuesto] [text] NULL,
	[TipoFactor] [text] NULL,
	[TasaOCuota] [real] NULL,
	[Importe] [real] NULL,
	[Traslados_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Traslado]  WITH CHECK ADD  CONSTRAINT [Traslados_Traslado] FOREIGN KEY([Traslados_Id])
REFERENCES [dbo].[Traslados] ([Traslados_Id])
GO
ALTER TABLE [dbo].[Traslado] CHECK CONSTRAINT [Traslados_Traslado]
GO
