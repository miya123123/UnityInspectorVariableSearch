using UnityEngine;
using System.Reflection;

namespace InspectorVariableSearch
{
    /// <summary>
    /// Represents a single search result
    /// </summary>
    public class SearchResult
    {
        public Component Component { get; }
        public FieldInfo Field { get; }
        public object Value { get; set; }

        public SearchResult(Component component, FieldInfo field, object value)
        {
            Component = component;
            Field = field;
            Value = value;
        }
    }
}
