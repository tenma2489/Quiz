using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<FlagData> flags;

    public Image leftImage;
    public Image rightImage;

    public TMP_Text questionText;

    private int correctSide; //0=ç∂ 1=âE

    void Start()
    {
        NextQuestion();
    }

    public void NextQuestion()
    {
        int answer = Random.Range(0, flags.Count);

        int wrong;
        do
        {
            wrong = Random.Range(0, flags.Count);
        } while (wrong == answer);

        questionText.text = flags[answer].countryName;

        correctSide = Random.Range(0, 2);

        if (correctSide == 0)
        {
            leftImage.sprite = flags[answer].flag;
            rightImage.sprite = flags[wrong].flag;
        }
        else
        {
            rightImage.sprite = flags[answer].flag;
            leftImage.sprite = flags[wrong].flag;
        }
    }

    public void SelectLeft()
    {
        CheckAnswer(0);
    }

    public void SelectRight()
    {
        CheckAnswer(1);
    }

    void CheckAnswer(int side)
    {
        if (side == correctSide)
        {
            Debug.Log("ê≥âÅI");
        }
        else
        {
            Debug.Log("ïsê≥â");
        }

        NextQuestion();
    }
}
