using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndLookAtMouse : MonoBehaviour
{
    public float rotationSpeed = 30f; // Velocidad de rotación constante

    private Camera mainCamera;

    void Start()
    {
        // Obtener la cámara principal
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Obtener la posición del ratón en el espacio del mundo
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position); // Suponemos que el plano está en Y = 0

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 mousePositionInWorld = ray.GetPoint(distance);
            Vector3 directionToMouse = (mousePositionInWorld - transform.position).normalized;

            // Calcular la rotación para mirar hacia el ratón
            Quaternion targetRotation = Quaternion.LookRotation(directionToMouse);

            // Aplicar la rotación constante sobre el eje Y
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            // Asegurarse de que el objeto mire hacia el ratón, sin perder la rotación constante
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

}
