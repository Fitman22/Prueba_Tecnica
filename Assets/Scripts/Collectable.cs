using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
  public List<Weapon> weapon;
    
    int w;
    private void Start()
    {
        w = Random.Range(0, weapon.Count);
        if (weapon[w])
        {
            GetComponent<MeshFilter>().mesh = weapon[w].model;
            GetComponent<MeshCollider>().sharedMesh = weapon[w].model;
            GetComponent<MeshRenderer>().materials = weapon[w].mat;
        }
    }
    public Weapon GetWeapon() { return weapon[w]; }
}
