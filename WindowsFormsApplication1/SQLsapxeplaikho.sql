select * from INVTA where TA001 ='1103' and TA002 = '20020008'
select * from  INVTB  where  TB001 = '1103' and TB002 ='20020008'
select * from INVLA where LA006 = '1103' and LA007 ='20020008'
select * from INVLF where LF001 = '1103' and LF002 ='20020008'
select * from INVMF where MF004 ='1103' and MF005 = '20020008'

select *  from INVMM
where 1=1  and MM001 = 'BY855MHT-14' and MM002 = 'Y12' and MM003 ='B14'  and MM004 = 'SM8K45'  
select *  from INVMM
where 1=1  and MM001 = 'BY855MHT-14' and MM002 = 'Y12' and MM004 = 'SM8K45'   and MM003 ='B20' 
select *  from INVMM
where 1=1  and MM001 = 'BY855MHT-14' and MM002 = 'Y12' and MM004 = 'SM8K45'   and MM003 ='B25' 


select *   from INVMC where 1=1  and MC001 = 'BY855MHT-14' and MC002 = 'Y12'
select *   from INVMC where 1=1  and MC001 = 'BY855MHT-14' and MC002 = 'Y12'

select top(1) * from INVME

select top(1) * from CMSMQ where 1=1 and MQ001 ='1103'
select top(1) * from INVTB where TB004 ='BY855MHT-14'
and CREATE_DATE = ( select MAX(CREATE_DATE) from INVTB where TB004 ='BY855MHT-14')


select max(TA002) from INVTA where TA001 = '1103'
select top(1) * from INVTA where TA001 ='1103' and TA002 = '1912002' 
--------------------------------------------------------------------------------------------
delete from INVTA where TA001 ='1103' and TA002 = '20020008'
delete from  INVTB  where  TB001 = '1103' and TB002 ='20020008'
delete from INVLA where LA006 = '1103' and LA007 ='20020008'
delete from INVLF where LF001 = '1103' and LF002 ='20020008'
delete from INVMF where MF004 ='1103' and MF005 = '20020008'
-------------------------------------------------
insert into INVTB ( COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,TB001,TB002,TB003,TB004,TB005,TB006,TB007,TB008,TB009,TB010,TB011,TB012,TB013,TB014,TB015,TB016,TB017,TB018,TB019,TB020,TB021,TB022,TB023,TB024,TB025,TB026,TB027,TB028,TB029,TB030,TB031,TB032,TB500,TB501,TB502,UDF01,UDF02,UDF03,UDF04,UDF05,UDF06,UDF07,UDF08,UDF09,UDF10,TB200,TB201,TB202)
values (  'TLVN2', 'TEST4', 'JG01', '20200205', 'NULL', 'NULL', '1', '11:28:09', 'MSI', 'INVI05', 'NULL', 'NULL', 'NULL', '1103', '20020001', '0001', 'BY855MHT-11B', 'TL-855MHT(11) B', '', '500', '', '', '', '0', 'Y12       ', '', '11BKM02             ', '20191211', '20191211', '', 'Y', '20200205', '', '', '0.000', '', 'N', '0.000', 'B15       ', '', '0.000000', '0.000000', '', '', '', '', '', '', '', '', '', '', '', '0.000000', '0.000000', '0.000000', '0.000000', '0.000000', 'N', '','')


select * from CMSME

SELECT TOP(1) * FROM INVMM
SELECT TOP(1) * FROM INVME

select *, ME009 from INVMM 
inner join INVME  on MM001 = ME001 and MM004 = ME002
where 1=1 and MM002 ='Y12' and ME009 > '20200206'