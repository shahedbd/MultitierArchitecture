using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeGenerator
{
    internal class BLCreate
    {
        private readonly string tableName;
        private readonly List<TableSchema> tableSchema;
        private readonly TableSchema tablePk;
        private readonly string currentPath;

        public BLCreate(string tableName, List<TableSchema> tableSchema, string currentPath)
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

        public void WriteBL()
        {
            using (var writer = new StreamWriter(currentPath + "\\" + tableName + "BL.cs"))
            {
                WriteBLClass(writer);
            }
        }

        private void WriteBLClass(StreamWriter writer)
        {
            writer.WriteLine("using System;");
            writer.WriteLine("using System.Collections.Generic;");
            writer.WriteLine("using System.Threading.Tasks;");
            writer.WriteLine("using FXTF.CRM.Common.Log;");
            writer.WriteLine("using FXTF.CRM.Service.Admin.Interfaces;");
            writer.WriteLine("using FXTF.CRM.Data.Repositories.Implementations;");
            writer.WriteLine("using FXTF.CRM.Model.Model.Admin;");
            writer.WriteLine();

            writer.WriteLine("namespace FXTF.CRM.Service.Admin.Implementations");
            writer.WriteLine("{");
            writer.WriteLine("public class " + tableName + "BL : I" + tableName + "BL");
            writer.WriteLine("{");

            writer.WriteLine();
            writer.WriteLine("protected ILogger Logger { get; set; }");
            writer.WriteLine();

            WriteBLCtor(writer);
            writer.WriteLine();
            WriteInsertBL(writer);
            writer.WriteLine();
            WriteUpdateBL(writer);
            writer.WriteLine();
            WriteDeleteBL(writer);
            writer.WriteLine();
            WriteGetAllBL(writer);
            writer.WriteLine();
            WriteGetByPkIdBL(writer);


            writer.WriteLine();
            writer.WriteLine();

            writer.WriteLine("    }");
            writer.WriteLine("}");
        }

        private void WriteBLCtor(StreamWriter writer)
        {
            writer.WriteLine(
                "public " + tableName + "BL(ILogger logger)");
            writer.WriteLine("{");
            writer.WriteLine("Logger = logger;");
            writer.WriteLine("}");
        }

        private void WriteInsertBL(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Insert " + tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <param name=\"entity\"></param>");
            writer.WriteLine("/// <returns>Message</returns>");
            writer.WriteLine("public async Task<string> Insert" + tableName + "(" + tableName + " entity)");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine("var result = await new " + tableName + "Repository(Logger).Insert(entity);");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("Logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");

        }

        private void WriteUpdateBL(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Update " + tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <param name=\"entity\"></param>");
            writer.WriteLine("/// <returns>Message</returns>");
            writer.WriteLine("public async Task<string> Update" + tableName + "(" + tableName + " entity)");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");

            writer.WriteLine("var result = await new " + tableName + "Repository(Logger).Update(entity);");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("Logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");

        }

        private void WriteDeleteBL(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Delete " + tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <param name=\"" + tablePk.ColumnName + "\"></param>");
            writer.WriteLine("/// <returns>Message</returns>");
            writer.WriteLine("public async Task<string> Delete" + tableName + "(" + tableName + " entity)");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine("var result = await new " + tableName + "Repository(Logger).Delete(entity." + tablePk.ColumnName + ");");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("Logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");
        }

        private void WriteGetAllBL(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Get All " + tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <returns>List of" + tableName + "</returns>");
            writer.WriteLine("public async Task<IEnumerable<" + tableName + ">> GetAll" + tableName + "()");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine("var result = await new " + tableName + "Repository(Logger).GetAll();");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("Logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");
        }

        private void WriteGetByPkIdBL(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Get " + tableName + " by " + tablePk.ColumnName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <param name=\"" + tablePk.ColumnName + "\"></param>");
            writer.WriteLine("/// <returns>" + tableName + " Object</returns>");
            writer.WriteLine("public async Task<" + tableName + "> Get" + tableName + "By" + tablePk.ColumnName + "(" + tablePk.DataTypeName + " " + tablePk.ColumnName + ")");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine("var result = await new " + tableName + "Repository(Logger).GetByID(" + tablePk.ColumnName + ");");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("Logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");
        }
    }
}