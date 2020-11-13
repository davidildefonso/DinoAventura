using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDino : MonoBehaviour
{

    private  Animator anim;


    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                anim.SetBool("corriendo", true);   
            } else{
                anim.SetBool("corriendo", false);
            }   
            anim.SetBool("caminando", true);
        }else if(Input.GetKey(KeyCode.LeftArrow)){
            if(Input.GetKey(KeyCode.LeftControl))
            {
                anim.SetBool("corriendo", true);   
            } else{
                anim.SetBool("corriendo", false);
            } 


            anim.SetBool("caminando",true);
        }else{
            anim.SetBool("caminando",false);
            anim.SetBool("corriendo", false);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("saltando");
        }
    }
}
