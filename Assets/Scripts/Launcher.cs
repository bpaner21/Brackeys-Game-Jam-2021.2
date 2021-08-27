using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Orbit))]
public class Launcher : MonoBehaviour
{
    [SerializeField] private float xAxis = 1.0f;
    [SerializeField] private float yAxis = 1.0f;

    [SerializeField] private float xOrigin = 0.0f;
    [SerializeField] private float yOrigin = 0.0f;

    [Range(0.0f, 2.0f)]
    [SerializeField] private float angleSpeed = 1.0f;

    [SerializeField] private float angle;

    [SerializeField] private Orbit orbit;

    [Range(1, 20)]
    [SerializeField] private int segments = 8;

    private void Awake()
    {
        this.orbit = GetComponent<Orbit>();
        orbit.Modify(segments, xAxis, yAxis, xOrigin, yOrigin);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle += angleSpeed * Time.deltaTime;

        if (angle > 2.0f * Mathf.PI) { angle %= 2.0f * Mathf.PI; }

        transform.position = new Vector3((Mathf.Sin(angle) * xAxis) + xOrigin, (Mathf.Cos(angle) * yAxis) + yOrigin, 0.0f);

        transform.up = Vector3.zero - transform.position;
    }

    private void OnValidate()
    {
        if (Application.isPlaying && orbit != null)
        {
            orbit.Modify(segments, xAxis, yAxis, xOrigin, yOrigin);
            orbit.CalculateEllipse(); 
        }
    }
}
