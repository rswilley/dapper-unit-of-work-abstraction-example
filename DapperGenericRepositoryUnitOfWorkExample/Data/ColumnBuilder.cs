using System.Reflection;
using System.Text;

namespace DapperGenericRepositoryUnitOfWorkExample.Data
{
    public static class ColumnBuilder<T>
    {
        //Use reflection to get the public properties of an entity
        //to get the columns for our SELECT statement
        public static string GetColumns()
        {
            var sb = new StringBuilder();

            var t = typeof(T);
            var properties = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
                sb.Append($"{property.Name},");

            return sb.ToString().TrimEnd(',');
        }
    }
}
