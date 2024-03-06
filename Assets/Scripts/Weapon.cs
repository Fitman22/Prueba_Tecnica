using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    public float damage,defense;
    public bool weapon;
    public Material[] mat;
    public Mesh model;
    public string animationAttack, animation;
    public Sprite icon;
}
