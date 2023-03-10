USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[DoctoRelacionado]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctoRelacionado](
	[IdDocumento] [varchar](36) NOT NULL,
	[Serie] [varchar](25) NULL,
	[Folio] [varchar](40) NULL,
	[MonedaDR] [text] NULL,
	[TipoCambioDR] [real] NULL,
	[MetodoDePagoDR] [text] NULL,
	[NumParcialidad] [bigint] NULL,
	[ImpSaldoAnt] [real] NULL,
	[ImpPagado] [real] NULL,
	[ImpSaldoInsoluto] [real] NULL,
	[Pago_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[DoctoRelacionado]  WITH CHECK ADD  CONSTRAINT [Pago_DoctoRelacionado] FOREIGN KEY([Pago_Id])
REFERENCES [dbo].[Pago] ([Pago_Id])
GO
ALTER TABLE [dbo].[DoctoRelacionado] CHECK CONSTRAINT [Pago_DoctoRelacionado]
GO
