using System;
using UnityEngine;

public class RoseCollision : MonoBehaviour
{
    public PlayerTalk playerTalk;

    private void Start()
    {
        playerTalk = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTalk>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "ROSE")
        {
            playerTalk.PlayDialogue(13);
        }
    }
}
