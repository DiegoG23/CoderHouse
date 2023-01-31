using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Vectores
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] protected int health = 5;
        [SerializeField] protected int damage = 1;
    }
}