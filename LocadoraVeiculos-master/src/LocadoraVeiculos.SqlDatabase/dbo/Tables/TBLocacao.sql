CREATE TABLE [dbo].[TBLocacao] (
    [Id]                     INT          IDENTITY (1, 1) NOT NULL,
    [Funcionario_Id]         INT          NOT NULL,
    [Veiculo_Id]             INT          NOT NULL,
    [Condutor_Id]            INT          NOT NULL,
    [PlanoCobranca_Id]       INT          NOT NULL,
    [MarcadorCombustivel]    TINYINT      NULL,
    [DataLocacao]            DATE         NOT NULL,
    [DataDevolucaoPrevista]  DATE         NOT NULL,
    [DataDevolucaoRealizada] DATE         NULL,
    [QuilometragemPercorrida]    INT NULL,
    [EmAberto]               TINYINT      NOT NULL,
    [Cupom_Id]               INT          NULL,
    CONSTRAINT [PK_TBLocacao] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBLocacao_TBCondutor] FOREIGN KEY ([Condutor_Id]) REFERENCES [dbo].[TBCondutor] ([Id]),
    CONSTRAINT [FK_TBLocacao_TBCupons] FOREIGN KEY ([Cupom_Id]) REFERENCES [dbo].[TBCupom] ([Id]),
    CONSTRAINT [FK_TBLocacao_TBFuncionario] FOREIGN KEY ([Funcionario_Id]) REFERENCES [dbo].[TBFuncionario] ([Id]),
    CONSTRAINT [FK_TBLocacao_TBPlanoCobranca] FOREIGN KEY ([PlanoCobranca_Id]) REFERENCES [dbo].[TBPlanoCobranca] ([Id]),
    CONSTRAINT [FK_TBLocacao_TBVeiculos] FOREIGN KEY ([Veiculo_Id]) REFERENCES [dbo].[TBVeiculo] ([Id])
);

