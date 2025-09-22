using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial_1Manager : MonoBehaviour
{
    public int flowCount;
    public GameObject tutoTextBoxGameObj;
    public GameObject horizontalAxisController;
    public GameObject horizontalAxisControllerParent;

    public GameObject forwardController;
    public GameObject backController;
    public GameObject nextStage;

    public List<GameObject> characterList;

    public int showCount=0;
    public int clickCount;

    public bool textPrint;
    
    tutorialTextBox tutoTextBox;
    Coroutine col;
    Image HorizontalControllerImg;
    /*Image ForwardControllerImg;
    Image BackControllerImg;*/
    // Start is called before the first frame update
    void Start()
    {
        //col = StartCoroutine(showHorizontalController());
        spawnPlayer(GameManager.gameManager.playerCharacterType);

        tutoTextBoxGameObj.SetActive(true);
        tutoTextBox = GameObject.Find("tutoTextBox").GetComponent<tutorialTextBox>();
        HorizontalControllerImg = horizontalAxisController.GetComponent<Image>();
        /*ForwardControllerImg = forwardController.GetComponent<Image>();
        ForwardControllerImg = backController.GetComponent<Image>();*/

        textPrint = false;
    }
    IEnumerator delay()
    {
        
        yield return new WaitForSeconds(0.5f);
        horizontalAxisController.SetActive(false);
        
    }
    IEnumerator delay2()
    {
        
        /*if(showCount<=2)
        {
            backController.SetActive(true);
            forwardController.SetActive(true);
        }
        else
        {
            backController.SetActive(false);
            forwardController.SetActive(false);
        }*/
        
        backController.SetActive(true);
        forwardController.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        
        backController.SetActive(false);
        forwardController.SetActive(false);
        if(showCount==1)
        {
            forwardController.SetActive(true);
            backController.SetActive(true);
        }
       
        

    }


    //invokeȣ���̶� �޼ҵ带 ���� �������� ����;

    public void showHorizontalController()
    {
       

        if (showCount>=2)
        {
            CancelInvoke("showHorizontalController");
            
            showCount = 0;
            
        }
        horizontalAxisController.SetActive(true);

        StartCoroutine(delay());
        showCount++;
    }
    public void showForwardBackController()
    {
        if (showCount >= 1)
        {
            
            CancelInvoke("showForwardBackController");
            
            showCount = 0;
            forwardController.SetActive(true);
            backController.SetActive(true);

        }
        StartCoroutine(delay2());
        showCount++;

    }


    // Update is called once per frame
    void Update()
    {
        if(textPrint)
        {
            horizontalAxisControllerParent.GetComponent<Image>().raycastTarget = false;
        }
        else
        {
            horizontalAxisControllerParent.GetComponent<Image>().raycastTarget = true;
        }
    }

    //�¿� �ü� ���� ��ư ǥ��
    public void flow_1()
    {
        tutoTextBoxGameObj.SetActive(false);

        horizontalAxisControllerParent.SetActive(true);


        InvokeRepeating("showHorizontalController", 0.5f, 1);



    }
    


/*    ������
- ����, ���� �ڿ������� ���ư��ݾ�!��

AI
- �����ñ� �̸��ϴ�.���� ��ư���� �յڷ� �̵��غ��ñ� �ٶ��ϴ�.��
*/
    public void flow_2()
    {
        clickCount = 0;
        tutoTextBoxGameObj.SetActive(true);
        tutoTextBox.textFlow2();
    }

    //�յ� �̵� ��Ʈ�ѷ� ���̱�
    public void flow_3()
    {
        tutoTextBoxGameObj.SetActive(false);
        InvokeRepeating("showForwardBackController", 0.5f, 1);
        
    }

    //�յڷ� �̵� �� 
/*    AI
- �����ϼ̽��ϴ�.���� ����� �ٸ� ������ �̵��� ��Ż�� �̵��� ���ʽÿ�.��

*/
    public void flow_4()
    {
        tutoTextBoxGameObj.SetActive(true);
        tutoTextBox.textFlow3();
    }

    //��Ż ���� �� �̵� �� Ʃ�丮��2�� �̵�
    public void flow_5()
    {
        tutoTextBoxGameObj.SetActive(false);
        nextStage.SetActive(true);
    }

    public void OnPauseClicked(GameObject menu)
    {
        menu.SetActive(true);
    }

    void spawnPlayer(string type)
    {
        if (type == "Earth")
        {
            characterList[0].SetActive(true);
        }
        else if (type == "Fire")
        {
            characterList[1].SetActive(true);
        }
    }
}
