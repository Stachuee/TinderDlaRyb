using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Stats
{
	public float statOne;
	public float statTwo;
	public float statThree;
	public float statFour;
	public float statFive;

	public static float Compare(Stats player, Stats two)
	{
		float dist = 0;
		dist += Mathf.Min(player.statOne - two.statOne, 0);
		dist += Mathf.Min(player.statTwo - two.statTwo, 0);
		dist += Mathf.Min(player.statThree - two.statThree, 0);
		dist += Mathf.Min(player.statFour - two.statFour, 0);
		dist += Mathf.Min(player.statFive - two.statFive, 0);
		return dist;
	}

	public static Stats operator+(Stats one, Stats two)
	{
		Stats val = new Stats();
		val.statOne = one.statOne + two.statOne;
		val.statTwo = one.statTwo + two.statTwo;
		val.statThree = one.statThree + two.statThree;
		val.statFour = one.statFour + two.statFour;
		val.statFive = one.statFive + two.statFive;
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

}
