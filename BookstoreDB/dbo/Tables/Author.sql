CREATE TABLE [dbo].[Author] (
    [AuthorID]    INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (50)  NOT NULL,
    [LastName]    NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED ([AuthorID] ASC)
);



