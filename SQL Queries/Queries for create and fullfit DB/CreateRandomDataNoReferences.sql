Declare @EmployeeID int
DECLARE @FromDate DATETIME2(0)
DECLARE @ToDate   DATETIME2(0)
Set @EmployeeID = 1
SET @FromDate = '1990-01-01 08:22:13' 
SET @ToDate = '2020-03-05 17:56:31'

DECLARE @Seconds INT = DATEDIFF(SECOND, @FromDate, @ToDate)
DECLARE @Random INT = ROUND(((@Seconds-1) * RAND()), 0)

While @EmployeeID <= 12000
Begin 
   Insert Into [Basics].[dbo].[Employees] values (@EmployeeID,
				'LastName - ' + CAST(@EmployeeID as nvarchar(10)),
              'FirstName - ' + CAST(@EmployeeID as nvarchar(10)),
			   DATEADD(SECOND, @Random, @FromDate),
			   CAST(CAST(FLOOR(RAND()*(380999999999-380000000000+1)+380000000000) AS DECIMAL(38,0)) as VARCHAR(40)),
			  'Notes - ' + CAST(@EmployeeID as nvarchar(10)))
   Print @EmployeeID
   Set @EmployeeID = @EmployeeID + 1
End