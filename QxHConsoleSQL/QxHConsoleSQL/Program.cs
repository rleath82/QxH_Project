using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading;
using Dapper;
using System.Linq;

namespace QxHConsoleSQL
{
    class Program
    {
        private static Timer timer;
        static void Main(string[] args)
        {
            var timerState = new TimerState { Counter = 0 };

            timer = new Timer(
                callback: new TimerCallback(TimerTask),
                state: timerState,
                dueTime: 5000,
                period: 5000);

            while (timerState.Counter > -1)
            {
                if (timerState.Counter > 5)
                    timerState.Counter = 0;
                try
                {
                    List<Merchandise> items = new List<Merchandise>();
                    SqlConnection sc = new SqlConnection();
                    Startup s = new Startup();
                    sc = s.GetSqlConnection();

                    try
                    {
                        sc.Open();

                        for (int i = 0; i < 3; i++)
                        {
                            using (var _bucket = s.GetCouchbaseConnect().OpenBucket(GetBuckets(i)))
                            {
                                Couchbase.Document<Merchandise> doc = new Couchbase.Document<Merchandise>();
                                SqlCommand cmd = sc.CreateCommand();

                                items = sc.Query<Merchandise>("SELECT * FROM USA").ToList();
                                foreach (Merchandise rowdata in items)
                                {
                                    doc.Id = rowdata.ItemId.ToString();
                                    doc.Content = rowdata;
                                    if (rowdata.CompanyId == i)
                                    {
                                        var result = _bucket.Upsert(doc);
                                    }
                                }
                            }
                        }
                        sc.Close();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private static string GetBuckets(int countryId)
        {
            if (countryId == 0)
                return "MerchUSA";
            else if (countryId == 1)
                return "MerchEUR";
            else
                return "MerchJPN";
        }

        private static void TimerTask(object timerState)
        {
            var state = timerState as TimerState;
            Interlocked.Increment(ref state.Counter);
        }

        class TimerState
        {
            public int Counter;
        }
    }
}
