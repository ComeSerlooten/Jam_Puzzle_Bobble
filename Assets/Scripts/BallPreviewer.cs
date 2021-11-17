using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPreviewer : MonoBehaviour
{
    [SerializeField] GameObject[] Prefabs;
    public GameObject nextBall;
    [HideInInspector] public GameObject activeball;

    int counter = 0;


    void Start()
    {
        nextBall = GetRandomBall();
        Vector3 instanceStartPos = transform.position;
        instanceStartPos.z -= 0.5f;
        activeball = Instantiate(nextBall, instanceStartPos, Quaternion.identity);

        for (int i = 0; i<1000; i++)
        {
            activeball.transform.position += Vector3.right * 0.001f;
        }

        GlobalVar.Reloading = false;
    }

  

    void Update()
    {
        if(GlobalVar.Reloading)
        {
            activeball.transform.position = Vector3.Lerp(activeball.transform.position, activeball.transform.position + 0.1f * Vector3.right, 1f);
            counter++;
        }
        else
        {
            counter = 0;
        }

        if (counter>= 10)
        {
            GlobalVar.Reloading = false;
        }

    }

    public GameObject GetRandomBall()
    {
        GameObject rand = Prefabs[Random.Range(0, Prefabs.Length)];
        return rand;
    }

    public void ballFired()
    {
        GlobalVar.Reloading = true;
        Destroy(activeball); 

        nextBall = GetRandomBall();
        Vector3 instanceStartPos = transform.position;
        instanceStartPos.z -= 0.5f;
        activeball = Instantiate(nextBall, instanceStartPos, Quaternion.identity);
    }
}
