using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientos : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;    
    private BoxCollider2D boxCollider2d;
    Vector3 characterScale;
    float characterScaleX;
    //public GameObject levelCompleteMsg;
    [SerializeField] private Transform levelCompleteMsg;
    bool wasMsgCreated=false;
     float lockPos = 0;
    Collider m_ObjectCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;  

        m_ObjectCollider = GetComponent<Collider>();
        m_ObjectCollider.isTrigger = false;
        Debug.Log("Trigger On : " + m_ObjectCollider.isTrigger);

    }


    
    public LayerMask groundLayers;

    bool isGrounded(){
        Vector2 position=transform.position;
        Vector2 direction = Vector2.down;
        float distance=1.0f;


        //Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position,direction,distance,groundLayers);
        if(hit.collider !=null){
            return true;
        }
        return false;
    }



    // Update is called once per frame
    void Update()
    {
        
        transform.rotation = Quaternion.Euler (lockPos, lockPos, lockPos);

        float h = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftControl))
        {
            
           gameObject.transform.position = new Vector2 (transform.position.x + (h*speed*2),transform.position.y); 
        }else{
             gameObject.transform.position = new Vector2 (transform.position.x + (h*speed),transform.position.y);
        }
       //gameObject.transform.position = new Vector2 (transform.position.x + (h*speed),transform.position.y);
      
        // Move the Character:
        //transform.Translate(Input.GetAxis("Horizontal") * 15f * Time.deltaTime, 0f, 0f);

        // Flip the Character:
        if (Input.GetAxis("Horizontal") < 0) {
            characterScale.x = -characterScaleX;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = characterScaleX;
        }
        transform.localScale = characterScale;

        if (Input.GetKeyDown(KeyCode.Space))
        {   
            if(!isGrounded())
            {
                return;
            }else
            {
                rb.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
            }
           
            
        } 

        

        //Debug.Log(gameObject.transform.position.x);  
        if(gameObject.transform.position.x>=67.2677 && wasMsgCreated==false)
        {
           //Instantiate(levelCompleteMsg,transform.position,Quaternion.identity);
           Instantiate(levelCompleteMsg,new Vector3 (gameObject.transform.position.x-7,3,0),Quaternion.identity); 
           wasMsgCreated=true;
        }

    }
}
