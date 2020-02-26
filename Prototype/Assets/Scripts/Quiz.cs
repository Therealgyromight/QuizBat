using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour {

    [System.NonSerialized] public Button answer1;
    [System.NonSerialized] public Button answer2;
    [System.NonSerialized] public Button answer3;
    [System.NonSerialized] public Button answer4;
    public Text question;
    [System.NonSerialized] public int questionID;
    [System.NonSerialized] public int question1ID, question2ID, question3ID, question4ID = 0;
    public string question1;
    public string question1answer1;
    public string question1answer2;
    public string question1answer3;
    public string question1answer4;
    public string correctAnswer1;
    public string question2;
    public string question2answer1;
    public string question2answer2;
    public string question2answer3;
    public string question2answer4;
    public string correctAnswer2;
    public string question3;
    public string question3answer1;
    public string question3answer2;
    public string question3answer3;
    public string question3answer4;
    public string correctAnswer3;
    public string question4;
    public string question4answer1;
    public string question4answer2;
    public string question4answer3;
    public string question4answer4;
    public string correctAnswer4;
    public string question5;
    public string question5answer1;
    public string question5answer2;
    public string question5answer3;
    public string question5answer4;
    public string correctAnswer5;
    public string question6;
    public string question6answer1;
    public string question6answer2;
    public string question6answer3;
    public string question6answer4;
    public string correctAnswer6;
    public string question7;
    public string question7answer1;
    public string question7answer2;
    public string question7answer3;
    public string question7answer4;
    public string correctAnswer7;
    public string question8;
    public string question8answer1;
    public string question8answer2;
    public string question8answer3;
    public string question8answer4;
    public string correctAnswer8;
    public string question9;
    public string question9answer1;
    public string question9answer2;
    public string question9answer3;
    public string question9answer4;
    public string correctAnswer9;
    public string question10;
    public string question10answer1;
    public string question10answer2;
    public string question10answer3;
    public string question10answer4;
    public string correctAnswer10;
    public int questionNumber = 1;
    public int level;
    public GameObject canvas;
    // Use this for initialization
    void Start () {

        level = PlayerPrefs.GetInt("Level");
        // Check if the limit of questions has been reached
        if (questionNumber == 6)
        {
            //If so, store the player level to be accessed in the next scene
            PlayerPrefs.SetInt("Level", level);
            // And change to the next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
        // Generate a random number from 1 to 10
        questionID = Random.Range(1, 11);
        LoopCheck();
	}

    void LoopCheck()
    {
        //Compare the Id of the chosen question to those of previously chosen questions
        if (questionID == question1ID || questionID == question2ID || questionID == question3ID || questionID == question4ID)
        {
            //If the id is repeated generate a new number
            Start();

        }
        else
        {
            //if the id is different from the previous move to the next part
            Update();
        }
    }
	
	// Update is called once per frame
	void Update () {
        {

            Debug.Log(level);
        
            if(questionID == 1)
            {
                //Assign each question and answer to their respective button and text fields based on the ID and store the ID to avoid repeats
                GameObject.Find("Button1").GetComponentInChildren<Text>().text = question1answer1;
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = question1answer2;
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = question1answer3;
                GameObject.Find("Button4").GetComponentInChildren<Text>().text = question1answer4;
                question.text = question1.ToString();
                if(questionNumber == 1)
                {
                    question1ID = 1;
                }
                if (questionNumber == 2)
                {
                    question2ID = 1;
                }
                if (questionNumber == 3)
                {
                    question3ID = 1;
                }
                if (questionNumber == 4)
                {
                    question4ID = 1;
                }
            }
            if (questionID == 2)
            {
                GameObject.Find("Button1").GetComponentInChildren<Text>().text = question2answer1;
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = question2answer2;
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = question2answer3;
                GameObject.Find("Button4").GetComponentInChildren<Text>().text = question2answer4;
                question.text = question2.ToString();
                if (questionNumber == 1)
                {
                    question1ID = 2;
                }
                if (questionNumber == 2)
                {
                    question2ID = 2;
                }
                if (questionNumber == 3)
                {
                    question3ID = 2;
                }
                if (questionNumber == 4)
                {
                    question4ID = 2;
                }
            }
            if (questionID == 3)
            {
                GameObject.Find("Button1").GetComponentInChildren<Text>().text = question3answer1;
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = question3answer2;
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = question3answer3;
                GameObject.Find("Button4").GetComponentInChildren<Text>().text = question3answer4;
                question.text = question3.ToString();
                if (questionNumber == 1)
                {
                    question1ID = 3;
                }
                if (questionNumber == 2)
                {
                    question2ID = 3;
                }
                if (questionNumber == 3)
                {
                    question3ID = 3;
                }
                if (questionNumber == 4)
                {
                    question4ID = 3;
                }
            }
            if (questionID == 4)
            {
                GameObject.Find("Button1").GetComponentInChildren<Text>().text = question4answer1;
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = question4answer2;
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = question4answer3;
                GameObject.Find("Button4").GetComponentInChildren<Text>().text = question4answer4;
                question.text = question4.ToString();
                if (questionNumber == 1)
                {
                    question1ID = 4;
                }
                if (questionNumber == 2)
                {
                    question2ID = 4;
                }
                if (questionNumber == 3)
                {
                    question3ID = 4;
                }
                if (questionNumber == 4)
                {
                    question4ID = 4;
                }
            }
            if (questionID == 5)
            {
                GameObject.Find("Button1").GetComponentInChildren<Text>().text = question5answer1;
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = question5answer2;
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = question5answer3;
                GameObject.Find("Button4").GetComponentInChildren<Text>().text = question5answer4;
                question.text = question5.ToString();
                if (questionNumber == 1)
                {
                    question1ID = 5;
                }
                if (questionNumber == 2)
                {
                    question2ID = 5;
                }
                if (questionNumber == 3)
                {
                    question3ID = 5;
                }
                if (questionNumber == 4)
                {
                    question4ID = 5;
                }
            }
            if (questionID == 6)
            {
                GameObject.Find("Button1").GetComponentInChildren<Text>().text = question6answer1;
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = question6answer2;
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = question6answer3;
                GameObject.Find("Button4").GetComponentInChildren<Text>().text = question6answer4;
                question.text = question6.ToString();
                if (questionNumber == 1)
                {
                    question1ID = 6;
                }
                if (questionNumber == 2)
                {
                    question2ID = 6;
                }
                if (questionNumber == 3)
                {
                    question3ID = 6;
                }
                if (questionNumber == 4)
                {
                    question4ID = 6;
                }
            }
            if (questionID == 7)
            {
                GameObject.Find("Button1").GetComponentInChildren<Text>().text = question7answer1;
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = question7answer2;
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = question7answer3;
                GameObject.Find("Button4").GetComponentInChildren<Text>().text = question7answer4;
                question.text = question7.ToString();
                if (questionNumber == 1)
                {
                    question1ID = 7;
                }
                if (questionNumber == 2)
                {
                    question2ID = 7;
                }
                if (questionNumber == 3)
                {
                    question3ID = 7;
                }
                if (questionNumber == 4)
                {
                    question4ID = 7;
                }
            }
            if (questionID == 8)
            {
                GameObject.Find("Button1").GetComponentInChildren<Text>().text = question8answer1;
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = question8answer2;
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = question8answer3;
                GameObject.Find("Button4").GetComponentInChildren<Text>().text = question8answer4;
                question.text = question8.ToString();
                if (questionNumber == 1)
                {
                    question1ID = 8;
                }
                if (questionNumber == 2)
                {
                    question2ID = 8;
                }
                if (questionNumber == 3)
                {
                    question3ID = 8;
                }
                if (questionNumber == 4)
                {
                    question4ID = 8;
                }
            }
            if (questionID == 9)
            {
                GameObject.Find("Button1").GetComponentInChildren<Text>().text = question9answer1;
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = question9answer2;
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = question9answer3;
                GameObject.Find("Button4").GetComponentInChildren<Text>().text = question9answer4;
                question.text = question9.ToString();
                if (questionNumber == 1)
                {
                    question1ID = 9;
                }
                if (questionNumber == 2)
                {
                    question2ID = 9;
                }
                if (questionNumber == 3)
                {
                    question3ID = 9;
                }
                if (questionNumber == 4)
                {
                    question4ID = 9;
                }
            }
            if (questionID == 10)
            {
                GameObject.Find("Button1").GetComponentInChildren<Text>().text = question10answer1;
                GameObject.Find("Button2").GetComponentInChildren<Text>().text = question10answer2;
                GameObject.Find("Button3").GetComponentInChildren<Text>().text = question10answer3;
                GameObject.Find("Button4").GetComponentInChildren<Text>().text = question10answer4;
                question.text = question10.ToString();
                if (questionNumber == 1)
                {
                    question1ID = 10;
                }
                if (questionNumber == 2)
                {
                    question2ID = 10;
                }
                if (questionNumber == 3)
                {
                    question3ID = 10;
                }
                if (questionNumber == 4)
                {
                    question4ID = 10;
                }
            }
        }
        
        
        
    }

    public void CheckAnswer1()
    {
        //Check if the answer in the text of the button pressed is correct
        if(GameObject.Find("Button1").GetComponentInChildren<Text>().text == correctAnswer1 || GameObject.Find("Button1").GetComponentInChildren<Text>().text == correctAnswer2 || GameObject.Find("Button1").GetComponentInChildren<Text>().text == correctAnswer3 || GameObject.Find("Button1").GetComponentInChildren<Text>().text == correctAnswer4 || GameObject.Find("Button1").GetComponentInChildren<Text>().text == correctAnswer5 || GameObject.Find("Button1").GetComponentInChildren<Text>().text == correctAnswer6 || GameObject.Find("Button1").GetComponentInChildren<Text>().text == correctAnswer7 || GameObject.Find("Button1").GetComponentInChildren<Text>().text == correctAnswer8 || GameObject.Find("Button1").GetComponentInChildren<Text>().text == correctAnswer9 || GameObject.Find("Button1").GetComponentInChildren<Text>().text == correctAnswer10)
        {
            //Increase level and question number if answer is correct and restart the process for next questions
            
            level++;
            questionNumber++;
            PlayerPrefs.SetInt("Level", level);
            Start();
        }
        else
        {
            //Increase question number only if incorrect answer and restart the process for next questions
            questionNumber++;
            Start();

        }
    }
    public void CheckAnswer2()
    {
        if (GameObject.Find("Button2").GetComponentInChildren<Text>().text == correctAnswer1 || GameObject.Find("Button2").GetComponentInChildren<Text>().text == correctAnswer2 || GameObject.Find("Button2").GetComponentInChildren<Text>().text == correctAnswer3 || GameObject.Find("Button2").GetComponentInChildren<Text>().text == correctAnswer4 || GameObject.Find("Button2").GetComponentInChildren<Text>().text == correctAnswer5 || GameObject.Find("Button2").GetComponentInChildren<Text>().text == correctAnswer6 || GameObject.Find("Button2").GetComponentInChildren<Text>().text == correctAnswer7 || GameObject.Find("Button2").GetComponentInChildren<Text>().text == correctAnswer8 || GameObject.Find("Button2").GetComponentInChildren<Text>().text == correctAnswer9 || GameObject.Find("Button2").GetComponentInChildren<Text>().text == correctAnswer10)
        {
            level++;
            questionNumber++;
            PlayerPrefs.SetInt("Level", level);
            Start();
        }
        else
        {
            questionNumber++;
            Start();

        }

    }
    public void CheckAnswer3()
    {
        if (GameObject.Find("Button3").GetComponentInChildren<Text>().text == correctAnswer1 || GameObject.Find("Button3").GetComponentInChildren<Text>().text == correctAnswer2 || GameObject.Find("Button3").GetComponentInChildren<Text>().text == correctAnswer3 || GameObject.Find("Button3").GetComponentInChildren<Text>().text == correctAnswer4 || GameObject.Find("Button3").GetComponentInChildren<Text>().text == correctAnswer5 || GameObject.Find("Button3").GetComponentInChildren<Text>().text == correctAnswer6 || GameObject.Find("Button3").GetComponentInChildren<Text>().text == correctAnswer7 || GameObject.Find("Button3").GetComponentInChildren<Text>().text == correctAnswer8 || GameObject.Find("Button3").GetComponentInChildren<Text>().text == correctAnswer9 || GameObject.Find("Button3").GetComponentInChildren<Text>().text == correctAnswer10)
        {
            level++;
            questionNumber++;
            PlayerPrefs.SetInt("Level", level);
            Start();
        }
        else
        {
            questionNumber++;
            Start();

        }
    }
    public void CheckAnswer4()
    {
        if (GameObject.Find("Button4").GetComponentInChildren<Text>().text == correctAnswer1 || GameObject.Find("Button4").GetComponentInChildren<Text>().text == correctAnswer2 || GameObject.Find("Button4").GetComponentInChildren<Text>().text == correctAnswer3 || GameObject.Find("Button4").GetComponentInChildren<Text>().text == correctAnswer4 || GameObject.Find("Button4").GetComponentInChildren<Text>().text == correctAnswer5 || GameObject.Find("Button4").GetComponentInChildren<Text>().text == correctAnswer6 || GameObject.Find("Button4").GetComponentInChildren<Text>().text == correctAnswer7 || GameObject.Find("Button4").GetComponentInChildren<Text>().text == correctAnswer8 || GameObject.Find("Button4").GetComponentInChildren<Text>().text == correctAnswer9 || GameObject.Find("Button4").GetComponentInChildren<Text>().text == correctAnswer10)
        {
            level++;
            questionNumber++;
            PlayerPrefs.SetInt("Level", level);
            Start();
        }
        else
        {
            questionNumber++;
            Start();

        }
    }


}
