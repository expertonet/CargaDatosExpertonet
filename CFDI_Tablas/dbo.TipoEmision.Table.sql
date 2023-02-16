USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[TipoEmision]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEmision](
	[TipoEmision_Id] [int] NOT NULL,
	[TipoEmision] [varchar](50) NULL,
 CONSTRAINT [PK_TipoEmision] PRIMARY KEY CLUSTERED 
(
	[TipoEmision_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
