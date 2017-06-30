using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickName {
	private static readonly string playerPrefsKey = "nickName";

	public static string Value()
	{
		return PlayerPrefs.GetString(playerPrefsKey, "");
	}

	public static void Apply(string value)
	{
		PlayerPrefs.SetString(playerPrefsKey, value);
		PlayerPrefs.Save();
	}
}
