using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EventSystem.structure.api
{
    #region Classes

    [DataContract()]
    class UserObject
    {
        [DataMember(Name = "gender")]
        public string Gender { get; set; }
        [DataMember(Name = "name")]
        public NameObject Name { get; set; }
        [DataMember(Name = "dob")]
        public DobObject Dob { get; set; }

        public UserObject(string gender, NameObject nameObj, DobObject dobObject)
        {
            this.Gender = gender;
            this.Name = nameObj;
            this.Dob = dobObject;
        }

    }

    [DataContract()]
    class UserResponseJson
    {
        [DataMember(Name = "results")]
        public List<UserObject> results;

        public UserResponseJson(List<UserObject> res)
        {
            this.results = res;
        }

    }

    #endregion

    #region Structures
    [DataContract()]
    struct DobObject
    {
        [DataMember(Name = "date")]
        public string date { get; set; }
        [DataMember(Name = "age")]
        public int age { get; set; }
    }

    [DataContract()]
    struct NameObject
    {
        [DataMember(Name = "title")]
        public string title { get; set; }
        [DataMember(Name = "first")]
        public string name { get; set; }
        [DataMember(Name = "last")]
        public string last { get; set; }

    }
    #endregion
}
