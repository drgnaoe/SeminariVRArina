using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject Coube1;
    public GameObject Cube;
    public Text counterText;

    private int score = 0;

    // Переменные для движения
    private CharacterController controller;
    private bool isMoving = false;
    private float moveSpeed = 5.0f; // Скорость движения

    void Start()
    {
        controller = GetComponent<CharacterController>();
        UpdateCounterText();
    }

    public void onClick()
    {
        if (!isMoving)
        {
            isMoving = true;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            float upInput = Input.GetKey(KeyCode.Space) ? 1 : (Input.GetKey(KeyCode.LeftControl) ? -1 : 0);

            Vector3 moveDirection = new Vector3(horizontalInput, upInput, verticalInput);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;

            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Coube1 || collision.gameObject == Cube)
        {
            score++;
            UpdateCounterText();
        }
    }

    void UpdateCounterText()
    {
        counterText.text = "Соприкосновений: " + score.ToString();
    }
}
