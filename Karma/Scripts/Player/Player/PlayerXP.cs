using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int XPs;

    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "XP")
        {
            GameObject EXP = collisionInfo.gameObject;
            XP xp = EXP.GetComponent<XP>();
            XPs += xp.value;
        }
    }
}
