using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollisionExample : MonoBehaviour
{
    float m_ResetHeight = 3.0f;
    float m_ResetTime = 5.0f;
    Vector3 m_ResetPosition;

    void Start()
    {
        m_ResetPosition = new Vector3(this.transform.localPosition.x, m_ResetHeight, this.transform.localPosition.z);
    }
    void OnTriggerEnter(Collider other)
    {
        // write the name of the object that entered the trigger to the console
        Debug.Log(other.name +" entered the trigger");
        
        // reposition the object that entered the trigger to be above the trigger after a reset time has passed
        StartCoroutine((WaitAndReset(other.transform)));
    }

    IEnumerator WaitAndReset(Transform resetObject)
    {
        yield return new WaitForSeconds(m_ResetTime);
        resetObject.localPosition = m_ResetPosition;
    }
}
