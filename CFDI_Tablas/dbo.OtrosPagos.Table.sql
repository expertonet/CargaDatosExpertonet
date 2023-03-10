USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[OtrosPagos]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtrosPagos](
	[OtrosPagos_Id] [int] NOT NULL,
	[Nomina_Id] [int] NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_OtrosPagos] PRIMARY KEY CLUSTERED 
(
	[OtrosPagos_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OtrosPagos]  WITH CHECK ADD  CONSTRAINT [Nomina_OtrosPagos] FOREIGN KEY([Nomina_Id])
REFERENCES [dbo].[Nomina] ([Nomina_Id])
GO
ALTER TABLE [dbo].[OtrosPagos] CHECK CONSTRAINT [Nomina_OtrosPagos]
GO
