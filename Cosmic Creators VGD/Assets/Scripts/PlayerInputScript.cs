using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    //[Header("Input")]
    public float vInput
    {
        get;
        private set;
    }

    public float hInput
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
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        Jump = Input.GetButtonDown("Jump");
    }
}
