﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blackjack.GameReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PlayerData", Namespace="http://schemas.datacontract.org/2004/07/Service.Models")]
    [System.SerializableAttribute()]
    public partial class PlayerData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double BankField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal BetField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GuidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Blackjack.GameReference.Card[] HandField;
        
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
        public decimal Bet {
            get {
                return this.BetField;
            }
            set {
                if ((this.BetField.Equals(value) != true)) {
                    this.BetField = value;
                    this.RaisePropertyChanged("Bet");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Guid {
            get {
                return this.GuidField;
            }
            set {
                if ((object.ReferenceEquals(this.GuidField, value) != true)) {
                    this.GuidField = value;
                    this.RaisePropertyChanged("Guid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Blackjack.GameReference.Card[] Hand {
            get {
                return this.HandField;
            }
            set {
                if ((object.ReferenceEquals(this.HandField, value) != true)) {
                    this.HandField = value;
                    this.RaisePropertyChanged("Hand");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Card", Namespace="http://schemas.datacontract.org/2004/07/Service.Models")]
    [System.SerializableAttribute()]
    public partial class Card : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Blackjack.GameReference.Face FaceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsCardUpField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Blackjack.GameReference.Suit SuitField;
        
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
        public Blackjack.GameReference.Face Face {
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
        public bool IsCardUp {
            get {
                return this.IsCardUpField;
            }
            set {
                if ((this.IsCardUpField.Equals(value) != true)) {
                    this.IsCardUpField = value;
                    this.RaisePropertyChanged("IsCardUp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Blackjack.GameReference.Suit Suit {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Face", Namespace="http://schemas.datacontract.org/2004/07/Service.Models")]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Suit", Namespace="http://schemas.datacontract.org/2004/07/Service.Models")]
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Table", Namespace="http://schemas.datacontract.org/2004/07/Service.Models")]
    [System.SerializableAttribute()]
    public partial class Table : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Blackjack.GameReference.PlayerData[] PlayersField;
        
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
        public Blackjack.GameReference.PlayerData[] Players {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="GameArgs", Namespace="http://schemas.datacontract.org/2004/07/Service")]
    [System.SerializableAttribute()]
    public partial class GameArgs : System.EventArgs, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal AmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Blackjack.GameReference.Card CardField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Blackjack.GameReference.PlayerData PlayerField;
        
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
        public decimal Amount {
            get {
                return this.AmountField;
            }
            set {
                if ((this.AmountField.Equals(value) != true)) {
                    this.AmountField = value;
                    this.RaisePropertyChanged("Amount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Blackjack.GameReference.Card Card {
            get {
                return this.CardField;
            }
            set {
                if ((object.ReferenceEquals(this.CardField, value) != true)) {
                    this.CardField = value;
                    this.RaisePropertyChanged("Card");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Blackjack.GameReference.PlayerData Player {
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GameReference.IGame", CallbackContract=typeof(Blackjack.GameReference.IGameCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IGame {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/Register", ReplyAction="http://tempuri.org/IGame/RegisterResponse")]
        void Register(string username, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/Register", ReplyAction="http://tempuri.org/IGame/RegisterResponse")]
        System.Threading.Tasks.Task RegisterAsync(string username, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/Login", ReplyAction="http://tempuri.org/IGame/LoginResponse")]
        Blackjack.GameReference.PlayerData Login(string username, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/Login", ReplyAction="http://tempuri.org/IGame/LoginResponse")]
        System.Threading.Tasks.Task<Blackjack.GameReference.PlayerData> LoginAsync(string username, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/GetPlayerInfo", ReplyAction="http://tempuri.org/IGame/GetPlayerInfoResponse")]
        Blackjack.GameReference.PlayerData GetPlayerInfo(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/GetPlayerInfo", ReplyAction="http://tempuri.org/IGame/GetPlayerInfoResponse")]
        System.Threading.Tasks.Task<Blackjack.GameReference.PlayerData> GetPlayerInfoAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/ListTables", ReplyAction="http://tempuri.org/IGame/ListTablesResponse")]
        Blackjack.GameReference.Table[] ListTables();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/ListTables", ReplyAction="http://tempuri.org/IGame/ListTablesResponse")]
        System.Threading.Tasks.Task<Blackjack.GameReference.Table[]> ListTablesAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/CreateTable")]
        void CreateTable();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/CreateTable")]
        System.Threading.Tasks.Task CreateTableAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/JoinTable", ReplyAction="http://tempuri.org/IGame/JoinTableResponse")]
        Blackjack.GameReference.Table JoinTable(int tableIndex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/JoinTable", ReplyAction="http://tempuri.org/IGame/JoinTableResponse")]
        System.Threading.Tasks.Task<Blackjack.GameReference.Table> JoinTableAsync(int tableIndex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/PlayerReady", ReplyAction="http://tempuri.org/IGame/PlayerReadyResponse")]
        Blackjack.GameReference.Table PlayerReady(string tableId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/PlayerReady", ReplyAction="http://tempuri.org/IGame/PlayerReadyResponse")]
        System.Threading.Tasks.Task<Blackjack.GameReference.Table> PlayerReadyAsync(string tableId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/Leave")]
        void Leave();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/Leave")]
        System.Threading.Tasks.Task LeaveAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/Bet")]
        void Bet(decimal amount);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/Bet")]
        System.Threading.Tasks.Task BetAsync(decimal amount);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/Hit")]
        void Hit();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/Hit")]
        System.Threading.Tasks.Task HitAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/Fold")]
        void Fold();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/Fold")]
        System.Threading.Tasks.Task FoldAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/OnJoin", ReplyAction="http://tempuri.org/IGame/OnJoinResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.PlayerData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Card[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Card))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Face))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Suit))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Table[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Table))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.PlayerData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.GameArgs))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.EventArgs))]
        void OnJoin(object sender, Blackjack.GameReference.GameArgs e);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/OnLeave", ReplyAction="http://tempuri.org/IGame/OnLeaveResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.PlayerData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Card[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Card))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Face))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Suit))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Table[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Table))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.PlayerData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.GameArgs))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.EventArgs))]
        void OnLeave(object sender, Blackjack.GameReference.GameArgs e);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/OnHit", ReplyAction="http://tempuri.org/IGame/OnHitResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.PlayerData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Card[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Card))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Face))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Suit))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Table[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Table))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.PlayerData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.GameArgs))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.EventArgs))]
        void OnHit(object sender, Blackjack.GameReference.GameArgs e);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/OnBet", ReplyAction="http://tempuri.org/IGame/OnBetResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.PlayerData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Card[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Card))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Face))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Suit))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Table[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Table))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.PlayerData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.GameArgs))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.EventArgs))]
        void OnBet(object sender, Blackjack.GameReference.GameArgs e);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/OnFold", ReplyAction="http://tempuri.org/IGame/OnFoldResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.PlayerData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Card[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Card))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Face))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Suit))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Table[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Table))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.PlayerData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.GameArgs))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.EventArgs))]
        void OnFold(object sender, Blackjack.GameReference.GameArgs e);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/OnNextTurn", ReplyAction="http://tempuri.org/IGame/OnNextTurnResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.PlayerData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Card[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Card))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Face))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Suit))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Table[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Table))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.PlayerData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.GameArgs))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.EventArgs))]
        void OnNextTurn(object sender, Blackjack.GameReference.GameArgs e);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/OnDeal", ReplyAction="http://tempuri.org/IGame/OnDealResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.PlayerData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Card[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Card))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Face))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Suit))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Table[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Table))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.PlayerData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.GameArgs))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.EventArgs))]
        void OnDeal(object sender, Blackjack.GameReference.GameArgs e);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGame/OnNewTableCreated")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.PlayerData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Card[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Card))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Face))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Suit))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Table[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.Table))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.PlayerData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Blackjack.GameReference.GameArgs))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.EventArgs))]
        void OnNewTableCreated(object sender, Blackjack.GameReference.Table[] tableList);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameChannel : Blackjack.GameReference.IGame, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GameClient : System.ServiceModel.DuplexClientBase<Blackjack.GameReference.IGame>, Blackjack.GameReference.IGame {
        
        public GameClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public GameClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public GameClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GameClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GameClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Register(string username, string pass) {
            base.Channel.Register(username, pass);
        }
        
        public System.Threading.Tasks.Task RegisterAsync(string username, string pass) {
            return base.Channel.RegisterAsync(username, pass);
        }
        
        public Blackjack.GameReference.PlayerData Login(string username, string pass) {
            return base.Channel.Login(username, pass);
        }
        
        public System.Threading.Tasks.Task<Blackjack.GameReference.PlayerData> LoginAsync(string username, string pass) {
            return base.Channel.LoginAsync(username, pass);
        }
        
        public Blackjack.GameReference.PlayerData GetPlayerInfo(string username) {
            return base.Channel.GetPlayerInfo(username);
        }
        
        public System.Threading.Tasks.Task<Blackjack.GameReference.PlayerData> GetPlayerInfoAsync(string username) {
            return base.Channel.GetPlayerInfoAsync(username);
        }
        
        public Blackjack.GameReference.Table[] ListTables() {
            return base.Channel.ListTables();
        }
        
        public System.Threading.Tasks.Task<Blackjack.GameReference.Table[]> ListTablesAsync() {
            return base.Channel.ListTablesAsync();
        }
        
        public void CreateTable() {
            base.Channel.CreateTable();
        }
        
        public System.Threading.Tasks.Task CreateTableAsync() {
            return base.Channel.CreateTableAsync();
        }
        
        public Blackjack.GameReference.Table JoinTable(int tableIndex) {
            return base.Channel.JoinTable(tableIndex);
        }
        
        public System.Threading.Tasks.Task<Blackjack.GameReference.Table> JoinTableAsync(int tableIndex) {
            return base.Channel.JoinTableAsync(tableIndex);
        }
        
        public Blackjack.GameReference.Table PlayerReady(string tableId) {
            return base.Channel.PlayerReady(tableId);
        }
        
        public System.Threading.Tasks.Task<Blackjack.GameReference.Table> PlayerReadyAsync(string tableId) {
            return base.Channel.PlayerReadyAsync(tableId);
        }
        
        public void Leave() {
            base.Channel.Leave();
        }
        
        public System.Threading.Tasks.Task LeaveAsync() {
            return base.Channel.LeaveAsync();
        }
        
        public void Bet(decimal amount) {
            base.Channel.Bet(amount);
        }
        
        public System.Threading.Tasks.Task BetAsync(decimal amount) {
            return base.Channel.BetAsync(amount);
        }
        
        public void Hit() {
            base.Channel.Hit();
        }
        
        public System.Threading.Tasks.Task HitAsync() {
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
