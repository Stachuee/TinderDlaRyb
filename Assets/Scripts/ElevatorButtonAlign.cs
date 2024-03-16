using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonAlign : MonoBehaviour
{
    [SerializeField] Transform button;

    Camera cam;

	private void Start()
	{
		cam = Camera.main;
	}

	void Update()
    {
        transform.position = cam.WorldToScreenPoint(button.position);
    }
}
