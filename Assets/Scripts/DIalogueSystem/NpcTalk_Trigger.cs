using System;
using UnityEngine;

public class NpcTalk_Trigger : NpcTalk
{
    private bool once = false;
    public float timeToRetriger = -1;
    private float timeToRetrigerA = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (!once&&other.TryGetComponent(out PlayerTalk pT))
        {
            once = true;
            pT.StartConversation(this);
        }

       
    }
    

    private void OnCollisionEnter(Collision other)
    {
        if (!once&&other.gameObject.TryGetComponent(out PlayerTalk pT))
        {
            once = true;
            pT.StartConversation(this);
        }

    }
}
