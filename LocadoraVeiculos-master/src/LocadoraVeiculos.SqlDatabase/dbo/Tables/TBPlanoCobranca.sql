CREATE TABLE [dbo].[TBPlanoCobranca] (
    [Id]                       INT          IDENTITY (1, 1) NOT NULL,
    [ValorDia]                 DECIMAL (18) NULL,
    [KilometragemLivreInclusa] INT          NULL,
    [ValorKMRodado]            DECIMAL (18) NULL,
    [TipoPlano]                TINYINT      NULL,
    [GrupoVeiculo_Id]          INT          NULL,
    CONSTRAINT [PK_TBPlanoCobranca] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBPlanoCobranca_TBGrupoVeiculo] FOREIGN KEY ([GrupoVeiculo_Id]) REFERENCES [dbo].[TBGrupoVeiculo] ([Id])
);

