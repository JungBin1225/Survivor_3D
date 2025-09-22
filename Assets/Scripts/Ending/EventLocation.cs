using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLocation : MonoBehaviour
{
    private Ending2Manager manager;

    public int index;

    void Start()
    {
        manager = transform.parent.GetComponent<Ending2Manager>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !manager.viewedText[index])
        {
            switch(index)
            {
                case 0:
                    StartCoroutine(manager.PlayingcutScene(manager.text.textFile_2));
                    break;

                case 1:
                    StartCoroutine(manager.PlayingcutScene(manager.text.textFile_3));
                    break;

                case 2:
                    StartCoroutine(manager.PlayingcutScene(manager.text.textFile_4));
                    break;
            }
            manager.viewedText[index] = true;
        }
    }
}
