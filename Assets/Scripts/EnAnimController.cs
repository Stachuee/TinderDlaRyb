using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnAnimController : MonoBehaviour, IAnimObserver
{
	Animator animator;

	[SerializeField] TextMeshProUGUI score;

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


	public void ChangeAnim(AnimStateController.AnimState newAnimState)
	{
		switch(newAnimState)
		{
			case AnimStateController.AnimState.EndAnim:
				animator.SetTrigger("TriggerEnd");
				StartCoroutine(SetScore());
				break;
			case AnimStateController.AnimState.MainMenu:
				animator.SetTrigger("TriggerReset");	
				break;
		}
	}

	IEnumerator SetScore()
	{
		yield return new WaitForSeconds(.1f);
		score.text = (GameManager.Instance.GetTargetFillAmmount() * 10).ToString("F1");
	}

}
