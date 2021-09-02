CREATE TABLE [dbo].[TBVeiculo] (
    [Id]                  INT          IDENTITY (1, 1) NOT NULL,
    [Placa]               VARCHAR (50) NOT NULL,
    [Fabricante]          VARCHAR (50) NOT NULL,
    [QtdLitrosTanque]     INT          NOT NULL,
    [QtdPortas]           INT          NULL,
    [NumeroChassi]        VARCHAR (50) NULL,
    [Cor]                 VARCHAR (50) NULL,
    [CapacidadeOcupantes] INT          NULL,
    [AnoFabricacao]       INT          NULL,
    [TamanhoPortaMalas]   VARCHAR (50) NULL,
    [TipoCombustivel]     VARCHAR (50) NOT NULL,
    [GrupoVeiculo_Id]     INT          NOT NULL,
    [Imagem]              IMAGE        NULL,
    [Modelo]              VARCHAR (50) NOT NULL,
    [Quilometragem]       FLOAT (53)   NOT NULL,
    CONSTRAINT [PK_TBVeiculos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBVeiculos_Categorias] FOREIGN KEY ([GrupoVeiculo_Id]) REFERENCES [dbo].[TBGrupoVeiculo] ([Id])
);

