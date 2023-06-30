CREATE TABLE [dbo].[TBTema] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Nome]  VARCHAR (300) NOT NULL,
    [Valor] DECIMAL (18)  NOT NULL,
    CONSTRAINT [PK_TBTema] PRIMARY KEY CLUSTERED ([Id] ASC)
);

