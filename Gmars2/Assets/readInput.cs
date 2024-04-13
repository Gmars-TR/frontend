using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class readInput : MonoBehaviour
{
    public string prompt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void readInputString(string s)
    {
        prompt = s;
        Debug.Log("Entered prompt: " + prompt);
    }

}
