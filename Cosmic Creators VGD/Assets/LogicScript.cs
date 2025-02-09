using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    private float startTime = 100;
    private float currentTime;
    [Header("Components")]
    public TMP_Text time;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        time.text = Mathf.CeilToInt(currentTime).ToString();
    }

}
