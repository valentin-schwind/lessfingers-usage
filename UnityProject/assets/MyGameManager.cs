using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    CubesTask cubesTask;
    KeyboardTask keyboardTask;
    QuestionaireTask questionaireTask;

    public GameObject GuidingCanvasText;
    private string Welcome = "Welcome! \nThanks for participating in this study! \n\nUse the time to take a first look at your new hands!";
    private string Thanks = "Thank you for participating in this study. \n You can take off the Headset now.";

    //START TIME AND TIME OF TASKS IS REDUCED AND HAS TO BE REASESSED-
    //public float timeTask = 5.0f;
    //public float timeKeyboard;
    //public float timeCubes;
    public GameObject Timer;
    private int time;
    private int timeForCubes = 60;
    private int timeForKeyboard = 60;

    //if countdown gets changed also change in coroutine
    private int countDown = 30;

    private int taskCounter = 0;
    public bool tasksHaveStarted = false;
    private LatinHand latinHand;

    private IEnumerator corout;

    public void Awake()
    {
        GameObject AllTheCubes = GameObject.Find("InteractionCubes");
        GameObject AllTheKeyboard = GameObject.Find("InteractionKeyboard");
        GameObject AllTheQuestions = GameObject.Find("InteractionQuestionaire");

        cubesTask = AllTheCubes.GetComponent<CubesTask>();
        keyboardTask = AllTheKeyboard.GetComponent<KeyboardTask>();
        questionaireTask = AllTheQuestions.GetComponent<QuestionaireTask>();
        latinHand = GameObject.FindObjectOfType(typeof(LatinHand)) as LatinHand;

        GuidingCanvasText.GetComponent<TextMesh>().text = Welcome;

        cubesTask.DisableTask();
        keyboardTask.DisableTask();
        questionaireTask.DisableTask();

        corout = startCountDown();
        StartCoroutine(corout);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.N))
        {
            switch (taskCounter)
            {
                case 0:
                    taskCounter = 1;
                    questionaireTask.DisableTask();
                    cubesTask.DisableTask();
                    break;
                case 1:
                    taskCounter = 2;
                    cubesTask.DisableTask();
                    keyboardTask.DisableTask();
                    break;
                case 2:
                    taskCounter = 0;
                    questionaireTask.DisableTask();
                    keyboardTask.DisableTask();
                    break;
            }
            startTasks();
        }
    }

    private IEnumerator startCountDown()
    {
        
        while (countDown >= 0)
        {
            Timer.GetComponent<TextMesh>().text = "" + countDown;
            yield return new WaitForSeconds(1);
          

            if (countDown == 0)
            {
                startTasks();
                countDown = 30;
                yield break;
            }
            countDown--;
        }
        
    }

    private void startTasks()
    {
        Timer.SetActive(true);

        StopAllCoroutines();

        switch (taskCounter)
        {
            case 0:
                startCubes();
                break;
            case 1:
                startKeyboard();
                break;
            case 2:
                startQuestionnaire();
                break;
        }
    }

    private void startCubes()
    {
        cubesTask.EnableTask();
        time = timeForCubes;
        
        corout = CountdownC();
        StartCoroutine(corout);
    }
    private void startKeyboard()
    {
        keyboardTask.EnableTask();
        time = timeForKeyboard;

        corout = CountdownK();
        StartCoroutine(corout);
    }

    private IEnumerator CountdownC()
    {
        while (time >= 0)
        {
            Timer.GetComponent<TextMesh>().text = "" + time;
            yield return new WaitForSeconds(1);
           
            if (time == 0)
            {
                cubesTask.DisableTask();
                taskCounter++;
                startTasks();
                
                yield break;
            }
            time--;
        }
    }

    private IEnumerator CountdownK()
    {
        while (time >= 0)
        {
            Timer.GetComponent<TextMesh>().text = "" + time;
            yield return new WaitForSeconds(1);
            
            if (time == 0)
            {
                keyboardTask.DisableTask();
                taskCounter++;
                startTasks();
                yield break;
            }
            time--;
        }
    }

    private void startQuestionnaire()
    {
        StopAllCoroutines();
        questionaireTask.EnableTask();
        cubesTask.DisableTask();
        keyboardTask.DisableTask();
        Timer.SetActive(false);
    }

    public void onQuestionnaireEnd()
    {

        if (latinHand.CurrentGroup == latinHand.GroupNames.Length - 1)
        {
            GuidingCanvasText.GetComponent<TextMesh>().text = Thanks;
        }
        else
        {
            if (questionaireTask.questionsDisabled)
            {
                latinHand.nextHandModel();
            }

            GuidingCanvasText.GetComponent<TextMesh>().text = "Now you are using another set of hands.\n\nUse the time to take a first look at your new hands!";
            Timer.SetActive(true);

            cubesTask.DisableTask();
            keyboardTask.DisableTask();

            corout = startCountDown();
            taskCounter = 0;
            StartCoroutine(corout);
        }
    }

    private void OnApplicationQuit()
    {
        keyboardTask.CloseKeyboard();
        cubesTask.CloseCubes();
        questionaireTask.CloseQuestionnaire();
    }
}
