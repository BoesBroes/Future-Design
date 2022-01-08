using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class TimeLine : MonoBehaviour
{
    public static TimeLine timeLine;

    public GameObject water;
    public GameObject buttonParent;
    private GameObject[] button;

    private Slider slider;

    public float waterChangeVar = 50;
    public float waterEffectsVarX = 100;
    public float waterEffectsVarY = 100;
    private float baseWaterLevel;

<<<<<<< HEAD
    public Material skyboxMaterial;
    public Material skyboxMaterial2;

    //TODO: check on weather effects
    //- 
=======
    public float emission = 1f;
    //TODO: check on other weather effects
>>>>>>> f7f39fd114a42f8b2d12196bc6a7b6c208feea5f

    // Start is called before the first frame update
    void Start()
    {
        //set some stuff
        if (timeLine == null)
        {
            timeLine = this;
        }
        slider = this.GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
<<<<<<< HEAD
       
        RenderSettings.skybox = skyboxMaterial;
        RenderSettings.skybox = skyboxMaterial2;


=======

        baseWaterLevel = water.transform.position.y;

        button = new GameObject[buttonParent.transform.childCount]; 
        for(int i = 0; i < button.Length; i++)
        {
            button[i] = buttonParent.transform.GetChild(i).gameObject;
            button[i].GetComponent<Button>().onClick.Invoke();
        }
>>>>>>> f7f39fd114a42f8b2d12196bc6a7b6c208feea5f
    }

    // Update is called once per frame
    public void ValueChangeCheck()
    {
        //change some stuff! 
        water.transform.position = new Vector3(water.transform.position.x, baseWaterLevel + Mathf.Pow(slider.value * waterChangeVar, emission), water.transform.position.z);
        water.GetComponent<NVWaterShaders>().rotateSpeed = new Vector2(1 + (slider.value * waterEffectsVarX), 1 + (slider.value * waterEffectsVarY));
        water.GetComponent<NVWaterShaders>().rotateDistance = new Vector2(1 + (slider.value * waterEffectsVarX), 1 + (slider.value * waterEffectsVarY));
        skyboxMaterial.SetColor("_EmissionColor", skyboxMaterial2.color);
   
    }

    public void ChangeEmission(GameObject thisObject)
    {
        thisObject.GetComponent<EmissionEnabled>().changeEmission();
        Debug.Log(emission);
    }

}
