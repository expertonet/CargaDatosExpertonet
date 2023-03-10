USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Complemento]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Complemento](
	[Comprobante_Id] [int] NULL,
	[Complemento_Id] [int] NOT NULL,
	[UUID] [varchar](900) NULL,
PRIMARY KEY CLUSTERED 
(
	[Complemento_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Complemento]  WITH CHECK ADD  CONSTRAINT [Comprobante_Complemento] FOREIGN KEY([Comprobante_Id])
REFERENCES [dbo].[Comprobante] ([Comprobante_Id])
GO
ALTER TABLE [dbo].[Complemento] CHECK CONSTRAINT [Comprobante_Complemento]
GO
