USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[SubsidioAlEmpleo]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubsidioAlEmpleo](
	[SubsidioCausado] [real] NOT NULL,
	[OtroPago_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SubsidioAlEmpleo]  WITH CHECK ADD  CONSTRAINT [OtroPago_SubsidioAlEmpleo] FOREIGN KEY([OtroPago_Id])
REFERENCES [dbo].[OtroPago] ([OtroPago_Id])
GO
ALTER TABLE [dbo].[SubsidioAlEmpleo] CHECK CONSTRAINT [OtroPago_SubsidioAlEmpleo]
GO
