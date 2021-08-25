using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Orbit : MonoBehaviour
{
    [Range(1, 20)]
    [SerializeField] private int segments = 8;

    [SerializeField] private float xAxis = 15.0f;

    [SerializeField] private float yAxis = 10.0f;

    [SerializeField] private LineRenderer lR;

    void Awake()
    {
        lR = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Application.isPlaying) { CalculateEllipse(); }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CalculateEllipse()
    {
        int numSegments = segments * 4;

        Vector3[] points = new Vector3[numSegments + 1];

        for (int i = 0; i < numSegments; ++i)
        {
            float angle = (1.0f * i / numSegments) * 2.0f * Mathf.PI;

            float x = transform.position.x + Mathf.Sin(angle) * xAxis;
            float y = transform.position.y + Mathf.Cos(angle) * yAxis;

            points[i] = new Vector3(x, y, 0.0f);
        }

        points[numSegments] = points[0];

        lR.positionCount = numSegments + 1;
        lR.SetPositions(points);
    }

    void OnValidate()
    {
        if (Application.isPlaying && lR != null) { CalculateEllipse(); }
    }
}
