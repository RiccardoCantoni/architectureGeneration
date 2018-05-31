using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericUtils {

	public static List<bool> windowSequence(int seqLength){
		List<bool> list = new List<bool> ();
		if (seqLength % 2 == 0) {
			if (seqLength == 2) {
				list.Add (false);
				list.Add (false);
			} else {
				List<bool> half = windowSequence (seqLength / 2);
				list.AddRange (half);
				half.Reverse ();
				list.AddRange (half);
			}
		} else {
			for (int i = 0; i < seqLength; i++) {
				list.Add (i % 2 != 0);
			}
		}
		return list;
	}

	public static Vector3 rotateClockwise(Vector3 axis){
		axis.Normalize ();
		if (axis.Equals(Vector3.forward)) return Vector3.right;
		if (axis.Equals(Vector3.right)) return Vector3.back;
		if (axis.Equals(Vector3.back)) return Vector3.left;
		if (axis.Equals(Vector3.left)) return Vector3.forward;
		Debug.Log ("axis error");
		return Vector3.zero;
	}

    public static GameObject loadPrefab(string type, string name)
    {
        GameObject o = (GameObject)Resources.Load("prefabs/"+type+"/"+name, typeof(GameObject));
        if (o == null) {
            throw new System.Exception("object "+type+", "+name+" not found");
        }
        return o;
    }

    public static GameObject[] loadAllPrefabs(string path)
    {
        Object[] os = Resources.LoadAll(path, typeof(GameObject));
        GameObject[] res = new GameObject[os.Length];
        for (int i=0; i<os.Length; i++)
        {
            res[i] = (GameObject)os[i];
        }
        return res;
    }
}
