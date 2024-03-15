using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    public static Wardrobe wardrobe;

	[SerializeField] List<Transform> wardrobeSegments;

	private void Awake()
	{
		if(wardrobe == null)
		{
			wardrobe = this;
		}
		else
		{
			Debug.LogError("Two wardrobe controllers");
		}
	}

}
