using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : Projectile
{
    [SerializeField] protected PolygonCollider2D eCollider;

    [SerializeField] protected Rigidbody2D eRigidbody;

    [SerializeField] protected Animator eAnimator;

    new protected void Awake()
    {
        base.Awake();

        health = 100;

        eCollider = GetComponent<PolygonCollider2D>();

        eRigidbody = GetComponent<Rigidbody2D>();

        eAnimator = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new protected void Update()
    {
        base.Update();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 inN = transform.position;

        inN = (inN - collision.contacts[0].point);

        inN.Normalize();

        angleXY = Vector2.Reflect(angleXY, inN);

        angleXY.Normalize();

        Debug.Log(this + " Hit");
    }
}
