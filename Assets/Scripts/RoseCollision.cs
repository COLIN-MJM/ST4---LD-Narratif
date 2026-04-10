using System;
using Unity.VisualScripting;
using UnityEngine;

public class RoseCollision : NpcTalk
{
    public PlayerTalk playerTalk;

    private bool once = false;
    public float timeToRetriger = -1;
    private float timeToRetrigerA = 0;

    protected override void Start()
    {
        base.Start();
        playerTalk = FindObjectOfType<PlayerTalk>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!once && other.gameObject.name == "ROSE")
        {
            Debug.Log(other.gameObject.name );
            once = true;
            playerTalk.StartConversation(this);
        }

       
    }
}
