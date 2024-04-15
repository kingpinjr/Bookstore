CREATE TABLE [dbo].[BookGenre] (
    [BookID]  INT NOT NULL,
    [GenreID] INT NOT NULL,
    CONSTRAINT [PK_BookGenre] PRIMARY KEY CLUSTERED ([BookID] ASC, [GenreID] ASC),
    CONSTRAINT [FK_BookGenre_Book] FOREIGN KEY ([BookID]) REFERENCES [dbo].[Book] ([BookID]),
    CONSTRAINT [FK_BookGenre_Genre] FOREIGN KEY ([GenreID]) REFERENCES [dbo].[Genre] ([GenreID])
);

