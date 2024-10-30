using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    public GameObject TextOff;
    public GameObject TextOn;

    
    void Start()
    {
        TextOff.SetActive(true);
        TextOn.SetActive(false);

    }
    
    void OnTriggerEnter()
    {
        TextOff.SetActive(false);
        TextOn.SetActive(true);

    }
}
