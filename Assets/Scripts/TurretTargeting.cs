using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    public float speed;

    private GameObject m_target;
    private Vector3 m_lastKnownPosition;
    private Quaternion m_lookAtRotation;

    // Update is called once per frame
    void Update()
    {
        if (m_target)
        {
            if (m_lastKnownPosition != m_target.transform.position)
            {
                m_lastKnownPosition = m_target.transform.position;
                m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position);
            }

            if (transform.rotation != m_lookAtRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookAtRotation, speed * Time.deltaTime);
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        m_target = target;
    }
}
