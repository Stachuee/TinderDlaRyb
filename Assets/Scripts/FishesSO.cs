using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObjects/Portraits", order = 1)]
public class FishesSO : ScriptableObject
{
	[SerializeField] Sprite icon;
	[SerializeField] Stats stats;
	[SerializeField] string name;
	[SerializeField] string desc;

	public Sprite GetIcon() { return icon; }
	public Stats GetStats() { return stats; }
	public string GetDesc() { return desc; }
	public string GetName() { return name; }
}
