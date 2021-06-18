using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRange : MonoBehaviour
{
    [SerializeField] private List<string> targetedTags = null;

    private List<GameObject> _targets = new List<GameObject>();


    private void Update()
    {
        for (int i = 0; i < _targets.Count; i++)
        {
            if (_targets[i] == null)
            {
                _targets.Remove(_targets[i]);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        bool notAValidTarget = true;

        for (int i = 0; i < targetedTags.Count; i++)
        {
            if (other.CompareTag(targetedTags[i]))
            {
                notAValidTarget = false;
                break;
            }
        }

        if (notAValidTarget) { return; }

        _targets.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < _targets.Count; i++)
        {
            if (other.gameObject == _targets[i])
            {
                _targets.Remove(other.gameObject);
                break;
            }
        }
    }

    public List<GameObject> GetValidTargets()
    {
        return _targets;
    }
}
