using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DragToShootScript : MonoBehaviour
{
  
    private Vector3 startPosition;
    private Vector3 releasePosition;
    private Vector3 shootDirection;
    public Vector3 BallCameraOffset = new Vector3(0f, 0f, -10f);
    public static Vector3 position;

    public float ThrowForce = 100f;
    public float ThrowDirectionX = 0.15f;
    public float ThrowDirectionY = 0.65f;

    float duration;
    float startTime;
    float endTime;
    
    Rigidbody rb;
    public GameObject ARcam;
    public ARSessionOrigin sessionOrigin;

    private bool isShoot;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sessionOrigin = GameObject.Find("AR Session Origin").GetComponent<ARSessionOrigin>();
        ARcam = sessionOrigin.transform.Find("AR Camera").gameObject;
        transform.parent = ARcam.transform;
        isShoot = false;
        SpawnBall();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            startTime = Time.time;
            isShoot = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            releasePosition = Input.mousePosition;
            endTime = Time.time;
            duration = endTime - startTime;
            shootDirection = releasePosition - startPosition;
            isShoot = true;
        }

        if(isShoot)
        {            
            rb.useGravity = true;
            Shoot();

            startTime = 0.0f;
            duration = 0.0f;
            
            startPosition = new Vector3(0, 0, 0);
            releasePosition = new Vector3(0, 0, 0);  

            isShoot = false;
            
        }        
    }
    private void FixedUpdate()
    {
        position = ARcam.transform.position;
        ARcam.transform.position = new Vector3(0, 0, 0);
    }
    void Shoot()
    {
        rb.AddForce((ARcam.transform.forward * ThrowForce/duration) + 
            (ARcam.transform.up * shootDirection.y * ThrowDirectionY) + 
            (ARcam.transform.right * shootDirection.x * ThrowDirectionX));        
    }
    
    private void SpawnBall()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(Vector3.zero);
        Vector3 ballPos = ARcam.transform.position + ARcam.transform.forward * BallCameraOffset.z
            + ARcam.transform.up * BallCameraOffset.y;
        transform.position = ballPos;        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Block"))
        {
            SpawnBall();
        }
        else
        {
            SpawnBall();
        }
    }
    
}
