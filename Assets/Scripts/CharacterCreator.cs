using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
	public static CharacterCreator Instance;

    [SerializeField] List<FishesSO> characterList;
	[SerializeField] List<DescriptionPartSO> descriptionPartList;

	[SerializeField] Vector2Int minMaxDescParts;

	[SerializeField] Character currentCharacter;

	private void Awake()
	{
		if (Instance == null) Instance = this;
		else
		{
			Debug.LogError("Dwa controllery na scenie");
		}
	}

	private void Start()
	{
		currentCharacter = CreateCharacter();
		TinderPhone.Instance.SetNewProfile(currentCharacter);
	}

	public Character CreateCharacter()
	{
		Stats stats = new Stats();
		int parts = Random.Range(minMaxDescParts.x, minMaxDescParts.y);
		List<DescriptionPartSO> partsList = new List<DescriptionPartSO>();
		string desc = "";

		for(; partsList.Count < parts;)
		{
			int id = Random.Range(0, descriptionPartList.Count);
			if (!partsList.Contains(descriptionPartList[id]))
			{
				partsList.Add(descriptionPartList[id]);
			}
			else if(partsList.Count == descriptionPartList.Count)
			{
				break;
			}
		}
		partsList.ForEach(part =>
		{
			desc += part.GetDesc();
			stats += part.GetStats();
		});

		FishesSO fishPortrait = characterList[Random.Range(0, characterList.Count)];
		stats += fishPortrait.GetStats();

		return new Character(fishPortrait, NameGenerator.GenerateName(), desc, stats);
	}

	public Character GetCurrentLove()
	{
		return currentCharacter;
	}
}
