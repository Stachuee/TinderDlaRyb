using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentAnims : MonoBehaviour, IAnimObserver
{
	public static EnvironmentAnims Instance;
	Animator animator;

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
				break;
			case AnimStateController.AnimState.MainMenu:
				animator.SetTrigger("TriggerReset");
				break;
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
}
