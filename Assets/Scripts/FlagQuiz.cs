using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlagQuiz : MonoBehaviour
{
    public TMP_Text questionText;

    public string[] countryNames;

    [Header("問題の国旗")]
    public Sprite[] flags; // 5枚の国旗


[Header("選択肢ボタン")]
    public Image leftImage;
    public Image rightImage;

    private int correctIndex;
    private int wrongIndex;

    // 正解が左かどうか
    private bool isCorrectLeft;

    void Start()
    {
        CreateQuestion();
    }

    public void CreateQuestion()
    {
        // 正解をランダムに選ぶ
        correctIndex = Random.Range(0, flags.Length);

        // 不正解を選ぶ（正解以外）
        do
        {
            wrongIndex = Random.Range(0, flags.Length);
        }
        while (wrongIndex == correctIndex);

        // 左右をランダム
        isCorrectLeft = Random.value < 0.5f;

        if (isCorrectLeft)
        {
            leftImage.sprite = flags[correctIndex];
            rightImage.sprite = flags[wrongIndex];
        }
        else
        {
            leftImage.sprite = flags[wrongIndex];
            rightImage.sprite = flags[correctIndex];
        }

        questionText.text = countryNames[correctIndex] + " はどっち？";


    }

    // 左ボタン
    public void LeftButton()
    {
        if (isCorrectLeft)
            Debug.Log("正解！");
        else
            Debug.Log("不正解");

        CreateQuestion();
    }

    // 右ボタン
    public void RightButton()
    {
        if (!isCorrectLeft)
            Debug.Log("正解！");
        else
            Debug.Log("不正解");

      
    }
}