using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class VRInput : BaseInput
{

    XRController controller;
    public Camera eventCamera;

    public static UnityEvent OnGripPressed = new UnityEvent();

    


    //public unityev

    protected override void Start()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);

        Debug.Log(" lol");

        foreach(var device in inputDevices)
        {
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.characteristics.ToString()));
        }
    }

    //public override bool GetMouseButton(int button)
    //{
    //    //return XR.Input.Common
    //    //      return InputSystem.GetDevice<XRController>()(UnityEngine.XR.CommonUsages.primary2DAxisClick);
    //    //return (UnityEngine.XR.CommonUsages.primary2DAxisClick);

    //}
}
