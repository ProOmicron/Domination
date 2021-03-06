using UnityEngine;
using System.Collections;

public class Unit_R : MonoBehaviour {

	/*public float speed = 5; // максимальная скорость корабля в секунду 
	public float speedDamping = 0.1f; // дампинг скорости 
	public float rotationSpeed = 90; // максимальный поворот в секунду 
	public float rotationDamping = 0.1f; // дампинг вращения корпуса 
	public float maxRotationAngle = 30f; // максимальный укол крена корпуса 

	public Transform shipModel; // сслыка на модель корабля (должна быть дочерним объектом) 


	// значение вращения корпуса по умолчанию 
	private Quaternion _shipDefaultRotation; 

	// текущий поворот корпуса 
	private float _shipRotation; 
	// текущая скорость 
	private float _shipSpeed; 

	public void Start() 
	{ 
		// сохраняем значение вращения корпуса по умолчанию 
		_shipDefaultRotation = shipModel.localRotation; 
	} 

	public void Update() 
	{ 
		// скорость корабля с дампингом 
		_shipSpeed = Mathf.Lerp(_shipSpeed, Mathf.Max(Input.GetAxis("Vertical"), 0), speedDamping); 
		// смещаем корабль в перед на нужную величину 
		transform.position += transform.forward * _shipSpeed * speed * Time.deltaTime; 

		var rot = Input.GetAxis("Horizontal"); 
		// вращаем корабль по оси Z 
		transform.rotation *= Quaternion.AngleAxis(rot * rotationSpeed * Time.deltaTime, transform.up); 

		// рассчитываем поврот корпуса корабля с дампингом 
		_shipRotation = Mathf.Lerp(_shipRotation, -rot * maxRotationAngle, rotationDamping); 
		// рассчитываем значение поворота корпуса 
		shipModel.localRotation = _shipDefaultRotation * Quaternion.AngleAxis(_shipRotation, Vector3.right); 

	}
*/

	public Vector3 startPos;
	public Transform prefab;
	private float Speed = 0.3f;
	public Vector3 target;
	private Ray ray;

	void Start () {
		target = startPos;
	}

	void Update () {

		if (Input.GetMouseButtonDown(1)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100.0f)){
				target = hit.point;
			}
			Instantiate(prefab, target, Quaternion.identity);
		}
		
		Vector2 dir = target - transform.position; //поворот к цели
		dir = new Vector2 (dir.x, dir.y);
			if(dir != Vector2.zero) transform.up = dir;

		transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime); //передвижение Юнита
	
	}
}