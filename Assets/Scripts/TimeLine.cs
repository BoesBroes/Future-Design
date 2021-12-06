using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeLine : MonoBehaviour
{
    public GameObject water;
    private Slider slider;

    public float waterChangeVar = 50;
    public float waterEffectsVarX = 100;
    public float waterEffectsVarY = 100;

    //TODO: check on weather effects

    // Start is called before the first frame update
    void Start()
    {
        //set some stuff
        slider = this.GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Update is called once per frame
    public void ValueChangeCheck()
    {
        //change some stuff!
        water.transform.position = new Vector3(water.transform.position.x, 50 + (slider.value * waterChangeVar), water.transform.position.z);
        water.GetComponent<NVWaterShaders>().rotateSpeed = new Vector2(1 + (slider.value * waterEffectsVarX), 1 + (slider.value * waterEffectsVarY));
        water.GetComponent<NVWaterShaders>().rotateDistance = new Vector2(1 + (slider.value * waterEffectsVarX), 1 + (slider.value * waterEffectsVarY));
    }

}
