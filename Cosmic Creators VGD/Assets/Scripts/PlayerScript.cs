using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Components")]
    public PlayerInputScript PlayerInputScript;
    private Rigidbody rb;
    [Header("Movement")]
    private float maxSpeed = 5;
    private float forceModifier = 15;
    [Header("Jumping")]
    private float jumpingForce = 4;
    private float jumpingForceModifier = .2f;
    private float jumpingMaxSpeedModifier = 1.1f;
    private float groundCheckLength = 1f;
    private float jumpTimer = 0f;
    private float jumpDelay = .15f;
    private bool jump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        jump = Input.GetKeyDown(KeyCode.Space);
        if ((jump))
        {
            jumpTimer = Time.time + jumpDelay;
        }
    }
    void FixedUpdate()
    {
        handleXZMovement();

        if (jump)
        {
            Debug.Log("test");
        }
        if (OnGround() && jumpTimer > Time.time)
        {
            Jump();
        }
    }
    void handleXZMovement() 
    {
        rb.AddForce(new Vector3(0, 0, PlayerInputScript.vInput * forceModifier)); //z force
        rb.AddForce(new Vector3(PlayerInputScript.hInput * forceModifier, 0, 0)); //x force
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
