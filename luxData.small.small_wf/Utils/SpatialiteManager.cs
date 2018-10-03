using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luxData.small.small_wf.Utils
{
    public interface ISpatialiteManager
    {
        string DbPath { get; }

        DataTable GetDataTable();
        void Update(DataTable dataTable);
    }

    class SpatialiteManager : ISpatialiteManager
    {
        public const string GeometryColumn = "geometry";
        public const string TableName = "LDS_FEATURES";

        public string DbPath { get; }

        public SpatialiteManager(string dbPath)
        {
            DbPath = dbPath;
        }

        private SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection("Data Source =" + DbPath);
            connection.Open();
            connection.EnableExtensions(true);
            connection.LoadExtension("mod_spatialite");

            return connection;
        }

        public DataTable GetDataTable()
        {
            var dataTable = new DataTable();
            var query = GetSelectQuery();

            using (var connection = GetConnection())
            using (var adapter = new SQLiteDataAdapter(query, connection))
            {
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        private string GetSelectQuery()
        {
            ICollection<string> items = new List<string>();

            var cmd = new SQLiteCommand("select * from " + TableName, GetConnection());
            var dr = cmd.ExecuteReader();
            for (var i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i) == GeometryColumn)
                {
                    // 5 decimals, 2 means geojson with crs
                    items.Add("AsGeoJSON('POINT', 5, 2)");
                }
                else
                {
                    items.Add(dr.GetName(i));
                }
            }

            return "select " + string.Join(",", items) + " from " + TableName;
        }

        public void Update(DataTable dataTable)
        {
            using (var connection = GetConnection())
            using (var transaction = connection.BeginTransaction())
            using (var adapter = new SQLiteDataAdapter(GetSelectQuery(), GetConnection()))
            {
                var cb = new SQLiteCommandBuilder(adapter);

                adapter.UpdateCommand = cb.GetUpdateCommand();
                adapter.DeleteCommand = cb.GetDeleteCommand();
                adapter.InsertCommand = cb.GetInsertCommand();

                adapter.Update(dataTable);
                transaction.Commit();
            }
        }
    }
}
