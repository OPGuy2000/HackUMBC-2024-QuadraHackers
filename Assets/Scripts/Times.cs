using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Times : MonoBehaviour
{
    public TextMeshProUGUI[] timerTexts;
    public Transform[] players;
    public float maxTime;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        foreach (var timet in timerTexts)
        {
            timet.text = Mathf.RoundToInt(timer).ToString();
        }
        if (timer <= 0)
        {
            timer = 0;
            foreach (var player in players)
            {
                if (player.childCount == 2) {
                    player.GetChild(0).GetChild(3).gameObject.SetActive(true);

                } else
                {
                    player.GetChild(0).GetChild(4).gameObject.SetActive(true);
                }
            }
            Invoke("Leave", 5f);
        }
    }

    void Leave()
    {
        SceneManager.LoadScene("Mainmenu");
    }

}
