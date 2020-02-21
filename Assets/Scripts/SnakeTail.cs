using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    public float CircleDiameter;

    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector2> positions = new List<Vector2>();

    // Start is called before the first frame update
    void Awake()
    {
        positions.Add(SnakeHead.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = ((Vector2)SnakeHead.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            Vector2 direction = ((Vector2) SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector2.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }

    public void AddCircle()
    {
        Transform circle = Instantiate(SnakeHead, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
    }

    public void RemoveCircle()
    {
        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        // Для красивой анимации удаляем первый круг после головы
        positions.RemoveAt(1);
    }
}
