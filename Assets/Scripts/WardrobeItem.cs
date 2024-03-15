using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WardrobeItem : MonoBehaviour, IDragHandler, IDropHandler
{
	[SerializeField] ClothesSO item;
	Vector2 startPos;

	private void Start()
	{
		StartCoroutine(SetPosition());
	}
	IEnumerator SetPosition()
	{
		yield return new WaitForEndOfFrame();
		startPos = transform.position;
	}

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	public void OnDrop(PointerEventData eventData)
	{
		if(transform.position.x < Screen.width / 2)
		{
			Fish.Instance.ChangeClothes(item);
		}
		transform.position = startPos;
	}
}
