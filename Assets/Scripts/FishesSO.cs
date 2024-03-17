using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObjects/Portraits", order = 1)]
public class FishesSO : ScriptableObject
{
	[SerializeField] Sprite icon;
	[SerializeField] Stats stats;
	[SerializeField] string name;
	[SerializeField] string desc;

	public Sprite GetIcon() { return icon; }
	public Stats GetStats() { return stats; }
	public string GetDesc() { return ToUTF32(desc); }
	public string GetName() { return name; }

	string ToUTF32(string input)
	{
		string output = input;
		Regex pattern = new Regex(@"\\u[a-zA-Z0-9]*");

		while (output.Contains(@"\u"))
		{
			output = pattern.Replace(output, @"\U000" + output.Substring(output.IndexOf(@"\u", StringComparison.Ordinal) + 2, 5), 1);
		}

		output = output.Replace("\\n", "\n");
		return output;
	}
}
