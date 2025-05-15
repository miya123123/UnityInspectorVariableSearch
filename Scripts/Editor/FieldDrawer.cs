using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace InspectorVariableSearch
{
    /// <summary>
    /// Handles drawing and editing fields in the Inspector Variable Search window
    /// </summary>
    public class FieldDrawer
    {
        /// <summary>
        /// Draws a field based on its type
        /// </summary>
        public object DrawField(Type fieldType, object value, string fieldName)
        {
            if (value == null)
            {
                EditorGUILayout.LabelField("Null value");
                return null;
            }

            // Handle special types
            if (fieldType.IsArray)
            {
                return DrawArrayField(fieldType, value, fieldName);
            }
            else if (typeof(IList).IsAssignableFrom(fieldType))
            {
                return DrawListField(fieldType, value, fieldName);
            }

            // Handle primitive and Unity types
            return DrawBasicField(fieldType, value);
        }

        /// <summary>
        /// Draws basic field types (primitives and Unity types)
        /// </summary>
        private object DrawBasicField(Type fieldType, object value)
        {
            // Primitive types
            if (fieldType == typeof(int))
            {
                return EditorGUILayout.IntField("", (int)value);
            }
            else if (fieldType == typeof(float))
            {
                return EditorGUILayout.FloatField("", (float)value);
            }
            else if (fieldType == typeof(string))
            {
                return EditorGUILayout.TextField("", (string)value);
            }
            else if (fieldType == typeof(bool))
            {
                return EditorGUILayout.Toggle("", (bool)value);
            }
            
            // Unity vector types
            else if (fieldType == typeof(Vector2))
            {
                return EditorGUILayout.Vector2Field("", (Vector2)value);
            }
            else if (fieldType == typeof(Vector3))
            {
                return EditorGUILayout.Vector3Field("", (Vector3)value);
            }
            else if (fieldType == typeof(Vector4))
            {
                return EditorGUILayout.Vector4Field("", (Vector4)value);
            }
            
            // Unity object types
            else if (typeof(UnityEngine.Object).IsAssignableFrom(fieldType))
            {
                return EditorGUILayout.ObjectField("", (UnityEngine.Object)value, fieldType, true);
            }
            
            // Other common Unity types
            else if (fieldType == typeof(Color))
            {
                return EditorGUILayout.ColorField("", (Color)value);
            }
            else if (fieldType == typeof(AnimationCurve))
            {
                return EditorGUILayout.CurveField("", (AnimationCurve)value);
            }
            else if (fieldType == typeof(Gradient))
            {
                return EditorGUILayout.GradientField("", (Gradient)value);
            }
            else if (fieldType == typeof(Quaternion))
            {
                Quaternion quaternion = (Quaternion)value;
                Vector4 vec4 = new Vector4(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
                vec4 = EditorGUILayout.Vector4Field("", vec4);
                return new Quaternion(vec4.x, vec4.y, vec4.z, vec4.w);
            }
            else if (fieldType == typeof(LayerMask))
            {
                LayerMask layerMask = (LayerMask)value;
                return DrawLayerMaskField(layerMask);
            }
            else if (fieldType.IsEnum)
            {
                return EditorGUILayout.EnumPopup("", (Enum)value);
            }
            
            // Default case
            EditorGUILayout.LabelField($"[{fieldType.Name}]");
            return value;
        }

        /// <summary>
        /// Draws a LayerMask field
        /// </summary>
        private LayerMask DrawLayerMaskField(LayerMask layerMask)
        {
            List<string> layers = new List<string>();
            List<int> layerNumbers = new List<int>();
            
            for (int i = 0; i < 32; i++)
            {
                string layerName = LayerMask.LayerToName(i);
                
                if (!string.IsNullOrEmpty(layerName))
                {
                    layers.Add(layerName);
                    layerNumbers.Add(i);
                }
            }
            
            int maskWithoutEmpty = 0;
            for (int i = 0; i < layerNumbers.Count; i++)
            {
                if (((1 << layerNumbers[i]) & layerMask.value) != 0)
                {
                    maskWithoutEmpty |= (1 << i);
                }
            }
            
            int newMaskWithoutEmpty = EditorGUILayout.MaskField("", maskWithoutEmpty, layers.ToArray());
            
            int newMask = 0;
            for (int i = 0; i < layerNumbers.Count; i++)
            {
                if ((newMaskWithoutEmpty & (1 << i)) != 0)
                {
                    newMask |= (1 << layerNumbers[i]);
                }
            }
            
            return newMask;
        }

        /// <summary>
        /// Draws an array field
        /// </summary>
        private object DrawArrayField(Type fieldType, object value, string fieldName)
        {
            if (value == null)
            {
                EditorGUILayout.LabelField("Null array");
                return null;
            }
            
            Type elementType = fieldType.GetElementType();
            Array array = value as Array;
            
            int newSize = EditorGUILayout.IntField("Size", array.Length);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginVertical();
            
            if (newSize != array.Length && newSize >= 0)
            {
                Array resizedArray = Array.CreateInstance(elementType, newSize);
                Array.Copy(array, resizedArray, Math.Min(array.Length, newSize));
                array = resizedArray;
            }
            
            EditorGUI.indentLevel++;
            
            for (int i = 0; i < array.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel($"Element {i}");
                
                object elementValue = array.GetValue(i);
                object newElementValue = DrawField(elementType, elementValue, $"Element {i}");
                
                if (!Equals(elementValue, newElementValue))
                {
                    array.SetValue(newElementValue, i);
                }
                
                DrawArrayElementButtons(array, i);
                
                EditorGUILayout.EndHorizontal();
            }
            
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginHorizontal();
            
            return array;
        }

        /// <summary>
        /// Draws buttons for array element manipulation
        /// </summary>
        private void DrawArrayElementButtons(Array array, int index)
        {
            // Move up button
            if (GUILayout.Button("↑", GUILayout.Width(30), GUILayout.Height(18)) && index > 0)
            {
                object temp = array.GetValue(index);
                array.SetValue(array.GetValue(index - 1), index);
                array.SetValue(temp, index - 1);
            }
            
            // Move down button
            if (GUILayout.Button("↓", GUILayout.Width(30), GUILayout.Height(18)) && index < array.Length - 1)
            {
                object temp = array.GetValue(index);
                array.SetValue(array.GetValue(index + 1), index);
                array.SetValue(temp, index + 1);
            }
        }

        /// <summary>
        /// Draws a list field
        /// </summary>
        private object DrawListField(Type fieldType, object value, string fieldName)
        {
            if (value == null)
            {
                EditorGUILayout.LabelField("Null list");
                return null;
            }
            
            Type elementType = fieldType.GetGenericArguments()[0];
            IList list = value as IList;
            
            int newSize = EditorGUILayout.IntField(fieldName + " Size", list.Count);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginVertical();
            
            if (newSize != list.Count && newSize >= 0)
            {
                list = ResizeList(list, elementType, newSize);
            }
            
            EditorGUI.indentLevel++;
            
            for (int i = 0; i < list.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                
                if (typeof(IList).IsAssignableFrom(elementType))
                {
                    if (list[i] == null)
                    {
                        list[i] = Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType.GetGenericArguments()[0]));
                    }
                    
                    EditorGUILayout.LabelField($"Element {i} (List)");
                    list[i] = DrawListField(elementType, list[i], $"Element {i}");
                }
                else
                {
                    EditorGUILayout.PrefixLabel($"Element {i}");
                    list[i] = DrawField(elementType, list[i], $"Element {i}");
                }
                
                EditorGUILayout.EndHorizontal();
            }
            
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginHorizontal();
            
            return list;
        }

        /// <summary>
        /// Resizes a list
        /// </summary>
        private IList ResizeList(IList originalList, Type elementType, int newSize)
        {
            IList newList = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType));
            
            for (int i = 0; i < newSize; i++)
            {
                if (i < originalList.Count)
                {
                    newList.Add(originalList[i]);
                }
                else
                {
                    newList.Add(CreateDefaultValue(elementType));
                }
            }
            
            return newList;
        }

        /// <summary>
        /// Creates a default value for a type
        /// </summary>
        private object CreateDefaultValue(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            
            return null;
        }
    }
}
