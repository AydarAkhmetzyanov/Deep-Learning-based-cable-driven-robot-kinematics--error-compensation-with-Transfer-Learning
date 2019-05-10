using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerConfigurable : MonoBehaviour
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
    private const float limitCoef = 1f;
    private const float limitLin = 0.7f;





    // Start is called before the first frame update
    void Start()
    {



        //var testPassed = false;
        //while (testPassed == false)
        //{
        //    testPassed = true;
        //    cable1Length = Random.Range(1f, 10f);
        //    cable2Length = Random.Range(1f, 10f);
        //    cable3Length = Random.Range(1f, 10f);
        //    cable4Length = Random.Range(1f, 10f);

        //    if ((cable1Length + cable4Length) < 8.5) testPassed = false;
        //    if ((cable2Length + cable3Length) < 8.5) testPassed = false;

        //    if ((cable1Length + cable3Length) < 4.5) testPassed = false;
        //    if ((cable2Length + cable4Length) < 4.5) testPassed = false;

        //    if ((cable1Length + cable2Length) < 8.5) testPassed = false;
        //    if ((cable3Length + cable4Length) < 8.5) testPassed = false;

        //}


        //this.Update();



    }

    // Update is called once per frame
    void Update()
    {




        cable1.GetComponent<CableComponent>().cableLength = this.cable1Length / visualLengthCoef;
        cable2.GetComponent<CableComponent>().cableLength = this.cable2Length / visualLengthCoef;
        cable3.GetComponent<CableComponent>().cableLength = this.cable3Length / visualLengthCoef;
        cable4.GetComponent<CableComponent>().cableLength = this.cable4Length / visualLengthCoef;

        SoftJointLimit softJointLimit1 = new SoftJointLimit();
        softJointLimit1.limit = (this.cable1Length * limitCoef) - limitLin;
        SoftJointLimit softJointLimit2 = new SoftJointLimit();
        softJointLimit2.limit = (this.cable2Length * limitCoef) - limitLin;
        SoftJointLimit softJointLimit3 = new SoftJointLimit();
        softJointLimit3.limit = (this.cable3Length * limitCoef) - limitLin;
        SoftJointLimit softJointLimit4 = new SoftJointLimit();
        softJointLimit4.limit = (this.cable4Length * limitCoef) - limitLin;

        cable1.GetComponent<ConfigurableJoint>().linearLimit = softJointLimit1;
        cable2.GetComponent<ConfigurableJoint>().linearLimit = softJointLimit2;
        cable3.GetComponent<ConfigurableJoint>().linearLimit = softJointLimit3;
        cable4.GetComponent<ConfigurableJoint>().linearLimit = softJointLimit4;

    }
}
