using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    //[Header("Input")]
    public float v
    {
        get;
        private set;
    }

    public float h
    {
        get;
        private set;
    }

    public bool Action
    {
        get;
        private set;
    }

    public bool Jump
    {
        get;
        private set;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if (true)
        {
            h = h * Mathf.Sqrt(1f - 0.5f * v * v);
            v = v * Mathf.Sqrt(1f - 0.5f * h * h);
        }

        Jump = Input.GetButton("Jump");
    }
}
