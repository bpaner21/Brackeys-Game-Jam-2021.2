using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public abstract class Projectile : MonoBehaviour
{
    private static float screenWidth = Screen.width;
    private static float screenHeight = Screen.height;

    [SerializeField] protected SpriteRenderer rendering;

    [SerializeField] private bool becameVisible = false;

    [SerializeField] protected Vector2 angle; // Angle in Radians, divided into a vector of {Sin, Cos}

    [SerializeField] private float speed;

    [SerializeField] private int size;

    protected void Awake()
    {
        rendering = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    protected void Start()
    {
        angle = new Vector2(-transform.position.x, -transform.position.y);

        speed = 2.0f;
    }

    // Update is called once per frame
    protected void Update()
    {
        Move();
    }

    protected void OnBecameVisible()
    {
        if (!becameVisible) { becameVisible = true; }
    }

    protected void OnBecameInvisible()
    {
        if (becameVisible)
        {
            float deltaX = transform.position.x;
            float deltaY = transform.position.y;

            if (transform.position.x < screenWidth || screenWidth < transform.position.x) { deltaX *= -1.0f; }
            if (transform.position.y < screenHeight || screenHeight < transform.position.x) { deltaY *= -1.0f; }

            transform.position = new Vector3(deltaX, deltaY, 0.0f);
        }
    }

    protected abstract void OnCollisionEnter2D(Collision2D collision);

    protected void Move()
    {
        transform.Translate(angle.x * speed * Time.deltaTime, angle.y * speed * Time.deltaTime, 0.0f);
    }

    protected void Collide()
    {

    }

    protected void Reflect()
    {

    }

    public Vector2 Angle 
    { 
        get { return angle; } 
        // private set { angle = value; } 
    }

    public float Speed 
    { 
        get { return speed; } 
        // private set { speed = value; } 
    }

    public int Size 
    {
        get { return size; } 
    }
}