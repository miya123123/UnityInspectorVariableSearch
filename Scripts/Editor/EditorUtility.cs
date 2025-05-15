using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace InspectorVariableSearch
{
    /// <summary>
    /// Utility methods for the Inspector Variable Search window
    /// </summary>
    public static class EditorUtility
    {
        /// <summary>
        /// Determines if a field should be shown in the search results
        /// </summary>
        public static bool ShouldShowField(FieldInfo field)
        {
            // Show serialized fields
            bool isSerializedField = field.IsDefined(typeof(SerializeField), true);
            
            // Show public fields that aren't hidden
            bool isPublicNotHidden = field.IsPublic && !field.IsDefined(typeof(HideInInspector), true);
            
            // Skip private/protected fields that aren't serialized
            bool isPrivateNotSerialized = (field.IsPrivate || field.IsFamily || 
                                          field.IsFamilyAndAssembly || field.IsAssembly || 
                                          field.IsFamilyOrAssembly) && !isSerializedField;
            
            return isSerializedField || isPublicNotHidden || !isPrivateNotSerialized;
        }

        /// <summary>
        /// Updates a field value and marks the component as dirty
        /// </summary>
        public static void UpdateField(Component component, SearchResult result, object newValue)
        {
            try
            {
                result.Field.SetValue(component, newValue);
                result.Value = newValue;
                UnityEditor.EditorUtility.SetDirty(component);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to set value for {result.Field.Name}: {ex.Message}");
            }
        }
    }
}
