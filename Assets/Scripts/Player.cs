using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float gravity = 9.81f;
    public float jumpForce = 5f;

    private void Awake() 
    {
        character = GetComponent<CharacterController>();
    }

    private void OnEnable() 
    {
        direction = Vector3.zero;
    }

    public void Update() 
    {
        direction += Vector3.down * gravity * Time.deltaTime;

        if (character.isGrounded)
        {
            direction = Vector3.down;

            if (Input.GetButton("Jump"))
            {
                direction = Vector3.up * jumpForce;
            }
        }

        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) {
            gameManager.Instance.GameOver();
        }
    }
}
