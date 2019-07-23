using System;
using System.Collections.Generic;
using System.Text;

namespace EventSystem.structure
{
    #region Classes
    class User
    {

        #region Defenitions
        private string _name;
        private string _lastName;
        private int _age;
        #endregion

        #region Constructor overloads
        public User(string name, string lastName, int age)
        {
            this._name = name;
            this._lastName = lastName;
            this._age = age;
        }
        #endregion

        #region Getters and Setters
        public string Name()
        {
            return this._name;
        }

        public string LastName()
        {
            return this._lastName;
        }

        public int Age()
        {
            return this._age;
        }

        public string getFullName()
        {
            return string.Concat(this._name, this._lastName);
        }

        public User setName(string name)
        {
            this._name = name;
            return this;
        }

        public User setLastName(string lastName)
        {
            this._lastName = lastName;
            return this;
        }

        public User setAge(int age)
        {
            this._age = age;
            return this;
        }

        #endregion


    }
    #endregion

    #region Events
    class UserEvents : EventArgs
    {
        #region Event Args
        
        private readonly string _message;
        private readonly User _user;
        #endregion

        #region Constructor overloads
        public UserEvents(User user, string message)
        {
            this._user = user;
            this._message = message;
        }

        public UserEvents(User user)
        {
            this._user = user;
            this._message = "NO_MESSAGE_SET";
        }

        #endregion

        #region Getters
        public User User()
        {
            return this._user;
        }

        public string Message()
        {
            return this._message;
        }
        #endregion
    }
    #endregion
}
