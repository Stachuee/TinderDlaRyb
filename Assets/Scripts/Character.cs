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

	public static float Compare(Stats one, Stats two)
	{
		float dist = 0;
		dist += Mathf.Abs(one.statOne - two.statOne);
		dist += Mathf.Abs(one.statTwo - two.statTwo);
		dist += Mathf.Abs(one.statThree - two.statThree);
		dist += Mathf.Abs(one.statFour - two.statFour);
		dist += Mathf.Abs(one.statFive - two.statFive);
		return dist;
	}

}

public class Character 
{
	public Sprite characterSprite;
	public string characterName;

	public Stats stats;
}
