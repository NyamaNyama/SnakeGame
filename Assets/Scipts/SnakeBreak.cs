using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBreak : MonoBehaviour
{
    [SerializeField] private CanvasChanger changer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        changer.Die();
    }

}
