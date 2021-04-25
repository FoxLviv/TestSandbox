Declare @ID int
DECLARE @FromDate DATETIME2(0)
DECLARE @ToDate   DATETIME2(0)
declare @UpperLimitForIDs int
declare @LowerLimitForIDs int

Set @ID = 1
SET @FromDate = '1990-01-01 08:22:13' 
SET @ToDate = '2020-03-05 17:56:31'
set @UpperLimitForIDs = 12000
set @LowerLimitForIDs = 1


DECLARE @Seconds INT = DATEDIFF(SECOND, @FromDate, @ToDate)
DECLARE @Random INT = ROUND(((@Seconds-1) * RAND()), 0)

While @ID <= 12000
Begin 
   Insert Into [Basics].[dbo].[Orders] values (@ID,
				Round(((@UpperLimitForIDs - @LowerLimitForIDs) * Rand()) + @LowerLimitForIDs, 0),
               Round(((@UpperLimitForIDs - @LowerLimitForIDs) * Rand()) + @LowerLimitForIDs, 0),
			    DATEADD(SECOND, @Random, @FromDate),
			   Round(((@UpperLimitForIDs - @LowerLimitForIDs) * Rand()) + @LowerLimitForIDs, 0))
			   
   Print @ID
   Set @ID = @ID + 1
End