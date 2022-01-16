using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasPointer : MonoBehaviour
{
    public float defaultLength = 1000f;

    public EventSystem eventSystem;
    public StandaloneInputModule inputModule;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateLength();
    }

    private void UpdateLength()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, GetEnd());
    }

    private Vector3 GetEnd()
    {
        float distance = GetCanvasDistance();
        Vector3 endPosition = CalculateEnd(defaultLength);

        if(distance != 0.0f)
        {
            endPosition = CalculateEnd(distance);
        }

        return endPosition;
    }

    private float GetCanvasDistance()
    {
        //get data
        PointerEventData eventData = new PointerEventData(eventSystem);
        //eventData.position = inputModule.inputOverride.mousePosition;

        //raycast w data
        List<RaycastResult> results = new List<RaycastResult>();
        eventSystem.RaycastAll(eventData, results);

        //get closest
        RaycastResult closestResult = FindFirstRayCast(results); 
        float distance = closestResult.distance;

        //clamp
        distance = Mathf.Clamp(distance, 0.0f, defaultLength);
        return distance;
    }

    private RaycastResult FindFirstRayCast(List<RaycastResult> results)
    {
        foreach (RaycastResult result in results)
        {
            if (!result.gameObject)
                continue;

            return result;
        }

        return new RaycastResult();
    }

    private Vector3 CalculateEnd(float lenght)
    {
        return transform.position + (transform.forward * lenght);
    }    
}
