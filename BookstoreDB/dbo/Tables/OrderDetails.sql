CREATE TABLE [dbo].[OrderDetails] (
    [OrderDetailID] INT IDENTITY (1, 1) NOT NULL,
    [BookstoreID]   INT NOT NULL,
    [Quantity]      INT NOT NULL,
    [BookID]        INT NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([OrderDetailID] ASC),
    CONSTRAINT [FK_OrderDetails_OrderDetails] FOREIGN KEY ([OrderDetailID]) REFERENCES [dbo].[OrderDetails] ([OrderDetailID])
);

