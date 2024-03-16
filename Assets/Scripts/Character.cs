using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;


[System.Serializable]
public struct Stats
{
	public float Sporty;
	public float Cute;
	public float Artsy;
	public float Alternative;
	public float Classive;

	public static float Compare(Stats player, Stats two)
	{
		float dist = 0;
		dist += Mathf.Min(player.Sporty - two.Sporty, 0);
		dist += Mathf.Min(player.Cute - two.Cute, 0);
		dist += Mathf.Min(player.Artsy - two.Artsy, 0);
		dist += Mathf.Min(player.Alternative - two.Alternative, 0);
		dist += Mathf.Min(player.Classive - two.Classive, 0);
		return dist;
	}

	public static Stats operator/(Stats one, float two)
	{
		Stats val = new Stats();
		val.Sporty = one.Sporty / two;
		val.Cute = one.Cute / two;
		val.Artsy = one.Artsy / two;
		val.Alternative = one.Alternative / two;
		val.Classive = one.Classive / two;
		return val;
	}

	public static Stats operator+(Stats one, Stats two)
	{
		Stats val = new Stats();
		val.Sporty = one.Sporty + two.Sporty;
		val.Cute = one.Cute + two.Cute;
		val.Artsy = one.Artsy + two.Artsy;
		val.Alternative = one.Alternative + two.Alternative;
		val.Classive = one.Classive + two.Classive;
		return val;
	}

}
[System.Serializable]
public class Character 
{
	public Sprite characterSprite;
	public string characterName;
	public string characterDesc;
	public Stats characterStats;

	public Character(FishesSO fish, string name, string desc, Stats stats)
	{
		characterSprite = fish.GetIcon();
		characterName = name;
		characterDesc = desc;
		characterStats = stats;
	}

	public Character(FishesSO fish)
	{
		characterSprite = fish.GetIcon();
		characterName = fish.GetName();
		characterDesc = fish.GetDesc();
		characterStats = fish.GetStats();
	}

}
