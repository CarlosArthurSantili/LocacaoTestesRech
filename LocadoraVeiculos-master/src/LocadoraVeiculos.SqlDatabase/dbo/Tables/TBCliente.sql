CREATE TABLE [dbo].[TBCliente] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Nome]       VARCHAR (80)  NOT NULL,
    [Endereco]   VARCHAR (100) NOT NULL,
    [Telefone]   VARCHAR (30)  NOT NULL,
    [RG]         VARCHAR (30)  NULL,
    [CPF]        VARCHAR (30)  NULL,
    [CNPJ]       VARCHAR (30)  NULL,
    [TipoPessoa] TINYINT       NULL,
    CONSTRAINT [PK_TBClientes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

