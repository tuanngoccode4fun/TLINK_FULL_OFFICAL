select smes.ME002 as Dept,TD001 + '-' + TD002 as DDH, TC012 as ClientOrder,TD004 as product ,TD005 as productName,
sum(TD008) as QuantityOfOrder, sum(TD009) as QuantityOfDelivery, TD013 as ClientRequestDate from COPTD ptd
inner join COPTC ptc on ptc.TC001 = ptd.TD001 and ptc.TC002 = ptd.TD002
left join CMSME smes on smes.ME001 = ptc.TC005
where  ptc.TC027 ='Y' 
and TD001 like 'A%' 
and TD016 ='N'
-- and ( TD004 like '%BMH%' or  TD004 like '%BWTX%')  
 and CONVERT(date,ptd.TD013)  >= '20200313'  
 and CONVERT(date,ptd.TD013) <= '20200403'  group by TD001,TC012, TD002,TD005, TD013,smes.ME002,TD004
order by TD013

select smes.ME002 as Dept,TD001 + '-' + TD002 as DDH, TC012 as ClientOrder,TD004 as product ,TD005 as productName,
sum(TD008) as QuantityOfOrder, sum(TD009) as QuantityOfDelivery, TD013 as ClientRequestDate from COPTD ptd
inner join COPTC ptc on ptc.TC001 = ptd.TD001 and ptc.TC002 = ptd.TD002
left join CMSME smes on smes.ME001 = ptc.TC005
where  ptc.TC027 ='Y'  and TD016 ='N'
 and TD001 like 'A%'  and CONVERT(date,ptd.TD013)  >= '20200316'  and CONVERT(date,ptd.TD013) <= '20200406'  group by TD001,TC012, TD002,TD005, TD013,smes.ME002,TD004
order by TD013

select MC001,MC002,MC007 from INVMC where  (MC002 = 'A03' or MC002 = 'A09')
and MC001 = 'EB-FC-I389B-TM'

-----tu san pham tim ra kinh va ngu kim 
--AB-CL-I013-186C
--AB-CL-C674-186C

--ban thanh pham cua san pham
select * from BOMMD where 
 (MD003 like 'AB-%' or MD003 like 'EB-%' or MD003 like 'CB-%') 
and MD012 = '' and MD003 ='AB-FKM-I074-3020P'

---- Ban thanh pham cua ban thanh pham
select * from BOMMD where MD001 = 'EB-TFR-C876-BLACK'
and (MD003 like 'AB-%' or MD003 like 'EB-%' or MD003 like 'CB-%') 
and MD012 = ''

---Tim ra kinh va ngu kim
select MD003,MC002,MC007 from BOMMD 
inner join  INVMC on MD003 = MC001
where 1=1 and MC007  > '0' and MD001 = 'AB-CL-I013-186C'  --
and (MD003 like 'ABL%' or MD003 like 'AWJ%' ) 
and (MC002 ='Y22' or (MC002 = 'A07' or MC002 ='A01' or MC002 = 'W01' or MC002 = '002'))

select  isnull(sum(LOTSIZE),'0')  from LOT a 
left join MODETAIL b on CMOID = ID
where  ERP_OPSEQ = '0010' and a.STATUS = '0' and b.STATUS !='99' and b.STATUS !='100' 
  and a.ITEMID =  'AB-CL-I013-186C'


  select MD003,MC002,MC007 from BOMMD 
inner join  INVMC on MD003 = MC001
where 1=1 and MD012 ='' and MC007  > '0'
 and (MD003 like 'ABL%' or MD003 like 'AWJ%' )
 and (MD002 = 'A07' or MD002 ='A01' or MD002 = 'W01' or MD002 = '002')

 select MD003,MC002,MC007 from BOMMD 
inner join  INVMC on MD003 = MC001
where 1=1 and MD012 ='' and MC007  > '0'
 and MD001   like '%AB-TCB-I477-7733C%'   and (MD003 like 'ABL%' or MD003 like 'AWJ%' )  
 and (MD002 = 'A07' or MD002 ='A01' or MD002 = 'W01' or MD002 = '002')

 select smes.ME002 as Dept,TD001 + '-' + TD002 as DDH, TC012 as ClientOrder,TD004 as product ,TD005 as productName,
sum(TD008) as QuantityOfOrder, sum(TD009) as QuantityOfDelivery, TD013 as ClientRequestDate from COPTD ptd
inner join COPTC ptc on ptc.TC001 = ptd.TD001 and ptc.TC002 = ptd.TD002
left join CMSME smes on smes.ME001 = ptc.TC005
where  ptc.TC027 ='Y'  and TD016 ='N'  
 and CONVERT(date,ptd.TD013)  >= '20200330'  and CONVERT(date,ptd.TD013) <= '20200420' 
 group by TD001,TC012, TD002,TD005, TD013,smes.ME002,TD004
order by TD013 


select MD003,MC002,MC007 from BOMMD 
inner join  INVMC on MD003 = MC001
where 1=1 and MD012 ='' and MC007  > '0'
 and MD001   like '%EB-TFR-C1368-CHOCO%'   and (MD003 like 'ABL%' or MD003 like 'AWJ%' )   and (MD002 = 'A07' or MD002 ='A01' 
 or MD002 = 'W01' or MD002 = '002')

 select MD003,MC002,MC007 from BOMMD 
inner join  INVMC on MD003 = MC001
where 1=1 and MD012 ='' and MC007  > '0'
 and MD001   like '%EB-TFR-C1368-CHOCO%'   and (MD003 like 'ABL%' or MD003 like 'AWJ%' )  
 and (MC002 = 'A07' or MC002 ='A01' or MC002 = 'W01' or MC002 = '002') 
