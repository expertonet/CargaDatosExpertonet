USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Retencion]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Retencion](
	[Base] [real] NOT NULL,
	[Impuesto] [text] NULL,
	[TipoFactor] [text] NULL,
	[TasaOCuota] [real] NOT NULL,
	[Importe] [real] NOT NULL,
	[Retenciones_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Retencion]  WITH CHECK ADD  CONSTRAINT [Retenciones_Retencion] FOREIGN KEY([Retenciones_Id])
REFERENCES [dbo].[Retenciones] ([Retenciones_Id])
GO
ALTER TABLE [dbo].[Retencion] CHECK CONSTRAINT [Retenciones_Retencion]
GO
