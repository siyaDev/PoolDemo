using System.Collections.Generic;
using MongoDBPool.IRepository;
using MongoDBPool.Models;

namespace UnitTests
{

    public class ResultsRepositoryMock : IResultRepository
    {
        public bool WasResultsSaved;
        public bool WasResultsUpDated;
       


         public IList<Results> SelectAllAsList()
         {
             return TestHelper.ResultsList();
         }

        public  Results SelectById(int playerId)
        {
          return  TestHelper.CreateResults();
        }
        public void Save(Results results)
        {
            if (results == null)
                WasResultsSaved = true;
        }

        public void Delete(int id)
        {

         TestHelper.CreatePlayer();
        }

        public void Update(Results results)
        {
            if (results == null)
                WasResultsUpDated = true;
        }
    }
}
