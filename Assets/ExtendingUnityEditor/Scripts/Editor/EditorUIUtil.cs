using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorUIUtil
{
	public static GUIStyle gui_title_style
	{
		get 
		{		
			var gui_title_style = new GUIStyle (GUI.skin.label);
			gui_title_style.normal.textColor = Color.black;
			gui_title_style.fontSize = 16;
			gui_title_style.fixedHeight = 30;

			return (gui_title_style);
		}
	}

	public static GUIStyle gui_msg_style
	{
		get
		{
			var msg_style = new GUIStyle (GUI.skin.label);
			msg_style.wordWrap = true;
			return (msg_style);
		}
	}

}
