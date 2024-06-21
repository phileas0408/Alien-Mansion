using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float gravity = 9.81f;
    private float currentgravity = 0;
    public float jumpForce = 6f;


    [SerializeField]
    private GameObject bulletprefab;
    [SerializeField]
    private float TimeToReload;
    [SerializeField]
    private Transform firePoint;
    private float bulletReload;

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

        //more gravity if down key is pressed
        if (Input.GetAxis("Vertical") < 0)
        {
            currentgravity = gravity * 2.5f;
        } else{
            currentgravity = gravity;
        }


        direction += Vector3.down * currentgravity * Time.deltaTime;

        if (character.isGrounded)
        {
            direction = Vector3.down;

            if (Input.GetAxis("Vertical") > 0)
            {
                direction = Vector3.up * jumpForce;
            }
        }



        if (Input.GetAxis("Horizontal") > 0){
            Debug.Log("shoot");
            Shoot();
        }
        bulletReload -= Time.deltaTime;

        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) {
            gameManager.Instance.GameOver();
        }
    }

    private void Shoot(){
        if (bulletReload <= 0){
            Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
            bulletReload = TimeToReload;
        }
    }
}