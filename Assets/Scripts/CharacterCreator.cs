using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
	public static CharacterCreator Instance;

    [SerializeField] List<FishesSO> characterList;
	[SerializeField] List<FishesSO> avalibleFishes;
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
		avalibleFishes.AddRange(characterList);
	}

	private void Start()
	{
		currentCharacter = CreateCharacter();
		TinderPhone.Instance.SetNewProfile(currentCharacter);

	}

	public Character CreateCharacter()
	{
		if(avalibleFishes.Count > 0)
		{
			avalibleFishes.AddRange(characterList);
		}
		int id = Random.Range(0, avalibleFishes.Count);
		FishesSO character = avalibleFishes[id];
		avalibleFishes.RemoveAt(id);
		return new Character(character);
	}

	public Character GetCurrentLove()
	{
		return currentCharacter;
	}
}
