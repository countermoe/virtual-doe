using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchModel : MonoBehaviour
{
    private bool isRemodel;
    private bool canSwitch;
    public GameObject scan;
    public GameObject remodel;

    private void Start()
    {
        canSwitch = true;
        isRemodel = false;
        scan.SetActive(true);
        remodel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            if (canSwitch)
            {
                isRemodel = !isRemodel;
                scan.SetActive(!isRemodel);
                remodel.SetActive(isRemodel);
                StartCoroutine(wait(0.5f));
            }
        }
    }

    IEnumerator wait(float sec)
    {
        canSwitch = false;
        yield return new WaitForSeconds(sec);
        canSwitch = true;
    }
}
