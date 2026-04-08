using UnityEngine;

public class RaycastAim : MonoBehaviour
{
    [HideInInspector]
    public bool lookingAtNPC = false;

    public PlayerTalk talk;
    
    void Update()
    {
        Ray ray;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            
            if (hit.collider.CompareTag("Npc"))
            {
                lookingAtNPC = true;
                if (!talk.isInConversation&&Input.GetKeyDown(KeyCode.E))
                {
                    NpcTalk npc = hit.collider.GetComponent<NpcTalk>();
                    talk.StartConversation(npc);
                }
            }
            else
            {
                lookingAtNPC = false;
            }
        }
        else
        {
            lookingAtNPC = false;
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.red);
    }
}
