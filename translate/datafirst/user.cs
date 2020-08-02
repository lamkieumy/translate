using System.Collections.Generic;
using System.Data;
using translate.dtos;

namespace translate.datafirst{
    public class user{
        private static user instance;
        public static user Instance{
            get{if (instance==null) instance= new user();return user.Instance;}
            private set => instance= value;
        }
        public List<userdto> showAllUser(){
            string query="select * from users";
            List<userdto> userdtos= new List<userdto>();
            DataTable data= dataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows){
                userdto userdto = new userdto(item);
                userdtos.Add(userdto);
            }
            return userdtos;
        }
    }
}