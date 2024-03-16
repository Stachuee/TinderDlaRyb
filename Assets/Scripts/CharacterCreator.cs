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


	public void CreateCharacter()
	{
		if(avalibleFishes.Count <= 0)
		{
			avalibleFishes.AddRange(characterList);
		}
		int id = Random.Range(0, avalibleFishes.Count);
		FishesSO character = avalibleFishes[id];
		avalibleFishes.RemoveAt(id);
		currentCharacter = new Character(character);
		Debug.Log(character.name);
		TinderPhone.Instance.SetNewProfile(currentCharacter);
		TinderPhoneCutscene.Instance.SetProfile(currentCharacter);
	}

	public Character GetCurrentLove()
	{
		return currentCharacter;
	}
}
