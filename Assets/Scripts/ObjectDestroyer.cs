using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public void DestroyAfterTime(float time)
    {
        Destroy(gameObject, time);
    }
}
