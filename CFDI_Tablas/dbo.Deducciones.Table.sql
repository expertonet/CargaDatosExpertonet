USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Deducciones]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deducciones](
	[TotalOtrasDeducciones] [real] NULL,
	[TotalImpuestosRetenidos] [real] NULL,
	[Deducciones_Id] [int] NOT NULL,
	[Nomina_Id] [int] NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_Deducciones] PRIMARY KEY CLUSTERED 
(
	[Deducciones_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Deducciones]  WITH CHECK ADD  CONSTRAINT [Nomina_Deducciones] FOREIGN KEY([Nomina_Id])
REFERENCES [dbo].[Nomina] ([Nomina_Id])
GO
ALTER TABLE [dbo].[Deducciones] CHECK CONSTRAINT [Nomina_Deducciones]
GO
