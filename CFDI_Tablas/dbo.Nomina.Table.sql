USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Nomina]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nomina](
	[Version] [text] NULL,
	[TipoNomina] [text] NULL,
	[FechaPago] [datetime] NOT NULL,
	[FechaInicialPago] [datetime] NOT NULL,
	[FechaFinalPago] [datetime] NOT NULL,
	[NumDiasPagados] [real] NOT NULL,
	[TotalPercepciones] [real] NULL,
	[TotalDeducciones] [real] NULL,
	[TotalOtrosPagos] [real] NULL,
	[Nomina_Id] [int] NOT NULL,
	[Complemento_Id] [int] NOT NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_Nomina] PRIMARY KEY CLUSTERED 
(
	[Nomina_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Nomina]  WITH CHECK ADD  CONSTRAINT [Complemento_Nomina] FOREIGN KEY([Complemento_Id])
REFERENCES [dbo].[Complemento] ([Complemento_Id])
GO
ALTER TABLE [dbo].[Nomina] CHECK CONSTRAINT [Complemento_Nomina]
GO
