﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFClient.GameReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Player", Namespace="http://schemas.datacontract.org/2004/07/Blackjack.Objects")]
    [System.SerializableAttribute()]
    public partial class Player : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long BankField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WPFClient.GameReference.Game[] GamesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
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
        public long Bank {
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
        public WPFClient.GameReference.Game[] Games {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Game", Namespace="http://schemas.datacontract.org/2004/07/Blackjack.Objects")]
    [System.SerializableAttribute()]
    public partial class Game : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> EarningsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WPFClient.GameReference.Player PlayerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> PlayerIdField;
        
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
        public System.Nullable<long> Earnings {
            get {
                return this.EarningsField;
            }
            set {
                if ((this.EarningsField.Equals(value) != true)) {
                    this.EarningsField = value;
                    this.RaisePropertyChanged("Earnings");
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
        public WPFClient.GameReference.Player Player {
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
        public System.Nullable<int> PlayerId {
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GameReference.IGame", SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IGame {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/Register", ReplyAction="http://tempuri.org/IGame/RegisterResponse")]
        void Register(string username, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/Register", ReplyAction="http://tempuri.org/IGame/RegisterResponse")]
        System.Threading.Tasks.Task RegisterAsync(string username, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/Login", ReplyAction="http://tempuri.org/IGame/LoginResponse")]
        WPFClient.GameReference.Player Login(string username, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/Login", ReplyAction="http://tempuri.org/IGame/LoginResponse")]
        System.Threading.Tasks.Task<WPFClient.GameReference.Player> LoginAsync(string username, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/GetPlayerInfo", ReplyAction="http://tempuri.org/IGame/GetPlayerInfoResponse")]
        WPFClient.GameReference.Player GetPlayerInfo(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGame/GetPlayerInfo", ReplyAction="http://tempuri.org/IGame/GetPlayerInfoResponse")]
        System.Threading.Tasks.Task<WPFClient.GameReference.Player> GetPlayerInfoAsync(string username);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameChannel : WPFClient.GameReference.IGame, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GameClient : System.ServiceModel.ClientBase<WPFClient.GameReference.IGame>, WPFClient.GameReference.IGame {
        
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
        
        public WPFClient.GameReference.Player Login(string username, string pass) {
            return base.Channel.Login(username, pass);
        }
        
        public System.Threading.Tasks.Task<WPFClient.GameReference.Player> LoginAsync(string username, string pass) {
            return base.Channel.LoginAsync(username, pass);
        }
        
        public WPFClient.GameReference.Player GetPlayerInfo(string username) {
            return base.Channel.GetPlayerInfo(username);
        }
        
        public System.Threading.Tasks.Task<WPFClient.GameReference.Player> GetPlayerInfoAsync(string username) {
            return base.Channel.GetPlayerInfoAsync(username);
        }
    }
}