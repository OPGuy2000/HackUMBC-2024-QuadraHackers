using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI timerText;
    public float targetTime = 999.0f; 

    // public void Update() {
    public void onGameStart() {
        targetTime -= Time.deltaTime;

        timerText.text = "Timer: " + targetTime;
        if (targetTime <= 0.0f) {
            timerEnded();
        }
    }

    public void timerEnded() {
        // do stuff
    }
}
