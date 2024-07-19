using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EatFood : MonoBehaviour
{
    public static event UnityAction instance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        instance.Invoke();
    }

}
