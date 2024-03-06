using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] GameObject inventary;
    [SerializeField] List<Slot> slots;
    [SerializeField] Slot Rhand, LHand;
    [SerializeField] Collect collect;
    [SerializeField] TextMeshProUGUI txAction;
    bool state, state2;
    private void Start()
    {
        ControlsController.getControls().OpenInventory.performed += ctr => OpenInventory();
        OpenInventory();
        Rhand.setUiController(this, true);
        LHand.setUiController(this, false);
        ControlsController.getControls().Interact.performed += ctr => OpenInventoryNpc();
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void EquipHand(Weapon weapon, bool rightHand)
    {
        collect.equipWeapon(weapon, rightHand);
    }
    public void RemoveHand(bool rightHand)
    {
        collect.removeWeapon(rightHand);
    }
    public void ActionTx(string action)
    {
        txAction.text = action;
    }
    public void noSpace()
    {
        GetComponent<Animator>().Play("noSpace");
    }
    public bool addItem(Weapon weapon)
    {
        bool onSlot=false;
        foreach (Slot slot in slots)
        {
            if (!slot.GetWeapon() && slot.setItem(weapon))
            {
                onSlot = true;
                break;
            }
        }
        return onSlot;
    }
    private void OpenInventory()
    {    
        inventary.SetActive(state);
        ChangeState(state);
        state = !state;
    }
    private void OpenInventoryNpc()
    {
        if (!collect.onInteract) return;
        state2 = !state2;
        ChangeState(state2);
        if (state2) { inventary.SetActive(true); state = false; GetComponent<Animator>().Play("InventoryNPC"); }
        else closeInventoryNpc();
       
    }
    public void  closeInventoryNpc()
    {
        inventary.SetActive(false);
        state = true;
        state2 = false;
        ChangeState(false);
        GetComponent<Animator>().Play("Idle");
    }
    public void ChangeState(bool state)
    {
        Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
        collect.ChangeState(!state);
    }
}
