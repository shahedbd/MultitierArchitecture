using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeGenerator
{
    internal class ModelCreate
    {
        private readonly string _tableName;
        private readonly List<TableSchema> _tableSchema;
        private readonly TableSchema _tablePk;

        //Shahed vai created the following folder path
        private static string strOutPutPath;

        public ModelCreate(string tableName, List<TableSchema> tableSchema, string path)
        {
            _tableSchema = tableSchema;
            var firstOrDefault = tableSchema.FirstOrDefault(p => p.IsIdentity.ToLower() == "true");
            if (firstOrDefault != null)
                _tablePk = firstOrDefault;
            if (tableName == "LiveCustomerPersonalInfo" || tableName == "LiveCustomerFinancialInfo")
                _tablePk = tableSchema.ElementAt<TableSchema>(0);
            _tableName = tableName;
            strOutPutPath = path + tableName;
            if (!Directory.Exists(strOutPutPath))  // if it doesn't exist, create
                Directory.CreateDirectory(strOutPutPath);
        }

        public void WriteModel()
        {
            using (var writer = new StreamWriter(strOutPutPath + "\\" + _tableName + ".cs"))
            {

                writer.WriteLine("using System;");
                writer.WriteLine("namespace FXTF.CRM.Model.Model.Admin");
                writer.WriteLine("{");
                writer.WriteLine("    public class " + _tableName);
                writer.WriteLine("    {");

                foreach (var schema in _tableSchema)
                {
                    if ("ntext".Equals(schema.DbTypeName))
                    {
                        writer.WriteLine("        public string " + schema.ColumnName + " { get; set; }");
                        continue;
                    }
                    writer.WriteLine("        public " + schema.DataTypeName + " " + schema.ColumnName + " { get; set; }");
                }

                writer.WriteLine("    }");
                writer.WriteLine("}");
            }
        }
    }
}