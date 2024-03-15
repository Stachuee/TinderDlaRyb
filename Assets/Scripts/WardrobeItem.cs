using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WardrobeItem : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] ClothesSO item;

	Image image;
	RectTransform rectTransform;

	Vector2 startPos;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		image = GetComponent<Image>();
	}

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

	public void OnEndDrag(PointerEventData eventData)
	{
		if (transform.position.x < Screen.width / 2)
		{
			Fish.Instance.ChangeClothes(item);
		}
		rectTransform.position = startPos;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		image.color = Color.gray;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		image.color = Color.white;
	}
}
