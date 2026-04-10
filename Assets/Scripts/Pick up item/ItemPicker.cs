
using System;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    [HideInInspector]public Rigidbody pickedItem;
    public float grabDistance;
    public float moveForce=1.5f;
    public Transform cameraTransform;
    [SerializeField] private GameObject scaryBots;
    [SerializeField] private GameObject trees;

    private bool dropBuffer = false;


    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            dropBuffer = true;
        }
    }

    private void FixedUpdate()
    {
        if(!pickedItem)return;

        if (dropBuffer)
        {
            Drop();
            dropBuffer = false;
            return;
        }
        
        Vector3 pickeItemPosition = transform.position + (cameraTransform.TransformDirection(Vector3.forward) * grabDistance);
        Vector3 forceVector = (pickeItemPosition - pickedItem.position)*moveForce;
        pickedItem.linearVelocity = forceVector;
    }

    public void PickUp(Rigidbody rb)
    {
        pickedItem = rb;
        pickedItem.useGravity = false;
        if (pickedItem.gameObject.name == "ROSE")
        {
            scaryBots.SetActive(true);
            trees.SetActive(false);
        }
    }

    public void Drop()
    {
        if(!pickedItem)return;
        pickedItem.useGravity = true;
        
        pickedItem = null;
    }
}
