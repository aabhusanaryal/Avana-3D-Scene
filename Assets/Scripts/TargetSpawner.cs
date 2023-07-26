using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private int maxCount = 3;
    [SerializeField]
    private float defX = -7.0f;
    [SerializeField]
    private float maxY = 5.0f;
    [SerializeField]
    private float maxZ = 9.0f;
    [SerializeField]
    private float minZ = -8.0f;
    [SerializeField]
    public bool gameOn = true;



    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI missCountText;

    public int count=0;
    public int score;
    public int missCount;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateScores();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOn)
        {
            for (int i = count; i < maxCount; i++)
            {
                GameObject g = GameObject.Instantiate(target, this.transform);
                g.transform.localPosition = new Vector3(defX, Random.Range(0, maxY), Random.Range(minZ, maxZ));
                count++;
            }
        }
       
    }

    public void UpdateScores()
    {
        //scoreText.text = "Score: " + score;
        //missCountText.text = "Misses: " + missCount;
    }

    public void newGame()
    {
        score = 0;
        missCount= 0;
        targets[] l = FindObjectsOfType<targets>();
        foreach (var tar in l)
        {
            DestroyImmediate(tar.gameObject);
        }
        count = 0;
        //UpdateScores();
    }
}
