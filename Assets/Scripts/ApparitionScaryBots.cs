using System;
using UnityEngine;

public class ApparitionScaryBots : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.forward = new Vector3((player.transform.position.x - transform.position.x), 0, (player.transform.position.z - transform.position.z));
    }
}
