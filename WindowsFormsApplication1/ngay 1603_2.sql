-----------In MQC BTP
select  sum(LOTSIZE)  from LOT a 
left join MODETAIL b on CMOID = ID
where  ERP_OPSEQ = '0010' and a.STATUS = '0' and b.STATUS !='99' and b.STATUS !='100' 
and a.ITEMID ='EB-FC-I389B-TM'
-----------Out MQC BTP
select  sum(LOTSIZE)  from LOT a 
left join MODETAIL b on CMOID = ID
where   ERP_OPSEQ = '0010' and a.STATUS = '50' and b.STATUS !='99' and b.STATUS !='100' 
and a.ITEMID ='EB-FC-I389B-TM'
------------int PQC
select  sum(LOTSIZE)  from LOT a 
left join MODETAIL b on CMOID = ID
where   ERP_OPSEQ = '0020' and a.STATUS = '0' and b.STATUS !='99' and b.STATUS !='100' 
and a.ITEMID ='EB-FC-I389B-TM'
------------Out PQC
select  sum(LOTSIZE)  from LOT a 
left join MODETAIL b on CMOID = ID
where  ERP_OPSEQ = '0020' and a.STATUS = '50' and b.STATUS !='99' and b.STATUS !='100' 
and a.ITEMID ='EB-FC-I389B-TM'
------------Stock Into warehouse
select  sum(LOTSIZE)  from LOT a 
left join MODETAIL b on CMOID = ID
where  ERP_OPSEQ = '0020' and a.STATUS = '130' and b.STATUS !='99' and b.STATUS !='100'  
and a.ITEMID ='EB-FC-I389B-TM'