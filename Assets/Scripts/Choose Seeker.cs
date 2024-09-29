using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSeeker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    public GameObject gunPrefab;
    Transform playerCam;

    void Start()
    {
        GiveGun(GeneratePlayers());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject GeneratePlayers()
    {
        return p1;
        int t = Mathf.RoundToInt( Random.Range(0, 3));
        if (t == 2 && p3.activeSelf == false)
            GeneratePlayers();
        if(t == 3 && p4.activeSelf == false)
            GeneratePlayers();
        if (t == 0)
            return p1;
        else if(t== 1) return p2;
        else if (t== 2) return p3;
        else return p4;
    }

    void GiveGun(GameObject player)
    {
        playerCam = player.transform.GetChild(0).GetComponent<Transform>();
        GameObject gun = Instantiate(gunPrefab, playerCam);
        gun.transform.localPosition = new Vector3(0.6f, -0.26f, 0.88f);
        gun.transform.localEulerAngles = new Vector3(90, 0, -90);
    }
}
