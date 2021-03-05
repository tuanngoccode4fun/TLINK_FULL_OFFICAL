select distinct k.CardNo, ISNULL(z.Name,'') as EmpName, z.Dept
from Kq_Source k
left join ZlEmployee z on k.CardNo = z.emp_finger
where 1=1 
and EmpID is null
and CAST(FDateTime as date ) >='20200401' 
and CAST(FDateTime as date) <='20200430' 

--select top(1) * from Kq_Source 

select * from 
(


select CardNo,FDateTime,MachNo,CAST(FDateTime as date ) as DateFinger, convert(char(5), FDateTime, 108) as TimeFinger,
case 
when  convert(char(5), FDateTime, 108) >='19:00' and convert(char(5), FDateTime, 108) <'20:00' then 'In-Night'
when  convert(char(5), FDateTime, 108) >='07:00' and convert(char(5), FDateTime, 108) <'08:00' then 'In-Day'
when  convert(char(5), FDateTime, 108) >='08:00' and convert(char(5), FDateTime, 108) <='09:00' then 'Out-night'
when  convert(char(5), FDateTime, 108) >='20:00' and convert(char(5), FDateTime, 108) <='21:00' then 'Out-Day'
else 'Undefined'
end as InOut
from Kq_Source
where 1=1 and EmpID is null
and CAST(FDateTime as date ) >='20200401' 
and CAST(FDateTime as date) <='20200430' 
and CardNo ='0000008646    '
order by CAST(FDateTime as datetime ) 



) a where InOut =  'Undefined'

select   * from Kq_Card
select top(1) * from ZlEmployee where emp_finger like '%9360'

select  convert(char(5), '2020-04-04 08:00:00.000', 108)


select isnull(d.Name,'') as Dept,isnull(z.Code,'') as Code, isnull(z.Name,'') as Name,isnull(z.ID,'') as ID, k.CardNo,FDateTime,MachNo,CAST(FDateTime as date ) as DateFinger, convert(char(5), FDateTime, 108) as TimeFinger,
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
left join ZlEmployee z on k.CardNo = z.emp_finger
left join ZlDept d on z.Dept = d.Code
where 1=1 
 and (z.Dept like '%888%' or EmpID is null)   and CAST(FDateTime as date ) >='20200401'  and CAST(FDateTime as date ) <='20200416'  order by CAST(FDateTime as datetime ) 



 select isnull(d.Name,'') as Dept,isnull(z.Code,'') as Code, isnull(z.Name,'') as Name,isnull(z.ID,'') as ID, k.CardNo,FDateTime,MachNo,CAST(FDateTime as date ) as DateFinger, convert(char(5), FDateTime, 108) as TimeFinger,
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
left join ZlEmployee z on k.CardNo = z.emp_finger
left join ZlDept d on z.Dept = d.Code
where 1=1 
  and (z.Dept like '%888%' )  and CAST(FDateTime as date ) >='20200401'  and CAST(FDateTime as date ) <='20200416'  
  order by CAST(FDateTime as datetime ),Code 
 