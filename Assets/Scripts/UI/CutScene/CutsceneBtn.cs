using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CutsceneBtn : MonoBehaviour
{

    public string btnType;
    public string nextScene;
    public List<Image> sceneList;
    public int cnt=0;
    CutsceneTextBox cutSceneTextBox;

    // Start is called before the first frame update
    void Start()
    {
        cutSceneTextBox = GameObject.Find("TextBox").GetComponent<CutsceneTextBox>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLeft()
    {
       if(cnt==0)
        {
            return;
        }
        else
        {
            cnt--;
            sceneList[cnt].gameObject.SetActive(true);

            sceneList[cnt + 1].gameObject.SetActive(false);
        }
        cutSceneTextBox.textCount = 0;
        cutSceneTextBox.OnClick();
    }
    public void OnClickRight()
    {
        
        if(cnt==sceneList.Count-1)
        {
            //������ ���� ���
            
            StartCoroutine(waitTimetoScene());
        }
        else
        {
            cnt++;
            sceneList[cnt].gameObject.SetActive(true);

            sceneList[cnt - 1].gameObject.SetActive(false);

            if(cnt == sceneList.Count - 1)
            {
                StartCoroutine(waitTimetoScene());
            }

        }
        cutSceneTextBox.textCount = 0;
        cutSceneTextBox.OnClick();

    }
    IEnumerator waitTimetoScene()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(nextScene);
    }
  

    public void moveNextScene()
    {

        SceneManager.LoadScene(nextScene);
    }

}
