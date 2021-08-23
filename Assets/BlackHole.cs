using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{ 
    [Range(1.0f, 5.0f)]
    [SerializeField] private float minScale = 1.0f;

    [Range(1.0f, 5.0f)]
    [SerializeField] private float maxScale = 2.0f;

    [SerializeField] private float currentScale;

    [Range(0.1f, 2.0f)]
    [SerializeField] private float scaleSpeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScale = Mathf.Lerp(minScale, maxScale, Mathf.PingPong(scaleSpeed * Time.time, 1.0f));

        currentScale = Mathf.Round(currentScale * 100) / 100.0f;

        this.transform.localScale = new Vector3(currentScale, currentScale, transform.localScale.z);
    }
}
