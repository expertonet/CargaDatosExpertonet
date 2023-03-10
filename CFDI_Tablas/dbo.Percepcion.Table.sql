USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Percepcion]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Percepcion](
	[TipoPercepcion] [text] NULL,
	[Clave] [varchar](15) NOT NULL,
	[Concepto] [varchar](100) NOT NULL,
	[ImporteGravado] [real] NOT NULL,
	[ImporteExento] [real] NOT NULL,
	[Percepcion_Id] [int] NOT NULL,
	[Percepciones_Id] [int] NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_Percepcion] PRIMARY KEY CLUSTERED 
(
	[Percepcion_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Percepcion]  WITH CHECK ADD  CONSTRAINT [Percepciones_Percepcion] FOREIGN KEY([Percepciones_Id])
REFERENCES [dbo].[Percepciones] ([Percepciones_Id])
GO
ALTER TABLE [dbo].[Percepcion] CHECK CONSTRAINT [Percepciones_Percepcion]
GO
