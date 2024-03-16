using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IAnimObserver
{
    public static GameManager Instance;


	bool timerActive;
	[SerializeField] float timeToFinish;
	float timeRemain;

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
		Debug.Log(Stats.Compare(Fish.Instance.GetFinalStats(), CharacterCreator.Instance.GetCurrentLove().characterStats));
	}

	public void Exit()
	{
		timerActive = false;
		AnimStateController.Instance.ChangeAnimState(AnimStateController.AnimState.MainMenu);
	}

	public void StartGame()
	{
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
}
