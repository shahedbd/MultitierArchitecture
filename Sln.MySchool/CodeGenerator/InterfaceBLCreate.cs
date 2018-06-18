using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeGenerator
{
    internal class InterfaceBLCreate
    {
        private readonly string tableName;
        private List<TableSchema> tableSchema;
        private readonly TableSchema tablePk;
        private string currentPath;

        public InterfaceBLCreate(string tableName, List<TableSchema> tableSchema, string currentPath)
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

        public void WriteInterfaceBL()
        {
            using (var writer = new StreamWriter(currentPath + "\\I" + tableName + "BL.cs"))
            {
                writer.WriteLine("using FXTF.CRM.Model.Model.Admin;");
                writer.WriteLine("using System.Collections.Generic;");
                writer.WriteLine("using System.Threading.Tasks;");
                writer.WriteLine();
                writer.WriteLine("namespace FXTF.CRM.Service.Admin.Interfaces");
                writer.WriteLine("{");
                writer.WriteLine("    public interface I" + tableName + "BL");
                writer.WriteLine("    {");

                writer.WriteLine("        Task<string> Insert" + tableName + "(" + tableName + " entity);");
                writer.WriteLine("        Task<string> Update" + tableName + "(" + tableName + " entity);");
                writer.WriteLine("        Task<string> Delete" + tableName + "(" + tableName + " entity);");
                writer.WriteLine("        Task<IEnumerable<" + tableName + ">> GetAll" + tableName + "();");
                writer.WriteLine("        Task<" + tableName + "> Get" + tableName + "By" + tablePk.ColumnName + "(" + tablePk.DataTypeName + " " + tablePk.ColumnName + ");");

                writer.WriteLine("    }");
                writer.WriteLine("}");
            }
        }
    }
}