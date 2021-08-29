using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Animator))]
public class Enemy : Projectile
{
    [SerializeField] protected int health = 100;

    [SerializeField] protected PolygonCollider2D colliding;

    [SerializeField] protected Animator animating;

    new protected void Awake()
    {
        base.Awake();

        colliding = GetComponent<PolygonCollider2D>();

        animating = GetComponent<Animator>();
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

        inN = (inN - collision.contacts[0].point).normalized;

        angle = Vector2.Reflect(angle, inN).normalized;
    }
}
