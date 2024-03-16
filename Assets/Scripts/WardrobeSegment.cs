using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeSegment : MonoBehaviour
{
    [SerializeField] List<ClothesSO> list;

	[SerializeField] GameObject prefab;

	private void Start()
	{
		list.ForEach(c =>
		{
			GameObject cloath =  Instantiate(prefab, transform);
			cloath.GetComponent<WardrobeItem>().SetItem(c);
		});
	}

}
