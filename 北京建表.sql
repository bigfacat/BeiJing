SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[GDTXBeiJing_UserYSBQC](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](50) NULL,
	[CompanyId] [int] NULL,
	[QuestionId] [int] NULL,
	[UserQuestionId] [int] NULL,
	[YSBQCId] [nvarchar](50) NULL,
	[TaskName] [nvarchar](100) NULL,
	[ZSXM] [nvarchar](50) NULL,
	[url] [varchar](250) NULL,
	[BDDM] [nvarchar](50) NULL,
	[HappenDate] [nvarchar](50) NULL,
	[SBZT] [nvarchar](50) NULL,
	[SBSE] [nvarchar](300) NULL,
	[SKSSQQ] [nvarchar](50) NULL,
	[SKSSQZ] [nvarchar](50) NULL,
	[SBQX] [nvarchar](50) NULL,
	[yzpzzlDm] [varchar](50) NULL,
	[sbblxDm] [varchar](50) NULL,
	[ywbm] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GDTXBeiJing_UserYSBQCReportData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[reportCode] [nvarchar](50) NOT NULL,
	[userId] [nvarchar](50) NOT NULL,
	[userYSBQCId] [int] NOT NULL,
	[dataKey] [nvarchar](50) NOT NULL,
	[dataValue] [ntext] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
