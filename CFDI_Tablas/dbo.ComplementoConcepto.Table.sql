USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[ComplementoConcepto]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComplementoConcepto](
	[Concepto_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ComplementoConcepto]  WITH CHECK ADD  CONSTRAINT [Concepto_ComplementoConcepto] FOREIGN KEY([Concepto_Id])
REFERENCES [dbo].[Concepto] ([Concepto_Id])
GO
ALTER TABLE [dbo].[ComplementoConcepto] CHECK CONSTRAINT [Concepto_ComplementoConcepto]
GO
