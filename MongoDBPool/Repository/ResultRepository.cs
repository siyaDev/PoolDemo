using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MongoDBPool.DAL;
using MongoDBPool.IRepository;
using MongoDBPool.Models;


namespace MongoDBPool.Repository
{
    public class ResultRepository : IResultRepository

    {

        public IList<Results> SelectAllAsList()
        {
            return (MultipleInnerSelect(SqlHelper.ExecuteDataset(DaLplayer.ConnectionString(), "[_p_selectAllResults]")));
        }

        public IList<Results> SelectAllResultsAsList(int playerId)
        {

            object[] parameterValues =
            {
                new SqlParameter("@PlayerID",playerId)
            };
            return (MultipleInnerSelect(SqlHelper.ExecuteDataset(DaLplayer.ConnectionString(), "[_p_selectAllResultsByJoint]", parameterValues)));
        }

        public IList<Results> MultipleInnerSelect(DataSet dsMessage)
        {

            IList<Results> resultses = new List<Results>();

            if (dsMessage.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow row in dsMessage.Tables[0].Rows)
                {
                    var result = new Results();
           
                    if (row["MatchDate"] != DBNull.Value)
                        result.Date = (DateTime)row["MatchDate"];

                    if (row["HostName"] != DBNull.Value)
                        result.HostName = (string)row["HostName"]; // GETpLAYER & join first & last name to create name

                    if (row["OpponentName"] != DBNull.Value)
                        result.OppnetName = (string)row["OpponentName"];

                    if (row["HostPoints"] != DBNull.Value)
                        result.HostPoints = (int)row["HostPoints"];

                    if (row["OpponentPoints"] != DBNull.Value)
                        result.OpponentPoints = (int)row["OpponentPoints"];

                    if (row["HostBallsLeft"] != DBNull.Value)
                        result.HosBallsLeft = (int)row["HostBallsLeft"];

                    if (row["OpponentBallsLeft"] != DBNull.Value)
                        result.OppnetBallsLeft = (int)row["OpponentBallsLeft"];

                    resultses.Add(result);
                }
            }
            return resultses;
        }

        // select result buy id to edit results
        public Results SelectById(int resulId)
        {
            object[] parameterValues =
            {
                new SqlParameter("@PlayerID",resulId)};
            return (InnerSelect(SqlHelper.ExecuteDataset(DaLplayer.ConnectionString(), "[GetResultByPlayerId]", parameterValues)));
        }
        public Results InnerSelect(DataSet dsMessage)
        {
            Results result = null;
            if (dsMessage.Tables[0].Rows.Count > 0)
            {
                result = new Results();

                if (dsMessage.Tables[0].Rows[0]["ResultsID"] != DBNull.Value)
                    result._id = (int)dsMessage.Tables[0].Rows[0]["ResultsID"];

                if (dsMessage.Tables[0].Rows[0]["MatchDate"] != DBNull.Value)
                    result.Date = (DateTime)dsMessage.Tables[0].Rows[0]["MatchDate"];

                if (dsMessage.Tables[0].Rows[0]["HostId"] != DBNull.Value)
                    result.HostId = (int)dsMessage.Tables[0].Rows[0]["HostId"];

                if (dsMessage.Tables[0].Rows[0]["OpponentId"] != DBNull.Value)
                    result.OppenentId = (int)dsMessage.Tables[0].Rows[0]["OpponentId"];

                if (dsMessage.Tables[0].Rows[0]["HostBallsLeft"] != DBNull.Value)
                    result.HosBallsLeft = (int)dsMessage.Tables[0].Rows[0]["HostBallsLeft"];

                if (dsMessage.Tables[0].Rows[0]["OpponentBallsLeft"] != DBNull.Value)
                    result.OppnetBallsLeft = (int)dsMessage.Tables[0].Rows[0]["OpponentBallsLeft"];
            }
            return result;
        }
        public void Save(Results results)
        {
            object[] parameterValues =
                {
                    new SqlParameter("@MatchDate", results.Date),
                    new SqlParameter("@HostId", results.HostId),
                    new SqlParameter("@OpponentId", results.OppenentId),
                    new SqlParameter("@HostBallsLeft ", results.HosBallsLeft),
                    new SqlParameter("@OpponentBallsLeft", results.OppnetBallsLeft),
                    new SqlParameter("@HostStatus",results.HostStatus),
                     new SqlParameter("@OppentStatus",results.OppnentStatus)

                };


          
            SqlHelper.ExecuteScalar(DaLplayer.ConnectionString(), "[SaveResults]", parameterValues);
             }

        public void Delete(int resultId)
           {
            object[] parameterValues =
            {
             new SqlParameter("@p_id",resultId)};
            SqlHelper.ExecuteScalar(DaLplayer.ConnectionString(), "p_DeleResultsById", parameterValues);
          }

        public void Update(Results result)
         {
            object[] parameterValues =
            {
              new SqlParameter("@p_id",result._id),  
              new SqlParameter("@HostBallsLeft",result.HosBallsLeft),   
              new SqlParameter("@OpponentBallsLeft",result.OppnetBallsLeft) };
            SqlHelper.ExecuteScalar(DaLplayer.ConnectionString(), "p_updateResults", parameterValues);
        }

    }
}