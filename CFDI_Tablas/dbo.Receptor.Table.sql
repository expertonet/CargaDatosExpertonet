USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Receptor]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receptor](
	[Rfc] [varchar](13) NOT NULL,
	[Nombre] [varchar](254) NULL,
	[ResidenciaFiscal] [text] NULL,
	[NumRegIdTrib] [varchar](40) NULL,
	[UsoCFDI] [text] NULL,
	[Comprobante_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Receptor]  WITH CHECK ADD  CONSTRAINT [Comprobante_Receptor] FOREIGN KEY([Comprobante_Id])
REFERENCES [dbo].[Comprobante] ([Comprobante_Id])
GO
ALTER TABLE [dbo].[Receptor] CHECK CONSTRAINT [Comprobante_Receptor]
GO
