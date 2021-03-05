select  p.B17,w.InTime as Intime, w.OutTime as Outtime,ISNULL(count(distinct s.EmpID),0) as CountEmp  
from Kq_Source s  left join ZlEmployee e on s.CardNo = e.emp_finger  
left join ZlDept d on d.Code = e.Dept  left join Kq_PaiBan p on p.EmpID = e.ID 
left join WorkingSetting w  on  w.Id = p.B17 where   e.State ='0' 
and cast(FDateTime as date)  = cast( '20200417' as date )  and convert(char(5), FDateTime, 108) >='06:00:00'  
and convert(char(5), FDateTime, 108) < '20:00:00'  and p.SessionID = (  select max(SessionID) from Kq_PaiBan b 
inner join ZlEmployee a on b.EmpID = a.ID
 where a.Dept = '111-1' )  and d.Code = '111-1'  and B17 is not NULL  group by p.B17 ,w.InTime, w.OutTime


  select  p.B17,w.InTime as Intime, w.OutTime as Outtime,ISNULL(count(distinct s.EmpID),0) as CountEmp  
  from Kq_Source s  left join ZlEmployee e on s.CardNo = e.emp_finger 
  left join ZlDept d on d.Code = e.Dept  left join Kq_PaiBan p on p.EmpID = e.ID  
  left join WorkingSetting w  on  w.Id = p.B17 where   e.State ='0' and cast(FDateTime as date)  = cast( '20200417' as date )  
  and convert(char(5), FDateTime, 108) >='19:00:00'  and convert(char(5), FDateTime, 108) < '23:59:00' 
  and p.SessionID = (  select max(SessionID) from Kq_PaiBan b inner join ZlEmployee a on b.EmpID = a.ID
 where a.Dept = '111-1' )  and d.Code = '111-1'  and B17 is not NULL  group by p.B17 ,w.InTime, w.OutTime 

 select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.emp_finger = s.CardNo
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where e.State = 0 and e.Dept not like '%888%'   and e.Dept not like '%666%' and 
e.emp_finger not in (select CardNo from Kq_Source where  cast(FDateTime as date)  = cast( '20200417' as date )  
  and convert(char(5), FDateTime, 108) >='01:00:00'  and convert(char(5), FDateTime, 108) < '23:59:00' )
   and p.B17  in ('03','07') and p.SessionID = (select max(SessionID) from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID)
 group by  e.Code,e.Name, e.Dept, z.Name, z.Manager

  select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.emp_finger = s.CardNo
 where e.State = 0 and e.Dept not like '%888%'   and e.Dept not like '%666%' and 
e.emp_finger not in (select CardNo from Kq_Source where  cast(FDateTime as date)  = cast( '20200417' as date )  
  and convert(char(5), FDateTime, 108) >='01:00:00'  and convert(char(5), FDateTime, 108) < '23:59:00' )
 
 
 group by  e.Code,e.Name, e.Dept, z.Name, z.Manager



  select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.emp_finger = s.CardNo
 where e.State = 0 and e.Dept not like '%888%'   and e.Dept not like '%666%' and 
e.emp_finger  in (select CardNo from Kq_Source where  cast(FDateTime as date)  = cast( '20200417' as date )  
  and convert(char(5), FDateTime, 108) >='04:00:00'  and convert(char(5), FDateTime, 108) < '08:00:00' )
 group by  e.Code,e.Name, e.Dept, z.Name, z.Manager

  select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.emp_finger = s.CardNo
  left join Kq_PaiBan p on e.ID = p.EmpID 
 where e.State = 0 and e.Dept not like '%888%'   and e.Dept not like '%666%' and 
e.emp_finger  in (select CardNo from Kq_Source where  cast(FDateTime as date)  = cast( '20200417' as date )  
  and convert(char(5), FDateTime, 108) >='06:00:00'  and convert(char(5), FDateTime, 108) <= '21:59:00' )
 group by  e.Code,e.Name, e.Dept, z.Name, z.Manager


 select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
 left join Kq_Source s on e.emp_finger = s.CardNo
 where e.State = 0 and e.Dept not like '%888%'   and e.Dept not like '%666%' and 
e.emp_finger  in (select CardNo from Kq_Source where  cast(FDateTime as date)  = cast( '20200417' as date )  
  and convert(char(5), FDateTime, 108) >='18:00:00'  and convert(char(5), FDateTime, 108) < '23:59:00' )
  and e.emp_finger  in (select CardNo from Kq_Source where  cast(FDateTime as date)  = cast( '20200418' as date )  
  and convert(char(5), FDateTime, 108) >='08:00:00'  and convert(char(5), FDateTime, 108) < '09:00:00' )
 group by  e.Code,e.Name, e.Dept, z.Name, z.Manager


 select * from ZlDept

 select * from WorkingSetting

 select * from Kq_PaiBan where SessionID =  (select max(SessionID) from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID where a.Code = 'TL-0405')

 select * from ZlEmployee e
 left join Kq_PaiBan p on e.ID = p.EmpID
 where   SessionID =37 and State =0
 and  p.SessionID =(select max(SessionID) from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID where a.Code = 'TL-4483')

 select * from ZlDept where TreeLevel = 1 and Code not like '%888%' and Code not like '%666%' 