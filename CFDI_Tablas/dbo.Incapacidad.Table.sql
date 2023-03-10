USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Incapacidad]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incapacidad](
	[DiasIncapacidad] [int] NOT NULL,
	[TipoIncapacidad] [text] NULL,
	[ImporteMonetario] [real] NULL,
	[Incapacidades_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Incapacidad]  WITH CHECK ADD  CONSTRAINT [Incapacidades_Incapacidad] FOREIGN KEY([Incapacidades_Id])
REFERENCES [dbo].[Incapacidades] ([Incapacidades_Id])
GO
ALTER TABLE [dbo].[Incapacidad] CHECK CONSTRAINT [Incapacidades_Incapacidad]
GO
