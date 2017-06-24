using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

[System.Serializable]
public class SaveItem
{
	public string name;
	public Vector2 position;

	public new string ToString()
	{
		return (name + "," + position.x + "," + position.y);
	}
}

public class SaveTest : MonoBehaviour
{
	public List<SaveItem> items = new List<SaveItem> (2);

	public string Save()
	{
		var sb = new StringBuilder ();
		var total = items.Count;
		var i = 0;

		while (i < total)
		{
			sb.Append (items [i].ToString ());
			if (i < total - 1)
				sb.Append (";");
			++i;
		}

		return (sb.ToString ());
	}

	public void Load(string data)
	{
		items = new List<SaveItem> ();
		if (data == "")
		{
			Debug.Log ("File is empty?");
			//à cause du load qui ne fonctionne pas, pour continuer le tutoriel j'hardcode le contenu de la liste ici.
			items = new List<SaveItem> (2);
			items [0].name = "item1";
			items [0].position.x = 0;
			items [0].position.y = 0;
			items [1].name = "item2";
			items [1].position.x = 10;
			items [1].position.y = 10;
			return;
		}
		var item_data = data.Split (';');

		var total = item_data.Length;
		var i = 0;

		while (i < total)
		{
			var values = item_data [i].Split (',');
			var item = new SaveItem ();
			item.name = values [0];
			item.position = new Vector2 (Int32.Parse (values [1]), Int32.Parse (values [2]));
			items.Add (item);
		}
	}
}
