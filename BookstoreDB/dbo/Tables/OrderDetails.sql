CREATE TABLE [dbo].[OrderDetails] (
    [OrderDetailID] INT IDENTITY (1, 1) NOT NULL,
    [BookstoreID]   INT NOT NULL,
    [Quantity]      INT NOT NULL,
    [BookID]        INT NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([OrderDetailID] ASC),
    CONSTRAINT [FK_OrderDetails_Book] FOREIGN KEY ([BookID]) REFERENCES [dbo].[Book] ([BookID]),
    CONSTRAINT [FK_OrderDetails_Bookstore] FOREIGN KEY ([BookstoreID]) REFERENCES [dbo].[Bookstore] ([BookstoreID])
);



