using UnityEngine;
using System.Collections;

public class Oblom_Spawn : MonoBehaviour {


	private GameObject prefeb;
	public GameObject prefeb1;
	public GameObject prefeb2;
	public int chastota = 300;

	void Update () {
		if (Random.Range(0, chastota) == 1) {
			if (Random.Range(0,2) < 1) prefeb = prefeb1;
			else prefeb = prefeb2;
			Vector3 position = new Vector3 (Random.Range(10.0f,-10.0f), 6 * (Random.Range (0, 2) * 2 - 1), 0);
			Instantiate (prefeb, position, Quaternion.identity);
		}		
	}
}
