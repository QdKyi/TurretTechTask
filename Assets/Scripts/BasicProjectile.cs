using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : AbstractProjectile
{
    private Vector3 _direction;
    private bool _fired;

    void Update()
    {
        if (_fired)
        {
            transform.position += _direction * (speed * Time.deltaTime);
        }
    }

    public override void FireProjectile(GameObject _launcher, GameObject _target, float attackSpeed)
    {
        if (_launcher && _target)
        {
            _direction = (_target.transform.position - _launcher.transform.position).normalized;
            _fired = true;
            launcher = _launcher;
            target = _target;
            targetTag = target.tag;

            // prevent projectiles to endlessly fly in some direction
            Destroy(gameObject, 2.0f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == targetTag)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
