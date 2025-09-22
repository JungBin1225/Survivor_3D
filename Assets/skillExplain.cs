using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class skillExplain : MonoBehaviour
{
    public Sprite skillSprite;
    private Image skillImg;
    public Text skillText;

    public GameObject skillExplainBox;
    private PlayerController player;
    

    // Start is called before the first frame update
    void Start()
    {
        skillSprite = this.GetComponent<Image>().sprite;
        skillImg = this.GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
       
    }


    public void checkSkillChangeImgUI()
    {
        
        skillSprite = this.GetComponent<Image>().sprite;
        //Debug.Log(skillImg.name);
        if(skillSprite==null)
        {
            skillImg.raycastTarget = false;
        }
        else
        {
            skillImg.raycastTarget = true;
            if (skillSprite.name.Contains("Ball"))
            {

                skillText.text = "��ų ��Lv"+player.ballLV.ToString()+": ������ ���� �ڵ����� �������ִ� ���� ��ȯ(+������ ���� �� ���� �߰�)";
            }
            else if (skillSprite.name.Contains("Knockback"))
            {
                skillText.text = "��ų �˹�Lv" + player.knockbackLV.ToString() + ": ���� �������� ������ ������ ������ ���� ��ó����";
            }
            else if (skillSprite.name.Contains("Nautilus"))
            {
                skillText.text = "��ų ��ƿ����Lv" + player.nautilusLV.ToString() + ": ���� �������� ���� �����ϴ� ���ٱ⸦ �߻��Ѵ�";
            }
            else if (skillSprite.name.Contains("Taunt"))
            {
                skillText.text = "��ų ����LV" + player.tauntLV.ToString() + ": ������ �����ϴ� ���߹�ü�� �����Ѵ�";
            }
            else if (skillSprite.name.Contains("Virus"))
            {
                skillText.text = "��ų ���̷���Lv" + player.virusLV.ToString() + ": ���鿡�� ������ �������� �ִ� ���� �Ѹ���";
            }
        }


    }
    

    public void OnPointerEnter()
    {
        skillExplainBox.SetActive(true);
    }
    public void OnPointerExit()
    {
        skillExplainBox.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        checkSkillChangeImgUI();

    }
}
