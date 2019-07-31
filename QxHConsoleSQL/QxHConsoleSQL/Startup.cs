using System;
using System.Collections.Generic;
using Couchbase.Configuration.Client;
using Couchbase.Authentication;
using System.Data.SqlClient;

namespace QxHConsoleSQL
{
    class Startup
    {
        SqlConnection sc = new SqlConnection();
        public Startup() { }

        internal SqlConnection GetSqlConnection()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "blazinsql.database.windows.net",
                    UserID = "qxhadmin",
                    Password = "user$123",
                    InitialCatalog = "blazinsql"
                };
                sc.ConnectionString = builder.ConnectionString;
                return sc;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        internal Couchbase.Cluster GetCouchbaseConnect()
        {
            var cluster = new Couchbase.Cluster(new ClientConfiguration
            {
                Servers = new List<Uri> { new Uri("couchbase://localhost") }
            });
            var authenticator = new PasswordAuthenticator("me", "password");
            cluster.Authenticate(authenticator);
            return cluster;
        }
    }
}
