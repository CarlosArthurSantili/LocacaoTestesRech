CREATE TABLE [dbo].[TBCondutor] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [Nome]            VARCHAR (50) NOT NULL,
    [Endereco]        VARCHAR (80) NOT NULL,
    [Telefone]        VARCHAR (20) NOT NULL,
    [RG]              VARCHAR (15) NOT NULL,
    [CPF]             VARCHAR (20) NOT NULL,
    [CNH]             VARCHAR (30) NOT NULL,
    [DataValidadeCNH] DATE         NOT NULL,
    [Cliente_Id]      INT          NOT NULL,
    CONSTRAINT [PK_TBCondutor] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBCondutor_TBClientes] FOREIGN KEY ([Cliente_Id]) REFERENCES [dbo].[TBCliente] ([Id])
);

