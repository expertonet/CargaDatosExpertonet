USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[CfdiRelacionados]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CfdiRelacionados](
	[TipoRelacion] [text] NULL,
	[CfdiRelacionados_Id] [int] NOT NULL,
	[Comprobante_Id] [int] NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_CfdiRelacionados] PRIMARY KEY CLUSTERED 
(
	[CfdiRelacionados_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[CfdiRelacionados]  WITH CHECK ADD  CONSTRAINT [Comprobante_CfdiRelacionados] FOREIGN KEY([Comprobante_Id])
REFERENCES [dbo].[Comprobante] ([Comprobante_Id])
GO
ALTER TABLE [dbo].[CfdiRelacionados] CHECK CONSTRAINT [Comprobante_CfdiRelacionados]
GO
