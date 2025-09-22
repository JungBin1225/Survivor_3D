using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    public string nextSceneText;
    public GameObject effectNextScene;
    public GameObject clearImg;
    public AudioSource audio;
    void Start()
    {
        audio = this.GetComponent<AudioSource>();    
    }
    IEnumerator moveToNextScene()
    {
        audio.Play();
        effectNextScene.SetActive(true);
        if(SceneManager.GetActiveScene().name == "Tutorial_2")
        {
            GameManager.gameManager.viewedTutorial = true;
        }
        StartCoroutine(showClearImg());
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(nextSceneText);
    }
    IEnumerator showClearImg()
    {
        yield return new WaitForSeconds(1.0f);
        clearImg.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().isClear = true;
            StartCoroutine(moveToNextScene());
        }
    }

}
