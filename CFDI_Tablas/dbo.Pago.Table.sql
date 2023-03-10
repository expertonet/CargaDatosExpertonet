USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[FechaPago] [datetime] NOT NULL,
	[FormaDePagoP] [text] NULL,
	[MonedaP] [text] NULL,
	[TipoCambioP] [real] NULL,
	[Monto] [real] NOT NULL,
	[NumOperacion] [varchar](100) NULL,
	[RfcEmisorCtaOrd] [varchar](13) NULL,
	[NomBancoOrdExt] [varchar](300) NULL,
	[CtaOrdenante] [varchar](50) NULL,
	[RfcEmisorCtaBen] [text] NULL,
	[CtaBeneficiario] [varchar](50) NULL,
	[TipoCadPago] [text] NULL,
	[CertPago] [varbinary](1) NULL,
	[CadPago] [varchar](80) NULL,
	[SelloPago] [varbinary](1) NULL,
	[Pago_Id] [int] NOT NULL,
	[Pagos_Id] [int] NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[Pago_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [Pagos_Pago] FOREIGN KEY([Pagos_Id])
REFERENCES [dbo].[Pagos] ([Pagos_Id])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [Pagos_Pago]
GO
