USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Parte]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parte](
	[ClaveProdServ] [text] NULL,
	[NoIdentificacion] [varchar](100) NULL,
	[Cantidad] [real] NOT NULL,
	[Unidad] [varchar](20) NULL,
	[Descripcion] [varchar](1000) NOT NULL,
	[ValorUnitario] [real] NULL,
	[Importe] [real] NULL,
	[Parte_Id] [int] NOT NULL,
	[Concepto_Id] [int] NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_Parte] PRIMARY KEY CLUSTERED 
(
	[Parte_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Parte]  WITH CHECK ADD  CONSTRAINT [Concepto_Parte] FOREIGN KEY([Concepto_Id])
REFERENCES [dbo].[Concepto] ([Concepto_Id])
GO
ALTER TABLE [dbo].[Parte] CHECK CONSTRAINT [Concepto_Parte]
GO
