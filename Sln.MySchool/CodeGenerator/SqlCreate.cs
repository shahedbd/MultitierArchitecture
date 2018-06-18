using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeGenerator
{
    internal class SqlCreate
    {
        private string tableName;
        private List<TableSchema> tableSchema;
        private readonly TableSchema tablePk;
        private readonly string currentPath;

        public enum SqlType
        {
            Add = 1,
            Update = 2,
            Delete = 3,
            SelectAll = 4,
            SelectById = 5
        }

        public SqlCreate(string tableName, List<TableSchema> tableSchema, string currentPath)
        {
            this.tableName = tableName;
            this.tableSchema = tableSchema;
            var firstOrDefault = tableSchema.FirstOrDefault(p => p.IsIdentity.ToLower() == "true");
            if (firstOrDefault != null)
                tablePk = firstOrDefault;
            if (tableName == "LiveCustomerPersonalInfo" || tableName == "LiveCustomerFinancialInfo")
                tablePk = tableSchema.ElementAt<TableSchema>(0);
            this.currentPath = currentPath + tableName;
        }

        public void WriteSql()
        {
            using (var writer = new StreamWriter(currentPath + "\\sp_" + tableName + ".sql"))
            {
                WriteSpHeader(writer);

                WriteAddSql(writer);
                Blank(writer);

                WriteUpdateSql(writer);
                Blank(writer);

                WriteDeleteSql(writer);
                Blank(writer);


                WriteGetAll(writer);
                Blank(writer);

                WriteGetByPk(writer);
            }
        }

        private void WriteSpHeader(StreamWriter writer)
        {
            writer.WriteLine("SET ANSI_NULLS ON");
            writer.WriteLine("GO");
            writer.WriteLine("SET QUOTED_IDENTIFIER ON");
            writer.WriteLine("GO");
            writer.WriteLine("");
            writer.WriteLine("CREATE  proc [dbo].[sp_" + tableName + "]");
            writer.WriteLine("(");

            foreach (var schema in tableSchema)
            {
                writer.WriteLine("@" + schema.ColumnName + "		" + schema.DbTypeName + 
                    (schema.DbTypeName == "nchar" || schema.DbTypeName == "nvarchar" ? "(" + schema.ColumnSize.ToString() + ")" 
                    : "") + " = null,");

                var abc = "@" + schema.ColumnName + "		" + schema.DbTypeName + (schema.DbTypeName == "nchar" ? "(" + schema.ColumnSize.ToString() + ")" : "") + " = null,";
            }

            writer.WriteLine("");
            writer.WriteLine("@Msg				nvarchar(MAX)=null OUT ,");
            writer.WriteLine("@pOptions			int ");
            writer.WriteLine(")");
            writer.WriteLine("AS");

        }

        private void WriteAddSql(StreamWriter writer)
        {
            Blank(writer);
            writer.WriteLine("--Save " + tableName + "");
            writer.WriteLine("if(@pOptions=" + (int)SqlType.Add + ")");
            writer.WriteLine("begin");
            writer.WriteLine("INSERT INTO " + tableName + "");
            writer.WriteLine("(");

            var stringBuilder = new StringBuilder();
            bool firstINSERTINTO = true;

            foreach (var schema in tableSchema)
            {
                if (!firstINSERTINTO)
                    stringBuilder.Append(schema.ColumnName + ",");
                firstINSERTINTO = false;
            }

            writer.WriteLine(stringBuilder.RemoveLast(","));

            writer.WriteLine(")");
            writer.WriteLine("VALUES( ");


            stringBuilder = new StringBuilder();
            bool firstVALUES = true;
            foreach (var schema in tableSchema)
            {               
                if (!firstVALUES)
                    stringBuilder.Append("@" + schema.ColumnName + ",");
                firstVALUES = false;
            }
            writer.WriteLine(stringBuilder.RemoveLast(","));

            writer.WriteLine(")");

            writer.WriteLine("IF @@ROWCOUNT = 0");
            writer.WriteLine("Begin");
            writer.WriteLine("SET @Msg='Warning: No rows were Inserted';	");
            writer.WriteLine("End");
            writer.WriteLine("Else");
            writer.WriteLine("Begin");
            writer.WriteLine("SET @Msg='Data Saved Successfully';	");
            writer.WriteLine("End					");
            writer.WriteLine("end");
            writer.WriteLine("--End of Save " + tableName + "");

        }

        private void WriteUpdateSql(StreamWriter writer)
        {
            writer.WriteLine("--Update " + tableName + " ");
            writer.WriteLine("if(@pOptions=" + (int)SqlType.Update + ")");
            writer.WriteLine("begin");
            writer.WriteLine("UPDATE	" + tableName + " ");

            writer.WriteLine("SET");

            var stringBuilder = new StringBuilder();
            foreach (var schema in tableSchema.Where(p => p.IsIdentity.ToLower() == "false"))
            {
                stringBuilder.AppendLine("" + schema.ColumnName + "	=	@" + schema.ColumnName + " ,");
            }
            writer.WriteLine(stringBuilder.RemoveLast(","));

            writer.WriteLine("WHERE	" + tablePk.ColumnName + "	=	@" + tablePk.ColumnName + ";");

            writer.WriteLine("IF @@ROWCOUNT = 0");
            writer.WriteLine("Begin");
            writer.WriteLine("SET @Msg='Warning: No rows were Updated';	");
            writer.WriteLine("End");
            writer.WriteLine("Else");
            writer.WriteLine("Begin");
            writer.WriteLine("SET @Msg='Data Updated Successfully';");
            writer.WriteLine("End");
            writer.WriteLine("End");
            writer.WriteLine("--End of Update " + tableName + " ");
        }

        private void WriteDeleteSql(StreamWriter writer)
        {
            writer.WriteLine("--Delete " + tableName + "");
            writer.WriteLine("if(@pOptions=" + (int)SqlType.Delete + ")");
            writer.WriteLine("begin");
            writer.WriteLine("Delete from " + tableName + " Where " + tablePk.ColumnName + "=@" + tablePk.ColumnName + ";");
            writer.WriteLine("SET @Msg='Data Deleted Successfully';");
            writer.WriteLine("end");
            writer.WriteLine("--End of Delete " + tableName + " ");
        }

        private void WriteGetAll(StreamWriter writer)
        {
            writer.WriteLine("--Select All " + tableName + " ");
            writer.WriteLine("if(@pOptions=" + (int)SqlType.SelectAll + ")");
            writer.WriteLine("begin	        ");
            writer.WriteLine("select * from " + tableName + ";");
            writer.WriteLine("if(@@ROWCOUNT=0)");
            writer.WriteLine("SET @Msg='Data Not Found';");
            writer.WriteLine("end");
            writer.WriteLine("--End of Select All " + tableName + " ");
        }

        private void WriteGetByPk(StreamWriter writer)
        {
            writer.WriteLine("--Select " + tableName + " By " + tablePk.ColumnName + " ");
            writer.WriteLine("if(@pOptions=" + (int)SqlType.SelectById + ")");
            writer.WriteLine("begin");
            writer.WriteLine("select * from " + tableName + " Where " + tablePk.ColumnName + "=@" + tablePk.ColumnName + ";");
            writer.WriteLine("if(@@ROWCOUNT=0)");
            writer.WriteLine("SET @Msg='Data Not Found';");
            writer.WriteLine("end");
            writer.WriteLine("--End of Select " + tableName + " By " + tablePk.ColumnName + " ");
        }



        private static void Blank(StreamWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine();
            writer.WriteLine();
        }
    }
}