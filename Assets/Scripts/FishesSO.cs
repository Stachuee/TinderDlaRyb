using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObjects/Portraits", order = 1)]
public class FishesSO : ScriptableObject
{
	[SerializeField] Sprite icon;
	[SerializeField] Stats stats;

	public Sprite GetIcon() { return icon; }
}
