USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Addenda]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addenda](
	[Comprobante_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Addenda]  WITH CHECK ADD  CONSTRAINT [Comprobante_Addenda] FOREIGN KEY([Comprobante_Id])
REFERENCES [dbo].[Comprobante] ([Comprobante_Id])
GO
ALTER TABLE [dbo].[Addenda] CHECK CONSTRAINT [Comprobante_Addenda]
GO
