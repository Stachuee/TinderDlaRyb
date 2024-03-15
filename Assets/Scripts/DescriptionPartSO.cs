using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObjects/DescriptionPart", order = 3)]
public class DescriptionPartSO : ScriptableObject
{
	[SerializeField] string descriptionPart;
	[SerializeField] Stats stats;
}
