using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class HighScore {
	private static readonly string className = "ranking";
	private static readonly string nameKey = "name";
	private static readonly string scoreKey = "score";

	public struct Entry
	{
		public string name;
		public int score;

		public Entry(NCMBObject obj)
		{
			name = System.Convert.ToString(obj[nameKey]);
			score = System.Convert.ToInt32(obj[scoreKey]);
		}
	}

	public static void Save(int score)
	{
		var ncmbObject = new NCMBObject(className);
		ncmbObject[nameKey] = NickName.Value();
		ncmbObject[scoreKey] = score;
		ncmbObject.SaveAsync();
	}

	public static IEnumerator List(int num)
	{
		List<Entry> ret = new List<Entry>();
		var query = new NCMBQuery<NCMBObject>(className);
		bool isConnecting = true;
		query.OrderByDescending(scoreKey);
		query.Limit = num;
		query.FindAsync((List<NCMBObject> objectList, NCMBException e) =>
		{
			if(e == null)
			{
				foreach(var obj in objectList)
				{
					ret.Add(new Entry(obj));
				}
			}
			isConnecting = false;
		});
		while(isConnecting) { yield return null; }
		yield return ret;
	}
}
