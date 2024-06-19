using UnityEditor;
using UnityEngine;

public class background : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update() {
        float speed = gameManager.Instance.gameSpeed / transform.localScale.x;
        meshRenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}
