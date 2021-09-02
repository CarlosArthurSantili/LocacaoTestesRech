CREATE TABLE [dbo].[TBTaxaSelecionada] (
    [ID] INT NOT NULL IDENTITY, 
    [Locacao_Id] INT NOT NULL,
    [Taxa_Id]    INT NOT NULL,
    CONSTRAINT [FK_TBLocacao_TBTaxasServicos_TBLocacao] FOREIGN KEY ([Locacao_Id]) REFERENCES [dbo].[TBLocacao] ([Id]),
    CONSTRAINT [FK_TBLocacao_TBTaxasServicos_TBTaxasServicos] FOREIGN KEY ([Taxa_Id]) REFERENCES [dbo].[TBTaxa] ([Id]), 
    CONSTRAINT [PK_TBTaxaSelecionada] PRIMARY KEY ([Id])
);

