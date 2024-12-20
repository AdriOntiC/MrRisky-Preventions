using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectOnTouch : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private bool isRotating = false;

    void Update()
    {
        // Comprova si estem en un dispositiu tàctil
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform == transform)
                    {
                        isRotating = true;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Moved && isRotating)
            {
                float rotationAmount = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;
                transform.Rotate(0, -rotationAmount, 0, Space.World);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isRotating = false;
            }
        }

        // Emulació per a l'editor amb el ratolí
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    isRotating = true;
                }
            }
        }
        else if (Input.GetMouseButton(0) && isRotating)
        {
            float rotationAmount = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, -rotationAmount, 0, Space.World);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }
    }
}
