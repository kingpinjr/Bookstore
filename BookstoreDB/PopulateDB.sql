/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET IDENTITY_INSERT [dbo].[Author] ON 
GO
INSERT [dbo].[Author] ([AuthorID], [FirstName], [LastName], [Description]) VALUES (1, N'John', N'Doe', N'vsdkvn')
GO
INSERT [dbo].[Author] ([AuthorID], [FirstName], [LastName], [Description]) VALUES (2, N'Jane', N'Doe', N'lksdcns')
GO
INSERT [dbo].[Author] ([AuthorID], [FirstName], [LastName], [Description]) VALUES (3, N'Sarah', N'Smith', N'cool girl')
GO
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Bookstore] ON 
GO
INSERT [dbo].[Bookstore] ([BookstoreID], [BookstoreName], [City], [State], [PostalCode], [Address], [PhoneNumber]) VALUES (1, N'Barnes & Noble', N'Tyler', N'Texas', 75703, N'4916 S Broadway Ave', N'9035343996')
GO
INSERT [dbo].[Bookstore] ([BookstoreID], [BookstoreName], [City], [State], [PostalCode], [Address], [PhoneNumber]) VALUES (2, N'Half Price Books', N'McKinney', N'Washington', 75682, N'8966 S Broadway Ave', N'9035618258')
GO
INSERT [dbo].[Bookstore] ([BookstoreID], [BookstoreName], [City], [State], [PostalCode], [Address], [PhoneNumber]) VALUES (3, N'Amazon', N'Allen', N'California', 35982, N'123 Main St', N'3569875216')
GO
SET IDENTITY_INSERT [dbo].[Bookstore] OFF
GO
SET IDENTITY_INSERT [dbo].[Genre] ON 
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (1, N'Horror')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (2, N'Romance')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (3, N'Fantasy')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (4, N'Non-Fiction')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (5, N'Science Fiction')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (6, N'Thriller')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (7, N'Comedy')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (8, N'Education')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (9, N'History')
GO
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Email], [Password], [PhoneNumber], [Address], [City], [State], [PostalCode], [isAdmin]) VALUES (1, N'a', N'a', N'a@gmail.com', N'$2a$13$R/acXwGqvU5FN1l0UFTREu1c/JNq9VznXaFApqEsxlT7OAdWyghaG', N'1234567890', N'1333 Pearl St', N'Nacogdoches', N'Texas', 75961, 0)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO

