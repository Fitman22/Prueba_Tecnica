
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] Image icon;
    Weapon weapon;
    UIcontroller uIcontroller;
    bool select,Right;
    private void Awake()
    {
        removeItem();
    }
    public void setUiController(UIcontroller ui,bool hand)
    {
        uIcontroller = ui;
        Right = hand;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == gameObject && GetWeapon())
        {
            select = true;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (select)
        {
            if (!eventData.pointerCurrentRaycast.isValid ||!eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>())
            {
                icon.rectTransform.localPosition = Vector2.zero;
                select = false;
            }
            Slot slotSelect = eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>();
            if (slotSelect && slotSelect)
            {
                if((uIcontroller || slotSelect.getHandSlot())&& slotSelect.GetWeapon() && GetWeapon().weapon)
                {
                    if (slotSelect.GetWeapon().weapon == GetWeapon().weapon)
                    {
                        Weapon temp = slotSelect.GetWeapon();
                        if (slotSelect.setItem(weapon))
                        {
                            setItem(temp);
                        }
                    }
                }
                else
                {
                    Weapon temp = slotSelect.GetWeapon();
                    if (slotSelect.setItem(weapon))
                    {
                        setItem(temp);
                    }
                }
              
                             
            }
                icon.rectTransform.localPosition = Vector2.zero; 
            select = false;
        }
    }
    public bool getHandSlot() { return uIcontroller ? true : false; }
    private void Update()
    {
        if (select)
        {
            Vector2 pos = ControlsController.getControls().Mouse.ReadValue<Vector2>();
            icon.rectTransform.position = pos;
        }
    }
    public Weapon GetWeapon() { return weapon; }
    void removeItem()
    {
        weapon = null;
        icon.color = new Color(0, 0, 0, 0);
        icon.sprite = null;
        if (uIcontroller) uIcontroller.RemoveHand(Right);
    }
    public bool setItem(Weapon weapon) {
        if (!weapon)
        {
            removeItem();
            return false;
        }
        else
        {
            if (uIcontroller) {
                if (!weapon.weapon == Right) return false;
                uIcontroller.EquipHand(weapon, Right); }
            icon.sprite = weapon.icon;
            this.weapon = weapon;
            icon.color = new Color(255, 255, 255, 255);
            return true;
        }
    }

  
}
