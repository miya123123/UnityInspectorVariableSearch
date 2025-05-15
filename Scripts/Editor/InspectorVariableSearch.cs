using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace InspectorVariableSearch
{
    /// <summary>
    /// Custom Unity Editor window for searching and editing variables within GameObject components
    /// </summary>
    public class InspectorVariableSearch : EditorWindow
    {
        #region Fields

        private string searchText = "";
        private Vector2 scrollPosition;
        private SearchEngine searchEngine;
        private FieldDrawer fieldDrawer;

        #endregion

        #region Unity Methods

        [MenuItem("Tools/Inspector Variable Search")]
        public static void Init()
        {
            InspectorVariableSearch window = (InspectorVariableSearch)GetWindow(typeof(InspectorVariableSearch));
            window.titleContent = new GUIContent("Variable Search");
            window.Show();
        }

        private void OnEnable()
        {
            searchEngine = new SearchEngine();
            fieldDrawer = new FieldDrawer();
            EditorApplication.update += UpdateSearchResults;
        }

        private void OnDisable()
        {
            EditorApplication.update -= UpdateSearchResults;
        }

        private void OnGUI()
        {
            DrawSearchBar();
            DrawSearchResults();
        }

        #endregion

        #region GUI Methods

        private void DrawSearchBar()
        {
            EditorGUILayout.BeginHorizontal();
            
            string newSearchText = EditorGUILayout.TextField("Search Text", searchText);
            if (newSearchText != searchText)
            {
                searchText = newSearchText;
            }
            
            if (GUILayout.Button("Search", GUILayout.Width(100)))
            {
                PerformSearch();
            }
            
            EditorGUILayout.EndHorizontal();
        }

        private void DrawSearchResults()
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Search Results:", EditorStyles.boldLabel);
            
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            
            try
            {
                if (searchEngine.CategorizedResults.Count == 0)
                {
                    EditorGUILayout.HelpBox("No results found. Use the search button to find variables.", MessageType.Info);
                }
                else
                {
                    DrawCategorizedResults();
                }
            }
            finally
            {
                EditorGUILayout.EndScrollView();
            }
        }

        private void DrawCategorizedResults()
        {
            List<Action> updates = new List<Action>();
            
            foreach (var category in searchEngine.CategorizedResults)
            {
                Component component = category.Key;
                
                if (component == null) continue;
                
                EditorGUILayout.LabelField(component.GetType().Name, EditorStyles.boldLabel);
                EditorGUI.indentLevel++;
                
                foreach (var result in category.Value)
                {
                    if (!EditorUtility.ShouldShowField(result.Field)) continue;
                    
                    EditorGUILayout.BeginHorizontal();
                    
                    try
                    {
                        EditorGUILayout.PrefixLabel(result.Field.Name);
                        EditorGUI.BeginChangeCheck();
                        
                        object newValue = fieldDrawer.DrawField(result.Field.FieldType, result.Value, result.Field.Name);
                        
                        if (EditorGUI.EndChangeCheck())
                        {
                            updates.Add(() => EditorUtility.UpdateField(component, result, newValue));
                        }
                    }
                    finally
                    {
                        EditorGUILayout.EndHorizontal();
                    }
                }
                
                EditorGUI.indentLevel--;
                EditorGUILayout.Space();
            }
            
            // Apply updates after drawing UI to avoid modification during enumeration
            foreach (var update in updates)
            {
                update.Invoke();
            }
        }

        #endregion

        #region Search Methods

        private void PerformSearch()
        {
            searchEngine.PerformSearch(searchText);
        }

        private void UpdateSearchResults()
        {
            if (searchEngine.UpdateSearchResults())
            {
                Repaint();
            }
        }

        #endregion
    }
}
