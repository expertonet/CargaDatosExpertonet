USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[RetencionesNodo0]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RetencionesNodo0](
	[Retenciones_Id] [int] NOT NULL,
	[Impuestos_Id] [int] NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_RetencionesNodo0] PRIMARY KEY CLUSTERED 
(
	[Retenciones_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RetencionesNodo0]  WITH CHECK ADD  CONSTRAINT [ImpuestosNodo0_RetencionesNodo0] FOREIGN KEY([Impuestos_Id])
REFERENCES [dbo].[ImpuestosNodo0] ([Impuestos_Id])
GO
ALTER TABLE [dbo].[RetencionesNodo0] CHECK CONSTRAINT [ImpuestosNodo0_RetencionesNodo0]
GO
