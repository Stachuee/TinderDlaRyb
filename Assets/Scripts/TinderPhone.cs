using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TinderPhone : MonoBehaviour
{
    public static TinderPhone Instance;
    [SerializeField] Image profilePicture;
    [SerializeField] TextMeshProUGUI fishName;
	[SerializeField] TextMeshProUGUI fishDesc;

    bool open;
    Animator animator;

	private void Awake()
	{
        if (Instance == null)
        {
            Instance = this;
		}
        else
        {
            Debug.LogError("Two Phones");
        }
		animator = GetComponent<Animator>();
	}

	public void SetNewProfile(Character character)
    {
        this.profilePicture.sprite = character.characterSprite;
        fishName.text = character.characterName;
        fishDesc.text = character.characterDesc;
    }
}
