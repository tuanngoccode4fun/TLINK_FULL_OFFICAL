insert into INVMF ( COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,MF001,MF002,MF003,MF004,MF005,MF006,MF007,MF008,MF009,MF010,MF011,MF012,MF013,MF014,MF015,MF016,MF017,MF018,MF019,MF020,MF021,MF500,MF501,MF502,MF503,MF504,MF505,MF506,UDF01,UDF02,UDF03,UDF04,UDF05,UDF06,UDF07,UDF08,UDF09,UDF10)
values (  'TLVN2', 'TEST4', 'GS', '20200108', '', '', '1', '08:47:48', 'Toluen PC', 'INVMI08', '', '', '', 'BY011-2000                              ', '15122019            ', '00010101', '1201', '20010002', '0001', 'Y01', '-1', '4', '250', '', '', '', '0.000', '', '0.000000', '0.000000', '', '', '', '', '', '', '0.000', '0.000', '0.0000', '', '', '', '', '', '', '', '0.000000', '0.000000', '0.000000', '0.000000','0.000000')

insert into INVLA ( COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,LA001,LA004,LA005,LA006,LA007,LA008,LA009,LA010,LA011,LA012,LA013,LA014,LA015,LA016,LA017,LA018,LA019,LA020,LA021,LA022,LA023,LA024,LA025,LA026,LA027,LA028,LA029,LA030,LA031,LA032,LA033,LA034,UDF01,UDF02,UDF03,UDF04,UDF05,UDF06,UDF07,UDF08,UDF09,UDF10) 
values (  'TLVN2', 'TEST4', 'GS', '20200108', '', '', '1', '08:48:28', 'Toluen PC', 'INVMI08', '', '', '', 'BY011-2000', '00010101', '1', '1201', '20010002', '0001', 'B05', '', '250', '0.000000', '0.000000', '4', 'N', '15122019', '0.000000', '0.000000', '0.000000', '0.000000', '0.000', 'DataGridViewTextBoxCell { ColumnIndex=16, RowIndex=0 }', '0.000000', '0.000000', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '0.000000', '0.000000', '0.000000', '0.000000','0.000000')

insert into INVLF ( COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,LF001,LF002,LF003,LF004,LF005,LF006,LF007,LF008,LF009,LF010,LF011,LF012,LF013,LF014,LF015,LF016,LF017,LF018,LF019,UDF01,UDF02,UDF03,UDF04,UDF05,UDF06,UDF07,UDF08,UDF09,UDF10) values (  'TLVN2', 'TEST4', 'GS', '20200108', '', '', '1', '08:56:03', 'Toluen PC', 'INVMI08', '', '', '', '1201', '20010002', '0001', 'BY011-2000', 'B05', '1B', '18122019', '1', '00010101', '4', '250', '0.000', '', '0.000000', '0.000000', '', '', '', '', '', '', '', '', '', '0.000000', '0.000000', '0.000000', '0.000000','0.000000')

select * from INVTA where TA001 = '1103' and TA002 ='1912002'

select * from INVTB where TB001 = '1201' and TB002 ='20010003'

select top(100) * from BOMMO




select * from INVTB where TB001 = '1201' and TB002 ='20010003'


select * from INVLF where LF006 like '%#####%'


select * from INVMC where MC001 = 'BY855MHT' --and MC002 ='B05'
and (MODI_DATE> '20200107' or CREATE_DATE > '20200107')

select * from INVMM where MM001 = 'BY855MHT'  and MODI_DATE > '20200107'

update INVMC set FLAG = FLAG+1 
where MC001 = 'BY855MHT'  and MC002 ='B05' and (MODI_DATE> '20200107' or CREATE_DATE > '20200107')

select * from INVMC  --set MODI_DATE = '20200108' , FLAG = FLAG+1 , MODI_TIME = '04:04:05',  MC007 = MC007 - 230 ,  MC013 = '20200108'  
 where 1=1  and MC001 ='BY855MHT' and MC002 ='B05'


  update INVMM  set MODI_DATE = '20200108' , MODI_TIME = '16:16:55',  MM005 = MM005 + 230 ,  MM009 = '20200108'  
  where 1=1  and MM001 = -'BY855MHT' and MM002 ='B06' and MM003 ='' and MM004 ='S6M926K1'


   update INVMM  set MODI_DATE = '20200108' , MODI_TIME = '16:19:05',  MM005 = MM005 + 230 ,  MM009 = '20200108'  

   select top(100) * from INVMM
   where 1=1  and MM001 = 'BY855MHT'  and (MODI_DATE> '20200107' or CREATE_DATE > '20200107')

      select top(100) * from INVMC
   where 1=1  and MC001 = 'BY855MHT' and (MODI_DATE> '20200107' or CREATE_DATE > '20200107')


  delete from INVMM
   where 1=1  and MM001 = 'BY855MHT'  and (MODI_DATE> '20200107' or CREATE_DATE > '20200107')

    delete  from INVMC
   where 1=1  and MC001 = 'BY855MHT' and (MODI_DATE> '20200107' or CREATE_DATE > '20200107')


 select * from INVMC where 1=1 and MC001 ='BY855MHT' and MC002 ='B05'


 insert into INVMF ( COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,MF001,MF002,MF003,MF004,MF005,MF006,MF007,MF008,MF009,MF010,MF011,MF012,MF013,MF014,MF015,MF016,MF017,MF018,MF019,MF020,MF021,MF500,MF501,MF502,MF503,MF504,MF505,MF506,UDF01,UDF02,UDF03,UDF04,UDF05,UDF06,UDF07,UDF08,UDF09,UDF10) 
 values (  'TLVN2', 'TEST4', 'GS', '20200108', '', '', '1', '16:53:13', 'Toluen PC', 'INVMI08', '', '', '', 'BY011-2000   
 ', '15122019            ', '20200102', '1201', '20010002', '0001', 'B05', '1', '4', '250', '', '', '', '0.000', '', '0.000000', '0.000000', '', '', '', '', '', '', '0.000', '0.000', '0.0000', '', '', '', '', '', '', '', '0.000000', '0.000000', '0.000000', '0.000000','0.000000')


--delete  from INVLA where LA001 ='BY855MHT' and CREATE_DATE > '20200101' 

--delete  from INVLF where LF004 ='BY855MHT' and (MODI_DATE> '20200101' or CREATE_DATE > '20200101')
--delete  from INVMF where MF001 ='BY855MHT' and (MODI_DATE> '20200101' or CREATE_DATE > '20200101')

--delete  from INVMM
--   where 1=1  and MM001 = 'BY855MHT'  and (MODI_DATE> '20200101' or CREATE_DATE > '20200101')

--delete   from INVMC
--   where 1=1  and MC001 = 'BY855MHT' and (MODI_DATE> '20200101' or CREATE_DATE > '20200101')

  select * from  INVTB  where  TB001 = '1201' and TB002 ='20010002'

  --------------------------------------------------------------------------------
update   INVTA  set  TA006 ='N' where  TA001 = '1201' and TA002 ='20010009'

delete  from INVLA where LA001 ='BY011-2000' and CREATE_DATE > '20200101' and LA007 ='20010009'

delete from INVLF where LF004 ='BY011-2000'and (MODI_DATE> '20200101' or CREATE_DATE > '20200101') and LF002 ='20010009'

delete from INVMF where MF001 ='BY011-2000' and (MODI_DATE> '20200101' or CREATE_DATE > '20200101') and MF005 = '20010009'


delete  from INVMM
where 1=1  and MM001 = 'BY011-2000'  and (CREATOR ='' or MODIFIER ='')

delete   from INVMC
  where 1=1  and MC001 = 'BY011-2000' and (CREATOR ='' or MODIFIER ='')


-------------------------------1102-2001001 1102-20010005 1102-20010005 1201-20010021 1102-20010013   1201-20010025   

select * from INVTA where CREATE_DATE > '20200110'

--1101-2001008 1203-20010001 1102-20010014
select * from INVTA where TA001 ='1103' and TA002 = '1912002' 
select * from  INVTB  where  TB001 = '1103' and TB002 ='1912002'
select * from INVLA where LA006 = '1103' and LA007 ='1912002'

select * from INVLF where LF001 = '1103' and LF002 ='1912002'

select * from INVMF where MF004 ='1103' and MF005 = '1912002'

select *  from INVMM
where 1=1  and MM001 = 'BY855MHT-14' and MM002 = 'Y12' and MM003 ='B14'  and MM004 = 'SM8K45'  
select *  from INVMM
where 1=1  and MM001 = 'BY855MHT-14' and MM002 = 'Y12' and MM004 = 'SM8K45'   and MM003 ='B20' 

select *   from INVMC where 1=1  and MC001 = 'BY855MHT-14' and MC002 = 'Y12'
select *   from INVMC where 1=1  and MC001 = 'BY855MHT-14' and MC002 = 'Y12'



--update INVLA set MODIFIER = 'NULL', MODI_DATE ='NULL', MODI_TIME ='NULL', MODI_AP ='NULL', MODI_PRID ='NULL'
--where  CREATE_DATE > '20200108' and LA007 ='20010015'

select * from INVLA where  (MODI_DATE> '20200101' or CREATE_DATE > '20200101') and LA007 ='20010021'  and LA006 ='1201'

select * from INVLF where  (MODI_DATE> '20200101' or CREATE_DATE > '20200101') and LF002 ='20010021'  and LF001='1201'

select * from INVMF where  (MODI_DATE> '20200101' or CREATE_DATE > '20200101') and MF005 = '20010021'  and MF004 ='1201'
----------------------------------
select * from INVLA where LA006 = 'B541' and LA007 ='20010021'

select * from INVLF where LF001 = '1102' and LF002 ='20010021'

select * from INVMF where MF004 ='1102' and MF005 = '20010021'

update INVLF set MODIFIER = 'NULL', MODI_DATE ='NULL', MODI_TIME ='NULL', MODI_AP ='NULL', MODI_PRID ='NULL'
where  CREATE_DATE > '20200108' and LF002 ='20010015'
update INVMF set MODIFIER = 'NULL', MODI_DATE ='NULL', MODI_TIME ='NULL', MODI_AP ='NULL', MODI_PRID ='NULL'
where  CREATE_DATE > '20200108' and MF005='20010015'
--------------------------------------------------------------------------------------------------

select *  from INVMM
where 1=1  and MM001 = 'BY855MHT-14' and MM002 = 'Y12' and MM003 ='B05' and MM004 = 'SM8K56'  and (CREATOR ='BCG01' or MODIFIER ='BCG01' ) 
and (CREATE_DATE ='20200114' or MODI_DATE = '20200114')

select *  from INVMM
where 1=1  and MM001 = 'BY855MHT-14'   and (CREATOR ='BCG01' or MODIFIER ='BCG01' )
and (CREATE_DATE ='20200114' or MODI_DATE = '20200114' )--and MM005 ='604'

select *   from INVMC
  where 1=1  and MC001 = 'BY855MHT-14' and MC002 = 'Y12' and (CREATOR ='BCG01' or MODIFIER ='BCG01' ) 
  and (CREATE_DATE ='20200114' or MODI_DATE = '20200114' )

------------------------------------------------------------------------------

  select * from PURTG where (MODI_DATE> '20200108' or CREATE_DATE > '20200108')
    select * from PURTH where (MODI_DATE> '20200108' or CREATE_DATE > '20200108')


	update   INVTA  set  TA006 ='N' where  TA001 = '1201' and TA002 ='20010004'

	 update INVMM  set MODI_DATE = '20200109' , MODI_TIME = '11:49:17',  MM005 = MM005 + 50 ,  MM009 = '20200109'  
	 where 1=1  and MM001 = 'BY011-2000' and MM002 ='B05' and MM003 ='2B' and MM004 ='15122019'


	 insert into INVMM ( COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,MM001,MM002,MM003,MM004,MM005,MM006,MM007,MM008,MM009,MM010,MM011,MM012,MM013,MM014,MM015,MM016,MM017,UDF01,UDF02,UDF03,UDF04,UDF05,UDF06,UDF07,UDF08,UDF09,UDF10) 
	 values (  'TLVN2', '', '', '20200109', 'ERP', '20191127', '1', '13:20:22', '', 'INVMI08', '08:14:43', 'SFT', 'Invb02', 'BY011-2000', 'Y12', 'B11', 'SKPQ23', '-500', '0', '', '20200109', '', '', '0', '', '0', '0', '', '', '', '', '', '', '', '', '0.000000', '0.000000', '0.000000', '0.000000','0.000000')


	 select * from INVMM where MM001 ='BY011-2000' and MM002 ='Y12' and MM003 ='B11' and MM004 ='SKPQ23'


	 insert into INVMM ( COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,MM001,MM002,MM003,MM004,MM005,MM006,MM007,MM008,MM009,MM010,MM011,MM012,MM013,MM014,MM015,MM016,MM017,UDF01,UDF02,UDF03,UDF04,UDF05,UDF06,UDF07,UDF08,UDF09,UDF10) 
	 values (  'TLVN2', '', '', '20200109', '', '', '1', '14:11:59', '', 'INVMI08', '', '', '', 'BY855MHT-14', 'Y12', 'B14', 'SM8K45', '-800', '0', '', '20200109', '', '', '0', '', '0', '0', '', '', '', '', '', '', '', '', '0.000000', '0.000000', '0.000000', '0.000000','0.000000')

	 select * from INVMM where 1=1 and MM001 ='BY855MHT-14' and MM002 ='Y12' and MM003 ='B14' and MM004='SM8K45'



--	 SELECT t.[text], s.last_execution_time, qp.query_plan
--FROM sys.dm_exec_cached_plans AS p
--INNER JOIN sys.dm_exec_query_stats AS s
--   ON p.plan_handle = s.plan_handle
--CROSS APPLY sys.dm_exec_sql_text(p.plan_handle) AS t
--CROSS APPLY sys.dm_exec_query_plan(p.plan_handle) qp
--WHERE s.last_execution_time > '2020-01-09 16:04:00.583'  and s.last_execution_time < '2020-01-09 16:07:00.583' 
--ORDER BY s.last_execution_time DESC 
select DISTINCT TA001,LEN(TA001)+ LEN(TA002)+1 AS COUNT from INVTA 
GROUP BY TA001,TA002

select top(100 )* from PURTH

select top(1) * from INVTB WHERE TB001 ='1201' AND TB002 ='20010021'

select DISTINCT TA001,LEN(TA001)+ LEN(TA002)+1 AS COUNT from INVTA 
GROUP BY TA001, TA002

SELECT TOP(1) * FROM MOCTC WHERE TC001 ='5401' AND TC002 ='1901001'


SELECT TOP(1) * FROM MOCTE WHERE TE001 ='5401' AND TE002 ='1901001'

select TOP(1) * from INVTA where TA001 ='5401' and TA002 = '20010035' 
select  * from  INVTB  where  TB001 = '5401' and TB002 ='20010035'
select TOP(1) * from INVLA where LA006 = '5401' and LA007 ='20010035'

select TOP(1) * from INVLF where LF001 = '5401' and LF002 ='20010035'

select TOP(1) * from INVMF where MF004 ='5401' and MF005 = '20010035'


select * from ADMMF where MF001 ='TEST4'
select top(1)* from PURTG where TG001 ='3401' and TG002 = '20010034'

select TD001, TD002, TD003, TD004, TD005,TD007,TD008,TD009,TD012,TD015, TD018 from PURTD where 1=1
and TD001 ='A331' and TD002 = '19120002'

select top(100) * from INVLA
select top(100) * from INVLF
select top(100) * from INVMF
select top(100) * from INVMM
select top(100) * from INVMC


select distinct MM002 from INVMM 
where MM002 !=''

select * from INVMM where 1=1 and MM002 like '%Y12%'

insert into INVLA ( COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,LA001,LA004,LA005,LA006,LA007,LA008,LA009,LA010,LA011,LA012,LA013,LA014,LA015,LA016,LA017,LA018,LA019,LA020,LA021,LA022,LA023,LA024,LA025,LA026,LA027,LA028,LA029,LA030,LA031,LA032,LA033,LA034,UDF01,UDF02,UDF03,UDF04,UDF05,UDF06,UDF07,UDF08,UDF09,UDF10) values (  'TLVN2', 'TEST4', 'JG01', '20200205', 'NULL', 'NULL', '1', '14:14:44', 'MSI', 'INVMI08', 'NULL', 'NULL', 'NULL', 'BY855MHT-14                             ', '20200205', '1', '1103', '20020001', '0001', 'Y12       ', '', '5', '0', '0', '5', 'Y', 'SM6K29              ', '0', '0', '0.000000', '0.000000', '13.446', 'B15       ', '0.000000', '0.000000', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '0.000000', '0.000000', '0.000000', '0.000000','0.000000')

insert into INVLA ( COMPANY,CREATOR,USR_GROUP,CREATE_DATE,MODIFIER,MODI_DATE,FLAG,CREATE_TIME,CREATE_AP,CREATE_PRID,MODI_TIME,MODI_AP,MODI_PRID,TA001,TA002,TA003,TA004,TA005,TA006,TA007,TA008,TA009,TA010,TA011,TA012,TA013,TA014,TA015,TA016,TA017,TA018,TA019,TA020,TA021,TA022,TA023,TA024,TA025,TA026,TA027,TA028,UDF01,UDF02,UDF03,UDF04,UDF05,UDF06,UDF07,UDF08,UDF09,UDF10,CFIELD01) values (  'TLVN2', 'TEST4', 'JG01', '20200205', 'NULL', 'NULL', '1', '14:15:14', 'MSI', 'INVMI08', 'NULL', 'NULL', 'NULL', '1101', '1812001    ', '20190101', 'B01', '', 'Y', '1', 'TL', '11', '0', '30.000', '0.000000', 'N', '20190101', 'BCW02', '0.000', 'N', '0', '0', '', '', '', '0.000000', '0.000000', '', '', '', '', '', '', '', '', '', '0.000000', '0.000000', '0.000000', '0.000000', '0.000000','1101-1812001    ')