using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour, IAnimObserver
{
    public static Wardrobe wardrobe;

	[SerializeField] List<Transform> wardrobeSegments;

	int current;

	bool lockWardrobe;

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

	private void Start()
	{
		AnimStateController.Instance.AddAnimObserver(this);
	}


	public void ChangeFloor(int change)
	{
		if (EnvironmentAnims.Instance.CategoryLocked() || lockWardrobe) return;


		wardrobeSegments[current].gameObject.SetActive(false);
		current += change;
		int prev = current;
		current = Mathf.Clamp(current, 0, wardrobeSegments.Count - 1);
		wardrobeSegments[current].gameObject.SetActive(true);

		if(prev == current) EnvironmentAnims.Instance.ChangeFloors();
	}

	public void ChangeAnim(AnimStateController.AnimState newAnimState)
	{
		if(newAnimState == AnimStateController.AnimState.MainMenu)
		{
			wardrobeSegments[current].gameObject.SetActive(false);
			current = 0;
			wardrobeSegments[0].gameObject.SetActive(true);
		}
	}

	public void LockWardrobe(bool value)
	{
		lockWardrobe = value;
	}
}
