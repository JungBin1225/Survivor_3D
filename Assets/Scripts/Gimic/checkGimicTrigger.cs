using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGimicTrigger : MonoBehaviour
{
    GimicManager gimicManager;
    //public GameObject gimicTextBG;
    public string type;
    // Start is called before the first frame update

    AudioSource audio;
    void Start()
    {
        gimicManager = GameObject.FindGameObjectWithTag("Gimic1").GetComponent<GimicManager>();
        audio = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //audio.Play();
            gimicManager.addType(type);
            if (type != "Black") {
                this.gameObject.SetActive(false);
            }
            
            

        }


    }
}
