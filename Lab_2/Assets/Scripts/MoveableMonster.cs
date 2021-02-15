using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveableMonster : Monster
{
    private float speed = 2.0f;

    private Vector3 direction;
    private SpriteRenderer sprite;

    protected override void Awake() 
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void Start()
    {
        direction = transform.right;
    }

    protected override void Update()
    {
        Move();
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.3f + transform.right * direction.x * 1.8f, 0.1f);
        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Character>())) direction *= -1f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x > 0.0f;
    }
}

