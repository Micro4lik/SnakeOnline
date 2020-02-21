using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using TMPro;

public class SnakeSimpleMovemenet : MonoBehaviour
{
    private PhotonView photonView;

    public float Speed = 2;

    private Rigidbody2D componentRigidbody;
    private SnakeTail componentSnakeTail;

    public TextMeshPro PointsText;

    public int Length = 5;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();

        componentRigidbody = GetComponent<Rigidbody2D>();
        componentSnakeTail = GetComponent<SnakeTail>();

        for (int i = 0; i < Length; i++)
        {
            componentSnakeTail.AddCircle();
        }

        PointsText.SetText(Length.ToString());
    }

    void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            componentRigidbody.velocity = Vector2.up * Speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            componentRigidbody.velocity = Vector2.down * Speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            componentRigidbody.velocity = Vector2.right * Speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            componentRigidbody.velocity = Vector2.left * Speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //Length++;
            componentSnakeTail.AddCircle();
            //PointsText.SetText(Length.ToString());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Length--;
            componentSnakeTail.RemoveCircle();
            //PointsText.SetText(Length.ToString());
            //если меньше 0, то вызывать попап поражения
        }
    }
}
