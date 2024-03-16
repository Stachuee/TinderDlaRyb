using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeSegment : MonoBehaviour
{
    [SerializeField] List<ClothesSO> list;

	[SerializeField] GameObject prefab;
	[SerializeField] Transform toSpawnUnder;
	private void Start()
	{
		list.ForEach(c =>
		{
			GameObject cloath =  Instantiate(prefab, toSpawnUnder);
			cloath.GetComponent<WardrobeItem>().SetItem(c);
		});
	}

}
