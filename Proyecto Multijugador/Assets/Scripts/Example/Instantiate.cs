using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject gun;
    public GameObject objectDad;
    Vector3 spawn;

    public void GunInsta()
    {
        spawn = transform.position + new Vector3(0.139f, -0.033f, 0);
        GameObject gunCom = Instantiate(gun, spawn, Quaternion.identity) as GameObject;
        gunCom.transform.parent = objectDad.transform;
        gunCom.transform.position = spawn;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GunInsta();
        }
    }


}
