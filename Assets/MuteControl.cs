using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteControl : MonoBehaviour
{
    public GameObject soundsManagement;
    public GameObject labelSoundON;
    public GameObject labelSoundOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("Apertei Q");
            MuteManagement();
        }
    }

    private void MuteManagement()
    {
        if (soundsManagement.activeSelf){
            print("Ativo");
            soundsManagement.SetActive(false);
            labelSoundOff.SetActive(true);
            labelSoundON.SetActive(false);
        } else 
        {
            print("Off");
            soundsManagement.SetActive(true);
            labelSoundOff.SetActive(false);
            labelSoundON.SetActive(true);
        }
    }
}
