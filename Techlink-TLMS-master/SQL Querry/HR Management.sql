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
where 1=1 
and CAST(FDateTime as date ) >='20200401' 
and CAST(FDateTime as date) <='20200430' and EmpID is null
--and CardNo ='0000009595'
--order by CAST(FDateTime as datetime ) 
) a where InOut =  'Undefined'

select   * from Kq_Card
select top(1) * from ZlEmployee where emp_finger like '%9360'

select  convert(char(5), '2020-04-04 08:00:00.000', 108)

--Tim tat ca cac thoi vu 
