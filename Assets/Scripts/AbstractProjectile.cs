using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AbstractProjectile : MonoBehaviour
{
    [SerializeField] protected float speed;

    protected GameObject launcher;
    protected GameObject target;
    protected string targetTag;

    public abstract void FireProjectile(GameObject launcher, GameObject target, float attackSpeed);
}
