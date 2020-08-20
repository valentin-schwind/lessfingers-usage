using UnityEngine;
using System.Collections;
using Leap.Unity.Interaction;

public class IPQ : MonoBehaviour
{
    public GameObject text;
    public GameObject leftLikert;
    public GameObject rightLikert;
    public GameObject likertNumbers;

    public GameObject button;
    public GameObject slider;

    public static float originalPosition;
    public InteractionSlider vasSlider;

    private int currentQuestion = 0;
    private GameObject[] texts = new GameObject[3];
    private bool lastQuestion;

    //in this array are 16 elements including the vas and the final statement
    private string[,] questionnaire =  {{"Visual Analog Scale\n Please rate your pain related to your \nhand.\n", "No pain", "Worst \npossible pain"},
                                    {"How aware were you of the real world \nsurrounding while navigating in the \nvirtual world? (i.e. sounds, room \ntemperature, other people, etc.)?", "extremely \naware", "not aware \nat all"},
                                    {"How real did the virtual world seem \nto you?\n", "completely \nreal", "not real \nat all" },
                                    {"I had a sense of acting in the \nvirtual space, rather than operating \nsomething from outside.", "fully \ndisagree", "fully \nagree"},
                                    {"How much did your experience in the \nvirtual environment seem consistent \nwith your real world \nexperience ?", "not \nconsistent", "very \nconsistent"},
                                    {"How real did the virtual world seem \nto you?\n", "about as \nreal as an \nimagined world", "indistinguish-\nable from the \nreal world"},
                                    {"I did not feel present in the virtual \nspace.\n", "did not \nfeel", "felt \npresent"},
                                    {"I was not aware of my real environment.\n\n", "fully \ndisagree", "fully \nagree"},
                                    {"In the computer generated world I \nhad a sense of \"being there\".\n", "not at \nall", "very \nmuch"},
                                    {"Somehow I felt that the virtual world \nsurrounded me.\n", "fully \ndisagree", "fully \nagree"},
                                    {"I felt present in the virtual space.\n\n", "fully \ndisagree", "fully \nagree"},
                                    {"I still paid attention to the real \nenvironment.\n", "fully \ndisagree", "fully \nagree"},
                                    {"The virtual world seemed more realistic \nthan the real world.", "fully \ndisagree", "fully \nagree"},
                                    {"I felt like I was just perceiving pictures.\n\n", "fully \ndisagree", "fully \nagree"},
                                    {"I was completely captivated by the \nvirtual world.\n", "fully \ndisagree", "fully \nagree"},
                                    {"Your are done with this questionaire. \nThe study will continue in a few seconds!", "", ""}};

    

    void Start()
    {
        originalPosition = vasSlider.HorizontalSliderValue;

        texts[0] = text;
        texts[1] = leftLikert;
        texts[2] = rightLikert;

        lastQuestion = false;

        button.SetActive(false);
        likertNumbers.SetActive(false);
        
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].GetComponent<TextMesh>().text = questionnaire[currentQuestion, i];
        }
    }

    public void OnContinueButtonPress()
    {
        currentQuestion++;

        if(currentQuestion == 1)
        {
            slider.SetActive(false);
            button.SetActive(true);
            likertNumbers.SetActive(true);
        }
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].GetComponent<TextMesh>().text = questionnaire[currentQuestion, i];
        }
        if (currentQuestion == 15)
        {
            setIPQ(false);
            lastQuestion = true;
            slider.SetActive(true);

            vasSlider.HorizontalSliderValue = originalPosition;
            currentQuestion = 0;

            leftLikert.SetActive(true);
            rightLikert.SetActive(true);
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].GetComponent<TextMesh>().text = questionnaire[currentQuestion, i];
            }
        }
    }

    public void setLQ (bool status)
    {
        lastQuestion = status;
    }

    private void setIPQ(bool set)
    {
        button.SetActive(set);
        likertNumbers.SetActive(set);
    }

    public bool getLQ()
    {
        return lastQuestion;
    }

    public int getCurrentQuestion()
    {
        return currentQuestion;
    }
}
