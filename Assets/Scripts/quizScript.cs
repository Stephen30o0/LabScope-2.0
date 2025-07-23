using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class quizScript : MonoBehaviour
{
    public TextAsset QuizData;

    //toggle buttons
    public GameObject TogA;
    public GameObject TogB;
    public GameObject TogC;
    public GameObject TogD;

    //text objects
    public GameObject QuesitonTxt;
    public GameObject AnsTxtA;
    public GameObject AnsTxtB;
    public GameObject AnsTxtC;
    public GameObject AnsTxtD;
    public GameObject ATitle;
    public GameObject BTitle;
    public GameObject CTitle;
    public GameObject DTitle;
    public GameObject StartButton;
    public GameObject ScoreTxt;
    public GameObject ScoreNum;
    public GameObject restartBtn;
    public GameObject WBScoreTxt;
    public GameObject WBScoreNum;

    //button on table
    public GameObject EnterBtn;

    //for remembering question number
    private int num;

    public int score;

    private bool newQuiz = false;

    //arrays for the quiz data to be stored
    private string[] questions;
    private string[] AnswerA;
    private string[] AnswerB;
    private string[] AnswerC;
    private string[] AnswerD;
    private string[] answerATF;
    private string[] answerBTF;
    private string[] answerCTF;
    private string[] answerDTF;

    void Awake()
    {
        restartBtn.SetActive(false);
        QuesitonTxt.SetActive(false);
        AnsTxtA.SetActive(false);
        AnsTxtB.SetActive(false);
        AnsTxtC.SetActive(false);
        AnsTxtD.SetActive(false);
        ATitle.SetActive(false);
        BTitle.SetActive(false);
        CTitle.SetActive(false);
        DTitle.SetActive(false);
        WBScoreNum.SetActive(false);
        WBScoreTxt.SetActive(false);

        TogA.SetActive(false);
        TogB.SetActive(false);
        TogC.SetActive(false);
        TogD.SetActive(false);
        EnterBtn.SetActive(false);
        ScoreTxt.SetActive(false);
        ScoreNum.SetActive(false);
    }

    // called when the start quiz button is called
    public void StartBtnPressed()
    {
        QuesitonTxt.SetActive(true);
        AnsTxtA.SetActive(true);
        AnsTxtB.SetActive(true);
            AnsTxtC.SetActive(true);
            AnsTxtD.SetActive(true);
            ATitle.SetActive(true);
            BTitle.SetActive(true);
            CTitle.SetActive(true);
            DTitle.SetActive(true);
            StartButton.SetActive(false);

        TogA.SetActive(true);
        TogB.SetActive(true);
        TogC.SetActive(true);
        TogD.SetActive(true);
        EnterBtn.SetActive(true);
        ScoreTxt.SetActive(true);
        ScoreNum.SetActive(true);

        string[] lines = QuizData.text.Split('\n');

            questions = new string[lines.Length];
            AnswerA = new string[lines.Length];
            AnswerB = new string[lines.Length];
            AnswerC = new string[lines.Length];
            AnswerD = new string[lines.Length];
            answerATF = new string[lines.Length];
            answerBTF = new string[lines.Length];
            answerCTF = new string[lines.Length];
            answerDTF = new string[lines.Length];

            //set the quiz data for the arrays
            int i = 0;
            foreach (string line in lines)
            {
                string[] lineData = line.Split(',');
                questions[i] = lineData[0];

                AnswerA[i] = lineData[1];
                AnswerB[i] = lineData[2];
                AnswerC[i] = lineData[3];
                AnswerD[i] = lineData[4];
                answerATF[i] = lineData[5];
                answerBTF[i] = lineData[6];
                answerCTF[i] = lineData[7];
                answerDTF[i] = lineData[8];
                i++;
            }

            QuesitonTxt.gameObject.GetComponent<TMP_Text>().text = questions[0];
            AnsTxtA.gameObject.GetComponent<TMP_Text>().text = AnswerA[0];
            AnsTxtB.gameObject.GetComponent<TMP_Text>().text = AnswerB[0];
            AnsTxtC.gameObject.GetComponent<TMP_Text>().text = AnswerC[0];
            AnsTxtD.gameObject.GetComponent<TMP_Text>().text = AnswerD[0];

    }

    public void EnterAnswer()
    {
        if (answerATF[num] == "CORRECT")
        {
            if (TogA.gameObject.GetComponent<Toggle>().isOn == true)
            {
                score++;
            }
        }
        else if (answerBTF[num] == "CORRECT")
        {
            if (TogB.gameObject.GetComponent<Toggle>().isOn == true)
            {
                score++;
            }
        }
        else if (answerCTF[num] == "CORRECT")
        {
            if (TogC.gameObject.GetComponent<Toggle>().isOn == true)
            {
                score++;
            }
        }
        else
        {
            if (TogD.gameObject.GetComponent<Toggle>().isOn == true)
            {
                score++;
            }
        }


        ScoreTxt.gameObject.GetComponent<TMP_Text>().text = score.ToString();

            //set next question
            if (num < AnswerA.Length - 1 && newQuiz == false)
            {
                num = num + 1;
            }
            else
            {
                QuesitonTxt.SetActive(false);
                AnsTxtA.SetActive(false);
                AnsTxtB.SetActive(false);
                AnsTxtC.SetActive(false);
                AnsTxtD.SetActive(false);
                ATitle.SetActive(false);
                BTitle.SetActive(false);
                CTitle.SetActive(false);
                DTitle.SetActive(false);
                restartBtn.SetActive(true);
                WBScoreNum.SetActive(true);
                WBScoreTxt.SetActive(true);
                EnterBtn.SetActive(false);
                WBScoreNum.gameObject.GetComponent<TMP_Text>().text = score.ToString();
            }

            QuesitonTxt.gameObject.GetComponent<TMP_Text>().text = questions[num];
            AnsTxtA.gameObject.GetComponent<TMP_Text>().text = AnswerA[num];
            AnsTxtB.gameObject.GetComponent<TMP_Text>().text = AnswerB[num];
            AnsTxtC.gameObject.GetComponent<TMP_Text>().text = AnswerC[num];
            AnsTxtD.gameObject.GetComponent<TMP_Text>().text = AnswerD[num];

    }
}
