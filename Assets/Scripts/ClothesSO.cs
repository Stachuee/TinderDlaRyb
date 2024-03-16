using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObjects/Clothes", order = 2)]
public class ClothesSO : ScriptableObject
{
	public enum ClothesType {Top, Bottom, FullFit, Shoes, Addon, Hair, UnderBottom, Bags}

	[SerializeField] Sprite sprite;
	[SerializeField] Sprite UIsprite;
	[SerializeField] Stats stats;
	[SerializeField] ClothesType type; 

	public Sprite GetSprite()
	{
		return sprite;
	}
	public Sprite GetUISprite()
	{
		return UIsprite;
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
