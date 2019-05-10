using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseGeometrical : MonoBehaviour
{

    [Range(-3.7f, 3.7f)]
    public float inverseTargetX;
    [Range(0f, 2f)]
    public float inverseTargetY;
    [Range(-1.2f, 1.2f)]
    public float inverseTargetZ;

    // Start is called before the first frame update
    void Start()
    {

        inverseTargetX = Random.Range(-3.7f, 3.7f);
        inverseTargetY = Random.Range(0f, 2f);
        inverseTargetZ = Random.Range(-1.2f, 1.2f);

    }

    // Update is called once per frame
    void Update()
    {




        var targetvector = new Vector3(inverseTargetX, inverseTargetY + 0.3f, inverseTargetZ); //end affector!=cableend

        this.GetComponent<Controller>().cable1Length = Vector3.Distance(this.GetComponent<Controller>().cable1.transform.localPosition, targetvector);
        this.GetComponent<Controller>().cable2Length = Vector3.Distance(this.GetComponent<Controller>().cable2.transform.localPosition, targetvector);
        this.GetComponent<Controller>().cable3Length = Vector3.Distance(this.GetComponent<Controller>().cable3.transform.localPosition, targetvector);
        this.GetComponent<Controller>().cable4Length = Vector3.Distance(this.GetComponent<Controller>().cable4.transform.localPosition, targetvector);



    }

}
