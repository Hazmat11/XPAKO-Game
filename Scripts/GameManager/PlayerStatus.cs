using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public GameObject player;
    Player p;

    public int countS;
    public float coefSpeed;
    public int countSW;
    public int countD;
    public int level;
    public int hp;
    public bool dead;

    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;

    public GameObject passif1;
    public GameObject passif2;
    public GameObject passif3;
    public GameObject passif4;

    public GameObject actif;

    void Start ()
    {
        p = player.GetComponent<Player>();
    }

    public void UpBonusSpeed ()
    {
        p.PlayerSpeed += p.PlayerSpeed * (countS * coefSpeed);
    }
}
