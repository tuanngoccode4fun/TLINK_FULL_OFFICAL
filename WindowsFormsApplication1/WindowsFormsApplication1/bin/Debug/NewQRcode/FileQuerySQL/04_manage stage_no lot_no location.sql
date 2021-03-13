
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
DECLARE @STT VARCHAR(5)
DECLARE @COMMIT BIT = 1
DECLARE @DATE VARCHAR(10)
DECLARE @HOUR VARCHAR(10)
DECLARE @Confirm VARCHAR(1) 
----------------
SET @PO = '@PO_VALUE'--replace @POVALUE
SET @LOT ='####################' --replace @LOTVALUE
SET @USER = '@USER_VALUE'--replace @USERVALUE
SET @WAREHOUSE = '@WAREHOUSE_VALUE' --replace @WAREHOUSEVALUE
SET @LOCATION ='##########'--replace @LOCATIONVALUE
SET @QUANTITY = @QUANTITY_VALUE --replace @QUANTITYVALUE
SET @TF001 = '@TF001_VALUE' --replace @TF001
SET @TF002 ='@TF002_VALUE' ---replace @TF002
SET @STT = '@STT_VALUE'--replace @STT
SET @Confirm = '@Confirm_VALUE'-- replace @confirmVAlue
SET @DATE = ( Select convert(varchar(8),GETDATE(),112))
SET @HOUR = (Select convert(varchar(8),GETDATE(),108))


SET @TA001 = SUBSTRING(@PO,0,5)
SET @TA002 = SUBSTRING(@PO,5,LEN(@PO)-1)
SET @SP = (SELECT TA006 FROM MOCTA WHERE TA001 = @TA001 AND TA002=  @TA002)
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

BEGIN TRAN
IF (NOT EXISTS(SELECT TOP 1 * FROM SFCTC WHERE TC001 =@TF001 and TC002 = @TF002 and TC003 =@STT))
BEGIN
INSERT INTO [dbo].[SFCTC]
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
           ,[TC001]
           ,[TC002]
           ,[TC003]
           ,[TC004]
           ,[TC005]
           ,[TC006]
           ,[TC007]
           ,[TC008]
           ,[TC009]
           ,[TC010]
           ,[TC011]
           ,[TC012]
           ,[TC013]
           ,[TC014]
           ,[TC015]
           ,[TC016]
           ,[TC017]
           ,[TC018]
           ,[TC019]
           ,[TC020]
           ,[TC021]
           ,[TC022]
           ,[TC023]
           ,[TC024]
           ,[TC025]
           ,[TC026]
           ,[TC027]
           ,[TC028]
           ,[TC029]
           ,[TC030]
           ,[TC031]
           ,[TC032]
           ,[TC033]
           ,[TC034]
           ,[TC035]
           ,[TC036]
           ,[TC037]
           ,[TC038]
           ,[TC039]
           ,[TC040]
           ,[TC041]
           ,[TC042]
           ,[TC043]
           ,[TC044]
           ,[TC045]
           ,[TC046]
           ,[TC047]
           ,[TC048]
           ,[TC049]
           ,[TC050]
           ,[TC051]
           ,[TC052]
        
           )
 SELECT ADMMF.COMPANY,ADMMF.MF001, ADMMF.MF004, @DATE,NULL, NULL,'1', @HOUR, 'TLAN', 'sftb03', NULL, NULL, NULL,
 @TF001,@TF002, @STT, @TA001, @TA002,'0020',SFCTA.TA004,'','',SFCTA.TA020,NULL,NULL,'1',@QUANTITY,0,0,0,0,0,0,0,@Confirm,SFCTA.TA006, 
 NULL,0,'N','N',
 NULL, NULL, NULL, NULL,'' --LOT = ''
 ,(Select convert(varchar(8),DATEADD(day,INVMB.MB023,GETDATE()),112)),
 (Select convert(varchar(8),DATEADD(day,INVMB.MB024,GETDATE()),112))
 ,'N', @QUANTITY,
'0',@DATE,0,NULL,@WAREHOUSE,@WEIGHT,@WEIGHT,0,0,0,@SP, INVMB.MB002,INVMB.MB003,
INVMB.MB016,0,''--@LOCATION
from  INVMB 
inner join ADMMF on ADMMF.MF001 = @USER
inner join SFCTA on SFCTA.TA001 = @TA001 and SFCTA.TA002 = @TA002 and TA003 = '0020' 
where INVMB.MB001 = @SP
--Inset or update SFCTB
IF(NOT EXISTS( SELECT TOP 1 * FROM SFCTB WHERE TB001 = @TF001 and TB002 = @TF002))
BEGIN
INSERT INTO [dbo].[SFCTB]
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
           ,[TB001]
           ,[TB002]
           ,[TB003]
           ,[TB004]
           ,[TB005]
           ,[TB006]
           ,[TB007]
           ,[TB008]
           ,[TB009]
           ,[TB010]
           ,[TB011]
           ,[TB012]
           ,[TB013]
           ,[TB014]
           ,[TB015]
           ,[TB016]
           ,[TB017]
           ,[TB018]
           ,[TB019]
           ,[TB020]
           ,[TB021]
           ,[TB022]
           ,[TB023]
           ,[TB024]
           ,[TB025]
           ,[TB026]
           ,[TB027]
           ,[TB028]
           ,[TB029]
           ,[TB030]
           ,[TB031]
           ,[TB036]
           ,[TB037]
           ,[TB038]
           ,[TB039]
           ,[TB200]
           ,[TB201]
		   )
	SELECT TOP 1 ADMMF.COMPANY,ADMMF.MF001, ADMMF.MF004,@DATE,NULL,NULL,
	1,@HOUR,'TLAN','TLAN',NULL,NULL, NULL,@TF001,@TF002,@DATE,'1',SFCTA.TA006,SFCTA.TA007,'3',
	@WAREHOUSE,CMSMC.MC002,'TL',0,'N',@Confirm,NULL, @DATE, @USER,'N','','1',NULL,NULL,'1','1',
	'',(SELECT LEFT(CONVERT(varchar, GetDate(),112),6)),0.2,0,NULL,0,0,0,SFCTA.TA018,0,'D301','',@QUANTITY,@QUANTITY 
	FROM SFCTB
	inner join ADMMF on ADMMF.MF001 = @USER
	inner join SFCTA on TA001 = @TA001 and TA002 = @TA002 and TA003 ='0020'
	inner join CMSMC on MC001= @WAREHOUSE
	inner join SFCTC on TC001 = @TF001 and TC002 = @TF002
END
ELSE
BEGIN 
UPDATE SFCTB SET  TB200 = TB200 + @QUANTITY , TB201 = ISNULL(TB201,0)+@QUANTITY 
FROM SFCTB
WHERE TB001 = @TF001 and TB002 = @TF002
END


IF (@Confirm ='Y')
BEGIN
UPDATE SFCTA SET MODIFIER = @USER, MODI_DATE =@DATE,FLAG = FLAG+1
,MODI_TIME = @HOUR, MODI_AP ='TLAN', MODI_PRID ='TLAN',
TA011 = ISNULL(TA011,0)+@QUANTITY, TA039 = ISNULL(TA039,0) + @WEIGHT
WHERE TA001 = @TA001 and TA002 = @TA002 and TA003 = '0020'

UPDATE MOCTA SET MODIFIER = @USER, MODI_DATE =@DATE,FLAG = FLAG+1
,MODI_TIME = @HOUR, MODI_AP ='TLAN', MODI_PRID ='TLAN',
TA014 = @DATE, TA017 = ISNULL(TA017,0)+@QUANTITY, TA046 = ISNULL(TA046,0)+@WEIGHT
WHERE TA001 = @TA001 AND TA002 = @TA002
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
'N',0,'2',''--@LOCATION
FROM MOCTA
INNER JOIN ADMMF ON MF001 = @USER
INNER JOIN INVMB ON MB001 = @SP
WHERE TA001 = @TA001 AND TA002 = @TA002
END

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
	'','Y','N',0,'N','N',SFCTA.TA006,@DATE,@USER,'N','0',@QUANTITY,@WEIGHT,0
FROM MOCTA
INNER JOIN ADMMF ON ADMMF.MF001 = @USER
INNER JOIN SFCTA ON SFCTA.TA001 = @TA001 AND SFCTA.TA002 = @TA002 AND SFCTA.TA003 = '0020'
END
ELSE
BEGIN
UPDATE MOCTF SET TF200 = ISNULL(TF200,0) + @QUANTITY, TF201 = ISNULL(TF201,0) + @WEIGHT
WHERE TF001 =@TF001 AND TF002 = @TF002
END

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
	,0,0,0,0,@WEIGHT,''--@LOCATION
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
	@SP,@WAREHOUSE,''--@LOCATION
	,0,0,0,@QUANTITY,0,0,0,'',@DATE,'', @WEIGHT,''--@LOCATION
	FROM MOCTG
INNER JOIN ADMMF ON ADMMF.MF001 = @USER
WHERE TG001 = @TF001 AND TG002 = @TF002 AND TG003 = @STT
END
ELSE
BEGIN 
UPDATE INVMC SET MODIFIER = @USER,MODI_DATE= @DATE,FLAG = FLAG+1,
MODI_TIME = @HOUR, MODI_AP = 'TLAN', MODI_PRID = 'TLAN',
MC007 = ISNULL(MC007,0) + @QUANTITY, MC014 = ISNULL(MC014,0) + @WEIGHT, MC012 = @DATE
WHERE MC001 = @SP AND MC002 = @WAREHOUSE
END


UPDATE INVMB SET MODIFIER = @USER,MODI_DATE= @DATE,FLAG = FLAG+1,
MODI_TIME = @HOUR, MODI_AP = 'TLAN', MODI_PRID = 'TLAN',
MB064 = ISNULL(MB064,0) + @QUANTITY,MB089 = ISNULL(MB089,0) + @WEIGHT
WHERE MB001 = @SP

END
ELSE 
BEGIN
UPDATE SFCTA SET MODIFIER = @USER, MODI_DATE =@DATE,FLAG = FLAG+1
,MODI_TIME = @HOUR, MODI_AP ='TLAN', MODI_PRID ='TLAN',
TA017 = ISNULL (TA017,0) + @QUANTITY, TA045 = ISNULL(TA045,0) + @WEIGHT
WHERE TA001 = @TA001 and TA002 = @TA002 and TA003 = '0020'
END

--select * from SFCTC where TC001 = @TF001 and TC002 = @TF002
--select * from SFCTB where TB001 = @TF001 and TB002 = @TF002
--select * from SFCTA WHERE TA001 = @TA001 and TA002 = @TA002 and TA003 = '0020'
-------
--SELECT * FROM MOCTA WHERE TA001 = @TA001 AND TA002 = @TA002
--SELECT * FROM MOCTG WHERE TG001 = @TF001 AND TG002 =@TF002
--SELECT * FROM MOCTF WHERE TF001 = @TF001 AND TF002 =@TF002

--SELECT * FROM INVLA WHERE LA006 = @TF001 AND LA007 = @TF002 --AND LA008 = @STT
--SELECT * FROM INVMC WHERE MC001 = @SP AND MC002 = @WAREHOUSE
--SELECT * FROM INVMB WHERE MB001 = @SP

END
ELSE 
BEGIN 
Print 'Duplicate when Insert SFCTC (TC001, TC002,TC003)'
END

IF @COMMIT =0
 ROLLBACK TRAN
ELSE IF @COMMIT = 1
BEGIN
COMMIT TRAN
select 'End script with sucessful'
END