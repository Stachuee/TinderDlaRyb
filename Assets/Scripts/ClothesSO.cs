using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObjects/Clothes", order = 2)]
public class ClothesSO : ScriptableObject
{
	public enum ClothesType {one, two, three }

	[SerializeField] Sprite sprite;
	[SerializeField] Stats stats;
	[SerializeField] ClothesType type; 
}
