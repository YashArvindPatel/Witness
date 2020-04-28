using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalResult : MonoBehaviour
{
    public Sprite[] selected;

    public Image realHair, realEyes, realGlasses, realMouth, realShirt;

    public Image guessedHair, guessedEyes, guessedGlasses, guessedMouth, guessedShirt;

    public int hairNo, shirtNo;

    public int matchPerc = 0;

    private void Start()
    {
        realHair.sprite = Holder.randomCriminalRecord[0];
        realEyes.sprite = Holder.randomCriminalRecord[1];
        realGlasses.sprite = Holder.randomCriminalRecord[2];
        realMouth.sprite = Holder.randomCriminalRecord[3];
        realShirt.sprite = Holder.randomCriminalRecord[4];

        guessedHair.sprite = selected[0];
        guessedEyes.sprite = selected[1];
        guessedGlasses.sprite = selected[2];
        guessedMouth.sprite = selected[3];
        guessedShirt.sprite = selected[4];

        if (realHair.sprite == guessedHair.sprite)
        {
            matchPerc += 20;
        }
        
        if (realEyes.sprite == guessedEyes.sprite)
        {
            matchPerc += 20;
        }

        if (realGlasses.sprite == guessedGlasses.sprite)
        {
            matchPerc += 20;
        }

        if (realMouth.sprite == guessedMouth.sprite)
        {
            matchPerc += 20;
        }

        if (realShirt.sprite == guessedShirt.sprite)
        {
            matchPerc += 20;
        }

        FindObjectOfType<TextMeshProUGUI>().text = "Match " + matchPerc + "%";
           
        Vector3 hairScale = new Vector3(0.2170499f, 0.1712278f, 0.105371f);
        Vector3 hairPos = new Vector3(12, 158.5f, 0);

        Vector3 shirtScale = new Vector3(0.1728691f, 0.1624705f, 0.09163589f);
        Vector3 shirtPos = new Vector3(3, 28.2f, 0);

        if (hairNo == 3)
        {
            guessedHair.GetComponent<RectTransform>().localScale = hairScale;
            guessedHair.GetComponent<RectTransform>().localPosition = hairPos;
        }

        if (shirtNo == 1 || shirtNo == 2 || shirtNo == 3)
        {
            guessedShirt.GetComponent<RectTransform>().localScale = shirtScale;
            guessedShirt.GetComponent<RectTransform>().localPosition = shirtPos;
        }

        if (Holder.randomHairNo == 3)
        {
            realHair.GetComponent<RectTransform>().localScale = hairScale;
            realHair.GetComponent<RectTransform>().localPosition = hairPos;
        }

        if (Holder.randomShirtNo == 1 || Holder.randomShirtNo == 2 || Holder.randomShirtNo == 3)
        {
            realShirt.GetComponent<RectTransform>().localScale = shirtScale;
            realShirt.GetComponent<RectTransform>().localPosition = shirtPos;
        }
    }
}
