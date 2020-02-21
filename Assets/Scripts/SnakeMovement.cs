using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float ForwardSpeed = 5;
    public float Sensitivity = 10;

    public int Length = 10;

    public TextMeshPro PointsText;

    private Camera mainCamera;
    private Rigidbody2D componentRigidbody;
    private SnakeTail componentSnakeTail;

    private Vector2 touchLastPos;
    private float sidewaysSpeed;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        componentRigidbody = GetComponent<Rigidbody2D>();
        componentSnakeTail = GetComponent<SnakeTail>();

        //Debug.Log(Length);
        for (int i = 0; i < Length; i++) 
        {
            componentSnakeTail.AddCircle();
        }

        PointsText.SetText(Length.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sidewaysSpeed = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 delta = (Vector2) mainCamera.ScreenToViewportPoint(Input.mousePosition) - touchLastPos;
            sidewaysSpeed += delta.x * Sensitivity;
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Length++;
            componentSnakeTail.AddCircle();
            PointsText.SetText(Length.ToString());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Length--;
            componentSnakeTail.RemoveCircle();
            PointsText.SetText(Length.ToString());
            //если меньше 0, то вызывать попап поражения
        }
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
        {
            componentRigidbody.velocity = new Vector2(sidewaysSpeed * 5, ForwardSpeed);
        }

        sidewaysSpeed = 0;
    }
}
