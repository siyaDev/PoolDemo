
namespace MongoDBPool.ViewModels
{
    public class EditResultsView
    {
        public int Id { get; set; }
        public int HostBallLeft { get; set; }
        public int OppnentBallLeft { get; set; }
        public EditResultsView(int id, int hostBallLeft, int oppnentBallLeft)
       {            Id = id;
            HostBallLeft = hostBallLeft;
            OppnentBallLeft = oppnentBallLeft;
        }
    }

   
}