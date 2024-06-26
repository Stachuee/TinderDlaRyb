using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WardrobeItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
	[SerializeField] ClothesSO item;
	[SerializeField] Image itemUI;

	Image image;
	RectTransform rectTransform;

	Vector2 startPos;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		image = GetComponent<Image>();
	}

	public void SetItem(ClothesSO clothes)
	{
		item = clothes;
		StartCoroutine(SetPosition());
		//image.sprite = item.GetSprite();
		itemUI.sprite = item.GetUISprite();
		itemUI.SetNativeSize();
	}

	IEnumerator SetPosition()
	{
		yield return new WaitForEndOfFrame();
		startPos = transform.localPosition;
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
		rectTransform.localPosition = startPos;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		itemUI.color = Color.gray;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		itemUI.color = Color.white;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		Fish.Instance.ChangeClothes(item);
	}
}
