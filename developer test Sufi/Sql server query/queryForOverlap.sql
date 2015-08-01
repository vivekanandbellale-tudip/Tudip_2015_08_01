;with flat as
(
 select StaffID, ServiceDate, BeginTime, EndTime, BeginTime as groupid 
 from Staff S1
 where not exists (select * from Staff S2 
 where S1.StaffID = S2.StaffID 
 and S1.ServiceDate = S2.ServiceDate 
 and S2.BeginTime <= S1.BeginTime and S2.EndTime <> S1.EndTime
 and S2.EndTime > S1.BeginTime)

  union all

  select StaffID, ServiceDate, BeginTime, EndTime, BeginTime as groupid 
  from Staff S1
 where exists (select * from Staff S2 
 where S1.StaffID = S2.StaffID 
 and S1.ServiceDate = S2.ServiceDate 
 and S2.BeginTime = S1.BeginTime and S2.EndTime > S1.EndTime)
   and not exists (select * from Staff S2 
 where S1.StaffID = S2.StaffID 
 and S1.ServiceDate = S2.ServiceDate 
 and S2.BeginTime < S1.BeginTime
 and S2.EndTime > S1.BeginTime)

 union all

 select S.StaffID, S.ServiceDate, S.BeginTime, S.EndTime, flat.groupid 
 from flat
 inner join Staff S 
 on flat.StaffID = S.StaffID
 and flat.ServiceDate = S.ServiceDate
 and flat.EndTime > S.BeginTime
 and flat.BeginTime < S.BeginTime and flat.EndTime < S.EndTime
)

select StaffID, ServiceDate, MIN(BeginTime) as begintime, MAX(EndTime) as endtime 
from flat
group by StaffID, ServiceDate, groupid
order by StaffID, ServiceDate, begintime, endtime