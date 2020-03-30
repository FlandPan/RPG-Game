using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScript : MonoBehaviour
{
    public GameObject hero;
    public GameObject addProj;
    public GameObject minusProj;
    public GameObject multProj;
    public GameObject divProj;
    private Vector3 _aimVector;
    private Vector3 _aimRoundVector;
    private int _roundCount = 0;

    // Update is called once per frame
    void Update()
    {

        _aimRoundVector = new Vector3(5*Mathf.Sin(_roundCount%360),5*Mathf.Cos(_roundCount%360),0);

        _roundCount++;

        GameObject circleProj = Instantiate(addProj);
        circleProj.transform.position = transform.position;
        RigidBody2D rb = circleProj.GetComponenet<RigidBody2D>();
        rb.AddForce(_aimRoundVector,ForceMode2D.Impulse);



    }
    float unitVector(Vector3 num)
    {
        return Mathf.Sqrt(num.x*num.x+num.y*num.y+num.z+num.z);
    }
}
