using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcitementBar : MonoBehaviour
{
    public static float excitementVal = 25;

    [SerializeField] PlayerOne p1;
    [SerializeField] PlayerTwo p2;

    [SerializeField] float maxVal;

    [SerializeField] float interestDecrease;
    public float gameTime = 83;

    public static float timer = 0;

    // Update is called once per frame

    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log("p1 health: " + PlayerOne.health + " p2 health: " + PlayerTwo.health + " excitement: " + excitementVal + " Timer: " + timer);

        gameTime -= Time.deltaTime;

        if (excitementVal > maxVal)
            excitementVal = maxVal;
        if (excitementVal < 0)
            excitementVal = 0;

        if (timer < 1)
        {
            return;
        }
        else { 
            timer = 0;
        }

        excitementVal -= interestDecrease;

        if(p1.rb.velocity.x == 0 || p2.rb.velocity.x == 0)
        {
            excitementVal -= .5f;
        }

        if (PlayerOne.health < 10)
            excitementVal += 2f;
        else if (PlayerOne.health < 20)
            excitementVal += 1f;
        else if (PlayerOne.health < 40)
            excitementVal += .5f;

        if (PlayerTwo.health < 10)
            excitementVal += 2f;
        else if (PlayerTwo.health < 20)
            excitementVal += 1f;
        else if (PlayerTwo.health < 40)
            excitementVal += .5f;

        if (PlayerOne.health < 98)
            PlayerOne.health += 4;
        if(PlayerTwo.health < 98)
            PlayerTwo.health += 4;

        if (gameTime <= 40 && gameTime >= 39)
            interestDecrease += 2;
    }
    
}
