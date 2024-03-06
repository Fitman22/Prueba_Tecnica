using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject objects;
    [SerializeField] Transform min, max;
    [SerializeField] int amount;
    private void Start()
    {
        for (int i = 0; i < amount; i++)
        {

            Vector3 pos = new Vector3(Random.Range(min.position.x, max.position.x),
                Random.Range(min.position.y, max.position.y), Random.Range(min.position.z, max.position.z));
            GameObject o = Instantiate(objects,pos,transform.rotation);
        }
    }
    private void OnDrawGizmos()
    {
        Vector3 center = (min.position + max.position) / 2f;
        Vector3 size = new Vector3(Mathf.Abs(max.position.x - min.position.x), Mathf.Abs(max.position.y - min.position.y), Mathf.Abs(max.position.z - min.position.z));
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center, size);
    }
}
