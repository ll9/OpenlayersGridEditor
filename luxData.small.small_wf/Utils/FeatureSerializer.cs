using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luxData.small.small_wf.Utils
{
    public class FeatureSerializer
    {
        /// <summary>
        /// Extracts a feature from its datarow and adds properties to it
        /// </summary>
        /// <param name="geometryColumn">name of the column where the feature is</param>
        /// <param name="row"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public static dynamic Serialize(string idColumn, string geometryColumn, DataRow row, DataTable table)
        {

            dynamic feature = new ExpandoObject();
            var geometry = JsonConvert.DeserializeObject<ExpandoObject>(row[geometryColumn].ToString());
            var properties = new Dictionary<string, object>();


            foreach (string columnName in table.Columns.Cast<DataColumn>().Select(col => col.ColumnName))
            {
                if (columnName == idColumn)
                {
                    feature.id = row[idColumn];
                }
                else if (columnName != geometryColumn)
                {
                    properties.Add(columnName, row[columnName]);
                }
            }

            feature.type = "Feature";
            feature.properties = properties;
            feature.geometry = geometry;
            return JsonConvert.SerializeObject(feature);
        }
    }
}
