using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcitementBar : MonoBehaviour
{
    public static float excitementVal = 0;

    [SerializeField] PlayerOne p1;
    [SerializeField] PlayerTwo p2;

    [SerializeField] float maxVal;

    // Update is called once per frame
    void Update()
    {
        excitementVal -= 3 * (int)Time.deltaTime;

        //high ground
        if (p1.rb.velocity.x != 0 && p2.rb.velocity.x != 0)
        {
            excitementVal += .5f * (int)Time.deltaTime;
        }
        else if(p1.rb.velocity.x == 0 && p2.rb.velocity.x == 0)
        {
            excitementVal -= .5f * (int)Time.deltaTime;
        }

        if (PlayerOne.health < 10)
            excitementVal += 7;
        else if (PlayerOne.health < 20)
            excitementVal += 5;
        else if (PlayerOne.health < 40)
            excitementVal += 3;

        if (PlayerTwo.health < 10)
            excitementVal += 7;
        else if (PlayerTwo.health < 20)
            excitementVal += 5;
        else if (PlayerTwo.health < 40)
            excitementVal += 3;

        if(excitementVal > maxVal)
            excitementVal = maxVal;

        Debug.Log("p1 health: " + PlayerOne.health + "p2 health: " + PlayerTwo.health + "excitement: " + excitementVal);

    }
    
}
