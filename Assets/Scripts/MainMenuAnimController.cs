using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimController : MonoBehaviour, IAnimObserver
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
		switch(newAnimState)
		{
			case AnimStateController.AnimState.MainMenu:
				animator.SetBool("MenuShown", true);
				break;
			case AnimStateController.AnimState.StartingAnim:
				animator.SetBool("MenuShown", false);
				ShowCredits(false);
				ShowOptions(false);
				break;
			case AnimStateController.AnimState.EndAnim:
				animator.SetBool("MenuShown", false);
				ShowCredits(false);
				ShowOptions(false);
				break;
		}
	}

	public void ShowCredits(bool value)
	{
		animator.SetBool("CreditsShown", value);
	}
	public void ShowOptions(bool value)
	{
		animator.SetBool("OptionsShown", value);
	}
}
