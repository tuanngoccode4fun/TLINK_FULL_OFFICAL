sqlcmd -Q "BULK INSERT [TEST].[dbo].[m_csv] FROM 'C:\Users\Long Coi\Desktop\long.csv' WITH(FIRSTROW = 1,FIELDTERMINATOR = ',', ROWTERMINATOR = '\n',TABLOCK)"
