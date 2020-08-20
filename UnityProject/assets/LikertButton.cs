using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LikertButton : MonoBehaviour
{
    public GameObject LikertNegThree;
    public GameObject LikertNegTwo;
    public GameObject LikertNegOne;
    public GameObject LikertZero;
    public GameObject LikertPosOne;
    public GameObject LikertPosTwo;
    public GameObject LikertPosThree;

    FingerCollision fingerCollisionNegThree;
    FingerCollision fingerCollisionNegTwo;
    FingerCollision fingerCollisionNegOne;
    FingerCollision fingerCollisionZero;
    FingerCollision fingerCollisionPosOne;
    FingerCollision fingerCollisionPosTwo;
    FingerCollision fingerCollisionPosThree;

    private GameObject[] likert = new GameObject[7];
    private FingerCollision[] fingerCollisions = new FingerCollision[7];

    private QuestionaireTask questTask;
    private LatinHand latinHand;
    public IPQ ipq;

    private void Start()
    {
        questTask = GameObject.FindObjectOfType(typeof(QuestionaireTask)) as QuestionaireTask;
        latinHand = GameObject.FindObjectOfType(typeof(LatinHand)) as LatinHand;
    }

    private void Awake()
    {
        FingerCollision.collisionEventPassed += this.onTriggerExit;

        fingerCollisionNegThree = LikertNegThree.GetComponent<FingerCollision>();
        fingerCollisionNegTwo = LikertNegTwo.GetComponent<FingerCollision>();
        fingerCollisionNegOne = LikertNegOne.GetComponent<FingerCollision>();
        fingerCollisionZero = LikertZero.GetComponent<FingerCollision>();
        fingerCollisionPosOne = LikertPosOne.GetComponent<FingerCollision>();
        fingerCollisionPosTwo = LikertPosTwo.GetComponent<FingerCollision>();
        fingerCollisionPosThree = LikertPosThree.GetComponent<FingerCollision>();
    }

    public void onTriggerExit(Collider fingerCollider, FingerCollision objectCollider)
    {
        if (objectCollider.name.Contains("Button"))
        {
            questTask.swQestT.WriteLine(latinHand.Participant + ";" +latinHand.CurrentGroup + ";" +latinHand.GroupNames[latinHand.CurrentGroup].ToString() + ";" +
                questTask.qtime.ElapsedMilliseconds + ";" + fingerCollider.ToString() + ";" +objectCollider.ToString() + ";" + ipq.getCurrentQuestion());
        }
    }
}
