using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator
{
    static string[] names = {"Bob", "Joe"};
	static string[] surrNames = { "Powazny", "Niepowazny" };
	public static string GenerateName()
    {
        return names[Random.Range(0, names.Length)] + " " + surrNames[Random.Range(0, surrNames.Length)];
    }
}
