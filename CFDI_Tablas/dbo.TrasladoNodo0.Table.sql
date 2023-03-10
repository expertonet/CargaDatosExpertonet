USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[TrasladoNodo0]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrasladoNodo0](
	[Impuesto] [text] NULL,
	[TipoFactor] [text] NULL,
	[TasaOCuota] [real] NOT NULL,
	[Importe] [real] NOT NULL,
	[Traslados_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[TrasladoNodo0]  WITH CHECK ADD  CONSTRAINT [TrasladosNodo0_TrasladoNodo0] FOREIGN KEY([Traslados_Id])
REFERENCES [dbo].[TrasladosNodo0] ([Traslados_Id])
GO
ALTER TABLE [dbo].[TrasladoNodo0] CHECK CONSTRAINT [TrasladosNodo0_TrasladoNodo0]
GO
