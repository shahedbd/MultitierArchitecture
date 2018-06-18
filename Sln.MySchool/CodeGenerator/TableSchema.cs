namespace CodeGenerator
{
    public class TableSchema
    {
        public string ColumnName { get; set; }
        public string DataTypeName { get; set; }
        public string DbTypeName { get; set; }
        public string ColumnSize { get; set; }
        public string IsIdentity { get; set; }

    }
}