--select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
-- left join ZlDept z on e.Dept = z.Code
-- left join Kq_Source s on e.ID = s.EmpID
-- where e.State = 0 and (e.Dept not like '%999%' and e.Dept not like '%888%') and 
--e.ID  in (select EmpID from Kq_Source where 1=1
-- and cast(FDateTime as date)  = cast( '20200511' as date ) 
-- and convert(char(5), FDateTime, 108) >='00:00:01'  and convert(char(5),
-- FDateTime, 108) < '23:59:00' ) and cast(FDateTime as date) = cast('20200511' as date)


-----Nguoi di lam ca dem
 select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where e.State = 0 and (e.Dept not like '%999%' and e.Dept not like '%888%')  and 
e.ID  in (select distinct EmpID from Kq_Source where 1=1  and cast(FDateTime as date)  = cast( '20200511' as date )  
and convert(char(5), FDateTime, 108) >='12:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00' 
)  and p.B11  in ('03','07') and p.SessionID = (select max(SessionID) 
from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID)

---Nguoi di lam ca ngay
select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where (e.Dept not like '%999%' and e.Dept not like '%888%')   and 
e.ID  in (select distinct EmpID from Kq_Source where 1=1  and cast(FDateTime as date)  = cast( '20200511' as date ) 
and convert(char(5), FDateTime, 108) >='00:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00'  )  
--and p.B11 not in ('03','07') 
and p.SessionID = (select max(SessionID) from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID) 


------------Nguoi nghi ca dem
 select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where  (e.Dept not like '%999%' and e.Dept not like '%888%')  and 
e.ID  not in (select distinct EmpID from Kq_Source where 1=1  and cast(FDateTime as date)  = cast( '20200511' as date )  
and convert(char(5), FDateTime, 108) >='12:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00' 
)  and p.B11  in ('03','07') and p.SessionID = (select max(SessionID) 
from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID)

--------------Nguoi nghi ca ngay
select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where e.State = 0 and (e.Dept not like '%999%' and e.Dept not like '%888%')   and 
e.ID not in (select distinct EmpID from Kq_Source where 1=1  and cast(FDateTime as date)  = cast( '20200511' as date ) 
and convert(char(5), FDateTime, 108) >='06:00:00'  and convert(char(5), FDateTime, 108) < '12:00:00'  )  
and p.B11 not  in ('03','07') 
and p.SessionID = (select max(SessionID) from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID) 


select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where e.State = 0 and (e.Dept not like '%999%' and e.Dept not like '%888%') and 
e.ID not in (select distinct EmpID from Kq_Source where 1=1  and cast(FDateTime as date)  = cast( '20200511' as date ) 
and convert(char(5), FDateTime, 108) >='12:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00' and EmpID is not null )  
and p.B11  in ('03','07') and p.SessionID = (select max(SessionID) 
from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID)

select * from ZlDept

select * from ZlEmployee where State = '0' and Dept ='888'


select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where (Dept not like '%888%' and  Dept  not like '%999%')   and 
e.ID not in (select distinct EmpID from Kq_Source where 1=1  and cast(FDateTime as date)  = cast( '20200511' as date )  
and convert(char(5), FDateTime, 108) >='05:00:01'  and convert(char(5), FDateTime, 108) < '12:00:00' and EmpID is not null )  and p.B11 not in ('03','07') 
and p.SessionID = (select max(SessionID) from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID)

select * from ZlEmployee e 
 right join Kq_PaiBan p on e.ID = p.EmpID 
 where 
 p.SessionID = 38

select * from Kq_PaiBan where SessionID = 37

select * from S_Session

