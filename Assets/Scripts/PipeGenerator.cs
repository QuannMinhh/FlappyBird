using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public GameObject pipePrefab;
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    private float countdown;
    public float timeDuration;
    public bool enableGeneratePipe;
    
    private void Awake()
    {
        countdown = timeDuration;
        enableGeneratePipe = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (enableGeneratePipe == true) 
        {
            countdown -= Time.deltaTime; //moi frame tru di ga tri bang 1/fps
                                         //30 fps: moi frame countdown giam di 1/30s, moi giay (30 frames) thi countdown giam di dung 1
            if (countdown <= 0)
            {
                //Sinh ra ong
                //Debug.Log("Sinh ra ong");
                Instantiate(pipePrefab, new Vector3(2.5f, Random.Range(-1.5f, 3), 0), Quaternion.identity);
                countdown = timeDuration;
            }
        }
    }
}
