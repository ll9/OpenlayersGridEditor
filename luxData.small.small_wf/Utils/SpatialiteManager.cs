﻿using System;
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
        public readonly string GeometryColumn = Properties.Settings.Default["geometryColumn"].ToString();
        public readonly string TableName = Properties.Settings.Default["tableName"].ToString();

        public string DbPath { get; }

        public SpatialiteManager(string dbPath)
        {
            DbPath = dbPath;
        }

        /// <summary>
        /// Gets SQLITE connection with spatialite extension
        /// </summary>
        /// <returns></returns>
        private SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection("Data Source =" + DbPath);
            connection.Open();
            connection.EnableExtensions(true);
            connection.LoadExtension("mod_spatialite");

            return connection;
        }

        /// <summary>
        /// Gets dataTable containing all properties
        /// Geometrie is obtained as geojson
        /// </summary>
        /// <returns></returns>
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

            using (var connection = GetConnection())
            using (var cmd = new SQLiteCommand("select * from " + TableName, connection))
            using (var dr = cmd.ExecuteReader())
            {
                for (var i = 0; i < dr.FieldCount; i++)
                {
                    if (dr.GetName(i) == GeometryColumn)
                    {
                        items.Add($"AsGeoJSON({GeometryColumn}, 5, 2)");
                    }
                    else
                    {
                        items.Add(dr.GetName(i));
                    }
                }
            }

            return "select " + string.Join(",", items) + " from " + TableName;
        }

        /// <summary>
        /// Saves changes from the datatable to the database
        /// does not include Geometry (needs to be handled seperately)
        /// </summary>
        /// <param name="dataTable"></param>
        public void Update(DataTable dataTable)
        {
            var query = GetSelectQuery();

            using (var connection = GetConnection())
            using (var transaction = connection.BeginTransaction())
            using (var adapter = new SQLiteDataAdapter(query, connection))
            using (var cb = new SQLiteCommandBuilder(adapter))
            {

                adapter.UpdateCommand = cb.GetUpdateCommand();
                adapter.DeleteCommand = cb.GetDeleteCommand();
                adapter.InsertCommand = cb.GetInsertCommand();

                adapter.Update(dataTable);
                transaction.Commit();
            }
        }
    }
}
