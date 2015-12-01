USE QLCT_2
GO
/****** Object:  StoredProcedure [dbo].[ADDNguoiChoi]    Script Date: 11/04/2015 20:06:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC ADDNhanVien (@HoDem nvarchar(50), @TenNV nvarchar(50), @NS date, @GT char(3), @LUONG int, @DiaChi nvarchar(50), @Ma_NQL varchar(10), @MaDV varchar(10), @ChucVu nvarchar(50), @DT int)
AS 
BEGIN
	DECLARE @MaNV nchar(10)
	DECLARE @sott int
	DECLARE contro CURSOR FORWARD_ONLY FOR SELECT MaNV FROM tblNhanVien
	SET @sott = 0
	
	OPEN contro
	FETCH NEXT FROM contro INTO @MaNV
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF((CAST(right(@MaNV, 8) AS int) - @sott) = 1)
		BEGIN
			SET @sott = CAST(right(@MaNV, 8) AS int)
		END
	ELSE BREAK
	FETCH NEXT FROM contro INTO @MaNV
END

DECLARE @cdai int
DECLARE @i int
SET @MaNV = CAST((@sott + 1) as nchar(8))
SET @cdai = LEN(@MaNV)
SET @i = 1
while ( @i <= 8 - @cdai)
BEGIN
	SET @MaNV = '0' + @MaNV
	SET @i = @i + 1
END
SET @MaNV = 'NV' + @MaNV

INSERT INTO tblNhanVien values ( @MaNV, @HoDem, @TenNV, @NS, @GT, @LUONG, @DiaChi, @Ma_NQL, @MaDV, @ChucVu, @DT)
SELECT @MaNV
CLOSE contro
DEALLOCATE contro
END
