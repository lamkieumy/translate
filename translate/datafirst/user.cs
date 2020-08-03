using System.Collections.Generic;
using System.Data;
using translate.dtos;

namespace translate.datafirst{
    public class user
    {
        private static user instance;
        public static user Instance{
            get
            {
                if (instance==null)
                    return instance = new user();
                return user.Instance;
            }
            private set {user.instance= value;}
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
        public int checklogin(login lg){
            string query ="exec checkuser @1 , @2 ";
            DataTable data = dataProvider.Instance.ExcuteQuery(query,new object[]{lg.username,lg.password});
            if(data==null){
                return 0;
            }else
            {
                return int.Parse(data.ToString());
            }
        }
    }
}