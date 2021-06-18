using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFiring : MonoBehaviour
{
    [SerializeField] private float fireRate = 0f;
    [SerializeField] private float fieldOfView = 0f;
    [SerializeField] private GameObject projectile = null;
    [SerializeField] private List<GameObject> projectileSpawns = null;

    private List<GameObject> _lastProjectiles = new List<GameObject>();
    private float _fireTimer = 0.0f;
    private GameObject _target;

    // Update is called once per frame
    void Update()
    {
        _fireTimer += Time.deltaTime;

        if (_target && _fireTimer >= fireRate)
        {
            float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(_target.transform.position - transform.position));

            if (angle < fieldOfView)
            {
                SpawnProjectiles();
                _fireTimer = 0.0f;
            }
        }
    }

    void SpawnProjectiles()
    {
        if (!projectile)
        {
            return;
        }

        _lastProjectiles.Clear();

        for (int i = 0; i < projectileSpawns.Count; i++)
        {
            if (projectileSpawns[i])
            {
                GameObject proj = Instantiate(projectile, projectileSpawns[i].transform.position, Quaternion.Euler(projectileSpawns[i].transform.forward));
                proj.GetComponent<AbstractProjectile>().FireProjectile(projectileSpawns[i], _target, fireRate);

                _lastProjectiles.Add(proj);
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }
}
