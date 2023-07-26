using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class targets : MonoBehaviour
{
    TargetSpawner targetSpawner;
    // Start is called before the first frame update
    void Start()
    {
        targetSpawner = GetComponentInParent<TargetSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            targetSpawner.score += 5;
            targetSpawner.count -= 1;
            targetSpawner.UpdateScores();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Debug.Log("Destryoed");
        }
    }
}
