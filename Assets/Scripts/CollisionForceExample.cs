using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollisionForceExample : MonoBehaviour
{
    Vector3 m_RandomForce;
    Vector3 m_ResetPosition;
    float m_ResetTime = 5.0f;
    float m_ResetHeight = 3.0f;
    const float k_MinForce = -500.0f;
    const float k_MaxForce = 500.0f;

    void Start()
    {
        m_ResetPosition =  new Vector3(this.transform.localPosition.x, m_ResetHeight, this.transform.localPosition.z);
    }
    
    void OnCollisionEnter(Collision other)
    {
        // write the name of the object that hit the collider to the console
        Debug.Log(other.gameObject.name+" entered the collider");
        
        Rigidbody otherRigidBody = other.transform.GetComponent<Rigidbody>();
        
        if (otherRigidBody)
        {
            m_RandomForce = CalculateRandomForce();
            otherRigidBody.AddForce(m_RandomForce);
            StartCoroutine(WaitAndReset(other.transform));
        }
    }

    Vector3 CalculateRandomForce()
    {
        return new Vector3(Random.Range(k_MinForce, k_MaxForce), Random.Range(k_MinForce, k_MaxForce), Random.Range(k_MinForce, k_MaxForce));
    }
    
    IEnumerator WaitAndReset(Transform resetObject)
    {
        yield return new WaitForSeconds(m_ResetTime);
        resetObject.localPosition = m_ResetPosition;
    }
}
