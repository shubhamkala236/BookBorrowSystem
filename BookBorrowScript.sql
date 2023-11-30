USE [master]
GO
/****** Object:  Database [BookBorrowDb]    Script Date: 30-11-2023 14:48:59 ******/
CREATE DATABASE [BookBorrowDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookBorrowDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BookBorrowDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookBorrowDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BookBorrowDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BookBorrowDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookBorrowDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookBorrowDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookBorrowDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookBorrowDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookBorrowDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookBorrowDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookBorrowDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookBorrowDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookBorrowDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookBorrowDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookBorrowDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookBorrowDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookBorrowDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookBorrowDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookBorrowDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookBorrowDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookBorrowDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookBorrowDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookBorrowDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookBorrowDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookBorrowDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookBorrowDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BookBorrowDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookBorrowDb] SET RECOVERY FULL 
GO
ALTER DATABASE [BookBorrowDb] SET  MULTI_USER 
GO
ALTER DATABASE [BookBorrowDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookBorrowDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookBorrowDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookBorrowDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookBorrowDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookBorrowDb', N'ON'
GO
ALTER DATABASE [BookBorrowDb] SET QUERY_STORE = OFF
GO
USE [BookBorrowDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 30-11-2023 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 30-11-2023 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](max) NOT NULL,
	[Rating] [int] NOT NULL,
	[Author] [nvarchar](max) NOT NULL,
	[Genre] [nvarchar](max) NOT NULL,
	[IsBookAvailable] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[LentByUserId] [int] NULL,
	[BorrowedByUserId] [int] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 30-11-2023 14:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[TokensAvailable] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231123111105_InitialMigration', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231123111926_ForeingKeyAdded', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231123141046_SeedCorrectData', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231123153026_AddedICollectionToUSER', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231124111651_removeFieldsFromUser', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookId], [BookName], [Rating], [Author], [Genre], [IsBookAvailable], [Description], [LentByUserId], [BorrowedByUserId]) VALUES (1, N'asdasd', 2, N'asda', N'asd', N'unavailable', N'asd adsa da', 1, 3)
INSERT [dbo].[Books] ([BookId], [BookName], [Rating], [Author], [Genre], [IsBookAvailable], [Description], [LentByUserId], [BorrowedByUserId]) VALUES (2, N'The Jumangi', 2, N'John', N'Adventure', N'unavailable', N'this is a sample description', 2, 1)
INSERT [dbo].[Books] ([BookId], [BookName], [Rating], [Author], [Genre], [IsBookAvailable], [Description], [LentByUserId], [BorrowedByUserId]) VALUES (3, N'Book3', 3, N'The Great Adas', N'Mystery', N'available', N'This is good', 3, NULL)
INSERT [dbo].[Books] ([BookId], [BookName], [Rating], [Author], [Genre], [IsBookAvailable], [Description], [LentByUserId], [BorrowedByUserId]) VALUES (4, N'The Exodus', 4, N'The Mihaz', N'Thriller', N'unavailable', N'This is a great thriller story', 1, 2)
INSERT [dbo].[Books] ([BookId], [BookName], [Rating], [Author], [Genre], [IsBookAvailable], [Description], [LentByUserId], [BorrowedByUserId]) VALUES (5, N'The Mummy', 3, N'James Charles', N'Horror, Mystery', N'available', N'The Story of great Egyptian Mummy.', 3, NULL)
INSERT [dbo].[Books] ([BookId], [BookName], [Rating], [Author], [Genre], [IsBookAvailable], [Description], [LentByUserId], [BorrowedByUserId]) VALUES (6, N'Return of the King', 4, N'Ben Jimin', N'Fantasy', N'unavailable', N'This the world of fantasy and adventure.', 4, 2)
INSERT [dbo].[Books] ([BookId], [BookName], [Rating], [Author], [Genre], [IsBookAvailable], [Description], [LentByUserId], [BorrowedByUserId]) VALUES (7, N'Harry Potter', 4, N'JK Rolling', N'Fantasy, Adventure, Mystery', N'available', N'This is a story of a young boy harry potter wizard.', 4, NULL)
INSERT [dbo].[Books] ([BookId], [BookName], [Rating], [Author], [Genre], [IsBookAvailable], [Description], [LentByUserId], [BorrowedByUserId]) VALUES (8, N'The Green', 3, N'James Chameron', N'Action', N'available', N'Test Sample And abundance description', 2, NULL)
INSERT [dbo].[Books] ([BookId], [BookName], [Rating], [Author], [Genre], [IsBookAvailable], [Description], [LentByUserId], [BorrowedByUserId]) VALUES (9, N'The Hollow', 2, N'Ichigo Kurosaki', N'Action, Fantasy', N'unavailable', N'The story of a shinegamiin japan.', 2, 4)
INSERT [dbo].[Books] ([BookId], [BookName], [Rating], [Author], [Genre], [IsBookAvailable], [Description], [LentByUserId], [BorrowedByUserId]) VALUES (10, N'The Return of Demon', 2, N'Jim Kizoka', N'Mystery, Action, Fantasy', N'unavailable', N'The legend on a hero with demon king powers', 2, 4)
INSERT [dbo].[Books] ([BookId], [BookName], [Rating], [Author], [Genre], [IsBookAvailable], [Description], [LentByUserId], [BorrowedByUserId]) VALUES (11, N'Book of 4', 3, N'Thomas', N'Action', N'unavailable', N'The great book of a historical event in america', 4, 3)
INSERT [dbo].[Books] ([BookId], [BookName], [Rating], [Author], [Genre], [IsBookAvailable], [Description], [LentByUserId], [BorrowedByUserId]) VALUES (12, N'Book of Virtuoso', 4, N'Jhin', N'Art', N'available', N'Artist obsessed with number 4. ', 4, NULL)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [Name], [Username], [Password], [TokensAvailable]) VALUES (1, N'Rohan', N'user1', N'user123', 13)
INSERT [dbo].[Users] ([UserId], [Name], [Username], [Password], [TokensAvailable]) VALUES (2, N'Shubham', N'user2', N'user123', 5)
INSERT [dbo].[Users] ([UserId], [Name], [Username], [Password], [TokensAvailable]) VALUES (3, N'Rahul', N'user3', N'user123', 13)
INSERT [dbo].[Users] ([UserId], [Name], [Username], [Password], [TokensAvailable]) VALUES (4, N'Rishabh', N'user4', N'user123', 9)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Books_BorrowedByUserId]    Script Date: 30-11-2023 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_Books_BorrowedByUserId] ON [dbo].[Books]
(
	[BorrowedByUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Books_LentByUserId]    Script Date: 30-11-2023 14:48:59 ******/
CREATE NONCLUSTERED INDEX [IX_Books_LentByUserId] ON [dbo].[Books]
(
	[LentByUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Users_BorrowedByUserId] FOREIGN KEY([BorrowedByUserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Users_BorrowedByUserId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Users_LentByUserId] FOREIGN KEY([LentByUserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Users_LentByUserId]
GO
USE [master]
GO
ALTER DATABASE [BookBorrowDb] SET  READ_WRITE 
GO
