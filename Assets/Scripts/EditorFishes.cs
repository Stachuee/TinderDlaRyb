using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public class EditorFishes : Editor
{
	//We connect the editor with the Weapon SO class
	[CustomEditor(typeof(FishesSO))]
	//We need to extend the Editor
	public class WeaponEditor : Editor
	{
		//Here we grab a reference to our Weapon SO
		FishesSO clothes;

		private void OnEnable()
		{
			//target is by default available for you
			//because we inherite Editor
			clothes = target as FishesSO;
		}

		//Here is the meat of the script
		public override void OnInspectorGUI()
		{
			//Draw whatever we already have in SO definition
			base.OnInspectorGUI();
			//Guard clause

			Sprite sprite = clothes.GetIcon();
			if (sprite == null)
				return;

			//Convert the weaponSprite (see SO script) to Texture
			Texture2D texture = AssetPreview.GetAssetPreview(sprite);
			//We crate empty space 80x80 (you may need to tweak it to scale better your sprite
			//This allows us to place the image JUST UNDER our default inspector
			GUILayout.Label("", GUILayout.Height(200), GUILayout.Width(200));
			//Draws the texture where we have defined our Label (empty space)
			GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
		}
	}
}
#endif