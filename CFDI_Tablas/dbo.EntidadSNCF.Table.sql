USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[EntidadSNCF]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntidadSNCF](
	[OrigenRecurso] [text] NULL,
	[MontoRecursoPropio] [real] NULL,
	[Emisor_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[EntidadSNCF]  WITH CHECK ADD  CONSTRAINT [Emisor_EntidadSNCF] FOREIGN KEY([Emisor_Id])
REFERENCES [dbo].[EmisorNomina] ([Emisor_Id])
GO
ALTER TABLE [dbo].[EntidadSNCF] CHECK CONSTRAINT [Emisor_EntidadSNCF]
GO
