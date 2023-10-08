using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    private int count;
    private int numPickups = 4;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI WinText;
    public TextMeshProUGUI PlayerPosition;
    public TextMeshProUGUI PlayerVelocity;
    public Vector3 lastPosition;

    void OnMove(InputValue value) {
        moveValue = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
        Vector3 Velocity = (transform.position - lastPosition)/Time.fixedDeltaTime;
        float velocity = MathF.Sqrt(Velocity.x*Velocity.x+Velocity.y*Velocity.y+Velocity.z*Velocity.z);
        PlayerVelocity.text = velocity.ToString();
        PlayerPosition.text = (transform.position).ToString();
        lastPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);

            count = count + 1;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        ScoreText.text = "Score: " + count.ToString();
        if(count >= numPickups)
        {
            WinText.text = "You Win!";
        }

    }

    void Start()
    {
        count = 0;
        WinText.text = "";
        SetCountText();
        lastPosition = transform.position;
    }
}
