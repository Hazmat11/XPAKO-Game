using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public static float playerSpeed = 5f;
    public float currentSpeed;
    public float timeValue = 0;
    public float Timefixed;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    // Update is called once per frame

    void Start() 
    {
        playerSpeed = currentSpeed;
    }
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (playerSpeed < 3) 
        {
            playerSpeed = 3;
        }

        if (playerSpeed < 5)
        {
            Timefixed = Mathf.Round(timeValue += Time.deltaTime);
        }else
        {
            timeValue = 0;
        }

        if (Timefixed == 7)
        {
            playerSpeed = 5;
            Timefixed = 0;
            timeValue = 0;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void Slow (int slow)
    {
        playerSpeed -= slow;
    }
}
