CREATE TABLE [dbo].[TBItem] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Descricao] VARCHAR (MAX) NOT NULL,
    [Valor]     DECIMAL (18)  NOT NULL,
    CONSTRAINT [PK_TBItem] PRIMARY KEY CLUSTERED ([Id] ASC)
);

