USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Retenciones]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Retenciones](
	[Retenciones_Id] [int] NOT NULL,
	[Impuestos_Id] [int] NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_Retenciones] PRIMARY KEY CLUSTERED 
(
	[Retenciones_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Retenciones]  WITH CHECK ADD  CONSTRAINT [Impuestos_Retenciones] FOREIGN KEY([Impuestos_Id])
REFERENCES [dbo].[Impuestos] ([Impuestos_Id])
GO
ALTER TABLE [dbo].[Retenciones] CHECK CONSTRAINT [Impuestos_Retenciones]
GO
