using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndLookAtMouse : MonoBehaviour
{
    public float rotationSpeed = 30f; // Velocidad de rotaci�n constante

    private Camera mainCamera;

    void Start()
    {
        // Obtener la c�mara principal
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Obtener la posici�n del rat�n en el espacio del mundo
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position); // Suponemos que el plano est� en Y = 0

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 mousePositionInWorld = ray.GetPoint(distance);
            Vector3 directionToMouse = (mousePositionInWorld - transform.position).normalized;

            // Calcular la rotaci�n para mirar hacia el rat�n
            Quaternion targetRotation = Quaternion.LookRotation(directionToMouse);

            // Aplicar la rotaci�n constante sobre el eje Y
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            // Asegurarse de que el objeto mire hacia el rat�n, sin perder la rotaci�n constante
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

}
