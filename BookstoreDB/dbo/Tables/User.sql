CREATE TABLE [dbo].[User] (
    [UserID]      INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]   VARCHAR (255) NOT NULL,
    [LastName]    VARCHAR (255) NOT NULL,
    [Email]       VARCHAR (255) NOT NULL,
    [Password]    VARCHAR (255) NOT NULL,
    [PhoneNumber] VARCHAR (255) NOT NULL,
    [Address]     VARCHAR (255) NULL,
    [City]        VARCHAR (255) NULL,
    [State]       VARCHAR (255) NULL,
    [PostalCode]  INT           NULL,
    [isAdmin]     BIT           NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

