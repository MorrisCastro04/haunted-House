using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject player;
    public CanvasGroup backgroundWin;
    public float fadeDuration;
    bool isplayer;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isplayer) {
            EndLevel();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isplayer = true;
        }
    }

    void EndLevel(){
        timer += Time.deltaTime;
        backgroundWin.alpha = timer / fadeDuration;
        if (timer > fadeDuration) {
            Application.Quit();
        }
    }
}
