using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SynectixConnection
    {
        string _serverName = @".\SQLEXPRESS"; /*@"SERVER\SQLSYNECTIX";*/
        string _modelName = "DataModel";
        string _database = "synectix";
        string _userName = "confdis1";
        string _password = "conf0171017Dis";
        string _connectionString = "";

        private static SynectixConnection _instance;

        //свойство "экземпляр"
        public static SynectixConnection Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SynectixConnection();
                return _instance;
            }
        }

        public string GetConnectionString(int mode)
        {
            string metadata = String.Format("metadata=res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl", _modelName);
            string authorization = String.Format("Data Source={0};Initial Catalog={1};persist security info=False;User ID={2};Password={3};" +
                                                 "MultipleActiveResultSets=True;App=EntityFramework",_serverName,_database,_userName,_password);
            string provider = "provider=System.Data.SqlClient;";

            switch (mode)
            {
                case 1: //подключение модели данных
                    _connectionString = String.Format(@"{0};{1};provider connection string='{2}';", metadata, provider, authorization);
                    break;

                case 2: //подключение набора данных
                    _connectionString = String.Format(@"{0}", authorization);
                    break;

                default:
                    break;
            }

            return _connectionString;
        }
    }
}
