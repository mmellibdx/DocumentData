using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DocumentData {

    public class TemplateValues {
        [Required(ErrorMessage = "Items is required")]
        [JsonPropertyName("items")]
        public List<PrintValueItem> Items { get; set; } = new ();
    }

    public class PrintValueItem {
        [JsonPropertyName("key")]
        public string? Key { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("items")]
        public List<PrintValueItem>? Items { get; set; }
    }

    public class RootObject {
        [Required(ErrorMessage = "DocumentData is required")]
        [JsonPropertyName("documentData")]
        public TemplateValues DocumentData { get; set; }
    }

    public static class ObjectConverter {
        public static RootObject ConvertToRootObject<T>(T obj) {
            RootObject rootObject = new RootObject {
                DocumentData = new TemplateValues {
                    Items = ConvertObjectToItems(obj)
                }
            };

            return rootObject;
        }

        private static List<PrintValueItem> ConvertObjectToItems(object obj) {
            if (obj == null) return [];

            List<PrintValueItem> items = new();
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var property in properties) {
                var value = property.GetValue(obj);

                // Ignora le variabili con valore null
                if (value == null) continue;

                // Ignora DateTime con valore 01/01/0001 00:00:00
                if (property.PropertyType == typeof(DateTime) && (DateTime)value == DateTime.MinValue) continue;

                DataMemberAttribute? dataMemberAttribute = property.GetCustomAttribute<DataMemberAttribute>();
                string propertyName = dataMemberAttribute?.Name ?? property.Name;

                if (IsPrimitiveOrKnownType(property.PropertyType)) {
                    // La proprietà è di un tipo primitivo o noto

                    // Gestione specifica per bool: converti il valore in minuscolo (true/false)
                    string? stringValue = property.PropertyType == typeof(bool)
                        ? value?.ToString()?.ToLowerInvariant()
                        : value?.ToString();

                    items.Add(new PrintValueItem {
                        Key = property.Name,
                        Value = stringValue ?? string.Empty
                    });
                } else if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string)) {

                    foreach (var element in (IEnumerable)value) {
                        // La proprietà è una collezione (ma non una stringa)
                        List<PrintValueItem> subItems = new();
                        var elementItems = ConvertObjectToItems(element);
                        if (elementItems != null) {
                            subItems.AddRange(elementItems);
                        }
                        if (subItems.Count > 0) {
                            items.Add(new PrintValueItem {
                                Description = property.Name,
                                Items = subItems
                            });
                        }
                    }

                } else {
                    // La proprietà è un tipo complesso (classe)
                    var subItems = ConvertObjectToItems(value);
                    if (subItems != null && subItems.Count > 0) {
                        items.Add(new PrintValueItem {
                            Description = property.Name,
                            Items = subItems
                        });
                    }
                }
            }

            return items;
        }

        private static bool IsPrimitiveOrKnownType(Type type) {
            return type.IsPrimitive || type == typeof(string) || type == typeof(DateTime) ||
                   type == typeof(decimal) || type == typeof(double) || type == typeof(float) ||
                   type == typeof(int) || type == typeof(long) || type == typeof(short) ||
                   type == typeof(byte) || type == typeof(uint) || type == typeof(ulong) ||
                   type == typeof(ushort) || type == typeof(sbyte) || type == typeof(bool);
        }
    }


}