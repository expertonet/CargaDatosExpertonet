USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[OtroPago]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtroPago](
	[TipoOtroPago] [text] NULL,
	[Clave] [varchar](15) NOT NULL,
	[Concepto] [varchar](100) NOT NULL,
	[Importe] [real] NOT NULL,
	[OtroPago_Id] [int] NOT NULL,
	[OtrosPagos_Id] [int] NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_OtroPago] PRIMARY KEY CLUSTERED 
(
	[OtroPago_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[OtroPago]  WITH CHECK ADD  CONSTRAINT [OtrosPagos_OtroPago] FOREIGN KEY([OtrosPagos_Id])
REFERENCES [dbo].[OtrosPagos] ([OtrosPagos_Id])
GO
ALTER TABLE [dbo].[OtroPago] CHECK CONSTRAINT [OtrosPagos_OtroPago]
GO
