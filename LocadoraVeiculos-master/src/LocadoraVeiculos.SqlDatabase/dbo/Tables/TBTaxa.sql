CREATE TABLE [dbo].[TBTaxa] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (100) NOT NULL,
    [Valor]    DECIMAL (18)  NULL,
    [TipoTaxa] TINYINT       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

