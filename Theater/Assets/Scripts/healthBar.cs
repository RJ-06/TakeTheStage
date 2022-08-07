using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] Image hBar1;
    [SerializeField] Image hBar2;
    [SerializeField] Image excitement;
    private float maxH = 100;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hBar1.fillAmount = PlayerOne.health / maxH;
        hBar2.fillAmount = PlayerTwo.health / maxH;
        excitement.fillAmount = ExcitementBar.excitementVal / 100;
    }
}
