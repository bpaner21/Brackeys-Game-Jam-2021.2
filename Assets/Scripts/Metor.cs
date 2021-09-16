using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Metor : Projectile
{
    [SerializeField] protected CircleCollider2D colliding;

    [SerializeField] protected Sprite circle;

    [SerializeField] protected GameObject splitMeteor;

    new protected void Awake()
    {
        base.Awake();

        colliding = GetComponent<CircleCollider2D>();
    }

    /*
    // Start is called before the first frame update
    new void Start()
    {

    }
    //*/

    /*
    // Update is called once per frame
    void Update()
    {

    } 
    //*/

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 inN = transform.position;

        inN = (inN - collision.contacts[0].point);

        inN.Normalize();

        angleXY = Vector2.Reflect(angleXY, inN);

        angleXY.Normalize();

        angle = Mathf.Atan2(angleXY.y, angleXY.x);

        if (angle < 0) { angle += Mathf.PI * 2.0f; }

        Split();
    }

    protected void Split()
    {
        float a1 = -1.0f, a2 = -1.0f, newSpd = Speed + 2.0f, newRad = transform.localScale.y / 2.0f;

        if (0 <= angle && angle < Directions.Up) 
        {
            a1 = angle / 2.0f;
            a2 = angle + ((Directions.Up - angle) / 2.0f);
        }

        if (Directions.Up <= angle && angle < Directions.Left) 
        {
            a1 = Directions.Up + ((angle - Directions.Up) / 2.0f);
            a2 = Directions.Up + ((Directions.Left - angle) / 2.0f);
        }

        if (Directions.Left <= angle && angle < Directions.Down) 
        {
            a1 = Directions.Left + ((angle - Directions.Left) / 2.0f);
            a2 = Directions.Left + ((Directions.Down - angle) / 2.0f);
        }
        
        if (Directions.Down <= angle && angle < Directions.Right) 
        {
            a1 = Directions.Down + ((angle - Directions.Down) / 2.0f);
            a2 = Directions.Down + ((Directions.Up - angle) / 2.0f);
        }

        //Debug.Log("a1: " + a1 + ", cos: " + Mathf.Cos(a1) + ", sin: " + Mathf.Sin(a1));
        //Debug.Log("a2: " + a2 + ", cos: " + Mathf.Cos(a2) + ", sin: " + Mathf.Sin(a2));

        if (health > 1)
        {
            CreateNewMeteor(a1);

            CreateNewMeteor(a2);

            Destroy(gameObject);
        }
    }

    protected void CreateNewMeteor(float newAngle)
    {
        GameObject newM = Instantiate(splitMeteor, this.transform.position, this.transform.rotation);

        var mScript = newM.GetComponent<Metor>();

        mScript.angleXY = new Vector2(Mathf.Cos(newAngle), Mathf.Sin(newAngle));
        mScript.angleXY.Normalize();

        //Debug.Log("Angle Set");

        mScript.speed = this.speed + 1.0f;
        mScript.transform.localScale = new Vector3(this.transform.localScale.x - 0.2f, this.transform.localScale.y - 0.2f, 1.0f);

        mScript.health = this.health / 2;

        return;
    }
}
