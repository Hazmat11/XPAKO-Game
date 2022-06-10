using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{
    public GameObject[] actives;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("i");
            GameObject active = Instantiate(actives[0], gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
