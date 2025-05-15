using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TestParam : MonoBehaviour
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
    public int test_int;
    public bool test2_bool = true;
    public Transform[] test3_transform_array;
    public List<Color> test4_color_list;
    public List<IntList> test5_int_list_list = new List<IntList>();
    public int[] test6_int_array;
    public IntArray[] test7_int_array_array;
    public int test8_int_long_name_1234567890123456789012345678901234567890;
    public List<AudioSource> test9_audio_list;
    public List<Transform> test10_transform_list;
    public List<float> test11_int_list;
    public List<bool> test12_bool_list;
    public bool[] test13_bool_array;
    public int test14_int_property{get; set;}
    public bool test15_int_property{get; set;}
    [SerializeField]
    AudioSource test16_audio_source;
    public Material test17_material;
    [SerializeField]
    MeshRenderer test18_mesh_renderer;
    [SerializeField]
    ParticleSystem test19_particle_system;
    [SerializeField]
    Rigidbody2D test20_rigidbody2D;
    [SerializeField]
    Vector2 test21_vector2;
    public Color test22_color;
    public float test23_float;
    public string test24_string;
    [SerializeField]
    Vector3 test25_vector3;
    public GameObject test26_game_object;
    [SerializeField]
    Transform test27_transform;
    [SerializeField]
    Rigidbody test28_rigidbody;
    [SerializeField]
    Collider test29_collider;
    [SerializeField]
    Collider2D test30_collider2D;
    [SerializeField]
    Camera test31_camera;
    [SerializeField]
    Light test32_light;
    [SerializeField]
    Vector4 test33_vector4;
    [SerializeField]
    Animation test34_animation;
    [SerializeField]
    Animator test35_animator;
    public ScriptableObjectExample test36_scriptable_object;
    public TestEnum test37_enum;
    public Quaternion test38_quaternion;
    public LayerMask test39_layer_mask;
    public AnimationCurve test40_animation_curve;
    public Gradient test41_gradient;


}