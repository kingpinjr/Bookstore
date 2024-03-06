CREATE TABLE [dbo].[Bookstore] (
    [BookstoreID]   INT           IDENTITY (1, 1) NOT NULL,
    [BookstoreName] NVARCHAR (50) NOT NULL,
    [City]          NVARCHAR (50) NOT NULL,
    [State]         NVARCHAR (50) NOT NULL,
    [PostalCode]    INT           NOT NULL,
    [Address]       NVARCHAR (50) NOT NULL,
    [PhoneNumber]   VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_Bookstore] PRIMARY KEY CLUSTERED ([BookstoreID] ASC)
);

