﻿using System;
using System.ComponentModel;

namespace QUANLYQN.Entities
{
	/// <summary>
	///		The data structure representation of the 'LSKHENTHUONG' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ILskhenthuong 
	{
		/// <summary>			
		/// ID_LICHSUKHENTHUONG : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "LSKHENTHUONG"</remarks>
		System.Int64 IdLichsukhenthuong { get; set; }
				
		
		
		/// <summary>
		/// ID_QUANNHAN : 
		/// </summary>
		System.Int32  IdQuannhan  { get; set; }
		
		/// <summary>
		/// ID_HINHTHUC_KHENTHUONG : 
		/// </summary>
		System.Int32  IdHinhthucKhenthuong  { get; set; }
		
		/// <summary>
		/// CAP_KHENTHUONG : 
		/// </summary>
		System.String  CapKhenthuong  { get; set; }
		
		/// <summary>
		/// NGAYNHAN : 
		/// </summary>
		System.DateTime?  Ngaynhan  { get; set; }
		
		/// <summary>
		/// GHICHU : 
		/// </summary>
		System.String  Ghichu  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


