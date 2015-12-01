#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using QUANLYQN.Entities;
using QUANLYQN.Data;

#endregion

namespace QUANLYQN.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="LstruonglopProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LstruonglopProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.Lstruonglop, QUANLYQN.Entities.LstruonglopKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.LstruonglopKey key)
		{
			return Delete(transactionManager, key.IdLichsutruonglop);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idLichsutruonglop">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idLichsutruonglop)
		{
			return Delete(null, idLichsutruonglop);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLichsutruonglop">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idLichsutruonglop);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_DMTRUONG1 key.
		///		FK_LSTRUONGLOP_DMTRUONG1 Description: 
		/// </summary>
		/// <param name="idTruong"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		public QUANLYQN.Entities.TList<Lstruonglop> GetByIdTruong(System.Int32 idTruong)
		{
			int count = -1;
			return GetByIdTruong(idTruong, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_DMTRUONG1 key.
		///		FK_LSTRUONGLOP_DMTRUONG1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTruong"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Lstruonglop> GetByIdTruong(TransactionManager transactionManager, System.Int32 idTruong)
		{
			int count = -1;
			return GetByIdTruong(transactionManager, idTruong, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_DMTRUONG1 key.
		///		FK_LSTRUONGLOP_DMTRUONG1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTruong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		public QUANLYQN.Entities.TList<Lstruonglop> GetByIdTruong(TransactionManager transactionManager, System.Int32 idTruong, int start, int pageLength)
		{
			int count = -1;
			return GetByIdTruong(transactionManager, idTruong, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_DMTRUONG1 key.
		///		fkLstruonglopDmtruong1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idTruong"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		public QUANLYQN.Entities.TList<Lstruonglop> GetByIdTruong(System.Int32 idTruong, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdTruong(null, idTruong, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_DMTRUONG1 key.
		///		fkLstruonglopDmtruong1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idTruong"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		public QUANLYQN.Entities.TList<Lstruonglop> GetByIdTruong(System.Int32 idTruong, int start, int pageLength,out int count)
		{
			return GetByIdTruong(null, idTruong, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_DMTRUONG1 key.
		///		FK_LSTRUONGLOP_DMTRUONG1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTruong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		public abstract QUANLYQN.Entities.TList<Lstruonglop> GetByIdTruong(TransactionManager transactionManager, System.Int32 idTruong, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_DMCAPHOC1 key.
		///		FK_LSTRUONGLOP_DMCAPHOC1 Description: 
		/// </summary>
		/// <param name="idCaphoc"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		public QUANLYQN.Entities.TList<Lstruonglop> GetByIdCaphoc(System.Int32 idCaphoc)
		{
			int count = -1;
			return GetByIdCaphoc(idCaphoc, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_DMCAPHOC1 key.
		///		FK_LSTRUONGLOP_DMCAPHOC1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCaphoc"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Lstruonglop> GetByIdCaphoc(TransactionManager transactionManager, System.Int32 idCaphoc)
		{
			int count = -1;
			return GetByIdCaphoc(transactionManager, idCaphoc, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_DMCAPHOC1 key.
		///		FK_LSTRUONGLOP_DMCAPHOC1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCaphoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		public QUANLYQN.Entities.TList<Lstruonglop> GetByIdCaphoc(TransactionManager transactionManager, System.Int32 idCaphoc, int start, int pageLength)
		{
			int count = -1;
			return GetByIdCaphoc(transactionManager, idCaphoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_DMCAPHOC1 key.
		///		fkLstruonglopDmcaphoc1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idCaphoc"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		public QUANLYQN.Entities.TList<Lstruonglop> GetByIdCaphoc(System.Int32 idCaphoc, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdCaphoc(null, idCaphoc, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_DMCAPHOC1 key.
		///		fkLstruonglopDmcaphoc1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idCaphoc"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		public QUANLYQN.Entities.TList<Lstruonglop> GetByIdCaphoc(System.Int32 idCaphoc, int start, int pageLength,out int count)
		{
			return GetByIdCaphoc(null, idCaphoc, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_DMCAPHOC1 key.
		///		FK_LSTRUONGLOP_DMCAPHOC1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCaphoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		public abstract QUANLYQN.Entities.TList<Lstruonglop> GetByIdCaphoc(TransactionManager transactionManager, System.Int32 idCaphoc, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_QUANNHAN1 key.
		///		FK_LSTRUONGLOP_QUANNHAN1 Description: 
		/// </summary>
		/// <param name="idQuannhan"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		public QUANLYQN.Entities.TList<Lstruonglop> GetByIdQuannhan(System.Int32 idQuannhan)
		{
			int count = -1;
			return GetByIdQuannhan(idQuannhan, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_QUANNHAN1 key.
		///		FK_LSTRUONGLOP_QUANNHAN1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuannhan"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Lstruonglop> GetByIdQuannhan(TransactionManager transactionManager, System.Int32 idQuannhan)
		{
			int count = -1;
			return GetByIdQuannhan(transactionManager, idQuannhan, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_QUANNHAN1 key.
		///		FK_LSTRUONGLOP_QUANNHAN1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuannhan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		public QUANLYQN.Entities.TList<Lstruonglop> GetByIdQuannhan(TransactionManager transactionManager, System.Int32 idQuannhan, int start, int pageLength)
		{
			int count = -1;
			return GetByIdQuannhan(transactionManager, idQuannhan, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_QUANNHAN1 key.
		///		fkLstruonglopQuannhan1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idQuannhan"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		public QUANLYQN.Entities.TList<Lstruonglop> GetByIdQuannhan(System.Int32 idQuannhan, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdQuannhan(null, idQuannhan, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_QUANNHAN1 key.
		///		fkLstruonglopQuannhan1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idQuannhan"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		public QUANLYQN.Entities.TList<Lstruonglop> GetByIdQuannhan(System.Int32 idQuannhan, int start, int pageLength,out int count)
		{
			return GetByIdQuannhan(null, idQuannhan, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LSTRUONGLOP_QUANNHAN1 key.
		///		FK_LSTRUONGLOP_QUANNHAN1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuannhan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Lstruonglop objects.</returns>
		public abstract QUANLYQN.Entities.TList<Lstruonglop> GetByIdQuannhan(TransactionManager transactionManager, System.Int32 idQuannhan, int start, int pageLength, out int count);
		
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override QUANLYQN.Entities.Lstruonglop Get(TransactionManager transactionManager, QUANLYQN.Entities.LstruonglopKey key, int start, int pageLength)
		{
			return GetByIdLichsutruonglop(transactionManager, key.IdLichsutruonglop, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_LSTRUONGLOP index.
		/// </summary>
		/// <param name="idLichsutruonglop"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lstruonglop"/> class.</returns>
		public QUANLYQN.Entities.Lstruonglop GetByIdLichsutruonglop(System.Int64 idLichsutruonglop)
		{
			int count = -1;
			return GetByIdLichsutruonglop(null,idLichsutruonglop, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSTRUONGLOP index.
		/// </summary>
		/// <param name="idLichsutruonglop"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lstruonglop"/> class.</returns>
		public QUANLYQN.Entities.Lstruonglop GetByIdLichsutruonglop(System.Int64 idLichsutruonglop, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLichsutruonglop(null, idLichsutruonglop, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSTRUONGLOP index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLichsutruonglop"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lstruonglop"/> class.</returns>
		public QUANLYQN.Entities.Lstruonglop GetByIdLichsutruonglop(TransactionManager transactionManager, System.Int64 idLichsutruonglop)
		{
			int count = -1;
			return GetByIdLichsutruonglop(transactionManager, idLichsutruonglop, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSTRUONGLOP index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLichsutruonglop"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lstruonglop"/> class.</returns>
		public QUANLYQN.Entities.Lstruonglop GetByIdLichsutruonglop(TransactionManager transactionManager, System.Int64 idLichsutruonglop, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLichsutruonglop(transactionManager, idLichsutruonglop, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSTRUONGLOP index.
		/// </summary>
		/// <param name="idLichsutruonglop"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lstruonglop"/> class.</returns>
		public QUANLYQN.Entities.Lstruonglop GetByIdLichsutruonglop(System.Int64 idLichsutruonglop, int start, int pageLength, out int count)
		{
			return GetByIdLichsutruonglop(null, idLichsutruonglop, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_LSTRUONGLOP index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLichsutruonglop"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Lstruonglop"/> class.</returns>
		public abstract QUANLYQN.Entities.Lstruonglop GetByIdLichsutruonglop(TransactionManager transactionManager, System.Int64 idLichsutruonglop, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;Lstruonglop&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;Lstruonglop&gt;"/></returns>
		public static QUANLYQN.Entities.TList<Lstruonglop> Fill(IDataReader reader, QUANLYQN.Entities.TList<Lstruonglop> rows, int start, int pageLength)
		{
		// advance to the starting row
		for (int i = 0; i < start; i++)
		{
			if (!reader.Read())
			return rows; // not enough rows, just return
		}
		for (int i = 0; i < pageLength; i++)
		{
			if (!reader.Read())
			break; // we are done
			string key = null;
			
			QUANLYQN.Entities.Lstruonglop c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Lstruonglop")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.LstruonglopColumn.IdLichsutruonglop - 1))?(long)0:(System.Int64)reader[((int)QUANLYQN.Entities.LstruonglopColumn.IdLichsutruonglop - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Lstruonglop>(
			key.ToString(), // EntityTrackingKey
			"Lstruonglop",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.Lstruonglop();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdLichsutruonglop = (System.Int64)reader["ID_LICHSUTRUONGLOP"];
			c.IdQuannhan = (System.Int32)reader["ID_QUANNHAN"];
			c.IdTruong = (System.Int32)reader["ID_TRUONG"];
			c.IdCaphoc = (System.Int32)reader["ID_CAPHOC"];
			c.Nganhhoc = reader.IsDBNull(reader.GetOrdinal("NGANHHOC")) ? null : (System.String)reader["NGANHHOC"];
			c.ThoigianBatdau = reader.IsDBNull(reader.GetOrdinal("THOIGIAN_BATDAU")) ? null : (System.DateTime?)reader["THOIGIAN_BATDAU"];
			c.ThoigianKetthuc = reader.IsDBNull(reader.GetOrdinal("THOIGIAN_KETTHUC")) ? null : (System.DateTime?)reader["THOIGIAN_KETTHUC"];
			c.Ghichu = reader.IsDBNull(reader.GetOrdinal("GHICHU")) ? null : (System.String)reader["GHICHU"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.Lstruonglop"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Lstruonglop"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.Lstruonglop entity)
		{
			if (!reader.Read()) return;
			
			entity.IdLichsutruonglop = (System.Int64)reader["ID_LICHSUTRUONGLOP"];
			entity.IdQuannhan = (System.Int32)reader["ID_QUANNHAN"];
			entity.IdTruong = (System.Int32)reader["ID_TRUONG"];
			entity.IdCaphoc = (System.Int32)reader["ID_CAPHOC"];
			entity.Nganhhoc = reader.IsDBNull(reader.GetOrdinal("NGANHHOC")) ? null : (System.String)reader["NGANHHOC"];
			entity.ThoigianBatdau = reader.IsDBNull(reader.GetOrdinal("THOIGIAN_BATDAU")) ? null : (System.DateTime?)reader["THOIGIAN_BATDAU"];
			entity.ThoigianKetthuc = reader.IsDBNull(reader.GetOrdinal("THOIGIAN_KETTHUC")) ? null : (System.DateTime?)reader["THOIGIAN_KETTHUC"];
			entity.Ghichu = reader.IsDBNull(reader.GetOrdinal("GHICHU")) ? null : (System.String)reader["GHICHU"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.Lstruonglop"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Lstruonglop"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.Lstruonglop entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdLichsutruonglop = (System.Int64)dataRow["ID_LICHSUTRUONGLOP"];
			entity.IdQuannhan = (System.Int32)dataRow["ID_QUANNHAN"];
			entity.IdTruong = (System.Int32)dataRow["ID_TRUONG"];
			entity.IdCaphoc = (System.Int32)dataRow["ID_CAPHOC"];
			entity.Nganhhoc = Convert.IsDBNull(dataRow["NGANHHOC"]) ? null : (System.String)dataRow["NGANHHOC"];
			entity.ThoigianBatdau = Convert.IsDBNull(dataRow["THOIGIAN_BATDAU"]) ? null : (System.DateTime?)dataRow["THOIGIAN_BATDAU"];
			entity.ThoigianKetthuc = Convert.IsDBNull(dataRow["THOIGIAN_KETTHUC"]) ? null : (System.DateTime?)dataRow["THOIGIAN_KETTHUC"];
			entity.Ghichu = Convert.IsDBNull(dataRow["GHICHU"]) ? null : (System.String)dataRow["GHICHU"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Lstruonglop"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Lstruonglop Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.Lstruonglop entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region IdTruongSource	
			if (CanDeepLoad(entity, "Dmtruong|IdTruongSource", deepLoadType, innerList) 
				&& entity.IdTruongSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdTruong;
				Dmtruong tmpEntity = EntityManager.LocateEntity<Dmtruong>(EntityLocator.ConstructKeyFromPkItems(typeof(Dmtruong), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdTruongSource = tmpEntity;
				else
					entity.IdTruongSource = DataRepository.DmtruongProvider.GetByIdTruong(transactionManager, entity.IdTruong);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdTruongSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdTruongSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DmtruongProvider.DeepLoad(transactionManager, entity.IdTruongSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdTruongSource

			#region IdCaphocSource	
			if (CanDeepLoad(entity, "Dmcaphoc|IdCaphocSource", deepLoadType, innerList) 
				&& entity.IdCaphocSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdCaphoc;
				Dmcaphoc tmpEntity = EntityManager.LocateEntity<Dmcaphoc>(EntityLocator.ConstructKeyFromPkItems(typeof(Dmcaphoc), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdCaphocSource = tmpEntity;
				else
					entity.IdCaphocSource = DataRepository.DmcaphocProvider.GetByIdCaphoc(transactionManager, entity.IdCaphoc);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdCaphocSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdCaphocSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DmcaphocProvider.DeepLoad(transactionManager, entity.IdCaphocSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdCaphocSource

			#region IdQuannhanSource	
			if (CanDeepLoad(entity, "Quannhan|IdQuannhanSource", deepLoadType, innerList) 
				&& entity.IdQuannhanSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdQuannhan;
				Quannhan tmpEntity = EntityManager.LocateEntity<Quannhan>(EntityLocator.ConstructKeyFromPkItems(typeof(Quannhan), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdQuannhanSource = tmpEntity;
				else
					entity.IdQuannhanSource = DataRepository.QuannhanProvider.GetByIdQuannhan(transactionManager, entity.IdQuannhan);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdQuannhanSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdQuannhanSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.QuannhanProvider.DeepLoad(transactionManager, entity.IdQuannhanSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdQuannhanSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the QUANLYQN.Entities.Lstruonglop object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.Lstruonglop instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Lstruonglop Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.Lstruonglop entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IdTruongSource
			if (CanDeepSave(entity, "Dmtruong|IdTruongSource", deepSaveType, innerList) 
				&& entity.IdTruongSource != null)
			{
				DataRepository.DmtruongProvider.Save(transactionManager, entity.IdTruongSource);
				entity.IdTruong = entity.IdTruongSource.IdTruong;
			}
			#endregion 
			
			#region IdCaphocSource
			if (CanDeepSave(entity, "Dmcaphoc|IdCaphocSource", deepSaveType, innerList) 
				&& entity.IdCaphocSource != null)
			{
				DataRepository.DmcaphocProvider.Save(transactionManager, entity.IdCaphocSource);
				entity.IdCaphoc = entity.IdCaphocSource.IdCaphoc;
			}
			#endregion 
			
			#region IdQuannhanSource
			if (CanDeepSave(entity, "Quannhan|IdQuannhanSource", deepSaveType, innerList) 
				&& entity.IdQuannhanSource != null)
			{
				DataRepository.QuannhanProvider.Save(transactionManager, entity.IdQuannhanSource);
				entity.IdQuannhan = entity.IdQuannhanSource.IdQuannhan;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region LstruonglopChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.Lstruonglop</c>
	///</summary>
	public enum LstruonglopChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Dmtruong</c> at IdTruongSource
		///</summary>
		[ChildEntityType(typeof(Dmtruong))]
		Dmtruong,
			
		///<summary>
		/// Composite Property for <c>Dmcaphoc</c> at IdCaphocSource
		///</summary>
		[ChildEntityType(typeof(Dmcaphoc))]
		Dmcaphoc,
			
		///<summary>
		/// Composite Property for <c>Quannhan</c> at IdQuannhanSource
		///</summary>
		[ChildEntityType(typeof(Quannhan))]
		Quannhan,
		}
	
	#endregion LstruonglopChildEntityTypes
	
	#region LstruonglopFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LstruonglopColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lstruonglop"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LstruonglopFilterBuilder : SqlFilterBuilder<LstruonglopColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LstruonglopFilterBuilder class.
		/// </summary>
		public LstruonglopFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LstruonglopFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LstruonglopFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LstruonglopFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LstruonglopFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LstruonglopFilterBuilder
	
	#region LstruonglopParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LstruonglopColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Lstruonglop"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LstruonglopParameterBuilder : ParameterizedSqlFilterBuilder<LstruonglopColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LstruonglopParameterBuilder class.
		/// </summary>
		public LstruonglopParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LstruonglopParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LstruonglopParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LstruonglopParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LstruonglopParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LstruonglopParameterBuilder
} // end namespace
