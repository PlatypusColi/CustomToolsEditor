using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class CustomDataStructure
{
	public string name;
	public GameObject target;
	public Vector3 position;

}

public class HelloWorld : MonoBehaviour
{
	[Range(0f, 10f)]
	public float speed;
	public Vector3 start_pos;

	[Tooltip("What the gameObject should follow")]
	public HelloWorld target;
	public string message = "HelloWorld!";

	[Header("Array tests")]
	public string[] strings;
	public int[] nbs;
	public Vector3[] positions;
	public GameObject[] objects;

	public CustomDataStructure[] custom_target;

	[HideInInspector]
	public List<string> string_list;
	public Dictionary<string, Vector3> children_pos;

	public int life{ get; set; }
}
