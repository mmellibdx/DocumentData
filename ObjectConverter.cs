using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StampeDatiDinamici
{

    public class Item
    {
        public string key { get; set; }
        public string value { get; set; }
        public string description { get; set; }
        public List<Item> items { get; set; }
    }

    public class DocumentData
    {
        public List<Item> items { get; set; }
    }

    public class RootObject
    {
        public DocumentData documentData { get; set; }
    }

    public static class ObjectConverter
    {
        public static RootObject ConvertToRootObject<T>(T obj)
        {
            RootObject rootObject = new RootObject
            {
                documentData = new DocumentData
                {
                    items = ConvertObjectToItems(obj)
                }
            };

            return rootObject;
        }

        private static List<Item> ConvertObjectToItems(object obj)
        {
            if (obj == null) return null;

            List<Item> items = new List<Item>();
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);

                // Ignora le variabili con valore null
                if (value == null) continue;

                // Ignora DateTime con valore 01/01/0001 00:00:00
                if (property.PropertyType == typeof(DateTime) && (DateTime)value == DateTime.MinValue) continue;

                if (IsPrimitiveOrKnownType(property.PropertyType))
                {
                    // La proprietà è di un tipo primitivo o noto
                    items.Add(new Item
                    {
                        key = property.Name,
                        value = value.ToString()
                    });
                }
                else if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string))
                {
                    // La proprietà è una collezione (ma non una stringa)
                    List<Item> subItems = new List<Item>();

                    foreach (var element in (IEnumerable)value)
                    {
                        var elementItems = ConvertObjectToItems(element);
                        if (elementItems != null)
                        {
                            subItems.AddRange(elementItems);
                        }
                    }

                    if (subItems.Count > 0)
                    {
                        items.Add(new Item
                        {
                            description = property.Name,
                            items = subItems
                        });
                    }
                }
                else
                {
                    // La proprietà è un tipo complesso (classe)
                    var subItems = ConvertObjectToItems(value);
                    if (subItems != null && subItems.Count > 0)
                    {
                        items.Add(new Item
                        {
                            description = property.Name,
                            items = subItems
                        });
                    }
                }
            }

            return items;
        }

        private static bool IsPrimitiveOrKnownType(Type type)
        {
            return type.IsPrimitive || type == typeof(string) || type == typeof(DateTime) ||
                   type == typeof(decimal) || type == typeof(double) || type == typeof(float) ||
                   type == typeof(int) || type == typeof(long) || type == typeof(short) ||
                   type == typeof(byte) || type == typeof(uint) || type == typeof(ulong) ||
                   type == typeof(ushort) || type == typeof(sbyte) || type == typeof(bool);
        }
    }


}