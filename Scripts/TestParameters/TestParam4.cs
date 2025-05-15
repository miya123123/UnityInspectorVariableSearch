using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TestParam4 : MonoBehaviour
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
    protected private int test_int;
    protected private bool test2_bool;
    protected private Transform[] test3_transform_array;
    protected private List<Color> test4_color_list;
    protected private List<IntList> test5_int_list_list;
    protected int[] test6_int_array;
    protected private IntArray[] test7_int_array_array;
    [SerializeField]
    protected int test8_int_long_name_1234567890123456789012345678901234567890;
    protected List<AudioSource> test9_audio_list;
    protected List<Transform> test10_transform_list;
    protected private List<float> test11_int_list;
    protected List<bool> test12_bool_list;
    [SerializeField]
    protected private bool[] test13_bool_array;
    protected private int test14_int_property{get; set;}
    protected bool test15_int_property{get; set;}
    protected AudioSource test16_audio_source;
    protected private Material test17_material;
    protected MeshRenderer test18_mesh_renderer;
    protected ParticleSystem test19_particle_system;
    [SerializeField]
    protected private Rigidbody2D test20_rigidbody2D;
    protected Vector2 test21_vector2;
    protected private Color test22_color;
    protected private float test23_float;
    protected private string test24_string;
    protected Vector3 test25_vector3;
    protected private GameObject test26_game_object;
    protected Transform test27_transform;
    [SerializeField]
    protected Rigidbody test28_rigidbody;
    protected Collider test29_collider;
    protected Collider2D test30_collider2D;
    protected Camera test31_camera;
    protected Light test32_light;
    protected Vector4 test33_vector4;
    [SerializeField]
    protected Animation test34_animation;
    protected Animator test35_animator;
    protected private ScriptableObjectExample test36_scriptable_object;
    protected private TestEnum test37_enum;
    protected private Quaternion test38_quaternion;
    protected private LayerMask test39_layer_mask;
    protected private AnimationCurve test40_animation_curve;
    protected private Gradient test41_gradient;


}