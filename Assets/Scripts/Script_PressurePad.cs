using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PressurePad : MonoBehaviour
{
    [SerializeField] GameObject door;
    MeshRenderer doorMaterialRender;
    [SerializeField] Material[] materialColors;
    [SerializeField] bool changeDoorToBlue, changeDoorToRed;
    Animator animController;

    Collider objectCollider;

    private void Start()
    {
        //Door
        if (door == null)
        {
            Debug.Log("Door GameObject not added!");
            return;
        }

        //Collider
        if (transform.parent.GetComponent<Collider>() != null)
        {
            objectCollider = transform.parent.GetComponent<Collider>();
            objectCollider.enabled = true;
        }


        doorMaterialRender = door.GetComponent<MeshRenderer>();
        ChangeDoorColor(0);

        //Animator
        if (transform.GetComponent<Animator>() == null)
        {
            Debug.Log("Animator not added!");
            return;
        }
        animController = GetComponent<Animator>();
        animController.SetBool("Idle", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player1" || other.transform.tag == "Player2")
        {
            if (door != null) { ReactWithPlayer(); }
        }
    }

    private void ChangeDoorColor(int index)
    {
        switch (index)
        {
            case 0:
                door.transform.gameObject.layer = LayerMask.NameToLayer("Default");
                break;
            case 1:
                door.transform.gameObject.layer = LayerMask.NameToLayer("Blue");
                break;
            case 2:
                door.transform.gameObject.layer = LayerMask.NameToLayer("Red");
                break;
            default:
                door.transform.gameObject.layer = LayerMask.NameToLayer("Default");
                break;
        }
        doorMaterialRender.material = materialColors[index];
    }

    private void ReactWithPlayer()
    {
        animController.SetBool("Idle", false);
        if (objectCollider != null)
        {
            objectCollider.enabled = false;
        }
        if (changeDoorToBlue) { ChangeDoorColor(1); }
        if (changeDoorToRed) { ChangeDoorColor(2); }
    }
}
