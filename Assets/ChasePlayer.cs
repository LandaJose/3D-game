using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    private NavMeshAgent crawler;
    public GameObject Player;
    public float crawlerDistanceRun = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        crawler = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance < crawlerDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPosition = transform.position - dirToPlayer;
            crawler.SetDestination(newPosition);
        }
    }
}
