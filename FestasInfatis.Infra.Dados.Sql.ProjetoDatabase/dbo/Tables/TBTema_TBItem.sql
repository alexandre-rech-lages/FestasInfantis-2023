CREATE TABLE [dbo].[TBTema_TBItem] (
    [Tema_Id] INT NOT NULL,
    [Item_Id] INT NOT NULL,
    CONSTRAINT [FK_TBTema_TBItem_TBItem] FOREIGN KEY ([Item_Id]) REFERENCES [dbo].[TBItem] ([Id]),
    CONSTRAINT [FK_TBTema_TBItemTBTema] FOREIGN KEY ([Tema_Id]) REFERENCES [dbo].[TBTema] ([Id])
);

