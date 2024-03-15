using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStateController : MonoBehaviour
{
	public static AnimStateController Instance;

	public enum AnimState { MainMenu, StartingAnim, MainGame, EndAnim }
	public AnimState currentState;

	List<IAnimObserver> observers = new List<IAnimObserver>();

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogError("Two Anim State Controller in one scene");
		}
	}

	public void ChangeAnimState(AnimState newAnimState)
	{
		if (newAnimState == currentState) return;
		observers.ForEach(x => x.ChangeAnim(newAnimState));
		currentState = newAnimState;
	}

	public void AddAnimObserver(IAnimObserver animObserver)
	{
		observers.Add(animObserver);
	}

	public void RemoveAnimObserver(IAnimObserver animObserver)
	{
		observers.Remove(animObserver);
	}
}
