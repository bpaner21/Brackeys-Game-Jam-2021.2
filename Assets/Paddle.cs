using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private GameObject blackHole;

    [SerializeField] private float distance = 0.0f;

    [SerializeField] private float width = 0.0f;

    [Range(0.0f, 2 * Mathf.PI)]
    [SerializeField] private float angle;

    [Range(0.0f, 10.0f)]
    [SerializeField] private float angleStep;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // current radius of black hole
        float delta = blackHole.transform.localScale.y;

        // keep paddle a set distance from the edge of the black hole
        distance = (delta / 2.0f) + 0.25f;

        angle += angleStep * Time.deltaTime;

        if (angle > 2 * Mathf.PI) { angle %= 2 * Mathf.PI; }

        // rotate paddle around the black hole
        transform.localPosition = new Vector3(Mathf.Cos(angle) * distance, Mathf.Sin(angle) * distance, transform.localPosition.z);

        // keep paddle angle relative to rotation
        transform.up = blackHole.transform.position - transform.position;

        // scale paddle with to size of black hole
        transform.localScale = new Vector3(delta * 0.8f, transform.localScale.y, transform.localScale.z);

        // print out current scale to inspector
        width = transform.localScale.x;
    }
}
