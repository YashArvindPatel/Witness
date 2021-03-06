﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffScript : MonoBehaviour
{
    public Sprite on;
    public Sprite off;
    public bool onOrOff = true;
    public Vector3 setScale;
    public bool toVibrate = true;

    public AudioSource audioSource;

    public bool isMusic = true;
    public bool isSound = true;
    public bool isVibration = true;

    public void Switch()
    {
        if (onOrOff)
        {
            onOrOff = false;
            GetComponent<Image>().sprite = off;

            if (isMusic)
            {
                audioSource.Pause();
            }
            else if (isSound)
            {
                audioSource.mute = true;
            }
            else if (isVibration)
            {
                toVibrate = false;
                FindObjectOfType<LoadGame>().toVibrate = false;
            }
           
            GetComponent<RectTransform>().localScale = new Vector3(6, 6, 6);
        }
        else
        {
            onOrOff = true;
            GetComponent<Image>().sprite = on;

            if (isMusic)
            {
                audioSource.UnPause();
            }
            else if (isSound)
            {
                audioSource.mute = false;
            }
            else if (isVibration)
            {
                toVibrate = true;
                FindObjectOfType<LoadGame>().toVibrate = true;
            }

            GetComponent<RectTransform>().localScale = setScale;
        }
    }

    private void OnDisable()
    {
        if (isMusic)
        {
            if (onOrOff)
            {
                PlayerPrefs.SetInt("volume", 1);
            }
            else
            {
                PlayerPrefs.SetInt("volume", 0);
            }
        }
        
        if (isSound)
        {
            if (onOrOff)
            {
                PlayerPrefs.SetInt("sound", 1);
            }
            else
            {
                PlayerPrefs.SetInt("sound", 0);
            }
        }
       
        if (isVibration)
        {
            if (onOrOff)
            {
                PlayerPrefs.SetInt("vibrate", 1);
            }
            else
            {
                PlayerPrefs.SetInt("vibrate", 0);
            }
        }
    }
}
