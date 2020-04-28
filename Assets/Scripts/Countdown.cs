using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Sprite count2,count1;
    public float timer = 1f;
    public int counter = 3;
    public GameObject criminalProfile;

    void Update()
    {
        if (timer < 0 && counter > 0)
        {
            counter--;

            if (counter == 2)
            {
                GetComponent<Image>().sprite = count2;
            }
            else if (counter == 1)
            {
                GetComponent<Image>().sprite = count1;
            }

            timer = 1f;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if (counter <= 0)
        {
            criminalProfile.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
