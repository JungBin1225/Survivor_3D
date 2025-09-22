using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBall : MonoBehaviour
{
    //public Transform playerPos;
    public Transform ObjectToTeleport;
    public CharacterController characterController;
    AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
       // playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        audio = this.GetComponent<AudioSource>();

    }

    private void Update()
    {
       // this.transform.position = new Vector3(10, 10, 10);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audio.Play();
            characterController.enabled = false;    //characterController�� �÷��̾� �������� �� ������ set�ϱ� �������� �����̵��� �ȵǰ� �־���
            other.transform.position = new Vector3(ObjectToTeleport.position.x + 5, other.transform.position.y, ObjectToTeleport.position.z);
            characterController.enabled = true;
            
        }


    }
}
