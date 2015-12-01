﻿
/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file Dmhinhthuckhenthuong.cs instead.
*/

#region using directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;

#endregion

namespace QUANLYQN.Entities
{
	///<summary>
	/// An object representation of the 'DMHINHTHUCKHENTHUONG' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	public abstract partial class DmhinhthuckhenthuongBase : EntityBase, QUANLYQN.Entities.IDmhinhthuckhenthuong, IEntityId<DmhinhthuckhenthuongKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		///  Hold the inner data of the entity.
		/// </summary>
		private DmhinhthuckhenthuongEntityData entityData;
		
		/// <summary>
		/// 	Hold the original data of the entity, as loaded from the repository.
		/// </summary>
		private DmhinhthuckhenthuongEntityData _originalData;
		
		/// <summary>
		/// 	Hold a backup of the inner data of the entity.
		/// </summary>
		private DmhinhthuckhenthuongEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		/// <summary>
		/// 	Hold the parent TList&lt;entity&gt; in which this entity maybe contained.
		/// </summary>
		/// <remark>Mostly used for databinding</remark>
		[NonSerialized]
		private TList<Dmhinhthuckhenthuong> parentCollection;
		
		private bool inTxn = false;
		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event DmhinhthuckhenthuongEventHandler ColumnChanging;		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event DmhinhthuckhenthuongEventHandler ColumnChanged;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="DmhinhthuckhenthuongBase"/> instance.
		///</summary>
		public DmhinhthuckhenthuongBase()
		{
			this.entityData = new DmhinhthuckhenthuongEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="DmhinhthuckhenthuongBase"/> instance.
		///</summary>
		///<param name="hinhthucKhenthuong"></param>
		///<param name="ghichu"></param>
		public DmhinhthuckhenthuongBase(System.String hinhthucKhenthuong, System.String ghichu)
		{
			this.entityData = new DmhinhthuckhenthuongEntityData();
			this.backupData = null;

			this.HinhthucKhenthuong = hinhthucKhenthuong;
			this.Ghichu = ghichu;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="Dmhinhthuckhenthuong"/> instance.
		///</summary>
		///<param name="hinhthucKhenthuong"></param>
		///<param name="ghichu"></param>
		public static Dmhinhthuckhenthuong CreateDmhinhthuckhenthuong(System.String hinhthucKhenthuong, System.String ghichu)
		{
			Dmhinhthuckhenthuong newDmhinhthuckhenthuong = new Dmhinhthuckhenthuong();
			newDmhinhthuckhenthuong.HinhthucKhenthuong = hinhthucKhenthuong;
			newDmhinhthuckhenthuong.Ghichu = ghichu;
			return newDmhinhthuckhenthuong;
		}
				
		#endregion Constructors
			
		#region Properties	
		
		#region Data Properties		
		/// <summary>
		/// 	Gets or sets the IdHinhthucKhenthuong property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[ReadOnlyAttribute(false)/*, XmlIgnoreAttribute()*/, DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(true, true, false)]
		public virtual System.Int32 IdHinhthucKhenthuong
		{
			get
			{
				return this.entityData.IdHinhthucKhenthuong; 
			}
			
			set
			{
				if (this.entityData.IdHinhthucKhenthuong == value)
					return;
					
				OnColumnChanging(DmhinhthuckhenthuongColumn.IdHinhthucKhenthuong, this.entityData.IdHinhthucKhenthuong);
				this.entityData.IdHinhthucKhenthuong = value;
				this.EntityId.IdHinhthucKhenthuong = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(DmhinhthuckhenthuongColumn.IdHinhthucKhenthuong, this.entityData.IdHinhthucKhenthuong);
				OnPropertyChanged("IdHinhthucKhenthuong");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the HinhthucKhenthuong property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, false, 50)]
		public virtual System.String HinhthucKhenthuong
		{
			get
			{
				return this.entityData.HinhthucKhenthuong; 
			}
			
			set
			{
				if (this.entityData.HinhthucKhenthuong == value)
					return;
					
				OnColumnChanging(DmhinhthuckhenthuongColumn.HinhthucKhenthuong, this.entityData.HinhthucKhenthuong);
				this.entityData.HinhthucKhenthuong = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(DmhinhthuckhenthuongColumn.HinhthucKhenthuong, this.entityData.HinhthucKhenthuong);
				OnPropertyChanged("HinhthucKhenthuong");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Ghichu property. 
		///		
		/// </summary>
		/// <value>This type is ntext.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true)]
		public virtual System.String Ghichu
		{
			get
			{
				return this.entityData.Ghichu; 
			}
			
			set
			{
				if (this.entityData.Ghichu == value)
					return;
					
				OnColumnChanging(DmhinhthuckhenthuongColumn.Ghichu, this.entityData.Ghichu);
				this.entityData.Ghichu = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(DmhinhthuckhenthuongColumn.Ghichu, this.entityData.Ghichu);
				OnPropertyChanged("Ghichu");
			}
		}
		
		#endregion Data Properties		

		#region Source Foreign Key Property
				
		#endregion
		
		#region Children Collections
	
		/// <summary>
		///	Holds a collection of Lskhenthuong objects
		///	which are related to this object through the relation FK_LSKHENTHUONG_DMHINHTHUCKHENTHUONG1
		/// </summary>	
		[System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
		public virtual TList<Lskhenthuong> LskhenthuongCollection
		{
			get { return entityData.LskhenthuongCollection; }
			set { entityData.LskhenthuongCollection = value; }	
		}
		#endregion Children Collections
		
		#endregion
		
		#region Validation
		
		/// <summary>
		/// Assigns validation rules to this object based on model definition.
		/// </summary>
		/// <remarks>This method overrides the base class to add schema related validation.</remarks>
		protected override void AddValidationRules()
		{
			//Validation rules based on database schema.
			ValidationRules.AddRule(
				Validation.CommonRules.NotNull,
				new Validation.ValidationRuleArgs("HinhthucKhenthuong", "Hinhthuc Khenthuong"));
			ValidationRules.AddRule(
				Validation.CommonRules.StringMaxLength, 
				new Validation.CommonRules.MaxLengthRuleArgs("HinhthucKhenthuong", "Hinhthuc Khenthuong", 50));
		}
   		#endregion
		
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "DMHINHTHUCKHENTHUONG"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"ID_HINHTHUC_KHENTHUONG", "HINHTHUC_KHENTHUONG", "GHICHU"};
			}
		}
		#endregion 
		
		#region IEditableObject
		
		#region  CancelAddNew Event
		/// <summary>
        /// The delegate for the CancelAddNew event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public delegate void CancelAddNewEventHandler(object sender, EventArgs e);
    
    	/// <summary>
		/// The CancelAddNew event.
		/// </summary>
		[field:NonSerialized]
		public event CancelAddNewEventHandler CancelAddNew ;

		/// <summary>
        /// Called when [cancel add new].
        /// </summary>
        public void OnCancelAddNew()
        {    
			if (!SuppressEntityEvents)
			{
	            CancelAddNewEventHandler handler = CancelAddNew ;
            	if (handler != null)
	            {    
    	            handler(this, EventArgs.Empty) ;
        	    }
	        }
        }
		#endregion 
		
		/// <summary>
		/// Begins an edit on an object.
		/// </summary>
		void IEditableObject.BeginEdit() 
	    {
	        //Console.WriteLine("Start BeginEdit");
	        if (!inTxn) 
	        {
	            this.backupData = this.entityData.Clone() as DmhinhthuckhenthuongEntityData;
	            inTxn = true;
	            //Console.WriteLine("BeginEdit");
	        }
	        //Console.WriteLine("End BeginEdit");
	    }
	
		/// <summary>
		/// Discards changes since the last <c>BeginEdit</c> call.
		/// </summary>
	    void IEditableObject.CancelEdit() 
	    {
	        //Console.WriteLine("Start CancelEdit");
	        if (this.inTxn) 
	        {
	            this.entityData = this.backupData;
	            this.backupData = null;
				this.inTxn = false;

				if (this.bindingIsNew)
	        	//if (this.EntityState == EntityState.Added)
	        	{
					if (this.parentCollection != null)
						this.parentCollection.Remove( (Dmhinhthuckhenthuong) this ) ;
				}	            
	        }
	        //Console.WriteLine("End CancelEdit");
	    }
	
		/// <summary>
		/// Pushes changes since the last <c>BeginEdit</c> or <c>IBindingList.AddNew</c> call into the underlying object.
		/// </summary>
	    void IEditableObject.EndEdit() 
	    {
	        //Console.WriteLine("Start EndEdit" + this.custData.id + this.custData.lastName);
	        if (this.inTxn) 
	        {
	            this.backupData = null;
				if (this.IsDirty) 
				{
					if (this.bindingIsNew) {
						this.EntityState = EntityState.Added;
						this.bindingIsNew = false ;
					}
					else
						if (this.EntityState == EntityState.Unchanged) 
							this.EntityState = EntityState.Changed ;
				}

				this.bindingIsNew = false ;
	            this.inTxn = false;	            
	        }
	        //Console.WriteLine("End EndEdit");
	    }
	    
	    /// <summary>
        /// Gets or sets the parent collection of this current entity, if available.
        /// </summary>
        /// <value>The parent collection.</value>
	    [XmlIgnore]
		[Browsable(false)]
	    public override object ParentCollection
	    {
	        get 
	        {
	            return this.parentCollection;
	        }
	        set 
	        {
	            this.parentCollection = value as TList<Dmhinhthuckhenthuong>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as Dmhinhthuckhenthuong);
	        }
	    }


		#endregion
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed Dmhinhthuckhenthuong Entity 
		///</summary>
		public virtual Dmhinhthuckhenthuong Copy()
		{
			//shallow copy entity
			Dmhinhthuckhenthuong copy = new Dmhinhthuckhenthuong();
			copy.SuppressEntityEvents = true;
			copy.IdHinhthucKhenthuong = this.IdHinhthucKhenthuong;
			copy.HinhthucKhenthuong = this.HinhthucKhenthuong;
			copy.Ghichu = this.Ghichu;
			
		
			//deep copy nested objects
			copy.LskhenthuongCollection = (TList<Lskhenthuong>) MakeCopyOf(this.LskhenthuongCollection); 
			copy.EntityState = this.EntityState;
			copy.SuppressEntityEvents = false;
			return copy;
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone()
		{
			return this.Copy();
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x == null)
				return null;
				
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		
		///<summary>
		///  Returns a Typed Dmhinhthuckhenthuong Entity which is a deep copy of the current entity.
		///</summary>
		public virtual Dmhinhthuckhenthuong DeepCopy()
		{
			return EntityHelper.Clone<Dmhinhthuckhenthuong>(this as Dmhinhthuckhenthuong);	
		}
		#endregion
		
		#region Methods	
			
		///<summary>
		/// Revert all changes and restore original values.
		///</summary>
		public override void CancelChanges()
		{
			IEditableObject obj = (IEditableObject) this;
			obj.CancelEdit();

			this.entityData = null;
			if (this._originalData != null)
			{
				this.entityData = this._originalData.Clone() as DmhinhthuckhenthuongEntityData;
			}
		}	
		
		/// <summary>
		/// Accepts the changes made to this object.
		/// </summary>
		/// <remarks>
		/// After calling this method, properties: IsDirty, IsNew are false. IsDeleted flag remains unchanged as it is handled by the parent List.
		/// </remarks>
		public override void AcceptChanges()
		{
			base.AcceptChanges();

			// we keep of the original version of the data
			this._originalData = null;
			this._originalData = this.entityData.Clone() as DmhinhthuckhenthuongEntityData;
		}
		
		#region Comparision with original data
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool IsPropertyChanged(DmhinhthuckhenthuongColumn column)
		{
			switch(column)
			{
					case DmhinhthuckhenthuongColumn.IdHinhthucKhenthuong:
					return entityData.IdHinhthucKhenthuong != _originalData.IdHinhthucKhenthuong;
					case DmhinhthuckhenthuongColumn.HinhthucKhenthuong:
					return entityData.HinhthucKhenthuong != _originalData.HinhthucKhenthuong;
					case DmhinhthuckhenthuongColumn.Ghichu:
					return entityData.Ghichu != _originalData.Ghichu;
			
				default:
					return false;
			}
		}
		
		/// <summary>
		/// Determines whether the data has changed from original.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if [has data changed]; otherwise, <c>false</c>.
		/// </returns>
		public bool HasDataChanged()
		{
			bool result = false;
			result = result || entityData.IdHinhthucKhenthuong != _originalData.IdHinhthucKhenthuong;
			result = result || entityData.HinhthucKhenthuong != _originalData.HinhthucKhenthuong;
			result = result || entityData.Ghichu != _originalData.Ghichu;
			return result;
}	
		
		#endregion

        ///<summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        ///</summary>
        ///<param name="Object1">An object to compare to this instance.</param>
        ///<returns>true if Object1 is a <see cref="DmhinhthuckhenthuongBase"/> and has the same value as this instance; otherwise, false.</returns>
        public override bool Equals(object Object1)
        {
			if (Object1 is DmhinhthuckhenthuongBase)
				return Equals(this, (DmhinhthuckhenthuongBase)Object1);
			else
				return false;
        }

        /// <summary>
		/// Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.
        /// Provides a hash function that is appropriate for <see cref="DmhinhthuckhenthuongBase"/> class 
        /// and that ensures a better distribution in the hash table
        /// </summary>
        /// <returns>number (hash code) that corresponds to the value of an object</returns>
        public override int GetHashCode()
        {
			return this.IdHinhthucKhenthuong.GetHashCode() ^ 
					this.HinhthucKhenthuong.GetHashCode() ^ 
					((this.Ghichu == null) ? string.Empty : this.Ghichu.ToString()).GetHashCode();
        }
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="DmhinhthuckhenthuongBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(DmhinhthuckhenthuongBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="DmhinhthuckhenthuongBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="DmhinhthuckhenthuongBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="DmhinhthuckhenthuongBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(DmhinhthuckhenthuongBase Object1, DmhinhthuckhenthuongBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.IdHinhthucKhenthuong != Object2.IdHinhthucKhenthuong)
				equal = false;
			if (Object1.HinhthucKhenthuong != Object2.HinhthucKhenthuong)
				equal = false;
			if ( Object1.Ghichu != null && Object2.Ghichu != null )
			{
				if (Object1.Ghichu != Object2.Ghichu)
					equal = false;
			}
			else if (Object1.Ghichu == null ^ Object2.Ghichu == null )
			{
				equal = false;
			}
					
			return equal;
		}
		
		#endregion
		
		#region IComparable Members
		///<summary>
		/// Compares this instance to a specified object and returns an indication of their relative values.
		///<param name="obj">An object to compare to this instance, or a null reference (Nothing in Visual Basic).</param>
		///</summary>
		///<returns>A signed integer that indicates the relative order of this instance and obj.</returns>
		public virtual int CompareTo(object obj)
		{
			throw new NotImplementedException();
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]) .CompareTo(((DmhinhthuckhenthuongBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]));
		}
		
		/*
		// static method to get a Comparer object
        public static DmhinhthuckhenthuongComparer GetComparer()
        {
            return new DmhinhthuckhenthuongComparer();
        }
        */

        // Comparer delegates back to Dmhinhthuckhenthuong
        // Employee uses the integer's default
        // CompareTo method
        /*
        public int CompareTo(Item rhs)
        {
            return this.Id.CompareTo(rhs.Id);
        }
        */

/*
        // Special implementation to be called by custom comparer
        public int CompareTo(Dmhinhthuckhenthuong rhs, DmhinhthuckhenthuongColumn which)
        {
            switch (which)
            {
            	
            	
            	case DmhinhthuckhenthuongColumn.IdHinhthucKhenthuong:
            		return this.IdHinhthucKhenthuong.CompareTo(rhs.IdHinhthucKhenthuong);
            		
            		                 
            	
            	
            	case DmhinhthuckhenthuongColumn.HinhthucKhenthuong:
            		return this.HinhthucKhenthuong.CompareTo(rhs.HinhthucKhenthuong);
            		
            		                 
            	
            	
            	case DmhinhthuckhenthuongColumn.Ghichu:
            		return this.Ghichu.CompareTo(rhs.Ghichu);
            		
            		                 
            }
            return 0;
        }
        */
	
		#endregion
		
		#region IComponent Members
		
		private ISite _site = null;

		/// <summary>
		/// Gets or Sets the site where this data is located.
		/// </summary>
		[XmlIgnore]
		[SoapIgnore]
		[Browsable(false)]
		public ISite Site
		{
			get{ return this._site; }
			set{ this._site = value; }
		}

		#endregion

		#region IDisposable Members
		
		/// <summary>
		/// Notify those that care when we dispose.
		/// </summary>
		[field:NonSerialized]
		public event System.EventHandler Disposed;

		/// <summary>
		/// Clean up. Nothing here though.
		/// </summary>
		public virtual void Dispose()
		{
			this.parentCollection = null;
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		/// <summary>
		/// Clean up.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				EventHandler handler = Disposed;
				if (handler != null)
					handler(this, EventArgs.Empty);
			}
		}
		
		#endregion
				
		#region IEntityKey<DmhinhthuckhenthuongKey> Members
		
		// member variable for the EntityId property
		private DmhinhthuckhenthuongKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public virtual DmhinhthuckhenthuongKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new DmhinhthuckhenthuongKey(this);
				}

				return _entityId;
			}
			set
			{
				if ( value != null )
				{
					value.Entity = this;
				}
				
				_entityId = value;
			}
		}
		
		#endregion
		
		#region EntityState
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false) , XmlIgnoreAttribute()]
		public override EntityState EntityState 
		{ 
			get{ return entityData.EntityState;	 } 
			set{ entityData.EntityState = value; } 
		}
		#endregion 
		
		#region EntityTrackingKey
		///<summary>
		/// Provides the tracking key for the <see cref="EntityLocator"/>
		///</summary>
		[XmlIgnore]
		public override string EntityTrackingKey
		{
			get
			{
				if(entityTrackingKey == null)
					entityTrackingKey = new System.Text.StringBuilder("Dmhinhthuckhenthuong")
					.Append("|").Append( this.IdHinhthucKhenthuong.ToString()).ToString();
				return entityTrackingKey;
			}
			set
		    {
		        if (value != null)
                    entityTrackingKey = value;
		    }
		}
		#endregion 
		
		#region ToString Method
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{4}{3}- IdHinhthucKhenthuong: {0}{3}- HinhthucKhenthuong: {1}{3}- Ghichu: {2}{3}", 
				this.IdHinhthucKhenthuong,
				this.HinhthucKhenthuong,
				(this.Ghichu == null) ? string.Empty : this.Ghichu.ToString(),
				System.Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'DMHINHTHUCKHENTHUONG' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal protected class DmhinhthuckhenthuongEntityData : ICloneable
	{
		#region Variable Declarations
		private EntityState currentEntityState = EntityState.Added;
		
		#region Primary key(s)
			/// <summary>			
			/// ID_HINHTHUC_KHENTHUONG : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "DMHINHTHUCKHENTHUONG"</remarks>
			public System.Int32 IdHinhthucKhenthuong;
				
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// HINHTHUC_KHENTHUONG : 
		/// </summary>
		public System.String		  HinhthucKhenthuong = string.Empty;
		
		/// <summary>
		/// GHICHU : 
		/// </summary>
		public System.String		  Ghichu = null;
		#endregion
			
		#region Source Foreign Key Property
				
		#endregion
		#endregion Variable Declarations
	
		#region Data Properties

		#region LskhenthuongCollection
		
		private TList<Lskhenthuong> lskhenthuongIdHinhthucKhenthuong;
		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation lskhenthuongIdHinhthucKhenthuong
		/// </summary>	
		public TList<Lskhenthuong> LskhenthuongCollection
		{
			get
			{
				if (lskhenthuongIdHinhthucKhenthuong == null)
				{
				lskhenthuongIdHinhthucKhenthuong = new TList<Lskhenthuong>();
				}
	
				return lskhenthuongIdHinhthucKhenthuong;
			}
			set { lskhenthuongIdHinhthucKhenthuong = value; }
		}
		
		#endregion

		#endregion Data Properties
		
		#region Clone Method

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public Object Clone()
		{
			DmhinhthuckhenthuongEntityData _tmp = new DmhinhthuckhenthuongEntityData();
						
			_tmp.IdHinhthucKhenthuong = this.IdHinhthucKhenthuong;
			
			_tmp.HinhthucKhenthuong = this.HinhthucKhenthuong;
			_tmp.Ghichu = this.Ghichu;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			//deep copy nested objects
			if (this.lskhenthuongIdHinhthucKhenthuong != null)
				_tmp.LskhenthuongCollection = (TList<Lskhenthuong>) MakeCopyOf(this.LskhenthuongCollection); 
			#endregion Child Collections
			
			//EntityState
			_tmp.EntityState = this.EntityState;
			
			return _tmp;
		}
		
		#endregion Clone Method
		
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public EntityState	EntityState
		{
			get { return currentEntityState;  }
			set { currentEntityState = value; }
		}
	
	}//End struct



		#endregion
		
				
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="DmhinhthuckhenthuongColumn"/> which has raised the event.</param>
		public void OnColumnChanging(DmhinhthuckhenthuongColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="DmhinhthuckhenthuongColumn"/> which has raised the event.</param>
		public void OnColumnChanged(DmhinhthuckhenthuongColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="DmhinhthuckhenthuongColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanging(DmhinhthuckhenthuongColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added && !EntityManager.TrackChangedEntities)
				EntityManager.StopTracking(entityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				DmhinhthuckhenthuongEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new DmhinhthuckhenthuongEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="DmhinhthuckhenthuongColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public void OnColumnChanged(DmhinhthuckhenthuongColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				DmhinhthuckhenthuongEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new DmhinhthuckhenthuongEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
			
	} // End Class
	
	
	#region DmhinhthuckhenthuongEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="Dmhinhthuckhenthuong"/> object.
	/// </remarks>
	public class DmhinhthuckhenthuongEventArgs : System.EventArgs
	{
		private DmhinhthuckhenthuongColumn column;
		private object value;
		
		///<summary>
		/// Initalizes a new Instance of the DmhinhthuckhenthuongEventArgs class.
		///</summary>
		public DmhinhthuckhenthuongEventArgs(DmhinhthuckhenthuongColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the DmhinhthuckhenthuongEventArgs class.
		///</summary>
		public DmhinhthuckhenthuongEventArgs(DmhinhthuckhenthuongColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		///<summary>
		/// The DmhinhthuckhenthuongColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="DmhinhthuckhenthuongColumn" />
		public DmhinhthuckhenthuongColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	///<summary>
	/// Define a delegate for all Dmhinhthuckhenthuong related events.
	///</summary>
	public delegate void DmhinhthuckhenthuongEventHandler(object sender, DmhinhthuckhenthuongEventArgs e);
	
	#region DmhinhthuckhenthuongComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class DmhinhthuckhenthuongComparer : System.Collections.Generic.IComparer<Dmhinhthuckhenthuong>
	{
		DmhinhthuckhenthuongColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:DmhinhthuckhenthuongComparer"/> class.
        /// </summary>
		public DmhinhthuckhenthuongComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DmhinhthuckhenthuongComparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public DmhinhthuckhenthuongComparer(DmhinhthuckhenthuongColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="Dmhinhthuckhenthuong"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="Dmhinhthuckhenthuong"/> to compare.</param>
        /// <param name="b">The second <c>Dmhinhthuckhenthuong</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(Dmhinhthuckhenthuong a, Dmhinhthuckhenthuong b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(Dmhinhthuckhenthuong entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(Dmhinhthuckhenthuong a, Dmhinhthuckhenthuong b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public DmhinhthuckhenthuongColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region DmhinhthuckhenthuongKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="Dmhinhthuckhenthuong"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class DmhinhthuckhenthuongKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongKey class.
		/// </summary>
		public DmhinhthuckhenthuongKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongKey class.
		/// </summary>
		public DmhinhthuckhenthuongKey(DmhinhthuckhenthuongBase entity)
		{
			this.Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.IdHinhthucKhenthuong = entity.IdHinhthucKhenthuong;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the DmhinhthuckhenthuongKey class.
		/// </summary>
		public DmhinhthuckhenthuongKey(System.Int32 idHinhthucKhenthuong)
		{
			#region Init Properties

			this.IdHinhthucKhenthuong = idHinhthucKhenthuong;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private DmhinhthuckhenthuongBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public DmhinhthuckhenthuongBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the IdHinhthucKhenthuong property
		private System.Int32 _idHinhthucKhenthuong;
		
		/// <summary>
		/// Gets or sets the IdHinhthucKhenthuong property.
		/// </summary>
		public System.Int32 IdHinhthucKhenthuong
		{
			get { return _idHinhthucKhenthuong; }
			set
			{
				if ( this.Entity != null )
					this.Entity.IdHinhthucKhenthuong = value;
				
				_idHinhthucKhenthuong = value;
			}
		}
		
		#endregion

		#region Methods
		
		/// <summary>
		/// Reads values from the supplied <see cref="IDictionary"/> object into
		/// properties of the current object.
		/// </summary>
		/// <param name="values">An <see cref="IDictionary"/> instance that contains
		/// the key/value pairs to be used as property values.</param>
		public override void Load(IDictionary values)
		{
			#region Init Properties

			if ( values != null )
			{
				IdHinhthucKhenthuong = ( values["IdHinhthucKhenthuong"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdHinhthucKhenthuong"], typeof(System.Int32)) : (int)0;
			}

			#endregion
		}

		/// <summary>
		/// Creates a new <see cref="IDictionary"/> object and populates it
		/// with the property values of the current object.
		/// </summary>
		/// <returns>A collection of name/value pairs.</returns>
		public override IDictionary ToDictionary()
		{
			IDictionary values = new Hashtable();

			#region Init Dictionary

			values.Add("IdHinhthucKhenthuong", IdHinhthucKhenthuong);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("IdHinhthucKhenthuong: {0}{1}",
								IdHinhthucKhenthuong,
								System.Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region DmhinhthuckhenthuongColumn Enum
	
	/// <summary>
	/// Enumerate the Dmhinhthuckhenthuong columns.
	/// </summary>
	[Serializable]
	public enum DmhinhthuckhenthuongColumn : int
	{
		/// <summary>
		/// IdHinhthucKhenthuong : 
		/// </summary>
		[EnumTextValue("ID_HINHTHUC_KHENTHUONG")]
		[ColumnEnum("ID_HINHTHUC_KHENTHUONG", typeof(System.Int32), System.Data.DbType.Int32, true, true, false)]
		IdHinhthucKhenthuong = 1,
		/// <summary>
		/// HinhthucKhenthuong : 
		/// </summary>
		[EnumTextValue("HINHTHUC_KHENTHUONG")]
		[ColumnEnum("HINHTHUC_KHENTHUONG", typeof(System.String), System.Data.DbType.String, false, false, false, 50)]
		HinhthucKhenthuong = 2,
		/// <summary>
		/// Ghichu : 
		/// </summary>
		[EnumTextValue("GHICHU")]
		[ColumnEnum("GHICHU", typeof(System.String), System.Data.DbType.String, false, false, true)]
		Ghichu = 3
	}//End enum

	#endregion DmhinhthuckhenthuongColumn Enum

} // end namespace
