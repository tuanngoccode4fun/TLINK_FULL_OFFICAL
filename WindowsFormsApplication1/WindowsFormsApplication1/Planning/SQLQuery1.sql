select * from COPTC 
select * from COPTD

select distinct ProductName, productNo 
from (
select smes.ME002 as Dept,TD001, TD002, TD004 as ProductName,TD005 as productNo,
sum(TD008) as ClientRequestQty,sum(TD009) as DeliveryQty, TD013 as ClientRequestDate from COPTD ptd
inner join COPTC ptc on ptc.TC001 = ptd.TD001 and ptc.TC002 = ptd.TD002
left join CMSME smes on smes.ME001 = ptc.TC005
where  ptc.TC027 ='Y' and TD001 like '%B%' and ( TD004 like '%BMH%' or  TD004 like '%BWTX%')
group by TD001,TD002,TD005, TD013,smes.ME002,TD004

) DDH 

 select distinct TE017 from MOCTA 
 left join MOCTE on TA001 = TE011 and TA002 = TE012
 where  (TE018 like '%HENN%' ) and TE019 ='Y'  and TA034 like '%68S01%'

 select * from INVMB
where MB001 like '%HC45-15FPM%'

 select  MC007 from INVMC
where  MC002 = 'A12' and MC001 like '%HC45-15FPM%' 


 select MB064 from INVMB where 1=1 and MB001 like '%355S01%'

 select  MC007 from INVMC
where  MC002 = 'A12' and MC001   like '%HC45-15FPM%' 


 





