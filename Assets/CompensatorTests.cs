using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CompensatorTests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        simulations = new List<GameObject>();
        InvokeRepeating("datasetCollectionPipeline", 1.0f, 25f);
    }
    private bool firstrun = true;

    public GameObject simulation_env;
    protected List<GameObject> simulations;

    // Update is called once per frame
    void Update()
    {
        
    }


    void datasetCollectionPipeline()
    {
        string FileName = "compensations.csv";
        if (!File.Exists(FileName))
        {
            string header = "c1,c2,c3,c4,x,y,z,tx,ty,tz" + Environment.NewLine;

            File.WriteAllText(FileName, header);
        }



    }

}
