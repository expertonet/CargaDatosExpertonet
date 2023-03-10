USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Emisor]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emisor](
	[Rfc] [varchar](13) NOT NULL,
	[Nombre] [varchar](254) NULL,
	[RegimenFiscal] [text] NULL,
	[Comprobante_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Emisor]  WITH CHECK ADD  CONSTRAINT [Comprobante_Emisor] FOREIGN KEY([Comprobante_Id])
REFERENCES [dbo].[Comprobante] ([Comprobante_Id])
GO
ALTER TABLE [dbo].[Emisor] CHECK CONSTRAINT [Comprobante_Emisor]
GO
