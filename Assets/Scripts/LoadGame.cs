using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public bool toVibrate = true;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }

    public void Update()
    {

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(audioClip);
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                LeaveGame();

                return;
            }
        }
    }

    public void LeaveGame()
    {
        Application.Quit();
    }   
}
