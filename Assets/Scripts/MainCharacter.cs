using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacter : MonoBehaviour
{
    public float speed = 5f; // Tốc độ di chuyển
    private Rigidbody2D rb;
    public Animator animator;

    //public static Singleton Instance { get; private set; }
    // Start is called before the first frame update
    public int playerRank = 0;

    //void Awake()
    //{
    //    // Save a Reference to the component as our singleton instance
    //    Instance = this;
    //}

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveToCenter());
    }
    private bool isMoving = false;
    IEnumerator MoveToCenter()
    {
        // Lấy vị trí ban đầu và vị trí giữa màn hình
        Vector3 initialPosition = transform.position;
        Vector3 centerPosition = new Vector3(0, 0, 0);

        // Tính toán thời gian di chuyển
        float moveTime = 2f; // Điều chỉnh thời gian di chuyển theo ý muốn

        // Di chuyển từ vị trí ban đầu đến vị trí giữa màn hình trong khoảng thời gian moveTime
        float elapsedTime = 0f;
        while (elapsedTime < moveTime)
        {
            animator.SetFloat("Speed", elapsedTime / moveTime);
            transform.position = Vector3.Lerp(initialPosition, centerPosition, elapsedTime / moveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Khi đã đến giữa, cho phép người chơi điều khiển
        isMoving = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mob")
        {
            Debug.Log("colision mob");
            SceneManager.LoadScene("BattleScene");
            Debug.Log("Move to battle scene");
        }
    }

    public int getPlayerRank()
    {
        return playerRank;
    }


    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            MovePlayer();
        }
    }

    bool facingRight = false;
    void MovePlayer()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;
 

        // Kiểm tra input từ các phím mũi tên
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalInput = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalInput = -1f;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        if(horizontalInput < 0 && !facingRight)
        {
            Flip();
        }
        if(horizontalInput > 0 && facingRight)
        {
            Flip();
        }
        // Tạo vector di chuyển từ input
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize();

        // Áp dụng di chuyển
        rb.velocity = movement * speed;
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
