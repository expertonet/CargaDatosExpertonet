USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Impuestos]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Impuestos](
	[Impuestos_Id] [int] NOT NULL,
	[Concepto_Id] [int] NULL,
	[Comprobante_Id] [int] NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_Impuestos] PRIMARY KEY CLUSTERED 
(
	[Impuestos_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Impuestos]  WITH CHECK ADD  CONSTRAINT [Comprobante_Impuestos] FOREIGN KEY([Comprobante_Id])
REFERENCES [dbo].[Comprobante] ([Comprobante_Id])
GO
ALTER TABLE [dbo].[Impuestos] CHECK CONSTRAINT [Comprobante_Impuestos]
GO
ALTER TABLE [dbo].[Impuestos]  WITH CHECK ADD  CONSTRAINT [Concepto_Impuestos] FOREIGN KEY([Concepto_Id])
REFERENCES [dbo].[Concepto] ([Concepto_Id])
GO
ALTER TABLE [dbo].[Impuestos] CHECK CONSTRAINT [Concepto_Impuestos]
GO
