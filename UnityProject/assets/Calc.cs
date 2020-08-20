using UnityEngine;
using Leap.Unity.Interaction;

public class Calc : MonoBehaviour
{
    public static float pain;
    public InteractionSlider slider;

    private void OnTriggerExit(Collider other)
    {
        pain = slider.HorizontalSliderValue;
    }
}