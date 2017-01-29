using UnityEngine;
using System.Collections;

[System.Serializable]
public class Unit_turret : MonoBehaviour {

	public string Name;
	public int Damage;
	public float atkSpeed = 1.0f;
	public float bltSpeed;
	public float Range;
	public GameObject BulletPref;
	public GameObject BulletSpawn;


	public Vector3 target;
	private Ray ray;
	private RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 100.0f)){
			target = hit.point;
		}

		Vector2 dir = target - transform.position; //поворот к цели
		dir = new Vector2 (dir.x, dir.y);
		if(dir != Vector2.zero) {
			transform.up = dir;
		}
	}
}
