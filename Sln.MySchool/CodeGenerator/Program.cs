using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace CodeGenerator
{
    class Program
    {
        private static string TableName { get; set; }
        private static List<TableSchema> _tableSchema;

        //Shahed vai created the following folder path
        private static string currentPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\OutPut\\";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Insert table name (type \'q\' to exit): ");
                TableName = Console.ReadLine();

                if ("q".Equals(TableName))
                {
                    break;
                }

                _tableSchema = GetTables();
                if (null == _tableSchema)
                {
                    Console.WriteLine("Invalid table name");
                    TableName = "";
                    continue;
                }

                ModelCreate modelCreate = new ModelCreate(TableName, _tableSchema, currentPath);
                modelCreate.WriteModel();
                RepositoryCreate repositoryCreate = new RepositoryCreate(TableName, _tableSchema, currentPath);
                repositoryCreate.WriteRepository();
                InterfaceBLCreate interfaceBLCreate = new InterfaceBLCreate(TableName, _tableSchema, currentPath);
                interfaceBLCreate.WriteInterfaceBL();
                BLCreate blCreate = new BLCreate(TableName, _tableSchema, currentPath);
                blCreate.WriteBL();
                SqlCreate sqlCreate = new SqlCreate(TableName, _tableSchema, currentPath);
                sqlCreate.WriteSql();
                TableName = "";
            }

        }

        public static List<TableSchema> GetTables()
        {
            SqlConnection connection = MSSQLConn.MSSQLConnection();
            try
            {
                var sql = "select * from " + TableName + " WHERE 1 = 0";
                connection.Open();
                var cmd = new SqlCommand(sql, connection);
                var reader = cmd.ExecuteReader();

                var schemaTable = reader.GetSchemaTable();

                if (schemaTable != null)
                    return (from DataRow row in schemaTable.Rows
                            select new TableSchema
                            {
                                ColumnName = row["ColumnName"].ToString(),
                                ColumnSize = row["ColumnSize"].ToString(),
                                DataTypeName = ConvertToType(row["DataTypeName"].ToString()),
                                DbTypeName = row["DataTypeName"].ToString(),
                                IsIdentity = row["IsIdentity"].ToString()
                            }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
            return new List<TableSchema>();
        }

        private static string ConvertToType(string sqlDataType)
        {
            switch (sqlDataType)
            {
                case "bigint":
                    return "long";
                case "nvarchar":
                    return "string";
                case "nchar":
                    return "string";
                case "varchar":
                    return "string";
                case "varbinary":
                    return "string";



                case "datetime":
                    return "DateTime";
                case "bit":
                    return "bool";
                case "int":
                    return "int";
                case "tinyint":
                    return "int";
                case "decimal":
                    return "decimal";
            }
            return "";
        }

    }
}
