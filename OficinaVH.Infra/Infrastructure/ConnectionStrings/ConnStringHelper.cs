using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaVH.Infra.Infrastructure.ConnectionStrings
{
    public static class ConnStringHelper
    {
        private static Dictionary<string, string> Connections { get; set; }

        public static void SetConnString(IConfiguration services)
        {
            Connections = services.GetSection("ConnStringSettings").GetChildren().ToDictionary(x => x.Key, x => x.Value);
        }

        public static string GetConnection()
        {
            return Connections["ConnStringSettings: ConnString"];
        }

        public static void SetMultipleResultsToRecursive(DbContext context)
        {
            context.Database.GetDbConnection().ConnectionString += "MultipleActiveResultSets=true";
        }
    }
}
