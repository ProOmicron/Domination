using UnityEngine;
using System.Collections;

public class Oblom : MonoBehaviour {

	public Vector3 targetFinish;
	private float Speed;
	private float rotationSpeed;
	private float i;
	private int napr;

	void OnEnable () {
		targetFinish = new Vector3 (Random.Range(10.0f,-10.0f),6 * (Random.Range (0, 2) * 2 - 1), 0);
		i = Random.Range(0.2f, 0.3f);
		napr = (Random.Range (0, 2) * 2 - 1);
		rotationSpeed = (napr * 200 - (i * 500));
		Speed = i * 6 - 0.5f;
		transform.localScale = new Vector3(i, i, i);
	}

	void Update () {		
		transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, transform.forward);//метод поворота
		transform.position = Vector2.MoveTowards(transform.position, targetFinish, Speed * Time.deltaTime); //передвижение
		if (targetFinish == transform.position){//логика разрушения
			Destroy (gameObject);
		}
	}
}
