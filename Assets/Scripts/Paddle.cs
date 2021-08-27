using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Paddle : MonoBehaviour
{
    [SerializeField] private GameObject blackHole;

    [SerializeField] private BoxCollider2D collision;

    [SerializeField] private float distance = 0.0f;

    [SerializeField] private float width = 0.0f;

    [Range(0.0f, 2 * Mathf.PI)]
    [SerializeField] private float angle;

    [Range(0.0f, 30.0f)]
    [SerializeField] private float angleStep;

    [Range(0.01f, 1.0f)]
    [SerializeField] private float widthScale = 0.75f;

    [Range(0.01f, 1.0f)]
    [SerializeField] private float paddleDistance = 0.25f;

    private float twoPI = 2.0f * Mathf.PI;

    private void Awake()
    {
        collision = GetComponent<BoxCollider2D>();
        collision.size = new Vector2(transform.localScale.x, transform.localScale.y);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) { angle -= angleStep * Time.deltaTime; }

        else if (Input.GetKey(KeyCode.RightArrow)) { angle += angleStep * Time.deltaTime; }

        if (angle > 2 * Mathf.PI) { angle %= twoPI; }

        // current radius of black hole
        float delta = blackHole.transform.localScale.y;

        // keep paddle a set distance from the edge of the black hole
        distance = (delta / 2.0f) + paddleDistance;

        // rotate paddle around the black hole
        transform.localPosition = new Vector3(Mathf.Sin(angle) * distance, Mathf.Cos(angle) * distance, transform.localPosition.z);

        // keep paddle angle relative to rotation
        transform.up = transform.position;

        // scale paddle with to size of black hole
        transform.localScale = new Vector3(delta * widthScale, transform.localScale.y, transform.localScale.z);

        // print out current scale to inspector
        width = transform.localScale.x;
    }
}
