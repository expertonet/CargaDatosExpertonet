USE [TBN2021_CFDI3_33]
GO
/****** Object:  Table [dbo].[ReceptorNomina]    Script Date: 23/04/2022 07:35:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceptorNomina](
	[Curp] [text] NULL,
	[NumSeguridadSocial] [varchar](15) NULL,
	[FechaInicioRelLaboral] [datetime] NULL,
	[Antigüedad] [text] NULL,
	[TipoContrato] [text] NULL,
	[Sindicalizado] [text] NULL,
	[TipoJornada] [text] NULL,
	[TipoRegimen] [text] NULL,
	[NumEmpleado] [varchar](15) NOT NULL,
	[Departamento] [varchar](100) NULL,
	[Puesto] [varchar](100) NULL,
	[RiesgoPuesto] [text] NULL,
	[PeriodicidadPago] [text] NULL,
	[Banco] [text] NULL,
	[CuentaBancaria] [bigint] NULL,
	[SalarioBaseCotApor] [real] NULL,
	[SalarioDiarioIntegrado] [real] NULL,
	[ClaveEntFed] [text] NULL,
	[Receptor_Id] [int] NOT NULL,
	[Nomina_Id] [int] NULL,
	[UUID] [varchar](900) NULL,
 CONSTRAINT [PK_Receptor] PRIMARY KEY CLUSTERED 
(
	[Receptor_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ReceptorNomina]  WITH CHECK ADD  CONSTRAINT [Nomina_Receptor] FOREIGN KEY([Nomina_Id])
REFERENCES [dbo].[Nomina] ([Nomina_Id])
GO
ALTER TABLE [dbo].[ReceptorNomina] CHECK CONSTRAINT [Nomina_Receptor]
GO
