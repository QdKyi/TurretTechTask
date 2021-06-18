using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    private float _speed = 2.5f;
    private GameObject _target;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("Turret") != null)
        {
            _target = GameObject.FindWithTag("Turret");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_target)
        {
            transform.LookAt(_target.transform);

            transform.position += transform.forward * Time.deltaTime * _speed;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Turret")
        {
            Destroy(gameObject);
        }
    }
}
