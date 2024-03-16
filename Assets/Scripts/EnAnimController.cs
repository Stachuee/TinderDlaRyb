using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnAnimController : MonoBehaviour, IAnimObserver
{
	Animator animator;

	[SerializeField] Image fill;

	float targetFill;
	float startFilling;
	const float fillTime = 0.8f;
	bool filling;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	void Start()
    {
        AnimStateController.Instance.AddAnimObserver(this);
    }

	private void Update()
	{
		if(filling)
		{
			float fillAmmount = (Time.time - startFilling) / fillTime;
			fill.fillAmount = fillAmmount;
			if(fillAmmount >= targetFill)
			{
				filling = false;
			}
		}
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
				fill.fillAmount = 0;
				break;
		}
	}

	public void AnimateFill()
	{
		targetFill = GameManager.Instance.GetTargetFillAmmount();
		startFilling= Time.time;
		filling = true;
	}

}
