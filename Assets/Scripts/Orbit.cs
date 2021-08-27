using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Orbit : MonoBehaviour
{


    [SerializeField] private float xAxis = 1.0f;
    [SerializeField] private float yAxis = 1.0f;

    [SerializeField] private float xOrigin = 0.0f;
    [SerializeField] private float yOrigin = 0.0f;

    [SerializeField] private LineRenderer lR;

    [Range(1, 20)]
    [SerializeField] private int segments = 8;

    void Awake()
    {
        lR = GetComponent<LineRenderer>();
        lR.widthMultiplier = 0.10f;
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

    public void CalculateEllipse()
    {
        int numSegments = segments * 4;

        Vector3[] points = new Vector3[numSegments + 1];

        for (int i = 0; i < numSegments; ++i)
        {
            float angle = (1.0f * i / numSegments) * 2.0f * Mathf.PI;

            float x = xOrigin + (Mathf.Sin(angle) * xAxis);
            float y = yOrigin + (Mathf.Cos(angle) * yAxis);

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

    public void Modify(int segments, float xAxis, float yAxis, float xOrigin, float yOrigin)
    {
        this.segments = segments;
        this.xAxis = xAxis;
        this.yAxis = yAxis;
        this.xOrigin = xOrigin;
        this.yOrigin = yOrigin;
    }

    public int Segments
    {
        set { this.segments = value; }
    }

    public float XAxis
    {
        set { this.xAxis = value; }
    }

    public float YAxis
    {
        set { this.yAxis = value; }
    }

    public float XOrigin
    {
        set { this.xOrigin = value; }
    }

    public float YOrigin
    {
        set { this.yOrigin = value; }
    }

    public bool LR 
    {
        get { return lR != null; } 
    }
}
