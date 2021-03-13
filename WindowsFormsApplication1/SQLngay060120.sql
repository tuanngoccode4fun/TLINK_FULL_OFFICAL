select top(100) * from INVLF where LF004 = 'BMH1227768S01' and LF007 like '%V2362019%'

select LF004, LF005,LF007, LF006, sum(LF011*LF008) as Qty from INVLF
where 1=1 and LF007 = '15122019' and LF004 = 'BY011-2000' and LF005 = 'B05'
group by LF004, LF005, LF006, LF007

select top(100) * from INVLA where LA001 = 'BMH1227768S01' and LA016 like '%V2362019%'

select * from INVTA where TA001 = '1201' and TA002 ='20010002'

select * from INVME 
left join INVMF on ME001 = MF001 and ME002 = MF002
where ME001 = 'BY011-2000' and ME002 like '%15122019%'

select * from INVME 
where ME001 = 'BY011-2000' and ME002 like '%15122019%'

select * from INVMF 
where MF001 = 'BY011-2000' and MF002 like '%15122019%'





select * from INVLA where LA001 = 'BY011-2000'

select * from INVMQ  where MQ001 =  'BY011-2000'

SELECT * FROM CMSMQ WHERE MQ001 = '1201' 

select * from INVLF where LF004 ='BY011-2000'

select top(1) * from INVLA where LA001 = 'BY011-2000'

 