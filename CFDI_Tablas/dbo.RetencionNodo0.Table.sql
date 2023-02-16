USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[RetencionNodo0]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RetencionNodo0](
	[Impuesto] [text] NULL,
	[Importe] [real] NOT NULL,
	[Retenciones_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[RetencionNodo0]  WITH CHECK ADD  CONSTRAINT [RetencionesNodo0_RetencionNodo0] FOREIGN KEY([Retenciones_Id])
REFERENCES [dbo].[RetencionesNodo0] ([Retenciones_Id])
GO
ALTER TABLE [dbo].[RetencionNodo0] CHECK CONSTRAINT [RetencionesNodo0_RetencionNodo0]
GO
