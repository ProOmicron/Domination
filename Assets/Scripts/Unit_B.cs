using UnityEngine;
using System.Collections;

public class Unit_B : MonoBehaviour {

    public Vector3 startPos;
    public float speedDamping = 0.1f;
    private float rotationDamping = 0.009f;
    public Transform shipModel;
	private float Speed = 0.9f;
    public Transform target;
	private Ray ray;    
    public float plus = 1;
    public float angel;
    public Vector3 dir;
    public Vector3 cross;

    void Start () {        
        target.position = startPos;
    }

	void Update () {
        Target();
        Povorot();
        Turn();
    }

    void Target()
    {
        if (Input.GetMouseButtonDown(0)) //Проверка на нажатие клавиши мыши
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                target.position = hit.point;
            }
        }
    }

    void Povorot()
    {
        dir = target.position - shipModel.localPosition; //поворот к цели

        angel = Vector3.Angle(dir, shipModel.up); //Логика в какую сторону поворачивать

        cross = Vector3.Cross(target.position, shipModel.position);

        if (cross.z < 0) plus = 1; else plus = -1;

        if ((Vector3.Distance(transform.position, target.position) >= 0.1f)) //Логика завершения манёвра
        {
            if (angel >= 0.0f) //Логика завершения поворота
            {
                //Сама логика поворота корабля
                shipModel.localRotation = shipModel.localRotation * Quaternion.AngleAxis(angel * plus * rotationDamping, Vector3.forward);
            }
        }
    }

    void Turn() // Метод передвижения корабля относительно вперёд на отрезок Speed
    {        
        if ((Vector3.Distance(transform.position, target.position) >= 0.1f)) //Логика завершения манёвра
        {
            transform.position += transform.up * Speed * Time.deltaTime;
        }
    }
}