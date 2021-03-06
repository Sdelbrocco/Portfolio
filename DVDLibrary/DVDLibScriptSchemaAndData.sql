USE [master]
GO
/****** Object:  Database [DVDLibrary]    Script Date: 7/27/2016 2:47:30 PM ******/
CREATE DATABASE [DVDLibrary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DVDLibrary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\DVDLibrary.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DVDLibrary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\DVDLibrary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DVDLibrary] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DVDLibrary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DVDLibrary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DVDLibrary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DVDLibrary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DVDLibrary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DVDLibrary] SET ARITHABORT OFF 
GO
ALTER DATABASE [DVDLibrary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DVDLibrary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DVDLibrary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DVDLibrary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DVDLibrary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DVDLibrary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DVDLibrary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DVDLibrary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DVDLibrary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DVDLibrary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DVDLibrary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DVDLibrary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DVDLibrary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DVDLibrary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DVDLibrary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DVDLibrary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DVDLibrary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DVDLibrary] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DVDLibrary] SET  MULTI_USER 
GO
ALTER DATABASE [DVDLibrary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DVDLibrary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DVDLibrary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DVDLibrary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DVDLibrary] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DVDLibrary]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 7/27/2016 2:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Actors](
	[ActorID] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Description] [varchar](max) NULL,
	[DateOfBirth] [date] NULL,
	[HometownCity] [varchar](50) NULL,
	[HometownState] [varchar](50) NULL,
 CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED 
(
	[ActorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Borrows]    Script Date: 7/27/2016 2:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Borrows](
	[BorrowID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[DVDID] [int] NOT NULL,
	[Borrowed] [date] NULL,
	[Returned] [date] NULL,
 CONSTRAINT [PK_Borrows] PRIMARY KEY CLUSTERED 
(
	[BorrowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Directors]    Script Date: 7/27/2016 2:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Directors](
	[DirectorID] [int] NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
 CONSTRAINT [PK_Directors] PRIMARY KEY CLUSTERED 
(
	[DirectorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DVDs]    Script Date: 7/27/2016 2:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVDs](
	[DVDID] [int] NOT NULL,
	[MovieID] [int] NOT NULL,
 CONSTRAINT [PK_DVDs] PRIMARY KEY CLUSTERED 
(
	[DVDID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Genres]    Script Date: 7/27/2016 2:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[GenreDescription] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 7/27/2016 2:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieID] [int] NOT NULL,
	[NumberOfCopies] [int] NOT NULL,
	[MovieTitle] [varchar](50) NOT NULL,
	[MovieSubtitle] [varchar](50) NULL,
	[RunTime] [int] NULL,
	[MPAARatingID] [int] NULL,
	[ReleaseDate] [date] NULL,
	[StudioName] [varchar](50) NULL,
	[GenreID] [int] NULL,
	[DirectorID] [int] NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Movies_Actors]    Script Date: 7/27/2016 2:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies_Actors](
	[MovieID] [int] NOT NULL,
	[ActorID] [int] NOT NULL,
 CONSTRAINT [PK_Movies_Actors] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC,
	[ActorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Movies_Directors]    Script Date: 7/27/2016 2:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies_Directors](
	[MovieID] [int] NOT NULL,
	[DirectorID] [int] NOT NULL,
 CONSTRAINT [PK_Movies_Directors] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC,
	[DirectorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MPAARatings]    Script Date: 7/27/2016 2:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MPAARatings](
	[MPAARatingID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_MPAARatings] PRIMARY KEY CLUSTERED 
(
	[MPAARatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 7/27/2016 2:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ratings](
	[RatingID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[MovieID] [int] NOT NULL,
	[Stars] [int] NULL,
	[UserNotes] [varchar](max) NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[RatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/27/2016 2:47:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] NOT NULL,
	[UserFirstName] [varchar](50) NULL,
	[UserLastName] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Actors] ([ActorID], [FirstName], [LastName], [Description], [DateOfBirth], [HometownCity], [HometownState]) VALUES (1, N'Keanu', N'Reeves', N'Keanu Reeves, whose first name means "cool breeze over the mountains" in Hawaiian, was born in Beirut, Lebanon in 1964, the son of English-born Patricia Taylor, a showgirl, and American-born Samuel Nowlin Reeves, a geologist. ', CAST(N'1964-09-02' AS Date), N'Beirut', NULL)
INSERT [dbo].[Actors] ([ActorID], [FirstName], [LastName], [Description], [DateOfBirth], [HometownCity], [HometownState]) VALUES (2, N'Laurence', N'Fishburne', N'One of Hollywood''s most talented and versatile performers and the recipient of a truckload of NAACP Image awards, Laurence John Fishburne III was born in Augusta, Georgia on July 30, 1961, to Hattie Bell (Crawford), a teacher, and Laurence John Fishburne, Jr., a juvenile corrections officer. ', CAST(N'1961-07-30' AS Date), N'Augusta', N'GA')
INSERT [dbo].[Actors] ([ActorID], [FirstName], [LastName], [Description], [DateOfBirth], [HometownCity], [HometownState]) VALUES (3, N'Hugo', N'Weaving', N'asdf', CAST(N'1960-01-01' AS Date), N'Ibadan', NULL)
INSERT [dbo].[Actors] ([ActorID], [FirstName], [LastName], [Description], [DateOfBirth], [HometownCity], [HometownState]) VALUES (4, N'Carrie-Anne', N'Moss', NULL, CAST(N'1967-08-21' AS Date), N'Vancouver', N'BC')
INSERT [dbo].[Actors] ([ActorID], [FirstName], [LastName], [Description], [DateOfBirth], [HometownCity], [HometownState]) VALUES (5, N'Johnny', N'Depp', NULL, CAST(N'1963-06-09' AS Date), N'Owensboro', N'KY')
INSERT [dbo].[Actors] ([ActorID], [FirstName], [LastName], [Description], [DateOfBirth], [HometownCity], [HometownState]) VALUES (6, N'Winona', N'Ryder', N'Winona Ryder was born Winona Laura Horowitz in Olmsted County, Minnesota, and was named after a nearby town, Winona, Minnesota. She is the daughter of Cynthia (Istas), an author and video producer, and Michael Horowitz, a publisher and bookseller.', CAST(N'1971-10-29' AS Date), N'Winona', N'MN')
INSERT [dbo].[Directors] ([DirectorID], [FirstName], [LastName]) VALUES (1, N'Lana', N'Wachowski')
INSERT [dbo].[Directors] ([DirectorID], [FirstName], [LastName]) VALUES (2, N'Lilly', N'Wachowski')
INSERT [dbo].[Directors] ([DirectorID], [FirstName], [LastName]) VALUES (3, N'Tim', N'Burton')
INSERT [dbo].[Directors] ([DirectorID], [FirstName], [LastName]) VALUES (4, N'Lasse', N'Halltsrom')
INSERT [dbo].[DVDs] ([DVDID], [MovieID]) VALUES (1, 1)
INSERT [dbo].[DVDs] ([DVDID], [MovieID]) VALUES (2, 1)
INSERT [dbo].[DVDs] ([DVDID], [MovieID]) VALUES (3, 2)
INSERT [dbo].[DVDs] ([DVDID], [MovieID]) VALUES (4, 2)
INSERT [dbo].[DVDs] ([DVDID], [MovieID]) VALUES (5, 2)
INSERT [dbo].[DVDs] ([DVDID], [MovieID]) VALUES (6, 2)
INSERT [dbo].[DVDs] ([DVDID], [MovieID]) VALUES (7, 3)
INSERT [dbo].[DVDs] ([DVDID], [MovieID]) VALUES (8, 3)
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([GenreId], [GenreDescription]) VALUES (1, N'Horror')
INSERT [dbo].[Genres] ([GenreId], [GenreDescription]) VALUES (2, N'Comedy')
INSERT [dbo].[Genres] ([GenreId], [GenreDescription]) VALUES (3, N'Action')
INSERT [dbo].[Genres] ([GenreId], [GenreDescription]) VALUES (4, N'Romance')
INSERT [dbo].[Genres] ([GenreId], [GenreDescription]) VALUES (5, N'Thriller')
INSERT [dbo].[Genres] ([GenreId], [GenreDescription]) VALUES (6, N'Drama')
INSERT [dbo].[Genres] ([GenreId], [GenreDescription]) VALUES (7, N'Suspense')
SET IDENTITY_INSERT [dbo].[Genres] OFF
INSERT [dbo].[Movies] ([MovieID], [NumberOfCopies], [MovieTitle], [MovieSubtitle], [RunTime], [MPAARatingID], [ReleaseDate], [StudioName], [GenreID], [DirectorID]) VALUES (1, 2, N'The Matrix', NULL, 136, 4, CAST(N'1999-03-31' AS Date), N'Warner Bros.', NULL, 1)
INSERT [dbo].[Movies] ([MovieID], [NumberOfCopies], [MovieTitle], [MovieSubtitle], [RunTime], [MPAARatingID], [ReleaseDate], [StudioName], [GenreID], [DirectorID]) VALUES (2, 4, N'Chocolat', NULL, 121, 3, CAST(N'2000-01-19' AS Date), N'Miramax', NULL, 4)
INSERT [dbo].[Movies] ([MovieID], [NumberOfCopies], [MovieTitle], [MovieSubtitle], [RunTime], [MPAARatingID], [ReleaseDate], [StudioName], [GenreID], [DirectorID]) VALUES (3, 2, N'Edward Scissorhands', NULL, 105, 3, CAST(N'1990-12-14' AS Date), N'20th Century Fox', NULL, 3)
SET IDENTITY_INSERT [dbo].[MPAARatings] ON 

INSERT [dbo].[MPAARatings] ([MPAARatingID], [Description]) VALUES (1, N'G')
INSERT [dbo].[MPAARatings] ([MPAARatingID], [Description]) VALUES (2, N'PG')
INSERT [dbo].[MPAARatings] ([MPAARatingID], [Description]) VALUES (3, N'PG-13')
INSERT [dbo].[MPAARatings] ([MPAARatingID], [Description]) VALUES (4, N'R')
SET IDENTITY_INSERT [dbo].[MPAARatings] OFF
ALTER TABLE [dbo].[Borrows]  WITH CHECK ADD  CONSTRAINT [FK_Borrows_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Borrows] CHECK CONSTRAINT [FK_Borrows_Users]
GO
ALTER TABLE [dbo].[DVDs]  WITH CHECK ADD  CONSTRAINT [FK_DVDs_Movies] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
GO
ALTER TABLE [dbo].[DVDs] CHECK CONSTRAINT [FK_DVDs_Movies]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Genres] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([GenreId])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Genres]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_MPAARatings] FOREIGN KEY([MPAARatingID])
REFERENCES [dbo].[MPAARatings] ([MPAARatingID])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_MPAARatings]
GO
ALTER TABLE [dbo].[Movies_Actors]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Actors_Actors] FOREIGN KEY([ActorID])
REFERENCES [dbo].[Actors] ([ActorID])
GO
ALTER TABLE [dbo].[Movies_Actors] CHECK CONSTRAINT [FK_Movies_Actors_Actors]
GO
ALTER TABLE [dbo].[Movies_Actors]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Actors_Movies] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
GO
ALTER TABLE [dbo].[Movies_Actors] CHECK CONSTRAINT [FK_Movies_Actors_Movies]
GO
ALTER TABLE [dbo].[Movies_Directors]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Directors_Directors] FOREIGN KEY([DirectorID])
REFERENCES [dbo].[Directors] ([DirectorID])
GO
ALTER TABLE [dbo].[Movies_Directors] CHECK CONSTRAINT [FK_Movies_Directors_Directors]
GO
ALTER TABLE [dbo].[Movies_Directors]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Directors_Movies] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
GO
ALTER TABLE [dbo].[Movies_Directors] CHECK CONSTRAINT [FK_Movies_Directors_Movies]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Movies] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Movies]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Users]
GO
USE [master]
GO
ALTER DATABASE [DVDLibrary] SET  READ_WRITE 
GO
