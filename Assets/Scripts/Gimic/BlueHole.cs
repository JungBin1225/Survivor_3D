using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueHole : MonoBehaviour
{
   // public Transform playerPos;
    public Transform ObjectToTeleport;
    public CharacterController characterController;
    GimicManager gimicManager;
    AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        gimicManager = GameObject.FindGameObjectWithTag("Gimic1").GetComponent<GimicManager>();
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audio.Play();
            characterController.enabled = false;    //characterController�� �÷��̾� �������� �� ������ set�ϱ� �������� �����̵��� �ȵǰ� �־���
            other.transform.position = new Vector3(ObjectToTeleport.position.x + 5, other.transform.position.y, ObjectToTeleport.position.z);
            characterController.enabled = true;

            //gimicManager.addType("Black"); //��� 1 �ʱ�ȭ

        }


    }
}
