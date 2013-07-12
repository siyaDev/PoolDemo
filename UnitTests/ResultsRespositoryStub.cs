using System.Collections.Generic;
using MongoDBPool.IRepository;
using MongoDBPool.Models;

namespace UnitTests
{
    class ResultsRespositoryStub : IResultRepository
    {
        public IList<Results> ressultsToReturn;
        public Results resultToReturn; 


      public  IList<Results> SelectAllAsList()
      {
          if (ressultsToReturn == null)
              return TestHelper.ResultsList();
                 return ressultsToReturn;
      }

        public Results SelectById(int playerId)
        {
            if (resultToReturn == null)
              return TestHelper.CreateResults();
                 return resultToReturn;

        }

        public void Save(Results results)
        {
            TestHelper.ResultsList().Add(results);

        }

        public void Delete(int playerId)
        {

        }

        public void Update(Results player)
        {
            
        }
    }
}
