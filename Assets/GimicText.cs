using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimicText : MonoBehaviour
{
    bool isTouch;
    /*public GameObject gimicRestartText;
    public GameObject gimicClearText;*/

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void DeleteSelf()
    {
        this.gameObject.SetActive(false);
    }
    /*public void OnTouch()
    {
        if (isTouch)
        {
            this.gameObject.SetActive(false);
        }
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
