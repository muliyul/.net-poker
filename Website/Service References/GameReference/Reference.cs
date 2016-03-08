﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Website.GameReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Player", Namespace="http://schemas.datacontract.org/2004/07/Service.Models")]
    [System.SerializableAttribute()]
    public partial class Player : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Website.GameReference.Game[] GamesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Website.GameReference.Game[] Games {
            get {
                return this.GamesField;
            }
            set {
                if ((object.ReferenceEquals(this.GamesField, value) != true)) {
                    this.GamesField = value;
                    this.RaisePropertyChanged("Games");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Game", Namespace="http://schemas.datacontract.org/2004/07/Service.Models")]
    [System.SerializableAttribute()]
    public partial class Game : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> BlackjacksField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime PlayedOnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Website.GameReference.Player PlayerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PlayerIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double WinningsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Blackjacks {
            get {
                return this.BlackjacksField;
            }
            set {
                if ((this.BlackjacksField.Equals(value) != true)) {
                    this.BlackjacksField = value;
                    this.RaisePropertyChanged("Blackjacks");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime PlayedOn {
            get {
                return this.PlayedOnField;
            }
            set {
                if ((this.PlayedOnField.Equals(value) != true)) {
                    this.PlayedOnField = value;
                    this.RaisePropertyChanged("PlayedOn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Website.GameReference.Player Player {
            get {
                return this.PlayerField;
            }
            set {
                if ((object.ReferenceEquals(this.PlayerField, value) != true)) {
                    this.PlayerField = value;
                    this.RaisePropertyChanged("Player");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PlayerId {
            get {
                return this.PlayerIdField;
            }
            set {
                if ((this.PlayerIdField.Equals(value) != true)) {
                    this.PlayerIdField = value;
                    this.RaisePropertyChanged("PlayerId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Winnings {
            get {
                return this.WinningsField;
            }
            set {
                if ((this.WinningsField.Equals(value) != true)) {
                    this.WinningsField = value;
                    this.RaisePropertyChanged("Winnings");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Table", Namespace="http://schemas.datacontract.org/2004/07/Shared")]
    [System.SerializableAttribute()]
    public partial class Table : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Website.GameReference.Player1[] PlayersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PotField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Website.GameReference.Player1[] Players {
            get {
                return this.PlayersField;
            }
            set {
                if ((object.ReferenceEquals(this.PlayersField, value) != true)) {
                    this.PlayersField = value;
                    this.RaisePropertyChanged("Players");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Pot {
            get {
                return this.PotField;
            }
            set {
                if ((this.PotField.Equals(value) != true)) {
                    this.PotField = value;
                    this.RaisePropertyChanged("Pot");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Player", Namespace="http://schemas.datacontract.org/2004/07/Shared")]
    [System.SerializableAttribute()]
    public partial class Player1 : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double BankField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime MemberSinceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Bank {
            get {
                return this.BankField;
            }
            set {
                if ((this.BankField.Equals(value) != true)) {
                    this.BankField = value;
                    this.RaisePropertyChanged("Bank");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime MemberSince {
            get {
                return this.MemberSinceField;
            }
            set {
                if ((this.MemberSinceField.Equals(value) != true)) {
                    this.MemberSinceField = value;
                    this.RaisePropertyChanged("MemberSince");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Card", Namespace="http://schemas.datacontract.org/2004/07/Shared")]
    [System.SerializableAttribute()]
    public partial class Card : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Website.GameReference.Face FaceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Website.GameReference.Suit SuitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Website.GameReference.Face Face {
            get {
                return this.FaceField;
            }
            set {
                if ((this.FaceField.Equals(value) != true)) {
                    this.FaceField = value;
                    this.RaisePropertyChanged("Face");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Website.GameReference.Suit Suit {
            get {
                return this.SuitField;
            }
            set {
                if ((this.SuitField.Equals(value) != true)) {
                    this.SuitField = value;
                    this.RaisePropertyChanged("Suit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Value {
            get {
                return this.ValueField;
            }
            set {
                if ((this.ValueField.Equals(value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Face", Namespace="http://schemas.datacontract.org/2004/07/Shared")]
    public enum Face : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Two = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Three = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Four = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Five = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Six = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Seven = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Eight = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Nine = 9,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Ten = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Jack = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Queen = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        King = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Ace = 11,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Suit", Namespace="http://schemas.datacontract.org/2004/07/Shared")]
    public enum Suit : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Spades = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Hearts = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Clubs = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Diamonds = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GameReference.IGame")]
    public interface IGame {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/Register", ReplyAction="http://tempuri.org/IGame/RegisterResponse")]
        void Register(string username, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/Register", ReplyAction="http://tempuri.org/IGame/RegisterResponse")]
        System.Threading.Tasks.Task RegisterAsync(string username, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/Login", ReplyAction="http://tempuri.org/IGame/LoginResponse")]
        Website.GameReference.Player Login(string username, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/Login", ReplyAction="http://tempuri.org/IGame/LoginResponse")]
        System.Threading.Tasks.Task<Website.GameReference.Player> LoginAsync(string username, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/GetPlayerInfo", ReplyAction="http://tempuri.org/IGame/GetPlayerInfoResponse")]
        Website.GameReference.Player GetPlayerInfo(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/GetPlayerInfo", ReplyAction="http://tempuri.org/IGame/GetPlayerInfoResponse")]
        System.Threading.Tasks.Task<Website.GameReference.Player> GetPlayerInfoAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/ListTables", ReplyAction="http://tempuri.org/IGame/ListTablesResponse")]
        Website.GameReference.Table[] ListTables();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/ListTables", ReplyAction="http://tempuri.org/IGame/ListTablesResponse")]
        System.Threading.Tasks.Task<Website.GameReference.Table[]> ListTablesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/CreateTable", ReplyAction="http://tempuri.org/IGame/CreateTableResponse")]
        Website.GameReference.Table CreateTable();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/CreateTable", ReplyAction="http://tempuri.org/IGame/CreateTableResponse")]
        System.Threading.Tasks.Task<Website.GameReference.Table> CreateTableAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/JoinTable", ReplyAction="http://tempuri.org/IGame/JoinTableResponse")]
        Website.GameReference.Table JoinTable(string tableId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/JoinTable", ReplyAction="http://tempuri.org/IGame/JoinTableResponse")]
        System.Threading.Tasks.Task<Website.GameReference.Table> JoinTableAsync(string tableId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/Leave")]
        void Leave();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/Leave")]
        System.Threading.Tasks.Task LeaveAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/Bet")]
        void Bet(int amount);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/Bet")]
        System.Threading.Tasks.Task BetAsync(int amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/Hit", ReplyAction="http://tempuri.org/IGame/HitResponse")]
        Website.GameReference.Card Hit();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/Hit", ReplyAction="http://tempuri.org/IGame/HitResponse")]
        System.Threading.Tasks.Task<Website.GameReference.Card> HitAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/Fold")]
        void Fold();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/Fold")]
        System.Threading.Tasks.Task FoldAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameChannel : Website.GameReference.IGame, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GameClient : System.ServiceModel.ClientBase<Website.GameReference.IGame>, Website.GameReference.IGame {
        
        public GameClient() {
        }
        
        public GameClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GameClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GameClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GameClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Register(string username, string pass) {
            base.Channel.Register(username, pass);
        }
        
        public System.Threading.Tasks.Task RegisterAsync(string username, string pass) {
            return base.Channel.RegisterAsync(username, pass);
        }
        
        public Website.GameReference.Player Login(string username, string pass) {
            return base.Channel.Login(username, pass);
        }
        
        public System.Threading.Tasks.Task<Website.GameReference.Player> LoginAsync(string username, string pass) {
            return base.Channel.LoginAsync(username, pass);
        }
        
        public Website.GameReference.Player GetPlayerInfo(string username) {
            return base.Channel.GetPlayerInfo(username);
        }
        
        public System.Threading.Tasks.Task<Website.GameReference.Player> GetPlayerInfoAsync(string username) {
            return base.Channel.GetPlayerInfoAsync(username);
        }
        
        public Website.GameReference.Table[] ListTables() {
            return base.Channel.ListTables();
        }
        
        public System.Threading.Tasks.Task<Website.GameReference.Table[]> ListTablesAsync() {
            return base.Channel.ListTablesAsync();
        }
        
        public Website.GameReference.Table CreateTable() {
            return base.Channel.CreateTable();
        }
        
        public System.Threading.Tasks.Task<Website.GameReference.Table> CreateTableAsync() {
            return base.Channel.CreateTableAsync();
        }
        
        public Website.GameReference.Table JoinTable(string tableId) {
            return base.Channel.JoinTable(tableId);
        }
        
        public System.Threading.Tasks.Task<Website.GameReference.Table> JoinTableAsync(string tableId) {
            return base.Channel.JoinTableAsync(tableId);
        }
        
        public void Leave() {
            base.Channel.Leave();
        }
        
        public System.Threading.Tasks.Task LeaveAsync() {
            return base.Channel.LeaveAsync();
        }
        
        public void Bet(int amount) {
            base.Channel.Bet(amount);
        }
        
        public System.Threading.Tasks.Task BetAsync(int amount) {
            return base.Channel.BetAsync(amount);
        }
        
        public Website.GameReference.Card Hit() {
            return base.Channel.Hit();
        }
        
        public System.Threading.Tasks.Task<Website.GameReference.Card> HitAsync() {
            return base.Channel.HitAsync();
        }
        
        public void Fold() {
            base.Channel.Fold();
        }
        
        public System.Threading.Tasks.Task FoldAsync() {
            return base.Channel.FoldAsync();
        }
    }
}
