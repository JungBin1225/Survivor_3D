using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimicManager : MonoBehaviour
{
    public GameObject clearPortal;

    public GameObject RedBox;
    public GameObject GreenBox;
    public GameObject BlueBox;
    public GameObject BlackBox;

    //public string[] answer;
    public string[] answer;
    public string[] playerAnswer;

    bool isClear=false;
    public GameObject gimicClearText;
    public GameObject gimicFailText;
    public GameObject gimicRestartText;

    AudioSource audio;
    public AudioClip clearBGM;
    public AudioClip failBGM;

    public int cnt=0;

    // Start is called before the first frame update
    void Start()
    {
        audio = this.GetComponent<AudioSource>();

    }
    public void addType(string type)
    {
        if (type == "Black")
        {
            StartCoroutine(showGimicResult(gimicRestartText));
            playerAnswer[0] = null;
            playerAnswer[1] = null;
            playerAnswer[2] = null;
            RedBox.SetActive(true);
            GreenBox.SetActive(true);
            BlueBox.SetActive(true);
            cnt = 0;

        }
        else
        {
            playerAnswer[cnt] = type;
            cnt++;
        }
       
    }
    private IEnumerator showGimicResult(GameObject obj)
    {
        
            obj.SetActive(true);
            yield return new WaitForSeconds(2.0f); 
            obj.SetActive(false);
            cnt = 0;
        
    }
    private IEnumerator RefreshGimic()
    {
        yield return new WaitForSeconds(2.0f);
        RedBox.SetActive(true);
        GreenBox.SetActive(true);
        BlueBox.SetActive(true);


    }
    public void checkAnswer()
    {
      
        
        if (answer[0]==playerAnswer[0]&answer[1]==playerAnswer[1]&answer[2]==playerAnswer[2])
        {
            /*gimicClearText.SetActive(true);*/
            /*audio.clip = clearBGM;
            audio.Play();*/

            StartCoroutine(showGimicResult(gimicClearText));
            isClear = true;
            clearPortal.SetActive(true);
            RedBox.SetActive(false);
            GreenBox.SetActive(false);
            BlueBox.SetActive(false);
            BlackBox.SetActive(false);
        }
        else
        {
            cnt = 0;
            audio.clip = failBGM;
            audio.Play();
            if (!isClear) StartCoroutine(showGimicResult(gimicFailText));   
            playerAnswer[0] = null;
            playerAnswer[1] = null;
            playerAnswer[2] = null;

            StartCoroutine(RefreshGimic());

        }
    
    }

    // Update is called once per frame
    void Update()
    {
        if (cnt == 3)
        {
            checkAnswer();
        }
        
    }
}
