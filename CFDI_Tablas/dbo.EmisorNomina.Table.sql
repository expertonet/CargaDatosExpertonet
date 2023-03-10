USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[EmisorNomina]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmisorNomina](
	[Curp] [text] NULL,
	[RegistroPatronal] [varchar](20) NULL,
	[RfcPatronOrigen] [varchar](13) NULL,
	[Emisor_Id] [int] NOT NULL,
	[Nomina_Id] [int] NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_Emisor] PRIMARY KEY CLUSTERED 
(
	[Emisor_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmisorNomina]  WITH CHECK ADD  CONSTRAINT [Nomina_Emisor] FOREIGN KEY([Nomina_Id])
REFERENCES [dbo].[Nomina] ([Nomina_Id])
GO
ALTER TABLE [dbo].[EmisorNomina] CHECK CONSTRAINT [Nomina_Emisor]
GO
