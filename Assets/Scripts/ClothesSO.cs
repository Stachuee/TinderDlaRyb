using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObjects/Clothes", order = 2)]
public class ClothesSO : ScriptableObject
{
	public enum ClothesType {Top, Bottom, FullFit, Shoes }

	[SerializeField] Sprite sprite;
	[SerializeField] Stats stats;
	[SerializeField] ClothesType type; 

	public Sprite GetSprite()
	{
		return sprite;
	}
	public Stats GetStats()
	{
		return stats;
	}
	public ClothesType GetClothesType()
	{
		return type;
	}
}
