 select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager, e.emp_finger 
 from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
 left join Kq_Source s on s.EmpID = e.ID
 where e.State = 0 and e.Dept  like '%888%'
and e.ID  in (select EmpID from Kq_Source where 1=1
 and cast(FDateTime as date)  = cast('20200422' as date) and convert(char(5), FDateTime, 108) >='00:00:01' 
 and convert(char(5), FDateTime, 108) < '23:59:00' ) 
 and cast(FDateTime as date)  = '20200422'

  select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager, e.emp_finger 
 from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
 left join Kq_Source s on s.EmpID = e.ID
 where e.State = 0 and e.Dept  like '%888%'
and e.ID  in (select EmpID from Kq_Source where 1=1
 and cast(FDateTime as date)  = '20200422' and convert(char(5), FDateTime, 108) >='00:00:01' 
 and convert(char(5), FDateTime, 108) < '23:59:00' ) 
 and cast(FDateTime as date)  = '20200422'

 select * from ZlEmployee where Dept like '%888%' and State ='0'

 select * from Kq_Source where CardNo like '%TL-2149%'

 select CardNo,*  from Kq_Source where 1=1
 and cast(FDateTime as date)  = '20200423' and convert(char(5), FDateTime, 108) >='00:00:01' 
 and convert(char(5), FDateTime, 108) < '23:59:00'
and CardNo like '%TL-8570%'


select * from ZlEmployee where ID = 4579



select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager, s.FDateTime, e.ID from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
 left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where e.State = 0 and e.Dept not like '%888%'   and e.Dept not like '%666%' and 
e.ID   in (select distinct  EmpID from Kq_Source where 1=1  and cast(FDateTime as date)  = cast( '20200423' as date )  and convert(char(5), FDateTime, 108) >='00:00:01' 
and convert(char(5), FDateTime, 108) < '23:59:00' ) 
and cast(FDateTime as date)  = cast( '20200423' as date)
and p.B23  in ('03','07') and p.SessionID = (select max(SessionID) 
from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID) 


select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 where e.State = 0 and e.Dept not like '%888%'   and e.Dept not like '%666%' and 
e.ID not in (select distinct EmpID from Kq_Source where 1=1  and cast(FDateTime as date)  = cast( '20200423' as date )  
and convert(char(5), FDateTime, 108) >='00:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00'
and EmpID is not null)



select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 where e.State = 0 and e.Dept not like '%888%'   and e.Dept not like '%666%' and 
e.ID not in (select EmpID from Kq_Source where 1=1  and cast(FDateTime as date)  = cast( '20200422' as date ) 
and convert(char(5), FDateTime, 108) >='00:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00'  and EmpID is not null )


select isnull(d.Name,'') as Dept,isnull(z.Code,'') as Code, isnull(z.Name,'') as Name,isnull(z.ID,'') as ID, k.CardNo,FDateTime,MachNo,CAST(FDateTime as date ) as DateFinger, 
convert(char(5), FDateTime, 108) as TimeFinger,
case 
when  convert(char(5), FDateTime, 108) >='19:00' and convert(char(5), FDateTime, 108) <'20:00' then 'In-Night'
when  convert(char(5), FDateTime, 108) >='07:00' and convert(char(5), FDateTime, 108) <'08:00' then 'In-Day'
when  convert(char(5), FDateTime, 108) >='05:00' and convert(char(5), FDateTime, 108) <='06:00' then 'Out-Night8'
when  convert(char(5), FDateTime, 108) >='08:00' and convert(char(5), FDateTime, 108) <='09:00' then 'Out-Night12'
when  convert(char(5), FDateTime, 108) >='17:00' and convert(char(5), FDateTime, 108) <='18:00' then 'Out-Day8'
when  convert(char(5), FDateTime, 108) >='20:00' and convert(char(5), FDateTime, 108) <='21:00' then 'Out-Day12'
else 'Undefined'
end as InOut
from Kq_Source k
left join ZlEmployee z on k.EmpID = z.ID
left join ZlDept d on z.Dept = d.Code
where 1=1 
  and (z.Dept like '%888%' )  and CAST(FDateTime as date ) >='20200401'  and CAST(FDateTime as date ) <='20200424'  order by CAST(FDateTime as datetime ) 


  select   e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager, s.FDateTime from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
 left join Kq_Source s on s.EmpID = e.ID
 where  e.Dept  like '%888%'   and 
 e.ID  in (select EmpID from Kq_Source where 1=1
 and cast(FDateTime as date)  = cast( '20200424' as date )  and convert(char(5), FDateTime, 108) >='00:00:01'  
 and convert(char(5), FDateTime, 108) < '23:59:00' )   and cast(FDateTime as date)  = cast( '20200424' as date )
 order by e.Code