using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentAnims : MonoBehaviour, IAnimObserver
{
	public static EnvironmentAnims Instance;
	Animator animator;

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
		}
	}

	public void ChangeFloors()
	{
		animator.SetTrigger("TriggerFloorChange");
		
	}
}
