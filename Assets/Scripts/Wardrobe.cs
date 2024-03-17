using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour, IAnimObserver
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
		if (EnvironmentAnims.Instance.CategoryLocked()) return;
		wardrobeSegments[current].gameObject.SetActive(false);
		current += change;
		current = Mathf.Clamp(current, 0, wardrobeSegments.Count - 1);
		wardrobeSegments[current].gameObject.SetActive(true);

		EnvironmentAnims.Instance.ChangeFloors();
	}

	public void ChangeAnim(AnimStateController.AnimState newAnimState)
	{
		if(newAnimState == AnimStateController.AnimState.MainMenu)
		{
			wardrobeSegments[current].gameObject.SetActive(false);
			wardrobeSegments[0].gameObject.SetActive(true);
		}
	}
}
