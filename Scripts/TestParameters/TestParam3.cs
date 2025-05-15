using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TestParam3 : MonoBehaviour
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
    private int test_int;
    private bool test2_bool;
    private Transform[] test3_transform_array;
    private List<Color> test4_color_list;
    private List<IntList> test5_int_list_list;
    private int[] test6_int_array;
    private IntArray[] test7_int_array_array;
    private int test8_int_long_name_1234567890123456789012345678901234567890;
    private List<AudioSource> test9_audio_list;
    private List<Transform> test10_transform_list;
    private List<float> test11_int_list;
    private List<bool> test12_bool_list;
    private bool[] test13_bool_array;
    private int test14_int_property{get; set;}
    private bool test15_int_property{get; set;}
    AudioSource test16_audio_source;
    private Material test17_material;
    MeshRenderer test18_mesh_renderer;
    ParticleSystem test19_particle_system;
    Rigidbody2D test20_rigidbody2D;
    Vector2 test21_vector2;
    private Color test22_color;
    private float test23_float;
    private string test24_string;
    Vector3 test25_vector3;
    private GameObject test26_game_object;
    Transform test27_transform;
    Rigidbody test28_rigidbody;
    Collider test29_collider;
    Collider2D test30_collider2D;
    Camera test31_camera;
    Light test32_light;
    Vector4 test33_vector4;
    Animation test34_animation;
    Animator test35_animator;
    private ScriptableObjectExample test36_scriptable_object;
    private TestEnum test37_enum;
    private Quaternion test38_quaternion;
    private LayerMask test39_layer_mask;
    private AnimationCurve test40_animation_curve;
    private Gradient test41_gradient;
    [HideInInspector]
    public Gradient test42_gradient;


}