CREATE TABLE [dbo].[Order] (
    [OrderID]       INT             IDENTITY (1, 1) NOT NULL,
    [OrderDetailID] INT             NOT NULL,
    [CustomerID]    INT             NOT NULL,
    [OrderDate]     DATE            NOT NULL,
    [TotalPrice]    DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderID] ASC, [OrderDetailID] ASC),
    CONSTRAINT [FK_Order_OrderDetails] FOREIGN KEY ([OrderDetailID]) REFERENCES [dbo].[OrderDetails] ([OrderDetailID])
);

