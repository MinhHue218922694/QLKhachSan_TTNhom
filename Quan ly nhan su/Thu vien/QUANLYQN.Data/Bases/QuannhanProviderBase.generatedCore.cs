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
	/// This class is the base class for any <see cref="QuannhanProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class QuannhanProviderBaseCore : EntityProviderBase<QUANLYQN.Entities.Quannhan, QUANLYQN.Entities.QuannhanKey>
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
		public override bool Delete(TransactionManager transactionManager, QUANLYQN.Entities.QuannhanKey key)
		{
			return Delete(transactionManager, key.IdQuannhan);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idQuannhan">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 idQuannhan)
		{
			return Delete(null, idQuannhan);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuannhan">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 idQuannhan);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMGIOITINH key.
		///		FK_QUANNHAN_DMGIOITINH Description: 
		/// </summary>
		/// <param name="idGioitinh"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdGioitinh(System.Int32 idGioitinh)
		{
			int count = -1;
			return GetByIdGioitinh(idGioitinh, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMGIOITINH key.
		///		FK_QUANNHAN_DMGIOITINH Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGioitinh"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdGioitinh(TransactionManager transactionManager, System.Int32 idGioitinh)
		{
			int count = -1;
			return GetByIdGioitinh(transactionManager, idGioitinh, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMGIOITINH key.
		///		FK_QUANNHAN_DMGIOITINH Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGioitinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdGioitinh(TransactionManager transactionManager, System.Int32 idGioitinh, int start, int pageLength)
		{
			int count = -1;
			return GetByIdGioitinh(transactionManager, idGioitinh, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMGIOITINH key.
		///		fkQuannhanDmgioitinh Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idGioitinh"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdGioitinh(System.Int32 idGioitinh, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdGioitinh(null, idGioitinh, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMGIOITINH key.
		///		fkQuannhanDmgioitinh Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idGioitinh"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdGioitinh(System.Int32 idGioitinh, int start, int pageLength,out int count)
		{
			return GetByIdGioitinh(null, idGioitinh, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMGIOITINH key.
		///		FK_QUANNHAN_DMGIOITINH Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGioitinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public abstract QUANLYQN.Entities.TList<Quannhan> GetByIdGioitinh(TransactionManager transactionManager, System.Int32 idGioitinh, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMLOAIQUANNHAN key.
		///		FK_QUANNHAN_DMLOAIQUANNHAN Description: 
		/// </summary>
		/// <param name="idLoaiquannhan"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdLoaiquannhan(System.Int32 idLoaiquannhan)
		{
			int count = -1;
			return GetByIdLoaiquannhan(idLoaiquannhan, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMLOAIQUANNHAN key.
		///		FK_QUANNHAN_DMLOAIQUANNHAN Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLoaiquannhan"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdLoaiquannhan(TransactionManager transactionManager, System.Int32 idLoaiquannhan)
		{
			int count = -1;
			return GetByIdLoaiquannhan(transactionManager, idLoaiquannhan, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMLOAIQUANNHAN key.
		///		FK_QUANNHAN_DMLOAIQUANNHAN Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLoaiquannhan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdLoaiquannhan(TransactionManager transactionManager, System.Int32 idLoaiquannhan, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLoaiquannhan(transactionManager, idLoaiquannhan, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMLOAIQUANNHAN key.
		///		fkQuannhanDmloaiquannhan Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idLoaiquannhan"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdLoaiquannhan(System.Int32 idLoaiquannhan, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdLoaiquannhan(null, idLoaiquannhan, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMLOAIQUANNHAN key.
		///		fkQuannhanDmloaiquannhan Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idLoaiquannhan"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdLoaiquannhan(System.Int32 idLoaiquannhan, int start, int pageLength,out int count)
		{
			return GetByIdLoaiquannhan(null, idLoaiquannhan, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMLOAIQUANNHAN key.
		///		FK_QUANNHAN_DMLOAIQUANNHAN Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLoaiquannhan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public abstract QUANLYQN.Entities.TList<Quannhan> GetByIdLoaiquannhan(TransactionManager transactionManager, System.Int32 idLoaiquannhan, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMDANTOC key.
		///		FK_QUANNHAN_DMDANTOC Description: 
		/// </summary>
		/// <param name="idDantoc"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdDantoc(System.Int32 idDantoc)
		{
			int count = -1;
			return GetByIdDantoc(idDantoc, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMDANTOC key.
		///		FK_QUANNHAN_DMDANTOC Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDantoc"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdDantoc(TransactionManager transactionManager, System.Int32 idDantoc)
		{
			int count = -1;
			return GetByIdDantoc(transactionManager, idDantoc, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMDANTOC key.
		///		FK_QUANNHAN_DMDANTOC Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDantoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdDantoc(TransactionManager transactionManager, System.Int32 idDantoc, int start, int pageLength)
		{
			int count = -1;
			return GetByIdDantoc(transactionManager, idDantoc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMDANTOC key.
		///		fkQuannhanDmdantoc Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idDantoc"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdDantoc(System.Int32 idDantoc, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdDantoc(null, idDantoc, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMDANTOC key.
		///		fkQuannhanDmdantoc Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idDantoc"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdDantoc(System.Int32 idDantoc, int start, int pageLength,out int count)
		{
			return GetByIdDantoc(null, idDantoc, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMDANTOC key.
		///		FK_QUANNHAN_DMDANTOC Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDantoc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public abstract QUANLYQN.Entities.TList<Quannhan> GetByIdDantoc(TransactionManager transactionManager, System.Int32 idDantoc, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMTONGIAO key.
		///		FK_QUANNHAN_DMTONGIAO Description: 
		/// </summary>
		/// <param name="idTongiao"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdTongiao(System.Int32 idTongiao)
		{
			int count = -1;
			return GetByIdTongiao(idTongiao, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMTONGIAO key.
		///		FK_QUANNHAN_DMTONGIAO Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTongiao"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdTongiao(TransactionManager transactionManager, System.Int32 idTongiao)
		{
			int count = -1;
			return GetByIdTongiao(transactionManager, idTongiao, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMTONGIAO key.
		///		FK_QUANNHAN_DMTONGIAO Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTongiao"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdTongiao(TransactionManager transactionManager, System.Int32 idTongiao, int start, int pageLength)
		{
			int count = -1;
			return GetByIdTongiao(transactionManager, idTongiao, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMTONGIAO key.
		///		fkQuannhanDmtongiao Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idTongiao"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdTongiao(System.Int32 idTongiao, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdTongiao(null, idTongiao, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMTONGIAO key.
		///		fkQuannhanDmtongiao Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idTongiao"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdTongiao(System.Int32 idTongiao, int start, int pageLength,out int count)
		{
			return GetByIdTongiao(null, idTongiao, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMTONGIAO key.
		///		FK_QUANNHAN_DMTONGIAO Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTongiao"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public abstract QUANLYQN.Entities.TList<Quannhan> GetByIdTongiao(TransactionManager transactionManager, System.Int32 idTongiao, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMDONVI key.
		///		FK_QUANNHAN_DMDONVI Description: 
		/// </summary>
		/// <param name="idDonvi"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdDonvi(System.Int32 idDonvi)
		{
			int count = -1;
			return GetByIdDonvi(idDonvi, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMDONVI key.
		///		FK_QUANNHAN_DMDONVI Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDonvi"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdDonvi(TransactionManager transactionManager, System.Int32 idDonvi)
		{
			int count = -1;
			return GetByIdDonvi(transactionManager, idDonvi, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMDONVI key.
		///		FK_QUANNHAN_DMDONVI Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDonvi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdDonvi(TransactionManager transactionManager, System.Int32 idDonvi, int start, int pageLength)
		{
			int count = -1;
			return GetByIdDonvi(transactionManager, idDonvi, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMDONVI key.
		///		fkQuannhanDmdonvi Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idDonvi"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdDonvi(System.Int32 idDonvi, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdDonvi(null, idDonvi, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMDONVI key.
		///		fkQuannhanDmdonvi Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idDonvi"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdDonvi(System.Int32 idDonvi, int start, int pageLength,out int count)
		{
			return GetByIdDonvi(null, idDonvi, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMDONVI key.
		///		FK_QUANNHAN_DMDONVI Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDonvi"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public abstract QUANLYQN.Entities.TList<Quannhan> GetByIdDonvi(TransactionManager transactionManager, System.Int32 idDonvi, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMCAPBAC key.
		///		FK_QUANNHAN_DMCAPBAC Description: 
		/// </summary>
		/// <param name="idCapbac"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdCapbac(System.Int32 idCapbac)
		{
			int count = -1;
			return GetByIdCapbac(idCapbac, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMCAPBAC key.
		///		FK_QUANNHAN_DMCAPBAC Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCapbac"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdCapbac(TransactionManager transactionManager, System.Int32 idCapbac)
		{
			int count = -1;
			return GetByIdCapbac(transactionManager, idCapbac, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMCAPBAC key.
		///		FK_QUANNHAN_DMCAPBAC Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCapbac"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdCapbac(TransactionManager transactionManager, System.Int32 idCapbac, int start, int pageLength)
		{
			int count = -1;
			return GetByIdCapbac(transactionManager, idCapbac, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMCAPBAC key.
		///		fkQuannhanDmcapbac Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idCapbac"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdCapbac(System.Int32 idCapbac, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdCapbac(null, idCapbac, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMCAPBAC key.
		///		fkQuannhanDmcapbac Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idCapbac"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdCapbac(System.Int32 idCapbac, int start, int pageLength,out int count)
		{
			return GetByIdCapbac(null, idCapbac, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMCAPBAC key.
		///		FK_QUANNHAN_DMCAPBAC Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCapbac"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public abstract QUANLYQN.Entities.TList<Quannhan> GetByIdCapbac(TransactionManager transactionManager, System.Int32 idCapbac, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMCHUCVU key.
		///		FK_QUANNHAN_DMCHUCVU Description: 
		/// </summary>
		/// <param name="idChucvu"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdChucvu(System.Int32 idChucvu)
		{
			int count = -1;
			return GetByIdChucvu(idChucvu, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMCHUCVU key.
		///		FK_QUANNHAN_DMCHUCVU Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idChucvu"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdChucvu(TransactionManager transactionManager, System.Int32 idChucvu)
		{
			int count = -1;
			return GetByIdChucvu(transactionManager, idChucvu, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMCHUCVU key.
		///		FK_QUANNHAN_DMCHUCVU Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idChucvu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdChucvu(TransactionManager transactionManager, System.Int32 idChucvu, int start, int pageLength)
		{
			int count = -1;
			return GetByIdChucvu(transactionManager, idChucvu, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMCHUCVU key.
		///		fkQuannhanDmchucvu Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idChucvu"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdChucvu(System.Int32 idChucvu, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdChucvu(null, idChucvu, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMCHUCVU key.
		///		fkQuannhanDmchucvu Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idChucvu"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdChucvu(System.Int32 idChucvu, int start, int pageLength,out int count)
		{
			return GetByIdChucvu(null, idChucvu, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMCHUCVU key.
		///		FK_QUANNHAN_DMCHUCVU Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idChucvu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public abstract QUANLYQN.Entities.TList<Quannhan> GetByIdChucvu(TransactionManager transactionManager, System.Int32 idChucvu, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMLOP key.
		///		FK_QUANNHAN_DMLOP Description: 
		/// </summary>
		/// <param name="idLop"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdLop(System.Int32 idLop)
		{
			int count = -1;
			return GetByIdLop(idLop, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMLOP key.
		///		FK_QUANNHAN_DMLOP Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLop"></param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		/// <remarks></remarks>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdLop(TransactionManager transactionManager, System.Int32 idLop)
		{
			int count = -1;
			return GetByIdLop(transactionManager, idLop, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMLOP key.
		///		FK_QUANNHAN_DMLOP Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLop"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdLop(TransactionManager transactionManager, System.Int32 idLop, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLop(transactionManager, idLop, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMLOP key.
		///		fkQuannhanDmlop Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idLop"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdLop(System.Int32 idLop, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdLop(null, idLop, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMLOP key.
		///		fkQuannhanDmlop Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idLop"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public QUANLYQN.Entities.TList<Quannhan> GetByIdLop(System.Int32 idLop, int start, int pageLength,out int count)
		{
			return GetByIdLop(null, idLop, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QUANNHAN_DMLOP key.
		///		FK_QUANNHAN_DMLOP Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLop"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of QUANLYQN.Entities.Quannhan objects.</returns>
		public abstract QUANLYQN.Entities.TList<Quannhan> GetByIdLop(TransactionManager transactionManager, System.Int32 idLop, int start, int pageLength, out int count);
		
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
		public override QUANLYQN.Entities.Quannhan Get(TransactionManager transactionManager, QUANLYQN.Entities.QuannhanKey key, int start, int pageLength)
		{
			return GetByIdQuannhan(transactionManager, key.IdQuannhan, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_QUANNHAN index.
		/// </summary>
		/// <param name="idQuannhan"></param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Quannhan"/> class.</returns>
		public QUANLYQN.Entities.Quannhan GetByIdQuannhan(System.Int32 idQuannhan)
		{
			int count = -1;
			return GetByIdQuannhan(null,idQuannhan, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QUANNHAN index.
		/// </summary>
		/// <param name="idQuannhan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Quannhan"/> class.</returns>
		public QUANLYQN.Entities.Quannhan GetByIdQuannhan(System.Int32 idQuannhan, int start, int pageLength)
		{
			int count = -1;
			return GetByIdQuannhan(null, idQuannhan, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QUANNHAN index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuannhan"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Quannhan"/> class.</returns>
		public QUANLYQN.Entities.Quannhan GetByIdQuannhan(TransactionManager transactionManager, System.Int32 idQuannhan)
		{
			int count = -1;
			return GetByIdQuannhan(transactionManager, idQuannhan, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QUANNHAN index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuannhan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Quannhan"/> class.</returns>
		public QUANLYQN.Entities.Quannhan GetByIdQuannhan(TransactionManager transactionManager, System.Int32 idQuannhan, int start, int pageLength)
		{
			int count = -1;
			return GetByIdQuannhan(transactionManager, idQuannhan, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QUANNHAN index.
		/// </summary>
		/// <param name="idQuannhan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Quannhan"/> class.</returns>
		public QUANLYQN.Entities.Quannhan GetByIdQuannhan(System.Int32 idQuannhan, int start, int pageLength, out int count)
		{
			return GetByIdQuannhan(null, idQuannhan, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QUANNHAN index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuannhan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="QUANLYQN.Entities.Quannhan"/> class.</returns>
		public abstract QUANLYQN.Entities.Quannhan GetByIdQuannhan(TransactionManager transactionManager, System.Int32 idQuannhan, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a QUANLYQN.Entities.TList&lt;Quannhan&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="QUANLYQN.Entities.TList&lt;Quannhan&gt;"/></returns>
		public static QUANLYQN.Entities.TList<Quannhan> Fill(IDataReader reader, QUANLYQN.Entities.TList<Quannhan> rows, int start, int pageLength)
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
			
			QUANLYQN.Entities.Quannhan c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Quannhan")
			.Append("|").Append((reader.IsDBNull(((int)QUANLYQN.Entities.QuannhanColumn.IdQuannhan - 1))?(int)0:(System.Int32)reader[((int)QUANLYQN.Entities.QuannhanColumn.IdQuannhan - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Quannhan>(
			key.ToString(), // EntityTrackingKey
			"Quannhan",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new QUANLYQN.Entities.Quannhan();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdQuannhan = (System.Int32)reader["ID_QUANNHAN"];
			c.MaQuannhan = (System.String)reader["MA_QUANNHAN"];
			c.HotenKhaisinh = (System.String)reader["HOTEN_KHAISINH"];
			c.HotenThuongdung = (System.String)reader["HOTEN_THUONGDUNG"];
			c.SotheQuannhan = (System.Int32)reader["SOTHE_QUANNHAN"];
			c.CmtQuannhan = (System.Int32)reader["CMT_QUANNHAN"];
			c.AnhQuannhan = reader.IsDBNull(reader.GetOrdinal("ANH_QUANNHAN")) ? null : (System.Byte[])reader["ANH_QUANNHAN"];
			c.Ngaysinh = (System.DateTime)reader["NGAYSINH"];
			c.Nguyenquan = (System.String)reader["NGUYENQUAN"];
			c.Sinhquan = (System.String)reader["SINHQUAN"];
			c.Truquan = reader.IsDBNull(reader.GetOrdinal("TRUQUAN")) ? null : (System.String)reader["TRUQUAN"];
			c.DcBaotin = reader.IsDBNull(reader.GetOrdinal("DC_BAOTIN")) ? null : (System.String)reader["DC_BAOTIN"];
			c.HotenCha = reader.IsDBNull(reader.GetOrdinal("HOTEN_CHA")) ? null : (System.String)reader["HOTEN_CHA"];
			c.HotenMe = reader.IsDBNull(reader.GetOrdinal("HOTEN_ME")) ? null : (System.String)reader["HOTEN_ME"];
			c.SafeNameHotenVoChong = reader.IsDBNull(reader.GetOrdinal("HOTEN_VO(CHONG)")) ? null : (System.String)reader["HOTEN_VO(CHONG)"];
			c.SoAnhchiem = (System.Int32)reader["SO_ANHCHIEM"];
			c.Socon = (System.Int32)reader["SOCON"];
			c.IdCapbac = (System.Int32)reader["ID_CAPBAC"];
			c.IdChucvu = (System.Int32)reader["ID_CHUCVU"];
			c.Cnqs = reader.IsDBNull(reader.GetOrdinal("CNQS")) ? null : (System.String)reader["CNQS"];
			c.Backythuat = reader.IsDBNull(reader.GetOrdinal("BACKYTHUAT")) ? null : (System.String)reader["BACKYTHUAT"];
			c.TrinhdoVanhoa = (System.String)reader["TRINHDO_VANHOA"];
			c.Suckhoe = reader.IsDBNull(reader.GetOrdinal("SUCKHOE")) ? null : (System.String)reader["SUCKHOE"];
			c.Ngoaingu = reader.IsDBNull(reader.GetOrdinal("NGOAINGU")) ? null : (System.String)reader["NGOAINGU"];
			c.HangThuongtat = reader.IsDBNull(reader.GetOrdinal("HANG_THUONGTAT")) ? null : (System.String)reader["HANG_THUONGTAT"];
			c.TpGiadinh = reader.IsDBNull(reader.GetOrdinal("TP_GIADINH")) ? null : (System.String)reader["TP_GIADINH"];
			c.TpBanthan = reader.IsDBNull(reader.GetOrdinal("TP_BANTHAN")) ? null : (System.String)reader["TP_BANTHAN"];
			c.IdDantoc = (System.Int32)reader["ID_DANTOC"];
			c.IdTongiao = (System.Int32)reader["ID_TONGIAO"];
			c.IdGioitinh = (System.Int32)reader["ID_GIOITINH"];
			c.NgayNhapngu = (System.DateTime)reader["NGAY_NHAPNGU"];
			c.NgayXuatngu = reader.IsDBNull(reader.GetOrdinal("NGAY_XUATNGU")) ? null : (System.DateTime?)reader["NGAY_XUATNGU"];
			c.NgayTaingu = reader.IsDBNull(reader.GetOrdinal("NGAY_TAINGU")) ? null : (System.DateTime?)reader["NGAY_TAINGU"];
			c.NgayVaodoan = reader.IsDBNull(reader.GetOrdinal("NGAY_VAODOAN")) ? null : (System.DateTime?)reader["NGAY_VAODOAN"];
			c.NgayVaodang = reader.IsDBNull(reader.GetOrdinal("NGAY_VAODANG")) ? null : (System.DateTime?)reader["NGAY_VAODANG"];
			c.NgayvaodangChinhthuc = reader.IsDBNull(reader.GetOrdinal("NGAYVAODANG_CHINHTHUC")) ? null : (System.DateTime?)reader["NGAYVAODANG_CHINHTHUC"];
			c.NgaycaptheQn = reader.IsDBNull(reader.GetOrdinal("NGAYCAPTHE_QN")) ? null : (System.DateTime?)reader["NGAYCAPTHE_QN"];
			c.NgaychuyenQncn = reader.IsDBNull(reader.GetOrdinal("NGAYCHUYEN_QNCN")) ? null : (System.DateTime?)reader["NGAYCHUYEN_QNCN"];
			c.NgaychuyenCnv = reader.IsDBNull(reader.GetOrdinal("NGAYCHUYEN_CNV")) ? null : (System.DateTime?)reader["NGAYCHUYEN_CNV"];
			c.IdDonvi = (System.Int32)reader["ID_DONVI"];
			c.IdLop = (System.Int32)reader["ID_LOP"];
			c.IdLoaiquannhan = (System.Int32)reader["ID_LOAIQUANNHAN"];
			c.Trangthai = (System.String)reader["TRANGTHAI"];
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
		/// Refreshes the <see cref="QUANLYQN.Entities.Quannhan"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Quannhan"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, QUANLYQN.Entities.Quannhan entity)
		{
			if (!reader.Read()) return;
			
			entity.IdQuannhan = (System.Int32)reader["ID_QUANNHAN"];
			entity.MaQuannhan = (System.String)reader["MA_QUANNHAN"];
			entity.HotenKhaisinh = (System.String)reader["HOTEN_KHAISINH"];
			entity.HotenThuongdung = (System.String)reader["HOTEN_THUONGDUNG"];
			entity.SotheQuannhan = (System.Int32)reader["SOTHE_QUANNHAN"];
			entity.CmtQuannhan = (System.Int32)reader["CMT_QUANNHAN"];
			entity.AnhQuannhan = reader.IsDBNull(reader.GetOrdinal("ANH_QUANNHAN")) ? null : (System.Byte[])reader["ANH_QUANNHAN"];
			entity.Ngaysinh = (System.DateTime)reader["NGAYSINH"];
			entity.Nguyenquan = (System.String)reader["NGUYENQUAN"];
			entity.Sinhquan = (System.String)reader["SINHQUAN"];
			entity.Truquan = reader.IsDBNull(reader.GetOrdinal("TRUQUAN")) ? null : (System.String)reader["TRUQUAN"];
			entity.DcBaotin = reader.IsDBNull(reader.GetOrdinal("DC_BAOTIN")) ? null : (System.String)reader["DC_BAOTIN"];
			entity.HotenCha = reader.IsDBNull(reader.GetOrdinal("HOTEN_CHA")) ? null : (System.String)reader["HOTEN_CHA"];
			entity.HotenMe = reader.IsDBNull(reader.GetOrdinal("HOTEN_ME")) ? null : (System.String)reader["HOTEN_ME"];
			entity.SafeNameHotenVoChong = reader.IsDBNull(reader.GetOrdinal("HOTEN_VO(CHONG)")) ? null : (System.String)reader["HOTEN_VO(CHONG)"];
			entity.SoAnhchiem = (System.Int32)reader["SO_ANHCHIEM"];
			entity.Socon = (System.Int32)reader["SOCON"];
			entity.IdCapbac = (System.Int32)reader["ID_CAPBAC"];
			entity.IdChucvu = (System.Int32)reader["ID_CHUCVU"];
			entity.Cnqs = reader.IsDBNull(reader.GetOrdinal("CNQS")) ? null : (System.String)reader["CNQS"];
			entity.Backythuat = reader.IsDBNull(reader.GetOrdinal("BACKYTHUAT")) ? null : (System.String)reader["BACKYTHUAT"];
			entity.TrinhdoVanhoa = (System.String)reader["TRINHDO_VANHOA"];
			entity.Suckhoe = reader.IsDBNull(reader.GetOrdinal("SUCKHOE")) ? null : (System.String)reader["SUCKHOE"];
			entity.Ngoaingu = reader.IsDBNull(reader.GetOrdinal("NGOAINGU")) ? null : (System.String)reader["NGOAINGU"];
			entity.HangThuongtat = reader.IsDBNull(reader.GetOrdinal("HANG_THUONGTAT")) ? null : (System.String)reader["HANG_THUONGTAT"];
			entity.TpGiadinh = reader.IsDBNull(reader.GetOrdinal("TP_GIADINH")) ? null : (System.String)reader["TP_GIADINH"];
			entity.TpBanthan = reader.IsDBNull(reader.GetOrdinal("TP_BANTHAN")) ? null : (System.String)reader["TP_BANTHAN"];
			entity.IdDantoc = (System.Int32)reader["ID_DANTOC"];
			entity.IdTongiao = (System.Int32)reader["ID_TONGIAO"];
			entity.IdGioitinh = (System.Int32)reader["ID_GIOITINH"];
			entity.NgayNhapngu = (System.DateTime)reader["NGAY_NHAPNGU"];
			entity.NgayXuatngu = reader.IsDBNull(reader.GetOrdinal("NGAY_XUATNGU")) ? null : (System.DateTime?)reader["NGAY_XUATNGU"];
			entity.NgayTaingu = reader.IsDBNull(reader.GetOrdinal("NGAY_TAINGU")) ? null : (System.DateTime?)reader["NGAY_TAINGU"];
			entity.NgayVaodoan = reader.IsDBNull(reader.GetOrdinal("NGAY_VAODOAN")) ? null : (System.DateTime?)reader["NGAY_VAODOAN"];
			entity.NgayVaodang = reader.IsDBNull(reader.GetOrdinal("NGAY_VAODANG")) ? null : (System.DateTime?)reader["NGAY_VAODANG"];
			entity.NgayvaodangChinhthuc = reader.IsDBNull(reader.GetOrdinal("NGAYVAODANG_CHINHTHUC")) ? null : (System.DateTime?)reader["NGAYVAODANG_CHINHTHUC"];
			entity.NgaycaptheQn = reader.IsDBNull(reader.GetOrdinal("NGAYCAPTHE_QN")) ? null : (System.DateTime?)reader["NGAYCAPTHE_QN"];
			entity.NgaychuyenQncn = reader.IsDBNull(reader.GetOrdinal("NGAYCHUYEN_QNCN")) ? null : (System.DateTime?)reader["NGAYCHUYEN_QNCN"];
			entity.NgaychuyenCnv = reader.IsDBNull(reader.GetOrdinal("NGAYCHUYEN_CNV")) ? null : (System.DateTime?)reader["NGAYCHUYEN_CNV"];
			entity.IdDonvi = (System.Int32)reader["ID_DONVI"];
			entity.IdLop = (System.Int32)reader["ID_LOP"];
			entity.IdLoaiquannhan = (System.Int32)reader["ID_LOAIQUANNHAN"];
			entity.Trangthai = (System.String)reader["TRANGTHAI"];
			entity.Ghichu = reader.IsDBNull(reader.GetOrdinal("GHICHU")) ? null : (System.String)reader["GHICHU"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="QUANLYQN.Entities.Quannhan"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Quannhan"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, QUANLYQN.Entities.Quannhan entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdQuannhan = (System.Int32)dataRow["ID_QUANNHAN"];
			entity.MaQuannhan = (System.String)dataRow["MA_QUANNHAN"];
			entity.HotenKhaisinh = (System.String)dataRow["HOTEN_KHAISINH"];
			entity.HotenThuongdung = (System.String)dataRow["HOTEN_THUONGDUNG"];
			entity.SotheQuannhan = (System.Int32)dataRow["SOTHE_QUANNHAN"];
			entity.CmtQuannhan = (System.Int32)dataRow["CMT_QUANNHAN"];
			entity.AnhQuannhan = Convert.IsDBNull(dataRow["ANH_QUANNHAN"]) ? null : (System.Byte[])dataRow["ANH_QUANNHAN"];
			entity.Ngaysinh = (System.DateTime)dataRow["NGAYSINH"];
			entity.Nguyenquan = (System.String)dataRow["NGUYENQUAN"];
			entity.Sinhquan = (System.String)dataRow["SINHQUAN"];
			entity.Truquan = Convert.IsDBNull(dataRow["TRUQUAN"]) ? null : (System.String)dataRow["TRUQUAN"];
			entity.DcBaotin = Convert.IsDBNull(dataRow["DC_BAOTIN"]) ? null : (System.String)dataRow["DC_BAOTIN"];
			entity.HotenCha = Convert.IsDBNull(dataRow["HOTEN_CHA"]) ? null : (System.String)dataRow["HOTEN_CHA"];
			entity.HotenMe = Convert.IsDBNull(dataRow["HOTEN_ME"]) ? null : (System.String)dataRow["HOTEN_ME"];
			entity.SafeNameHotenVoChong = Convert.IsDBNull(dataRow["HOTEN_VO(CHONG)"]) ? null : (System.String)dataRow["HOTEN_VO(CHONG)"];
			entity.SoAnhchiem = (System.Int32)dataRow["SO_ANHCHIEM"];
			entity.Socon = (System.Int32)dataRow["SOCON"];
			entity.IdCapbac = (System.Int32)dataRow["ID_CAPBAC"];
			entity.IdChucvu = (System.Int32)dataRow["ID_CHUCVU"];
			entity.Cnqs = Convert.IsDBNull(dataRow["CNQS"]) ? null : (System.String)dataRow["CNQS"];
			entity.Backythuat = Convert.IsDBNull(dataRow["BACKYTHUAT"]) ? null : (System.String)dataRow["BACKYTHUAT"];
			entity.TrinhdoVanhoa = (System.String)dataRow["TRINHDO_VANHOA"];
			entity.Suckhoe = Convert.IsDBNull(dataRow["SUCKHOE"]) ? null : (System.String)dataRow["SUCKHOE"];
			entity.Ngoaingu = Convert.IsDBNull(dataRow["NGOAINGU"]) ? null : (System.String)dataRow["NGOAINGU"];
			entity.HangThuongtat = Convert.IsDBNull(dataRow["HANG_THUONGTAT"]) ? null : (System.String)dataRow["HANG_THUONGTAT"];
			entity.TpGiadinh = Convert.IsDBNull(dataRow["TP_GIADINH"]) ? null : (System.String)dataRow["TP_GIADINH"];
			entity.TpBanthan = Convert.IsDBNull(dataRow["TP_BANTHAN"]) ? null : (System.String)dataRow["TP_BANTHAN"];
			entity.IdDantoc = (System.Int32)dataRow["ID_DANTOC"];
			entity.IdTongiao = (System.Int32)dataRow["ID_TONGIAO"];
			entity.IdGioitinh = (System.Int32)dataRow["ID_GIOITINH"];
			entity.NgayNhapngu = (System.DateTime)dataRow["NGAY_NHAPNGU"];
			entity.NgayXuatngu = Convert.IsDBNull(dataRow["NGAY_XUATNGU"]) ? null : (System.DateTime?)dataRow["NGAY_XUATNGU"];
			entity.NgayTaingu = Convert.IsDBNull(dataRow["NGAY_TAINGU"]) ? null : (System.DateTime?)dataRow["NGAY_TAINGU"];
			entity.NgayVaodoan = Convert.IsDBNull(dataRow["NGAY_VAODOAN"]) ? null : (System.DateTime?)dataRow["NGAY_VAODOAN"];
			entity.NgayVaodang = Convert.IsDBNull(dataRow["NGAY_VAODANG"]) ? null : (System.DateTime?)dataRow["NGAY_VAODANG"];
			entity.NgayvaodangChinhthuc = Convert.IsDBNull(dataRow["NGAYVAODANG_CHINHTHUC"]) ? null : (System.DateTime?)dataRow["NGAYVAODANG_CHINHTHUC"];
			entity.NgaycaptheQn = Convert.IsDBNull(dataRow["NGAYCAPTHE_QN"]) ? null : (System.DateTime?)dataRow["NGAYCAPTHE_QN"];
			entity.NgaychuyenQncn = Convert.IsDBNull(dataRow["NGAYCHUYEN_QNCN"]) ? null : (System.DateTime?)dataRow["NGAYCHUYEN_QNCN"];
			entity.NgaychuyenCnv = Convert.IsDBNull(dataRow["NGAYCHUYEN_CNV"]) ? null : (System.DateTime?)dataRow["NGAYCHUYEN_CNV"];
			entity.IdDonvi = (System.Int32)dataRow["ID_DONVI"];
			entity.IdLop = (System.Int32)dataRow["ID_LOP"];
			entity.IdLoaiquannhan = (System.Int32)dataRow["ID_LOAIQUANNHAN"];
			entity.Trangthai = (System.String)dataRow["TRANGTHAI"];
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
		/// <param name="entity">The <see cref="QUANLYQN.Entities.Quannhan"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Quannhan Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, QUANLYQN.Entities.Quannhan entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region IdGioitinhSource	
			if (CanDeepLoad(entity, "Dmgioitinh|IdGioitinhSource", deepLoadType, innerList) 
				&& entity.IdGioitinhSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdGioitinh;
				Dmgioitinh tmpEntity = EntityManager.LocateEntity<Dmgioitinh>(EntityLocator.ConstructKeyFromPkItems(typeof(Dmgioitinh), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdGioitinhSource = tmpEntity;
				else
					entity.IdGioitinhSource = DataRepository.DmgioitinhProvider.GetByIdGioitinh(transactionManager, entity.IdGioitinh);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdGioitinhSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdGioitinhSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DmgioitinhProvider.DeepLoad(transactionManager, entity.IdGioitinhSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdGioitinhSource

			#region IdLoaiquannhanSource	
			if (CanDeepLoad(entity, "Dmloaiquannhan|IdLoaiquannhanSource", deepLoadType, innerList) 
				&& entity.IdLoaiquannhanSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdLoaiquannhan;
				Dmloaiquannhan tmpEntity = EntityManager.LocateEntity<Dmloaiquannhan>(EntityLocator.ConstructKeyFromPkItems(typeof(Dmloaiquannhan), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdLoaiquannhanSource = tmpEntity;
				else
					entity.IdLoaiquannhanSource = DataRepository.DmloaiquannhanProvider.GetByIdLoaiqn(transactionManager, entity.IdLoaiquannhan);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdLoaiquannhanSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdLoaiquannhanSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DmloaiquannhanProvider.DeepLoad(transactionManager, entity.IdLoaiquannhanSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdLoaiquannhanSource

			#region IdDantocSource	
			if (CanDeepLoad(entity, "Dmdantoc|IdDantocSource", deepLoadType, innerList) 
				&& entity.IdDantocSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdDantoc;
				Dmdantoc tmpEntity = EntityManager.LocateEntity<Dmdantoc>(EntityLocator.ConstructKeyFromPkItems(typeof(Dmdantoc), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdDantocSource = tmpEntity;
				else
					entity.IdDantocSource = DataRepository.DmdantocProvider.GetByIdDantoc(transactionManager, entity.IdDantoc);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdDantocSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdDantocSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DmdantocProvider.DeepLoad(transactionManager, entity.IdDantocSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdDantocSource

			#region IdTongiaoSource	
			if (CanDeepLoad(entity, "Dmtongiao|IdTongiaoSource", deepLoadType, innerList) 
				&& entity.IdTongiaoSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdTongiao;
				Dmtongiao tmpEntity = EntityManager.LocateEntity<Dmtongiao>(EntityLocator.ConstructKeyFromPkItems(typeof(Dmtongiao), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdTongiaoSource = tmpEntity;
				else
					entity.IdTongiaoSource = DataRepository.DmtongiaoProvider.GetByIdTongiao(transactionManager, entity.IdTongiao);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdTongiaoSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdTongiaoSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DmtongiaoProvider.DeepLoad(transactionManager, entity.IdTongiaoSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdTongiaoSource

			#region IdDonviSource	
			if (CanDeepLoad(entity, "Dmdonvi|IdDonviSource", deepLoadType, innerList) 
				&& entity.IdDonviSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdDonvi;
				Dmdonvi tmpEntity = EntityManager.LocateEntity<Dmdonvi>(EntityLocator.ConstructKeyFromPkItems(typeof(Dmdonvi), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdDonviSource = tmpEntity;
				else
					entity.IdDonviSource = DataRepository.DmdonviProvider.GetByIdDonvi(transactionManager, entity.IdDonvi);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdDonviSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdDonviSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DmdonviProvider.DeepLoad(transactionManager, entity.IdDonviSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdDonviSource

			#region IdCapbacSource	
			if (CanDeepLoad(entity, "Dmcapbac|IdCapbacSource", deepLoadType, innerList) 
				&& entity.IdCapbacSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdCapbac;
				Dmcapbac tmpEntity = EntityManager.LocateEntity<Dmcapbac>(EntityLocator.ConstructKeyFromPkItems(typeof(Dmcapbac), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdCapbacSource = tmpEntity;
				else
					entity.IdCapbacSource = DataRepository.DmcapbacProvider.GetByIdCapbac(transactionManager, entity.IdCapbac);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdCapbacSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdCapbacSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DmcapbacProvider.DeepLoad(transactionManager, entity.IdCapbacSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdCapbacSource

			#region IdChucvuSource	
			if (CanDeepLoad(entity, "Dmchucvu|IdChucvuSource", deepLoadType, innerList) 
				&& entity.IdChucvuSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdChucvu;
				Dmchucvu tmpEntity = EntityManager.LocateEntity<Dmchucvu>(EntityLocator.ConstructKeyFromPkItems(typeof(Dmchucvu), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdChucvuSource = tmpEntity;
				else
					entity.IdChucvuSource = DataRepository.DmchucvuProvider.GetByIdChucvu(transactionManager, entity.IdChucvu);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdChucvuSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdChucvuSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DmchucvuProvider.DeepLoad(transactionManager, entity.IdChucvuSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdChucvuSource

			#region IdLopSource	
			if (CanDeepLoad(entity, "Dmlop|IdLopSource", deepLoadType, innerList) 
				&& entity.IdLopSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdLop;
				Dmlop tmpEntity = EntityManager.LocateEntity<Dmlop>(EntityLocator.ConstructKeyFromPkItems(typeof(Dmlop), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdLopSource = tmpEntity;
				else
					entity.IdLopSource = DataRepository.DmlopProvider.GetByIdLop(transactionManager, entity.IdLop);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdLopSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdLopSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DmlopProvider.DeepLoad(transactionManager, entity.IdLopSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdLopSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdQuannhan methods when available
			
			#region LschucvuCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Lschucvu>|LschucvuCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LschucvuCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.LschucvuCollection = DataRepository.LschucvuProvider.GetByIdQuannhan(transactionManager, entity.IdQuannhan);

				if (deep && entity.LschucvuCollection.Count > 0)
				{
					deepHandles.Add("LschucvuCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Lschucvu>) DataRepository.LschucvuProvider.DeepLoad,
						new object[] { transactionManager, entity.LschucvuCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region LscapbacCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Lscapbac>|LscapbacCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LscapbacCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.LscapbacCollection = DataRepository.LscapbacProvider.GetByIdQuannhan(transactionManager, entity.IdQuannhan);

				if (deep && entity.LscapbacCollection.Count > 0)
				{
					deepHandles.Add("LscapbacCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Lscapbac>) DataRepository.LscapbacProvider.DeepLoad,
						new object[] { transactionManager, entity.LscapbacCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region LskyluatCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Lskyluat>|LskyluatCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LskyluatCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.LskyluatCollection = DataRepository.LskyluatProvider.GetByIdQuannhan(transactionManager, entity.IdQuannhan);

				if (deep && entity.LskyluatCollection.Count > 0)
				{
					deepHandles.Add("LskyluatCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Lskyluat>) DataRepository.LskyluatProvider.DeepLoad,
						new object[] { transactionManager, entity.LskyluatCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region LskhenthuongCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Lskhenthuong>|LskhenthuongCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LskhenthuongCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.LskhenthuongCollection = DataRepository.LskhenthuongProvider.GetByIdQuannhan(transactionManager, entity.IdQuannhan);

				if (deep && entity.LskhenthuongCollection.Count > 0)
				{
					deepHandles.Add("LskhenthuongCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Lskhenthuong>) DataRepository.LskhenthuongProvider.DeepLoad,
						new object[] { transactionManager, entity.LskhenthuongCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region LstruonglopCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Lstruonglop>|LstruonglopCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LstruonglopCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.LstruonglopCollection = DataRepository.LstruonglopProvider.GetByIdQuannhan(transactionManager, entity.IdQuannhan);

				if (deep && entity.LstruonglopCollection.Count > 0)
				{
					deepHandles.Add("LstruonglopCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Lstruonglop>) DataRepository.LstruonglopProvider.DeepLoad,
						new object[] { transactionManager, entity.LstruonglopCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
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
		/// Deep Save the entire object graph of the QUANLYQN.Entities.Quannhan object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">QUANLYQN.Entities.Quannhan instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">QUANLYQN.Entities.Quannhan Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, QUANLYQN.Entities.Quannhan entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IdGioitinhSource
			if (CanDeepSave(entity, "Dmgioitinh|IdGioitinhSource", deepSaveType, innerList) 
				&& entity.IdGioitinhSource != null)
			{
				DataRepository.DmgioitinhProvider.Save(transactionManager, entity.IdGioitinhSource);
				entity.IdGioitinh = entity.IdGioitinhSource.IdGioitinh;
			}
			#endregion 
			
			#region IdLoaiquannhanSource
			if (CanDeepSave(entity, "Dmloaiquannhan|IdLoaiquannhanSource", deepSaveType, innerList) 
				&& entity.IdLoaiquannhanSource != null)
			{
				DataRepository.DmloaiquannhanProvider.Save(transactionManager, entity.IdLoaiquannhanSource);
				entity.IdLoaiquannhan = entity.IdLoaiquannhanSource.IdLoaiqn;
			}
			#endregion 
			
			#region IdDantocSource
			if (CanDeepSave(entity, "Dmdantoc|IdDantocSource", deepSaveType, innerList) 
				&& entity.IdDantocSource != null)
			{
				DataRepository.DmdantocProvider.Save(transactionManager, entity.IdDantocSource);
				entity.IdDantoc = entity.IdDantocSource.IdDantoc;
			}
			#endregion 
			
			#region IdTongiaoSource
			if (CanDeepSave(entity, "Dmtongiao|IdTongiaoSource", deepSaveType, innerList) 
				&& entity.IdTongiaoSource != null)
			{
				DataRepository.DmtongiaoProvider.Save(transactionManager, entity.IdTongiaoSource);
				entity.IdTongiao = entity.IdTongiaoSource.IdTongiao;
			}
			#endregion 
			
			#region IdDonviSource
			if (CanDeepSave(entity, "Dmdonvi|IdDonviSource", deepSaveType, innerList) 
				&& entity.IdDonviSource != null)
			{
				DataRepository.DmdonviProvider.Save(transactionManager, entity.IdDonviSource);
				entity.IdDonvi = entity.IdDonviSource.IdDonvi;
			}
			#endregion 
			
			#region IdCapbacSource
			if (CanDeepSave(entity, "Dmcapbac|IdCapbacSource", deepSaveType, innerList) 
				&& entity.IdCapbacSource != null)
			{
				DataRepository.DmcapbacProvider.Save(transactionManager, entity.IdCapbacSource);
				entity.IdCapbac = entity.IdCapbacSource.IdCapbac;
			}
			#endregion 
			
			#region IdChucvuSource
			if (CanDeepSave(entity, "Dmchucvu|IdChucvuSource", deepSaveType, innerList) 
				&& entity.IdChucvuSource != null)
			{
				DataRepository.DmchucvuProvider.Save(transactionManager, entity.IdChucvuSource);
				entity.IdChucvu = entity.IdChucvuSource.IdChucvu;
			}
			#endregion 
			
			#region IdLopSource
			if (CanDeepSave(entity, "Dmlop|IdLopSource", deepSaveType, innerList) 
				&& entity.IdLopSource != null)
			{
				DataRepository.DmlopProvider.Save(transactionManager, entity.IdLopSource);
				entity.IdLop = entity.IdLopSource.IdLop;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();
	
			#region List<Lschucvu>
				if (CanDeepSave(entity.LschucvuCollection, "List<Lschucvu>|LschucvuCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Lschucvu child in entity.LschucvuCollection)
					{
						if(child.IdQuannhanSource != null)
							child.IdQuannhan = child.IdQuannhanSource.IdQuannhan;
						else
							child.IdQuannhan = entity.IdQuannhan;

					}

					if (entity.LschucvuCollection.Count > 0 || entity.LschucvuCollection.DeletedItems.Count > 0)
					{
						DataRepository.LschucvuProvider.Save(transactionManager, entity.LschucvuCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Lschucvu >) DataRepository.LschucvuProvider.DeepSave,
							new object[] { transactionManager, entity.LschucvuCollection, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
	
			#region List<Lscapbac>
				if (CanDeepSave(entity.LscapbacCollection, "List<Lscapbac>|LscapbacCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Lscapbac child in entity.LscapbacCollection)
					{
						if(child.IdQuannhanSource != null)
							child.IdQuannhan = child.IdQuannhanSource.IdQuannhan;
						else
							child.IdQuannhan = entity.IdQuannhan;

					}

					if (entity.LscapbacCollection.Count > 0 || entity.LscapbacCollection.DeletedItems.Count > 0)
					{
						DataRepository.LscapbacProvider.Save(transactionManager, entity.LscapbacCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Lscapbac >) DataRepository.LscapbacProvider.DeepSave,
							new object[] { transactionManager, entity.LscapbacCollection, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
	
			#region List<Lskyluat>
				if (CanDeepSave(entity.LskyluatCollection, "List<Lskyluat>|LskyluatCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Lskyluat child in entity.LskyluatCollection)
					{
						if(child.IdQuannhanSource != null)
							child.IdQuannhan = child.IdQuannhanSource.IdQuannhan;
						else
							child.IdQuannhan = entity.IdQuannhan;

					}

					if (entity.LskyluatCollection.Count > 0 || entity.LskyluatCollection.DeletedItems.Count > 0)
					{
						DataRepository.LskyluatProvider.Save(transactionManager, entity.LskyluatCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Lskyluat >) DataRepository.LskyluatProvider.DeepSave,
							new object[] { transactionManager, entity.LskyluatCollection, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
	
			#region List<Lskhenthuong>
				if (CanDeepSave(entity.LskhenthuongCollection, "List<Lskhenthuong>|LskhenthuongCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Lskhenthuong child in entity.LskhenthuongCollection)
					{
						if(child.IdQuannhanSource != null)
							child.IdQuannhan = child.IdQuannhanSource.IdQuannhan;
						else
							child.IdQuannhan = entity.IdQuannhan;

					}

					if (entity.LskhenthuongCollection.Count > 0 || entity.LskhenthuongCollection.DeletedItems.Count > 0)
					{
						DataRepository.LskhenthuongProvider.Save(transactionManager, entity.LskhenthuongCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Lskhenthuong >) DataRepository.LskhenthuongProvider.DeepSave,
							new object[] { transactionManager, entity.LskhenthuongCollection, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
	
			#region List<Lstruonglop>
				if (CanDeepSave(entity.LstruonglopCollection, "List<Lstruonglop>|LstruonglopCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Lstruonglop child in entity.LstruonglopCollection)
					{
						if(child.IdQuannhanSource != null)
							child.IdQuannhan = child.IdQuannhanSource.IdQuannhan;
						else
							child.IdQuannhan = entity.IdQuannhan;

					}

					if (entity.LstruonglopCollection.Count > 0 || entity.LstruonglopCollection.DeletedItems.Count > 0)
					{
						DataRepository.LstruonglopProvider.Save(transactionManager, entity.LstruonglopCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Lstruonglop >) DataRepository.LstruonglopProvider.DeepSave,
							new object[] { transactionManager, entity.LstruonglopCollection, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
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
	
	#region QuannhanChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>QUANLYQN.Entities.Quannhan</c>
	///</summary>
	public enum QuannhanChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Dmgioitinh</c> at IdGioitinhSource
		///</summary>
		[ChildEntityType(typeof(Dmgioitinh))]
		Dmgioitinh,
			
		///<summary>
		/// Composite Property for <c>Dmloaiquannhan</c> at IdLoaiquannhanSource
		///</summary>
		[ChildEntityType(typeof(Dmloaiquannhan))]
		Dmloaiquannhan,
			
		///<summary>
		/// Composite Property for <c>Dmdantoc</c> at IdDantocSource
		///</summary>
		[ChildEntityType(typeof(Dmdantoc))]
		Dmdantoc,
			
		///<summary>
		/// Composite Property for <c>Dmtongiao</c> at IdTongiaoSource
		///</summary>
		[ChildEntityType(typeof(Dmtongiao))]
		Dmtongiao,
			
		///<summary>
		/// Composite Property for <c>Dmdonvi</c> at IdDonviSource
		///</summary>
		[ChildEntityType(typeof(Dmdonvi))]
		Dmdonvi,
			
		///<summary>
		/// Composite Property for <c>Dmcapbac</c> at IdCapbacSource
		///</summary>
		[ChildEntityType(typeof(Dmcapbac))]
		Dmcapbac,
			
		///<summary>
		/// Composite Property for <c>Dmchucvu</c> at IdChucvuSource
		///</summary>
		[ChildEntityType(typeof(Dmchucvu))]
		Dmchucvu,
			
		///<summary>
		/// Composite Property for <c>Dmlop</c> at IdLopSource
		///</summary>
		[ChildEntityType(typeof(Dmlop))]
		Dmlop,
	
		///<summary>
		/// Collection of <c>Quannhan</c> as OneToMany for LschucvuCollection
		///</summary>
		[ChildEntityType(typeof(TList<Lschucvu>))]
		LschucvuCollection,

		///<summary>
		/// Collection of <c>Quannhan</c> as OneToMany for LscapbacCollection
		///</summary>
		[ChildEntityType(typeof(TList<Lscapbac>))]
		LscapbacCollection,

		///<summary>
		/// Collection of <c>Quannhan</c> as OneToMany for LskyluatCollection
		///</summary>
		[ChildEntityType(typeof(TList<Lskyluat>))]
		LskyluatCollection,

		///<summary>
		/// Collection of <c>Quannhan</c> as OneToMany for LskhenthuongCollection
		///</summary>
		[ChildEntityType(typeof(TList<Lskhenthuong>))]
		LskhenthuongCollection,

		///<summary>
		/// Collection of <c>Quannhan</c> as OneToMany for LstruonglopCollection
		///</summary>
		[ChildEntityType(typeof(TList<Lstruonglop>))]
		LstruonglopCollection,
	}
	
	#endregion QuannhanChildEntityTypes
	
	#region QuannhanFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;QuannhanColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Quannhan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuannhanFilterBuilder : SqlFilterBuilder<QuannhanColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuannhanFilterBuilder class.
		/// </summary>
		public QuannhanFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuannhanFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuannhanFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuannhanFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuannhanFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuannhanFilterBuilder
	
	#region QuannhanParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;QuannhanColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Quannhan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuannhanParameterBuilder : ParameterizedSqlFilterBuilder<QuannhanColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuannhanParameterBuilder class.
		/// </summary>
		public QuannhanParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuannhanParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuannhanParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuannhanParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuannhanParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuannhanParameterBuilder
} // end namespace
