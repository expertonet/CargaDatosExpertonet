USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[TimbreFiscalDigital]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimbreFiscalDigital](
	[Version] [text] NULL,
	[FechaTimbrado] [datetime] NOT NULL,
	[RfcProvCertif] [text] NULL,
	[Leyenda] [varchar](150) NULL,
	[SelloCFD] [text] NULL,
	[NoCertificadoSAT] [text] NULL,
	[SelloSAT] [text] NULL,
	[Complemento_Id] [int] NOT NULL,
	[UUID] [varchar](900) NULL,
PRIMARY KEY CLUSTERED 
(
	[Complemento_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[TimbreFiscalDigital]  WITH CHECK ADD  CONSTRAINT [Complemento_TimbreFiscalDigital] FOREIGN KEY([Complemento_Id])
REFERENCES [dbo].[Complemento] ([Complemento_Id])
GO
ALTER TABLE [dbo].[TimbreFiscalDigital] CHECK CONSTRAINT [Complemento_TimbreFiscalDigital]
GO
