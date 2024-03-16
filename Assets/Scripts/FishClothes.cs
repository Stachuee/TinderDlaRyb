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
        if(item != null)
        {
			spriteRenderer.sprite = item.GetSprite();
		}
        else
        {
            spriteRenderer.sprite = null;
        }
        
    }

    public void RemoveItem()
    {
        this.item = null;
        spriteRenderer.sprite = null;
    }

    public ClothesSO GetItem()
    {
        return item;
    }
}
