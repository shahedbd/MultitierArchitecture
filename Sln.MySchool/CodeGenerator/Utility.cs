using System.Text;

namespace CodeGenerator
{
    public static class Utility
    {
        public static StringBuilder RemoveLast(this StringBuilder sb, string value)
        {
            if (sb.Length < 1) return sb;
            sb.Remove(sb.ToString().LastIndexOf(value), value.Length);
            return sb;
        }
    }
}
