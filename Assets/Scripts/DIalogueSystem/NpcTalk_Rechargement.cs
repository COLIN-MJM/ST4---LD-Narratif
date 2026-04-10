using UnityEngine;

public class NpcTalk_Rechargement : NpcTalk
{
    public Collider myCollider;
    public override int TalkTo(int choice = 0)
    {
        myCollider.enabled = false;
        return base.TalkTo(choice);
        
    }
}
