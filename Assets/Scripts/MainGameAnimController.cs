using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameAnimController : MonoBehaviour, IAnimObserver
{

	Animator animator;

	bool phoneOpen;

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
			case AnimStateController.AnimState.MainGame:
				animator.SetBool("InGame", true);
				break;
			case AnimStateController.AnimState.MainMenu:
				animator.SetBool("InGame", false);
				break;
			case AnimStateController.AnimState.EndAnim:
				animator.SetBool("InGame", false);
				break;
		}
	}

	public void SwitchPhone()
	{
		phoneOpen = !phoneOpen;
		animator.SetBool("OnPhone", phoneOpen);
	}
}
