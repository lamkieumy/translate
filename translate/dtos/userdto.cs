using System.Data;

namespace translate.dtos{
    public class userdto
    {
        public string username{get;set;}
        public string password{get;set;}
        public string firstname{get;set;}
        public string lastname{get;set;}

        public userdto(string username, string password, string firstname, string lastname)
        {
            this.username = username;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
        }
        public userdto(){}
        public userdto(DataRow row){
            this.username=row[1].ToString();
            this.password=row[2].ToString();
            this.firstname=row[3].ToString();
            this.lastname=row[4].ToString();
        }
    }
}