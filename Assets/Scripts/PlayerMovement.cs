using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float rotationSpeed;
    private Camera mainCamera;
    private Rigidbody rb;
    private Vector3 movementDirection;
    void Start()
    {
        if(PlayerPrefs.GetInt(Store.upgradeShipId,0)==1){
            
            GetComponentInChildren<MeshRenderer>().material=Resources.Load(
                "Starsparrow_Green",typeof(Material)) as Material;
        }
        
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        
    }

    void Update()
    {
        ProcessInput();
        KeepPlayerOnScreen();
        RotateToFaceVelocity();
    }

    private void FixedUpdate()
    {
        if (movementDirection == Vector3.zero)
        {
            return;
        }
        rb.AddForce(movementDirection * forceMagnitude * Time.deltaTime, ForceMode.Force);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }

    void ProcessInput(){

        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            movementDirection = transform.position - worldPosition;

            movementDirection.z = 0f;
            movementDirection.Normalize();

        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }

    private void KeepPlayerOnScreen(){
        
        Vector3 newPosition = transform.position;
        Vector3 viewportPost = mainCamera.WorldToViewportPoint(transform.position);
        if(viewportPost.x>1){
            newPosition.x=-newPosition.x+0.1f;
        }else if(viewportPost.x<0){
            newPosition.x=-newPosition.x - 0.1f;
        }

         if(viewportPost.y>1){
            newPosition.y=-newPosition.y+0.1f;
        }else if(viewportPost.y<0){
            newPosition.y=-newPosition.y - 0.1f;
        }
        transform.position=newPosition;
    }

    private void  RotateToFaceVelocity(){
        if(rb.velocity==Vector3.zero){return;}
         Quaternion targetRotation = Quaternion.LookRotation(rb.velocity,Vector3.back);
         transform.rotation = Quaternion.Lerp(
            transform.rotation,targetRotation,rotationSpeed*Time.deltaTime);
    }
}
