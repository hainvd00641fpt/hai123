using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Entity
{
    class Member
    {
        private string _id;
        private String _firstName;
        private String _lastName;
        private String _avatar;
        private String _phone;
        private String _address;
        private String _introduction;
        private int _gender;
        private String _birthday;
        private String _email;
        private String _password;
        private string _status;

        public string lastName { get => _lastName; set => _lastName = value; }
        public string avatar { get => _avatar; set => _avatar = value; }
        public string phone { get => _phone; set => _phone = value; }
        public string address { get => _address; set => _address = value; }
        public string introduction { get => _introduction; set => _introduction = value; }
        public int gender { get => _gender; set => _gender = value; }
        public string birthday { get => _birthday; set => _birthday = value; }
        public string email { get => _email; set => _email = value; }
        public string password { get => _password; set => _password = value; }
        public string id { get => _id; set => _id = value; }
        public string status { get => _status; set => _status = value; }
        public string firstName { get => _firstName; set => _firstName = value; }
    }
}

