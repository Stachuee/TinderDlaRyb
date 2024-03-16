using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudiooController : MonoBehaviour
{
    [SerializeField] private AudioSource source;

	public void Mute(bool value)
    {
		source.mute = value;
    }
}
