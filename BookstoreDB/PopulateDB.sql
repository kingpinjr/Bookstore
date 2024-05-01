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
INSERT [dbo].[Author] ([AuthorID], [FirstName], [LastName], [Description]) VALUES (1, N' Sarah ', N'Maas', N'Sarah Janet Maas is an American fantasy author known for her fantasy series Throne of Glass, A Court of Thorns and Roses, and Crescent City. As of 2022, she has sold over twelve million copies of her books and her work has been translated into 37 languages. ')
GO
INSERT [dbo].[Author] ([AuthorID], [FirstName], [LastName], [Description]) VALUES (2, N'Dot', N'Hutchison', N'Dot Hutchison has worked in retail, taught at a Boy Scout camp, and fought in human combat chessboards, but she''s most grateful that she can finally call writing work. When not immersed in the worlds-between-pages, she can frequently be found dancing around like an idiot, tracing stories in the stars, or waiting for storms to roll in from the ocean. She currently lives in Florida. A Wounded Name is her debut novel.')
GO
INSERT [dbo].[Author] ([AuthorID], [FirstName], [LastName], [Description]) VALUES (3, N'Osamu', N'Dazai', N'Shūji Tsushima, known by his pen name Osamu Dazai, was a Japanese novelist and author. A number of his most popular works, such as The Setting Sun and No Longer Human, are considered modern-day classics. His influences include Ryūnosuke Akutagawa, Murasaki Shikibu and Fyodor Dostoyevsky.')
GO
INSERT [dbo].[Author] ([AuthorID], [FirstName], [LastName], [Description]) VALUES (4, N'Genki', N'Kawamura', N'GENKI KAWAMURA is an internationally bestselling author. If Cats Disappeared from the World was his first novel and has sold over two million copies in Japan and has been translated into over fourteen different languages. His other novels are Million Dollar Man and April Come She Will. He has also written children''s picture books including Tinny & The Balloon, MOOM, and Patissier Monster. Kawamura occasionally produces, directs, and writes movies, and is a showrunner. He was a producer of the blockbuster anime film Your Name.')
GO
INSERT [dbo].[Author] ([AuthorID], [FirstName], [LastName], [Description]) VALUES (5, N'Jane', N'Austen', N'Jane Austen was an English novelist known primarily for her six novels, which implicitly interpret, critique, and comment upon the British landed gentry at the end of the 18th century. Austen''s plots often explore the dependence of women on marriage for the pursuit of favourable social standing and economic security.')
GO
INSERT [dbo].[Author] ([AuthorID], [FirstName], [LastName], [Description]) VALUES (6, N'Sylvia', N'Plath', N'Sylvia Plath was an American poet, novelist, and short story writer. She is credited with advancing the genre of confessional poetry and is best known for The Colossus and Other Poems, Ariel, and The Bell Jar, a semi-autobiographical novel published shortly before her suicide in 1963.')
GO
INSERT [dbo].[Author] ([AuthorID], [FirstName], [LastName], [Description]) VALUES (7, N'Stephen', N'King', N'Stephen Edwin King is an American author. Called the "King of Horror", he has also explored other genres, among them suspense, crime, science-fiction, fantasy and mystery. He has also written approximately 200 short stories, most of which have been published in collections.')
GO
INSERT [dbo].[Author] ([AuthorID], [FirstName], [LastName], [Description]) VALUES (8, N'Agatha', N'Christie', N'NULLDame Agatha Mary Clarissa Christie, Lady Mallowan, DBE was an English writer known for her 66 detective novels and 14 short story collections, particularly those revolving around fictional detectives Hercule Poirot and Miss Marple.')
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
SET IDENTITY_INSERT [dbo].[Book] ON 
GO
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Price], [AuthorID], [BookstoreID], [Publisher], [PublicationDate], [ISBN], [Stock], [PictureURL]) VALUES (1, N'A Court of Thorns and Roses', N'When nineteen-year-old huntress Feyre kills a wolf in the woods, a terrifying creature arrives to demand retribution. Dragged to a treacherous magical land she knows about only from legends, Feyre discovers that her captor is not truly a beast, but one of the lethal, immortal faeries who once ruled her world.

At least, he''s not a beast all the time.

As she adapts to her new home, her feelings for the faerie, Tamlin, transform from icy hostility into a fiery passion that burns through every lie she''s been told about the beautiful, dangerous world of the Fae. But something is not right in the faerie lands. An ancient, wicked shadow is growing, and Feyre must find a way to stop it, or doom Tamlin-and his world-forever.

From bestselling author Sarah J. Maas comes a seductive, breathtaking book that blends romance, adventure, and faerie lore into an unforgettable read.', 10.3700, 1, 2, N'Bloomsbury Publishing', CAST(N'2024-03-13' AS Date), N'979-8885797085', 3, N'https://m.media-amazon.com/images/I/81xBVvXlycL._SL1500_.jpg')
GO
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Price], [AuthorID], [BookstoreID], [Publisher], [PublicationDate], [ISBN], [Stock], [PictureURL]) VALUES (5, N'The Butterfly Garden', N'Near an isolated mansion lies a beautiful garden.

In this garden grow luscious flowers, shady trees…and a collection of precious “butterflies”―young women who have been kidnapped and intricately tattooed to resemble their namesakes. Overseeing it all is the Gardener, a brutal, twisted man obsessed with capturing and preserving his lovely specimens.

When the garden is discovered, a survivor is brought in for questioning. FBI agents Victor Hanoverian and Brandon Eddison are tasked with piecing together one of the most stomach-churning cases of their careers. But the girl, known only as Maya, proves to be a puzzle herself.

As her story twists and turns, slowly shedding light on life in the Butterfly Garden, Maya reveals old grudges, new saviors, and horrific tales of a man who’d go to any length to hold beauty captive. But the more she shares, the more the agents have to wonder what she’s still hiding…', 9.5900, 2, 1, N'Thomas & Mercer ', CAST(N'2016-06-01' AS Date), N'978-1503934719', 5, N'https://m.media-amazon.com/images/I/81i34roycwL._SL1500_.jpg')
GO
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Price], [AuthorID], [BookstoreID], [Publisher], [PublicationDate], [ISBN], [Stock], [PictureURL]) VALUES (9, N'No Longer Human', N'Portraying himself as a failure, the protagonist of Osamu Dazai''s No Longer Human narrates a seemingly normal life even while he feels himself incapable of understanding human beings. Oba Yozo''s attempts to reconcile himself to the world around him begin in early childhood, continue through high school, where he becomes a "clown" to mask his alienation, and eventually lead to a failed suicide attempt as an adult. Without sentimentality, he records the casual cruelties of life and its fleeting moments of human connection and tenderness.', 13.3200, 3, 3, N'New Directions', CAST(N'1973-01-17' AS Date), N'978-0811204811', 2, N'https://m.media-amazon.com/images/I/61vBJ41AO5L._SL1200_.jpg')
GO
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Price], [AuthorID], [BookstoreID], [Publisher], [PublicationDate], [ISBN], [Stock], [PictureURL]) VALUES (14, N'If Cats Disappeared From the World', N'This timeless tale from Genki Kawamura (producer of the Japanese blockbuster animated movie Your Name) is a moving story of loss and reconciliation, and of one man’s journey to discover what really matters most in life.

The young postman’s days are numbered. Estranged from his family and living alone with only his cat, Cabbage, to keep him company, he was unprepared for the doctor’s diagnosis that he has only months to live. But before he can tackle his bucket list, the devil shows up to make him an offer: In exchange for making one thing in the world disappear, the postman will be granted one extra day of life. And so begins a very strange week that brings the young postman and his beloved cat to the brink of existence.

With each object that disappears, the postman reflects on the life he’s lived, his joys and regrets, and the people he’s loved and lost.', 13.8100, 4, 2, N'Flatiron Books', CAST(N'2019-03-12' AS Date), N'978-1250294050', 7, N'https://m.media-amazon.com/images/I/91MIF5C6gvL._SL1500_.jpg')
GO
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Price], [AuthorID], [BookstoreID], [Publisher], [PublicationDate], [ISBN], [Stock], [PictureURL]) VALUES (17, N'Pride and Prejudice', N'Though her sisters are keen on finding men to marry, Elizabeth Bennet would rather wait for someone she loves - certainly not someone like Mr. Fitzwilliam Darcy, whom she finds to be smug and judgmental, in contrast to the charming George Wickham. But soon Elizabeth learns that her first impressions may not have been correct, and the quiet, genteel Mr. Darcy might be her true love after all.', 14.4900, 5, 1, N'Puffin Books', CAST(N'2024-02-13' AS Date), N'978-0593622452', 3, N'https://m.media-amazon.com/images/I/51s2Sl4NIxL._SY445_SX342_.jpg')
GO
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Price], [AuthorID], [BookstoreID], [Publisher], [PublicationDate], [ISBN], [Stock], [PictureURL]) VALUES (18, N'The Bell Jar', N'The Bell Jar chronicles the crack-up of Esther Greenwood: young, brilliant, beautiful, and enormously talented, but slowly going under—maybe for the last time. Sylvia Plath masterfully draws the reader into Esther’s breakdown with such intensity that Esther’s neurosis becomes completely understandable and even rational, as probable and accessible an experience as going to the movies. Such thorough exploration of the dark and harrowing corners of the psyche - and the profound collective loneliness that modern society has yet to find a solution for - is an extraordinary accomplishment, and has made The Bell Jar a haunting American classic.

This P.S. edition features extra insights into the book, including author interviews, recommended reading, and more.', 10.7900, 6, 3, N'Harper Perennial Modern Classics', CAST(N'2005-08-02' AS Date), N'978-0060837020', 6, N'https://m.media-amazon.com/images/I/81wUVpREPSL._SL1500_.jpg')
GO
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Price], [AuthorID], [BookstoreID], [Publisher], [PublicationDate], [ISBN], [Stock], [PictureURL]) VALUES (21, N'If it Bleeds', N'Readers adore Stephen King’s novels, and his novellas are their own dark treat, briefer but just as impactful and enduring as his longer fiction. Many of his novellas have been made into iconic films, including “The Body” (Stand by Me) and “Rita Hayworth and Shawshank Redemption” (Shawshank Redemption).

The four brilliant tales in If It Bleeds prove as iconic as their predecessors. In the title story, reader favorite Holly Gibney (from the Mr. Mercedes trilogy and The Outsider) must face her fears, and possibly another outsider—this time on her own. In “Mr. Harrigan’s Phone” an intergenerational friendship has a disturbing afterlife. “The Life of Chuck” explores, beautifully, how each of us contains multitudes. And in “Rat,” a struggling writer must contend with the darker side of ambition.

If these novellas show King’s range, they also prove that certain themes endure. One of King’s great concerns is evil, and in If It Bleeds, there’s plenty of it. There is also evil’s opposite, which in King’s fiction often manifests as friendship. Holly is reminded that friendship is not only life-affirming but can be life-saving. Young Craig befriends Mr. Harrigan, and the sweetness of this late-in-life connection is its own reward.

“An adroit vehicle to showcase the…nature of evil” (The Boston Globe), If It Bleeds is “exactly what I wanted to read right now,” says Ruth Franklin in The New York Times Book Review.', 15.7000, 7, 2, N'Scribner', CAST(N'2020-04-20' AS Date), N'978-1982137977', 4, N'https://m.media-amazon.com/images/I/81offywaW+L._SL1500_.jpg')
GO
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Price], [AuthorID], [BookstoreID], [Publisher], [PublicationDate], [ISBN], [Stock], [PictureURL]) VALUES (22, N'And Then There Were None', N'Ten people, each with something to hide and something to fear, are invited to an isolated mansion on Indian Island by a host who, surprisingly, fails to appear. On the island they are cut off from everything but each other and the inescapable shadows of their own past lives. One by one, the guests share the darkest secrets of their wicked pasts. And one by one, they die…

Which among them is the killer and will any of them survive?', 8.4900, 8, 1, N'William Morrow Paperbacks', CAST(N'2011-03-29' AS Date), N'978-0062073488', 8, N'https://m.media-amazon.com/images/I/41RpulOsOoL.jpg')
GO
SET IDENTITY_INSERT [dbo].[Book] OFF
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
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (10, N'Fiction')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (11, N'Autobiography')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (12, N'Mystery')
GO
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
INSERT [dbo].[BookGenre] ([BookID], [GenreID]) VALUES (1, 3)
GO
INSERT [dbo].[BookGenre] ([BookID], [GenreID]) VALUES (2, 6)
GO
INSERT [dbo].[BookGenre] ([BookID], [GenreID]) VALUES (3, 10)
GO
INSERT [dbo].[BookGenre] ([BookID], [GenreID]) VALUES (4, 10)
GO
INSERT [dbo].[BookGenre] ([BookID], [GenreID]) VALUES (5, 2)
GO
INSERT [dbo].[BookGenre] ([BookID], [GenreID]) VALUES (5, 10)
GO
INSERT [dbo].[BookGenre] ([BookID], [GenreID]) VALUES (6, 11)
GO
INSERT [dbo].[BookGenre] ([BookID], [GenreID]) VALUES (7, 1)
GO
INSERT [dbo].[BookGenre] ([BookID], [GenreID]) VALUES (7, 6)
GO
INSERT [dbo].[BookGenre] ([BookID], [GenreID]) VALUES (7, 10)
GO
INSERT [dbo].[BookGenre] ([BookID], [GenreID]) VALUES (8, 6)
GO
INSERT [dbo].[BookGenre] ([BookID], [GenreID]) VALUES (8, 10)
GO
INSERT [dbo].[BookGenre] ([BookID], [GenreID]) VALUES (8, 12)
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Email], [Password], [PhoneNumber], [Address], [City], [State], [PostalCode], [isAdmin]) VALUES (1, N'a', N'a', N'a@gmail.com', N'$2a$13$R/acXwGqvU5FN1l0UFTREu1c/JNq9VznXaFApqEsxlT7OAdWyghaG', N'1234567890', N'1333 Pearl St', N'Nacogdoches', N'Texas', 75961, 0)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO

