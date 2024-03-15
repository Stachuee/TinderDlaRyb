using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishClothes : MonoBehaviour
{
    [SerializeField] ClothesSO item;
	[SerializeField] SpriteRenderer spriteRenderer;


	public void SetItem(ClothesSO item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    public ClothesSO GetItem()
    {
        return item;
    }
}
