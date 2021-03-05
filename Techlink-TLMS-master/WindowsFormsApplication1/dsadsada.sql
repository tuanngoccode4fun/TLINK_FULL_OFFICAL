select distinct serno, lot, model, site, factory, line, process, item, inspectdate, inspecttime, data, judge, status, remark from m_ERPMQC_REALTIME where 1=1 and data != '0'   and site = 'B01' and process = 'MQC' and cast(inspectdate as datetime) + CAST (inspecttime as datetime) >= '2020-03-17 17:30:39'and
cast(inspectdate as datetime) + CAST (inspecttime as datetime) <= '2020-03-18 07:30:39' order by inspectdate, inspecttime

select min(cast(inspectdate as datetime) + CAST (inspecttime as datetime)) from m_ERPMQC_REALTIME
where 1=1 and data != '0'   and site = 'B01' and process = 'MQC' 
 and cast(inspectdate as datetime) + CAST (inspecttime as datetime) >= '2020-03-17 17:00:12' and cast(inspectdate as datetime) + CAST (inspecttime as datetime) <= '2020-03-18 07:30:12' and model = 'BMH1244645S02' 
 


 Select distinct serno, lot, model, site, factory, line, process, item, inspectdate, inspecttime, data, judge, status,
 remark from m_ERPMQC_REALTIME 
 where 1=1  and data  != '0' and site = 'B01' and process = 'MQC' and lot = 'B511-20020006;0010;B01;B01' 
 and cast(inspectdate as datetime) + CAST (inspecttime as datetime) >= '2020-03-19 00:00:00'
 and cast(inspectdate as datetime) + CAST (inspecttime as datetime) <= '2020-03-19 00:00:00'
 order by inspectdate, inspecttime

 select  serno, lot, model, site, factory, line, process, item, inspectdate, inspecttime, data, judge, 
 status, remark from m_ERPMQC_REALTIME 
 where 1=1  and data  != '0' and site = 'B01' and process = 'MQC' and model like '%355%'
 and cast(inspectdate as datetime) + CAST (inspecttime as datetime) >= '2020-03-20 11:00:04'and
 cast(inspectdate as datetime) + CAST (inspecttime as datetime) <= '2020-03-21 11:00:00' 
 order by cast(inspectdate as datetime) + CAST (inspecttime as datetime)

 select remark, model,line, sum(cast (data as int)) as tong  from m_ERPMQC_REALTIME where
  model like '%355%'
  and cast(inspectdate as datetime) + CAST (inspecttime as datetime) >= '2020-03-21 10:30:00'and
 cast(inspectdate as datetime) + CAST (inspecttime as datetime) <= '2020-03-21 11:00:00' 
 group by remark, model, line


 --3/20/2020 4:07:31 PM-3/20/2020 6:13:52 PM

--- AT-TCB-393001