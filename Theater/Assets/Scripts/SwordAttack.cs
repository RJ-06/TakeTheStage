using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] PlayerOne p1;
    [SerializeField] PlayerTwo p2;
    [SerializeField] int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("what the hell >:(");
        if (col.gameObject.tag == "PlayerOne")
        {
            if (!p1.guarding)
            {
                PlayerOne.health -= damage;
            }
        }
        else if (col.gameObject.tag == "PlayerTwo") {
            if (!p2.guarding)
            {
                PlayerTwo.health -= damage;
            }
        }
    }

}
