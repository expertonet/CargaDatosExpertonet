USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Pagos]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagos](
	[Version] [text] NULL,
	[Pagos_Id] [int] NOT NULL,
	[Complemento_Id] [int] NOT NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_Pagos] PRIMARY KEY CLUSTERED 
(
	[Pagos_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pagos]  WITH CHECK ADD  CONSTRAINT [Complemento_Pagos] FOREIGN KEY([Complemento_Id])
REFERENCES [dbo].[Complemento] ([Complemento_Id])
GO
ALTER TABLE [dbo].[Pagos] CHECK CONSTRAINT [Complemento_Pagos]
GO
