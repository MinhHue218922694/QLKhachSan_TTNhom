
Use [QUANLYQN]
Go
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMLOP_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMLOP_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMLOP_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DMLOP table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMLOP_Get_List

AS


				
				SELECT
					[ID_LOP],
					[MALOP],
					[TENLOP],
					[ID_DAIDOI],
					[GHICHU]
				FROM
					[dbo].[DMLOP]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMLOP_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMLOP_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMLOP_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DMLOP table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMLOP_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_LOP] int 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_LOP])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_LOP]'
				SET @SQL = @SQL + ' FROM [dbo].[DMLOP]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_LOP], O.[MALOP], O.[TENLOP], O.[ID_DAIDOI], O.[GHICHU]
				FROM
				    [dbo].[DMLOP] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_LOP] = PageIndex.[ID_LOP]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DMLOP]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMLOP_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMLOP_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMLOP_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DMLOP table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMLOP_Insert
(

	@IdLop int    OUTPUT,

	@Malop nvarchar (50)  ,

	@Tenlop nvarchar (50)  ,

	@IdDaidoi int   ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[DMLOP]
					(
					[MALOP]
					,[TENLOP]
					,[ID_DAIDOI]
					,[GHICHU]
					)
				VALUES
					(
					@Malop
					,@Tenlop
					,@IdDaidoi
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdLop = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMLOP_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMLOP_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMLOP_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DMLOP table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMLOP_Update
(

	@IdLop int   ,

	@Malop nvarchar (50)  ,

	@Tenlop nvarchar (50)  ,

	@IdDaidoi int   ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DMLOP]
				SET
					[MALOP] = @Malop
					,[TENLOP] = @Tenlop
					,[ID_DAIDOI] = @IdDaidoi
					,[GHICHU] = @Ghichu
				WHERE
[ID_LOP] = @IdLop 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMLOP_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMLOP_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMLOP_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DMLOP table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMLOP_Delete
(

	@IdLop int   
)
AS


				DELETE FROM [dbo].[DMLOP] WITH (ROWLOCK) 
				WHERE
					[ID_LOP] = @IdLop
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMLOP_GetByIdDaidoi procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMLOP_GetByIdDaidoi') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMLOP_GetByIdDaidoi
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DMLOP table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMLOP_GetByIdDaidoi
(

	@IdDaidoi int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_LOP],
					[MALOP],
					[TENLOP],
					[ID_DAIDOI],
					[GHICHU]
				FROM
					[dbo].[DMLOP]
				WHERE
					[ID_DAIDOI] = @IdDaidoi
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMLOP_GetByIdLop procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMLOP_GetByIdLop') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMLOP_GetByIdLop
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DMLOP table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMLOP_GetByIdLop
(

	@IdLop int   
)
AS


				SELECT
					[ID_LOP],
					[MALOP],
					[TENLOP],
					[ID_DAIDOI],
					[GHICHU]
				FROM
					[dbo].[DMLOP]
				WHERE
					[ID_LOP] = @IdLop
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMLOP_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMLOP_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMLOP_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DMLOP table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMLOP_Find
(

	@SearchUsingOR bit   = null ,

	@IdLop int   = null ,

	@Malop nvarchar (50)  = null ,

	@Tenlop nvarchar (50)  = null ,

	@IdDaidoi int   = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_LOP]
	, [MALOP]
	, [TENLOP]
	, [ID_DAIDOI]
	, [GHICHU]
    FROM
	[dbo].[DMLOP]
    WHERE 
	 ([ID_LOP] = @IdLop OR @IdLop is null)
	AND ([MALOP] = @Malop OR @Malop is null)
	AND ([TENLOP] = @Tenlop OR @Tenlop is null)
	AND ([ID_DAIDOI] = @IdDaidoi OR @IdDaidoi is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_LOP]
	, [MALOP]
	, [TENLOP]
	, [ID_DAIDOI]
	, [GHICHU]
    FROM
	[dbo].[DMLOP]
    WHERE 
	 ([ID_LOP] = @IdLop AND @IdLop is not null)
	OR ([MALOP] = @Malop AND @Malop is not null)
	OR ([TENLOP] = @Tenlop AND @Tenlop is not null)
	OR ([ID_DAIDOI] = @IdDaidoi AND @IdDaidoi is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPMENUS_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPMENUS_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPMENUS_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ADMIN_GROUPMENUS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPMENUS_Get_List

AS


				
				SELECT
					[ID_MENU],
					[ID_GROUP],
					[VIEW],
					[ADD],
					[EDIT],
					[DELETE],
					[CONTROL]
				FROM
					[dbo].[ADMIN_GROUPMENUS]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPMENUS_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPMENUS_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPMENUS_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ADMIN_GROUPMENUS table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPMENUS_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_MENU] char(50) COLLATE database_default , [ID_GROUP] char(15) COLLATE database_default  
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_MENU], [ID_GROUP])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_MENU], [ID_GROUP]'
				SET @SQL = @SQL + ' FROM [dbo].[ADMIN_GROUPMENUS]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_MENU], O.[ID_GROUP], O.[VIEW], O.[ADD], O.[EDIT], O.[DELETE], O.[CONTROL]
				FROM
				    [dbo].[ADMIN_GROUPMENUS] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_MENU] = PageIndex.[ID_MENU]
					AND O.[ID_GROUP] = PageIndex.[ID_GROUP]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ADMIN_GROUPMENUS]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPMENUS_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPMENUS_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPMENUS_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ADMIN_GROUPMENUS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPMENUS_Insert
(

	@IdMenu char (50)  ,

	@IdGroup char (15)  ,

	@View bit   ,

	@Add bit   ,

	@Edit bit   ,

	@Delete bit   ,

	@Control bit   
)
AS


					
				INSERT INTO [dbo].[ADMIN_GROUPMENUS]
					(
					[ID_MENU]
					,[ID_GROUP]
					,[VIEW]
					,[ADD]
					,[EDIT]
					,[DELETE]
					,[CONTROL]
					)
				VALUES
					(
					@IdMenu
					,@IdGroup
					,@View
					,@Add
					,@Edit
					,@Delete
					,@Control
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPMENUS_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPMENUS_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPMENUS_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ADMIN_GROUPMENUS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPMENUS_Update
(

	@IdMenu char (50)  ,

	@OriginalIdMenu char (50)  ,

	@IdGroup char (15)  ,

	@OriginalIdGroup char (15)  ,

	@View bit   ,

	@Add bit   ,

	@Edit bit   ,

	@Delete bit   ,

	@Control bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ADMIN_GROUPMENUS]
				SET
					[ID_MENU] = @IdMenu
					,[ID_GROUP] = @IdGroup
					,[VIEW] = @View
					,[ADD] = @Add
					,[EDIT] = @Edit
					,[DELETE] = @Delete
					,[CONTROL] = @Control
				WHERE
[ID_MENU] = @OriginalIdMenu 
AND [ID_GROUP] = @OriginalIdGroup 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPMENUS_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPMENUS_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPMENUS_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ADMIN_GROUPMENUS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPMENUS_Delete
(

	@IdMenu char (50)  ,

	@IdGroup char (15)  
)
AS


				DELETE FROM [dbo].[ADMIN_GROUPMENUS] WITH (ROWLOCK) 
				WHERE
					[ID_MENU] = @IdMenu
					AND [ID_GROUP] = @IdGroup
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPMENUS_GetByIdGroup procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPMENUS_GetByIdGroup') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPMENUS_GetByIdGroup
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ADMIN_GROUPMENUS table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPMENUS_GetByIdGroup
(

	@IdGroup char (15)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_MENU],
					[ID_GROUP],
					[VIEW],
					[ADD],
					[EDIT],
					[DELETE],
					[CONTROL]
				FROM
					[dbo].[ADMIN_GROUPMENUS]
				WHERE
					[ID_GROUP] = @IdGroup
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPMENUS_GetByIdMenu procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPMENUS_GetByIdMenu') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPMENUS_GetByIdMenu
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ADMIN_GROUPMENUS table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPMENUS_GetByIdMenu
(

	@IdMenu char (50)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_MENU],
					[ID_GROUP],
					[VIEW],
					[ADD],
					[EDIT],
					[DELETE],
					[CONTROL]
				FROM
					[dbo].[ADMIN_GROUPMENUS]
				WHERE
					[ID_MENU] = @IdMenu
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPMENUS_GetByIdMenuIdGroup procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPMENUS_GetByIdMenuIdGroup') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPMENUS_GetByIdMenuIdGroup
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ADMIN_GROUPMENUS table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPMENUS_GetByIdMenuIdGroup
(

	@IdMenu char (50)  ,

	@IdGroup char (15)  
)
AS


				SELECT
					[ID_MENU],
					[ID_GROUP],
					[VIEW],
					[ADD],
					[EDIT],
					[DELETE],
					[CONTROL]
				FROM
					[dbo].[ADMIN_GROUPMENUS]
				WHERE
					[ID_MENU] = @IdMenu
					AND [ID_GROUP] = @IdGroup
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPMENUS_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPMENUS_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPMENUS_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ADMIN_GROUPMENUS table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPMENUS_Find
(

	@SearchUsingOR bit   = null ,

	@IdMenu char (50)  = null ,

	@IdGroup char (15)  = null ,

	@View bit   = null ,

	@Add bit   = null ,

	@Edit bit   = null ,

	@Delete bit   = null ,

	@Control bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_MENU]
	, [ID_GROUP]
	, [VIEW]
	, [ADD]
	, [EDIT]
	, [DELETE]
	, [CONTROL]
    FROM
	[dbo].[ADMIN_GROUPMENUS]
    WHERE 
	 ([ID_MENU] = @IdMenu OR @IdMenu is null)
	AND ([ID_GROUP] = @IdGroup OR @IdGroup is null)
	AND ([VIEW] = @View OR @View is null)
	AND ([ADD] = @Add OR @Add is null)
	AND ([EDIT] = @Edit OR @Edit is null)
	AND ([DELETE] = @Delete OR @Delete is null)
	AND ([CONTROL] = @Control OR @Control is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_MENU]
	, [ID_GROUP]
	, [VIEW]
	, [ADD]
	, [EDIT]
	, [DELETE]
	, [CONTROL]
    FROM
	[dbo].[ADMIN_GROUPMENUS]
    WHERE 
	 ([ID_MENU] = @IdMenu AND @IdMenu is not null)
	OR ([ID_GROUP] = @IdGroup AND @IdGroup is not null)
	OR ([VIEW] = @View AND @View is not null)
	OR ([ADD] = @Add AND @Add is not null)
	OR ([EDIT] = @Edit AND @Edit is not null)
	OR ([DELETE] = @Delete AND @Delete is not null)
	OR ([CONTROL] = @Control AND @Control is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMLOAIQUANNHAN_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMLOAIQUANNHAN_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMLOAIQUANNHAN_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DMLOAIQUANNHAN table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMLOAIQUANNHAN_Get_List

AS


				
				SELECT
					[ID_LOAIQN],
					[LOAI_QUANNHAN],
					[GHICHU]
				FROM
					[dbo].[DMLOAIQUANNHAN]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMLOAIQUANNHAN_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMLOAIQUANNHAN_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMLOAIQUANNHAN_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DMLOAIQUANNHAN table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMLOAIQUANNHAN_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_LOAIQN] int 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_LOAIQN])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_LOAIQN]'
				SET @SQL = @SQL + ' FROM [dbo].[DMLOAIQUANNHAN]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_LOAIQN], O.[LOAI_QUANNHAN], O.[GHICHU]
				FROM
				    [dbo].[DMLOAIQUANNHAN] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_LOAIQN] = PageIndex.[ID_LOAIQN]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DMLOAIQUANNHAN]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMLOAIQUANNHAN_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMLOAIQUANNHAN_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMLOAIQUANNHAN_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DMLOAIQUANNHAN table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMLOAIQUANNHAN_Insert
(

	@IdLoaiqn int    OUTPUT,

	@LoaiQuannhan nvarchar (50)  ,

	@Ghichu nchar (10)  
)
AS


					
				INSERT INTO [dbo].[DMLOAIQUANNHAN]
					(
					[LOAI_QUANNHAN]
					,[GHICHU]
					)
				VALUES
					(
					@LoaiQuannhan
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdLoaiqn = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMLOAIQUANNHAN_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMLOAIQUANNHAN_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMLOAIQUANNHAN_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DMLOAIQUANNHAN table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMLOAIQUANNHAN_Update
(

	@IdLoaiqn int   ,

	@LoaiQuannhan nvarchar (50)  ,

	@Ghichu nchar (10)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DMLOAIQUANNHAN]
				SET
					[LOAI_QUANNHAN] = @LoaiQuannhan
					,[GHICHU] = @Ghichu
				WHERE
[ID_LOAIQN] = @IdLoaiqn 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMLOAIQUANNHAN_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMLOAIQUANNHAN_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMLOAIQUANNHAN_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DMLOAIQUANNHAN table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMLOAIQUANNHAN_Delete
(

	@IdLoaiqn int   
)
AS


				DELETE FROM [dbo].[DMLOAIQUANNHAN] WITH (ROWLOCK) 
				WHERE
					[ID_LOAIQN] = @IdLoaiqn
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMLOAIQUANNHAN_GetByIdLoaiqn procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMLOAIQUANNHAN_GetByIdLoaiqn') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMLOAIQUANNHAN_GetByIdLoaiqn
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DMLOAIQUANNHAN table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMLOAIQUANNHAN_GetByIdLoaiqn
(

	@IdLoaiqn int   
)
AS


				SELECT
					[ID_LOAIQN],
					[LOAI_QUANNHAN],
					[GHICHU]
				FROM
					[dbo].[DMLOAIQUANNHAN]
				WHERE
					[ID_LOAIQN] = @IdLoaiqn
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMLOAIQUANNHAN_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMLOAIQUANNHAN_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMLOAIQUANNHAN_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DMLOAIQUANNHAN table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMLOAIQUANNHAN_Find
(

	@SearchUsingOR bit   = null ,

	@IdLoaiqn int   = null ,

	@LoaiQuannhan nvarchar (50)  = null ,

	@Ghichu nchar (10)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_LOAIQN]
	, [LOAI_QUANNHAN]
	, [GHICHU]
    FROM
	[dbo].[DMLOAIQUANNHAN]
    WHERE 
	 ([ID_LOAIQN] = @IdLoaiqn OR @IdLoaiqn is null)
	AND ([LOAI_QUANNHAN] = @LoaiQuannhan OR @LoaiQuannhan is null)
	AND ([GHICHU] = @Ghichu OR @Ghichu is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_LOAIQN]
	, [LOAI_QUANNHAN]
	, [GHICHU]
    FROM
	[dbo].[DMLOAIQUANNHAN]
    WHERE 
	 ([ID_LOAIQN] = @IdLoaiqn AND @IdLoaiqn is not null)
	OR ([LOAI_QUANNHAN] = @LoaiQuannhan AND @LoaiQuannhan is not null)
	OR ([GHICHU] = @Ghichu AND @Ghichu is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMTONGIAO_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMTONGIAO_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMTONGIAO_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DMTONGIAO table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMTONGIAO_Get_List

AS


				
				SELECT
					[ID_TONGIAO],
					[TONGIAO],
					[GHICHU]
				FROM
					[dbo].[DMTONGIAO]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMTONGIAO_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMTONGIAO_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMTONGIAO_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DMTONGIAO table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMTONGIAO_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_TONGIAO] int 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_TONGIAO])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_TONGIAO]'
				SET @SQL = @SQL + ' FROM [dbo].[DMTONGIAO]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_TONGIAO], O.[TONGIAO], O.[GHICHU]
				FROM
				    [dbo].[DMTONGIAO] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_TONGIAO] = PageIndex.[ID_TONGIAO]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DMTONGIAO]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMTONGIAO_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMTONGIAO_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMTONGIAO_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DMTONGIAO table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMTONGIAO_Insert
(

	@IdTongiao int    OUTPUT,

	@Tongiao nvarchar (50)  ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[DMTONGIAO]
					(
					[TONGIAO]
					,[GHICHU]
					)
				VALUES
					(
					@Tongiao
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdTongiao = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMTONGIAO_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMTONGIAO_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMTONGIAO_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DMTONGIAO table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMTONGIAO_Update
(

	@IdTongiao int   ,

	@Tongiao nvarchar (50)  ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DMTONGIAO]
				SET
					[TONGIAO] = @Tongiao
					,[GHICHU] = @Ghichu
				WHERE
[ID_TONGIAO] = @IdTongiao 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMTONGIAO_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMTONGIAO_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMTONGIAO_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DMTONGIAO table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMTONGIAO_Delete
(

	@IdTongiao int   
)
AS


				DELETE FROM [dbo].[DMTONGIAO] WITH (ROWLOCK) 
				WHERE
					[ID_TONGIAO] = @IdTongiao
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMTONGIAO_GetByIdTongiao procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMTONGIAO_GetByIdTongiao') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMTONGIAO_GetByIdTongiao
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DMTONGIAO table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMTONGIAO_GetByIdTongiao
(

	@IdTongiao int   
)
AS


				SELECT
					[ID_TONGIAO],
					[TONGIAO],
					[GHICHU]
				FROM
					[dbo].[DMTONGIAO]
				WHERE
					[ID_TONGIAO] = @IdTongiao
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMTONGIAO_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMTONGIAO_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMTONGIAO_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DMTONGIAO table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMTONGIAO_Find
(

	@SearchUsingOR bit   = null ,

	@IdTongiao int   = null ,

	@Tongiao nvarchar (50)  = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_TONGIAO]
	, [TONGIAO]
	, [GHICHU]
    FROM
	[dbo].[DMTONGIAO]
    WHERE 
	 ([ID_TONGIAO] = @IdTongiao OR @IdTongiao is null)
	AND ([TONGIAO] = @Tongiao OR @Tongiao is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_TONGIAO]
	, [TONGIAO]
	, [GHICHU]
    FROM
	[dbo].[DMTONGIAO]
    WHERE 
	 ([ID_TONGIAO] = @IdTongiao AND @IdTongiao is not null)
	OR ([TONGIAO] = @Tongiao AND @Tongiao is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMHINHTHUCKYLUAT_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMHINHTHUCKYLUAT_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMHINHTHUCKYLUAT_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DMHINHTHUCKYLUAT table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMHINHTHUCKYLUAT_Get_List

AS


				
				SELECT
					[ID_HINHTHUC_KYLUAT],
					[HINHTHUC_KYLUAT],
					[GHICHU]
				FROM
					[dbo].[DMHINHTHUCKYLUAT]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMHINHTHUCKYLUAT_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMHINHTHUCKYLUAT_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMHINHTHUCKYLUAT_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DMHINHTHUCKYLUAT table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMHINHTHUCKYLUAT_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_HINHTHUC_KYLUAT] int 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_HINHTHUC_KYLUAT])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_HINHTHUC_KYLUAT]'
				SET @SQL = @SQL + ' FROM [dbo].[DMHINHTHUCKYLUAT]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_HINHTHUC_KYLUAT], O.[HINHTHUC_KYLUAT], O.[GHICHU]
				FROM
				    [dbo].[DMHINHTHUCKYLUAT] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_HINHTHUC_KYLUAT] = PageIndex.[ID_HINHTHUC_KYLUAT]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DMHINHTHUCKYLUAT]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMHINHTHUCKYLUAT_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMHINHTHUCKYLUAT_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMHINHTHUCKYLUAT_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DMHINHTHUCKYLUAT table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMHINHTHUCKYLUAT_Insert
(

	@IdHinhthucKyluat int    OUTPUT,

	@HinhthucKyluat nvarchar (50)  ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[DMHINHTHUCKYLUAT]
					(
					[HINHTHUC_KYLUAT]
					,[GHICHU]
					)
				VALUES
					(
					@HinhthucKyluat
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdHinhthucKyluat = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMHINHTHUCKYLUAT_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMHINHTHUCKYLUAT_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMHINHTHUCKYLUAT_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DMHINHTHUCKYLUAT table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMHINHTHUCKYLUAT_Update
(

	@IdHinhthucKyluat int   ,

	@HinhthucKyluat nvarchar (50)  ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DMHINHTHUCKYLUAT]
				SET
					[HINHTHUC_KYLUAT] = @HinhthucKyluat
					,[GHICHU] = @Ghichu
				WHERE
[ID_HINHTHUC_KYLUAT] = @IdHinhthucKyluat 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMHINHTHUCKYLUAT_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMHINHTHUCKYLUAT_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMHINHTHUCKYLUAT_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DMHINHTHUCKYLUAT table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMHINHTHUCKYLUAT_Delete
(

	@IdHinhthucKyluat int   
)
AS


				DELETE FROM [dbo].[DMHINHTHUCKYLUAT] WITH (ROWLOCK) 
				WHERE
					[ID_HINHTHUC_KYLUAT] = @IdHinhthucKyluat
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMHINHTHUCKYLUAT_GetByIdHinhthucKyluat procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMHINHTHUCKYLUAT_GetByIdHinhthucKyluat') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMHINHTHUCKYLUAT_GetByIdHinhthucKyluat
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DMHINHTHUCKYLUAT table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMHINHTHUCKYLUAT_GetByIdHinhthucKyluat
(

	@IdHinhthucKyluat int   
)
AS


				SELECT
					[ID_HINHTHUC_KYLUAT],
					[HINHTHUC_KYLUAT],
					[GHICHU]
				FROM
					[dbo].[DMHINHTHUCKYLUAT]
				WHERE
					[ID_HINHTHUC_KYLUAT] = @IdHinhthucKyluat
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMHINHTHUCKYLUAT_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMHINHTHUCKYLUAT_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMHINHTHUCKYLUAT_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DMHINHTHUCKYLUAT table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMHINHTHUCKYLUAT_Find
(

	@SearchUsingOR bit   = null ,

	@IdHinhthucKyluat int   = null ,

	@HinhthucKyluat nvarchar (50)  = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_HINHTHUC_KYLUAT]
	, [HINHTHUC_KYLUAT]
	, [GHICHU]
    FROM
	[dbo].[DMHINHTHUCKYLUAT]
    WHERE 
	 ([ID_HINHTHUC_KYLUAT] = @IdHinhthucKyluat OR @IdHinhthucKyluat is null)
	AND ([HINHTHUC_KYLUAT] = @HinhthucKyluat OR @HinhthucKyluat is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_HINHTHUC_KYLUAT]
	, [HINHTHUC_KYLUAT]
	, [GHICHU]
    FROM
	[dbo].[DMHINHTHUCKYLUAT]
    WHERE 
	 ([ID_HINHTHUC_KYLUAT] = @IdHinhthucKyluat AND @IdHinhthucKyluat is not null)
	OR ([HINHTHUC_KYLUAT] = @HinhthucKyluat AND @HinhthucKyluat is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMTRUONG_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMTRUONG_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMTRUONG_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DMTRUONG table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMTRUONG_Get_List

AS


				
				SELECT
					[ID_TRUONG],
					[TENTRUONG],
					[GHICHU]
				FROM
					[dbo].[DMTRUONG]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMTRUONG_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMTRUONG_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMTRUONG_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DMTRUONG table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMTRUONG_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_TRUONG] int 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_TRUONG])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_TRUONG]'
				SET @SQL = @SQL + ' FROM [dbo].[DMTRUONG]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_TRUONG], O.[TENTRUONG], O.[GHICHU]
				FROM
				    [dbo].[DMTRUONG] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_TRUONG] = PageIndex.[ID_TRUONG]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DMTRUONG]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMTRUONG_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMTRUONG_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMTRUONG_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DMTRUONG table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMTRUONG_Insert
(

	@IdTruong int    OUTPUT,

	@Tentruong nvarchar (50)  ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[DMTRUONG]
					(
					[TENTRUONG]
					,[GHICHU]
					)
				VALUES
					(
					@Tentruong
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdTruong = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMTRUONG_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMTRUONG_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMTRUONG_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DMTRUONG table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMTRUONG_Update
(

	@IdTruong int   ,

	@Tentruong nvarchar (50)  ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DMTRUONG]
				SET
					[TENTRUONG] = @Tentruong
					,[GHICHU] = @Ghichu
				WHERE
[ID_TRUONG] = @IdTruong 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMTRUONG_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMTRUONG_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMTRUONG_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DMTRUONG table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMTRUONG_Delete
(

	@IdTruong int   
)
AS


				DELETE FROM [dbo].[DMTRUONG] WITH (ROWLOCK) 
				WHERE
					[ID_TRUONG] = @IdTruong
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMTRUONG_GetByIdTruong procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMTRUONG_GetByIdTruong') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMTRUONG_GetByIdTruong
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DMTRUONG table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMTRUONG_GetByIdTruong
(

	@IdTruong int   
)
AS


				SELECT
					[ID_TRUONG],
					[TENTRUONG],
					[GHICHU]
				FROM
					[dbo].[DMTRUONG]
				WHERE
					[ID_TRUONG] = @IdTruong
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMTRUONG_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMTRUONG_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMTRUONG_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DMTRUONG table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMTRUONG_Find
(

	@SearchUsingOR bit   = null ,

	@IdTruong int   = null ,

	@Tentruong nvarchar (50)  = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_TRUONG]
	, [TENTRUONG]
	, [GHICHU]
    FROM
	[dbo].[DMTRUONG]
    WHERE 
	 ([ID_TRUONG] = @IdTruong OR @IdTruong is null)
	AND ([TENTRUONG] = @Tentruong OR @Tentruong is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_TRUONG]
	, [TENTRUONG]
	, [GHICHU]
    FROM
	[dbo].[DMTRUONG]
    WHERE 
	 ([ID_TRUONG] = @IdTruong AND @IdTruong is not null)
	OR ([TENTRUONG] = @Tentruong AND @Tentruong is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSTRUONGLOP_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSTRUONGLOP_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSTRUONGLOP_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the LSTRUONGLOP table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSTRUONGLOP_Get_List

AS


				
				SELECT
					[ID_LICHSUTRUONGLOP],
					[ID_QUANNHAN],
					[ID_TRUONG],
					[ID_CAPHOC],
					[NGANHHOC],
					[THOIGIAN_BATDAU],
					[THOIGIAN_KETTHUC],
					[GHICHU]
				FROM
					[dbo].[LSTRUONGLOP]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSTRUONGLOP_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSTRUONGLOP_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSTRUONGLOP_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the LSTRUONGLOP table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSTRUONGLOP_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_LICHSUTRUONGLOP] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_LICHSUTRUONGLOP])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_LICHSUTRUONGLOP]'
				SET @SQL = @SQL + ' FROM [dbo].[LSTRUONGLOP]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_LICHSUTRUONGLOP], O.[ID_QUANNHAN], O.[ID_TRUONG], O.[ID_CAPHOC], O.[NGANHHOC], O.[THOIGIAN_BATDAU], O.[THOIGIAN_KETTHUC], O.[GHICHU]
				FROM
				    [dbo].[LSTRUONGLOP] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_LICHSUTRUONGLOP] = PageIndex.[ID_LICHSUTRUONGLOP]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[LSTRUONGLOP]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSTRUONGLOP_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSTRUONGLOP_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSTRUONGLOP_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the LSTRUONGLOP table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSTRUONGLOP_Insert
(

	@IdLichsutruonglop bigint    OUTPUT,

	@IdQuannhan int   ,

	@IdTruong int   ,

	@IdCaphoc int   ,

	@Nganhhoc nvarchar (50)  ,

	@ThoigianBatdau smalldatetime   ,

	@ThoigianKetthuc smalldatetime   ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[LSTRUONGLOP]
					(
					[ID_QUANNHAN]
					,[ID_TRUONG]
					,[ID_CAPHOC]
					,[NGANHHOC]
					,[THOIGIAN_BATDAU]
					,[THOIGIAN_KETTHUC]
					,[GHICHU]
					)
				VALUES
					(
					@IdQuannhan
					,@IdTruong
					,@IdCaphoc
					,@Nganhhoc
					,@ThoigianBatdau
					,@ThoigianKetthuc
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdLichsutruonglop = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSTRUONGLOP_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSTRUONGLOP_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSTRUONGLOP_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the LSTRUONGLOP table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSTRUONGLOP_Update
(

	@IdLichsutruonglop bigint   ,

	@IdQuannhan int   ,

	@IdTruong int   ,

	@IdCaphoc int   ,

	@Nganhhoc nvarchar (50)  ,

	@ThoigianBatdau smalldatetime   ,

	@ThoigianKetthuc smalldatetime   ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[LSTRUONGLOP]
				SET
					[ID_QUANNHAN] = @IdQuannhan
					,[ID_TRUONG] = @IdTruong
					,[ID_CAPHOC] = @IdCaphoc
					,[NGANHHOC] = @Nganhhoc
					,[THOIGIAN_BATDAU] = @ThoigianBatdau
					,[THOIGIAN_KETTHUC] = @ThoigianKetthuc
					,[GHICHU] = @Ghichu
				WHERE
[ID_LICHSUTRUONGLOP] = @IdLichsutruonglop 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSTRUONGLOP_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSTRUONGLOP_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSTRUONGLOP_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the LSTRUONGLOP table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSTRUONGLOP_Delete
(

	@IdLichsutruonglop bigint   
)
AS


				DELETE FROM [dbo].[LSTRUONGLOP] WITH (ROWLOCK) 
				WHERE
					[ID_LICHSUTRUONGLOP] = @IdLichsutruonglop
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSTRUONGLOP_GetByIdTruong procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSTRUONGLOP_GetByIdTruong') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSTRUONGLOP_GetByIdTruong
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LSTRUONGLOP table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSTRUONGLOP_GetByIdTruong
(

	@IdTruong int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_LICHSUTRUONGLOP],
					[ID_QUANNHAN],
					[ID_TRUONG],
					[ID_CAPHOC],
					[NGANHHOC],
					[THOIGIAN_BATDAU],
					[THOIGIAN_KETTHUC],
					[GHICHU]
				FROM
					[dbo].[LSTRUONGLOP]
				WHERE
					[ID_TRUONG] = @IdTruong
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSTRUONGLOP_GetByIdCaphoc procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSTRUONGLOP_GetByIdCaphoc') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSTRUONGLOP_GetByIdCaphoc
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LSTRUONGLOP table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSTRUONGLOP_GetByIdCaphoc
(

	@IdCaphoc int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_LICHSUTRUONGLOP],
					[ID_QUANNHAN],
					[ID_TRUONG],
					[ID_CAPHOC],
					[NGANHHOC],
					[THOIGIAN_BATDAU],
					[THOIGIAN_KETTHUC],
					[GHICHU]
				FROM
					[dbo].[LSTRUONGLOP]
				WHERE
					[ID_CAPHOC] = @IdCaphoc
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSTRUONGLOP_GetByIdQuannhan procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSTRUONGLOP_GetByIdQuannhan') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSTRUONGLOP_GetByIdQuannhan
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LSTRUONGLOP table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSTRUONGLOP_GetByIdQuannhan
(

	@IdQuannhan int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_LICHSUTRUONGLOP],
					[ID_QUANNHAN],
					[ID_TRUONG],
					[ID_CAPHOC],
					[NGANHHOC],
					[THOIGIAN_BATDAU],
					[THOIGIAN_KETTHUC],
					[GHICHU]
				FROM
					[dbo].[LSTRUONGLOP]
				WHERE
					[ID_QUANNHAN] = @IdQuannhan
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSTRUONGLOP_GetByIdLichsutruonglop procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSTRUONGLOP_GetByIdLichsutruonglop') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSTRUONGLOP_GetByIdLichsutruonglop
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LSTRUONGLOP table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSTRUONGLOP_GetByIdLichsutruonglop
(

	@IdLichsutruonglop bigint   
)
AS


				SELECT
					[ID_LICHSUTRUONGLOP],
					[ID_QUANNHAN],
					[ID_TRUONG],
					[ID_CAPHOC],
					[NGANHHOC],
					[THOIGIAN_BATDAU],
					[THOIGIAN_KETTHUC],
					[GHICHU]
				FROM
					[dbo].[LSTRUONGLOP]
				WHERE
					[ID_LICHSUTRUONGLOP] = @IdLichsutruonglop
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSTRUONGLOP_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSTRUONGLOP_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSTRUONGLOP_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the LSTRUONGLOP table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSTRUONGLOP_Find
(

	@SearchUsingOR bit   = null ,

	@IdLichsutruonglop bigint   = null ,

	@IdQuannhan int   = null ,

	@IdTruong int   = null ,

	@IdCaphoc int   = null ,

	@Nganhhoc nvarchar (50)  = null ,

	@ThoigianBatdau smalldatetime   = null ,

	@ThoigianKetthuc smalldatetime   = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_LICHSUTRUONGLOP]
	, [ID_QUANNHAN]
	, [ID_TRUONG]
	, [ID_CAPHOC]
	, [NGANHHOC]
	, [THOIGIAN_BATDAU]
	, [THOIGIAN_KETTHUC]
	, [GHICHU]
    FROM
	[dbo].[LSTRUONGLOP]
    WHERE 
	 ([ID_LICHSUTRUONGLOP] = @IdLichsutruonglop OR @IdLichsutruonglop is null)
	AND ([ID_QUANNHAN] = @IdQuannhan OR @IdQuannhan is null)
	AND ([ID_TRUONG] = @IdTruong OR @IdTruong is null)
	AND ([ID_CAPHOC] = @IdCaphoc OR @IdCaphoc is null)
	AND ([NGANHHOC] = @Nganhhoc OR @Nganhhoc is null)
	AND ([THOIGIAN_BATDAU] = @ThoigianBatdau OR @ThoigianBatdau is null)
	AND ([THOIGIAN_KETTHUC] = @ThoigianKetthuc OR @ThoigianKetthuc is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_LICHSUTRUONGLOP]
	, [ID_QUANNHAN]
	, [ID_TRUONG]
	, [ID_CAPHOC]
	, [NGANHHOC]
	, [THOIGIAN_BATDAU]
	, [THOIGIAN_KETTHUC]
	, [GHICHU]
    FROM
	[dbo].[LSTRUONGLOP]
    WHERE 
	 ([ID_LICHSUTRUONGLOP] = @IdLichsutruonglop AND @IdLichsutruonglop is not null)
	OR ([ID_QUANNHAN] = @IdQuannhan AND @IdQuannhan is not null)
	OR ([ID_TRUONG] = @IdTruong AND @IdTruong is not null)
	OR ([ID_CAPHOC] = @IdCaphoc AND @IdCaphoc is not null)
	OR ([NGANHHOC] = @Nganhhoc AND @Nganhhoc is not null)
	OR ([THOIGIAN_BATDAU] = @ThoigianBatdau AND @ThoigianBatdau is not null)
	OR ([THOIGIAN_KETTHUC] = @ThoigianKetthuc AND @ThoigianKetthuc is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCAPBAC_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCAPBAC_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCAPBAC_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the LSCAPBAC table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCAPBAC_Get_List

AS


				
				SELECT
					[ID_LICHSUCAPBAC],
					[ID_QUANNHAN],
					[ID_CAPBAC],
					[NGAYNHAN],
					[GHICHU]
				FROM
					[dbo].[LSCAPBAC]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCAPBAC_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCAPBAC_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCAPBAC_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the LSCAPBAC table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCAPBAC_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_LICHSUCAPBAC] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_LICHSUCAPBAC])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_LICHSUCAPBAC]'
				SET @SQL = @SQL + ' FROM [dbo].[LSCAPBAC]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_LICHSUCAPBAC], O.[ID_QUANNHAN], O.[ID_CAPBAC], O.[NGAYNHAN], O.[GHICHU]
				FROM
				    [dbo].[LSCAPBAC] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_LICHSUCAPBAC] = PageIndex.[ID_LICHSUCAPBAC]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[LSCAPBAC]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCAPBAC_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCAPBAC_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCAPBAC_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the LSCAPBAC table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCAPBAC_Insert
(

	@IdLichsucapbac bigint    OUTPUT,

	@IdQuannhan int   ,

	@IdCapbac int   ,

	@Ngaynhan smalldatetime   ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[LSCAPBAC]
					(
					[ID_QUANNHAN]
					,[ID_CAPBAC]
					,[NGAYNHAN]
					,[GHICHU]
					)
				VALUES
					(
					@IdQuannhan
					,@IdCapbac
					,@Ngaynhan
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdLichsucapbac = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCAPBAC_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCAPBAC_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCAPBAC_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the LSCAPBAC table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCAPBAC_Update
(

	@IdLichsucapbac bigint   ,

	@IdQuannhan int   ,

	@IdCapbac int   ,

	@Ngaynhan smalldatetime   ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[LSCAPBAC]
				SET
					[ID_QUANNHAN] = @IdQuannhan
					,[ID_CAPBAC] = @IdCapbac
					,[NGAYNHAN] = @Ngaynhan
					,[GHICHU] = @Ghichu
				WHERE
[ID_LICHSUCAPBAC] = @IdLichsucapbac 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCAPBAC_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCAPBAC_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCAPBAC_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the LSCAPBAC table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCAPBAC_Delete
(

	@IdLichsucapbac bigint   
)
AS


				DELETE FROM [dbo].[LSCAPBAC] WITH (ROWLOCK) 
				WHERE
					[ID_LICHSUCAPBAC] = @IdLichsucapbac
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCAPBAC_GetByIdQuannhan procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCAPBAC_GetByIdQuannhan') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCAPBAC_GetByIdQuannhan
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LSCAPBAC table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCAPBAC_GetByIdQuannhan
(

	@IdQuannhan int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_LICHSUCAPBAC],
					[ID_QUANNHAN],
					[ID_CAPBAC],
					[NGAYNHAN],
					[GHICHU]
				FROM
					[dbo].[LSCAPBAC]
				WHERE
					[ID_QUANNHAN] = @IdQuannhan
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCAPBAC_GetByIdCapbac procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCAPBAC_GetByIdCapbac') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCAPBAC_GetByIdCapbac
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LSCAPBAC table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCAPBAC_GetByIdCapbac
(

	@IdCapbac int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_LICHSUCAPBAC],
					[ID_QUANNHAN],
					[ID_CAPBAC],
					[NGAYNHAN],
					[GHICHU]
				FROM
					[dbo].[LSCAPBAC]
				WHERE
					[ID_CAPBAC] = @IdCapbac
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCAPBAC_GetByIdLichsucapbac procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCAPBAC_GetByIdLichsucapbac') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCAPBAC_GetByIdLichsucapbac
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LSCAPBAC table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCAPBAC_GetByIdLichsucapbac
(

	@IdLichsucapbac bigint   
)
AS


				SELECT
					[ID_LICHSUCAPBAC],
					[ID_QUANNHAN],
					[ID_CAPBAC],
					[NGAYNHAN],
					[GHICHU]
				FROM
					[dbo].[LSCAPBAC]
				WHERE
					[ID_LICHSUCAPBAC] = @IdLichsucapbac
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCAPBAC_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCAPBAC_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCAPBAC_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the LSCAPBAC table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCAPBAC_Find
(

	@SearchUsingOR bit   = null ,

	@IdLichsucapbac bigint   = null ,

	@IdQuannhan int   = null ,

	@IdCapbac int   = null ,

	@Ngaynhan smalldatetime   = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_LICHSUCAPBAC]
	, [ID_QUANNHAN]
	, [ID_CAPBAC]
	, [NGAYNHAN]
	, [GHICHU]
    FROM
	[dbo].[LSCAPBAC]
    WHERE 
	 ([ID_LICHSUCAPBAC] = @IdLichsucapbac OR @IdLichsucapbac is null)
	AND ([ID_QUANNHAN] = @IdQuannhan OR @IdQuannhan is null)
	AND ([ID_CAPBAC] = @IdCapbac OR @IdCapbac is null)
	AND ([NGAYNHAN] = @Ngaynhan OR @Ngaynhan is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_LICHSUCAPBAC]
	, [ID_QUANNHAN]
	, [ID_CAPBAC]
	, [NGAYNHAN]
	, [GHICHU]
    FROM
	[dbo].[LSCAPBAC]
    WHERE 
	 ([ID_LICHSUCAPBAC] = @IdLichsucapbac AND @IdLichsucapbac is not null)
	OR ([ID_QUANNHAN] = @IdQuannhan AND @IdQuannhan is not null)
	OR ([ID_CAPBAC] = @IdCapbac AND @IdCapbac is not null)
	OR ([NGAYNHAN] = @Ngaynhan AND @Ngaynhan is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKYLUAT_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKYLUAT_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKYLUAT_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the LSKYLUAT table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKYLUAT_Get_List

AS


				
				SELECT
					[ID_LICHSUKYLUAT],
					[ID_QUANNHAN],
					[ID_HINHTHUC_KYLUAT],
					[CAP_KYLUAT],
					[NGAY_QUYETDINH],
					[GHICHU]
				FROM
					[dbo].[LSKYLUAT]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKYLUAT_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKYLUAT_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKYLUAT_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the LSKYLUAT table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKYLUAT_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_LICHSUKYLUAT] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_LICHSUKYLUAT])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_LICHSUKYLUAT]'
				SET @SQL = @SQL + ' FROM [dbo].[LSKYLUAT]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_LICHSUKYLUAT], O.[ID_QUANNHAN], O.[ID_HINHTHUC_KYLUAT], O.[CAP_KYLUAT], O.[NGAY_QUYETDINH], O.[GHICHU]
				FROM
				    [dbo].[LSKYLUAT] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_LICHSUKYLUAT] = PageIndex.[ID_LICHSUKYLUAT]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[LSKYLUAT]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKYLUAT_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKYLUAT_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKYLUAT_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the LSKYLUAT table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKYLUAT_Insert
(

	@IdLichsukyluat bigint    OUTPUT,

	@IdQuannhan int   ,

	@IdHinhthucKyluat int   ,

	@CapKyluat nvarchar (50)  ,

	@NgayQuyetdinh smalldatetime   ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[LSKYLUAT]
					(
					[ID_QUANNHAN]
					,[ID_HINHTHUC_KYLUAT]
					,[CAP_KYLUAT]
					,[NGAY_QUYETDINH]
					,[GHICHU]
					)
				VALUES
					(
					@IdQuannhan
					,@IdHinhthucKyluat
					,@CapKyluat
					,@NgayQuyetdinh
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdLichsukyluat = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKYLUAT_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKYLUAT_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKYLUAT_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the LSKYLUAT table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKYLUAT_Update
(

	@IdLichsukyluat bigint   ,

	@IdQuannhan int   ,

	@IdHinhthucKyluat int   ,

	@CapKyluat nvarchar (50)  ,

	@NgayQuyetdinh smalldatetime   ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[LSKYLUAT]
				SET
					[ID_QUANNHAN] = @IdQuannhan
					,[ID_HINHTHUC_KYLUAT] = @IdHinhthucKyluat
					,[CAP_KYLUAT] = @CapKyluat
					,[NGAY_QUYETDINH] = @NgayQuyetdinh
					,[GHICHU] = @Ghichu
				WHERE
[ID_LICHSUKYLUAT] = @IdLichsukyluat 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKYLUAT_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKYLUAT_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKYLUAT_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the LSKYLUAT table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKYLUAT_Delete
(

	@IdLichsukyluat bigint   
)
AS


				DELETE FROM [dbo].[LSKYLUAT] WITH (ROWLOCK) 
				WHERE
					[ID_LICHSUKYLUAT] = @IdLichsukyluat
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKYLUAT_GetByIdQuannhan procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKYLUAT_GetByIdQuannhan') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKYLUAT_GetByIdQuannhan
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LSKYLUAT table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKYLUAT_GetByIdQuannhan
(

	@IdQuannhan int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_LICHSUKYLUAT],
					[ID_QUANNHAN],
					[ID_HINHTHUC_KYLUAT],
					[CAP_KYLUAT],
					[NGAY_QUYETDINH],
					[GHICHU]
				FROM
					[dbo].[LSKYLUAT]
				WHERE
					[ID_QUANNHAN] = @IdQuannhan
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKYLUAT_GetByIdHinhthucKyluat procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKYLUAT_GetByIdHinhthucKyluat') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKYLUAT_GetByIdHinhthucKyluat
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LSKYLUAT table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKYLUAT_GetByIdHinhthucKyluat
(

	@IdHinhthucKyluat int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_LICHSUKYLUAT],
					[ID_QUANNHAN],
					[ID_HINHTHUC_KYLUAT],
					[CAP_KYLUAT],
					[NGAY_QUYETDINH],
					[GHICHU]
				FROM
					[dbo].[LSKYLUAT]
				WHERE
					[ID_HINHTHUC_KYLUAT] = @IdHinhthucKyluat
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKYLUAT_GetByIdLichsukyluat procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKYLUAT_GetByIdLichsukyluat') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKYLUAT_GetByIdLichsukyluat
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LSKYLUAT table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKYLUAT_GetByIdLichsukyluat
(

	@IdLichsukyluat bigint   
)
AS


				SELECT
					[ID_LICHSUKYLUAT],
					[ID_QUANNHAN],
					[ID_HINHTHUC_KYLUAT],
					[CAP_KYLUAT],
					[NGAY_QUYETDINH],
					[GHICHU]
				FROM
					[dbo].[LSKYLUAT]
				WHERE
					[ID_LICHSUKYLUAT] = @IdLichsukyluat
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKYLUAT_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKYLUAT_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKYLUAT_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the LSKYLUAT table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKYLUAT_Find
(

	@SearchUsingOR bit   = null ,

	@IdLichsukyluat bigint   = null ,

	@IdQuannhan int   = null ,

	@IdHinhthucKyluat int   = null ,

	@CapKyluat nvarchar (50)  = null ,

	@NgayQuyetdinh smalldatetime   = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_LICHSUKYLUAT]
	, [ID_QUANNHAN]
	, [ID_HINHTHUC_KYLUAT]
	, [CAP_KYLUAT]
	, [NGAY_QUYETDINH]
	, [GHICHU]
    FROM
	[dbo].[LSKYLUAT]
    WHERE 
	 ([ID_LICHSUKYLUAT] = @IdLichsukyluat OR @IdLichsukyluat is null)
	AND ([ID_QUANNHAN] = @IdQuannhan OR @IdQuannhan is null)
	AND ([ID_HINHTHUC_KYLUAT] = @IdHinhthucKyluat OR @IdHinhthucKyluat is null)
	AND ([CAP_KYLUAT] = @CapKyluat OR @CapKyluat is null)
	AND ([NGAY_QUYETDINH] = @NgayQuyetdinh OR @NgayQuyetdinh is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_LICHSUKYLUAT]
	, [ID_QUANNHAN]
	, [ID_HINHTHUC_KYLUAT]
	, [CAP_KYLUAT]
	, [NGAY_QUYETDINH]
	, [GHICHU]
    FROM
	[dbo].[LSKYLUAT]
    WHERE 
	 ([ID_LICHSUKYLUAT] = @IdLichsukyluat AND @IdLichsukyluat is not null)
	OR ([ID_QUANNHAN] = @IdQuannhan AND @IdQuannhan is not null)
	OR ([ID_HINHTHUC_KYLUAT] = @IdHinhthucKyluat AND @IdHinhthucKyluat is not null)
	OR ([CAP_KYLUAT] = @CapKyluat AND @CapKyluat is not null)
	OR ([NGAY_QUYETDINH] = @NgayQuyetdinh AND @NgayQuyetdinh is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMHINHTHUCKHENTHUONG_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMHINHTHUCKHENTHUONG_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMHINHTHUCKHENTHUONG_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DMHINHTHUCKHENTHUONG table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMHINHTHUCKHENTHUONG_Get_List

AS


				
				SELECT
					[ID_HINHTHUC_KHENTHUONG],
					[HINHTHUC_KHENTHUONG],
					[GHICHU]
				FROM
					[dbo].[DMHINHTHUCKHENTHUONG]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMHINHTHUCKHENTHUONG_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMHINHTHUCKHENTHUONG_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMHINHTHUCKHENTHUONG_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DMHINHTHUCKHENTHUONG table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMHINHTHUCKHENTHUONG_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_HINHTHUC_KHENTHUONG] int 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_HINHTHUC_KHENTHUONG])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_HINHTHUC_KHENTHUONG]'
				SET @SQL = @SQL + ' FROM [dbo].[DMHINHTHUCKHENTHUONG]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_HINHTHUC_KHENTHUONG], O.[HINHTHUC_KHENTHUONG], O.[GHICHU]
				FROM
				    [dbo].[DMHINHTHUCKHENTHUONG] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_HINHTHUC_KHENTHUONG] = PageIndex.[ID_HINHTHUC_KHENTHUONG]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DMHINHTHUCKHENTHUONG]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMHINHTHUCKHENTHUONG_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMHINHTHUCKHENTHUONG_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMHINHTHUCKHENTHUONG_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DMHINHTHUCKHENTHUONG table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMHINHTHUCKHENTHUONG_Insert
(

	@IdHinhthucKhenthuong int    OUTPUT,

	@HinhthucKhenthuong nvarchar (50)  ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[DMHINHTHUCKHENTHUONG]
					(
					[HINHTHUC_KHENTHUONG]
					,[GHICHU]
					)
				VALUES
					(
					@HinhthucKhenthuong
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdHinhthucKhenthuong = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMHINHTHUCKHENTHUONG_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMHINHTHUCKHENTHUONG_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMHINHTHUCKHENTHUONG_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DMHINHTHUCKHENTHUONG table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMHINHTHUCKHENTHUONG_Update
(

	@IdHinhthucKhenthuong int   ,

	@HinhthucKhenthuong nvarchar (50)  ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DMHINHTHUCKHENTHUONG]
				SET
					[HINHTHUC_KHENTHUONG] = @HinhthucKhenthuong
					,[GHICHU] = @Ghichu
				WHERE
[ID_HINHTHUC_KHENTHUONG] = @IdHinhthucKhenthuong 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMHINHTHUCKHENTHUONG_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMHINHTHUCKHENTHUONG_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMHINHTHUCKHENTHUONG_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DMHINHTHUCKHENTHUONG table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMHINHTHUCKHENTHUONG_Delete
(

	@IdHinhthucKhenthuong int   
)
AS


				DELETE FROM [dbo].[DMHINHTHUCKHENTHUONG] WITH (ROWLOCK) 
				WHERE
					[ID_HINHTHUC_KHENTHUONG] = @IdHinhthucKhenthuong
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMHINHTHUCKHENTHUONG_GetByIdHinhthucKhenthuong procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMHINHTHUCKHENTHUONG_GetByIdHinhthucKhenthuong') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMHINHTHUCKHENTHUONG_GetByIdHinhthucKhenthuong
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DMHINHTHUCKHENTHUONG table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMHINHTHUCKHENTHUONG_GetByIdHinhthucKhenthuong
(

	@IdHinhthucKhenthuong int   
)
AS


				SELECT
					[ID_HINHTHUC_KHENTHUONG],
					[HINHTHUC_KHENTHUONG],
					[GHICHU]
				FROM
					[dbo].[DMHINHTHUCKHENTHUONG]
				WHERE
					[ID_HINHTHUC_KHENTHUONG] = @IdHinhthucKhenthuong
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMHINHTHUCKHENTHUONG_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMHINHTHUCKHENTHUONG_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMHINHTHUCKHENTHUONG_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DMHINHTHUCKHENTHUONG table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMHINHTHUCKHENTHUONG_Find
(

	@SearchUsingOR bit   = null ,

	@IdHinhthucKhenthuong int   = null ,

	@HinhthucKhenthuong nvarchar (50)  = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_HINHTHUC_KHENTHUONG]
	, [HINHTHUC_KHENTHUONG]
	, [GHICHU]
    FROM
	[dbo].[DMHINHTHUCKHENTHUONG]
    WHERE 
	 ([ID_HINHTHUC_KHENTHUONG] = @IdHinhthucKhenthuong OR @IdHinhthucKhenthuong is null)
	AND ([HINHTHUC_KHENTHUONG] = @HinhthucKhenthuong OR @HinhthucKhenthuong is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_HINHTHUC_KHENTHUONG]
	, [HINHTHUC_KHENTHUONG]
	, [GHICHU]
    FROM
	[dbo].[DMHINHTHUCKHENTHUONG]
    WHERE 
	 ([ID_HINHTHUC_KHENTHUONG] = @IdHinhthucKhenthuong AND @IdHinhthucKhenthuong is not null)
	OR ([HINHTHUC_KHENTHUONG] = @HinhthucKhenthuong AND @HinhthucKhenthuong is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCHUCVU_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCHUCVU_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCHUCVU_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the LSCHUCVU table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCHUCVU_Get_List

AS


				
				SELECT
					[ID_LICHSUCHUCVU],
					[ID_QUANNHAN],
					[ID_CHUCVU],
					[NGAYNHAN],
					[GHICHU]
				FROM
					[dbo].[LSCHUCVU]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCHUCVU_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCHUCVU_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCHUCVU_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the LSCHUCVU table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCHUCVU_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_LICHSUCHUCVU] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_LICHSUCHUCVU])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_LICHSUCHUCVU]'
				SET @SQL = @SQL + ' FROM [dbo].[LSCHUCVU]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_LICHSUCHUCVU], O.[ID_QUANNHAN], O.[ID_CHUCVU], O.[NGAYNHAN], O.[GHICHU]
				FROM
				    [dbo].[LSCHUCVU] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_LICHSUCHUCVU] = PageIndex.[ID_LICHSUCHUCVU]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[LSCHUCVU]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCHUCVU_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCHUCVU_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCHUCVU_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the LSCHUCVU table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCHUCVU_Insert
(

	@IdLichsuchucvu bigint    OUTPUT,

	@IdQuannhan int   ,

	@IdChucvu int   ,

	@Ngaynhan smalldatetime   ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[LSCHUCVU]
					(
					[ID_QUANNHAN]
					,[ID_CHUCVU]
					,[NGAYNHAN]
					,[GHICHU]
					)
				VALUES
					(
					@IdQuannhan
					,@IdChucvu
					,@Ngaynhan
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdLichsuchucvu = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCHUCVU_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCHUCVU_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCHUCVU_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the LSCHUCVU table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCHUCVU_Update
(

	@IdLichsuchucvu bigint   ,

	@IdQuannhan int   ,

	@IdChucvu int   ,

	@Ngaynhan smalldatetime   ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[LSCHUCVU]
				SET
					[ID_QUANNHAN] = @IdQuannhan
					,[ID_CHUCVU] = @IdChucvu
					,[NGAYNHAN] = @Ngaynhan
					,[GHICHU] = @Ghichu
				WHERE
[ID_LICHSUCHUCVU] = @IdLichsuchucvu 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCHUCVU_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCHUCVU_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCHUCVU_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the LSCHUCVU table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCHUCVU_Delete
(

	@IdLichsuchucvu bigint   
)
AS


				DELETE FROM [dbo].[LSCHUCVU] WITH (ROWLOCK) 
				WHERE
					[ID_LICHSUCHUCVU] = @IdLichsuchucvu
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCHUCVU_GetByIdChucvu procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCHUCVU_GetByIdChucvu') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCHUCVU_GetByIdChucvu
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LSCHUCVU table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCHUCVU_GetByIdChucvu
(

	@IdChucvu int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_LICHSUCHUCVU],
					[ID_QUANNHAN],
					[ID_CHUCVU],
					[NGAYNHAN],
					[GHICHU]
				FROM
					[dbo].[LSCHUCVU]
				WHERE
					[ID_CHUCVU] = @IdChucvu
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCHUCVU_GetByIdQuannhan procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCHUCVU_GetByIdQuannhan') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCHUCVU_GetByIdQuannhan
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LSCHUCVU table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCHUCVU_GetByIdQuannhan
(

	@IdQuannhan int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_LICHSUCHUCVU],
					[ID_QUANNHAN],
					[ID_CHUCVU],
					[NGAYNHAN],
					[GHICHU]
				FROM
					[dbo].[LSCHUCVU]
				WHERE
					[ID_QUANNHAN] = @IdQuannhan
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCHUCVU_GetByIdLichsuchucvu procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCHUCVU_GetByIdLichsuchucvu') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCHUCVU_GetByIdLichsuchucvu
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LSCHUCVU table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCHUCVU_GetByIdLichsuchucvu
(

	@IdLichsuchucvu bigint   
)
AS


				SELECT
					[ID_LICHSUCHUCVU],
					[ID_QUANNHAN],
					[ID_CHUCVU],
					[NGAYNHAN],
					[GHICHU]
				FROM
					[dbo].[LSCHUCVU]
				WHERE
					[ID_LICHSUCHUCVU] = @IdLichsuchucvu
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSCHUCVU_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSCHUCVU_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSCHUCVU_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the LSCHUCVU table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSCHUCVU_Find
(

	@SearchUsingOR bit   = null ,

	@IdLichsuchucvu bigint   = null ,

	@IdQuannhan int   = null ,

	@IdChucvu int   = null ,

	@Ngaynhan smalldatetime   = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_LICHSUCHUCVU]
	, [ID_QUANNHAN]
	, [ID_CHUCVU]
	, [NGAYNHAN]
	, [GHICHU]
    FROM
	[dbo].[LSCHUCVU]
    WHERE 
	 ([ID_LICHSUCHUCVU] = @IdLichsuchucvu OR @IdLichsuchucvu is null)
	AND ([ID_QUANNHAN] = @IdQuannhan OR @IdQuannhan is null)
	AND ([ID_CHUCVU] = @IdChucvu OR @IdChucvu is null)
	AND ([NGAYNHAN] = @Ngaynhan OR @Ngaynhan is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_LICHSUCHUCVU]
	, [ID_QUANNHAN]
	, [ID_CHUCVU]
	, [NGAYNHAN]
	, [GHICHU]
    FROM
	[dbo].[LSCHUCVU]
    WHERE 
	 ([ID_LICHSUCHUCVU] = @IdLichsuchucvu AND @IdLichsuchucvu is not null)
	OR ([ID_QUANNHAN] = @IdQuannhan AND @IdQuannhan is not null)
	OR ([ID_CHUCVU] = @IdChucvu AND @IdChucvu is not null)
	OR ([NGAYNHAN] = @Ngaynhan AND @Ngaynhan is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_USERS_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_USERS_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_USERS_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ADMIN_USERS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_USERS_Get_List

AS


				
				SELECT
					[ID_USER],
					[PASSWORD],
					[FULL_NAME],
					[ACTIVE],
					[MODIFIED],
					[DESCRIPTION]
				FROM
					[dbo].[ADMIN_USERS]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_USERS_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_USERS_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_USERS_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ADMIN_USERS table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_USERS_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_USER] char(15) COLLATE database_default  
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_USER])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_USER]'
				SET @SQL = @SQL + ' FROM [dbo].[ADMIN_USERS]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_USER], O.[PASSWORD], O.[FULL_NAME], O.[ACTIVE], O.[MODIFIED], O.[DESCRIPTION]
				FROM
				    [dbo].[ADMIN_USERS] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_USER] = PageIndex.[ID_USER]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ADMIN_USERS]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_USERS_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_USERS_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_USERS_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ADMIN_USERS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_USERS_Insert
(

	@IdUser char (15)  ,

	@Password varbinary (MAX)  ,

	@FullName nvarchar (255)  ,

	@Active int   ,

	@Modified datetime   ,

	@Description nvarchar (100)  
)
AS


					
				INSERT INTO [dbo].[ADMIN_USERS]
					(
					[ID_USER]
					,[PASSWORD]
					,[FULL_NAME]
					,[ACTIVE]
					,[MODIFIED]
					,[DESCRIPTION]
					)
				VALUES
					(
					@IdUser
					,@Password
					,@FullName
					,@Active
					,@Modified
					,@Description
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_USERS_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_USERS_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_USERS_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ADMIN_USERS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_USERS_Update
(

	@IdUser char (15)  ,

	@OriginalIdUser char (15)  ,

	@Password varbinary (MAX)  ,

	@FullName nvarchar (255)  ,

	@Active int   ,

	@Modified datetime   ,

	@Description nvarchar (100)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ADMIN_USERS]
				SET
					[ID_USER] = @IdUser
					,[PASSWORD] = @Password
					,[FULL_NAME] = @FullName
					,[ACTIVE] = @Active
					,[MODIFIED] = @Modified
					,[DESCRIPTION] = @Description
				WHERE
[ID_USER] = @OriginalIdUser 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_USERS_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_USERS_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_USERS_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ADMIN_USERS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_USERS_Delete
(

	@IdUser char (15)  
)
AS


				DELETE FROM [dbo].[ADMIN_USERS] WITH (ROWLOCK) 
				WHERE
					[ID_USER] = @IdUser
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_USERS_GetByIdUser procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_USERS_GetByIdUser') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_USERS_GetByIdUser
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ADMIN_USERS table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_USERS_GetByIdUser
(

	@IdUser char (15)  
)
AS


				SELECT
					[ID_USER],
					[PASSWORD],
					[FULL_NAME],
					[ACTIVE],
					[MODIFIED],
					[DESCRIPTION]
				FROM
					[dbo].[ADMIN_USERS]
				WHERE
					[ID_USER] = @IdUser
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_USERS_GetByIdGroupFromAdminGroupusers procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_USERS_GetByIdGroupFromAdminGroupusers') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_USERS_GetByIdGroupFromAdminGroupusers
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_USERS_GetByIdGroupFromAdminGroupusers
(

	@IdGroup char (15)  
)
AS


SELECT dbo.[ADMIN_USERS].[ID_USER]
       ,dbo.[ADMIN_USERS].[PASSWORD]
       ,dbo.[ADMIN_USERS].[FULL_NAME]
       ,dbo.[ADMIN_USERS].[ACTIVE]
       ,dbo.[ADMIN_USERS].[MODIFIED]
       ,dbo.[ADMIN_USERS].[DESCRIPTION]
  FROM dbo.[ADMIN_USERS]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[ADMIN_GROUPUSERS] 
                WHERE dbo.[ADMIN_GROUPUSERS].[ID_GROUP] = @IdGroup
                  AND dbo.[ADMIN_GROUPUSERS].[ID_USER] = dbo.[ADMIN_USERS].[ID_USER]
                  )
				Select @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_USERS_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_USERS_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_USERS_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ADMIN_USERS table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_USERS_Find
(

	@SearchUsingOR bit   = null ,

	@IdUser char (15)  = null ,

	@Password varbinary (MAX)  = null ,

	@FullName nvarchar (255)  = null ,

	@Active int   = null ,

	@Modified datetime   = null ,

	@Description nvarchar (100)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_USER]
	, [PASSWORD]
	, [FULL_NAME]
	, [ACTIVE]
	, [MODIFIED]
	, [DESCRIPTION]
    FROM
	[dbo].[ADMIN_USERS]
    WHERE 
	 ([ID_USER] = @IdUser OR @IdUser is null)
	AND ([FULL_NAME] = @FullName OR @FullName is null)
	AND ([ACTIVE] = @Active OR @Active is null)
	AND ([MODIFIED] = @Modified OR @Modified is null)
	AND ([DESCRIPTION] = @Description OR @Description is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_USER]
	, [PASSWORD]
	, [FULL_NAME]
	, [ACTIVE]
	, [MODIFIED]
	, [DESCRIPTION]
    FROM
	[dbo].[ADMIN_USERS]
    WHERE 
	 ([ID_USER] = @IdUser AND @IdUser is not null)
	OR ([FULL_NAME] = @FullName AND @FullName is not null)
	OR ([ACTIVE] = @Active AND @Active is not null)
	OR ([MODIFIED] = @Modified AND @Modified is not null)
	OR ([DESCRIPTION] = @Description AND @Description is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPS_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPS_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPS_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ADMIN_GROUPS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPS_Get_List

AS


				
				SELECT
					[ID_GROUP],
					[GROUP_NAME],
					[ACTIVE],
					[PARENT],
					[DESCRIPTION],
					[MODIFIED]
				FROM
					[dbo].[ADMIN_GROUPS]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPS_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPS_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPS_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ADMIN_GROUPS table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPS_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_GROUP] char(15) COLLATE database_default  
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_GROUP])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_GROUP]'
				SET @SQL = @SQL + ' FROM [dbo].[ADMIN_GROUPS]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_GROUP], O.[GROUP_NAME], O.[ACTIVE], O.[PARENT], O.[DESCRIPTION], O.[MODIFIED]
				FROM
				    [dbo].[ADMIN_GROUPS] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_GROUP] = PageIndex.[ID_GROUP]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ADMIN_GROUPS]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPS_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPS_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPS_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ADMIN_GROUPS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPS_Insert
(

	@IdGroup char (15)  ,

	@GroupName nvarchar (255)  ,

	@Active int   ,

	@Parent nchar (10)  ,

	@Description nvarchar (100)  ,

	@Modified datetime   
)
AS


					
				INSERT INTO [dbo].[ADMIN_GROUPS]
					(
					[ID_GROUP]
					,[GROUP_NAME]
					,[ACTIVE]
					,[PARENT]
					,[DESCRIPTION]
					,[MODIFIED]
					)
				VALUES
					(
					@IdGroup
					,@GroupName
					,@Active
					,@Parent
					,@Description
					,@Modified
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPS_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPS_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPS_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ADMIN_GROUPS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPS_Update
(

	@IdGroup char (15)  ,

	@OriginalIdGroup char (15)  ,

	@GroupName nvarchar (255)  ,

	@Active int   ,

	@Parent nchar (10)  ,

	@Description nvarchar (100)  ,

	@Modified datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ADMIN_GROUPS]
				SET
					[ID_GROUP] = @IdGroup
					,[GROUP_NAME] = @GroupName
					,[ACTIVE] = @Active
					,[PARENT] = @Parent
					,[DESCRIPTION] = @Description
					,[MODIFIED] = @Modified
				WHERE
[ID_GROUP] = @OriginalIdGroup 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPS_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPS_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPS_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ADMIN_GROUPS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPS_Delete
(

	@IdGroup char (15)  
)
AS


				DELETE FROM [dbo].[ADMIN_GROUPS] WITH (ROWLOCK) 
				WHERE
					[ID_GROUP] = @IdGroup
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPS_GetByIdGroup procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPS_GetByIdGroup') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPS_GetByIdGroup
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ADMIN_GROUPS table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPS_GetByIdGroup
(

	@IdGroup char (15)  
)
AS


				SELECT
					[ID_GROUP],
					[GROUP_NAME],
					[ACTIVE],
					[PARENT],
					[DESCRIPTION],
					[MODIFIED]
				FROM
					[dbo].[ADMIN_GROUPS]
				WHERE
					[ID_GROUP] = @IdGroup
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPS_GetByIdUserFromAdminGroupusers procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPS_GetByIdUserFromAdminGroupusers') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPS_GetByIdUserFromAdminGroupusers
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPS_GetByIdUserFromAdminGroupusers
(

	@IdUser char (15)  
)
AS


SELECT dbo.[ADMIN_GROUPS].[ID_GROUP]
       ,dbo.[ADMIN_GROUPS].[GROUP_NAME]
       ,dbo.[ADMIN_GROUPS].[ACTIVE]
       ,dbo.[ADMIN_GROUPS].[PARENT]
       ,dbo.[ADMIN_GROUPS].[DESCRIPTION]
       ,dbo.[ADMIN_GROUPS].[MODIFIED]
  FROM dbo.[ADMIN_GROUPS]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[ADMIN_GROUPUSERS] 
                WHERE dbo.[ADMIN_GROUPUSERS].[ID_USER] = @IdUser
                  AND dbo.[ADMIN_GROUPUSERS].[ID_GROUP] = dbo.[ADMIN_GROUPS].[ID_GROUP]
                  )
				Select @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPS_GetByIdMenuFromAdminGroupmenus procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPS_GetByIdMenuFromAdminGroupmenus') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPS_GetByIdMenuFromAdminGroupmenus
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPS_GetByIdMenuFromAdminGroupmenus
(

	@IdMenu char (50)  
)
AS


SELECT dbo.[ADMIN_GROUPS].[ID_GROUP]
       ,dbo.[ADMIN_GROUPS].[GROUP_NAME]
       ,dbo.[ADMIN_GROUPS].[ACTIVE]
       ,dbo.[ADMIN_GROUPS].[PARENT]
       ,dbo.[ADMIN_GROUPS].[DESCRIPTION]
       ,dbo.[ADMIN_GROUPS].[MODIFIED]
  FROM dbo.[ADMIN_GROUPS]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[ADMIN_GROUPMENUS] 
                WHERE dbo.[ADMIN_GROUPMENUS].[ID_MENU] = @IdMenu
                  AND dbo.[ADMIN_GROUPMENUS].[ID_GROUP] = dbo.[ADMIN_GROUPS].[ID_GROUP]
                  )
				Select @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPS_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPS_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPS_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ADMIN_GROUPS table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPS_Find
(

	@SearchUsingOR bit   = null ,

	@IdGroup char (15)  = null ,

	@GroupName nvarchar (255)  = null ,

	@Active int   = null ,

	@Parent nchar (10)  = null ,

	@Description nvarchar (100)  = null ,

	@Modified datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_GROUP]
	, [GROUP_NAME]
	, [ACTIVE]
	, [PARENT]
	, [DESCRIPTION]
	, [MODIFIED]
    FROM
	[dbo].[ADMIN_GROUPS]
    WHERE 
	 ([ID_GROUP] = @IdGroup OR @IdGroup is null)
	AND ([GROUP_NAME] = @GroupName OR @GroupName is null)
	AND ([ACTIVE] = @Active OR @Active is null)
	AND ([PARENT] = @Parent OR @Parent is null)
	AND ([DESCRIPTION] = @Description OR @Description is null)
	AND ([MODIFIED] = @Modified OR @Modified is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_GROUP]
	, [GROUP_NAME]
	, [ACTIVE]
	, [PARENT]
	, [DESCRIPTION]
	, [MODIFIED]
    FROM
	[dbo].[ADMIN_GROUPS]
    WHERE 
	 ([ID_GROUP] = @IdGroup AND @IdGroup is not null)
	OR ([GROUP_NAME] = @GroupName AND @GroupName is not null)
	OR ([ACTIVE] = @Active AND @Active is not null)
	OR ([PARENT] = @Parent AND @Parent is not null)
	OR ([DESCRIPTION] = @Description AND @Description is not null)
	OR ([MODIFIED] = @Modified AND @Modified is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_MENUS_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_MENUS_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_MENUS_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ADMIN_MENUS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_MENUS_Get_List

AS


				
				SELECT
					[ID_MENU],
					[MENU_NAME],
					[ACTIVE],
					[PARENT],
					[IMAGE_NAME],
					[IS_CREATE_ICON],
					[DESCRIPTION],
					[CHECKED],
					[MODIFIED],
					[MENU_ORDER]
				FROM
					[dbo].[ADMIN_MENUS]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_MENUS_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_MENUS_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_MENUS_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ADMIN_MENUS table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_MENUS_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_MENU] char(50) COLLATE database_default  
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_MENU])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_MENU]'
				SET @SQL = @SQL + ' FROM [dbo].[ADMIN_MENUS]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_MENU], O.[MENU_NAME], O.[ACTIVE], O.[PARENT], O.[IMAGE_NAME], O.[IS_CREATE_ICON], O.[DESCRIPTION], O.[CHECKED], O.[MODIFIED], O.[MENU_ORDER]
				FROM
				    [dbo].[ADMIN_MENUS] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_MENU] = PageIndex.[ID_MENU]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ADMIN_MENUS]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_MENUS_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_MENUS_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_MENUS_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ADMIN_MENUS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_MENUS_Insert
(

	@IdMenu char (50)  ,

	@MenuName nvarchar (255)  ,

	@Active int   ,

	@Parent char (15)  ,

	@ImageName char (50)  ,

	@IsCreateIcon int   ,

	@Description nvarchar (255)  ,

	@SafeNameChecked int   ,

	@Modified datetime   ,

	@MenuOrder int   
)
AS


					
				INSERT INTO [dbo].[ADMIN_MENUS]
					(
					[ID_MENU]
					,[MENU_NAME]
					,[ACTIVE]
					,[PARENT]
					,[IMAGE_NAME]
					,[IS_CREATE_ICON]
					,[DESCRIPTION]
					,[CHECKED]
					,[MODIFIED]
					,[MENU_ORDER]
					)
				VALUES
					(
					@IdMenu
					,@MenuName
					,@Active
					,@Parent
					,@ImageName
					,@IsCreateIcon
					,@Description
					,@SafeNameChecked
					,@Modified
					,@MenuOrder
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_MENUS_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_MENUS_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_MENUS_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ADMIN_MENUS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_MENUS_Update
(

	@IdMenu char (50)  ,

	@OriginalIdMenu char (50)  ,

	@MenuName nvarchar (255)  ,

	@Active int   ,

	@Parent char (15)  ,

	@ImageName char (50)  ,

	@IsCreateIcon int   ,

	@Description nvarchar (255)  ,

	@SafeNameChecked int   ,

	@Modified datetime   ,

	@MenuOrder int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ADMIN_MENUS]
				SET
					[ID_MENU] = @IdMenu
					,[MENU_NAME] = @MenuName
					,[ACTIVE] = @Active
					,[PARENT] = @Parent
					,[IMAGE_NAME] = @ImageName
					,[IS_CREATE_ICON] = @IsCreateIcon
					,[DESCRIPTION] = @Description
					,[CHECKED] = @SafeNameChecked
					,[MODIFIED] = @Modified
					,[MENU_ORDER] = @MenuOrder
				WHERE
[ID_MENU] = @OriginalIdMenu 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_MENUS_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_MENUS_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_MENUS_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ADMIN_MENUS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_MENUS_Delete
(

	@IdMenu char (50)  
)
AS


				DELETE FROM [dbo].[ADMIN_MENUS] WITH (ROWLOCK) 
				WHERE
					[ID_MENU] = @IdMenu
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_MENUS_GetByIdMenu procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_MENUS_GetByIdMenu') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_MENUS_GetByIdMenu
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ADMIN_MENUS table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_MENUS_GetByIdMenu
(

	@IdMenu char (50)  
)
AS


				SELECT
					[ID_MENU],
					[MENU_NAME],
					[ACTIVE],
					[PARENT],
					[IMAGE_NAME],
					[IS_CREATE_ICON],
					[DESCRIPTION],
					[CHECKED],
					[MODIFIED],
					[MENU_ORDER]
				FROM
					[dbo].[ADMIN_MENUS]
				WHERE
					[ID_MENU] = @IdMenu
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_MENUS_GetByIdGroupFromAdminGroupmenus procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_MENUS_GetByIdGroupFromAdminGroupmenus') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_MENUS_GetByIdGroupFromAdminGroupmenus
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_MENUS_GetByIdGroupFromAdminGroupmenus
(

	@IdGroup char (15)  
)
AS


SELECT dbo.[ADMIN_MENUS].[ID_MENU]
       ,dbo.[ADMIN_MENUS].[MENU_NAME]
       ,dbo.[ADMIN_MENUS].[ACTIVE]
       ,dbo.[ADMIN_MENUS].[PARENT]
       ,dbo.[ADMIN_MENUS].[IMAGE_NAME]
       ,dbo.[ADMIN_MENUS].[IS_CREATE_ICON]
       ,dbo.[ADMIN_MENUS].[DESCRIPTION]
       ,dbo.[ADMIN_MENUS].[CHECKED]
       ,dbo.[ADMIN_MENUS].[MODIFIED]
       ,dbo.[ADMIN_MENUS].[MENU_ORDER]
  FROM dbo.[ADMIN_MENUS]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[ADMIN_GROUPMENUS] 
                WHERE dbo.[ADMIN_GROUPMENUS].[ID_GROUP] = @IdGroup
                  AND dbo.[ADMIN_GROUPMENUS].[ID_MENU] = dbo.[ADMIN_MENUS].[ID_MENU]
                  )
				Select @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_MENUS_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_MENUS_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_MENUS_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ADMIN_MENUS table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_MENUS_Find
(

	@SearchUsingOR bit   = null ,

	@IdMenu char (50)  = null ,

	@MenuName nvarchar (255)  = null ,

	@Active int   = null ,

	@Parent char (15)  = null ,

	@ImageName char (50)  = null ,

	@IsCreateIcon int   = null ,

	@Description nvarchar (255)  = null ,

	@SafeNameChecked int   = null ,

	@Modified datetime   = null ,

	@MenuOrder int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_MENU]
	, [MENU_NAME]
	, [ACTIVE]
	, [PARENT]
	, [IMAGE_NAME]
	, [IS_CREATE_ICON]
	, [DESCRIPTION]
	, [CHECKED]
	, [MODIFIED]
	, [MENU_ORDER]
    FROM
	[dbo].[ADMIN_MENUS]
    WHERE 
	 ([ID_MENU] = @IdMenu OR @IdMenu is null)
	AND ([MENU_NAME] = @MenuName OR @MenuName is null)
	AND ([ACTIVE] = @Active OR @Active is null)
	AND ([PARENT] = @Parent OR @Parent is null)
	AND ([IMAGE_NAME] = @ImageName OR @ImageName is null)
	AND ([IS_CREATE_ICON] = @IsCreateIcon OR @IsCreateIcon is null)
	AND ([DESCRIPTION] = @Description OR @Description is null)
	AND ([CHECKED] = @SafeNameChecked OR @SafeNameChecked is null)
	AND ([MODIFIED] = @Modified OR @Modified is null)
	AND ([MENU_ORDER] = @MenuOrder OR @MenuOrder is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_MENU]
	, [MENU_NAME]
	, [ACTIVE]
	, [PARENT]
	, [IMAGE_NAME]
	, [IS_CREATE_ICON]
	, [DESCRIPTION]
	, [CHECKED]
	, [MODIFIED]
	, [MENU_ORDER]
    FROM
	[dbo].[ADMIN_MENUS]
    WHERE 
	 ([ID_MENU] = @IdMenu AND @IdMenu is not null)
	OR ([MENU_NAME] = @MenuName AND @MenuName is not null)
	OR ([ACTIVE] = @Active AND @Active is not null)
	OR ([PARENT] = @Parent AND @Parent is not null)
	OR ([IMAGE_NAME] = @ImageName AND @ImageName is not null)
	OR ([IS_CREATE_ICON] = @IsCreateIcon AND @IsCreateIcon is not null)
	OR ([DESCRIPTION] = @Description AND @Description is not null)
	OR ([CHECKED] = @SafeNameChecked AND @SafeNameChecked is not null)
	OR ([MODIFIED] = @Modified AND @Modified is not null)
	OR ([MENU_ORDER] = @MenuOrder AND @MenuOrder is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMGIOITINH_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMGIOITINH_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMGIOITINH_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DMGIOITINH table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMGIOITINH_Get_List

AS


				
				SELECT
					[ID_GIOITINH],
					[GIOITINH],
					[GHICHU]
				FROM
					[dbo].[DMGIOITINH]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMGIOITINH_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMGIOITINH_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMGIOITINH_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DMGIOITINH table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMGIOITINH_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_GIOITINH] int 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_GIOITINH])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_GIOITINH]'
				SET @SQL = @SQL + ' FROM [dbo].[DMGIOITINH]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_GIOITINH], O.[GIOITINH], O.[GHICHU]
				FROM
				    [dbo].[DMGIOITINH] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_GIOITINH] = PageIndex.[ID_GIOITINH]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DMGIOITINH]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMGIOITINH_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMGIOITINH_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMGIOITINH_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DMGIOITINH table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMGIOITINH_Insert
(

	@IdGioitinh int    OUTPUT,

	@Gioitinh nvarchar (50)  ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[DMGIOITINH]
					(
					[GIOITINH]
					,[GHICHU]
					)
				VALUES
					(
					@Gioitinh
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdGioitinh = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMGIOITINH_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMGIOITINH_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMGIOITINH_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DMGIOITINH table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMGIOITINH_Update
(

	@IdGioitinh int   ,

	@Gioitinh nvarchar (50)  ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DMGIOITINH]
				SET
					[GIOITINH] = @Gioitinh
					,[GHICHU] = @Ghichu
				WHERE
[ID_GIOITINH] = @IdGioitinh 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMGIOITINH_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMGIOITINH_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMGIOITINH_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DMGIOITINH table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMGIOITINH_Delete
(

	@IdGioitinh int   
)
AS


				DELETE FROM [dbo].[DMGIOITINH] WITH (ROWLOCK) 
				WHERE
					[ID_GIOITINH] = @IdGioitinh
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMGIOITINH_GetByIdGioitinh procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMGIOITINH_GetByIdGioitinh') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMGIOITINH_GetByIdGioitinh
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DMGIOITINH table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMGIOITINH_GetByIdGioitinh
(

	@IdGioitinh int   
)
AS


				SELECT
					[ID_GIOITINH],
					[GIOITINH],
					[GHICHU]
				FROM
					[dbo].[DMGIOITINH]
				WHERE
					[ID_GIOITINH] = @IdGioitinh
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMGIOITINH_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMGIOITINH_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMGIOITINH_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DMGIOITINH table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMGIOITINH_Find
(

	@SearchUsingOR bit   = null ,

	@IdGioitinh int   = null ,

	@Gioitinh nvarchar (50)  = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_GIOITINH]
	, [GIOITINH]
	, [GHICHU]
    FROM
	[dbo].[DMGIOITINH]
    WHERE 
	 ([ID_GIOITINH] = @IdGioitinh OR @IdGioitinh is null)
	AND ([GIOITINH] = @Gioitinh OR @Gioitinh is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_GIOITINH]
	, [GIOITINH]
	, [GHICHU]
    FROM
	[dbo].[DMGIOITINH]
    WHERE 
	 ([ID_GIOITINH] = @IdGioitinh AND @IdGioitinh is not null)
	OR ([GIOITINH] = @Gioitinh AND @Gioitinh is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPUSERS_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPUSERS_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPUSERS_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ADMIN_GROUPUSERS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPUSERS_Get_List

AS


				
				SELECT
					[ID_GROUP],
					[ID_USER]
				FROM
					[dbo].[ADMIN_GROUPUSERS]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPUSERS_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPUSERS_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPUSERS_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ADMIN_GROUPUSERS table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPUSERS_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_GROUP] char(15) COLLATE database_default , [ID_USER] char(15) COLLATE database_default  
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_GROUP], [ID_USER])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_GROUP], [ID_USER]'
				SET @SQL = @SQL + ' FROM [dbo].[ADMIN_GROUPUSERS]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_GROUP], O.[ID_USER]
				FROM
				    [dbo].[ADMIN_GROUPUSERS] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_GROUP] = PageIndex.[ID_GROUP]
					AND O.[ID_USER] = PageIndex.[ID_USER]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ADMIN_GROUPUSERS]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPUSERS_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPUSERS_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPUSERS_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ADMIN_GROUPUSERS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPUSERS_Insert
(

	@IdGroup char (15)  ,

	@IdUser char (15)  
)
AS


					
				INSERT INTO [dbo].[ADMIN_GROUPUSERS]
					(
					[ID_GROUP]
					,[ID_USER]
					)
				VALUES
					(
					@IdGroup
					,@IdUser
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPUSERS_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPUSERS_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPUSERS_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ADMIN_GROUPUSERS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPUSERS_Update
(

	@IdGroup char (15)  ,

	@OriginalIdGroup char (15)  ,

	@IdUser char (15)  ,

	@OriginalIdUser char (15)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ADMIN_GROUPUSERS]
				SET
					[ID_GROUP] = @IdGroup
					,[ID_USER] = @IdUser
				WHERE
[ID_GROUP] = @OriginalIdGroup 
AND [ID_USER] = @OriginalIdUser 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPUSERS_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPUSERS_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPUSERS_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ADMIN_GROUPUSERS table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPUSERS_Delete
(

	@IdGroup char (15)  ,

	@IdUser char (15)  
)
AS


				DELETE FROM [dbo].[ADMIN_GROUPUSERS] WITH (ROWLOCK) 
				WHERE
					[ID_GROUP] = @IdGroup
					AND [ID_USER] = @IdUser
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPUSERS_GetByIdGroup procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPUSERS_GetByIdGroup') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPUSERS_GetByIdGroup
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ADMIN_GROUPUSERS table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPUSERS_GetByIdGroup
(

	@IdGroup char (15)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_GROUP],
					[ID_USER]
				FROM
					[dbo].[ADMIN_GROUPUSERS]
				WHERE
					[ID_GROUP] = @IdGroup
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPUSERS_GetByIdUser procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPUSERS_GetByIdUser') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPUSERS_GetByIdUser
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ADMIN_GROUPUSERS table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPUSERS_GetByIdUser
(

	@IdUser char (15)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_GROUP],
					[ID_USER]
				FROM
					[dbo].[ADMIN_GROUPUSERS]
				WHERE
					[ID_USER] = @IdUser
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPUSERS_GetByIdGroupIdUser procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPUSERS_GetByIdGroupIdUser') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPUSERS_GetByIdGroupIdUser
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ADMIN_GROUPUSERS table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPUSERS_GetByIdGroupIdUser
(

	@IdGroup char (15)  ,

	@IdUser char (15)  
)
AS


				SELECT
					[ID_GROUP],
					[ID_USER]
				FROM
					[dbo].[ADMIN_GROUPUSERS]
				WHERE
					[ID_GROUP] = @IdGroup
					AND [ID_USER] = @IdUser
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ADMIN_GROUPUSERS_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ADMIN_GROUPUSERS_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ADMIN_GROUPUSERS_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ADMIN_GROUPUSERS table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ADMIN_GROUPUSERS_Find
(

	@SearchUsingOR bit   = null ,

	@IdGroup char (15)  = null ,

	@IdUser char (15)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_GROUP]
	, [ID_USER]
    FROM
	[dbo].[ADMIN_GROUPUSERS]
    WHERE 
	 ([ID_GROUP] = @IdGroup OR @IdGroup is null)
	AND ([ID_USER] = @IdUser OR @IdUser is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_GROUP]
	, [ID_USER]
    FROM
	[dbo].[ADMIN_GROUPUSERS]
    WHERE 
	 ([ID_GROUP] = @IdGroup AND @IdGroup is not null)
	OR ([ID_USER] = @IdUser AND @IdUser is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCAPHOC_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCAPHOC_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCAPHOC_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DMCAPHOC table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCAPHOC_Get_List

AS


				
				SELECT
					[ID_CAPHOC],
					[CAPHOC],
					[GHICHU]
				FROM
					[dbo].[DMCAPHOC]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCAPHOC_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCAPHOC_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCAPHOC_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DMCAPHOC table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCAPHOC_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_CAPHOC] int 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_CAPHOC])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_CAPHOC]'
				SET @SQL = @SQL + ' FROM [dbo].[DMCAPHOC]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_CAPHOC], O.[CAPHOC], O.[GHICHU]
				FROM
				    [dbo].[DMCAPHOC] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_CAPHOC] = PageIndex.[ID_CAPHOC]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DMCAPHOC]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCAPHOC_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCAPHOC_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCAPHOC_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DMCAPHOC table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCAPHOC_Insert
(

	@IdCaphoc int    OUTPUT,

	@Caphoc nvarchar (50)  ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[DMCAPHOC]
					(
					[CAPHOC]
					,[GHICHU]
					)
				VALUES
					(
					@Caphoc
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdCaphoc = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCAPHOC_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCAPHOC_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCAPHOC_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DMCAPHOC table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCAPHOC_Update
(

	@IdCaphoc int   ,

	@Caphoc nvarchar (50)  ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DMCAPHOC]
				SET
					[CAPHOC] = @Caphoc
					,[GHICHU] = @Ghichu
				WHERE
[ID_CAPHOC] = @IdCaphoc 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCAPHOC_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCAPHOC_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCAPHOC_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DMCAPHOC table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCAPHOC_Delete
(

	@IdCaphoc int   
)
AS


				DELETE FROM [dbo].[DMCAPHOC] WITH (ROWLOCK) 
				WHERE
					[ID_CAPHOC] = @IdCaphoc
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCAPHOC_GetByIdCaphoc procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCAPHOC_GetByIdCaphoc') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCAPHOC_GetByIdCaphoc
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DMCAPHOC table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCAPHOC_GetByIdCaphoc
(

	@IdCaphoc int   
)
AS


				SELECT
					[ID_CAPHOC],
					[CAPHOC],
					[GHICHU]
				FROM
					[dbo].[DMCAPHOC]
				WHERE
					[ID_CAPHOC] = @IdCaphoc
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCAPHOC_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCAPHOC_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCAPHOC_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DMCAPHOC table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCAPHOC_Find
(

	@SearchUsingOR bit   = null ,

	@IdCaphoc int   = null ,

	@Caphoc nvarchar (50)  = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_CAPHOC]
	, [CAPHOC]
	, [GHICHU]
    FROM
	[dbo].[DMCAPHOC]
    WHERE 
	 ([ID_CAPHOC] = @IdCaphoc OR @IdCaphoc is null)
	AND ([CAPHOC] = @Caphoc OR @Caphoc is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_CAPHOC]
	, [CAPHOC]
	, [GHICHU]
    FROM
	[dbo].[DMCAPHOC]
    WHERE 
	 ([ID_CAPHOC] = @IdCaphoc AND @IdCaphoc is not null)
	OR ([CAPHOC] = @Caphoc AND @Caphoc is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMDONVI_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMDONVI_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMDONVI_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DMDONVI table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMDONVI_Get_List

AS


				
				SELECT
					[ID_DONVI],
					[MA_DONVI],
					[TEN_DONVI],
					[ID_DONVICHA],
					[GHICHU]
				FROM
					[dbo].[DMDONVI]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMDONVI_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMDONVI_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMDONVI_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DMDONVI table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMDONVI_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_DONVI] int 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_DONVI])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_DONVI]'
				SET @SQL = @SQL + ' FROM [dbo].[DMDONVI]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_DONVI], O.[MA_DONVI], O.[TEN_DONVI], O.[ID_DONVICHA], O.[GHICHU]
				FROM
				    [dbo].[DMDONVI] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_DONVI] = PageIndex.[ID_DONVI]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DMDONVI]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMDONVI_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMDONVI_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMDONVI_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DMDONVI table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMDONVI_Insert
(

	@IdDonvi int    OUTPUT,

	@MaDonvi varchar (50)  ,

	@TenDonvi nvarchar (50)  ,

	@IdDonvicha int   ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[DMDONVI]
					(
					[MA_DONVI]
					,[TEN_DONVI]
					,[ID_DONVICHA]
					,[GHICHU]
					)
				VALUES
					(
					@MaDonvi
					,@TenDonvi
					,@IdDonvicha
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdDonvi = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMDONVI_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMDONVI_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMDONVI_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DMDONVI table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMDONVI_Update
(

	@IdDonvi int   ,

	@MaDonvi varchar (50)  ,

	@TenDonvi nvarchar (50)  ,

	@IdDonvicha int   ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DMDONVI]
				SET
					[MA_DONVI] = @MaDonvi
					,[TEN_DONVI] = @TenDonvi
					,[ID_DONVICHA] = @IdDonvicha
					,[GHICHU] = @Ghichu
				WHERE
[ID_DONVI] = @IdDonvi 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMDONVI_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMDONVI_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMDONVI_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DMDONVI table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMDONVI_Delete
(

	@IdDonvi int   
)
AS


				DELETE FROM [dbo].[DMDONVI] WITH (ROWLOCK) 
				WHERE
					[ID_DONVI] = @IdDonvi
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMDONVI_GetByIdDonvi procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMDONVI_GetByIdDonvi') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMDONVI_GetByIdDonvi
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DMDONVI table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMDONVI_GetByIdDonvi
(

	@IdDonvi int   
)
AS


				SELECT
					[ID_DONVI],
					[MA_DONVI],
					[TEN_DONVI],
					[ID_DONVICHA],
					[GHICHU]
				FROM
					[dbo].[DMDONVI]
				WHERE
					[ID_DONVI] = @IdDonvi
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMDONVI_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMDONVI_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMDONVI_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DMDONVI table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMDONVI_Find
(

	@SearchUsingOR bit   = null ,

	@IdDonvi int   = null ,

	@MaDonvi varchar (50)  = null ,

	@TenDonvi nvarchar (50)  = null ,

	@IdDonvicha int   = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_DONVI]
	, [MA_DONVI]
	, [TEN_DONVI]
	, [ID_DONVICHA]
	, [GHICHU]
    FROM
	[dbo].[DMDONVI]
    WHERE 
	 ([ID_DONVI] = @IdDonvi OR @IdDonvi is null)
	AND ([MA_DONVI] = @MaDonvi OR @MaDonvi is null)
	AND ([TEN_DONVI] = @TenDonvi OR @TenDonvi is null)
	AND ([ID_DONVICHA] = @IdDonvicha OR @IdDonvicha is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_DONVI]
	, [MA_DONVI]
	, [TEN_DONVI]
	, [ID_DONVICHA]
	, [GHICHU]
    FROM
	[dbo].[DMDONVI]
    WHERE 
	 ([ID_DONVI] = @IdDonvi AND @IdDonvi is not null)
	OR ([MA_DONVI] = @MaDonvi AND @MaDonvi is not null)
	OR ([TEN_DONVI] = @TenDonvi AND @TenDonvi is not null)
	OR ([ID_DONVICHA] = @IdDonvicha AND @IdDonvicha is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMDANTOC_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMDANTOC_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMDANTOC_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DMDANTOC table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMDANTOC_Get_List

AS


				
				SELECT
					[ID_DANTOC],
					[DANTOC],
					[GHICHU]
				FROM
					[dbo].[DMDANTOC]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMDANTOC_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMDANTOC_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMDANTOC_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DMDANTOC table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMDANTOC_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_DANTOC] int 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_DANTOC])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_DANTOC]'
				SET @SQL = @SQL + ' FROM [dbo].[DMDANTOC]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_DANTOC], O.[DANTOC], O.[GHICHU]
				FROM
				    [dbo].[DMDANTOC] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_DANTOC] = PageIndex.[ID_DANTOC]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DMDANTOC]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMDANTOC_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMDANTOC_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMDANTOC_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DMDANTOC table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMDANTOC_Insert
(

	@IdDantoc int    OUTPUT,

	@Dantoc nvarchar (50)  ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[DMDANTOC]
					(
					[DANTOC]
					,[GHICHU]
					)
				VALUES
					(
					@Dantoc
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdDantoc = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMDANTOC_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMDANTOC_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMDANTOC_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DMDANTOC table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMDANTOC_Update
(

	@IdDantoc int   ,

	@Dantoc nvarchar (50)  ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DMDANTOC]
				SET
					[DANTOC] = @Dantoc
					,[GHICHU] = @Ghichu
				WHERE
[ID_DANTOC] = @IdDantoc 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMDANTOC_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMDANTOC_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMDANTOC_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DMDANTOC table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMDANTOC_Delete
(

	@IdDantoc int   
)
AS


				DELETE FROM [dbo].[DMDANTOC] WITH (ROWLOCK) 
				WHERE
					[ID_DANTOC] = @IdDantoc
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMDANTOC_GetByIdDantoc procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMDANTOC_GetByIdDantoc') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMDANTOC_GetByIdDantoc
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DMDANTOC table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMDANTOC_GetByIdDantoc
(

	@IdDantoc int   
)
AS


				SELECT
					[ID_DANTOC],
					[DANTOC],
					[GHICHU]
				FROM
					[dbo].[DMDANTOC]
				WHERE
					[ID_DANTOC] = @IdDantoc
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMDANTOC_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMDANTOC_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMDANTOC_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DMDANTOC table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMDANTOC_Find
(

	@SearchUsingOR bit   = null ,

	@IdDantoc int   = null ,

	@Dantoc nvarchar (50)  = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_DANTOC]
	, [DANTOC]
	, [GHICHU]
    FROM
	[dbo].[DMDANTOC]
    WHERE 
	 ([ID_DANTOC] = @IdDantoc OR @IdDantoc is null)
	AND ([DANTOC] = @Dantoc OR @Dantoc is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_DANTOC]
	, [DANTOC]
	, [GHICHU]
    FROM
	[dbo].[DMDANTOC]
    WHERE 
	 ([ID_DANTOC] = @IdDantoc AND @IdDantoc is not null)
	OR ([DANTOC] = @Dantoc AND @Dantoc is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCHUCVU_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCHUCVU_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCHUCVU_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DMCHUCVU table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCHUCVU_Get_List

AS


				
				SELECT
					[ID_CHUCVU],
					[CHUCVU],
					[GHICHU]
				FROM
					[dbo].[DMCHUCVU]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCHUCVU_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCHUCVU_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCHUCVU_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DMCHUCVU table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCHUCVU_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_CHUCVU] int 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_CHUCVU])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_CHUCVU]'
				SET @SQL = @SQL + ' FROM [dbo].[DMCHUCVU]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_CHUCVU], O.[CHUCVU], O.[GHICHU]
				FROM
				    [dbo].[DMCHUCVU] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_CHUCVU] = PageIndex.[ID_CHUCVU]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DMCHUCVU]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCHUCVU_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCHUCVU_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCHUCVU_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DMCHUCVU table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCHUCVU_Insert
(

	@IdChucvu int    OUTPUT,

	@Chucvu nvarchar (50)  ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[DMCHUCVU]
					(
					[CHUCVU]
					,[GHICHU]
					)
				VALUES
					(
					@Chucvu
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdChucvu = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCHUCVU_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCHUCVU_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCHUCVU_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DMCHUCVU table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCHUCVU_Update
(

	@IdChucvu int   ,

	@Chucvu nvarchar (50)  ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DMCHUCVU]
				SET
					[CHUCVU] = @Chucvu
					,[GHICHU] = @Ghichu
				WHERE
[ID_CHUCVU] = @IdChucvu 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCHUCVU_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCHUCVU_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCHUCVU_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DMCHUCVU table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCHUCVU_Delete
(

	@IdChucvu int   
)
AS


				DELETE FROM [dbo].[DMCHUCVU] WITH (ROWLOCK) 
				WHERE
					[ID_CHUCVU] = @IdChucvu
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCHUCVU_GetByIdChucvu procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCHUCVU_GetByIdChucvu') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCHUCVU_GetByIdChucvu
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DMCHUCVU table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCHUCVU_GetByIdChucvu
(

	@IdChucvu int   
)
AS


				SELECT
					[ID_CHUCVU],
					[CHUCVU],
					[GHICHU]
				FROM
					[dbo].[DMCHUCVU]
				WHERE
					[ID_CHUCVU] = @IdChucvu
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCHUCVU_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCHUCVU_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCHUCVU_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DMCHUCVU table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCHUCVU_Find
(

	@SearchUsingOR bit   = null ,

	@IdChucvu int   = null ,

	@Chucvu nvarchar (50)  = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_CHUCVU]
	, [CHUCVU]
	, [GHICHU]
    FROM
	[dbo].[DMCHUCVU]
    WHERE 
	 ([ID_CHUCVU] = @IdChucvu OR @IdChucvu is null)
	AND ([CHUCVU] = @Chucvu OR @Chucvu is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_CHUCVU]
	, [CHUCVU]
	, [GHICHU]
    FROM
	[dbo].[DMCHUCVU]
    WHERE 
	 ([ID_CHUCVU] = @IdChucvu AND @IdChucvu is not null)
	OR ([CHUCVU] = @Chucvu AND @Chucvu is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCAPBAC_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCAPBAC_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCAPBAC_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DMCAPBAC table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCAPBAC_Get_List

AS


				
				SELECT
					[ID_CAPBAC],
					[CAPBAC],
					[GHICHU]
				FROM
					[dbo].[DMCAPBAC]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCAPBAC_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCAPBAC_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCAPBAC_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DMCAPBAC table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCAPBAC_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_CAPBAC] int 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_CAPBAC])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_CAPBAC]'
				SET @SQL = @SQL + ' FROM [dbo].[DMCAPBAC]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_CAPBAC], O.[CAPBAC], O.[GHICHU]
				FROM
				    [dbo].[DMCAPBAC] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_CAPBAC] = PageIndex.[ID_CAPBAC]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DMCAPBAC]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCAPBAC_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCAPBAC_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCAPBAC_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DMCAPBAC table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCAPBAC_Insert
(

	@IdCapbac int    OUTPUT,

	@Capbac nvarchar (50)  ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[DMCAPBAC]
					(
					[CAPBAC]
					,[GHICHU]
					)
				VALUES
					(
					@Capbac
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdCapbac = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCAPBAC_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCAPBAC_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCAPBAC_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DMCAPBAC table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCAPBAC_Update
(

	@IdCapbac int   ,

	@Capbac nvarchar (50)  ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DMCAPBAC]
				SET
					[CAPBAC] = @Capbac
					,[GHICHU] = @Ghichu
				WHERE
[ID_CAPBAC] = @IdCapbac 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCAPBAC_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCAPBAC_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCAPBAC_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DMCAPBAC table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCAPBAC_Delete
(

	@IdCapbac int   
)
AS


				DELETE FROM [dbo].[DMCAPBAC] WITH (ROWLOCK) 
				WHERE
					[ID_CAPBAC] = @IdCapbac
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCAPBAC_GetByIdCapbac procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCAPBAC_GetByIdCapbac') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCAPBAC_GetByIdCapbac
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DMCAPBAC table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCAPBAC_GetByIdCapbac
(

	@IdCapbac int   
)
AS


				SELECT
					[ID_CAPBAC],
					[CAPBAC],
					[GHICHU]
				FROM
					[dbo].[DMCAPBAC]
				WHERE
					[ID_CAPBAC] = @IdCapbac
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DMCAPBAC_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DMCAPBAC_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DMCAPBAC_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DMCAPBAC table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DMCAPBAC_Find
(

	@SearchUsingOR bit   = null ,

	@IdCapbac int   = null ,

	@Capbac nvarchar (50)  = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_CAPBAC]
	, [CAPBAC]
	, [GHICHU]
    FROM
	[dbo].[DMCAPBAC]
    WHERE 
	 ([ID_CAPBAC] = @IdCapbac OR @IdCapbac is null)
	AND ([CAPBAC] = @Capbac OR @Capbac is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_CAPBAC]
	, [CAPBAC]
	, [GHICHU]
    FROM
	[dbo].[DMCAPBAC]
    WHERE 
	 ([ID_CAPBAC] = @IdCapbac AND @IdCapbac is not null)
	OR ([CAPBAC] = @Capbac AND @Capbac is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QUANNHAN_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QUANNHAN_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QUANNHAN_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the QUANNHAN table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QUANNHAN_Get_List

AS


				
				SELECT
					[ID_QUANNHAN],
					[MA_QUANNHAN],
					[HOTEN_KHAISINH],
					[HOTEN_THUONGDUNG],
					[SOTHE_QUANNHAN],
					[CMT_QUANNHAN],
					[ANH_QUANNHAN],
					[NGAYSINH],
					[NGUYENQUAN],
					[SINHQUAN],
					[TRUQUAN],
					[DC_BAOTIN],
					[HOTEN_CHA],
					[HOTEN_ME],
					[HOTEN_VO(CHONG)],
					[SO_ANHCHIEM],
					[SOCON],
					[ID_CAPBAC],
					[ID_CHUCVU],
					[CNQS],
					[BACKYTHUAT],
					[TRINHDO_VANHOA],
					[SUCKHOE],
					[NGOAINGU],
					[HANG_THUONGTAT],
					[TP_GIADINH],
					[TP_BANTHAN],
					[ID_DANTOC],
					[ID_TONGIAO],
					[ID_GIOITINH],
					[NGAY_NHAPNGU],
					[NGAY_XUATNGU],
					[NGAY_TAINGU],
					[NGAY_VAODOAN],
					[NGAY_VAODANG],
					[NGAYVAODANG_CHINHTHUC],
					[NGAYCAPTHE_QN],
					[NGAYCHUYEN_QNCN],
					[NGAYCHUYEN_CNV],
					[ID_DONVI],
					[ID_LOP],
					[ID_LOAIQUANNHAN],
					[TRANGTHAI],
					[GHICHU]
				FROM
					[dbo].[QUANNHAN]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QUANNHAN_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QUANNHAN_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QUANNHAN_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the QUANNHAN table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QUANNHAN_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_QUANNHAN] int 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_QUANNHAN])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_QUANNHAN]'
				SET @SQL = @SQL + ' FROM [dbo].[QUANNHAN]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_QUANNHAN], O.[MA_QUANNHAN], O.[HOTEN_KHAISINH], O.[HOTEN_THUONGDUNG], O.[SOTHE_QUANNHAN], O.[CMT_QUANNHAN], O.[ANH_QUANNHAN], O.[NGAYSINH], O.[NGUYENQUAN], O.[SINHQUAN], O.[TRUQUAN], O.[DC_BAOTIN], O.[HOTEN_CHA], O.[HOTEN_ME], O.[HOTEN_VO(CHONG)], O.[SO_ANHCHIEM], O.[SOCON], O.[ID_CAPBAC], O.[ID_CHUCVU], O.[CNQS], O.[BACKYTHUAT], O.[TRINHDO_VANHOA], O.[SUCKHOE], O.[NGOAINGU], O.[HANG_THUONGTAT], O.[TP_GIADINH], O.[TP_BANTHAN], O.[ID_DANTOC], O.[ID_TONGIAO], O.[ID_GIOITINH], O.[NGAY_NHAPNGU], O.[NGAY_XUATNGU], O.[NGAY_TAINGU], O.[NGAY_VAODOAN], O.[NGAY_VAODANG], O.[NGAYVAODANG_CHINHTHUC], O.[NGAYCAPTHE_QN], O.[NGAYCHUYEN_QNCN], O.[NGAYCHUYEN_CNV], O.[ID_DONVI], O.[ID_LOP], O.[ID_LOAIQUANNHAN], O.[TRANGTHAI], O.[GHICHU]
				FROM
				    [dbo].[QUANNHAN] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_QUANNHAN] = PageIndex.[ID_QUANNHAN]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[QUANNHAN]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QUANNHAN_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QUANNHAN_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QUANNHAN_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the QUANNHAN table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QUANNHAN_Insert
(

	@IdQuannhan int    OUTPUT,

	@MaQuannhan nvarchar (50)  ,

	@HotenKhaisinh nvarchar (50)  ,

	@HotenThuongdung nvarchar (50)  ,

	@SotheQuannhan int   ,

	@CmtQuannhan int   ,

	@AnhQuannhan binary (5000)  ,

	@Ngaysinh smalldatetime   ,

	@Nguyenquan ntext   ,

	@Sinhquan ntext   ,

	@Truquan ntext   ,

	@DcBaotin ntext   ,

	@HotenCha nvarchar (50)  ,

	@HotenMe nvarchar (50)  ,

	@SafeNameHotenVoChong nvarchar (50)  ,

	@SoAnhchiem int   ,

	@Socon int   ,

	@IdCapbac int   ,

	@IdChucvu int   ,

	@Cnqs nvarchar (50)  ,

	@Backythuat nvarchar (50)  ,

	@TrinhdoVanhoa nvarchar (50)  ,

	@Suckhoe nvarchar (50)  ,

	@Ngoaingu nvarchar (50)  ,

	@HangThuongtat nvarchar (50)  ,

	@TpGiadinh nvarchar (50)  ,

	@TpBanthan nvarchar (50)  ,

	@IdDantoc int   ,

	@IdTongiao int   ,

	@IdGioitinh int   ,

	@NgayNhapngu smalldatetime   ,

	@NgayXuatngu smalldatetime   ,

	@NgayTaingu smalldatetime   ,

	@NgayVaodoan smalldatetime   ,

	@NgayVaodang smalldatetime   ,

	@NgayvaodangChinhthuc smalldatetime   ,

	@NgaycaptheQn smalldatetime   ,

	@NgaychuyenQncn smalldatetime   ,

	@NgaychuyenCnv smalldatetime   ,

	@IdDonvi int   ,

	@IdLop int   ,

	@IdLoaiquannhan int   ,

	@Trangthai nvarchar (50)  ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[QUANNHAN]
					(
					[MA_QUANNHAN]
					,[HOTEN_KHAISINH]
					,[HOTEN_THUONGDUNG]
					,[SOTHE_QUANNHAN]
					,[CMT_QUANNHAN]
					,[ANH_QUANNHAN]
					,[NGAYSINH]
					,[NGUYENQUAN]
					,[SINHQUAN]
					,[TRUQUAN]
					,[DC_BAOTIN]
					,[HOTEN_CHA]
					,[HOTEN_ME]
					,[HOTEN_VO(CHONG)]
					,[SO_ANHCHIEM]
					,[SOCON]
					,[ID_CAPBAC]
					,[ID_CHUCVU]
					,[CNQS]
					,[BACKYTHUAT]
					,[TRINHDO_VANHOA]
					,[SUCKHOE]
					,[NGOAINGU]
					,[HANG_THUONGTAT]
					,[TP_GIADINH]
					,[TP_BANTHAN]
					,[ID_DANTOC]
					,[ID_TONGIAO]
					,[ID_GIOITINH]
					,[NGAY_NHAPNGU]
					,[NGAY_XUATNGU]
					,[NGAY_TAINGU]
					,[NGAY_VAODOAN]
					,[NGAY_VAODANG]
					,[NGAYVAODANG_CHINHTHUC]
					,[NGAYCAPTHE_QN]
					,[NGAYCHUYEN_QNCN]
					,[NGAYCHUYEN_CNV]
					,[ID_DONVI]
					,[ID_LOP]
					,[ID_LOAIQUANNHAN]
					,[TRANGTHAI]
					,[GHICHU]
					)
				VALUES
					(
					@MaQuannhan
					,@HotenKhaisinh
					,@HotenThuongdung
					,@SotheQuannhan
					,@CmtQuannhan
					,@AnhQuannhan
					,@Ngaysinh
					,@Nguyenquan
					,@Sinhquan
					,@Truquan
					,@DcBaotin
					,@HotenCha
					,@HotenMe
					,@SafeNameHotenVoChong
					,@SoAnhchiem
					,@Socon
					,@IdCapbac
					,@IdChucvu
					,@Cnqs
					,@Backythuat
					,@TrinhdoVanhoa
					,@Suckhoe
					,@Ngoaingu
					,@HangThuongtat
					,@TpGiadinh
					,@TpBanthan
					,@IdDantoc
					,@IdTongiao
					,@IdGioitinh
					,@NgayNhapngu
					,@NgayXuatngu
					,@NgayTaingu
					,@NgayVaodoan
					,@NgayVaodang
					,@NgayvaodangChinhthuc
					,@NgaycaptheQn
					,@NgaychuyenQncn
					,@NgaychuyenCnv
					,@IdDonvi
					,@IdLop
					,@IdLoaiquannhan
					,@Trangthai
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdQuannhan = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QUANNHAN_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QUANNHAN_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QUANNHAN_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the QUANNHAN table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QUANNHAN_Update
(

	@IdQuannhan int   ,

	@MaQuannhan nvarchar (50)  ,

	@HotenKhaisinh nvarchar (50)  ,

	@HotenThuongdung nvarchar (50)  ,

	@SotheQuannhan int   ,

	@CmtQuannhan int   ,

	@AnhQuannhan binary (5000)  ,

	@Ngaysinh smalldatetime   ,

	@Nguyenquan ntext   ,

	@Sinhquan ntext   ,

	@Truquan ntext   ,

	@DcBaotin ntext   ,

	@HotenCha nvarchar (50)  ,

	@HotenMe nvarchar (50)  ,

	@SafeNameHotenVoChong nvarchar (50)  ,

	@SoAnhchiem int   ,

	@Socon int   ,

	@IdCapbac int   ,

	@IdChucvu int   ,

	@Cnqs nvarchar (50)  ,

	@Backythuat nvarchar (50)  ,

	@TrinhdoVanhoa nvarchar (50)  ,

	@Suckhoe nvarchar (50)  ,

	@Ngoaingu nvarchar (50)  ,

	@HangThuongtat nvarchar (50)  ,

	@TpGiadinh nvarchar (50)  ,

	@TpBanthan nvarchar (50)  ,

	@IdDantoc int   ,

	@IdTongiao int   ,

	@IdGioitinh int   ,

	@NgayNhapngu smalldatetime   ,

	@NgayXuatngu smalldatetime   ,

	@NgayTaingu smalldatetime   ,

	@NgayVaodoan smalldatetime   ,

	@NgayVaodang smalldatetime   ,

	@NgayvaodangChinhthuc smalldatetime   ,

	@NgaycaptheQn smalldatetime   ,

	@NgaychuyenQncn smalldatetime   ,

	@NgaychuyenCnv smalldatetime   ,

	@IdDonvi int   ,

	@IdLop int   ,

	@IdLoaiquannhan int   ,

	@Trangthai nvarchar (50)  ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[QUANNHAN]
				SET
					[MA_QUANNHAN] = @MaQuannhan
					,[HOTEN_KHAISINH] = @HotenKhaisinh
					,[HOTEN_THUONGDUNG] = @HotenThuongdung
					,[SOTHE_QUANNHAN] = @SotheQuannhan
					,[CMT_QUANNHAN] = @CmtQuannhan
					,[ANH_QUANNHAN] = @AnhQuannhan
					,[NGAYSINH] = @Ngaysinh
					,[NGUYENQUAN] = @Nguyenquan
					,[SINHQUAN] = @Sinhquan
					,[TRUQUAN] = @Truquan
					,[DC_BAOTIN] = @DcBaotin
					,[HOTEN_CHA] = @HotenCha
					,[HOTEN_ME] = @HotenMe
					,[HOTEN_VO(CHONG)] = @SafeNameHotenVoChong
					,[SO_ANHCHIEM] = @SoAnhchiem
					,[SOCON] = @Socon
					,[ID_CAPBAC] = @IdCapbac
					,[ID_CHUCVU] = @IdChucvu
					,[CNQS] = @Cnqs
					,[BACKYTHUAT] = @Backythuat
					,[TRINHDO_VANHOA] = @TrinhdoVanhoa
					,[SUCKHOE] = @Suckhoe
					,[NGOAINGU] = @Ngoaingu
					,[HANG_THUONGTAT] = @HangThuongtat
					,[TP_GIADINH] = @TpGiadinh
					,[TP_BANTHAN] = @TpBanthan
					,[ID_DANTOC] = @IdDantoc
					,[ID_TONGIAO] = @IdTongiao
					,[ID_GIOITINH] = @IdGioitinh
					,[NGAY_NHAPNGU] = @NgayNhapngu
					,[NGAY_XUATNGU] = @NgayXuatngu
					,[NGAY_TAINGU] = @NgayTaingu
					,[NGAY_VAODOAN] = @NgayVaodoan
					,[NGAY_VAODANG] = @NgayVaodang
					,[NGAYVAODANG_CHINHTHUC] = @NgayvaodangChinhthuc
					,[NGAYCAPTHE_QN] = @NgaycaptheQn
					,[NGAYCHUYEN_QNCN] = @NgaychuyenQncn
					,[NGAYCHUYEN_CNV] = @NgaychuyenCnv
					,[ID_DONVI] = @IdDonvi
					,[ID_LOP] = @IdLop
					,[ID_LOAIQUANNHAN] = @IdLoaiquannhan
					,[TRANGTHAI] = @Trangthai
					,[GHICHU] = @Ghichu
				WHERE
[ID_QUANNHAN] = @IdQuannhan 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QUANNHAN_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QUANNHAN_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QUANNHAN_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the QUANNHAN table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QUANNHAN_Delete
(

	@IdQuannhan int   
)
AS


				DELETE FROM [dbo].[QUANNHAN] WITH (ROWLOCK) 
				WHERE
					[ID_QUANNHAN] = @IdQuannhan
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QUANNHAN_GetByIdGioitinh procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QUANNHAN_GetByIdGioitinh') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QUANNHAN_GetByIdGioitinh
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the QUANNHAN table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QUANNHAN_GetByIdGioitinh
(

	@IdGioitinh int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_QUANNHAN],
					[MA_QUANNHAN],
					[HOTEN_KHAISINH],
					[HOTEN_THUONGDUNG],
					[SOTHE_QUANNHAN],
					[CMT_QUANNHAN],
					[ANH_QUANNHAN],
					[NGAYSINH],
					[NGUYENQUAN],
					[SINHQUAN],
					[TRUQUAN],
					[DC_BAOTIN],
					[HOTEN_CHA],
					[HOTEN_ME],
					[HOTEN_VO(CHONG)],
					[SO_ANHCHIEM],
					[SOCON],
					[ID_CAPBAC],
					[ID_CHUCVU],
					[CNQS],
					[BACKYTHUAT],
					[TRINHDO_VANHOA],
					[SUCKHOE],
					[NGOAINGU],
					[HANG_THUONGTAT],
					[TP_GIADINH],
					[TP_BANTHAN],
					[ID_DANTOC],
					[ID_TONGIAO],
					[ID_GIOITINH],
					[NGAY_NHAPNGU],
					[NGAY_XUATNGU],
					[NGAY_TAINGU],
					[NGAY_VAODOAN],
					[NGAY_VAODANG],
					[NGAYVAODANG_CHINHTHUC],
					[NGAYCAPTHE_QN],
					[NGAYCHUYEN_QNCN],
					[NGAYCHUYEN_CNV],
					[ID_DONVI],
					[ID_LOP],
					[ID_LOAIQUANNHAN],
					[TRANGTHAI],
					[GHICHU]
				FROM
					[dbo].[QUANNHAN]
				WHERE
					[ID_GIOITINH] = @IdGioitinh
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QUANNHAN_GetByIdLoaiquannhan procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QUANNHAN_GetByIdLoaiquannhan') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QUANNHAN_GetByIdLoaiquannhan
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the QUANNHAN table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QUANNHAN_GetByIdLoaiquannhan
(

	@IdLoaiquannhan int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_QUANNHAN],
					[MA_QUANNHAN],
					[HOTEN_KHAISINH],
					[HOTEN_THUONGDUNG],
					[SOTHE_QUANNHAN],
					[CMT_QUANNHAN],
					[ANH_QUANNHAN],
					[NGAYSINH],
					[NGUYENQUAN],
					[SINHQUAN],
					[TRUQUAN],
					[DC_BAOTIN],
					[HOTEN_CHA],
					[HOTEN_ME],
					[HOTEN_VO(CHONG)],
					[SO_ANHCHIEM],
					[SOCON],
					[ID_CAPBAC],
					[ID_CHUCVU],
					[CNQS],
					[BACKYTHUAT],
					[TRINHDO_VANHOA],
					[SUCKHOE],
					[NGOAINGU],
					[HANG_THUONGTAT],
					[TP_GIADINH],
					[TP_BANTHAN],
					[ID_DANTOC],
					[ID_TONGIAO],
					[ID_GIOITINH],
					[NGAY_NHAPNGU],
					[NGAY_XUATNGU],
					[NGAY_TAINGU],
					[NGAY_VAODOAN],
					[NGAY_VAODANG],
					[NGAYVAODANG_CHINHTHUC],
					[NGAYCAPTHE_QN],
					[NGAYCHUYEN_QNCN],
					[NGAYCHUYEN_CNV],
					[ID_DONVI],
					[ID_LOP],
					[ID_LOAIQUANNHAN],
					[TRANGTHAI],
					[GHICHU]
				FROM
					[dbo].[QUANNHAN]
				WHERE
					[ID_LOAIQUANNHAN] = @IdLoaiquannhan
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QUANNHAN_GetByIdDantoc procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QUANNHAN_GetByIdDantoc') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QUANNHAN_GetByIdDantoc
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the QUANNHAN table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QUANNHAN_GetByIdDantoc
(

	@IdDantoc int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_QUANNHAN],
					[MA_QUANNHAN],
					[HOTEN_KHAISINH],
					[HOTEN_THUONGDUNG],
					[SOTHE_QUANNHAN],
					[CMT_QUANNHAN],
					[ANH_QUANNHAN],
					[NGAYSINH],
					[NGUYENQUAN],
					[SINHQUAN],
					[TRUQUAN],
					[DC_BAOTIN],
					[HOTEN_CHA],
					[HOTEN_ME],
					[HOTEN_VO(CHONG)],
					[SO_ANHCHIEM],
					[SOCON],
					[ID_CAPBAC],
					[ID_CHUCVU],
					[CNQS],
					[BACKYTHUAT],
					[TRINHDO_VANHOA],
					[SUCKHOE],
					[NGOAINGU],
					[HANG_THUONGTAT],
					[TP_GIADINH],
					[TP_BANTHAN],
					[ID_DANTOC],
					[ID_TONGIAO],
					[ID_GIOITINH],
					[NGAY_NHAPNGU],
					[NGAY_XUATNGU],
					[NGAY_TAINGU],
					[NGAY_VAODOAN],
					[NGAY_VAODANG],
					[NGAYVAODANG_CHINHTHUC],
					[NGAYCAPTHE_QN],
					[NGAYCHUYEN_QNCN],
					[NGAYCHUYEN_CNV],
					[ID_DONVI],
					[ID_LOP],
					[ID_LOAIQUANNHAN],
					[TRANGTHAI],
					[GHICHU]
				FROM
					[dbo].[QUANNHAN]
				WHERE
					[ID_DANTOC] = @IdDantoc
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QUANNHAN_GetByIdTongiao procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QUANNHAN_GetByIdTongiao') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QUANNHAN_GetByIdTongiao
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the QUANNHAN table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QUANNHAN_GetByIdTongiao
(

	@IdTongiao int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_QUANNHAN],
					[MA_QUANNHAN],
					[HOTEN_KHAISINH],
					[HOTEN_THUONGDUNG],
					[SOTHE_QUANNHAN],
					[CMT_QUANNHAN],
					[ANH_QUANNHAN],
					[NGAYSINH],
					[NGUYENQUAN],
					[SINHQUAN],
					[TRUQUAN],
					[DC_BAOTIN],
					[HOTEN_CHA],
					[HOTEN_ME],
					[HOTEN_VO(CHONG)],
					[SO_ANHCHIEM],
					[SOCON],
					[ID_CAPBAC],
					[ID_CHUCVU],
					[CNQS],
					[BACKYTHUAT],
					[TRINHDO_VANHOA],
					[SUCKHOE],
					[NGOAINGU],
					[HANG_THUONGTAT],
					[TP_GIADINH],
					[TP_BANTHAN],
					[ID_DANTOC],
					[ID_TONGIAO],
					[ID_GIOITINH],
					[NGAY_NHAPNGU],
					[NGAY_XUATNGU],
					[NGAY_TAINGU],
					[NGAY_VAODOAN],
					[NGAY_VAODANG],
					[NGAYVAODANG_CHINHTHUC],
					[NGAYCAPTHE_QN],
					[NGAYCHUYEN_QNCN],
					[NGAYCHUYEN_CNV],
					[ID_DONVI],
					[ID_LOP],
					[ID_LOAIQUANNHAN],
					[TRANGTHAI],
					[GHICHU]
				FROM
					[dbo].[QUANNHAN]
				WHERE
					[ID_TONGIAO] = @IdTongiao
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QUANNHAN_GetByIdDonvi procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QUANNHAN_GetByIdDonvi') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QUANNHAN_GetByIdDonvi
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the QUANNHAN table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QUANNHAN_GetByIdDonvi
(

	@IdDonvi int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_QUANNHAN],
					[MA_QUANNHAN],
					[HOTEN_KHAISINH],
					[HOTEN_THUONGDUNG],
					[SOTHE_QUANNHAN],
					[CMT_QUANNHAN],
					[ANH_QUANNHAN],
					[NGAYSINH],
					[NGUYENQUAN],
					[SINHQUAN],
					[TRUQUAN],
					[DC_BAOTIN],
					[HOTEN_CHA],
					[HOTEN_ME],
					[HOTEN_VO(CHONG)],
					[SO_ANHCHIEM],
					[SOCON],
					[ID_CAPBAC],
					[ID_CHUCVU],
					[CNQS],
					[BACKYTHUAT],
					[TRINHDO_VANHOA],
					[SUCKHOE],
					[NGOAINGU],
					[HANG_THUONGTAT],
					[TP_GIADINH],
					[TP_BANTHAN],
					[ID_DANTOC],
					[ID_TONGIAO],
					[ID_GIOITINH],
					[NGAY_NHAPNGU],
					[NGAY_XUATNGU],
					[NGAY_TAINGU],
					[NGAY_VAODOAN],
					[NGAY_VAODANG],
					[NGAYVAODANG_CHINHTHUC],
					[NGAYCAPTHE_QN],
					[NGAYCHUYEN_QNCN],
					[NGAYCHUYEN_CNV],
					[ID_DONVI],
					[ID_LOP],
					[ID_LOAIQUANNHAN],
					[TRANGTHAI],
					[GHICHU]
				FROM
					[dbo].[QUANNHAN]
				WHERE
					[ID_DONVI] = @IdDonvi
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QUANNHAN_GetByIdCapbac procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QUANNHAN_GetByIdCapbac') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QUANNHAN_GetByIdCapbac
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the QUANNHAN table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QUANNHAN_GetByIdCapbac
(

	@IdCapbac int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_QUANNHAN],
					[MA_QUANNHAN],
					[HOTEN_KHAISINH],
					[HOTEN_THUONGDUNG],
					[SOTHE_QUANNHAN],
					[CMT_QUANNHAN],
					[ANH_QUANNHAN],
					[NGAYSINH],
					[NGUYENQUAN],
					[SINHQUAN],
					[TRUQUAN],
					[DC_BAOTIN],
					[HOTEN_CHA],
					[HOTEN_ME],
					[HOTEN_VO(CHONG)],
					[SO_ANHCHIEM],
					[SOCON],
					[ID_CAPBAC],
					[ID_CHUCVU],
					[CNQS],
					[BACKYTHUAT],
					[TRINHDO_VANHOA],
					[SUCKHOE],
					[NGOAINGU],
					[HANG_THUONGTAT],
					[TP_GIADINH],
					[TP_BANTHAN],
					[ID_DANTOC],
					[ID_TONGIAO],
					[ID_GIOITINH],
					[NGAY_NHAPNGU],
					[NGAY_XUATNGU],
					[NGAY_TAINGU],
					[NGAY_VAODOAN],
					[NGAY_VAODANG],
					[NGAYVAODANG_CHINHTHUC],
					[NGAYCAPTHE_QN],
					[NGAYCHUYEN_QNCN],
					[NGAYCHUYEN_CNV],
					[ID_DONVI],
					[ID_LOP],
					[ID_LOAIQUANNHAN],
					[TRANGTHAI],
					[GHICHU]
				FROM
					[dbo].[QUANNHAN]
				WHERE
					[ID_CAPBAC] = @IdCapbac
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QUANNHAN_GetByIdChucvu procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QUANNHAN_GetByIdChucvu') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QUANNHAN_GetByIdChucvu
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the QUANNHAN table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QUANNHAN_GetByIdChucvu
(

	@IdChucvu int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_QUANNHAN],
					[MA_QUANNHAN],
					[HOTEN_KHAISINH],
					[HOTEN_THUONGDUNG],
					[SOTHE_QUANNHAN],
					[CMT_QUANNHAN],
					[ANH_QUANNHAN],
					[NGAYSINH],
					[NGUYENQUAN],
					[SINHQUAN],
					[TRUQUAN],
					[DC_BAOTIN],
					[HOTEN_CHA],
					[HOTEN_ME],
					[HOTEN_VO(CHONG)],
					[SO_ANHCHIEM],
					[SOCON],
					[ID_CAPBAC],
					[ID_CHUCVU],
					[CNQS],
					[BACKYTHUAT],
					[TRINHDO_VANHOA],
					[SUCKHOE],
					[NGOAINGU],
					[HANG_THUONGTAT],
					[TP_GIADINH],
					[TP_BANTHAN],
					[ID_DANTOC],
					[ID_TONGIAO],
					[ID_GIOITINH],
					[NGAY_NHAPNGU],
					[NGAY_XUATNGU],
					[NGAY_TAINGU],
					[NGAY_VAODOAN],
					[NGAY_VAODANG],
					[NGAYVAODANG_CHINHTHUC],
					[NGAYCAPTHE_QN],
					[NGAYCHUYEN_QNCN],
					[NGAYCHUYEN_CNV],
					[ID_DONVI],
					[ID_LOP],
					[ID_LOAIQUANNHAN],
					[TRANGTHAI],
					[GHICHU]
				FROM
					[dbo].[QUANNHAN]
				WHERE
					[ID_CHUCVU] = @IdChucvu
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QUANNHAN_GetByIdLop procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QUANNHAN_GetByIdLop') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QUANNHAN_GetByIdLop
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the QUANNHAN table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QUANNHAN_GetByIdLop
(

	@IdLop int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_QUANNHAN],
					[MA_QUANNHAN],
					[HOTEN_KHAISINH],
					[HOTEN_THUONGDUNG],
					[SOTHE_QUANNHAN],
					[CMT_QUANNHAN],
					[ANH_QUANNHAN],
					[NGAYSINH],
					[NGUYENQUAN],
					[SINHQUAN],
					[TRUQUAN],
					[DC_BAOTIN],
					[HOTEN_CHA],
					[HOTEN_ME],
					[HOTEN_VO(CHONG)],
					[SO_ANHCHIEM],
					[SOCON],
					[ID_CAPBAC],
					[ID_CHUCVU],
					[CNQS],
					[BACKYTHUAT],
					[TRINHDO_VANHOA],
					[SUCKHOE],
					[NGOAINGU],
					[HANG_THUONGTAT],
					[TP_GIADINH],
					[TP_BANTHAN],
					[ID_DANTOC],
					[ID_TONGIAO],
					[ID_GIOITINH],
					[NGAY_NHAPNGU],
					[NGAY_XUATNGU],
					[NGAY_TAINGU],
					[NGAY_VAODOAN],
					[NGAY_VAODANG],
					[NGAYVAODANG_CHINHTHUC],
					[NGAYCAPTHE_QN],
					[NGAYCHUYEN_QNCN],
					[NGAYCHUYEN_CNV],
					[ID_DONVI],
					[ID_LOP],
					[ID_LOAIQUANNHAN],
					[TRANGTHAI],
					[GHICHU]
				FROM
					[dbo].[QUANNHAN]
				WHERE
					[ID_LOP] = @IdLop
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QUANNHAN_GetByIdQuannhan procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QUANNHAN_GetByIdQuannhan') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QUANNHAN_GetByIdQuannhan
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the QUANNHAN table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QUANNHAN_GetByIdQuannhan
(

	@IdQuannhan int   
)
AS


				SELECT
					[ID_QUANNHAN],
					[MA_QUANNHAN],
					[HOTEN_KHAISINH],
					[HOTEN_THUONGDUNG],
					[SOTHE_QUANNHAN],
					[CMT_QUANNHAN],
					[ANH_QUANNHAN],
					[NGAYSINH],
					[NGUYENQUAN],
					[SINHQUAN],
					[TRUQUAN],
					[DC_BAOTIN],
					[HOTEN_CHA],
					[HOTEN_ME],
					[HOTEN_VO(CHONG)],
					[SO_ANHCHIEM],
					[SOCON],
					[ID_CAPBAC],
					[ID_CHUCVU],
					[CNQS],
					[BACKYTHUAT],
					[TRINHDO_VANHOA],
					[SUCKHOE],
					[NGOAINGU],
					[HANG_THUONGTAT],
					[TP_GIADINH],
					[TP_BANTHAN],
					[ID_DANTOC],
					[ID_TONGIAO],
					[ID_GIOITINH],
					[NGAY_NHAPNGU],
					[NGAY_XUATNGU],
					[NGAY_TAINGU],
					[NGAY_VAODOAN],
					[NGAY_VAODANG],
					[NGAYVAODANG_CHINHTHUC],
					[NGAYCAPTHE_QN],
					[NGAYCHUYEN_QNCN],
					[NGAYCHUYEN_CNV],
					[ID_DONVI],
					[ID_LOP],
					[ID_LOAIQUANNHAN],
					[TRANGTHAI],
					[GHICHU]
				FROM
					[dbo].[QUANNHAN]
				WHERE
					[ID_QUANNHAN] = @IdQuannhan
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.QUANNHAN_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.QUANNHAN_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.QUANNHAN_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the QUANNHAN table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.QUANNHAN_Find
(

	@SearchUsingOR bit   = null ,

	@IdQuannhan int   = null ,

	@MaQuannhan nvarchar (50)  = null ,

	@HotenKhaisinh nvarchar (50)  = null ,

	@HotenThuongdung nvarchar (50)  = null ,

	@SotheQuannhan int   = null ,

	@CmtQuannhan int   = null ,

	@AnhQuannhan binary (5000)  = null ,

	@Ngaysinh smalldatetime   = null ,

	@Nguyenquan ntext   = null ,

	@Sinhquan ntext   = null ,

	@Truquan ntext   = null ,

	@DcBaotin ntext   = null ,

	@HotenCha nvarchar (50)  = null ,

	@HotenMe nvarchar (50)  = null ,

	@SafeNameHotenVoChong nvarchar (50)  = null ,

	@SoAnhchiem int   = null ,

	@Socon int   = null ,

	@IdCapbac int   = null ,

	@IdChucvu int   = null ,

	@Cnqs nvarchar (50)  = null ,

	@Backythuat nvarchar (50)  = null ,

	@TrinhdoVanhoa nvarchar (50)  = null ,

	@Suckhoe nvarchar (50)  = null ,

	@Ngoaingu nvarchar (50)  = null ,

	@HangThuongtat nvarchar (50)  = null ,

	@TpGiadinh nvarchar (50)  = null ,

	@TpBanthan nvarchar (50)  = null ,

	@IdDantoc int   = null ,

	@IdTongiao int   = null ,

	@IdGioitinh int   = null ,

	@NgayNhapngu smalldatetime   = null ,

	@NgayXuatngu smalldatetime   = null ,

	@NgayTaingu smalldatetime   = null ,

	@NgayVaodoan smalldatetime   = null ,

	@NgayVaodang smalldatetime   = null ,

	@NgayvaodangChinhthuc smalldatetime   = null ,

	@NgaycaptheQn smalldatetime   = null ,

	@NgaychuyenQncn smalldatetime   = null ,

	@NgaychuyenCnv smalldatetime   = null ,

	@IdDonvi int   = null ,

	@IdLop int   = null ,

	@IdLoaiquannhan int   = null ,

	@Trangthai nvarchar (50)  = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_QUANNHAN]
	, [MA_QUANNHAN]
	, [HOTEN_KHAISINH]
	, [HOTEN_THUONGDUNG]
	, [SOTHE_QUANNHAN]
	, [CMT_QUANNHAN]
	, [ANH_QUANNHAN]
	, [NGAYSINH]
	, [NGUYENQUAN]
	, [SINHQUAN]
	, [TRUQUAN]
	, [DC_BAOTIN]
	, [HOTEN_CHA]
	, [HOTEN_ME]
	, [HOTEN_VO(CHONG)]
	, [SO_ANHCHIEM]
	, [SOCON]
	, [ID_CAPBAC]
	, [ID_CHUCVU]
	, [CNQS]
	, [BACKYTHUAT]
	, [TRINHDO_VANHOA]
	, [SUCKHOE]
	, [NGOAINGU]
	, [HANG_THUONGTAT]
	, [TP_GIADINH]
	, [TP_BANTHAN]
	, [ID_DANTOC]
	, [ID_TONGIAO]
	, [ID_GIOITINH]
	, [NGAY_NHAPNGU]
	, [NGAY_XUATNGU]
	, [NGAY_TAINGU]
	, [NGAY_VAODOAN]
	, [NGAY_VAODANG]
	, [NGAYVAODANG_CHINHTHUC]
	, [NGAYCAPTHE_QN]
	, [NGAYCHUYEN_QNCN]
	, [NGAYCHUYEN_CNV]
	, [ID_DONVI]
	, [ID_LOP]
	, [ID_LOAIQUANNHAN]
	, [TRANGTHAI]
	, [GHICHU]
    FROM
	[dbo].[QUANNHAN]
    WHERE 
	 ([ID_QUANNHAN] = @IdQuannhan OR @IdQuannhan is null)
	AND ([MA_QUANNHAN] = @MaQuannhan OR @MaQuannhan is null)
	AND ([HOTEN_KHAISINH] = @HotenKhaisinh OR @HotenKhaisinh is null)
	AND ([HOTEN_THUONGDUNG] = @HotenThuongdung OR @HotenThuongdung is null)
	AND ([SOTHE_QUANNHAN] = @SotheQuannhan OR @SotheQuannhan is null)
	AND ([CMT_QUANNHAN] = @CmtQuannhan OR @CmtQuannhan is null)
	AND ([NGAYSINH] = @Ngaysinh OR @Ngaysinh is null)
	AND ([HOTEN_CHA] = @HotenCha OR @HotenCha is null)
	AND ([HOTEN_ME] = @HotenMe OR @HotenMe is null)
	AND ([HOTEN_VO(CHONG)] = @SafeNameHotenVoChong OR @SafeNameHotenVoChong is null)
	AND ([SO_ANHCHIEM] = @SoAnhchiem OR @SoAnhchiem is null)
	AND ([SOCON] = @Socon OR @Socon is null)
	AND ([ID_CAPBAC] = @IdCapbac OR @IdCapbac is null)
	AND ([ID_CHUCVU] = @IdChucvu OR @IdChucvu is null)
	AND ([CNQS] = @Cnqs OR @Cnqs is null)
	AND ([BACKYTHUAT] = @Backythuat OR @Backythuat is null)
	AND ([TRINHDO_VANHOA] = @TrinhdoVanhoa OR @TrinhdoVanhoa is null)
	AND ([SUCKHOE] = @Suckhoe OR @Suckhoe is null)
	AND ([NGOAINGU] = @Ngoaingu OR @Ngoaingu is null)
	AND ([HANG_THUONGTAT] = @HangThuongtat OR @HangThuongtat is null)
	AND ([TP_GIADINH] = @TpGiadinh OR @TpGiadinh is null)
	AND ([TP_BANTHAN] = @TpBanthan OR @TpBanthan is null)
	AND ([ID_DANTOC] = @IdDantoc OR @IdDantoc is null)
	AND ([ID_TONGIAO] = @IdTongiao OR @IdTongiao is null)
	AND ([ID_GIOITINH] = @IdGioitinh OR @IdGioitinh is null)
	AND ([NGAY_NHAPNGU] = @NgayNhapngu OR @NgayNhapngu is null)
	AND ([NGAY_XUATNGU] = @NgayXuatngu OR @NgayXuatngu is null)
	AND ([NGAY_TAINGU] = @NgayTaingu OR @NgayTaingu is null)
	AND ([NGAY_VAODOAN] = @NgayVaodoan OR @NgayVaodoan is null)
	AND ([NGAY_VAODANG] = @NgayVaodang OR @NgayVaodang is null)
	AND ([NGAYVAODANG_CHINHTHUC] = @NgayvaodangChinhthuc OR @NgayvaodangChinhthuc is null)
	AND ([NGAYCAPTHE_QN] = @NgaycaptheQn OR @NgaycaptheQn is null)
	AND ([NGAYCHUYEN_QNCN] = @NgaychuyenQncn OR @NgaychuyenQncn is null)
	AND ([NGAYCHUYEN_CNV] = @NgaychuyenCnv OR @NgaychuyenCnv is null)
	AND ([ID_DONVI] = @IdDonvi OR @IdDonvi is null)
	AND ([ID_LOP] = @IdLop OR @IdLop is null)
	AND ([ID_LOAIQUANNHAN] = @IdLoaiquannhan OR @IdLoaiquannhan is null)
	AND ([TRANGTHAI] = @Trangthai OR @Trangthai is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_QUANNHAN]
	, [MA_QUANNHAN]
	, [HOTEN_KHAISINH]
	, [HOTEN_THUONGDUNG]
	, [SOTHE_QUANNHAN]
	, [CMT_QUANNHAN]
	, [ANH_QUANNHAN]
	, [NGAYSINH]
	, [NGUYENQUAN]
	, [SINHQUAN]
	, [TRUQUAN]
	, [DC_BAOTIN]
	, [HOTEN_CHA]
	, [HOTEN_ME]
	, [HOTEN_VO(CHONG)]
	, [SO_ANHCHIEM]
	, [SOCON]
	, [ID_CAPBAC]
	, [ID_CHUCVU]
	, [CNQS]
	, [BACKYTHUAT]
	, [TRINHDO_VANHOA]
	, [SUCKHOE]
	, [NGOAINGU]
	, [HANG_THUONGTAT]
	, [TP_GIADINH]
	, [TP_BANTHAN]
	, [ID_DANTOC]
	, [ID_TONGIAO]
	, [ID_GIOITINH]
	, [NGAY_NHAPNGU]
	, [NGAY_XUATNGU]
	, [NGAY_TAINGU]
	, [NGAY_VAODOAN]
	, [NGAY_VAODANG]
	, [NGAYVAODANG_CHINHTHUC]
	, [NGAYCAPTHE_QN]
	, [NGAYCHUYEN_QNCN]
	, [NGAYCHUYEN_CNV]
	, [ID_DONVI]
	, [ID_LOP]
	, [ID_LOAIQUANNHAN]
	, [TRANGTHAI]
	, [GHICHU]
    FROM
	[dbo].[QUANNHAN]
    WHERE 
	 ([ID_QUANNHAN] = @IdQuannhan AND @IdQuannhan is not null)
	OR ([MA_QUANNHAN] = @MaQuannhan AND @MaQuannhan is not null)
	OR ([HOTEN_KHAISINH] = @HotenKhaisinh AND @HotenKhaisinh is not null)
	OR ([HOTEN_THUONGDUNG] = @HotenThuongdung AND @HotenThuongdung is not null)
	OR ([SOTHE_QUANNHAN] = @SotheQuannhan AND @SotheQuannhan is not null)
	OR ([CMT_QUANNHAN] = @CmtQuannhan AND @CmtQuannhan is not null)
	OR ([NGAYSINH] = @Ngaysinh AND @Ngaysinh is not null)
	OR ([HOTEN_CHA] = @HotenCha AND @HotenCha is not null)
	OR ([HOTEN_ME] = @HotenMe AND @HotenMe is not null)
	OR ([HOTEN_VO(CHONG)] = @SafeNameHotenVoChong AND @SafeNameHotenVoChong is not null)
	OR ([SO_ANHCHIEM] = @SoAnhchiem AND @SoAnhchiem is not null)
	OR ([SOCON] = @Socon AND @Socon is not null)
	OR ([ID_CAPBAC] = @IdCapbac AND @IdCapbac is not null)
	OR ([ID_CHUCVU] = @IdChucvu AND @IdChucvu is not null)
	OR ([CNQS] = @Cnqs AND @Cnqs is not null)
	OR ([BACKYTHUAT] = @Backythuat AND @Backythuat is not null)
	OR ([TRINHDO_VANHOA] = @TrinhdoVanhoa AND @TrinhdoVanhoa is not null)
	OR ([SUCKHOE] = @Suckhoe AND @Suckhoe is not null)
	OR ([NGOAINGU] = @Ngoaingu AND @Ngoaingu is not null)
	OR ([HANG_THUONGTAT] = @HangThuongtat AND @HangThuongtat is not null)
	OR ([TP_GIADINH] = @TpGiadinh AND @TpGiadinh is not null)
	OR ([TP_BANTHAN] = @TpBanthan AND @TpBanthan is not null)
	OR ([ID_DANTOC] = @IdDantoc AND @IdDantoc is not null)
	OR ([ID_TONGIAO] = @IdTongiao AND @IdTongiao is not null)
	OR ([ID_GIOITINH] = @IdGioitinh AND @IdGioitinh is not null)
	OR ([NGAY_NHAPNGU] = @NgayNhapngu AND @NgayNhapngu is not null)
	OR ([NGAY_XUATNGU] = @NgayXuatngu AND @NgayXuatngu is not null)
	OR ([NGAY_TAINGU] = @NgayTaingu AND @NgayTaingu is not null)
	OR ([NGAY_VAODOAN] = @NgayVaodoan AND @NgayVaodoan is not null)
	OR ([NGAY_VAODANG] = @NgayVaodang AND @NgayVaodang is not null)
	OR ([NGAYVAODANG_CHINHTHUC] = @NgayvaodangChinhthuc AND @NgayvaodangChinhthuc is not null)
	OR ([NGAYCAPTHE_QN] = @NgaycaptheQn AND @NgaycaptheQn is not null)
	OR ([NGAYCHUYEN_QNCN] = @NgaychuyenQncn AND @NgaychuyenQncn is not null)
	OR ([NGAYCHUYEN_CNV] = @NgaychuyenCnv AND @NgaychuyenCnv is not null)
	OR ([ID_DONVI] = @IdDonvi AND @IdDonvi is not null)
	OR ([ID_LOP] = @IdLop AND @IdLop is not null)
	OR ([ID_LOAIQUANNHAN] = @IdLoaiquannhan AND @IdLoaiquannhan is not null)
	OR ([TRANGTHAI] = @Trangthai AND @Trangthai is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKHENTHUONG_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKHENTHUONG_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKHENTHUONG_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the LSKHENTHUONG table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKHENTHUONG_Get_List

AS


				
				SELECT
					[ID_LICHSUKHENTHUONG],
					[ID_QUANNHAN],
					[ID_HINHTHUC_KHENTHUONG],
					[CAP_KHENTHUONG],
					[NGAYNHAN],
					[GHICHU]
				FROM
					[dbo].[LSKHENTHUONG]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKHENTHUONG_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKHENTHUONG_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKHENTHUONG_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the LSKHENTHUONG table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKHENTHUONG_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID_LICHSUKHENTHUONG] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID_LICHSUKHENTHUONG])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [ID_LICHSUKHENTHUONG]'
				SET @SQL = @SQL + ' FROM [dbo].[LSKHENTHUONG]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[ID_LICHSUKHENTHUONG], O.[ID_QUANNHAN], O.[ID_HINHTHUC_KHENTHUONG], O.[CAP_KHENTHUONG], O.[NGAYNHAN], O.[GHICHU]
				FROM
				    [dbo].[LSKHENTHUONG] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID_LICHSUKHENTHUONG] = PageIndex.[ID_LICHSUKHENTHUONG]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[LSKHENTHUONG]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKHENTHUONG_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKHENTHUONG_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKHENTHUONG_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the LSKHENTHUONG table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKHENTHUONG_Insert
(

	@IdLichsukhenthuong bigint    OUTPUT,

	@IdQuannhan int   ,

	@IdHinhthucKhenthuong int   ,

	@CapKhenthuong nvarchar (50)  ,

	@Ngaynhan smalldatetime   ,

	@Ghichu ntext   
)
AS


					
				INSERT INTO [dbo].[LSKHENTHUONG]
					(
					[ID_QUANNHAN]
					,[ID_HINHTHUC_KHENTHUONG]
					,[CAP_KHENTHUONG]
					,[NGAYNHAN]
					,[GHICHU]
					)
				VALUES
					(
					@IdQuannhan
					,@IdHinhthucKhenthuong
					,@CapKhenthuong
					,@Ngaynhan
					,@Ghichu
					)
				
				-- Get the identity value
				SET @IdLichsukhenthuong = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKHENTHUONG_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKHENTHUONG_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKHENTHUONG_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the LSKHENTHUONG table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKHENTHUONG_Update
(

	@IdLichsukhenthuong bigint   ,

	@IdQuannhan int   ,

	@IdHinhthucKhenthuong int   ,

	@CapKhenthuong nvarchar (50)  ,

	@Ngaynhan smalldatetime   ,

	@Ghichu ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[LSKHENTHUONG]
				SET
					[ID_QUANNHAN] = @IdQuannhan
					,[ID_HINHTHUC_KHENTHUONG] = @IdHinhthucKhenthuong
					,[CAP_KHENTHUONG] = @CapKhenthuong
					,[NGAYNHAN] = @Ngaynhan
					,[GHICHU] = @Ghichu
				WHERE
[ID_LICHSUKHENTHUONG] = @IdLichsukhenthuong 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKHENTHUONG_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKHENTHUONG_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKHENTHUONG_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the LSKHENTHUONG table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKHENTHUONG_Delete
(

	@IdLichsukhenthuong bigint   
)
AS


				DELETE FROM [dbo].[LSKHENTHUONG] WITH (ROWLOCK) 
				WHERE
					[ID_LICHSUKHENTHUONG] = @IdLichsukhenthuong
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKHENTHUONG_GetByIdQuannhan procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKHENTHUONG_GetByIdQuannhan') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKHENTHUONG_GetByIdQuannhan
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LSKHENTHUONG table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKHENTHUONG_GetByIdQuannhan
(

	@IdQuannhan int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_LICHSUKHENTHUONG],
					[ID_QUANNHAN],
					[ID_HINHTHUC_KHENTHUONG],
					[CAP_KHENTHUONG],
					[NGAYNHAN],
					[GHICHU]
				FROM
					[dbo].[LSKHENTHUONG]
				WHERE
					[ID_QUANNHAN] = @IdQuannhan
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKHENTHUONG_GetByIdHinhthucKhenthuong procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKHENTHUONG_GetByIdHinhthucKhenthuong') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKHENTHUONG_GetByIdHinhthucKhenthuong
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LSKHENTHUONG table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKHENTHUONG_GetByIdHinhthucKhenthuong
(

	@IdHinhthucKhenthuong int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID_LICHSUKHENTHUONG],
					[ID_QUANNHAN],
					[ID_HINHTHUC_KHENTHUONG],
					[CAP_KHENTHUONG],
					[NGAYNHAN],
					[GHICHU]
				FROM
					[dbo].[LSKHENTHUONG]
				WHERE
					[ID_HINHTHUC_KHENTHUONG] = @IdHinhthucKhenthuong
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKHENTHUONG_GetByIdLichsukhenthuong procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKHENTHUONG_GetByIdLichsukhenthuong') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKHENTHUONG_GetByIdLichsukhenthuong
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the LSKHENTHUONG table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKHENTHUONG_GetByIdLichsukhenthuong
(

	@IdLichsukhenthuong bigint   
)
AS


				SELECT
					[ID_LICHSUKHENTHUONG],
					[ID_QUANNHAN],
					[ID_HINHTHUC_KHENTHUONG],
					[CAP_KHENTHUONG],
					[NGAYNHAN],
					[GHICHU]
				FROM
					[dbo].[LSKHENTHUONG]
				WHERE
					[ID_LICHSUKHENTHUONG] = @IdLichsukhenthuong
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.LSKHENTHUONG_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.LSKHENTHUONG_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.LSKHENTHUONG_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the LSKHENTHUONG table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.LSKHENTHUONG_Find
(

	@SearchUsingOR bit   = null ,

	@IdLichsukhenthuong bigint   = null ,

	@IdQuannhan int   = null ,

	@IdHinhthucKhenthuong int   = null ,

	@CapKhenthuong nvarchar (50)  = null ,

	@Ngaynhan smalldatetime   = null ,

	@Ghichu ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID_LICHSUKHENTHUONG]
	, [ID_QUANNHAN]
	, [ID_HINHTHUC_KHENTHUONG]
	, [CAP_KHENTHUONG]
	, [NGAYNHAN]
	, [GHICHU]
    FROM
	[dbo].[LSKHENTHUONG]
    WHERE 
	 ([ID_LICHSUKHENTHUONG] = @IdLichsukhenthuong OR @IdLichsukhenthuong is null)
	AND ([ID_QUANNHAN] = @IdQuannhan OR @IdQuannhan is null)
	AND ([ID_HINHTHUC_KHENTHUONG] = @IdHinhthucKhenthuong OR @IdHinhthucKhenthuong is null)
	AND ([CAP_KHENTHUONG] = @CapKhenthuong OR @CapKhenthuong is null)
	AND ([NGAYNHAN] = @Ngaynhan OR @Ngaynhan is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID_LICHSUKHENTHUONG]
	, [ID_QUANNHAN]
	, [ID_HINHTHUC_KHENTHUONG]
	, [CAP_KHENTHUONG]
	, [NGAYNHAN]
	, [GHICHU]
    FROM
	[dbo].[LSKHENTHUONG]
    WHERE 
	 ([ID_LICHSUKHENTHUONG] = @IdLichsukhenthuong AND @IdLichsukhenthuong is not null)
	OR ([ID_QUANNHAN] = @IdQuannhan AND @IdQuannhan is not null)
	OR ([ID_HINHTHUC_KHENTHUONG] = @IdHinhthucKhenthuong AND @IdHinhthucKhenthuong is not null)
	OR ([CAP_KHENTHUONG] = @CapKhenthuong AND @CapKhenthuong is not null)
	OR ([NGAYNHAN] = @Ngaynhan AND @Ngaynhan is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

