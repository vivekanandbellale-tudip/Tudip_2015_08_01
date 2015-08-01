1.Created a table

USE [Test]
GO

/****** Object:  Table [dbo].[services]    Script Date: 08/01/2015 17:23:28 ******/
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

2.Inserted values:



3.Wrote the script for merging the overlapping time sots.

;with flat as
(
 select StaffID, ServiceDate, BeginTime, EndTime, BeginTime as groupid 
 from services S1
 where not exists (select * from services S2 
 where S1.StaffID = S2.StaffID 
 and S1.ServiceDate = S2.ServiceDate 
 and S2.BeginTime <= S1.BeginTime and S2.EndTime <> S1.EndTime
 and S2.EndTime > S1.BeginTime)

  union all

  select StaffID, ServiceDate, BeginTime, EndTime, BeginTime as groupid 
  from services S1
 where exists (select * from services S2 
 where S1.StaffID = S2.StaffID 
 and S1.ServiceDate = S2.ServiceDate 
 and S2.BeginTime = S1.BeginTime and S2.EndTime > S1.EndTime)
   and not exists (select * from services S2 
 where S1.StaffID = S2.StaffID 
 and S1.ServiceDate = S2.ServiceDate 
 and S2.BeginTime < S1.BeginTime
 and S2.EndTime > S1.BeginTime)

 union all

 select S.StaffID, S.ServiceDate, S.BeginTime, S.EndTime, flat.groupid 
 from flat
 inner join services S 
 on flat.StaffID = S.StaffID
 and flat.ServiceDate = S.ServiceDate
 and flat.EndTime > S.BeginTime
 and flat.BeginTime < S.BeginTime and flat.EndTime < S.EndTime
)

select StaffID, ServiceDate, MIN(BeginTime) as Begintime, MAX(EndTime) as Endtime 
from flat
group by StaffID, ServiceDate, groupid
order by StaffID, ServiceDate, begintime, endtime