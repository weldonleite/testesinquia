USE [MOV]
GO

/****** Object:  Table [dbo].[MOVIMENTO_MANUAL]    Script Date: 03/07/2018 23:47:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MOVIMENTO_MANUAL](
	[DAT_MES] [int] NOT NULL,
	[DAT_ANO] [int] NOT NULL,
	[NUM_LANCAMENTO] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[COD_PRODUTO] [char](4) NOT NULL,
	[COD_COSIF] [char](11) NOT NULL,
	[VAL_VALOR] [numeric](18, 2) NOT NULL,
	[DES_DESCRICAO] [varchar](50) NOT NULL,
	[DAT_MOVIMENTO] [smalldatetime] NOT NULL,
	[COD_USUARIO] [varchar](15) NOT NULL,
 CONSTRAINT [PK_MOVIMENTO_MANUAL] PRIMARY KEY CLUSTERED 
(
	[DAT_MES] ASC,
	[DAT_ANO] ASC,
	[NUM_LANCAMENTO] ASC,
	[COD_PRODUTO] ASC,
	[COD_COSIF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[MOVIMENTO_MANUAL]  WITH CHECK ADD  CONSTRAINT [FK_MOVIMENTO_MANUAL_PRODUTO] FOREIGN KEY([COD_PRODUTO])
REFERENCES [dbo].[PRODUTO] ([COD_PRODUTO])
GO

ALTER TABLE [dbo].[MOVIMENTO_MANUAL] CHECK CONSTRAINT [FK_MOVIMENTO_MANUAL_PRODUTO]
GO

ALTER TABLE [dbo].[MOVIMENTO_MANUAL]  WITH CHECK ADD  CONSTRAINT [FK_MOVIMENTO_MANUAL_PRODUTO_COSIF] FOREIGN KEY([COD_PRODUTO], [COD_COSIF])
REFERENCES [dbo].[PRODUTO_COSIF] ([COD_PRODUTO], [COD_COSIF])
GO

ALTER TABLE [dbo].[MOVIMENTO_MANUAL] CHECK CONSTRAINT [FK_MOVIMENTO_MANUAL_PRODUTO_COSIF]
GO


