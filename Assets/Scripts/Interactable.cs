using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
   public NpcTalk npcTalk;
   public bool pickable = false;
   [HideInInspector]public Rigidbody rb;

   private void Start()
   {
      TryGetComponent(out Rigidbody rib);
      rb = rib;
   }
}
