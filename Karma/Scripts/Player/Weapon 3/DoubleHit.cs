using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleHit : MonoBehaviour
{
    public Transform[] hitPoints;
    public GameObject prefab;
    public WeaponStats WS;

    private double fireSpeed;
    private double tmp;

    void Update()
    {
        fireSpeed = WS.fireRate;

        if (tmp >= fireSpeed)
        {
            Hit();

            tmp = 0;
        } else {
            tmp++;
        }
    }

    private void Hit ()
    {
        for (int i = 0; i <= 1; i++)
        {
            GameObject hit = Instantiate(prefab, hitPoints[i].position, hitPoints[i].rotation);
        }
    }
}