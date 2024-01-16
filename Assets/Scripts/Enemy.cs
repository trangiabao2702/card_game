using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;
using Math = System.Math;
public class Enemy : MonoBehaviour
{
    private Vector3 startPosition;
    private float MaxX;
    private float MinX;
    private float MaxY;
    private float MinY;
    float horizontalInput = 0f;
    float verticalInput = 0f;
    bool facingRight = false;
    Random random = new Random();

    // Start is called before the first frame update
    public float speed = 3f; // Tốc độ di chuyển
    private Rigidbody2D rb;
    public Animator animator;

    public EnemySpawner spawner;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        MaxX = startPosition.x + 1.5f > 55f ? 55f : startPosition.x + 1.5f;
        MinX = startPosition.x - 1.5f < 5f ? 5f : startPosition.x - 1.5f;
        MaxY = startPosition.y + 1.5f > 4.5f ? 4.5f : startPosition.y + 1.5f;
        MinY = startPosition.y - 1.5f < -3f ? -3f : startPosition.y - 1.5f;
        randomDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if(horizontalInput != 0f || verticalInput != 0f)
        {
            MoveEnemy();
        }
    }

    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.decreaseMobCount();
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Mob"))
    //    {
    //        Debug.Log("colision mob");
    //    }
    //}
    void randomDirection()
    {
        Vector3 currentPosition = transform.position;
        while (horizontalInput == 0f && verticalInput == 0f)
        {
            int randomIndex = random.Next(0, 4);
            // Kiểm tra input từ các phím mũi tên
            if (randomIndex == 0 && currentPosition.x > MinX) 
            {
                //Debug.Log("Enemy move to left");
                horizontalInput = -1f;
            }
            else if (randomIndex == 1 && currentPosition.x < MaxX)
            {
                //Debug.Log("Enemy move to right");
                horizontalInput = 1f;
            }
            else if (randomIndex == 2 && currentPosition.y < MaxY)
            {
                //Debug.Log("Enemy move up");
                verticalInput = 1f;
            }
            else if (randomIndex == 3 && currentPosition.y > MinY)
            {
                //Debug.Log("Enemy move to down");
                verticalInput = -1f;
            }
        }
    }
    void MoveEnemy()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        if (horizontalInput < 0 && !facingRight)
        {
            Flip();
        }
        if (horizontalInput > 0 && facingRight)
        {
            Flip();
        }
        // Tạo vector di chuyển từ input
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize();
        //Debug.Log(movement);
        // Áp dụng di chuyển
        rb.velocity = movement * speed;
        Vector3 currentPosition = transform.position;
        if(currentPosition.x <= MinX || currentPosition.x >= MaxX || currentPosition.y <= MinY || currentPosition.y >= MaxY)
        {
            horizontalInput = 0f;
            verticalInput = 0f;
            //animator.SetFloat("Speed", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
            //Debug.Log("set not move");
            Invoke("randomDirection", 1f);
        }
    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
