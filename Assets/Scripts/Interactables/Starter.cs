using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Starter : Interactable
{
    [SerializeField]
    Material[] materials;
    
   
    
    [SerializeField]
    TargetSpawner TS;

    [SerializeField]
    GameObject button;

    [SerializeField]
    

    private MeshRenderer m;
    

    // Start is called before the first frame update

    void Start()
    {
        promptMessage = "Press E to begin Round.";
        m = button.GetComponent<MeshRenderer>();
        m.material = materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        if (!TS.gameOn)
        {
            m.material = materials[1];
            promptMessage = "Press E to end Round.";
            TS.gameOn = true;
            TS.newGame();
            // trigger scores and spawn.
        }
        else
        {
            m.material = materials[0];
            promptMessage = "Press E to begin Round.";
            TS.gameOn= false;
            targets[] l = FindObjectsOfType<targets>();
            foreach (var tar in l)
            {
                DestroyImmediate(tar.gameObject);
            }
            TS.count = 0;


        }
        //Debug.Log("Interacted with" + gameObject.name);
        //base.Interact();
    }
}
