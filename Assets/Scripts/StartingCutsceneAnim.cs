using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCutsceneAnim : MonoBehaviour, IAnimObserver
{
    Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	private void Start()
	{
		AnimStateController.Instance.AddAnimObserver(this);
	}

	public void ChangeAnim(AnimStateController.AnimState newAnimState)
	{

		switch (newAnimState)
		{
			case AnimStateController.AnimState.StartingAnim:
				animator.SetTrigger("TriggerFirstCutscene");
				break;
		}
	}

	public void EndAnim()
	{
		AnimStateController.Instance.ChangeAnimState(AnimStateController.AnimState.MainGame);
	}

}
