using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public static Sprite[] randomCriminalRecord;
    public static int randomHairNo, randomShirtNo;
    public AudioSource audioSource;

    public AudioSource clicking;
    public AudioClip audioClip;
    public bool toClick = true;
    public bool toVibrate = true;

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("volume") == 1)
        {
            audioSource.Play();
        }
        else if (PlayerPrefs.GetInt("volume") == 0)
        {
            audioSource.Stop();
        }

        if (PlayerPrefs.GetInt("sound") == 1)
        {
            toClick = true;
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            toClick = false;
        }

        if (PlayerPrefs.GetInt("vibrate") == 1)
        {
            toVibrate = true;
        }
        else if (PlayerPrefs.GetInt("vibrate") == 0)
        {
            toVibrate = false;
        }
    }

    private void Update()
    {
        if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0)) && toClick)
        {
            clicking.PlayOneShot(audioClip);
        }
    }
}
