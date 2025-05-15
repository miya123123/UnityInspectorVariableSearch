using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TestParam6 : MonoBehaviour
{
    [Serializable]
    public class IntList
    {
        public List<int> myList = new List<int>();
    }
    [Serializable]
    public class IntArray
    {
        public int[] myArray;
    }
    public enum TestEnum
    {
        FirstOption,
        SecondOption,
        ThirdOption
    }
    internal protected int test_int;
    internal protected bool test2_bool;
    internal protected Transform[] test3_transform_array;
    internal protected List<Color> test4_color_list;
    internal protected List<IntList> test5_int_list_list;
    internal int[] test6_int_array;
    internal protected IntArray[] test7_int_array_array;
    [SerializeField]
    internal int test8_int_long_name_1234567890123456789012345678901234567890;
    internal List<AudioSource> test9_audio_list;
    internal List<Transform> test10_transform_list;
    internal protected List<float> test11_int_list;
    internal List<bool> test12_bool_list;
    [SerializeField]
    internal protected bool[] test13_bool_array;
    internal protected int test14_int_property{get; set;}
    internal bool test15_int_property{get; set;}
    internal AudioSource test16_audio_source;
    internal protected Material test17_material;
    internal MeshRenderer test18_mesh_renderer;
    internal ParticleSystem test19_particle_system;
    [SerializeField]
    internal protected Rigidbody2D test20_rigidbody2D;
    internal Vector2 test21_vector2;
    internal protected Color test22_color;
    internal protected float test23_float;
    internal protected string test24_string;
    internal Vector3 test25_vector3;
    internal protected GameObject test26_game_object;
    internal Transform test27_transform;
    [SerializeField]
    internal Rigidbody test28_rigidbody;
    internal Collider test29_collider;
    internal Collider2D test30_collider2D;
    internal Camera test31_camera;
    internal Light test32_light;
    internal Vector4 test33_vector4;
    [SerializeField]
    internal Animation test34_animation;
    internal Animator test35_animator;
    internal protected ScriptableObjectExample test36_scriptable_object;
    internal protected TestEnum test37_enum;
    internal protected Quaternion test38_quaternion;
    internal protected LayerMask test39_layer_mask;
    internal protected AnimationCurve test40_animation_curve;
    internal protected Gradient test41_gradient;


}