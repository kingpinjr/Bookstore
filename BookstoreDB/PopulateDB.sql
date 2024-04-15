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
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Email], [Password], [PhoneNumber], [Address], [City], [State], [PostalCode], [isAdmin]) VALUES (1, N'g', N'k', N'email@email.com', N'$2a$13$GfLt4o7fe4gcmK31LU2R5ubE5zsu3YADQK.TR3WXqvO9e.OD4dNWm', N'111111', N'111 doiajwd', N'al', N'tx', 84202, 0)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
