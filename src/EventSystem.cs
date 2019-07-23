using EventSystem.structure;
using EventSystem.structure.api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace EventSystem.src
{
    class Event
    {

        #region Defenitions
        private Dictionary<String, User> _users;
        public delegate void AccountCreate(object source, UserEvents e);
        public event AccountCreate OnAccountCreate;
        private const string END_POINT = "https://randomuser.me/api/";
        #endregion

        #region Constructor
        public Event()
        {
            this._users = new Dictionary<string, User>();
        }
        #endregion

        #region Methods
        public void Create(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                User account = this._fetchAccountsSync();
                this.createUser(account.Name(), account.LastName(), account.Age());
                OnAccountCreate?.Invoke(this, new UserEvents(account));
            }
        }

        private User _fetchAccountsSync()
        {
            HttpWebRequest request = WebRequest.Create(END_POINT) as HttpWebRequest;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK) throw new Exception(string.Concat("Server error {0}: {1}", response.StatusCode, response.StatusDescription));
              

                Stream stream = response.GetResponseStream();

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(UserResponseJson));
                UserResponseJson account = (UserResponseJson)serializer.ReadObject(stream);

                if (account == null) throw new Exception(string.Concat("Unable to find account from api"));

                UserObject first = (account).results.First();

                return new User(first.Name.name, first.Name.last, first.Dob.age);
            }
        }

        public void createUser(string name, string lastName, int age)
        {
            this._users.TryAdd(name, new User(name, lastName, age));
        }

        public List<String> fetchAllSync()
        {
            return this._users.Select(user => user.Key).ToList();
        }

        #endregion

        #region starter 

        public void start(int amount)
        {
            this.OnAccountCreate += Event_OnAccountCreate;
            this.Create(amount);
        }

        private void Event_OnAccountCreate(Object source, UserEvents e)
        {
            User user = e.User();
            Console.WriteLine(string.Format("New user created ! With the name: {0} and age: {1}", user.getFullName(), user.Age()));
        }

        #endregion
    }
}
