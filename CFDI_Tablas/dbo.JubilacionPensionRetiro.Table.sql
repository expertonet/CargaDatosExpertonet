USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[JubilacionPensionRetiro]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JubilacionPensionRetiro](
	[TotalUnaExhibicion] [real] NULL,
	[TotalParcialidad] [real] NULL,
	[MontoDiario] [real] NULL,
	[IngresoAcumulable] [real] NOT NULL,
	[IngresoNoAcumulable] [real] NOT NULL,
	[Percepciones_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[JubilacionPensionRetiro]  WITH CHECK ADD  CONSTRAINT [Percepciones_JubilacionPensionRetiro] FOREIGN KEY([Percepciones_Id])
REFERENCES [dbo].[Percepciones] ([Percepciones_Id])
GO
ALTER TABLE [dbo].[JubilacionPensionRetiro] CHECK CONSTRAINT [Percepciones_JubilacionPensionRetiro]
GO
