USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Deduccion]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deduccion](
	[TipoDeduccion] [text] NULL,
	[Clave] [varchar](15) NOT NULL,
	[Concepto] [varchar](100) NOT NULL,
	[Importe] [real] NOT NULL,
	[Deducciones_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Deduccion]  WITH CHECK ADD  CONSTRAINT [Deducciones_Deduccion] FOREIGN KEY([Deducciones_Id])
REFERENCES [dbo].[Deducciones] ([Deducciones_Id])
GO
ALTER TABLE [dbo].[Deduccion] CHECK CONSTRAINT [Deducciones_Deduccion]
GO
