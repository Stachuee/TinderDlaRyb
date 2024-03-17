using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnvironmentAnims : MonoBehaviour, IAnimObserver
{
	public static EnvironmentAnims Instance;
	Animator animator;

	[SerializeField] GameObject good;
	[SerializeField] GameObject neutral;
	[SerializeField] GameObject bad;

	bool elevatorLocked;

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogError("Two enviro animators");
		}
		animator = GetComponent<Animator>();
	}

	private void Start()
	{
		AnimStateController.Instance.AddAnimObserver(this);
	}

	public void ChangeAnim(AnimStateController.AnimState newAnimState)
	{
		switch(newAnimState)
		{
			case AnimStateController.AnimState.StartingAnim:
				animator.SetTrigger("TriggerFirstCutscene");
				LockWardrobe();
				break;
			case AnimStateController.AnimState.MainMenu:
				animator.SetTrigger("TriggerReset");
				break;
			case AnimStateController.AnimState.EndAnim:
				animator.SetTrigger("TriggerEnd");
				good.SetActive(false);
				bad.SetActive(false);
				neutral.SetActive(true);
				break;
		}
	}

	public void RevealMood()
	{
		float score = GameManager.Instance.GetTargetFillAmmount();
		good.SetActive(false);
		bad.SetActive(false);
		neutral.SetActive(true);

		if (score < 0.33f)
		{
			bad.SetActive(true);
		}
		else if (score > 0.66f)
		{
			good.SetActive(true);
			neutral.SetActive(false);
		}
	}

	public void ChangeFloors()
	{
		if(!elevatorLocked)
		animator.SetTrigger("TriggerFloorChange");
	}

	public void LockCategory()
	{
		elevatorLocked = true;
	}

	public void UnlockedCategory()
	{
		elevatorLocked = false;
	}

	public bool CategoryLocked()
	{
		return elevatorLocked;
	}

	public void UnlockWardrobe()
	{
		Wardrobe.wardrobe.LockWardrobe(false);
	}
	public void LockWardrobe()
	{
		Wardrobe.wardrobe.LockWardrobe(true);
	}
}
