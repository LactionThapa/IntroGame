using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public GameObject[] pickups;
    public GameObject nearestPickUp;
    public GameObject previousNearestPickUp;
    public TextMeshProUGUI Distance;
    float distance;
    float nearestDistance = 100000;
    
    void Start()
    {
        pickups = GameObject.FindGameObjectsWithTag("PickUp");

        lineRenderer = gameObject.AddComponent<LineRenderer>();

        lineRenderer.SetPosition(0, transform.position);
        for (int i = 0; i < pickups.Length; i++)
        {
            distance = Vector3.Distance(transform.position, pickups[i].transform.position);

            if(distance < nearestDistance)
            {
                nearestPickUp = pickups[i];
                nearestDistance = distance;
            }
            
        }
        Vector3 endPosition = nearestPickUp.transform.position;
        lineRenderer.SetPosition(1, endPosition);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        nearestPickUp.GetComponent<Renderer>().material.color = Color.blue;
    }

    private void Update()
    {
        Distance.text = (Vector3.Distance(transform.position, nearestPickUp.transform.position)).ToString();
        previousNearestPickUp = nearestPickUp;
        if((distance = Vector3.Distance(transform.position, nearestPickUp.transform.position)) > 0.5f)
        {
            nearestPickUp.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            nearestPickUp.GetComponent<Renderer>().material.color = Color.white;
        }
        pickups = GameObject.FindGameObjectsWithTag("PickUp");

        for (int i = 0; i < pickups.Length; i++)
        {
            distance = Vector3.Distance(transform.position, pickups[i].transform.position);

            if (distance < nearestDistance)
            {
                nearestPickUp = pickups[i];
                nearestDistance = distance;
            }

        }
        nearestDistance = 100000;
        Vector3 endPosition = nearestPickUp.transform.position;
        lineRenderer.SetPosition(1, endPosition);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        if (previousNearestPickUp == nearestPickUp)
        {
            nearestPickUp.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            previousNearestPickUp.GetComponent<Renderer>().material.color= Color.white;
        }
        lineRenderer.SetPosition(0, transform.position);
    }


   

   
}
