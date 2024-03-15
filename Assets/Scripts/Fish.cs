using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public static Fish Instance;

    [SerializeField] List<SpriteRenderer> clothes;

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogError("Two fishes");
		}
	}


	public void ChangeClothes(ClothesSO clothes)
	{
		this.clothes[(int)clothes.GetClothesType()].sprite = clothes.GetSprite();
	}
}
