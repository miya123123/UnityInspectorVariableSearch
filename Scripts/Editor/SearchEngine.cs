using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace InspectorVariableSearch
{
    /// <summary>
    /// Handles searching for variables in GameObject components
    /// </summary>
    public class SearchEngine
    {
        private List<SearchResult> searchResults = new List<SearchResult>();
        private Dictionary<Component, List<SearchResult>> categorizedResults = new Dictionary<Component, List<SearchResult>>();

        /// <summary>
        /// Gets the categorized search results
        /// </summary>
        public Dictionary<Component, List<SearchResult>> CategorizedResults => categorizedResults;

        /// <summary>
        /// Gets the raw search results
        /// </summary>
        public List<SearchResult> SearchResults => searchResults;

        /// <summary>
        /// Performs a search for variables in the selected GameObject
        /// </summary>
        /// <param name="searchText">The text to search for</param>
        public void PerformSearch(string searchText)
        {
            searchResults.Clear();
            categorizedResults.Clear();
            
            SearchInSelectedGameObject(searchText);
            CategorizeSearchResults();
        }

        /// <summary>
        /// Searches for variables in the selected GameObject
        /// </summary>
        private void SearchInSelectedGameObject(string searchText)
        {
            GameObject selectedObject = Selection.activeGameObject;
            
            if (selectedObject != null)
            {
                Component[] components = selectedObject.GetComponents<Component>();
                
                foreach (Component component in components)
                {
                    if (component != null)
                    {
                        SearchInComponent(component, searchText);
                    }
                }
            }
            else
            {
                Debug.Log("No GameObject selected");
            }
        }

        /// <summary>
        /// Searches for variables in a component
        /// </summary>
        private void SearchInComponent(Component component, string searchText)
        {
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | 
                                       BindingFlags.Instance | BindingFlags.Static;
            
            FieldInfo[] fields = component.GetType().GetFields(bindingFlags);
            
            foreach (var field in fields)
            {
                if (string.IsNullOrEmpty(searchText) || 
                    field.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    try
                    {
                        object fieldValue = field.GetValue(component);
                        searchResults.Add(new SearchResult(component, field, fieldValue));
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError($"Error accessing field {field.Name}: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// Categorizes search results by component
        /// </summary>
        private void CategorizeSearchResults()
        {
            foreach (var result in searchResults)
            {
                if (!categorizedResults.ContainsKey(result.Component))
                {
                    categorizedResults[result.Component] = new List<SearchResult>();
                }
                
                categorizedResults[result.Component].Add(result);
            }
        }

        /// <summary>
        /// Updates search results with current values
        /// </summary>
        /// <returns>True if any values changed and a repaint is needed</returns>
        public bool UpdateSearchResults()
        {
            bool shouldRepaint = false;
            
            foreach (var result in searchResults)
            {
                try
                {
                    if (result.Component == null) continue;
                    
                    object currentValue = result.Field.GetValue(result.Component);
                    
                    if (!Equals(currentValue, result.Value))
                    {
                        result.Value = currentValue;
                        shouldRepaint = true;
                    }
                }
                catch (Exception)
                {
                    // Component might have been destroyed
                    continue;
                }
            }
            
            return shouldRepaint;
        }
    }
}
