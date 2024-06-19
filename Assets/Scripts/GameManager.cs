using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance { get; private set; }


    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    private void Awake() {
        if (Instance == null){
            Instance = this;
        } else {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy() {
        if (Instance == this){
            Instance = null;
        }
    }

    public void Start() {
        NewGame();
    }

    private void NewGame() {
        gameSpeed = initialGameSpeed;
    }

    private void Update(){
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
    }

}
