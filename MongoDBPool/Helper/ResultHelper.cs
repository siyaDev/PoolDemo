using MongoDB.Driver;

namespace MongoDBPool.Helper
{
    public class ResultHelper
    {
        private static ResultHelper _instance;

        public static ResultHelper Instance
        {
            get { return _instance ?? (_instance = new ResultHelper()); }
        }

        private MongoServer _server;

        public MongoDatabase Database
        {
            get { return Server.GetDatabase("TournamentDatabase"); }
        }

        private MongoServer Server
        {
            get
            {
                if (_server == null || _server.State != MongoServerState.Connected)
                {
                    _server = CreateServer();
                }
                return _server;
            }
        }


        private MongoServer CreateServer()
        {
            // TODO: refactor connection string into AppSetting
            string connectionString = "mongodb://127.0.0.1";
            var server = MongoServer.Create(connectionString);
            return server;
        }



    }
}