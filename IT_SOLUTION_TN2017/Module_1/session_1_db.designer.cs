﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Module_1
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="session1")]
	public partial class session_1_dbDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCountry(Country instance);
    partial void UpdateCountry(Country instance);
    partial void DeleteCountry(Country instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertOffice(Office instance);
    partial void UpdateOffice(Office instance);
    partial void DeleteOffice(Office instance);
    partial void InsertRole(Role instance);
    partial void UpdateRole(Role instance);
    partial void DeleteRole(Role instance);
    partial void InsertTimeOnSystem(TimeOnSystem instance);
    partial void UpdateTimeOnSystem(TimeOnSystem instance);
    partial void DeleteTimeOnSystem(TimeOnSystem instance);
    #endregion
		
		public session_1_dbDataContext() : 
				base(global::Module_1.Properties.Settings.Default.session1ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public session_1_dbDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public session_1_dbDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public session_1_dbDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public session_1_dbDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Country> Countries
		{
			get
			{
				return this.GetTable<Country>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Office> Offices
		{
			get
			{
				return this.GetTable<Office>();
			}
		}
		
		public System.Data.Linq.Table<Role> Roles
		{
			get
			{
				return this.GetTable<Role>();
			}
		}
		
		public System.Data.Linq.Table<TimeOnSystem> TimeOnSystems
		{
			get
			{
				return this.GetTable<TimeOnSystem>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Countries")]
	public partial class Country : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Name;
		
		private EntitySet<Office> _Offices;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Country()
		{
			this._Offices = new EntitySet<Office>(new Action<Office>(this.attach_Offices), new Action<Office>(this.detach_Offices));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Country_Office", Storage="_Offices", ThisKey="ID", OtherKey="CountryID")]
		public EntitySet<Office> Offices
		{
			get
			{
				return this._Offices;
			}
			set
			{
				this._Offices.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Offices(Office entity)
		{
			this.SendPropertyChanging();
			entity.Country = this;
		}
		
		private void detach_Offices(Office entity)
		{
			this.SendPropertyChanging();
			entity.Country = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _RoleID;
		
		private string _Email;
		
		private string _Password;
		
		private string _FirstName;
		
		private string _LastName;
		
		private System.Nullable<int> _OfficeID;
		
		private System.Nullable<System.DateTime> _Birthdate;
		
		private System.Nullable<bool> _Active;
		
		private EntitySet<TimeOnSystem> _TimeOnSystems;
		
		private EntityRef<Office> _Office;
		
		private EntityRef<Role> _Role;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnRoleIDChanging(int value);
    partial void OnRoleIDChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnOfficeIDChanging(System.Nullable<int> value);
    partial void OnOfficeIDChanged();
    partial void OnBirthdateChanging(System.Nullable<System.DateTime> value);
    partial void OnBirthdateChanged();
    partial void OnActiveChanging(System.Nullable<bool> value);
    partial void OnActiveChanged();
    #endregion
		
		public User()
		{
			this._TimeOnSystems = new EntitySet<TimeOnSystem>(new Action<TimeOnSystem>(this.attach_TimeOnSystems), new Action<TimeOnSystem>(this.detach_TimeOnSystems));
			this._Office = default(EntityRef<Office>);
			this._Role = default(EntityRef<Role>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleID", DbType="Int NOT NULL")]
		public int RoleID
		{
			get
			{
				return this._RoleID;
			}
			set
			{
				if ((this._RoleID != value))
				{
					if (this._Role.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnRoleIDChanging(value);
					this.SendPropertyChanging();
					this._RoleID = value;
					this.SendPropertyChanged("RoleID");
					this.OnRoleIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50)")]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OfficeID", DbType="Int")]
		public System.Nullable<int> OfficeID
		{
			get
			{
				return this._OfficeID;
			}
			set
			{
				if ((this._OfficeID != value))
				{
					if (this._Office.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnOfficeIDChanging(value);
					this.SendPropertyChanging();
					this._OfficeID = value;
					this.SendPropertyChanged("OfficeID");
					this.OnOfficeIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Birthdate", DbType="Date")]
		public System.Nullable<System.DateTime> Birthdate
		{
			get
			{
				return this._Birthdate;
			}
			set
			{
				if ((this._Birthdate != value))
				{
					this.OnBirthdateChanging(value);
					this.SendPropertyChanging();
					this._Birthdate = value;
					this.SendPropertyChanged("Birthdate");
					this.OnBirthdateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", DbType="Bit")]
		public System.Nullable<bool> Active
		{
			get
			{
				return this._Active;
			}
			set
			{
				if ((this._Active != value))
				{
					this.OnActiveChanging(value);
					this.SendPropertyChanging();
					this._Active = value;
					this.SendPropertyChanged("Active");
					this.OnActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_TimeOnSystem", Storage="_TimeOnSystems", ThisKey="ID", OtherKey="UserID")]
		public EntitySet<TimeOnSystem> TimeOnSystems
		{
			get
			{
				return this._TimeOnSystems;
			}
			set
			{
				this._TimeOnSystems.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Office_User", Storage="_Office", ThisKey="OfficeID", OtherKey="ID", IsForeignKey=true)]
		public Office Office
		{
			get
			{
				return this._Office.Entity;
			}
			set
			{
				Office previousValue = this._Office.Entity;
				if (((previousValue != value) 
							|| (this._Office.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Office.Entity = null;
						previousValue.Users.Remove(this);
					}
					this._Office.Entity = value;
					if ((value != null))
					{
						value.Users.Add(this);
						this._OfficeID = value.ID;
					}
					else
					{
						this._OfficeID = default(Nullable<int>);
					}
					this.SendPropertyChanged("Office");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Role_User", Storage="_Role", ThisKey="RoleID", OtherKey="ID", IsForeignKey=true)]
		public Role Role
		{
			get
			{
				return this._Role.Entity;
			}
			set
			{
				Role previousValue = this._Role.Entity;
				if (((previousValue != value) 
							|| (this._Role.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Role.Entity = null;
						previousValue.Users.Remove(this);
					}
					this._Role.Entity = value;
					if ((value != null))
					{
						value.Users.Add(this);
						this._RoleID = value.ID;
					}
					else
					{
						this._RoleID = default(int);
					}
					this.SendPropertyChanged("Role");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_TimeOnSystems(TimeOnSystem entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_TimeOnSystems(TimeOnSystem entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Offices")]
	public partial class Office : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _CountryID;
		
		private string _Title;
		
		private string _Phone;
		
		private string _Contact;
		
		private EntitySet<User> _Users;
		
		private EntityRef<Country> _Country;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnCountryIDChanging(int value);
    partial void OnCountryIDChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnContactChanging(string value);
    partial void OnContactChanged();
    #endregion
		
		public Office()
		{
			this._Users = new EntitySet<User>(new Action<User>(this.attach_Users), new Action<User>(this.detach_Users));
			this._Country = default(EntityRef<Country>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountryID", DbType="Int NOT NULL")]
		public int CountryID
		{
			get
			{
				return this._CountryID;
			}
			set
			{
				if ((this._CountryID != value))
				{
					if (this._Country.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCountryIDChanging(value);
					this.SendPropertyChanging();
					this._CountryID = value;
					this.SendPropertyChanged("CountryID");
					this.OnCountryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Contact", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string Contact
		{
			get
			{
				return this._Contact;
			}
			set
			{
				if ((this._Contact != value))
				{
					this.OnContactChanging(value);
					this.SendPropertyChanging();
					this._Contact = value;
					this.SendPropertyChanged("Contact");
					this.OnContactChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Office_User", Storage="_Users", ThisKey="ID", OtherKey="OfficeID")]
		public EntitySet<User> Users
		{
			get
			{
				return this._Users;
			}
			set
			{
				this._Users.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Country_Office", Storage="_Country", ThisKey="CountryID", OtherKey="ID", IsForeignKey=true)]
		public Country Country
		{
			get
			{
				return this._Country.Entity;
			}
			set
			{
				Country previousValue = this._Country.Entity;
				if (((previousValue != value) 
							|| (this._Country.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Country.Entity = null;
						previousValue.Offices.Remove(this);
					}
					this._Country.Entity = value;
					if ((value != null))
					{
						value.Offices.Add(this);
						this._CountryID = value.ID;
					}
					else
					{
						this._CountryID = default(int);
					}
					this.SendPropertyChanged("Country");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Users(User entity)
		{
			this.SendPropertyChanging();
			entity.Office = this;
		}
		
		private void detach_Users(User entity)
		{
			this.SendPropertyChanging();
			entity.Office = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Roles")]
	public partial class Role : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Title;
		
		private EntitySet<User> _Users;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    #endregion
		
		public Role()
		{
			this._Users = new EntitySet<User>(new Action<User>(this.attach_Users), new Action<User>(this.detach_Users));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Role_User", Storage="_Users", ThisKey="ID", OtherKey="RoleID")]
		public EntitySet<User> Users
		{
			get
			{
				return this._Users;
			}
			set
			{
				this._Users.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Users(User entity)
		{
			this.SendPropertyChanging();
			entity.Role = this;
		}
		
		private void detach_Users(User entity)
		{
			this.SendPropertyChanging();
			entity.Role = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TimeOnSystem")]
	public partial class TimeOnSystem : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private System.DateTime _Date;
		
		private string _Login;
		
		private string _Logout;
		
		private string _SumTime;
		
		private string _Reason;
		
		private int _UserID;
		
		private EntityRef<User> _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    partial void OnLoginChanging(string value);
    partial void OnLoginChanged();
    partial void OnLogoutChanging(string value);
    partial void OnLogoutChanged();
    partial void OnSumTimeChanging(string value);
    partial void OnSumTimeChanged();
    partial void OnReasonChanging(string value);
    partial void OnReasonChanged();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    #endregion
		
		public TimeOnSystem()
		{
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="Date NOT NULL")]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Login", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Login
		{
			get
			{
				return this._Login;
			}
			set
			{
				if ((this._Login != value))
				{
					this.OnLoginChanging(value);
					this.SendPropertyChanging();
					this._Login = value;
					this.SendPropertyChanged("Login");
					this.OnLoginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Logout", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Logout
		{
			get
			{
				return this._Logout;
			}
			set
			{
				if ((this._Logout != value))
				{
					this.OnLogoutChanging(value);
					this.SendPropertyChanging();
					this._Logout = value;
					this.SendPropertyChanged("Logout");
					this.OnLogoutChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SumTime", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string SumTime
		{
			get
			{
				return this._SumTime;
			}
			set
			{
				if ((this._SumTime != value))
				{
					this.OnSumTimeChanging(value);
					this.SendPropertyChanging();
					this._SumTime = value;
					this.SendPropertyChanged("SumTime");
					this.OnSumTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Reason", DbType="NChar(50)")]
		public string Reason
		{
			get
			{
				return this._Reason;
			}
			set
			{
				if ((this._Reason != value))
				{
					this.OnReasonChanging(value);
					this.SendPropertyChanging();
					this._Reason = value;
					this.SendPropertyChanged("Reason");
					this.OnReasonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int NOT NULL")]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_TimeOnSystem", Storage="_User", ThisKey="UserID", OtherKey="ID", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.TimeOnSystems.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.TimeOnSystems.Add(this);
						this._UserID = value.ID;
					}
					else
					{
						this._UserID = default(int);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591