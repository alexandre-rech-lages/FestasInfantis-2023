CREATE TABLE [dbo].[TBAluguel] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [PorcentagemSinal]     DECIMAL (18)  NOT NULL,
    [PorcentagemDesconto]  DECIMAL (18)  NOT NULL,
    [DataPagamento]        DATETIME      NULL,
    [PagamentoConcluido]   BIT           NOT NULL,
    [Festa_Data]           DATETIME      NOT NULL,
    [Festa_HorarioInicio]  BIGINT        NOT NULL,
    [Festa_HorarioTermino] BIGINT        NOT NULL,
    [Endereco_Estado]      VARCHAR (300) NOT NULL,
    [Endereco_Cidade]      VARCHAR (300) NOT NULL,
    [Endereco_Bairro]      VARCHAR (300) NOT NULL,
    [Endereco_Rua]         VARCHAR (300) NOT NULL,
    [Endereco_Numero]      INT           NOT NULL,
    [Configuracao_PorcentagemDesconto]  DECIMAL (18)  NOT NULL DEFAULT 0,
    [Configuracao_PorcentagemMaxima]  DECIMAL (18)  NOT NULL DEFAULT 0,
    [Tema_Id]              INT           NOT NULL,
    [Cliente_Id]           INT           NOT NULL,

    CONSTRAINT [PK_TBAluguel] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBAluguel_TBCliente] FOREIGN KEY ([Cliente_Id]) REFERENCES [dbo].[TBCliente] ([Id]),
    CONSTRAINT [FK_TBAluguel_TBTema] FOREIGN KEY ([Tema_Id]) REFERENCES [dbo].[TBTema] ([Id])
);

