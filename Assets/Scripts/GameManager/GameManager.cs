using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public bool isCutScene;
    public bool viewedTutorial;
    public string lastStage;
    //var

    public string lastCharacter;
    public string playerCharacterType;
    public Dictionary<string, bool> characterDic = new Dictionary<string, bool>() { {"Earth",true },{"Fire",true }, { "Water", false }
    ,{"Light",false },{"Dark",false }};

    public float current_Hp;
    public int current_Level;
    public int current_Exp;
    public int current_BallLV;
    public int current_KnockbackLV;
    public int current_TauntLV;
    public int current_NautilusLV;
    public int current_VirusLV;

    public float rotValue;

    private void Awake()
    {
        if (gameManager == null)
            gameManager = this;

        else if (gameManager != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        isCutScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initManager()
    {
        isCutScene = false;
        lastStage = "";
        lastCharacter = "";
        playerCharacterType = "";
        current_Hp = 0;
        current_Level = 0;
        current_Exp = 0;
        current_BallLV = 0;
        current_KnockbackLV = 0;
        current_TauntLV = 0;
        current_NautilusLV = 0;
        current_VirusLV = 0;
    }
}
