USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[ImpuestosNodo0]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImpuestosNodo0](
	[TotalImpuestosRetenidos] [real] NULL,
	[TotalImpuestosTrasladados] [real] NULL,
	[Impuestos_Id] [int] NOT NULL,
	[Pago_Id] [int] NULL,
	[Comprobante_Id] [int] NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_ImpuestosNodo0] PRIMARY KEY CLUSTERED 
(
	[Impuestos_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ImpuestosNodo0]  WITH CHECK ADD  CONSTRAINT [Comprobante_ImpuestosNodo0] FOREIGN KEY([Comprobante_Id])
REFERENCES [dbo].[Comprobante] ([Comprobante_Id])
GO
ALTER TABLE [dbo].[ImpuestosNodo0] CHECK CONSTRAINT [Comprobante_ImpuestosNodo0]
GO
