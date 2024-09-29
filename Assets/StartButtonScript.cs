using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartButtonScript : MonoBehaviour
{

    public Button StartButton;
    public GameObject controlPanel;
    bool panelOpen= false;

    public void Click()
    {
        this.gameObject.SetActive(false);
        panelOpen = true;
        controlPanel.SetActive(true);
        Debug.Log("open!");
        Invoke("LoadNext", 3f);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(Click);
    }

    // Update is called once per frame
    void Update()
    {
        if(panelOpen)
        {
            
                panelOpen=false;
            
        }
    }

    void LoadNext()
    {
        SceneManager.LoadScene("GameSceneBK 1");
    }
}
