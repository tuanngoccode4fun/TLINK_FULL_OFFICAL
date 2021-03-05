

SELECT * FROM SFCTA WHERE TA001 = 'B512' and TA002 = '20040001'
select * from MOCTA where TA001 = 'B512' and TA002 = '20040001'

select top(1) * from MOCTA where TA001 = 'B512' and TA021 = 'B01'
--------------------------------xuat hang-----------------------------


 select MM001, MM002,MM003,MM004,MM005,MM006, MM007, MM008,MM009,MM010 
 from INVMM where MM001 like '%BMH1227768S01                           %'

 select top(1) * from COPTH
  select top(1) * from COPTG
 select Top(1) * from COPTG where TG001 ='A231' and TG003 like '%1911%'

 select a.TA001+'-'+ a.TA002 from SFCTA a
 inner join MOCTA b on a.TA001 = b.TA001 and a.TA002 = b.TA002
 where  a.TA003 = '0020'
 and a.TA010>a.TA011+a.TA012 and a.TA032 ='N' and CAST(a.CREATE_DATE as date)  > '20200101'
and  b.TA006 like  '%BMH1227768%'
order by a.CREATE_DATE ASC

  select Top(1) * from SFCTA 
 select Top(1) * from MOCTA
  select Top(1) * from MOCTB


---B511-20030005   
--B511-20030006   
--B511-20040001   

  select * from MOCTA where TA011 ='N'
  ----------------------lENH SAN XUAT
   select * from MOCTA where TA001 ='B511' and TA002 = '20030024' 
   SELECT * FROM MOCTF  WHERE TF001 = 'D301' AND TF002 = '20050086'
   SELECT * FROM MOCTG  WHERE TG001 = 'D301' AND TG002 = '20050086'
   SELECT * FROM SFCTA WHERE TA001 = 'B511' AND TA002 = '20020002' and TA003 = '0020' 
  select * from SFCTB where TB001 = 'D301' and TB002 = '20050086'
 select * from SFCTC where TC001 = 'D301' and TC002 =  '20050086'

-------------NHAP KHO
 select * from INVLF where LF001 ='D301' and LF002 = '20050073'
 select * from INVLA where LA006 = 'D301' and LA007 = '20050073'
 select * from INVMF where MF004 = 'D301' and MF005 = '20050073'
 select  * from INVME  where ME005 ='D301' and ME006 ='20050073'
 select * from INVMM where 1=1 and MM001 = 'BMH1199355S01'  and MM002 = 'B02' and MM004 ='abc11'
  select * from INVMM where 1=1 and MM001 = 'BMH1199355S01'  and MM002 = 'B02' and MM004 ='abc22'
 select * from INVMC where MC001 = 'BMH1199355S01'  and MC002 ='B02'
select * from INVMB where MB001 = 'BMH1199355S01'

select * from COPMA

--select MB023 from INVMB where MB001 = 'BMH1199355S01'
-----------------------
--delete from SFCTC
--where TC001 = 'D301' and TC002 = '20050007'
--delete from SFCTB
--where TB001 = 'D301' and TB002 = '20050007'

select * from INVMD where MD001 LIKE  '%44645%'

  update LOT set  LOTSIZE =LOTSIZE - 50,   PKQTY = PKQTYPER * LOTSIZE  where ID  ='B511-20020086' and STATUS =130 and ERP_OPSEQ ='0020' 


  SELECT * FROM SFCTA WHERE TA001 = 'B511' AND TA002 = '20050002'


  select * from  INVMB where MB001 = 'BMH1199355S01' 

  SELECT * FROM INVMX WHERE  CREATE_DATE = '20200511'  
  OR   MODI_DATE   = '20200511'

  SELECT * FROM INVLA WHERE LA006 = 'D301'

  SELECT  * FROM MOCTF WHERE TF001 = 'D301' AND TF002 = '20050070'

  SELECT * FROM MOCTG where  TG001 = 'D301' AND TG002 = '20050070'

  SELECT * FROM INVMB WHERE MB001 = 'BMH1227768S01'

select  *  from COPTC WHERE TC005 =  'B01'

select  TC012,TD001,TD002,TD003, TD004,TD005,TD008,TD009,TD010,TD013,TD016,TD021, TD032, TD036, TC005, TC004 from COPTC
 inner join COPTD on TC001 = TD001 and TC002 = TD002
 where TC027 = 'Y' AND TD016 = 'N'   
 and TD004 like '%199355%'



 