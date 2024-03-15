using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour, IAnimObserver
{
	public static CamController Instance;

	[SerializeField] List<Vector3> CameraPositions;
	[SerializeField] float speed;

	public Vector3 currentTarget;

	
	private void Awake()
	{
		if(Instance == null)
		{
			Instance= this;
		}
		else
		{
			Debug.LogError("Two cam controllers");
		}
	}

	private void Start()
	{
		currentTarget = CameraPositions[0];

		AnimStateController.Instance.AddAnimObserver(this);
	}

	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
	}

	public void SwitchCam(int id)
	{
		currentTarget = CameraPositions[id];
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		CameraPositions.ForEach(pos =>
		{
			Gizmos.DrawWireSphere(pos, 1);
		});
	}

	public void ChangeAnim(AnimStateController.AnimState newAnimState)
	{
		switch(newAnimState)
		{
			case AnimStateController.AnimState.MainMenu:
				SwitchCam(0);
				break;
			case AnimStateController.AnimState.MainGame: 
				SwitchCam(1);
				break;
		}
	}
}
