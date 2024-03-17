using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

	[SerializeField] Image timerSlider;

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogError("Two timers");
		}
	}

	private void Update()
	{
		UpdateTimer();
	}

	public void UpdateTimer()
	{
		timerSlider.fillAmount = GameManager.Instance.GetCurrentTimerProgress();
	}
}
