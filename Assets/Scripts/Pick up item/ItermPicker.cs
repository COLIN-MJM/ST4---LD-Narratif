
using System;
using UnityEngine;

public class ItermPicker : MonoBehaviour
{
    [HideInInspector]public Rigidbody pickedItem;
    public float grabDistance;
    public float moveForce=1.5f;
    public Transform cameraTransform;

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
    }

    public void Drop()
    {
        if(!pickedItem)return;
        pickedItem.useGravity = true;
        
        pickedItem = null;
    }
}
