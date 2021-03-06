USE [InstagramDB]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 11/06/2019 22:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Remark] [nvarchar](150) NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Followers]    Script Date: 11/06/2019 22:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Followers](
	[UserId] [int] NOT NULL,
	[FollowerId] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Followers] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[FollowerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Likes]    Script Date: 11/06/2019 22:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Likes](
	[PostId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Likes] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 11/06/2019 22:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Photo] [nvarchar](max) NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostsComments]    Script Date: 11/06/2019 22:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostsComments](
	[PostId] [int] NOT NULL,
	[CommentId] [int] NOT NULL,
 CONSTRAINT [PK_PostsComments] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC,
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/06/2019 22:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](20) NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersProfiles]    Script Date: 11/06/2019 22:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersProfiles](
	[Id] [int] NOT NULL,
	[FullName] [nvarchar](150) NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_UsersProfiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users_UserId]
GO
ALTER TABLE [dbo].[Followers]  WITH CHECK ADD  CONSTRAINT [FK_Followers_Users_FollowerId] FOREIGN KEY([FollowerId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Followers] CHECK CONSTRAINT [FK_Followers_Users_FollowerId]
GO
ALTER TABLE [dbo].[Followers]  WITH CHECK ADD  CONSTRAINT [FK_Followers_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Followers] CHECK CONSTRAINT [FK_Followers_Users_UserId]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_Likes_Posts_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_Likes_Posts_PostId]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_Likes_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_Likes_Users_UserId]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Users_UserId]
GO
ALTER TABLE [dbo].[PostsComments]  WITH CHECK ADD  CONSTRAINT [FK_PostsComments_Comments_CommentId] FOREIGN KEY([CommentId])
REFERENCES [dbo].[Comments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostsComments] CHECK CONSTRAINT [FK_PostsComments_Comments_CommentId]
GO
ALTER TABLE [dbo].[PostsComments]  WITH CHECK ADD  CONSTRAINT [FK_PostsComments_Posts_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
GO
ALTER TABLE [dbo].[PostsComments] CHECK CONSTRAINT [FK_PostsComments_Posts_PostId]
GO
ALTER TABLE [dbo].[UsersProfiles]  WITH CHECK ADD  CONSTRAINT [FK_UsersProfiles_Users_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersProfiles] CHECK CONSTRAINT [FK_UsersProfiles_Users_Id]
GO
