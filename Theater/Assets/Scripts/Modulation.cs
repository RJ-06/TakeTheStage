using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modulation : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource a;
    public Slider s;
    public bool locked = false;

    [SerializeField] float minPitch;
    [SerializeField] float maxPitch;

    [SerializeField] char key;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        a.pitch = .01f * s.value * (maxPitch - minPitch) + minPitch;



        if (Input.GetMouseButtonDown(0) && locked)
        {
            a.Play();
        }


    }

    public void lockButton()
   {
        locked = !locked;
   }

    
}
