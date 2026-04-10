using UnityEngine;

public class RaycastAim : MonoBehaviour
{
    [HideInInspector]
    public bool lookingAtNPC = false;

    public float raycastDistance = 3;

    public PlayerTalk talk;
    public ItemPicker pick;
    
    void Update()
    {
        Ray ray;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit,raycastDistance))
        {
            if (!hit.collider.CompareTag("Interactable")||!hit.collider.TryGetComponent(out Interactable interactable))return;
            
            
            if (interactable.npcTalk)
            {
                lookingAtNPC = true;
                if (!talk.isInConversation&&Input.GetKeyDown(KeyCode.E))
                {
                    talk.StartConversation(interactable.npcTalk);
                }
            }
            else
            {
                lookingAtNPC = false;
            }

            if (interactable.pickable&&interactable.rb&&!pick.pickedItem && Input.GetMouseButtonDown(0))
            {
                pick.PickUp(interactable.rb);
            }
            
        }
        else
        {
            lookingAtNPC = false;
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.red);
    }
}
