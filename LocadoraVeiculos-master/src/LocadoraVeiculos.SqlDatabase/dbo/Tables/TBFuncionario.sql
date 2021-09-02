CREATE TABLE [dbo].[TBFuncionario] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Nome]         VARCHAR (50) NULL,
    [Usuario]      VARCHAR (50) NULL,
    [Senha]        VARCHAR (50) NULL,
    [DataAdmissao] DATE         NULL,
    [Salario]      NUMERIC (18) NULL,
    CONSTRAINT [PK_TBFuncionario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

