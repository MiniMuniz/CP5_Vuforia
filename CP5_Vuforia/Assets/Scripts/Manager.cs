using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float rotationSpeed = 0.2f;

    private bool canInteract = false;
    private bool rotationActive = false;

    void Update()
    {
        CheckTouch();

        if (rotationActive)
        {
            CheckSwipe();
        }
    }

    public void EnableInteraction()
    {
        canInteract = true;
    }

    public void DisableInteraction()
    {
        canInteract = false;
        rotationActive = false;

        transform.localScale = Vector3.one;
    }

    void CheckTouch()
    {
        if (!canInteract)
            return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ToggleCube();
            }
        }
    }

    void ToggleCube()
    {
        if (!rotationActive)
        {
            transform.localScale = new Vector3(200, 100, 100);
            rotationActive = true;
        }
        else
        {
            transform.localScale = new Vector3(100, 100, 100);

            rotationActive = false;
        }
    }

    void CheckSwipe()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved)
        {
            float movement = touch.deltaPosition.x;

            RotateObject(movement);
        }
    }

    void RotateObject(float movement)
    {
        transform.Rotate(0, -movement * rotationSpeed, 0);
    }
}


