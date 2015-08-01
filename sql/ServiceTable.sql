USE [Test]
GO

/****** Object:  Table [dbo].[services]    Script Date: 08/01/2015 17:26:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[services](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StaffID] [int] NOT NULL,
	[ServiceDate] [date] NULL,
	[BeginTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
 CONSTRAINT [PK_services] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


