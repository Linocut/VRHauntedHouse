using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CandleSpawn : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject candle;
    public Transform destination;
    public bool summon = false;
    public float interval = 1.5f;
    public float candleOffset = .5f;

    float timePassed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (summon)
        {
            timePassed += Time.deltaTime;
            if (timePassed >= interval)
            {
                timePassed = 0f;
                GameObject summon = Instantiate(candle, transform.position + Vector3.up * candleOffset, Quaternion.identity);
            }
        }
    }

    public void ShowPath()
    {
        summon = true;
        agent.SetDestination(destination.position);
    }
}
