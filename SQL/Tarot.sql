ALTER DATABASE [TarotBooking] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TarotBooking].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TarotBooking] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TarotBooking] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TarotBooking] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TarotBooking] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TarotBooking] SET ARITHABORT OFF 
GO
ALTER DATABASE [TarotBooking] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TarotBooking] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TarotBooking] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TarotBooking] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TarotBooking] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TarotBooking] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TarotBooking] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TarotBooking] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TarotBooking] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TarotBooking] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TarotBooking] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TarotBooking] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TarotBooking] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TarotBooking] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TarotBooking] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TarotBooking] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TarotBooking] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TarotBooking] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TarotBooking] SET  MULTI_USER 
GO
ALTER DATABASE [TarotBooking] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TarotBooking] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TarotBooking] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TarotBooking] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TarotBooking] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TarotBooking] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TarotBooking] SET QUERY_STORE = OFF
GO
USE [TarotBooking]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 5/19/2024 8:33:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[PaymentId] [int] NOT NULL,
	[BillingDate] [datetime] NULL,
	[TotalAmount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 5/19/2024 8:33:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[TarotReaderId] [int] NOT NULL,
	[Date] [date] NULL,
	[Amount] [float] null,
	[Status] [bit] NULL,
	[Description] [nvarchar](1000) NULL,
	[ScheduleId] [int] NOT NULL,
	[SessionTypeId] [int] not null unique,
	
PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/19/2024 8:33:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL Unique,
	[Description] [nvarchar](1000) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 5/19/2024 8:33:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[TarotReaderId] [int] NOT NULL,
	[Rating] [int] NULL,
	[Comments] [nvarchar](1000) NULL,
	[Date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 5/19/2024 8:33:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[BookingId] [int] NOT NULL,
	[Amount] [int] NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentMethod] [nvarchar](255) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/19/2024 8:33:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 5/19/2024 8:33:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[TarotReaderId] [int] NOT NULL,
	[Date] [date] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Status] [bit] NULL
PRIMARY KEY CLUSTERED 
(
	[ScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SessionType]    Script Date: 5/19/2024 8:33:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionType](
	[SessionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Duration] [int] NULL,
	[Description] [nvarchar](1000) NULL,
	[Price] [float] NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SessionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarotReader]    Script Date: 5/19/2024 8:33:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarotReader](
	[TarotReaderId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL Unique,
	[Introduction] [nvarchar](500) NULL,
	[Description] [nvarchar](4000) NULL,
	[Experience] [nvarchar](max) NULL,
    [Kind] [nvarchar](max) NULL,
	[Image] [varbinary](max) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TarotReaderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarotReaderSessionType]    Script Date: 5/19/2024 8:33:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarotReaderSessionType](
	[TarotReaderId] [int] NOT NULL,
	[SessionTypeId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TarotReaderId] ASC,
	[SessionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/19/2024 8:33:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[DateOfBirth] [date] NULL,
	[PhoneNumber] [varchar](255) NULL,
	[Gender] [bit] NULL,
	[Email] [varchar](255) NULL,
	[Password] [varchar](255) NULL,
	[Address] [nvarchar](1000) NULL,
	[IsActive] [bit] NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bills] ON 

INSERT [dbo].[Bills] ([BillId], [PaymentId], [BillingDate], [TotalAmount]) VALUES (1, 1, CAST(N'2024-05-01T09:00:00.000' AS DateTime), 250)
INSERT [dbo].[Bills] ([BillId], [PaymentId], [BillingDate], [TotalAmount]) VALUES (2, 2, CAST(N'2024-05-02T10:00:00.000' AS DateTime), 450)
INSERT [dbo].[Bills] ([BillId], [PaymentId], [BillingDate], [TotalAmount]) VALUES (3, 3, CAST(N'2024-05-03T11:00:00.000' AS DateTime), 600)
INSERT [dbo].[Bills] ([BillId], [PaymentId], [BillingDate], [TotalAmount]) VALUES (4, 4, CAST(N'2024-05-04T12:00:00.000' AS DateTime), 250)
INSERT [dbo].[Bills] ([BillId], [PaymentId], [BillingDate], [TotalAmount]) VALUES (5, 5, CAST(N'2024-05-05T13:00:00.000' AS DateTime), 450)
INSERT [dbo].[Bills] ([BillId], [PaymentId], [BillingDate], [TotalAmount]) VALUES (6, 6, CAST(N'2024-05-06T14:00:00.000' AS DateTime), 600)
INSERT [dbo].[Bills] ([BillId], [PaymentId], [BillingDate], [TotalAmount]) VALUES (7, 7, CAST(N'2024-05-07T15:00:00.000' AS DateTime), 250)
INSERT [dbo].[Bills] ([BillId], [PaymentId], [BillingDate], [TotalAmount]) VALUES (8, 8, CAST(N'2024-05-08T16:00:00.000' AS DateTime), 450)
INSERT [dbo].[Bills] ([BillId], [PaymentId], [BillingDate], [TotalAmount]) VALUES (9, 9, CAST(N'2024-05-09T17:00:00.000' AS DateTime), 600)
INSERT [dbo].[Bills] ([BillId], [PaymentId], [BillingDate], [TotalAmount]) VALUES (10, 10, CAST(N'2024-05-10T09:00:00.000' AS DateTime), 450)
SET IDENTITY_INSERT [dbo].[Bills] OFF
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([BookingId], [CustomerId], [TarotReaderId], [Date],[Amount], [Status], [Description], [ScheduleId], [SessionTypeId]) VALUES (1, 1, 1, CAST(N'2024-05-20' AS Date),250, 1, N'General Reading', 1, 1)
INSERT [dbo].[Booking] ([BookingId], [CustomerId], [TarotReaderId], [Date],[Amount], [Status], [Description], [ScheduleId], [SessionTypeId]) VALUES (2, 2, 1, CAST(N'2024-05-20' AS Date),400, 1, N'Love Reading', 2, 2)
INSERT [dbo].[Booking] ([BookingId], [CustomerId], [TarotReaderId], [Date],[Amount], [Status], [Description], [ScheduleId], [SessionTypeId]) VALUES (3, 3, 2, CAST(N'2024-05-20' AS Date),500, 1, N'Career Reading', 3, 3)
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerId], [UserId], [Description], [Status]) VALUES (1, 2, N'Mong muốn tìm được nơi booking Tarot chất lượng', 1)
INSERT [dbo].[Customer] ([CustomerId], [UserId], [Description], [Status]) VALUES (2, 3, N'Khách hàng mới', 1)
INSERT [dbo].[Customer] ([CustomerId], [UserId], [Description], [Status]) VALUES (3, 4, N'Khách hàng đã quay lại', 1)
INSERT [dbo].[Customer] ([CustomerId], [UserId], [Description], [Status]) VALUES (4, 5, N'Khách hàng tiềm năng', 1)
INSERT [dbo].[Customer] ([CustomerId], [UserId], [Description], [Status]) VALUES (5, 6, N'Khách hàng thường xuyên', 1)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([FeedbackId], [CustomerId], [TarotReaderId], [Rating], [Comments], [Date]) VALUES (1, 1, 1, 5, N'Ð?c bài r?t tuy?t v?i!', CAST(N'2024-05-01' AS Date))
INSERT [dbo].[Feedback] ([FeedbackId], [CustomerId], [TarotReaderId], [Rating], [Comments], [Date]) VALUES (2, 3, 2, 4, N'R?t sâu s?c', CAST(N'2024-05-02' AS Date))
INSERT [dbo].[Feedback] ([FeedbackId], [CustomerId], [TarotReaderId], [Rating], [Comments], [Date]) VALUES (3, 4, 1, 3, N'Nhi?u kinh nghi?m', CAST(N'2024-05-03' AS Date))
INSERT [dbo].[Feedback] ([FeedbackId], [CustomerId], [TarotReaderId], [Rating], [Comments], [Date]) VALUES (4, 5, 2, 5, N'Amazing!', CAST(N'2024-05-04' AS Date))
INSERT [dbo].[Feedback] ([FeedbackId], [CustomerId], [TarotReaderId], [Rating], [Comments], [Date]) VALUES (5, 1, 2, 2, N'Không vu?t quá mong d?i', CAST(N'2024-05-05' AS Date))
INSERT [dbo].[Feedback] ([FeedbackId], [CustomerId], [TarotReaderId], [Rating], [Comments], [Date]) VALUES (6, 2, 1, 4, N'Bài h?c t?t', CAST(N'2024-05-06' AS Date))
INSERT [dbo].[Feedback] ([FeedbackId], [CustomerId], [TarotReaderId], [Rating], [Comments], [Date]) VALUES (7, 3, 2, 5, N'Th? tim <3', CAST(N'2024-05-07' AS Date))
INSERT [dbo].[Feedback] ([FeedbackId], [CustomerId], [TarotReaderId], [Rating], [Comments], [Date]) VALUES (8, 2, 1, 3, N'Nó r?t okay', CAST(N'2024-05-08' AS Date))
INSERT [dbo].[Feedback] ([FeedbackId], [CustomerId], [TarotReaderId], [Rating], [Comments], [Date]) VALUES (9, 5, 2, 4, N'R?t t?t', CAST(N'2024-05-09' AS Date))
INSERT [dbo].[Feedback] ([FeedbackId], [CustomerId], [TarotReaderId], [Rating], [Comments], [Date]) VALUES (10, 1, 1, 5, N'Ð?c bài tuy?t v?i', CAST(N'2024-05-10' AS Date))
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([PaymentId], [BookingId], [Amount], [PaymentDate], [PaymentMethod], [Status]) VALUES (1, 1, 250, CAST(N'2024-05-01T09:00:00.000' AS DateTime), N'Credit Card', 1)
INSERT [dbo].[Payment] ([PaymentId], [BookingId], [Amount], [PaymentDate], [PaymentMethod], [Status]) VALUES (2, 2, 450, CAST(N'2024-05-02T10:00:00.000' AS DateTime), N'PayPal', 1)
INSERT [dbo].[Payment] ([PaymentId], [BookingId], [Amount], [PaymentDate], [PaymentMethod], [Status]) VALUES (3, 3, 600, CAST(N'2024-05-03T11:00:00.000' AS DateTime), N'Credit Card', 1)
INSERT [dbo].[Payment] ([PaymentId], [BookingId], [Amount], [PaymentDate], [PaymentMethod], [Status]) VALUES (4, 1, 250, CAST(N'2024-05-04T12:00:00.000' AS DateTime), N'Debit Card', 1)
INSERT [dbo].[Payment] ([PaymentId], [BookingId], [Amount], [PaymentDate], [PaymentMethod], [Status]) VALUES (5, 2, 450, CAST(N'2024-05-05T13:00:00.000' AS DateTime), N'Credit Card', 1)
INSERT [dbo].[Payment] ([PaymentId], [BookingId], [Amount], [PaymentDate], [PaymentMethod], [Status]) VALUES (6, 3, 600, CAST(N'2024-05-06T14:00:00.000' AS DateTime), N'PayPal', 1)
INSERT [dbo].[Payment] ([PaymentId], [BookingId], [Amount], [PaymentDate], [PaymentMethod], [Status]) VALUES (7, 1, 250, CAST(N'2024-05-07T15:00:00.000' AS DateTime), N'Credit Card', 1)
INSERT [dbo].[Payment] ([PaymentId], [BookingId], [Amount], [PaymentDate], [PaymentMethod], [Status]) VALUES (8, 2, 450, CAST(N'2024-05-08T16:00:00.000' AS DateTime), N'Debit Card', 1)
INSERT [dbo].[Payment] ([PaymentId], [BookingId], [Amount], [PaymentDate], [PaymentMethod], [Status]) VALUES (9, 3, 600, CAST(N'2024-05-09T17:00:00.000' AS DateTime), N'Credit Card', 1)
INSERT [dbo].[Payment] ([PaymentId], [BookingId], [Amount], [PaymentDate], [PaymentMethod], [Status]) VALUES (10, 2, 450, CAST(N'2024-05-10T09:00:00.000' AS DateTime), N'PayPal', 1)
SET IDENTITY_INSERT [dbo].[Payment] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Customer')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (3, N'TarotReader')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedule] ON 

INSERT [dbo].[Schedule] ([ScheduleId], [TarotReaderId], [Date], [StartTime], [EndTime]) VALUES (1, 1, CAST(N'2024-05-25' AS Date), CAST(N'1900-01-01T10:00:00.000' AS DateTime), CAST(N'1900-01-01T10:30:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleId], [TarotReaderId], [Date], [StartTime], [EndTime]) VALUES (2, 1, CAST(N'2024-05-25' AS Date), CAST(N'1900-01-01T14:00:00.000' AS DateTime), CAST(N'1900-01-01T15:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleId], [TarotReaderId], [Date], [StartTime], [EndTime]) VALUES (3, 1, CAST(N'2024-05-25' AS Date), CAST(N'1900-01-01T09:00:00.000' AS DateTime), CAST(N'1900-01-01T10:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleId], [TarotReaderId], [Date], [StartTime], [EndTime]) VALUES (4, 2, CAST(N'2024-06-04' AS Date), CAST(N'1900-01-01T11:30:00.000' AS DateTime), CAST(N'1900-01-01T12:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleId], [TarotReaderId], [Date], [StartTime], [EndTime]) VALUES (5, 2, CAST(N'2024-06-04' AS Date), CAST(N'1900-01-01T11:30:00.000' AS DateTime), CAST(N'1900-01-01T12:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([ScheduleId], [TarotReaderId], [Date], [StartTime], [EndTime]) VALUES (6, 2, CAST(N'2024-06-04' AS Date), CAST(N'1900-01-01T11:30:00.000' AS DateTime), CAST(N'1900-01-01T12:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Schedule] OFF
GO
SET IDENTITY_INSERT [dbo].[SessionType] ON 

INSERT [dbo].[SessionType] ([SessionTypeId], [Name], [Duration], [Description], [Price], [Status]) VALUES (1, N'Buổi đọc bài 30 phút', 30, N'Khám phá có hướng dẫn về chủ đề hoặc câu hỏi bạn đã chọn, được tổ chức trên Tellory với video trực tiếp và bộ bài tarot tương tác.', 250, 1)
INSERT [dbo].[SessionType] ([SessionTypeId], [Name], [Duration], [Description], [Price], [Status]) VALUES (2, N'Buổi đọc bài 60 phút', 60, N'Khám phá có hướng dẫn về chủ đề hoặc câu hỏi bạn đã chọn, được tổ chức trên Tellory với video trực tiếp và bộ bài tarot tương tác.', 450, 1)
INSERT [dbo].[SessionType] ([SessionTypeId], [Name], [Duration], [Description], [Price], [Status]) VALUES (3, N'Buổi học Tarot', 60, N'Phiên cố vấn được cá nhân hóa, được điều chỉnh để đáp ứng mức độ kinh nghiệm và mục tiêu của bạn, được tổ chức trên Tellory bằng video trực tiếp.', 600, 1)
INSERT [dbo].[SessionType] ([SessionTypeId], [Name], [Duration], [Description], [Price], [Status]) VALUES (4, N'Buổi đọc bài 30 phút', 30, N'Khám phá có hướng dẫn về chủ đề hoặc câu hỏi bạn đã chọn, được tổ chức trên Tellory với video trực tiếp và bộ bài tarot tương tác.', 300, 1)
INSERT [dbo].[SessionType] ([SessionTypeId], [Name], [Duration], [Description], [Price], [Status]) VALUES (5, N'Buổi đọc bài 60 phút', 60, N'Khám phá có hướng dẫn về chủ đề hoặc câu hỏi bạn đã chọn, được tổ chức trên Tellory với video trực tiếp và bộ bài tarot tương tác.', 500, 1)
INSERT [dbo].[SessionType] ([SessionTypeId], [Name], [Duration], [Description], [Price], [Status]) VALUES (6, N'Buổi học Tarot', 60, N'Phiên cố vấn được cá nhân hóa, được điều chỉnh để đáp ứng mức độ kinh nghiệm và mục tiêu của bạn, được tổ chức trên Tellory bằng video trực tiếp.', 700, 1)
INSERT [dbo].[SessionType] ([SessionTypeId], [Name], [Duration], [Description], [Price], [Status]) VALUES (7, N'Buổi đọc bài 30 phút', 30, N'Khám phá có hướng dẫn về chủ đề hoặc câu hỏi bạn đã chọn, được tổ chức trên Tellory với video trực tiếp và bộ bài tarot tương tác.', 200, 1)
INSERT [dbo].[SessionType] ([SessionTypeId], [Name], [Duration], [Description], [Price], [Status]) VALUES (8, N'Buổi đọc bài 60 phút', 60, N'Khám phá có hướng dẫn về chủ đề hoặc câu hỏi bạn đã chọn, được tổ chức trên Tellory với video trực tiếp và bộ bài tarot tương tác.', 400, 1)
INSERT [dbo].[SessionType] ([SessionTypeId], [Name], [Duration], [Description], [Price], [Status]) VALUES (9, N'Buổi học Tarot', 60, N'Phiên cố vấn được cá nhân hóa, được điều chỉnh để đáp ứng mức độ kinh nghiệm và mục tiêu của bạn, được tổ chức trên Tellory bằng video trực tiếp.', 550, 1)
SET IDENTITY_INSERT [dbo].[SessionType] OFF
GO
SET IDENTITY_INSERT [dbo].[TarotReader] ON;

INSERT [dbo].[TarotReader] ([TarotReaderId], [UserId], [Introduction], [Description], [Image], [Status], [Experience], [Kind]) 
VALUES 
(1, 7, N'Xin chào! Tôi là Ánh Nguyệt, một Tarot Reader với niềm đam mê sâu sắc với nghệ thuật Tarot. Điều đặc biệt về phong cách của tôi chính là sự kết hợp giữa sự tinh tế và sự sâu sắc trong việc đọc bài Tarot.', 
N'Mỗi readers của X-Tarot đều có một dấu ấn riêng, và ở reader Zoro phong cách nhẹ nhàng, cởi mở, dí dỏm đã trở thành một nét đặc trưng không lẫn vào đâu được. Mỗi khi tiếp xúc với anh, bạn sẽ luôn cảm thấy vô cùng thoải mái, dễ chịu, cảm giác như đã quen biết tự bao giờ. Và rồi nếu bạn có lỡ bay lên mây một chút, rồi choáng ngợp đôi chút bởi ấn tượng ban đầu về sự hoạt bát, phóng khoáng với đôi phần lãng tử của anh, thì có lẽ bạn cũng sẽ lại phải bất ngờ một chút, giật mình đôi chút mà hạ xuống dưới đất bởi cảm giác chân thật mà anh đưa lại lúc về sau.
Mặc dù sở hữu rất nhiều bộ bài Tarot, nhưng anh ưa thích đồng hành cùng Legacy of the Divine Tarot hơn cả – bộ bài vừa có ngôn ngữ hình ảnh rất dễ hiểu, sâu sắc lại vừa có sức mạnh thứ hai về hệ thống chiêm tinh học gắn kèm vào. Cũng phải thôi vì tác giả của Legacy là một giảng viên đồ hoạ, nét vẽ của ông vừa rất thật lại vừa rất sâu. Và đó cũng chính là con đường mà reader Zoro chọn khi tiếp cận với các querents của mình vậy. Thẳng thắn, rõ ràng, đầy đủ, không vòng vèo, đưa lối, ấy luôn là cách anh dùng để đưa thông tin tới querent, để cùng họ nhìn chi tiết hơn câu chuyện rắc rối của bản thân, hiểu rõ hơn về từng góc cạnh của vấn đề, và cuối cùng – nhận ra đâu sẽ là điểm đặt chân kế tiếp của mình.
Còn bạn, bạn đã biết phải book event nào tiếp theo cho mình rồi chứ?', 
0x4F, 1, N'5 years', N'Psychic'),

(2, 8, N'Xin chào! Tôi là Minh Đăng, một Tarot Reader với niềm đam mê sâu sắc với nghệ thuật Tarot. Điều đặc biệt về phong cách của tôi chính là sự kết hợp giữa sự tinh tế và sự sâu sắc trong việc đọc bài Tarot.', 
N'Nổi tiếng với những lần đọc chính xác và sâu sắc', 0x4F, 1, N'3 years', N'Clairvoyant');

SET IDENTITY_INSERT [dbo].[TarotReader] OFF;

GO
INSERT [dbo].[TarotReaderSessionType] ([TarotReaderId], [SessionTypeId]) VALUES (1, 1)
INSERT [dbo].[TarotReaderSessionType] ([TarotReaderId], [SessionTypeId]) VALUES (1, 2)
INSERT [dbo].[TarotReaderSessionType] ([TarotReaderId], [SessionTypeId]) VALUES (2, 4)
INSERT [dbo].[TarotReaderSessionType] ([TarotReaderId], [SessionTypeId]) VALUES (2, 5)
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [LastName], [FirstName], [DateOfBirth], [PhoneNumber], [Gender], [Email], [Password], [Address], [IsActive], [RoleId]) VALUES (1, N'Nghĩa', N'Bùi Hiếu', CAST(N'2000-05-10' AS Date), N'0912014524', 0, N'buihieunghia@gmail.com', N'a123456', N'12A Bùi Hữu Nghĩa Street, Bình Thạnh District, Hồ Chí Minh City', 1, 1)
INSERT [dbo].[User] ([UserId], [LastName], [FirstName], [DateOfBirth], [PhoneNumber], [Gender], [Email], [Password], [Address], [IsActive], [RoleId]) VALUES (2, N'Nghi', N'Nguyễn Hà', CAST(N'1999-12-02' AS Date), N'0987654321', 1, N'nguyenhanghi@gmail.com', N'hanghi123', N'123 Lê Văn Việt Street, District 9 , Thủ Đức City', 1, 2)
INSERT [dbo].[User] ([UserId], [LastName], [FirstName], [DateOfBirth], [PhoneNumber], [Gender], [Email], [Password], [Address], [IsActive], [RoleId]) VALUES (3, N'Hà', N'Nguyễn An', CAST(N'2001-01-12' AS Date), N'0345678148', 1, N'nguyenanha@gmail.com', N'anha123', N'13B Bạch Đằng Street, Bình Thạnh District, Hồ Chí Minh City', 1, 2)
INSERT [dbo].[User] ([UserId], [LastName], [FirstName], [DateOfBirth], [PhoneNumber], [Gender], [Email], [Password], [Address], [IsActive], [RoleId]) VALUES (4, N'Nga', N'Văn Thị', CAST(N'2004-07-05' AS Date), N'0197625487', 1, N'vanthinga@gmail.com', N'vanngacute', N'12A D1 Street, District 9, Thủ Đức City', 1, 2)
INSERT [dbo].[User] ([UserId], [LastName], [FirstName], [DateOfBirth], [PhoneNumber], [Gender], [Email], [Password], [Address], [IsActive], [RoleId]) VALUES (5, N'Uyên', N'Ngô Nguyễn', CAST(N'1996-10-03' AS Date), N'0487015487', 1, N'ngonguyenuyen@gmail.com', N'abc123', N'1/2C Làng Tăng Phú Street, Bình Thạnh District, Hồ Chí Minh City', 1, 2)
INSERT [dbo].[User] ([UserId], [LastName], [FirstName], [DateOfBirth], [PhoneNumber], [Gender], [Email], [Password], [Address], [IsActive], [RoleId]) VALUES (6, N'Phát', N'Trần Tấn', CAST(N'1997-04-11' AS Date), N'0647015489', 1, N'trantanphat@gmail.com', N'abc123', N'192 Xô Viết Nghệ Tĩnh Street, Bình Thạnh District, Hồ Chí Minh City', 1, 2)
INSERT [dbo].[User] ([UserId], [LastName], [FirstName], [DateOfBirth], [PhoneNumber], [Gender], [Email], [Password], [Address], [IsActive], [RoleId]) VALUES (7, N'Nguyệt', N'Võ Ánh', CAST(N'1999-05-15' AS Date), N'0254987645', 1, N'voanhnguyet@gmail.com', N'abc123', N'123 Võ Văn Ngân Street, Thủ Đức District, Thủ Đức City', 1, 3)
INSERT [dbo].[User] ([UserId], [LastName], [FirstName], [DateOfBirth], [PhoneNumber], [Gender], [Email], [Password], [Address], [IsActive], [RoleId]) VALUES (8, N'Đăng', N'Nguyễn Minh', CAST(N'2002-03-09' AS Date), N'0345015879', 1, N'nguyenminhdang@gmail.com', N'abc123', N'12/4/5 Kha Vạn Cân Street, Thủ Đức District, Thủ Đức City', 1, 3)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payment] ([PaymentId])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([ScheduleId])
REFERENCES [dbo].[Schedule] ([ScheduleId])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([TarotReaderId])
REFERENCES [dbo].[TarotReader] ([TarotReaderId])
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([TarotReaderId])
REFERENCES [dbo].[TarotReader] ([TarotReaderId])
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD FOREIGN KEY([BookingId])
REFERENCES [dbo].[Booking] ([BookingId])
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([TarotReaderId])
REFERENCES [dbo].[TarotReader] ([TarotReaderId])
GO
ALTER TABLE [dbo].[TarotReader]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[TarotReaderSessionType]  WITH CHECK ADD FOREIGN KEY([SessionTypeId])
REFERENCES [dbo].[SessionType] ([SessionTypeId])
GO
ALTER TABLE [dbo].[TarotReaderSessionType]  WITH CHECK ADD FOREIGN KEY([TarotReaderId])
REFERENCES [dbo].[TarotReader] ([TarotReaderId])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
Go
ALTER TABLE [dbo].[Booking]
WITH CHECK ADD FOREIGN KEY ([SessionTypeId]) REFERENCES [dbo].[SessionType]([SessionTypeId])
GO
USE [master]
GO
ALTER DATABASE [TarotBooking] SET  READ_WRITE 
GO
