using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Projectile : MonoBehaviour
{
    protected static class Directions
    {
        public const float Up = Mathf.PI * 0.5f;
        public const float Left = Mathf.PI;
        public const float Down = Mathf.PI * 1.5f;
        public const float Right = Mathf.PI * 2.0f;
    }

    private static float screenWidth = Screen.width;
    private static float screenHeight = Screen.height;

    [SerializeField] protected SpriteRenderer rendering;

    [SerializeField] private bool becameVisible = false;

    [SerializeField] protected float angle = 0.0f; // Angle in Radians

    [SerializeField] protected Vector2 angleXY; // movement direction of angle, presented as a normalized vector

    [SerializeField] protected float speed = 1.0f;

    [SerializeField] protected int health;

    protected void Awake()
    {
        rendering = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    protected void Start()
    {
        if (angleXY == Vector2.zero)
        {
            angleXY = new Vector2(-transform.position.x, -transform.position.y);
            angleXY.Normalize();
        }

        //speed = 1.0f;

        //Debug.Log("Start");
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
        transform.Translate(angleXY.x * speed * Time.deltaTime, angleXY.y * speed * Time.deltaTime, 0.0f);
    }

    protected void Collide()
    {

    }

    protected void Reflect()
    {

    }

    public float Angle
    {
        get { return angle;  }
        // protected set { angle = value; }
    }

    public Vector2 AngleXY
    { 
        get { return angleXY; } 
        // protected set { angleXY = value; } 
    }

    public float Speed 
    { 
        get { return speed; } 
        // private set { speed = value; } 
    }
}