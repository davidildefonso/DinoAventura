using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    [SerializeField] private Transform levelCompleteMsg;

    // Start is called before the first frame update
    void Start()
    {
        
        Instantiate(levelCompleteMsg,Vector3.zero,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
