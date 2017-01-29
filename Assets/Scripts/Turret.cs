using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour {

	Transform turretTransform;

	//используем этот метод для инициализации
	private void Start()
	{
		turretTransform = transform.Find("Unit_turret");
	}

	//а этот метод вызывается каждый фрейм
	private void Update()
	{
		GameObject[] enemies;
		enemies = GameObject.FindGameObjectsWithTag("Oblom");
		GameObject nearestEnemy = null;

		float dist = Mathf.Infinity;

		foreach(GameObject e in enemies) {
			float d = Vector3.Distance(this.transform.position, e.transform.position);
			if(nearestEnemy == null || d < dist){
				nearestEnemy = e;
				dist = d;
			}
		}

		if(nearestEnemy == null) {
			Debug.Log("No Enemies?");
			return;
		}

		Vector3 dir = nearestEnemy.transform.position - this.transform.position;

		Quaternion LookRot = Quaternion.LookRotation(dir);

		//turretTransform.rotation = Quaternion.Euler(0, 0, 0);
	}
}
