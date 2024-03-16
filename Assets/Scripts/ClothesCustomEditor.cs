using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClothesCustomEditor : Editor
{
	//We connect the editor with the Weapon SO class
	[CustomEditor(typeof(ClothesSO))]
	//We need to extend the Editor
	public class WeaponEditor : Editor
	{
		//Here we grab a reference to our Weapon SO
		ClothesSO clothes;

		private void OnEnable()
		{
			//target is by default available for you
			//because we inherite Editor
			clothes = target as ClothesSO;
		}

		//Here is the meat of the script
		public override void OnInspectorGUI()
		{
			//Draw whatever we already have in SO definition
			base.OnInspectorGUI();
			//Guard clause

			Sprite sprite = clothes.GetSprite();
			if (sprite == null)
				return;

			//Convert the weaponSprite (see SO script) to Texture
			Texture2D texture = AssetPreview.GetAssetPreview(sprite);
			//We crate empty space 80x80 (you may need to tweak it to scale better your sprite
			//This allows us to place the image JUST UNDER our default inspector
			GUILayout.Label("", GUILayout.Height(300), GUILayout.Width(600));
			//Draws the texture where we have defined our Label (empty space)
			GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
		}
	}
}
