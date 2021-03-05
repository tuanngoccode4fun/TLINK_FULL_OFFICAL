----------Xuat hang thanh pham
---Update COPTC, COPTD DDH
---Insert COPTG, COPTH
SELECT * FROM SFCTA WHERE TA001 ='B511' AND TA002 ='20050007'

select * from INVMB where MB001 = 'BMH1199355S01'
select * from COPTH WHERE TH001 ='B231' AND TH002 ='20050001'
select top(100)* from COPTG

select top(1)* from COPTD

 select * from INVLF where LF001 ='B231' and LF002 = '2005018'
 select * from INVLA where LA006 = 'B231' and LA007 = '2001001'
 select * from INVMF where MF004 = 'B231' and MF005 = '2001001'
 select  * from INVME  where ME005 ='B231' and ME006 ='2001001'
 select * from INVMM where 1=1 and MM001 = 'BMH1199355S01'  and MM002 = 'B02' and MM004 ='abc11'
  select * from INVMM where 1=1 and MM001 = 'BMH1199355S01'  and MM002 = 'B02' and MM004 ='abc22'
SELECT * FROM INVMC 
 where MC001 LIKE '%1244645S02%'  and MC002 ='B02'
 UPDATE  INVMC SET MC007 = 6730 , MC014 = 1218.13
 where MC001 LIKE '%1244645S02%'  and MC002 ='B02'
select * from INVMB where MB001 LIKE '%1244645S02%'
UPDATE INVMB SET MB089 =1218.13 WHERE MB001 LIKE '%1244645S02%'

----------------------------
SELECT *  from COPTH WHERE TH001 ='B231' AND TH002 ='2005018'
SELECT *  from COPTG WHERE TG001 ='B231' AND TG002 ='2005018'

AND TG003 = (select max(cast(TG003 as date)) from COPTG)
SELECT *  from COPTD WHERE TD001 ='B221' AND TD002 ='1908063    ' AND TD003 = '0004'
SELECT MAX(TG002)+1 from COPTG where TG001 ='B231' and TG003 like '202005%'
-----------------------------
update COPTH set TH026 = 'N' WHERE TH001 ='B231' AND TH002 ='2005007'

select top(1) * from ACRTA 
select top(2) * from ACRTA 


---------
  ----------------------lENH SAN XUAT
  --B511-20020041
--B511-20030023
--B511-20030024
   select * from MOCTA where TA001 ='B511' and TA002 in ('20020041','20030023','20030024')
   select * FROM MOCTF  WHERE TF001 = 'D301' AND TF002 = '20050434'
   select * FROM MOCTG  WHERE TG001 = 'D301' AND TG002 = '20050434'
  SELECT * FROM SFCTA WHERE TA001 = 'B511' AND TA002 in ('20020041','20030023','20030024') and TA003 ='0020'
   select * from SFCTB where TB001 = 'D301' and TB002 = '20050434'
 select * from SFCTC where TC001 = 'D301' and TC002 =  '20050434'

-------------NHAP KHO
select * from INVLF where LF001 ='D301' and LF002 = '20050434'
 select * from INVLA where LA006 = 'D301' and LA007 = '20050434'
 select * from INVMF where MF004 = 'D301' and MF005 = '20050434'
 select * from INVME  where ME005 ='D301' and ME006 ='20050434'
 select * from INVMM where 1=1 and MM001 = 'BMH1227768S11'  and MM002 = 'B02' and MM004 ='V1412020'
  select * from INVMM where 1=1 and MM001 = 'BMH1227768S11'  and MM002 = 'B02' and MM004 ='V1392020'
  select * from INVMM where 1=1 and MM001 = 'BMH1227768S11'  and MM002 = 'B02' and MM004 ='V1402020'
 select * from INVMC where MC001 = 'BMH1227768S11'  and MC002 ='B02'
 -------------------

 -------------------------------------
 update SFCTA set TA011 = TA011-180, TA039 = TA039 -29.7
 where TA001 ='B511' and TA002 = '20020041' and TA003 ='0020'

  update SFCTA set TA011 = TA011-180, TA039 = TA039 -29.7
 where TA001 ='B511' and TA002 = '20030023'  and TA003 ='0020'

  update SFCTA set TA011 = TA011-360, TA039 = TA039 -59.4
 where TA001 ='B511' and TA002 = '20030024' and TA003 ='0020'
 ---------------------
 update MOCTA set TA017 = TA017 -180 , TA046 = TA046 - 29.7
 where TA001 ='B511' and TA002 = '20020041'

  update MOCTA set TA017 = TA017 -180 , TA046 = TA046 - 29.7
 where TA001 ='B511' and TA002 = '20030023'

  update MOCTA set TA017 = TA017 -360 , TA046 = TA046 - 59.4
 where TA001 ='B511' and TA002 = '20030024'

 ----------------
 update INVMC set MC007 = MC007 - 720 , MC014 = MC014 -118.8
 WHERE MC001 = 'BMH1227768S11'  and MC002 ='B02'





 SELECT * FROM CMSMF WHERE MF001 ='USD'
  SELECT * FROM CMSMG WHERE MG001 ='USD' 
  and MG002 = (select max(cast(MG002 as date)) from CMSMG where MG001 ='USD'  and cast(MG002 as date) < '20200519')

  SELECT * FROM CMSMG

  select 
  case
  when ( TD009 >= TD008 and TD033 >=TD032) then 'Y'
  else 'N'
  end as DeliveryStatus
  from COPTD
  where TD001 = 'B224' and TD002 = '1909030   ' and TD003 = '0002'

  select * from COPTD where TD001 = 'B221' and TD002 = '1901053' and TD003 = '0006'

   update  COPTD set TD016 ='N' where TD008 > TD009 and TD032 > TD033
 and TD016 ='Y'

 select * from COPTD where TD008 > TD009 and TD032 > TD033
 and TD016 ='Y'
  

  SELECT * FROM COPTD where TD016 ='Y'

  ---B224	1909152    	0001

  --B224	1911105    	0001

  --B221	1901053    	0006