using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GimmicImage : MonoBehaviour
{
    public List<Sprite> imageList;
    private Image Image;

    private void OnEnable()
    {
        Time.timeScale = 0;
        Image = transform.GetChild(0).gameObject.GetComponent<Image>();
        SetImage();
    }


    void Update()
    {
        
    }

    public void OnClosedClick(GameObject gameObject)
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    private void SetImage()
    {
        if(SceneManager.GetActiveScene().name.Contains("2"))
        {
            Image.sprite = imageList[0];
        }
        else
        {
            Image.sprite = imageList[1];
        }
    }
}
