using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCriminalGenerator : MonoBehaviour
{
    public Sprite hair1, hair2, hair3, hair4, hair5;
    public Sprite eyes1, eyes2, eyes3, eyes4, eyes5;
    public Sprite glasses1, glasses2, glasses3, glasses4, glasses5;
    public Sprite mouth1, mouth2, mouth3, mouth4, mouth5;
    public Sprite shirt1, shirt2, shirt3, shirt4, shirt5;
    public Vector3 originalScaleForHair;
    public Vector3 originalScaleForShirt;
    public Vector3 scaleForHair;
    public Vector3 scaleForShirt;
    public Vector3 originalPosForHair;
    public Vector3 originalPosForShirt;
    public Vector3 posForHair;
    public Vector3 posForShirt;

    public Sprite[] randomCriminalRecord;

    public RectTransform hairObject, shirtObject;

    public Image hair, eyes, glasses, mouth, shirt;

    public GameObject question1;

    public float timer = 2;

    void Start()
    {
        randomCriminalRecord = new Sprite[5];
        scaleForHair = new Vector3(0.2157371f, 0.1724692f, 0.105371f);
        scaleForShirt = new Vector3(0.1751722f, 0.1695681f, 0.09163589f);
        posForHair = new Vector3(13.3f, 61.3f, 0);
        posForShirt = new Vector3(2, -68, 0);
        originalScaleForHair = hairObject.localScale;
        originalScaleForShirt = shirtObject.localScale;
        originalPosForHair = hairObject.localPosition;
        originalPosForShirt = shirtObject.localPosition;
        GenerateRandomCriminal();
    }    

    public void GenerateRandomCriminal()
    {
        Sprite[] hairList = { hair1, hair2, hair3, hair4, hair5 };
        Sprite[] eyesList = { eyes1, eyes2, eyes3, eyes4, eyes5 };
        Sprite[] glassesList = { glasses1, glasses2, glasses3, glasses4, glasses5 };
        Sprite[] mouthList = { mouth1, mouth2, mouth3, mouth4, mouth5 };
        Sprite[] shirtList = { shirt1, shirt2, shirt3, shirt4, shirt5 };

        int ran1 = Random.Range(0, 5);
        int ran2 = Random.Range(0, 5);

        hair.sprite = hairList[ran1];
        eyes.sprite = eyesList[Random.Range(0, 5)];
        glasses.sprite = glassesList[Random.Range(0, 5)];
        mouth.sprite = mouthList[Random.Range(0, 5)];
        shirt.sprite = shirtList[ran2];

        if (ran1 == 3)
        {
            hairObject.localScale = scaleForHair;
            hairObject.localPosition = posForHair;
        }
        else
        {
            hairObject.localScale = originalScaleForHair;
            hairObject.localPosition = originalPosForHair;
        }

        if (ran2 == 1 || ran2 == 2 || ran2 == 3)
        {
            shirtObject.localScale = scaleForShirt;
            shirtObject.localPosition = posForShirt;
        }
        else
        {
            shirtObject.localScale = originalScaleForShirt;
            shirtObject.localPosition = originalPosForShirt;
        }

        randomCriminalRecord[0] = hair.sprite;
        randomCriminalRecord[1] = eyes.sprite;
        randomCriminalRecord[2] = glasses.sprite;
        randomCriminalRecord[3] = mouth.sprite;
        randomCriminalRecord[4] = shirt.sprite;

        Holder.randomCriminalRecord = randomCriminalRecord;
        Holder.randomHairNo = ran1;
        Holder.randomShirtNo = ran2;
    }

    private void Update()
    {
        if (timer < 0)
        {
            question1.SetActive(true);
            gameObject.SetActive(false);
            timer = 2;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
