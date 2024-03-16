using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TinderPhoneCutscene : MonoBehaviour
{
    public static TinderPhoneCutscene Instance;

	[SerializeField] Image profilePic;
	[SerializeField] TextMeshProUGUI profileName;
	[SerializeField] TextMeshProUGUI profileDesc;

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogError("Two tinder Phones cutscne");
		}
	}

	private void Start()
	{
		SetProfile(CharacterCreator.Instance.GetCurrentLove());
	}

	public void SetProfile(Character character)
	{
		profilePic.sprite = character.characterSprite;
		profileName.text = character.characterName;
		profileDesc.text = character.characterDesc;
	}
}
