﻿using System;
using System.ComponentModel;

namespace QUANLYQN.Entities
{
	/// <summary>
	///		The data structure representation of the 'DMLOAIQUANNHAN' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IDmloaiquannhan 
	{
		/// <summary>			
		/// ID_LOAIQN : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "DMLOAIQUANNHAN"</remarks>
		System.Int32 IdLoaiqn { get; set; }
				
		
		
		/// <summary>
		/// LOAI_QUANNHAN : 
		/// </summary>
		System.String  LoaiQuannhan  { get; set; }
		
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


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation quannhanIdLoaiquannhan
		/// </summary>	
		TList<Quannhan> QuannhanCollection {  get;  set;}	

		#endregion Data Properties

	}
}


