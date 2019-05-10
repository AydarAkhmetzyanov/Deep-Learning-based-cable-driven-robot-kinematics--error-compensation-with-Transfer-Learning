using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InverseToTransfer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        simulations = new List<GameObject>();
        InvokeRepeating("datasetCollectionPipeline", 1.0f, 25f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool firstrun = true;

    public string FileName;

    public GameObject simulation_env;
    protected List<GameObject> simulations;

    void datasetCollectionPipeline()
    {


        if (!File.Exists(FileName))
        {
            string header = "c1,c2,c3,c4,x,y,z,tx,ty,tz" + Environment.NewLine;

            File.WriteAllText(FileName, header);
        }




        if (firstrun == false)
        {


            foreach (var simulation in simulations)
            {
                //if y>=0 (not on floor)
                if (simulation.GetComponent<Controller>().endAffector.gameObject.transform.localPosition.y > 0)
                {
                    //save position in csv file
                    string data = simulation.GetComponent<Controller>().cable1Length.ToString();
                    data = data + "," + simulation.GetComponent<Controller>().cable2Length.ToString();
                    data = data + "," + simulation.GetComponent<Controller>().cable3Length.ToString();
                    data = data + "," + simulation.GetComponent<Controller>().cable4Length.ToString();

                    data = data + "," + simulation.GetComponent<Controller>().endAffector.transform.localPosition.x;
                    data = data + "," + simulation.GetComponent<Controller>().endAffector.transform.localPosition.y;
                    data = data + "," + simulation.GetComponent<Controller>().endAffector.transform.localPosition.z;

                    data = data + "," + simulation.GetComponent<InverseGeometrical>().inverseTargetX;
                    data = data + "," + simulation.GetComponent<InverseGeometrical>().inverseTargetY;
                    data = data + "," + simulation.GetComponent<InverseGeometrical>().inverseTargetZ;

                    File.AppendAllText(FileName, data + Environment.NewLine);
                }
            }

        }



        //delete simulations
        foreach (var simulation in simulations)
        {
            Destroy(simulation);
        }
        simulations.Clear();
        //init simulations
        for (int x = -5; x < 5; x++)
        {
            for (int y = -4; y < 4; y++)
            {
                simulations.Add(Instantiate(simulation_env, new Vector3(x * 15, 0, y * 15), Quaternion.identity));
            }
        }


        firstrun = false;



    }
}
