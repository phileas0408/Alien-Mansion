using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletSpeed = 3f;

    private void Start() {
        Destroy(gameObject, 10);
    }
    private void Update() {
        transform.position += bulletSpeed * Time.deltaTime * Vector3.right;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) {
            if (other.gameObject.name == "cow(Clone)") {
                Debug.Log("killed a cow");
                gameManager.Instance.score += -50;
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
