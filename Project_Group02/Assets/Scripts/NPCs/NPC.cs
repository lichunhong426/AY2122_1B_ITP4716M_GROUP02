using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public GameObject TriggerText;
    public GameObject DialogueObject;


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            TriggerText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                DialogueObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;


            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerText.SetActive(false);
        DialogueObject.SetActive(false);
    }
}
