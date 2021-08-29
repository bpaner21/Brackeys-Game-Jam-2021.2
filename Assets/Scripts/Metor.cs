using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Metor : Projectile
{
    [SerializeField] protected CircleCollider2D colliding;

    public bool contact = false;

    new protected void Awake()
    {
        base.Awake();

        colliding = GetComponent<CircleCollider2D>();

        colliding.radius = transform.localScale.x;
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
        contact = !contact;

        if (contact) { rendering.color = Color.red; Debug.Log("Red"); }
        else { rendering.color = Color.white; Debug.Log("White"); }

        Vector2 inN = transform.position;

        inN = (inN - collision.contacts[0].point).normalized;

        angle = Vector2.Reflect(angle, inN).normalized;
    }
}
