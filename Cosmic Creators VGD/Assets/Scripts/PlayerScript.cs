using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Components")]
    public PlayerInputScript PlayerInputScript;
    private Rigidbody rb;
    [Header("Movement")]
    private float maxSpeed = 1;
    private float forceModifier = 15;
    [Header("Jumping")]
    public float jumpingForce = 20;
    private float jumpingForceModifier = .2f;
    private float jumpingMaxSpeedModifier = 1.1f;
    private float groundCheckLength = 1.05f;
    private float jumpTimer = 0f;
    private float jumpDelay = .1f;
    private bool jump;
    [Header("Physics")]
    private float upwardsForce = 10f;
    private float currentTime = 0f;
    private float onGroundTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        jump = PlayerInputScript.Jump;
        if ((jump))
        {
            jumpTimer = currentTime + jumpDelay;
        }
    }
    void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;
        HandleXZMovement();
        bool onGround = OnGround();
        if (onGround)
        {
            onGroundTimer = currentTime + .5f;
            if(jumpTimer > currentTime)
            {
                Jump();
            }
        }
        if(jumpTimer > Time.time && onGroundTimer > currentTime)
        {
            rb.AddForce(Vector3.up * upwardsForce);
        }
    }
    void HandleXZMovement()
    {
        rb.AddForce(new Vector3(PlayerInputScript.h * forceModifier, 0, 0)); //x force
        rb.AddForce(new Vector3(0, 0, PlayerInputScript.v * forceModifier)); //z force
        
        // float h = rb.velocity.x;
        // float v = rb.velocity.z;
        // float XZSpeed = Mathf.Sqrt(h * h + v * v);
        // if(XZSpeed > maxSpeed)
        // {
        //     h = h * Mathf.Sqrt(1f - 0.5f * v * v);
        //     v = v * Mathf.Sqrt(1f - 0.5f * h * h);
        //     rb.velocity = new Vector3(h * maxSpeed, 0, v * maxSpeed);
        // }
        
    }
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpingForce, ForceMode.Impulse);
    }

    private bool OnGround()
    {
        bool ret = false;

        float rayDepth = groundCheckLength;
        float rayOriginOffset = 1f;
        float totalRayLen = rayOriginOffset + rayDepth;

        Ray ray = new Ray(this.transform.position + Vector3.up * rayOriginOffset, Vector3.down);

        int layerMask = 1 << LayerMask.NameToLayer("Default");


        RaycastHit[] hits = Physics.RaycastAll(ray, totalRayLen, layerMask);

        foreach (RaycastHit hit in hits)
        {

            if (hit.collider.gameObject.CompareTag("Ground"))
            {

                ret = true;

                break; //only need to find the ground once

            }

        }
        Debug.Log(ret);
        return ret;
    }
}
