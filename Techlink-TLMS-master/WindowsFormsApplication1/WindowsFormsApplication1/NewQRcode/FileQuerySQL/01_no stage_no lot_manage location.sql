
DECLARE @PO  VARCHAR(30)
DECLARE @TA001 VARCHAR(10)
DECLARE @TA002 VARCHAR(10)
DECLARE @SP VARCHAR(100)
DECLARE @LOT VARCHAR(100)
DECLARE @USER VARCHAR(30)
DECLARE @WAREHOUSE VARCHAR(10)
DECLARE @LOCATION VARCHAR(30)
DECLARE @QUANTITY DECIMAL(10,5)
DECLARE @WEIGHT DECIMAL(10,5)
DECLARE @TF001 VARCHAR (10)
DECLARE @TF002 VARCHAR (10)
DECLARE @STT VARCHAR(4)
DECLARE @COMMIT BIT = 1
DECLARE @DATE VARCHAR(10)
DECLARE @HOUR VARCHAR(10)
DECLARE @Confirm VARCHAR(1) 
DECLARE @LotManage BIT =0
DECLARE @STTCount Varchar(10)
----------------
SET @PO = 'W51121010002'--replace @POVALUE--D511	20100041
SET @LOT ='####################' --replace @LOTVALUE '####################'
SET @USER = 'ERP'--replace @USERVALUE
SET @WAREHOUSE = 'W01' --replace @WAREHOUSEVALUE
SET @LOCATION ='B01-01'--replace @LOCATIONVALUE = '##########'
SET @QUANTITY = 200 --replace @QUANTITYVALUE
SET @TF001 = 'W581' --replace @TF001
SET @STT = '0001'--replace @STT
SET @Confirm = 'N'-- replace @confirmVAlue
SET @DATE = ( Select convert(varchar(8),GETDATE(),112))
SET @HOUR = (Select convert(varchar(8),GETDATE(),108))
SET @LotManage = 0
------SET @STTCount
IF((select MQ006 from CMSMQ where MQ001 =@TF001) = '4')
SET @STTCount = '0001'
ELSE IF ((select MQ006 from CMSMQ where MQ001 =@TF001) = '3')
SET @STTCount = '001'
ELSE IF ((select MQ006 from CMSMQ where MQ001 =@TF001) = '5')
SET @STTCount = '00001'
ELSE IF ((select MQ006 from CMSMQ where MQ001 =@TF001) = '6')
SET @STTCount = '000001'
--------------------------------------------
---------SET @TF002-------------
IF (NOT EXISTS (SELECT TOP 1 TF002 as MADON FROM MOCTF WHERE TF001 = @TF001 and SUBSTRING(TF003,0,7) = (SELECT LEFT(CONVERT(varchar, GetDate(),112),6)) UNION
SELECT TOP 1 TB002 as MADON FROM SFCTB WHERE TB001 = @TF001 and TB025 = (SELECT LEFT(CONVERT(varchar, GetDate(),112),6))))
SET @TF002 = (select convert(char(4), getdate(), 12)) +@STTCount
ELSE 
SET @TF002 = (SELECT MAX(MaxValue) FROM 
(SELECT ISNULL((MAX(TF002)+1),0) as MaxValue FROM MOCTF WHERE TF001 = @TF001 and SUBSTRING(TF003,0,7) = (SELECT LEFT(CONVERT(varchar, GetDate(),112),6))
UNION SELECT ISNULL(MAX(TB002)+1,0) as MaxValue FROM SFCTB WHERE TB001 = @TF001 and TB025 = (SELECT LEFT(CONVERT(varchar, GetDate(),112),6))) as T1)
--PRINT @TF002
--SET @TF002 = '21010001'
----------------------------------------------
SET @TA001 = SUBSTRING(@PO,0,5)
SET @TA002 = SUBSTRING(@PO,5,LEN(@PO)-1)
SET @SP = (SELECT TA006 FROM MOCTA WHERE TA001 = @TA001 AND TA002=  @TA002)
-------SET @WEIGHT
IF( (select MB091 from INVMB where MB001 =@SP )='Y')
BEGIN
IF((select  MD002 from INVMD where MD001 = @SP ) = 'KG' or (select  MD002 from INVMD where MD001 = @SP ) = 'kg')
BEGIN
SET @WEIGHT = @QUANTITY * (select  MD003/MD004 from INVMD where MD001 = @SP)
END
END
ELSE
BEGIN
SET @WEIGHT = 0
END
-----------------------------------------------

BEGIN TRAN
IF(NOT EXISTS (SELECT TOP 1 * FROM MOCTG WHERE TG001 =@TF001 AND TG002 = @TF002 AND TG003 = @STT))
BEGIN 
INSERT INTO [dbo].[MOCTG]
           ([COMPANY]
           ,[CREATOR]
           ,[USR_GROUP]
           ,[CREATE_DATE]
           ,[MODIFIER]
           ,[MODI_DATE]
           ,[FLAG]
           ,[CREATE_TIME]
           ,[CREATE_AP]
           ,[CREATE_PRID]
           ,[MODI_TIME]
           ,[MODI_AP]
           ,[MODI_PRID]
           ,[TG001]
           ,[TG002]
           ,[TG003]
           ,[TG004]
           ,[TG005]
           ,[TG006]
           ,[TG007]
           ,[TG008]
           ,[TG009]
           ,[TG010]
           ,[TG011]
           ,[TG012]
           ,[TG013]
           ,[TG014]
           ,[TG015]
           ,[TG016]
           ,[TG017]
           ,[TG018]
           ,[TG019]
           ,[TG020]
           ,[TG021]
           ,[TG022]
           ,[TG023]
           ,[TG024]
           ,[TG025]
           ,[TG026]
           ,[TG027]
           ,[TG028]
           ,[TG029]
           ,[TG030]
           ,[TG031]
           ,[TG032]
           ,[TG033]
           ,[TG034]
           )
SELECT ADMMF.COMPANY,ADMMF.MF001, ADMMF.MF004,@DATE,NULL,NULL,1,@HOUR,
'TLAN','TLAN',NULL,NULL,NULL,@TF001,@TF002,@STT,@SP,MB002,MB003,MB004,'',
1, @WAREHOUSE, @QUANTITY,0,@QUANTITY, @TA001,@TA002,'0','' --@LOT
,(Select convert(varchar(8),DATEADD(day,INVMB.MB023,GETDATE()),112)),
(Select convert(varchar(8),DATEADD(day,INVMB.MB024,GETDATE()),112)),
'['+@WAREHOUSE+']','','Y',0,'N',@WEIGHT,0,@WEIGHT,0,INVMB.MB090,'N',
'N',0,'2',@LOCATION
FROM MOCTA
INNER JOIN ADMMF ON MF001 = @USER
INNER JOIN INVMB ON MB001 = @SP
WHERE TA001 = @TA001 AND TA002 = @TA002

IF(NOT EXISTS (SELECT TOP 1 * FROM MOCTF WHERE TF001 = @TF001 AND TF002 = @TF002))
BEGIN
INSERT INTO [dbo].[MOCTF]
           ([COMPANY]
           ,[CREATOR]
           ,[USR_GROUP]
           ,[CREATE_DATE]
           ,[MODIFIER]
           ,[MODI_DATE]
           ,[FLAG]
           ,[CREATE_TIME]
           ,[CREATE_AP]
           ,[CREATE_PRID]
           ,[MODI_TIME]
           ,[MODI_AP]
           ,[MODI_PRID]
           ,[TF001]
           ,[TF002]
           ,[TF003]
           ,[TF004]
           ,[TF005]
           ,[TF006]
           ,[TF007]
           ,[TF008]
           ,[TF009]
           ,[TF010]
           ,[TF011]
           ,[TF012]
           ,[TF013]
           ,[TF014]
		   ,[TF015]
           ,[TF200]
           ,[TF201]
           ,[TF202])

SELECT TOP 1 ADMMF.COMPANY,ADMMF.MF001, ADMMF.MF004,@DATE,NULL,NULL,
	1,@HOUR,'TLAN','TLAN',NULL,NULL, NULL,@TF001, @TF002, @DATE,'TL',
	'',@Confirm,'N',0,'N','N',MOCTA.TA021,@DATE,@USER,'N','0',@QUANTITY,@WEIGHT,0
FROM MOCTA
INNER JOIN ADMMF ON ADMMF.MF001 = @USER
WHERE TA001 = @TA001 and TA002 = @TA002
END
ELSE
BEGIN
UPDATE MOCTF SET TF200 = TF200 + @QUANTITY, TF201 = TF201 + @WEIGHT
WHERE TF001 =@TF001 AND TF002 = @TF002
END
IF (@Confirm ='Y')
BEGIN
UPDATE MOCTA SET MODIFIER = @USER, MODI_DATE =@DATE,FLAG = FLAG+1
,MODI_TIME = @HOUR, MODI_AP ='TLAN', MODI_PRID ='TLAN',
TA014 = @DATE, TA017 = TA017+@QUANTITY, TA046 = TA046+@WEIGHT
WHERE TA001 = @TA001 AND TA002 = @TA002

INSERT INTO [dbo].[INVLA]
           ([COMPANY]
           ,[CREATOR]
           ,[USR_GROUP]
           ,[CREATE_DATE]
           ,[MODIFIER]
           ,[MODI_DATE]
           ,[FLAG]
           ,[CREATE_TIME]
           ,[CREATE_AP]
           ,[CREATE_PRID]
           ,[MODI_TIME]
           ,[MODI_AP]
           ,[MODI_PRID]
           ,[LA001]
           ,[LA004]
           ,[LA005]
           ,[LA006]
           ,[LA007]
           ,[LA008]
           ,[LA009]
           ,[LA010]
           ,[LA011]
           ,[LA012]
           ,[LA013]
           ,[LA014]
           ,[LA015]
           ,[LA016]
           ,[LA017]
           ,[LA018]
           ,[LA019]
           ,[LA020]
           ,[LA021]
           ,[LA022]
           )
SELECT TOP 1   ADMMF.COMPANY,ADMMF.MF001, ADMMF.MF004,@DATE,NULL,NULL,
	1,@HOUR,'TLAN','TLAN',NULL,NULL, NULL,
	@SP,@DATE,1,@TF001,@TF002,@STT,@WAREHOUSE,@PO,@QUANTITY,0,0,1,'Y',''--@LOT
	,0,0,0,0,@WEIGHT,@LOCATION
FROM MOCTG
INNER JOIN ADMMF ON MF001 = @USER
WHERE TG001 = @TF001 AND TG002= @TF002 AND TG003 = @STT
;

IF (NOT EXISTS (SELECT TOP 1 * FROM INVMC WHERE MC001 = @SP AND MC002 = @WAREHOUSE))
BEGIN
INSERT INTO [dbo].[INVMC]
           ([COMPANY]
           ,[CREATOR]
           ,[USR_GROUP]
           ,[CREATE_DATE]
           ,[MODIFIER]
           ,[MODI_DATE]
           ,[FLAG]
           ,[CREATE_TIME]
           ,[CREATE_AP]
           ,[CREATE_PRID]
           ,[MODI_TIME]
           ,[MODI_AP]
           ,[MODI_PRID]
           ,[MC001]
           ,[MC002]
           ,[MC003]
           ,[MC004]
           ,[MC005]
           ,[MC006]
           ,[MC007]
           ,[MC008]
           ,[MC009]
           ,[MC010]
           ,[MC011]
           ,[MC012]
           ,[MC013]
           ,[MC014]
           ,[MC015]
           )
SELECT TOP 1 ADMMF.COMPANY,ADMMF.MF001, ADMMF.MF004,@DATE,NULL,NULL,
	1,@HOUR,'TLAN','TLAN',NULL,NULL, NULL,
	@SP,@WAREHOUSE,@LOCATION
	,0,0,0,@QUANTITY,0,0,0,'',@DATE,'', @WEIGHT,@LOCATION
	FROM MOCTG
INNER JOIN ADMMF ON ADMMF.MF001 = @USER
WHERE TG001 = @TF001 AND TG002 = @TF002 AND TG003 = @STT
END
ELSE
BEGIN 
UPDATE INVMC SET MODIFIER = @USER,MODI_DATE= @DATE,FLAG = FLAG+1,
MODI_TIME = @HOUR, MODI_AP = 'TLAN', MODI_PRID = 'TLAN',
MC007 = MC007 + @QUANTITY, MC014 = MC014 + @WEIGHT, MC012 = @DATE
WHERE MC001 = @SP AND MC002 = @WAREHOUSE
END


UPDATE INVMB SET MODIFIER = @USER,MODI_DATE= @DATE,FLAG = FLAG+1,
MODI_TIME = @HOUR, MODI_AP = 'TLAN', MODI_PRID = 'TLAN',
MB064 =MB064 +@QUANTITY,MB089 = MB089+@WEIGHT
WHERE MB001 = @SP

END

SELECT * FROM MOCTA WHERE TA001 = @TA001 AND TA002 = @TA002 
SELECT * FROM MOCTG WHERE TG001 = @TF001 AND TG002 =@TF002
SELECT * FROM MOCTF WHERE TF001 = @TF001 AND TF002 =@TF002
SELECT * FROM INVLA WHERE LA006 = @TF001 AND LA007 = @TF002 --AND LA008 = @STT
SELECT * FROM INVMC WHERE MC001 = @SP AND MC002 = @WAREHOUSE
SELECT * FROM INVMB WHERE MB001 = @SP
END
ELSE
BEGIN 
Print 'Duplicate when Insert MOCTG (TG001, TG002,TG003)'
END

IF @COMMIT =0
 ROLLBACK TRAN
ELSE IF @COMMIT = 1
COMMIT TRAN
