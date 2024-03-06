using StarterAssets;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Collect : MonoBehaviour
{
    [SerializeField] GameObject weapon,Shield;
    [SerializeField] UIcontroller uicontroller;
    [SerializeField] ThirdPersonController controller;
    Weapon Onweapon;
    public bool onInteract;
    bool state = true;
    private void Start()
    {
        ControlsController.getControls().click.performed += ctr => Attack();
    }
    public void ChangeState(bool state)
    {
        controller.enabled = state;
        this.state = state;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Collectable>())
        {
            if (uicontroller.addItem(collision.gameObject.GetComponent<Collectable>().GetWeapon()))
            {
                Destroy(collision.gameObject);
            }
            else
            {
                uicontroller.noSpace();
            }
           
        }
       
    }
    void Attack()
    {        
        
       if(Onweapon && state)GetComponent<Animator>().Play(Onweapon.animationAttack);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("NPC"))
        {
            uicontroller.ActionTx("press " + ControlsController.getControls().Interact.GetBindingDisplayString());
            onInteract = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("NPC"))
        {
            uicontroller.closeInventoryNpc();
            uicontroller.ActionTx("");
            onInteract = false;
        }
    }
    public void removeWeapon(bool rightHand)
    {
        if (rightHand)
        {
            Onweapon = null;
            weapon.GetComponent<MeshFilter>().mesh = null;
            weapon.GetComponent<MeshRenderer>().material = null;
        }
        else
        {
            Shield.GetComponent<MeshFilter>().mesh = null;
            Shield.GetComponent<MeshRenderer>().material = null ;
        }
    }
    public void equipWeapon(Weapon newEquip,bool rightHand)
    {
        if (rightHand)
        {
            Onweapon = newEquip;
            weapon.GetComponent<MeshFilter>().mesh = newEquip.model;
            weapon.GetComponent<MeshRenderer>().materials = newEquip.mat;
        }
        else
        {
            Shield.GetComponent<MeshFilter>().mesh = newEquip.model;
            Shield.GetComponent<MeshRenderer>().materials = newEquip.mat;
        }
    }
}
