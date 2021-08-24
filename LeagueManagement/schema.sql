USE [master]
GO
/****** Object:  Database [QLGD]    Script Date: 24/08/2021 23:04:48 PM ******/
CREATE DATABASE [QLGD]
GO
ALTER DATABASE [QLGD] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLGD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLGD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLGD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLGD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLGD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLGD] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLGD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLGD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLGD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLGD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLGD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLGD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLGD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLGD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLGD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLGD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLGD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLGD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLGD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLGD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLGD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLGD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLGD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLGD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLGD] SET  MULTI_USER 
GO
ALTER DATABASE [QLGD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLGD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLGD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLGD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLGD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLGD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QLGD] SET QUERY_STORE = OFF
GO
USE [QLGD]
GO
/****** Object:  Table [dbo].[dh_account]    Script Date: 24/08/2021 23:04:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dh_account](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [username] [varchar](50) NOT NULL,
    [password] [varchar](50) NOT NULL,
    [email] [varchar](50) NOT NULL,
    [active] [bit] NOT NULL,
    CONSTRAINT [PK_dh_account] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[dh_atheletes]    Script Date: 24/08/2021 23:04:49 PM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[dh_atheletes](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [name] [nvarchar](50) NOT NULL,
    [age] [int] NULL,
    [gender] [bit] NULL,
    [nation_id] [int] NOT NULL,
    [team_id] [int] NOT NULL,
    CONSTRAINT [PK_dh_atheletes] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[dh_league]    Script Date: 24/08/2021 23:04:49 PM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[dh_league](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [name] [nvarchar](50) NOT NULL,
    [nation_id] [int] NOT NULL,
    [num_matches] [int] NOT NULL,
    [num_team] [int] NULL,
    CONSTRAINT [PK_dh_league] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[dh_league_ranking]    Script Date: 24/08/2021 23:04:49 PM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[dh_league_ranking](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [league_id] [int] NOT NULL,
    [season_id] [int] NOT NULL,
    [team_id] [int] NOT NULL,
    [point] [int] NOT NULL,
    [num_win] [int] NOT NULL,
    [num_draw] [int] NOT NULL,
    [num_lost] [int] NOT NULL,
    [played_matches] [int] NOT NULL,
    [difference] [int] NOT NULL,
    [num_goal_scored] [int] NULL,
    [num_goal_received] [int] NULL,
    CONSTRAINT [PK_dh_league_ranking] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[dh_match]    Script Date: 24/08/2021 23:04:49 PM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[dh_match](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [league_id] [int] NOT NULL,
    [season_id] [int] NOT NULL,
    [team_host_id] [int] NOT NULL,
    [team_away_id] [int] NOT NULL,
    [team_host_goal] [int] NOT NULL,
    [team_away_goal] [int] NOT NULL,
    [start_time] [bigint] NOT NULL,
    [end_time] [bigint] NOT NULL,
    [is_final_result] [bit] NULL,
    CONSTRAINT [PK_dh_match] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[dh_nation]    Script Date: 24/08/2021 23:04:49 PM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[dh_nation](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [name] [nvarchar](50) NOT NULL,
    CONSTRAINT [PK_dh_nation] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[dh_season]    Script Date: 24/08/2021 23:04:49 PM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[dh_season](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [name] [nvarchar](50) NOT NULL,
    [start_time] [bigint] NOT NULL,
    [end_time] [bigint] NOT NULL,
    CONSTRAINT [PK_dh_season] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[dh_smtp_mail]    Script Date: 24/08/2021 23:04:49 PM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[dh_smtp_mail](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [account] [varchar](100) NOT NULL,
    [password] [varchar](100) NOT NULL,
    [host] [varchar](100) NOT NULL,
    [port] [int] NOT NULL,
    [active] [bit] NULL,
    PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[dh_team]    Script Date: 24/08/2021 23:04:49 PM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[dh_team](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [name] [nvarchar](50) NOT NULL,
    [host] [nvarchar](50) NULL,
    [nation_id] [int] NOT NULL,
    [num_atheletes] [int] NULL,
    CONSTRAINT [PK_dh_team] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
    SET IDENTITY_INSERT [dbo].[dh_account] ON

    INSERT [dbo].[dh_account] ([id], [username], [password], [email], [active]) VALUES (1, N'thaind', N'123456', N'thaind@gmail.com', 1)
    INSERT [dbo].[dh_account] ([id], [username], [password], [email], [active]) VALUES (2, N'sonnx', N'123456', N'sonnx@gmail.com', 1)
    INSERT [dbo].[dh_account] ([id], [username], [password], [email], [active]) VALUES (3, N'phuctx', N'123456', N'phucnx@gmail.com', 1)
    INSERT [dbo].[dh_account] ([id], [username], [password], [email], [active]) VALUES (4, N'xsonnx', N'123', N'sonxx@gmail.com', 0)
    SET IDENTITY_INSERT [dbo].[dh_account] OFF
    GO
    SET IDENTITY_INSERT [dbo].[dh_atheletes] ON

    INSERT [dbo].[dh_atheletes] ([id], [name], [age], [gender], [nation_id], [team_id]) VALUES (1, N'Jadon Sancho', 21, 1, 1, 1)
    INSERT [dbo].[dh_atheletes] ([id], [name], [age], [gender], [nation_id], [team_id]) VALUES (2, N'Paul Pogba', 28, 1, 2, 1)
    INSERT [dbo].[dh_atheletes] ([id], [name], [age], [gender], [nation_id], [team_id]) VALUES (3, N'Edinson Cavani', 34, 1, 5, 1)
    INSERT [dbo].[dh_atheletes] ([id], [name], [age], [gender], [nation_id], [team_id]) VALUES (4, N'Joe Gomez', 24, 1, 1, 2)
    INSERT [dbo].[dh_atheletes] ([id], [name], [age], [gender], [nation_id], [team_id]) VALUES (5, N'Fabinho', 27, 1, 5, 2)
    INSERT [dbo].[dh_atheletes] ([id], [name], [age], [gender], [nation_id], [team_id]) VALUES (6, N'Mohamed Salah', 29, 1, 5, 2)
    INSERT [dbo].[dh_atheletes] ([id], [name], [age], [gender], [nation_id], [team_id]) VALUES (7, N'Bukayo Saka', 19, 1, 1, 3)
    INSERT [dbo].[dh_atheletes] ([id], [name], [age], [gender], [nation_id], [team_id]) VALUES (8, N'BenWhite', 23, 1, 1, 3)
    INSERT [dbo].[dh_atheletes] ([id], [name], [age], [gender], [nation_id], [team_id]) VALUES (9, N'Joe Willock', 23, 1, 1, 3)
    INSERT [dbo].[dh_atheletes] ([id], [name], [age], [gender], [nation_id], [team_id]) VALUES (10, N'Harry Kane', 28, 1, 1, 4)
    INSERT [dbo].[dh_atheletes] ([id], [name], [age], [gender], [nation_id], [team_id]) VALUES (11, N'Dele Alli', 25, 1, 1, 4)
    INSERT [dbo].[dh_atheletes] ([id], [name], [age], [gender], [nation_id], [team_id]) VALUES (12, N'Bryan Gil ', 20, 1, 5, 4)
    SET IDENTITY_INSERT [dbo].[dh_atheletes] OFF
    GO
    SET IDENTITY_INSERT [dbo].[dh_league] ON

    INSERT [dbo].[dh_league] ([id], [name], [nation_id], [num_matches], [num_team]) VALUES (1, N'Ngoại hạng Anh', 1, 20, 10)
    INSERT [dbo].[dh_league] ([id], [name], [nation_id], [num_matches], [num_team]) VALUES (2, N'Ligue 1', 2, 20, 10)
    INSERT [dbo].[dh_league] ([id], [name], [nation_id], [num_matches], [num_team]) VALUES (3, N'Serie A', 3, 20, 10)
    INSERT [dbo].[dh_league] ([id], [name], [nation_id], [num_matches], [num_team]) VALUES (4, N'La Liga', 5, 20, 10)
    SET IDENTITY_INSERT [dbo].[dh_league] OFF
    GO
    SET IDENTITY_INSERT [dbo].[dh_league_ranking] ON

    INSERT [dbo].[dh_league_ranking] ([id], [league_id], [season_id], [team_id], [point], [num_win], [num_draw], [num_lost], [played_matches], [difference], [num_goal_scored], [num_goal_received]) VALUES (1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0)
    INSERT [dbo].[dh_league_ranking] ([id], [league_id], [season_id], [team_id], [point], [num_win], [num_draw], [num_lost], [played_matches], [difference], [num_goal_scored], [num_goal_received]) VALUES (2, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0)
    INSERT [dbo].[dh_league_ranking] ([id], [league_id], [season_id], [team_id], [point], [num_win], [num_draw], [num_lost], [played_matches], [difference], [num_goal_scored], [num_goal_received]) VALUES (3, 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0)
    INSERT [dbo].[dh_league_ranking] ([id], [league_id], [season_id], [team_id], [point], [num_win], [num_draw], [num_lost], [played_matches], [difference], [num_goal_scored], [num_goal_received]) VALUES (4, 1, 1, 4, 0, 0, 0, 0, 0, 0, 0, 0)
    INSERT [dbo].[dh_league_ranking] ([id], [league_id], [season_id], [team_id], [point], [num_win], [num_draw], [num_lost], [played_matches], [difference], [num_goal_scored], [num_goal_received]) VALUES (5, 1, 1, 5, 0, 0, 0, 0, 0, 0, 0, 0)
    INSERT [dbo].[dh_league_ranking] ([id], [league_id], [season_id], [team_id], [point], [num_win], [num_draw], [num_lost], [played_matches], [difference], [num_goal_scored], [num_goal_received]) VALUES (6, 1, 1, 6, 0, 0, 0, 0, 0, 0, 0, 0)
    INSERT [dbo].[dh_league_ranking] ([id], [league_id], [season_id], [team_id], [point], [num_win], [num_draw], [num_lost], [played_matches], [difference], [num_goal_scored], [num_goal_received]) VALUES (7, 1, 1, 7, 0, 0, 0, 0, 0, 0, 0, 0)
    INSERT [dbo].[dh_league_ranking] ([id], [league_id], [season_id], [team_id], [point], [num_win], [num_draw], [num_lost], [played_matches], [difference], [num_goal_scored], [num_goal_received]) VALUES (8, 1, 1, 8, 0, 0, 0, 0, 0, 0, 0, 0)
    INSERT [dbo].[dh_league_ranking] ([id], [league_id], [season_id], [team_id], [point], [num_win], [num_draw], [num_lost], [played_matches], [difference], [num_goal_scored], [num_goal_received]) VALUES (9, 1, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0)
    SET IDENTITY_INSERT [dbo].[dh_league_ranking] OFF
    GO
    SET IDENTITY_INSERT [dbo].[dh_match] ON

    INSERT [dbo].[dh_match] ([id], [league_id], [season_id], [team_host_id], [team_away_id], [team_host_goal], [team_away_goal], [start_time], [end_time], [is_final_result]) VALUES (1, 1, 1, 1, 2, 0, 0, 1533103200000, 1533108600000, 0)
    INSERT [dbo].[dh_match] ([id], [league_id], [season_id], [team_host_id], [team_away_id], [team_host_goal], [team_away_goal], [start_time], [end_time], [is_final_result]) VALUES (2, 1, 1, 3, 4, 0, 0, 1533189600000, 1533195000000, 0)
    INSERT [dbo].[dh_match] ([id], [league_id], [season_id], [team_host_id], [team_away_id], [team_host_goal], [team_away_goal], [start_time], [end_time], [is_final_result]) VALUES (3, 1, 1, 5, 6, 0, 0, 1533276000000, 1533281400000, 0)
    INSERT [dbo].[dh_match] ([id], [league_id], [season_id], [team_host_id], [team_away_id], [team_host_goal], [team_away_goal], [start_time], [end_time], [is_final_result]) VALUES (4, 1, 1, 7, 8, 0, 0, 1533362400000, 1533367800000, 0)
    INSERT [dbo].[dh_match] ([id], [league_id], [season_id], [team_host_id], [team_away_id], [team_host_goal], [team_away_goal], [start_time], [end_time], [is_final_result]) VALUES (5, 1, 1, 9, 1, 0, 0, 1533448800000, 1533454200000, 0)
    INSERT [dbo].[dh_match] ([id], [league_id], [season_id], [team_host_id], [team_away_id], [team_host_goal], [team_away_goal], [start_time], [end_time], [is_final_result]) VALUES (6, 1, 1, 2, 3, 0, 0, 1533535200000, 1533540600000, 0)
    SET IDENTITY_INSERT [dbo].[dh_match] OFF
    GO
    SET IDENTITY_INSERT [dbo].[dh_nation] ON

    INSERT [dbo].[dh_nation] ([id], [name]) VALUES (1, N'Anh')
    INSERT [dbo].[dh_nation] ([id], [name]) VALUES (2, N'Pháp')
    INSERT [dbo].[dh_nation] ([id], [name]) VALUES (3, N'Italia')
    INSERT [dbo].[dh_nation] ([id], [name]) VALUES (4, N'Đức')
    INSERT [dbo].[dh_nation] ([id], [name]) VALUES (5, N'Tây Ba Nha')
    SET IDENTITY_INSERT [dbo].[dh_nation] OFF
    GO
    SET IDENTITY_INSERT [dbo].[dh_season] ON

    INSERT [dbo].[dh_season] ([id], [name], [start_time], [end_time]) VALUES (1, N'2018-2019', 1533056400000, 1559149200000)
    INSERT [dbo].[dh_season] ([id], [name], [start_time], [end_time]) VALUES (2, N'2019-2020', 1564592400000, 1590771600000)
    INSERT [dbo].[dh_season] ([id], [name], [start_time], [end_time]) VALUES (3, N'2020-2021', 1596214800000, 1622307600000)
    SET IDENTITY_INSERT [dbo].[dh_season] OFF
    GO
    SET IDENTITY_INSERT [dbo].[dh_team] ON

    INSERT [dbo].[dh_team] ([id], [name], [host], [nation_id], [num_atheletes]) VALUES (1, N'Manchester United', N'Old Trafford', 1, 30)
    INSERT [dbo].[dh_team] ([id], [name], [host], [nation_id], [num_atheletes]) VALUES (2, N'Liverpool', N'Anfield', 1, 30)
    INSERT [dbo].[dh_team] ([id], [name], [host], [nation_id], [num_atheletes]) VALUES (3, N'Arsenal', N'Emirates', 1, 30)
    INSERT [dbo].[dh_team] ([id], [name], [host], [nation_id], [num_atheletes]) VALUES (4, N'Tottenham', N'Tottenham Stadium', 1, 30)
    INSERT [dbo].[dh_team] ([id], [name], [host], [nation_id], [num_atheletes]) VALUES (5, N'Everton', N'Goodison Park', 1, 30)
    INSERT [dbo].[dh_team] ([id], [name], [host], [nation_id], [num_atheletes]) VALUES (6, N'Chelsea', N'Stamford Bridge', 1, 30)
    INSERT [dbo].[dh_team] ([id], [name], [host], [nation_id], [num_atheletes]) VALUES (7, N'Manchester City', N'Etihad', 1, 30)
    INSERT [dbo].[dh_team] ([id], [name], [host], [nation_id], [num_atheletes]) VALUES (8, N'West Ham', N'London Stadium', 1, 30)
    INSERT [dbo].[dh_team] ([id], [name], [host], [nation_id], [num_atheletes]) VALUES (9, N'Wolves', N'Molineux ', 1, 30)
    SET IDENTITY_INSERT [dbo].[dh_team] OFF
    GO
ALTER TABLE [dbo].[dh_smtp_mail] ADD  DEFAULT ((1)) FOR [active]
    GO
ALTER TABLE [dbo].[dh_atheletes]  WITH NOCHECK ADD  CONSTRAINT [FK_dh_atheletes_dh_nation] FOREIGN KEY([nation_id])
    REFERENCES [dbo].[dh_nation] ([id])
    GO
ALTER TABLE [dbo].[dh_atheletes] CHECK CONSTRAINT [FK_dh_atheletes_dh_nation]
    GO
ALTER TABLE [dbo].[dh_atheletes]  WITH NOCHECK ADD  CONSTRAINT [FK_dh_atheletes_dh_team] FOREIGN KEY([team_id])
    REFERENCES [dbo].[dh_team] ([id])
    GO
ALTER TABLE [dbo].[dh_atheletes] CHECK CONSTRAINT [FK_dh_atheletes_dh_team]
    GO
ALTER TABLE [dbo].[dh_league]  WITH CHECK ADD  CONSTRAINT [FK_dh_league_dh_nation] FOREIGN KEY([nation_id])
    REFERENCES [dbo].[dh_nation] ([id])
    GO
ALTER TABLE [dbo].[dh_league] CHECK CONSTRAINT [FK_dh_league_dh_nation]
    GO
ALTER TABLE [dbo].[dh_league_ranking]  WITH CHECK ADD  CONSTRAINT [FK_dh_league_ranking_dh_league] FOREIGN KEY([league_id])
    REFERENCES [dbo].[dh_league] ([id])
    GO
ALTER TABLE [dbo].[dh_league_ranking] CHECK CONSTRAINT [FK_dh_league_ranking_dh_league]
    GO
ALTER TABLE [dbo].[dh_league_ranking]  WITH CHECK ADD  CONSTRAINT [FK_dh_league_ranking_dh_season] FOREIGN KEY([season_id])
    REFERENCES [dbo].[dh_season] ([id])
    GO
ALTER TABLE [dbo].[dh_league_ranking] CHECK CONSTRAINT [FK_dh_league_ranking_dh_season]
    GO
ALTER TABLE [dbo].[dh_league_ranking]  WITH CHECK ADD  CONSTRAINT [FK_dh_league_ranking_dh_team] FOREIGN KEY([team_id])
    REFERENCES [dbo].[dh_team] ([id])
    GO
ALTER TABLE [dbo].[dh_league_ranking] CHECK CONSTRAINT [FK_dh_league_ranking_dh_team]
    GO
ALTER TABLE [dbo].[dh_match]  WITH CHECK ADD  CONSTRAINT [FK_dh_match_dh_league] FOREIGN KEY([league_id])
    REFERENCES [dbo].[dh_league] ([id])
    GO
ALTER TABLE [dbo].[dh_match] CHECK CONSTRAINT [FK_dh_match_dh_league]
    GO
ALTER TABLE [dbo].[dh_match]  WITH CHECK ADD  CONSTRAINT [FK_dh_match_dh_season] FOREIGN KEY([season_id])
    REFERENCES [dbo].[dh_season] ([id])
    GO
ALTER TABLE [dbo].[dh_match] CHECK CONSTRAINT [FK_dh_match_dh_season]
    GO
ALTER TABLE [dbo].[dh_match]  WITH CHECK ADD  CONSTRAINT [FK_dh_match_dh_team] FOREIGN KEY([team_host_id])
    REFERENCES [dbo].[dh_team] ([id])
    GO
ALTER TABLE [dbo].[dh_match] CHECK CONSTRAINT [FK_dh_match_dh_team]
    GO
ALTER TABLE [dbo].[dh_match]  WITH CHECK ADD  CONSTRAINT [FK_dh_match_dh_team1] FOREIGN KEY([team_away_id])
    REFERENCES [dbo].[dh_team] ([id])
    GO
ALTER TABLE [dbo].[dh_match] CHECK CONSTRAINT [FK_dh_match_dh_team1]
    GO
ALTER TABLE [dbo].[dh_team]  WITH NOCHECK ADD  CONSTRAINT [FK_dh_team_dh_nation] FOREIGN KEY([nation_id])
    REFERENCES [dbo].[dh_nation] ([id])
    GO
ALTER TABLE [dbo].[dh_team] CHECK CONSTRAINT [FK_dh_team_dh_nation]
    GO
/****** Object:  Trigger [dbo].[update_ranking]    Script Date: 24/08/2021 23:04:49 PM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE trigger [dbo].[update_ranking] on [dbo].[dh_match]
for update
                       AS
begin
	if(UPDATE(team_host_goal) AND UPDATE(team_away_goal))
begin
		declare @host_id int, @away_id int, @host_goal int, @away_goal int,@league_id int, @season_id int, @id int
select @host_goal= team_host_goal, @away_goal= team_away_goal,@id = id from inserted
                                                                                if(@host_goal>@away_goal)
begin
UPDATE dh_league_ranking
SET point = point +3, num_win=num_win + 1, played_matches=played_matches +1, difference=difference +@host_goal-@away_goal,
    num_goal_scored= num_goal_scored + @host_goal, num_goal_received = num_goal_received + @away_goal
Where team_id in (select team_host_id from dh_match where id=@id)
  and league_id in (select league_id from dh_match where id=@id)
  and season_id in (select season_id from dh_match where id=@id)
UPDATE dh_league_ranking
SET  num_lost=num_lost + 1, played_matches=played_matches +1, difference=difference + @away_goal - @host_goal,
     num_goal_scored= num_goal_scored + @away_goal, num_goal_received = num_goal_received + @host_goal
Where team_id in (select team_away_id from dh_match where id=@id)
  and league_id in (select league_id from dh_match where id=@id)
  and season_id in (select season_id from dh_match where id=@id)
UPDATE dh_match
SET is_final_result =1
WHERE id=@id
end
else if(@host_goal=@away_goal)
begin
UPDATE dh_league_ranking
SET point = point +1, num_draw=num_draw + 1, played_matches=played_matches +1,
    num_goal_scored= num_goal_scored + @host_goal, num_goal_received = num_goal_received + @away_goal
Where team_id in (select team_host_id from dh_match where id=@id)
  and league_id in (select league_id from dh_match where id=@id)
  and season_id in (select season_id from dh_match where id=@id)
UPDATE dh_league_ranking
SET point = point +1, num_draw=num_draw + 1, played_matches=played_matches +1,
    num_goal_scored= num_goal_scored + @away_goal, num_goal_received = num_goal_received + @host_goal
Where team_id in (select team_away_id from dh_match where id=@id)
  and league_id in (select league_id from dh_match where id=@id)
  and season_id in (select season_id from dh_match where id=@id)
UPDATE dh_match
SET is_final_result =1
WHERE id=@id
end
else
begin
UPDATE dh_league_ranking
SET point = point +3, num_win=num_win + 1, played_matches=played_matches +1, difference=difference + @away_goal-@host_goal,
    num_goal_scored= num_goal_scored + @away_goal, num_goal_received = num_goal_received + @host_goal
Where team_id in (select team_away_id from dh_match where id=@id)
  and league_id in (select league_id from dh_match where id=@id)
  and season_id in (select season_id from dh_match where id=@id)
UPDATE dh_league_ranking
SET  num_lost=num_lost + 1, played_matches=played_matches +1, difference=difference + @host_goal - @away_goal,
     num_goal_scored= num_goal_scored + @host_goal, num_goal_received = num_goal_received + @away_goal
Where team_id in (select team_host_id from dh_match where id=@id)
  and league_id in (select league_id from dh_match where id=@id)
  and season_id in (select season_id from dh_match where id=@id)
UPDATE dh_match
SET is_final_result =1
WHERE id=@id
end
end
end
GO
ALTER TABLE [dbo].[dh_match] ENABLE TRIGGER [update_ranking]
    GO
    USE [master]
    GO
ALTER DATABASE [QLGD] SET  READ_WRITE 
GO
