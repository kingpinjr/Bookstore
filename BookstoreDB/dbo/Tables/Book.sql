CREATE TABLE [dbo].[Book] (
    [BookID]          INT             IDENTITY (1, 1) NOT NULL,
    [Title]           NVARCHAR (255)  NOT NULL,
    [Description]     NVARCHAR (MAX)  NOT NULL,
    [Price]           SMALLMONEY      NOT NULL,
    [AuthorID]        INT             NOT NULL,
    [BookstoreID]     INT             NOT NULL,
    [Publisher]       NVARCHAR (255)  NOT NULL,
    [PublicationDate] DATE            NOT NULL,
    [ISBN]            NVARCHAR (14)   NOT NULL,
    [Stock]           INT             NOT NULL,
    [PictureURL]      NVARCHAR (2048) NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([BookID] ASC),
    CONSTRAINT [FK_Book_Author] FOREIGN KEY ([AuthorID]) REFERENCES [dbo].[Author] ([AuthorID]),
    CONSTRAINT [FK_Book_Bookstore] FOREIGN KEY ([BookstoreID]) REFERENCES [dbo].[Bookstore] ([BookstoreID])
);









