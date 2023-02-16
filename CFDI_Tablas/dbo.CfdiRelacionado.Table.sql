USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[CfdiRelacionado]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CfdiRelacionado](
	[UUID] [text] NULL,
	[CfdiRelacionados_Id] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[CfdiRelacionado]  WITH CHECK ADD  CONSTRAINT [CfdiRelacionados_CfdiRelacionado] FOREIGN KEY([CfdiRelacionados_Id])
REFERENCES [dbo].[CfdiRelacionados] ([CfdiRelacionados_Id])
GO
ALTER TABLE [dbo].[CfdiRelacionado] CHECK CONSTRAINT [CfdiRelacionados_CfdiRelacionado]
GO
