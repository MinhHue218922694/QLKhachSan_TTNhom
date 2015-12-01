USE  
GO
CREATE PROC ADDDonVi (@TenDV nvarchar(50), @NQL varchar(10), @DC nvarchar(50), @SoDT int)
AS 
BEGIN
	DECLARE @MaDV nchar(10)
	DECLARE @sott int
	DECLARE contro CURSOR FORWARD_ONLY FOR SELECT MaDV FROM tblDonVi
	SET @sott = 0
	
	OPEN contro
	FETCH NEXT FROM contro INTO @MaDV
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF((CAST(right(@MaDV, 8) AS int) - @sott) = 1)
		BEGIN
			SET @sott = CAST(right(@MaDV, 8) AS int)
		END
	ELSE BREAK
	FETCH NEXT FROM contro INTO @MaDV
END

DECLARE @cdai int
DECLARE @i int
SET @MaDV = CAST((@sott + 1) as nchar(8))
SET @cdai = LEN(@MaDV)
SET @i = 1
while ( @i <= 8 - @cdai)
BEGIN
	SET @MaDV = '0' + @MaDV
	SET @i = @i + 1
END
SET @MaDV = 'DV' + @MaDV

INSERT INTO tblDonVi values ( @MaDV,@TenDV,@NQL,@DC,@SoDT)
SELECT @MaDV
CLOSE contro
DEALLOCATE contro
END