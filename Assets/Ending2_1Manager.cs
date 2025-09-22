using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending2_1Manager : MonoBehaviour
{
    public GameObject mainUI;
    public TextController text;
    public List<GameObject> characterList;
    public GameObject pauseMenu;

    private PlayerController player;
    private float time;
    private bool start;

    public GameObject enemyGenerator;

    List<GameObject> ableUI;

    void Start()
    {
        start = false;
        player = FindObjectOfType<PlayerController>();
        spawnPlayer(GameManager.gameManager.playerCharacterType);

        StartCoroutine(PlayingcutScene());
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

    public IEnumerator PlayingcutScene()
    {
        yield return StartCoroutine(text.WriteText(text.textFile_1));

        GameManager.gameManager.isCutScene = false;
        enemyGenerator.SetActive(true);

    }

    public void DisableOther()
    {
        ableUI = new List<GameObject>();
        //Debug.Log("call disableother");
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
        //Debug.Log("call enableother");
        foreach (GameObject ui in ableUI)
        {
            ui.SetActive(true);
        }
        ableUI.Clear();
    }

    public void OnPauseClicked(string menu)
    {
        //Debug.Log("call onpauseclicked");
        pauseMenu.SetActive(true);
        pauseMenu.GetComponent<PauseMenu>().state = menu;
        pauseMenu.GetComponent<PauseMenu>().ChangeMenu();
    }
}
