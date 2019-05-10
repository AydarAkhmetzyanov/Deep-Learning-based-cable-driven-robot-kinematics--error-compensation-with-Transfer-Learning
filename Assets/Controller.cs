using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public GameObject cable1;
    public GameObject cable2;
    public GameObject cable3;
    public GameObject cable4;
    public GameObject endAffector;
    public GameObject cableEnd;

    [Range(0.1f,10f)]
    public float cable1Length;
    [Range(0.1f, 10f)]
    public float cable2Length;
    [Range(0.1f, 10f)]
    public float cable3Length;
    [Range(0.1f, 10f)]
    public float cable4Length;



    private const float visualLengthCoef = 1.5f;

    public float maxDistCoeficient1 = 1f;
    public float maxDistCoeficient2 = 1f;
    public float maxDistCoeficient3 = 1f;
    public float maxDistCoeficient4 = 1f;
    public float springStiffness = 10000f;

    // Start is called before the first frame update
    void Start()
    {

        cable1.GetComponent<SpringJoint>().spring = springStiffness;
        cable2.GetComponent<SpringJoint>().spring = springStiffness;
        cable3.GetComponent<SpringJoint>().spring = springStiffness;
        cable4.GetComponent<SpringJoint>().spring = springStiffness;

        this.cable1Length = Vector3.Distance(cable1.transform.localPosition, cableEnd.transform.localPosition);
        this.cable2Length = Vector3.Distance(cable2.transform.localPosition, cableEnd.transform.localPosition);
        this.cable3Length = Vector3.Distance(cable3.transform.localPosition, cableEnd.transform.localPosition);
        this.cable4Length = Vector3.Distance(cable4.transform.localPosition, cableEnd.transform.localPosition);

        this.Update();

    }

    // Update is called once per frame
    void Update()
    {

        cable1.GetComponent<CableComponent>().cableLength = this.cable1Length / visualLengthCoef;
        cable2.GetComponent<CableComponent>().cableLength = this.cable2Length / visualLengthCoef;
        cable3.GetComponent<CableComponent>().cableLength = this.cable3Length / visualLengthCoef;
        cable4.GetComponent<CableComponent>().cableLength = this.cable4Length / visualLengthCoef;

        cable1.GetComponent<SpringJoint>().maxDistance = this.cable1Length * maxDistCoeficient1;
        cable2.GetComponent<SpringJoint>().maxDistance = this.cable2Length * maxDistCoeficient2;
        cable3.GetComponent<SpringJoint>().maxDistance = this.cable3Length * maxDistCoeficient3;
        cable4.GetComponent<SpringJoint>().maxDistance = this.cable4Length * maxDistCoeficient4;

        //cable1.GetComponent<SpringJoint>().minDistance = this.cable1Length * (float)1;
        //cable2.GetComponent<SpringJoint>().minDistance = this.cable2Length * (float)1;
        //cable3.GetComponent<SpringJoint>().minDistance = this.cable3Length * (float)1;
        //cable4.GetComponent<SpringJoint>().minDistance = this.cable4Length * (float)1;

    }
}
