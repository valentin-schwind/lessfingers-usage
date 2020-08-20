using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class QuestionaireTask : MonoBehaviour
{
    public GameObject GuidingCanvasText;
    public GameObject Questionaire;
    public GameObject ContButton;
    private contbutton script;
    private Calc calc;
    private StreamWriter swquestionaire;
    public StreamWriter swQestT;
    public bool questionsDisabled = true;
    private LatinHand latinHand;
    private string QuestionaireInstruction = "Please select the option you feel is most fitting!";
    public Stopwatch qtime = new Stopwatch();
    public IPQ ipq;
    private int questionnaireIndex = 0; 
    private String path;
    public String pathQuestT;

    private bool hasStarted = false;

    public void EnableTask()
    {
        hasStarted = true;
        questionsDisabled = false;

        script = GameObject.FindObjectOfType(typeof(contbutton)) as contbutton;
        calc = GameObject.FindObjectOfType(typeof(Calc)) as Calc;

        ipq.setLQ(false);
        Questionaire.SetActive(true);
        ContButton.SetActive(true);

        GuidingCanvasText.GetComponent<TextMesh>().text = QuestionaireInstruction;
        qtime.Reset();
    }

    private void Awake()
    {
        latinHand = GameObject.FindObjectOfType(typeof(LatinHand)) as LatinHand;
        path = "C:\\Users\\GEVAKUB\\Documents\\Quest\\" + latinHand.Participant + "_" + DateTime.Now.Ticks + "_" + "Questionaire.txt";
        pathQuestT = "C:\\Users\\GEVAKUB\\Documents\\QTask\\" + latinHand.Participant + "_" + DateTime.Now.Ticks + "_" + "QuestionaireTask.txt";
        swquestionaire = new StreamWriter(path);
        swQestT = new StreamWriter(pathQuestT);
        swquestionaire.WriteLine("subjectid;hands;handname;item;value;timeStamp");
        swQestT.WriteLine("subjectid;hands;handname;timestamp;finger;object;ipq");

        contbutton.collisionEventPassed += this.onTriggerExit;
    }

    private void Update()
    {
        qtime.Start();
    }

    public void DisableTask()
    {
        questionsDisabled = true;
        Questionaire.SetActive(false);
        ContButton.SetActive(false);
        MyGameManager gm = GameObject.FindObjectOfType(typeof(MyGameManager)) as MyGameManager;
        if (hasStarted)
        {
            hasStarted = false;
            gm.onQuestionnaireEnd();
        }
    }

    public void onTriggerExit(Collider fingerCollider, contbutton objectCollider)
    {
            if (ipq.getCurrentQuestion() == 0)
            {
                swquestionaire.WriteLine(latinHand.Participant + ";" + latinHand.CurrentGroup + ";" + latinHand.GroupNames[latinHand.CurrentGroup].ToString() +
                    ";Pain;" + Calc.pain + ";" + contbutton.timeStampQ);
            }
            else
            {
                swquestionaire.WriteLine(latinHand.Participant + ";" + latinHand.CurrentGroup + ";" + latinHand.GroupNames[latinHand.CurrentGroup].ToString() +
                    ";" + ipq.getCurrentQuestion() + ";" + contbutton.selected + ";" + contbutton.timeStampQ);
                questionnaireIndex++;
            }

            if (questionnaireIndex == 14)
            {
                questionnaireIndex = 0;
                DisableTask();
            }

        if (objectCollider.name.Contains("Button"))
        {
            swQestT.WriteLine(latinHand.Participant + ";" +latinHand.CurrentGroup + ";" +latinHand.GroupNames[latinHand.CurrentGroup].ToString() + ";" +
                qtime.ElapsedMilliseconds + ";" + fingerCollider.ToString() + ";" +objectCollider.ToString() + ";" + ipq.getCurrentQuestion());
        }
    }

    public void CloseQuestionnaire()
    {
        swquestionaire.Close();
        swQestT.Close();
        swquestionaire.Dispose();
        swQestT.Dispose();
    }
}
