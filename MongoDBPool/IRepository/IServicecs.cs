
using System.Collections.Generic;
using MongoDBPool.Models;

namespace MongoDBPool.IRepository
{
    public interface IResultService
    {

        List<Player> CalculatePoints(Results resulut);
        Results ResultsEvaluation(Results results);


    }
}