using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{

    public Button StartButton;
    public GameObject controlPanel;

    public void Click()
    {
        this.gameObject.SetActive(false);
        controlPanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(Click);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
