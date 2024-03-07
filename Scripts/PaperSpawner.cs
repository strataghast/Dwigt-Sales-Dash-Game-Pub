using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    public void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }
    private void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Paper", new Vector3(Random.Range(0, 0), -8, 0), Quaternion.identity);
    }

}
