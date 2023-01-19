using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]

public class Answers
{
    public string question;
    public string[] options;
    public int correctAnswer;
}

public class QuestMana : MonoBehaviour
{
    
    public List<Answers> ans;
    public GameObject[] optionsButtons;
    public int currentQuestion;
    public Text questionText;
    public Text QuestNumber;
    [SerializeField] TextMeshProUGUI TextClock;
    private float valueTimer;
    private bool status;
    public GameObject questionPanel;
    public GameObject restartPanel;

    public Text currentText;
    public int score;
    int questNum = 0;

    private void Awake()
    {
     status = true;
     valueTimer = 60f;
    }

    void Start()
    {
        questNum = ans.Count;
        GenerateQ();
        restartPanel.SetActive(false);
    }

    void Gameover()
    {
        restartPanel.SetActive(true);
        questionPanel.SetActive(false);
        questionText.text = score + "/" + questNum;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        //condition of clock
        if(status)
        {
            valueTimer -= Time.deltaTime;
            int tm = Mathf.FloorToInt(valueTimer);
            TextClock.text = ""+tm;

            if(valueTimer <= 0){status = false;}
        }     
    }

    void GenerateQ()
    {
        if(ans.Count > 0)
        {
            currentQuestion = Random.Range(0, ans.Count);
            questionText.text = ans[currentQuestion].question;
            SetAnsw();
        }
        else
        {
            Gameover();
        }
    }

    void SetAnsw()
    {
        for(int i = 0; i < optionsButtons.Length; i++)
        {
            optionsButtons[i].transform.GetChild(0).GetComponent<Text>().text 
                = ans[currentQuestion].options[i];
            optionsButtons[i].GetComponent<Valider>().opcCorrect = false;
            
            if(ans[currentQuestion].correctAnswer == i+1)
            {
                optionsButtons[i].GetComponent<Valider>().opcCorrect = true;
            }
        }
    }

    public void SetCorrect()
    {
        score += 1;
        GenerateQ();
        ans.RemoveAt(currentQuestion);
    }

    public void SetWrong()
    {
        GenerateQ();
        ans.RemoveAt(currentQuestion);
    }
}
