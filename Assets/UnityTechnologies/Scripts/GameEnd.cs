using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public GameObject player;
    public CanvasGroup backgroundWin;
    public AudioSource winSound;
    public CanvasGroup backgroundLose;
    public AudioSource loseSound;

    public float fadeDuration;
    public float displayImageDuration;
    bool isplayer;
    bool isCaught;
    bool hasAudioPlayed;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isplayer) {
            EndLevel(backgroundWin, false, winSound);
        }
        else if (isCaught) {
            EndLevel(backgroundLose, true, loseSound);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isplayer = true;
        }
    }

    void EndLevel(CanvasGroup imgCanvas, bool restart, AudioSource sound) {
        if (!hasAudioPlayed) {
            sound.Play();
            hasAudioPlayed = true;
        }
        timer += Time.deltaTime;
        imgCanvas.alpha = timer / fadeDuration;
        if (timer > fadeDuration + displayImageDuration) {
            if (restart) {
                SceneManager.LoadScene(0);
            }
            else {
                SceneManager.LoadScene(0);
            }
        }
    }
    public void CaughtPlayer() {
        isCaught = true;
    }
}
