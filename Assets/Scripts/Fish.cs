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
