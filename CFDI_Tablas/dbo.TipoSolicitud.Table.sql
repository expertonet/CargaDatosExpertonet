USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[TipoSolicitud]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoSolicitud](
	[TipoSolicitud_Id] [int] NOT NULL,
	[TipoSolicitud] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoSolicitud_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
