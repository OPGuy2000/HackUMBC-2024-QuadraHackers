using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public TextMeshPro ammoText;

    public int maxAmmoPerMag;
    public int ammoInMag;
    int ammoInStock;

    public float timeBetweenShots;
    bool readyToShoot;

    public float reloadTime;
    public bool reloading;

    float currentLerpTime;



    // Start is called before the first frame update
    void Start()
    {
        readyToShoot = true;

        //testing purposes only
        ammoInMag = 30;
        ammoInStock = 60;
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = ammoInMag.ToString() + "/" + ammoInStock.ToString();
        if (Input.GetKeyDown(KeyCode.R) && !reloading && ammoInMag < maxAmmoPerMag && ammoInStock > 0)
            reloading = true;
        if (reloading ) Reload();

        if (Input.GetKeyDown(KeyCode.Mouse0) && ammoInMag > 0 && readyToShoot)
        {
            ammoInMag--;
            readyToShoot = false;
            Invoke("ResetShot", timeBetweenShots);
        }
            
    }

    void Reload()
    {
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > reloadTime)
        {
            currentLerpTime = reloadTime;
        }

        

        //lerp!
        float perc = currentLerpTime / reloadTime;
        transform.localEulerAngles = Vector3.Lerp(new Vector3(90, 0, -90), new Vector3(450, 0, -90), perc);
        if(perc >= 1)
        {
            reloading = false;
            currentLerpTime = 0;
            if(ammoInStock > maxAmmoPerMag)
            {
                ammoInStock -= maxAmmoPerMag - ammoInMag;
                ammoInMag += maxAmmoPerMag - ammoInMag;
            } else
            {
                ammoInMag += ammoInStock;
                ammoInStock = 0;
            }
            
        }
    }

    void ResetShot()
    {
        readyToShoot = true;
    }
}
