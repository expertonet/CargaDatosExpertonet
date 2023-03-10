USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[InformacionAduanera]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformacionAduanera](
	[NumeroPedimento] [text] NULL,
	[Parte_Id] [int] NULL,
	[Concepto_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[InformacionAduanera]  WITH CHECK ADD  CONSTRAINT [Concepto_InformacionAduanera] FOREIGN KEY([Concepto_Id])
REFERENCES [dbo].[Concepto] ([Concepto_Id])
GO
ALTER TABLE [dbo].[InformacionAduanera] CHECK CONSTRAINT [Concepto_InformacionAduanera]
GO
ALTER TABLE [dbo].[InformacionAduanera]  WITH CHECK ADD  CONSTRAINT [Parte_InformacionAduanera] FOREIGN KEY([Parte_Id])
REFERENCES [dbo].[Parte] ([Parte_Id])
GO
ALTER TABLE [dbo].[InformacionAduanera] CHECK CONSTRAINT [Parte_InformacionAduanera]
GO
