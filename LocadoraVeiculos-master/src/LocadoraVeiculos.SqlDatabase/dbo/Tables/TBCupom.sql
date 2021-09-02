CREATE TABLE [dbo].[TBCupom] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Nome]         VARCHAR (100) NOT NULL,
    [Valor]        INT           NOT NULL,
    [DataValidade] DATE          NOT NULL,
    [Parceiro_Id]  INT           NOT NULL,
    [ValorMinimo]  DECIMAL (18)  NOT NULL,
    [Tipo]         TINYINT       NULL,
    CONSTRAINT [PK__TBCupons__3214EC27818D6E96] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBCupons_TBParceiros] FOREIGN KEY ([Parceiro_Id]) REFERENCES [dbo].[TBParceiro] ([Id])
);

