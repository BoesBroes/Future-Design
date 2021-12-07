using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionEnabled : MonoBehaviour
{
    private bool emissionEnabled = false;
    public float emissionChange;

    public void changeEmission()
    {
        if(emissionEnabled)
        {
            emissionEnabled = false;
            TimeLine.timeLine.emission -= emissionChange;
            TimeLine.timeLine.ValueChangeCheck();
        }
        else
        {
            emissionEnabled = true;
            TimeLine.timeLine.emission += emissionChange;
            TimeLine.timeLine.ValueChangeCheck();
        }
    }
}
