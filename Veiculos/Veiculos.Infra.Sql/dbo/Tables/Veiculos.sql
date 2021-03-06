﻿CREATE TABLE [dbo].[Veiculos]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Nome] VARCHAR(50) NOT NULL,
	[Ano] INT NOT NULL,
	[TipoVeiculoId] INT NOT NULL
	CONSTRAINT [PK_Veiculos] PRIMARY KEY CLUSTERED ([Id] ASC)
	CONSTRAINT [FK_TipoVeiculo] FOREIGN KEY ([TipoVeiculoId]) REFERENCES [dbo].[TipoVeiculo] ([Id])
)
