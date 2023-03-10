USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Traslados]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Traslados](
	[Traslados_Id] [int] NOT NULL,
	[Impuestos_Id] [int] NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_Traslados] PRIMARY KEY CLUSTERED 
(
	[Traslados_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Traslados]  WITH CHECK ADD  CONSTRAINT [Impuestos_Traslados] FOREIGN KEY([Impuestos_Id])
REFERENCES [dbo].[Impuestos] ([Impuestos_Id])
GO
ALTER TABLE [dbo].[Traslados] CHECK CONSTRAINT [Impuestos_Traslados]
GO
