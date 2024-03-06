using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsController : MonoBehaviour
{
    MapControls map;
   static MapControls.ControlsActions controls;
    private void Awake()
    {
        map = new MapControls();
        controls = map.Controls;
    }
    public static MapControls.ControlsActions getControls()
    {
        return controls;
    }
    private void OnEnable()
    {
        map.Enable();
    }
    private void OnDestroy()
    {
        map.Disable();
    }
}
