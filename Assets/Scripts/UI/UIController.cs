using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    PlayerController player;
    public GameObject GameOverImg;
    public Image hpBar;
    public Image expBar;
    public Text expText;
    public Text levelText;
    public Text hpText;


    private float playerHp;
    private float playerTotalHp;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerTotalHp = player.maxHp;
        expText.text = player.exp.ToString() + "/" + player.expList[player.Level].ToString(); 
        levelText.text = "Lv." + player.Level.ToString();


        //debug
        expBar.fillAmount = 0;
        hpBar.fillAmount = 1;
        hpText.text = player.GetHp().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHpBar();
        PlayerExpBar();
        if (player.GetHp() <= 0)
        {
            GameOverImg.gameObject.SetActive(true);
        }
        else
        {
            GameOverImg.gameObject.SetActive(false);
        }
        
    }
    public void PlayerHpBar()
    {

        if (player.GetHp() > playerTotalHp)
        {
            playerTotalHp = player.GetHp();

        }

        playerHp = player.GetHp();
        hpBar.fillAmount = playerHp / playerTotalHp;


        hpText.text = playerHp.ToString() + "/" + playerTotalHp.ToString();
        
    }
    public void PlayerExpBar()
    {
        expBar.fillAmount = (float)player.exp/ (float)player.expList[player.Level];

    }
    public void ResetPlayerExpBar()
    {
        expBar.fillAmount = 0;
    }
    public void SetExp()
    {
        expText.text = player.exp.ToString() + "/" + player.expList[player.Level].ToString();

    }
    public void SetLevel()
    {
        levelText.text = "Lv." + player.Level.ToString();

    }

    public void GotoMain()
    {
        GameManager.gameManager.initManager();
        SceneManager.LoadScene("CharacterSelect");
    }

    public void OnGimmicClicked(GameObject gimmic)
    {
        gimmic.SetActive(true);
    }
}
