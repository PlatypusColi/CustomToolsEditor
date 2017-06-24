using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HelloWorld))]
public class HelloWorldEditor : Editor
{

	public override void OnInspectorGUI ()
	{
		var script = target as HelloWorld;

		EditorGUILayout.Space ();

		EditorGUILayout.LabelField (GetType ().ToString (), EditorUIUtil.gui_title_style);

		EditorGUILayout.Space ();

		EditorGUILayout.LabelField ("Put text here to explain what to do with the editor. Put text here to explain what to do with the editor. Put text here to explain what to do with the editor.", EditorUIUtil.gui_msg_style);

		EditorGUILayout.BeginVertical ("box");
		EditorGUILayout.Space ();
		script.speed = EditorGUILayout.Slider ("Speed", script.speed, 0f, 10f);

		script.target = EditorGUILayout.ObjectField ("Target", script.target, typeof(HelloWorld), true) as HelloWorld;
		if (script.target == null)
			EditorGUILayout.HelpBox ("There is an error.", MessageType.Error);

		EditorGUILayout.Space ();
		EditorGUILayout.EndVertical ();

		EditorGUILayout.Space ();

		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.LabelField ("A Button");
		if (GUILayout.Button("Open Test Window"))
		{
			EditorWindow.GetWindow (typeof(TestWindow));
		}

		EditorGUILayout.EndHorizontal ();
		//DrawDefaultInspector ();

		//EditorGUILayout.LabelField ("Custom Message", script.message);

	}


}

