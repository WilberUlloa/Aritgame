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
    [SerializeField] TextMeshProUGUI TextClock;
    private float valueTimer;
    private bool status;
    public GameObject questionPanel;
    public GameObject restartPanel;

    public Text currentText;
    public int score;
    int totalQuestion = 0;

    public Text MaxP;
    public Text MinP;

    private void Awake()
    {
     status = true;
     valueTimer = 60f;
    }

    void Start()
    {
        status = false;
        totalQuestion = ans.Count;
        restartPanel.SetActive(false);
        GenerateQ();
    }

    void Gameover()
    {
        restartPanel.SetActive(true);
        questionPanel.SetActive(false);
        currentText.text = score + " / " + totalQuestion;
        status = false;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex);
    }

    public void StartClock(){status = true;}

   public void Update()
    {
        //condition of clock
        if(status)
        {
            valueTimer -= Time.deltaTime;
            int tm = Mathf.FloorToInt(valueTimer);
            TextClock.text = ""+tm;

            if(valueTimer <= 0+1)
            {
                status = false;
                Gameover();
            }
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
            optionsButtons[i].GetComponent<Valider>().opcCorrect = false;
            optionsButtons[i].transform.GetChild(0).GetComponent<Text>().text 
                = ans[currentQuestion].options[i];
            
            if(ans[currentQuestion].correctAnswer == i+1)
            {
                optionsButtons[i].GetComponent<Valider>().opcCorrect = true;
            }
        }
    }

    public void SetCorrect()
    {
        score += 1;
        ans.RemoveAt(currentQuestion);
        GenerateQ();
    }

    public void SetWrong()
    {
        ans.RemoveAt(currentQuestion);
        GenerateQ();
    }
}
