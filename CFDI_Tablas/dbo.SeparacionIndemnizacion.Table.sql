USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[SeparacionIndemnizacion]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeparacionIndemnizacion](
	[TotalPagado] [real] NOT NULL,
	[NumAñosServicio] [int] NOT NULL,
	[UltimoSueldoMensOrd] [real] NOT NULL,
	[IngresoAcumulable] [real] NOT NULL,
	[IngresoNoAcumulable] [real] NOT NULL,
	[Percepciones_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SeparacionIndemnizacion]  WITH CHECK ADD  CONSTRAINT [Percepciones_SeparacionIndemnizacion] FOREIGN KEY([Percepciones_Id])
REFERENCES [dbo].[Percepciones] ([Percepciones_Id])
GO
ALTER TABLE [dbo].[SeparacionIndemnizacion] CHECK CONSTRAINT [Percepciones_SeparacionIndemnizacion]
GO
