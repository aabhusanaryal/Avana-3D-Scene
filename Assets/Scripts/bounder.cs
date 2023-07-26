using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounder : MonoBehaviour
{
    [SerializeField]
    TargetSpawner TS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            TS.missCount += 1;
            TS.UpdateScores();
            GameObject.Destroy(other.gameObject);
        }
    }
}
