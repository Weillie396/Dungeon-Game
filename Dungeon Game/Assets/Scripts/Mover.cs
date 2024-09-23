using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float yspeed = 0.75f;
    protected float xspeed = 1.0f;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    protected virtual void UpdateMotor(Vector3 input)
    {
        // reset moveDelta
        moveDelta = new Vector3(input.x * xspeed, input.y * yspeed, 0).normalized;

        // Swap Sprite Direction, whether you are going right or left

        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Add push vector if any

        moveDelta += pushDirection;

        // Reduce the push force every frame dependant on the recovery
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);


        // Make sure you can move in Y direction by casting a box first
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // Make the player move
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        // Make sure you can move in X direction by casting a box first
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // Make the player move
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
