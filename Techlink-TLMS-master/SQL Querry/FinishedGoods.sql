

select *  from LOT where ID in(  'B511-20030014', 'B511-20030022')
select *  from LOT where ID = 'B511-20030046'
select * from MODETAIL where CMOID = 'B511-20030014'
select * from LOT a
left join MODETAIL b on CMOID = ID
where 1=1
and a.STATUS =50 and ERP_OPSEQ =0020 
and CAST(LOTSIZE as float) > 0 and b.STATUS !='99' and b.STATUS !='100'
and a.ITEMID like '%BMH1227768%'
select  *  from LOT a 
left join MODETAIL b on CMOID = ID
where  1=1 --ERP_OPSEQ = '0010' and a.STATUS = '0' and b.STATUS !='99' and b.STATUS !='100'
and a.ITEMID LIKE '%1227768S11%'
and  cast( a.RELEASEDATETIME  as Date) >='20200407'
select distinct ERP_OPSEQ,a.STATUS from LOT a
left join MODETAIL b on CMOID = ID
order by ERP_OPSEQ

select  *  from MODETAIL where STATUS = '50' and ITEMID like '%1227768S11%'
select top(1) * from LOT
select top(1) * from SFT_TRANSORDER

select * from MODETAIL where CMOID = 'B511-20030014'
select *  from LOT where ID in(  'B511-20030014', 'B511-20030022')
select * from LOT where ITEMID like '%BMH1227768S11%' and STATUS = '0'

select  a.ID, a.ITEMID,LOTSIZE, a.UNIT  from LOT a 
left join MODETAIL b on CMOID = ID
where  1=1 
and ERP_OPSEQ = '0020'
and a.STATUS = '130'
--and b.STATUS !='99' and b.STATUS !='100'
and a.ITEMID LIKE '%EB-TFR-I394-BLACK%'
--MOCTA --SFCTA  SFCTC SFCTB
--SFT_TRANSORDER_LINE SFT_TRANSORDER SFT_TRANSORDER_FIN
--SFT_OP_REALRUN SFT_WS_RUN
--LOT  MODETAIL

--SFT_COLLECTITEM_SUBLINE
--SFT_COLLECTITEM_LINE 
--SFT_OP_EXCEPT

--EB-TFR-I656-BLACK
select * from MODETAIL where ITEMID ='EB-TFR-I394-BLACK'
--A511-19020052
select top(1) * from SFT_OP_EXCEPT
select * from MODETAIL where CMOID = 'B511-19120020'
select *  from LOT where ID = 'B511-19120020'
select * from SFT_TRANSORDER where KEYID = 'B511-19120020'
order by cast(CREATE_DATE as datetime)
select * from SFT_TRANSORDER_LINE where KEYID = 'B511-19120020' and TRANSORDERTYPE ='D301'
order by cast(CREATE_DATE as datetime)
select * from SFT_OP_REALRUN where ID = 'A511-19010265'
order by cast(OUTTIME as datetime)--
select * from SFT_WS_RUN where ID = 'A511-19010265'--Record lai trang thai SFT
order by cast(EXECUTETIME as datetime)
select * from SFT_OP_EXCEPT where ID ='A511-19010265'

--delete from SFT_TRANSORDER where TRANSTYPE = 'D301' and TRANSNO = '02004240001'

select * from SFT_TRANSORDER_LINE where TRANSORDERTYPE ='D301' and TRANSNO = '02004240001'

--delete  from SFT_WS_RUN where ID = 'A511-19010265' and SEQUENCE =310

update LOT set MO009 = '6566', MO027 = '2618.364'
where CMOID ='A511-19010265' and STATUS =99


update LOT set MO009 = '300', MO027 = '87.6'
where CMOID ='A511-19010265' and STATUS =130

update LOT set LOTSIZE = '6566.000' , PKQTY = '2618.364'
where ID ='A511-19010265' and STATUS = 99

update LOT set LOTSIZE = '300' , PKQTY = '87.6'
where ID ='A511-19010265' and STATUS = 130

 select  a.ID, a.ITEMID,LOTSIZE, a.UNIT  from LOT a 
left join MODETAIL b on CMOID = ID
where  1 = 1
and ERP_OPSEQ = '0020'
and a.STATUS = '130'
and b.STATUS != '99' and b.STATUS != '100' and a.ITEMID LIKE '%768%'






select * from LOT where  ERP_OPSEQ = '0030' and STATUS = 50  

select top(1) * from SFT_TRANSORDER


select isnull(max(SEQUENCE),'0')+ 1 from SFT_WS_RUN where ID = 'A511-190102'



select distinct ID from LOT where STATUS != '99'
and STATUS ='130'

select * from LOT where ID ='B511-19120020' and STATUS =99

 select *  from LOT where ID in ( 'B511-19120020','A511-19010265') and STATUS =99

 select * from MODETAIL where CMOID ='B511-19120020' 
 --B511-19120020 02004250001

select * from SFT_TRANSORDER where cast(CREATE_DATE as datetime) > '20200501'
select * from SFT_TRANSORDER_LINE where cast(CREATE_DATE as datetime) > '20200501'

select * from SFT_TRANSORDER where TRANSTYPE ='D301'
select * from SFT_TRANSORDER_LINE where TRANSORDERTYPE = 'D301' and TRANSNO ='01911290015'

select * from SFT_WS_RUN

select * from SFT_TRANSORDER_LINE where TRANSORDERTYPE = 'D301' and TRANSNO ='01911290015'
select * from SFT_TRANSORDER where TRANSTYPE ='D301' and TRANSNO ='02005060001'
--------------------------------------------

select * from SFT_TRANSORDER_LINE where TRANSORDERTYPE = 'D301'-- and TRANSNO ='02005210015'
and cast(CREATE_DATE as date )>= '20200521'
select * from SFT_TRANSORDER where TRANSTYPE ='D301' and TRANSNO ='02005210015'
select * from SFT_WS_RUN where ID = 'B511-20020051'--Record lai trang thai SFT
and EXECUTETYPE = 'IntoWH'
select * from SFT_WS_RUN where ID = 'B511-20020046'--Record lai trang thai SFT
and EXECUTETYPE = 'IntoWH'

select *  from LOT where ID = 'B511-20020051' AND STATUS =99;
select *  from LOT where ID = 'B511-20020046' AND STATUS =99 ;

select * from MODETAIL where CMOID = 'A511-19010265'
select * from MODETAIL where CMOID = 'B511-20020046'

---------------------
delete from SFT_TRANSORDER_LINE where TRANSORDERTYPE = 'D301' and TRANSNO ='02005060001'
delete from SFT_TRANSORDER where TRANSTYPE ='D301' and TRANSNO ='02005060001'
delete  from SFT_WS_RUN where ID = 'B511-20020051'--Record lai trang thai SFT
and EXECUTETYPE = 'IntoWH'
delete from SFT_WS_RUN where ID = 'B511-20020046'--Record lai trang thai SFT
and EXECUTETYPE = 'IntoWH'
DELETE  from LOT where ID = 'B511-20020051' AND STATUS =99;
DELETE  from LOT where ID = 'B511-20020046' AND STATUS =99 ;
-----------------------------------------------------------
--B511-20020041       
--B511-20030023       
--B511-20030024       
select * from MODETAIL where CMOID = 'B511-20020041' 
select * from LOT where ID = 'B512-20040001' 


select * from SFT_WS_RUN where ID ='B512-20040001' 
order by CAST(EXECUTETIME as datetime)

select * from SFT_TRANSORDER where KEYID = 'A511-19010265'

select distinct EXECUTETYPE,ERP_OPSEQ,ERP_OPID, ERP_WSID from SFT_WS_RUN
where ERP_OPSEQ ='0020' and ERP_OPID ='B02'
  update LOT set  LOTSIZE =LOTSIZE - 50,   PKQTY = PKQTYPER * LOTSIZE  where ID  ='B511-20020086' and STATUS =130 and ERP_OPSEQ ='0020' 

  ----------------------------- xUAT TRAM PQC
select * from MODETAIL where CMOID = 'B511-20020041'
select *  from LOT where ID = 'B511-20020041'
select * from SFT_TRANSORDER where KEYID = 'B511-20020041'
order by cast(CREATE_DATE as datetime)
select * from SFT_TRANSORDER_LINE where KEYID = 'B511-20020041'
order by cast(CREATE_DATE as datetime)
select * from SFT_OP_REALRUN where ID = 'B511-20020041'
order by cast(OUTTIME as datetime)--


select *  from LOT where ID = 'A511-19010265' and STATUS = 50 and ERP_OPSEQ = '0020'
select * from SFT_WS_RUN where ID = 'A511-19010265'--Record lai trang thai SFT
order by cast(EXECUTETIME as datetime)

select ID from LOT where LOTSIZE > 0  and STATUS = 50
and ERP_OPSEQ ='0020'
and ITEMID like '%1227768%'
  

   select a.TA001+'-'+ a.TA002 as PO from TLVN2.dbo.SFCTA a
 inner join TLVN2.dbo.MOCTA b on a.TA001 = b.TA001 and a.TA002 = b.TA002
 inner join SFT_TLVN2.dbo.LOT l on l.ID = a.TA001+'-'+a.TA002
 where  a.TA003 = '0020' and CAST(a.CREATE_DATE as datetime) > '20200101'
 and a.TA010>a.TA011+a.TA012 and a.TA032 ='N'
 and l.LOTSIZE > 0 and l.STATUS = 50 and l.ERP_OPSEQ = '0020'
 and  b.TA006 like '%1227768%'


 select * from LOT where ID = 'B511-20040018        '

 select * from SFT_WS_RUN where ID = 'B511-20040018'--Record lai trang thai SFT
 and SEQUENCE =506
order by cast(EXECUTETIME as datetime)

SELECT * FROM SFT_OP_EXCEPT WHERE ID ='B511-20040018'

SELECT ID,SEQUENCE,ARRIVEQTY,OUTQTY,TOID, TOSN, OPID,ERP_OPSEQ,ERP_OPID, ERP_WSID,REPORTSTOCKIN ,OR001 , OR002, OR003, OR004, OUTTIME ,REPORTSTOCKIN
FROM SFT_OP_REALRUN WHERE ID ='B511-20040018' and REPORTSTOCKIN = 1
and CAST(OUTTIME AS date) > '20200507'
ORDER BY CAST(OUTTIME AS datetime)

SELECT *
FROM SFT_OP_REALRUN WHERE ID ='B511-20020101' --and REPORTSTOCKIN = 1
and CAST(OUTTIME AS date) > '20200507'
ORDER BY CAST(OUTTIME AS datetime)
 select * from LOT where ID = 'B512-20040001'

 select top(1) * from LOT where ID ='B512-20040001       ' 
select ID,SEQUENCE, ERP_OPSEQ, ERP_OPID, ERP_WSID from  SFT_OP_REALRUN
where ID ='B511-20020097'

select  ID,SEQUENCE,ARRIVEQTY,OUTQTY,TOID, TOSN, OPID,ERP_OPSEQ,ERP_OPID, 
ERP_WSID,REPORTSTOCKIN ,OR001 ,
OR002, OR003, OR004, OUTTIME from SFT_OP_REALRUN where REPORTSTOCKIN = 1

select MAX(SEQUENCE)+1 from SFT_OP_REALRUN where ERP_OPSEQ ='0020' and ERP_OPID ='A02' and ERP_WSID ='A01'
and ID ='A511-19010265' 

select LOTSIZE from LOT where STATUS = 50 and ERP_OPSEQ = '0020' AND ERP_OPID ='B02'
AND ID = 'B511-20030023' 


 select * from LOT where ID = 'B511-20030024' 
---BMH1227768S11

 select * from SFT_OP_REALRUN  where 1=1 
 AND ERP_OPSEQ ='0020' and ERP_OPID ='B02' and ERP_WSID ='B01'
 AND ID = 'B511-19020015'

  select * from SFT_OP_REALRUN  where 1=1 AND ID = '' AND ERP_OPSEQ ='0020' and ERP_OPID ='B02' and ERP_WSID ='B01'


 select * from MODETAIL where CMOID = 'B511-20020188'
select *  from LOT where ID = 'B511-20030023'
select * from SFT_TRANSORDER where KEYID = 'B511-20020188'
order by cast(CREATE_DATE as datetime)
select * from SFT_TRANSORDER_LINE where KEYID = 'B511-20020188'
order by cast(CREATE_DATE as datetime)

select * from SFT_OP_REALRUN where ID =  'B511-20020066'
and OR013 = 8
order by cast(OUTTIME as datetime)--
 select * from SFT_WS_RUN where ID =  'B511-20020188'--Record lai trang thai SFT

order by cast(EXECUTETIME as datetime)


select * from SFT_OP_REALRUN where ID =  'B511-20020066'
and OR013 = 8
update  SFT_OP_REALRUN set OR014 = 'TEST', OR003 ='B02', OR004 ='B01' where ID =  'B511-20020066'
and OR013 = 8

-------------------------------sft------------

--B511-20020041       
--B511-20030023       
--B511-20030024   

---B511-20030005   
--B511-20030006   
--B511-20040001  

--B511-20020003   
--B511-20020001   
--B511-20020002   


 select * from MODETAIL where CMOID = 'B511-20030005'

select *  from LOT where ID = 'B511-20020003'
select *  from LOT where ID = 'B511-20020001'
select *  from LOT where ID = 'B511-20020002'

select * from LOT  where 1=1  and ID = 'B511-20020003       '  and STATUS = '130'  and ERP_OPSEQ ='0020'





update LOT set  LOTSIZE =LOTSIZE - 100,   PKQTY = PKQTYPER * LOTSIZE  where ID  ='B511-20020003       ' and STATUS =50 and ERP_OPSEQ ='0020' 

update LOT set  LOTSIZE =LOTSIZE + 100,   PKQTY = PKQTYPER * LOTSIZE  where ID  ='B511-20020003       ' and STATUS =50 and ERP_OPSEQ ='0020' 



select * from SFT_TRANSORDER where KEYID = 'B511-20020041'
order by cast(CREATE_DATE as datetime)
select * from SFT_TRANSORDER_LINE where KEYID = 'B511-20020041'
order by cast(CREATE_DATE as datetime)
select * from SFT_OP_REALRUN where ID = 'B511-20020041'
order by cast(OUTTIME as datetime)--
 select * from SFT_WS_RUN where ID = 'B511-20020041'--Record lai trang thai SFT
order by cast(EXECUTETIME as datetime)
------------------------------------------------
select * FROM SFT_TRANSORDER 
WHERE  TRANSTYPE = 'D301' AND TRANSNO = '02005210018'
select * FROM SFT_TRANSORDER_LINE
WHERE  TRANSORDERTYPE = 'D301' AND TRANSNO ='02005210018'

select * from SFT_WS_RUN where ID = 'B511-20020041' 
order by cast(EXECUTETIME as datetime)
 select * from SFT_WS_RUN where ID = 'B511-20030023' 
order by cast(EXECUTETIME as datetime)
 select * from SFT_WS_RUN where ID = 'B511-20030024'--Record lai trang thai SFT
order by cast(EXECUTETIME as datetime)

SELECT * FROM SFT_TRANSORDER WHERE TRANSDATE ='20200511' --AND TRANSTYPE = 'D301'
ORDER BY CAST(CREATE_DATE AS datetime) 

select * from SFT_TRANSORDER where KEYID = 'B511-20050011'
 
 select MAX(SEQUENCE)+1 from SFT_OP_REALRUN where 1=1 and ERP_OPSEQ ='0020'
 and ERP_OPID ='B02' and ERP_WSID ='B01' and ID ='B511-20050002'


