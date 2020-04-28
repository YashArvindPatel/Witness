using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DidYouGuess : MonoBehaviour
{
    public Sprite[] selected;
    public float timer = 5;
    public GameObject result;
    public int hairNo, shirtNo;

    private void Update()
    {
        if (timer < 0)
        {
            result.SetActive(true);
            FindObjectOfType<FinalResult>().selected = selected;
            FindObjectOfType<FinalResult>().hairNo = hairNo;
            FindObjectOfType<FinalResult>().shirtNo = shirtNo;
            gameObject.SetActive(false);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

}
