using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretAI : MonoBehaviour
{
    public UnityEvent onDestroyed;

    private TurretTargeting _targetting;
    private TurretFiring _firing;
    private TurretRange _range;
    private int _health = 3;

    // Start is called before the first frame update
    void Start()
    {
        _targetting = GetComponent<TurretTargeting>();
        _firing = GetComponent<TurretFiring>();
        _range = GetComponent<TurretRange>();
        InvokeRepeating("TargetNearest", 0, 0.3f);
    }

    void TargetNearest()
    {
        List<GameObject> targetsInRange = _range.GetValidTargets();

        GameObject currentTarget = null;
        float nearest = 0.0f;

        for (int i = 0; i < targetsInRange.Count; i++)
        {
            float distance = (transform.position - targetsInRange[i].transform.position).sqrMagnitude;

            if (!currentTarget || distance < nearest)
            {
                currentTarget = targetsInRange[i];
                nearest = distance;
            }
        }

        _targetting.SetTarget(currentTarget);
        _firing.SetTarget(currentTarget);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster" && _health > 1)
        {
            _health--;
        }
        else
        {
            onDestroyed.Invoke();
            onDestroyed.RemoveAllListeners();
            Destroy(gameObject);
        }
    }
}
