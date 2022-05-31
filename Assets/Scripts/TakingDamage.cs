using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("hit taken");
    }
}
