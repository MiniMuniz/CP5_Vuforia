using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float velocidadeRotacao = 0.2f;

    private bool canInteract = false;
    private bool rotacao = false;

    void Update()
    {
        Touch();

        if (rotacao)
        {
            Swipe();
        }
    }

    public void Ligar()
    {
        canInteract = true;
    }

    public void Desligar()
    {
        canInteract = false;
        rotacao = false;

        transform.localScale = Vector3.one;
    }
    
    void Touch()
    {
        if (!canInteract)
            return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                AlterarModelo();
            }
        }
    }

    void AlterarModelo()
    {
        if (!rotacao)
        {
            transform.localScale = new Vector3(80, 50, 50);
            rotacao = true;
        }
        else
        {
            transform.localScale = new Vector3(30, 30, 30);

            rotacao = false;
        }
    }

    void Swipe()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved)
        {
            float movement = touch.deltaPosition.x;

            GirarModelo(movement);
        }
    }

    void GirarModelo(float movement)
    {
        transform.Rotate(0, -movement * velocidadeRotacao, 0);
    }
}


