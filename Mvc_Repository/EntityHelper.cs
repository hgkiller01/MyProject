using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mvc_Repository
{
    public class EntityHelper
    {
        /// <summary>
        /// Entities the property names.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<string> EntityPropertyNames<T>()
        {
            string entityName = typeof(T).Name;
            var members = new Dictionary<string, IEnumerable<string>>();
            var mw = new MetadataWorkspace(
                new[] { "res://*/" },
                new[] { Assembly.GetExecutingAssembly() });
            var tables = mw.GetItems(DataSpace.CSpace);
            foreach (var e in tables.OfType<EntityType>())
            {
                members.Add
                    (
                        e.Name,
                        e.Members
                        .Where(m => m.TypeUsage.EdmType.BuiltInTypeKind == BuiltInTypeKind.PrimitiveType)
                        .Select(m => m.Name)
                    );
            }
            return members.Where(x => x.Key == entityName).Select(x => x.Value).FirstOrDefault();

        }
        /// <summary>
        /// Gets the property sort tuples.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        public static List<Tuple<string, string>> GetPropertySortTuples<T>(string propertyName,string order)
        {
            var result = new List<Tuple<string, string>>();
            //取得 Entity 所有的 Property 名稱
            var entityPropertyNames = EntityHelper.EntityPropertyNames<T>();
            var propertyNameOptions = propertyName.Split(',').ToList();
            var orderOptions = order.Split(',').ToList();
            for (int i = 0; i < propertyNameOptions.Count; i++)
            {
                var columnName = propertyNameOptions[i].Trim();
                var sortOrder = string.IsNullOrWhiteSpace(orderOptions[i]) ? "asc" : orderOptions[i];
                var propertyNames = entityPropertyNames as string[] ?? entityPropertyNames.ToArray();
                if (!propertyNames.Contains(columnName))
                {
                   columnName = string.Empty;
                }
                if (!(sortOrder.Equals("asc", StringComparison.OrdinalIgnoreCase)
                      || sortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase)))
                {
                    order = "asc";
                }
                if (!string.IsNullOrEmpty(columnName))
                {
                    result.Add(new Tuple<string, string>(columnName, sortOrder));
                }
            }
            return result;

        }
    }
}