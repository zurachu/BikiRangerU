using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class HighScore {
	private static readonly string className = "ranking";
	private static readonly string nameKey = "name";
	private static readonly string scoreKey = "score";

	public static void Save(int score)
	{
		var ncmbObject = new NCMBObject(className);
		ncmbObject[nameKey] = NickName.Value();
		ncmbObject[scoreKey] = score;
		ncmbObject.SaveAsync();
	}
}
