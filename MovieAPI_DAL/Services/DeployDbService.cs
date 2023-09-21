using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI_DAL.Services
{
    public class DeployDbService
    {
        private IDbConnection _connection;
        public DeployDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateDatabase()
        {

            string query = "";
        }
    }
}
