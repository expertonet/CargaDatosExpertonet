USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Concepto]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Concepto](
	[ClaveProdServ] [text] NULL,
	[NoIdentificacion] [varchar](100) NULL,
	[Cantidad] [real] NOT NULL,
	[ClaveUnidad] [text] NULL,
	[Unidad] [varchar](20) NULL,
	[Descripcion] [varchar](1000) NOT NULL,
	[ValorUnitario] [real] NOT NULL,
	[Importe] [real] NOT NULL,
	[Descuento] [real] NULL,
	[Concepto_Id] [int] NOT NULL,
	[Conceptos_Id] [int] NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_Concepto] PRIMARY KEY CLUSTERED 
(
	[Concepto_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Concepto]  WITH CHECK ADD  CONSTRAINT [Conceptos_Concepto] FOREIGN KEY([Conceptos_Id])
REFERENCES [dbo].[Conceptos] ([Conceptos_Id])
GO
ALTER TABLE [dbo].[Concepto] CHECK CONSTRAINT [Conceptos_Concepto]
GO
