USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[HorasExtra]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HorasExtra](
	[Dias] [int] NOT NULL,
	[TipoHoras] [text] NULL,
	[HorasExtra] [int] NOT NULL,
	[ImportePagado] [real] NOT NULL,
	[Percepcion_Id] [int] NULL,
	[UUID] [varchar](900) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[HorasExtra]  WITH CHECK ADD  CONSTRAINT [Percepcion_HorasExtra] FOREIGN KEY([Percepcion_Id])
REFERENCES [dbo].[Percepcion] ([Percepcion_Id])
GO
ALTER TABLE [dbo].[HorasExtra] CHECK CONSTRAINT [Percepcion_HorasExtra]
GO
