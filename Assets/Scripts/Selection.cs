using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    public Sprite[] listOf5;
    public Sprite[] questions;
    public Vector3[] scales;

    public Sprite hair1, hair2, hair3, hair4, hair5;
    public Sprite eyes1, eyes2, eyes3, eyes4, eyes5;
    public Sprite glasses1, glasses2, glasses3, glasses4, glasses5;
    public Sprite mouth1, mouth2, mouth3, mouth4, mouth5;
    public Sprite shirt1, shirt2, shirt3, shirt4, shirt5;
    public Sprite ques1, ques2, ques3, ques4, ques5;

    public Sprite[] selected;
    public GameObject didYouGuess;

    public Image question, holder;

    public int counter = 0;
    public int questionCount = 0;
    public int hairNo, shirtNo;

    private void Start()
    {
        selected = new Sprite[5];
        questions = new Sprite[] { ques1, ques2, ques3, ques4, ques5 };
        scales = new Vector3[] { new Vector3(0.9247484f, 0.9247484f, 0.9247484f), new Vector3(), new Vector3(), new Vector3(), new Vector3() };
        ChangeQuestion();
        ChangeListOf5();
    }

    public void GoLeft()
    {
        if (counter == 0)
        {
            return;
        }

        counter--;

        holder.sprite = listOf5[counter];
        holder.SetNativeSize();
    }
    
    public void GoRight()
    {
        if (counter == 4)
        {
            return;
        }

        counter++;

        holder.sprite = listOf5[counter];
        holder.SetNativeSize();
    }

    public void Select()
    {
        selected[questionCount] = holder.sprite;
        questionCount++;

        if (questionCount < 5)
        {
            ChangeQuestion();
            ChangeListOf5();
        }
        else
        {
            shirtNo = counter;
            QuestionsDone();
        }
    }

    void ChangeQuestion()
    {
        question.sprite = questions[questionCount];
    }

    void ChangeListOf5()
    {
        if (questionCount == 0)
        {
            listOf5 = new Sprite[] { hair1, hair2, hair3, hair4, hair5 };
        }
        else if (questionCount == 1)
        {
            hairNo = counter;
            listOf5 = new Sprite[] { eyes1, eyes2, eyes3, eyes4, eyes5 };
        }
        else if (questionCount == 2)
        {
            listOf5 = new Sprite[] { glasses1, glasses2, glasses3, glasses4, glasses5 };
        }
        else if (questionCount == 3)
        {
            listOf5 = new Sprite[] { mouth1, mouth2, mouth3, mouth4, mouth5 };
        }
        else if (questionCount == 4)
        {
            listOf5 = new Sprite[] { shirt1, shirt2, shirt3, shirt4, shirt5 };
        }

        counter = 0;

        holder.sprite = listOf5[counter];
        holder.SetNativeSize();
    }

    void QuestionsDone()
    {
        didYouGuess.SetActive(true);
        FindObjectOfType<DidYouGuess>().selected = selected;
        FindObjectOfType<DidYouGuess>().hairNo = hairNo;
        FindObjectOfType<DidYouGuess>().shirtNo = shirtNo;
        gameObject.SetActive(false);
    }
}
