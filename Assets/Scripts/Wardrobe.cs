using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    public static Wardrobe wardrobe;

	[SerializeField] List<Transform> wardrobeSegments;

	int current;

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


	public void ChangeFloor(int change)
	{
		wardrobeSegments[current].gameObject.SetActive(false);
		current += change;
		current = Mathf.Clamp(current, 0, wardrobeSegments.Count - 1);
		wardrobeSegments[current].gameObject.SetActive(true);

		EnvironmentAnims.Instance.ChangeFloors();
	}
}
