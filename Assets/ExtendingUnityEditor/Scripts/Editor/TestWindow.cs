using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestWindow : EditorWindow
{
	private GameObject curr_selection;

	[MenuItem("Window/Test Window")]
	static void Init()
	{
		var window = (TestWindow)GetWindow (typeof(TestWindow));

		var content = new GUIContent ();
		content.text = "Test Window";

		var icon = new Texture2D (16, 16);
		content.image = icon;

		window.titleContent = content;
	}

	private void OnFocus()
	{
		curr_selection = Selection.activeGameObject;
	}

	private void OnLostFocus()
	{
		curr_selection = null;
	}

	private void OnGUI()
	{
		if (curr_selection) {
			EditorGUILayout.BeginVertical ();
			EditorGUILayout.LabelField ("Currently Selected GameObject:");
			EditorGUILayout.LabelField (curr_selection.name);
			curr_selection.transform.position = EditorGUILayout.Vector3Field ("At position", curr_selection.transform.position);

			EditorGUILayout.EndVertical ();
		}
		else
		{
			EditorGUILayout.LabelField ("Select a GameObject first then click here.");
		}

		DropAreaGUI ();
	}

	private void DropAreaGUI()
	{
		var e = Event.current.type;

		if (e == EventType.DragUpdated)
		{
			DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
		}
		else if (e == EventType.dragPerform)
		{
			DragAndDrop.AcceptDrag ();

			foreach (Object dragged_obj in DragAndDrop.objectReferences)
			{
				if (dragged_obj is GameObject)
					Debug.Log (dragged_obj.name);
			}
		}
	}
}
