select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager, 'Day' as ca from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where (e.Dept not like '%999%' and e.Dept not like '%888%')  and e.State = '0'   and 
e.ID not in (select distinct EmpID from Kq_Source where 1=1  and cast(FDateTime as date)  = cast( '20200521' as date )  and convert(char(5), FDateTime, 108) >='00:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00' and EmpID is not null )  
and p.B21 not in ('03','07') and p.SessionID = (select max(SessionID) from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID) 

union all
select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager, 'Day-Not PaiPan' as  ca from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 where (e.Dept not like '%999%' and e.Dept not like '%888%')  and e.State = '0'   and 
e.ID not in (select distinct EmpID from Kq_Source where 1=1   and cast(FDateTime as date)  = cast( '20200521' as date )  and convert(char(5), FDateTime, 108) >='00:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00' and EmpID is not null )  and e.ID not in (select EmpID from Kq_PaiBan where SessionID = (select max(SessionID) 
from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID ) ) 

union all

 select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager, 'Night' as ca from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where  (e.Dept not like '%999%' and e.Dept not like '%888%')  and e.State = '0'   and 
e.ID not in (select distinct EmpID from Kq_Source where 1=1  and cast(FDateTime as date)  = cast( '20200521' as date )
and convert(char(5), FDateTime, 108) >='12:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00' and EmpID is not null ) 
and p.B21  in ('03','07') and p.SessionID = (select max(SessionID) from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID) 

---------------------------------------------------------------------------------------------------



 select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager, 'Day' as ca from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where  (e.Dept not like '%999%' and e.Dept not like '%888%') and e.State = '0'  and 
e.ID  in (select distinct EmpID from Kq_Source where 1=1  and cast(FDateTime as date)  = cast( '20200521' as date )  and convert(char(5), FDateTime, 108) >='00:00:01' 
and convert(char(5), FDateTime, 108) < '23:59:00' and EmpID is not null )  and p.B21 not  in ('03','07') and p.SessionID = (select max(SessionID) from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID) 
 union all

 
select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager , 'Day- ko GC' as ca from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 where (e.Dept not like '%999%' and e.Dept not like '%888%')  and e.State = '0'   and 
e.ID  in (select distinct EmpID from Kq_Source where 1=1   and cast(FDateTime as date)  = cast( '20200521' as date )  and convert(char(5), FDateTime, 108) >='00:00:01'  
and convert(char(5), FDateTime, 108) < '23:59:00' and EmpID is not null )  and e.ID not in (select EmpID from Kq_PaiBan where SessionID = (select max(SessionID) 
from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID ) ) 

union all

 select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager , 'night' as ca from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where  (e.Dept not like '%999%' and e.Dept not like '%888%') and e.State = '0'  and 
e.ID  in (select distinct EmpID from Kq_Source where 1=1  
and ((cast(FDateTime as date)  = cast( '20200521' as date )  and convert(char(5), FDateTime, 108) >='12:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00') or  
(cast(FDateTime as date)  = cast( '20200522' as date )  and convert(char(5), FDateTime, 108) >='04:00:00'  and convert(char(5), FDateTime, 108) < '12:00:00'))
and EmpID is not null )

and p.B21  in ('03','07') and p.SessionID = (select max(SessionID) from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID) 





---------------------------------------------

 select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where  (e.Dept not like '%999%' and e.Dept not like '%888%') and e.State = '0'  and 
e.ID  in (select distinct EmpID from Kq_Source where 1=1  and ((cast(FDateTime as date)  = cast( '20200521' as date )  
and convert(char(5), FDateTime, 108) >='12:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00')    or (cast(FDateTime as date)  = cast( '20200522' as date )   
and convert(char(5), FDateTime, 108) >='04:00:00'  and convert(char(5), FDateTime, 108) < '12:00:00'))  and EmpID is not null ) 
and p.B21  in ('03','07') and p.SessionID = (select max(SessionID) from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID) 

