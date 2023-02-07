using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public class Asteroid : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] sprites;

    public float size = 1f;
    public float minSize = 0.35f;
    public float maxSize = 1.65f;
    public float movementSpeed = 50f;
    public float maxLifetime = 30f;

    float gold = 0f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        float x = Random.value * 20;
        if (x > 17)
        gold = 25f;
        // Assign random properties to make each asteroid feel unique
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);

        // Set the scale and mass of the asteroid based on the assigned size so
        // the physics is more realistic
        transform.localScale = Vector3.one * size;
        rigidbody.mass = size;

        // Destroy the asteroid after it reaches its max lifetime
        //Destroy(gameObject, maxLifetime);
    }

    public void SetTrajectory(Vector2 direction)
    {
        // The asteroid only needs a force to be added once since they have no
        // drag to make them stop moving
        rigidbody.AddForce(direction * movementSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            // Check if the asteroid is large enough to split in half
            // (both parts must be greater than the minimum size)
            if ((size * 0.3f) >= minSize)
            {
                CreateSplit();
                CreateSplit();
            }



            // Destroy the current asteroid since it is either replaced by two
            // new asteroids or small enough to be destroyed by the bullet
            Debug.Log("death or dying");
            Destroy(gameObject);
        }
    }

    private Asteroid CreateSplit()
    {
        // Set the new asteroid poistion to be the same as the current asteroid
        // but with a slight offset so they do not spawn inside each other
        Vector2 position = transform.position;
        position += Random.insideUnitCircle * 0.5f;

        // Create the new asteroid at half the size of the current
        Asteroid half = Instantiate(this, position, transform.rotation);
        half.size = size * 0.2f;

        // Set a random trajectory
        half.SetTrajectory(Random.insideUnitCircle.normalized);

        return half;
    }

}
