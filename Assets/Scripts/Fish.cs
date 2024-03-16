using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public static Fish Instance;

    [SerializeField] List<FishClothes> clothes;

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
		if(clothes.GetClothesType() == ClothesSO.ClothesType.Top || clothes.GetClothesType() == ClothesSO.ClothesType.Bottom)
		{
			this.clothes[(int)ClothesSO.ClothesType.FullFit].RemoveItem();
		}
		else if(clothes.GetClothesType() == ClothesSO.ClothesType.FullFit)
		{
			this.clothes[(int)ClothesSO.ClothesType.Top].RemoveItem();
			this.clothes[(int)ClothesSO.ClothesType.Bottom].RemoveItem();
		}
		this.clothes[(int)clothes.GetClothesType()].SetItem(clothes);
	}

	public Stats GetFinalStats()
	{
		Stats stats = new Stats();

		clothes.ForEach(c =>
		{
			if(c.GetItem() != null)
			stats += c.GetItem().GetStats();
		});
		return stats;
	}
}
