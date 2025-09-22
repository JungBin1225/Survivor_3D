using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending2Manager : MonoBehaviour
{
    public GameObject mainUI;
    public TextController text;
    public List<GameObject> characterList;
    public GameObject pauseMenu;

    public List<bool> viewedText;
        
    private PlayerController player;
    private float time;
    private bool start;

    List<GameObject> ableUI;

    void Start()
    {
        start = false;
        player = FindObjectOfType<PlayerController>();
        spawnPlayer(GameManager.gameManager.playerCharacterType);

        StartCoroutine(PlayingcutScene(text.textFile_1));
    }

    // Update is called once per frame
    void Update()
    {

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

    public IEnumerator PlayingcutScene(TextAsset textFile)
    {
        yield return StartCoroutine(text.WriteText(textFile));

        GameManager.gameManager.isCutScene = false;
    }

    public void DisableOther()
    {
        ableUI = new List<GameObject>();
        for (int i = 0; i < mainUI.transform.childCount; i++)
        {
            GameObject ui = mainUI.transform.GetChild(i).gameObject;
            if (ui.activeSelf)
            {
                ableUI.Add(ui);
                ui.SetActive(false);
            }
        }
    }

    public void EnableOther()
    {
        foreach (GameObject ui in ableUI)
        {
            ui.SetActive(true);
        }
        ableUI.Clear();
    }

    public void OnPauseClicked(string menu)
    {
        pauseMenu.SetActive(true);
        pauseMenu.GetComponent<PauseMenu>().state = menu;
        pauseMenu.GetComponent<PauseMenu>().ChangeMenu();
    }
}
