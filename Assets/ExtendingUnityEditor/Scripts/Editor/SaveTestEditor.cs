using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditorInternal;

[CustomEditor(typeof(SaveTest))]
public class SaveTestEditor : Editor
{
//	private ReorderableList list;
//	private SaveTest save_test_script;
//
//	private void Enable()
//	{
//		save_test_script = Selection.activeGameObject.GetComponent<SaveTest> ();
//		list = new ReorderableList (serializedObject, serializedObject.FindProperty ("items"), true, true, true, true);
//	}
	// ne marchait pas.

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();

		EditorGUILayout.Space ();

		EditorGUILayout.LabelField (GetType ().ToString (), EditorUIUtil.gui_title_style);

		EditorGUILayout.Space ();

		EditorGUILayout.LabelField ("Put text here to explain what to do with the editor. Put text here to explain what to do with the editor. Put text here to explain what to do with the editor.", EditorUIUtil.gui_msg_style);

		//list.DoLayoutList(); donne une null exception error donc commenté.

		var save_test_script = Selection.activeGameObject.GetComponent<SaveTest> ();

		EditorGUILayout.BeginVertical ();
		if (GUILayout.Button ("Save"))
		{
			var text = save_test_script.Save ();

			WriteData (text);
		}

		if (GUILayout.Button ("Load"))
		{
			save_test_script.Load (ReadDataFromFile());
		}

		EditorGUILayout.EndVertical ();
	}

	private void WriteData(string data)
	{
		var path = EditorUtility.SaveFilePanel ("Save Data", "", "data.txt", "txt");

		using (FileStream fs = new FileStream (path, FileMode.Create))
		{
			using (StreamWriter writer = new StreamWriter (fs))
			{
				writer.Write (data);
			}
		}

		AssetDatabase.Refresh ();
	}

	private string ReadDataFromFile()
	{
		var path = EditorUtility.OpenFilePanel ("Load Data", "", "txt");

		Debug.Log (path);
		var reader = new WWW ("file:///" + path);
		if (reader == null)
			Debug.Log ("Reading failed");
		while (!reader.isDone) {
		}
		//pb avec reader : text est null alors que le fichier contient bien les infos. Pas trouvé de solution.
		return (reader.text);
	}
}
