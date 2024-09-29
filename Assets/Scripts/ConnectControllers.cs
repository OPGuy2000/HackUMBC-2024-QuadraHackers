using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConnectControllers : MonoBehaviour
{
    public TextMeshProUGUI prompt1;
    public TextMeshProUGUI prompt2;
    public TextMeshProUGUI prompt3;
    public TextMeshProUGUI prompt4;


    public GameObject p3;
    public GameObject p4;

    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Connect()
    {
        string[] controllers = Input.GetJoystickNames();
        prompt1.text = controllers[0];
        prompt2.text = controllers[1];

        if(controllers.Length > 2)
        {
            prompt3.text = controllers[2];


        }
        if (controllers.Length > 3)
            prompt4.text = controllers[3];

    }
}
