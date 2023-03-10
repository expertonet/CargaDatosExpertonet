USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[AccionesOTitulos]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccionesOTitulos](
	[ValorMercado] [real] NOT NULL,
	[PrecioAlOtorgarse] [real] NOT NULL,
	[Percepcion_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccionesOTitulos]  WITH CHECK ADD  CONSTRAINT [Percepcion_AccionesOTitulos] FOREIGN KEY([Percepcion_Id])
REFERENCES [dbo].[Percepcion] ([Percepcion_Id])
GO
ALTER TABLE [dbo].[AccionesOTitulos] CHECK CONSTRAINT [Percepcion_AccionesOTitulos]
GO
