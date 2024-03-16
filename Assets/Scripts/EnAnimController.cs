using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnAnimController : MonoBehaviour, IAnimObserver
{
	Animator animator;

	[SerializeField] Image fill;

	float targetFill;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	void Start()
    {
        AnimStateController.Instance.AddAnimObserver(this);
    }

	public void ChangeAnim(AnimStateController.AnimState newAnimState)
	{
		switch(newAnimState)
		{
			case AnimStateController.AnimState.EndAnim:
				animator.SetTrigger("TriggerEnd");
				break;
			case AnimStateController.AnimState.MainMenu:
				animator.SetTrigger("TriggerReset");
				break;
		}
	}

	public void AnimateFill()
	{
		targetFill = GameManager.Instance.GetTargetFillAmmount();
		fill.fillAmount = targetFill;
	}

}
