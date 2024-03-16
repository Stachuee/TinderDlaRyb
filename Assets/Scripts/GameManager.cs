using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IAnimObserver
{
    public static GameManager Instance;


	bool timerActive;
	[SerializeField] float timeToFinish;
	float timeRemain;

	[SerializeField] float maxScore;
	[SerializeField] float worstScore;

	public float score;

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogError("Two game managers");
		}
	}

	private void Start()
	{
		AnimStateController.Instance.AddAnimObserver(this);
	}


	private void Update()
	{
		if(timerActive)
		{
			timeRemain -= Time.deltaTime;
			if(timeRemain <= 0 )
			{
				End();
			}
		}
	}

	public void StartTimer()
	{
		timerActive = true;
		timeRemain = timeToFinish;
	}

	public void End()
	{
		timerActive = false;
		AnimStateController.Instance.ChangeAnimState(AnimStateController.AnimState.EndAnim);
		float curScore = Stats.Compare(Fish.Instance.GetFinalStats() / 5, CharacterCreator.Instance.GetCurrentLove().characterStats);
		float lerpScore = Mathf.Lerp(0, maxScore,  Mathf.Clamp01(1 - (curScore / worstScore)));
		score = lerpScore;
		Debug.Log(lerpScore);
	}

	public void Exit()
	{
		timerActive = false;
		AnimStateController.Instance.ChangeAnimState(AnimStateController.AnimState.MainMenu);
	}

	public void StartGame()
	{
		if (AnimStateController.Instance.currentState != AnimStateController.AnimState.MainMenu) return;
		CharacterCreator.Instance.CreateCharacter();
		AnimStateController.Instance.ChangeAnimState(AnimStateController.AnimState.StartingAnim);
	}

	public float GetCurrentTimerProgress()
	{
		return 1 - (timeRemain / timeToFinish);
	}

	public void ChangeAnim(AnimStateController.AnimState newAnimState)
	{
		switch(newAnimState)
		{
			case AnimStateController.AnimState.MainGame:
				StartTimer();
				break;
			case AnimStateController.AnimState.EndAnim:
				timerActive = false;
				break;
		}
	}

	public float GetTargetFillAmmount()
	{
		return score / maxScore;
	}
}
