using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    [SerializeField] [Range(0f,10f)] float moveDelay = 1f;

    void Start()
    {
        StartCoroutine(FindPath());
    }

    IEnumerator FindPath()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(moveDelay);
        }
    }
}
