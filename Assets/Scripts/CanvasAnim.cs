using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAnim : MonoBehaviour, IAnimObserver
{
    public static CanvasAnim Instance;

	Animator animator;


	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogError("Two canves anim");
		}

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
			case AnimStateController.AnimState.MainMenu:
				animator.SetTrigger("TriggerBackToMenu");
				break;
			case AnimStateController.AnimState.MainGame:
				animator.SetTrigger("TriggerMainGame");
				break;
			case AnimStateController.AnimState.StartingAnim:
				animator.SetTrigger("TriggerFirstCutscene");
				break;
		}

	}
}
