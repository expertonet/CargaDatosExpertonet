USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[SubContratacion]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubContratacion](
	[RfcLabora] [varchar](13) NOT NULL,
	[PorcentajeTiempo] [real] NOT NULL,
	[Receptor_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SubContratacion]  WITH CHECK ADD  CONSTRAINT [Receptor_SubContratacion] FOREIGN KEY([Receptor_Id])
REFERENCES [dbo].[ReceptorNomina] ([Receptor_Id])
GO
ALTER TABLE [dbo].[SubContratacion] CHECK CONSTRAINT [Receptor_SubContratacion]
GO
