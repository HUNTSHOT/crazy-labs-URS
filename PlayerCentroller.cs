using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCentroller :MonoBehaviour {
    #region vars
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;
    [SerializeField] float lineDestans;
    [SerializeField] float jumpForce;
    [SerializeField] float gravity;
    [SerializeField] Material slideM;
    [SerializeField] Material walking;
    [SerializeField] float slideTime;
    [SerializeField] Transform bullet;
    [SerializeField] Transform firePos;
    [SerializeField] float fireRate;

    int deseiredLine;
    CharacterController CharacterController;
    Vector3 Dir;
    Vector3 targetPos;
    bool slidding;
    Renderer ren;
    Vector3 slideC= new Vector3(0, -0.5f, 0);
    Vector3 walkC = new Vector3(0, 0, 0);
    float slideH=0.4f;
    float walkH = 2.18f;
    bool fired;
    float playerBaseSpeed=15f;
    float playerBaseFireRate=1f;

    #endregion
    
    void Start() {
        deseiredLine=1;
        CharacterController=GetComponent<CharacterController>();
        ren=GetComponent<Renderer>();
        Dir.z=speed;
        targetPos=transform.position.z*transform.forward+transform.position.y*transform.up;
        fired=false;
    } 
    void Update() {
        Dir.z=speed;      
        Dir.y+=gravity*Time.deltaTime;
        if(speed<maxSpeed) speed+=0.1f*Time.deltaTime;
        if(Input.GetMouseButtonDown(0)) fire();//textting
    }
    void FixedUpdate()
    {
        CharacterController.Move(Dir*Time.deltaTime);
    }  

    #region base voids
    void swichLine() {        
            targetPos=transform.position.z*transform.forward+transform.position.y*transform.up;
            switch(deseiredLine) {
                case 0: transform.position=Vector3.Lerp(transform.position, targetPos+=Vector3.left*lineDestans, 80); break;
                case 1: transform.position=Vector3.Lerp(transform.position, targetPos, 80); break;
                case 2: transform.position=Vector3.Lerp(transform.position, targetPos+=Vector3.right*lineDestans, 80); break;
                default: break;
            }
            CharacterController.center=CharacterController.center;        
    }
    void turn() {
        if(deseiredLine>2) deseiredLine=2;
        if(deseiredLine<0) deseiredLine=0;
        swichLine();  
    }
    public void jump() {
        if(chech()) Dir.y=jumpForce;
    }
    public void fire() {
        if(chech()&&!fired)
            StartCoroutine(ifire());
    }
    public void left() {
        if(chech()) deseiredLine++;
        turn();
    }
    public void right() {
        if(chech()) deseiredLine--;
        turn();
    }
    public void slide() {
        if(chech()) StartCoroutine(iSlide());
    }
    IEnumerator iSlide() {
        slidding=true;
        ren.material=slideM;
        CharacterController.center=slideC;
        CharacterController.height=slideH;
        yield return new WaitForSeconds(slideTime);
        CharacterController.center=walkC;
        CharacterController.height=walkH;
        ren.material=walking;
        slidding=false;
    }
    IEnumerator ifire() {
        fired=true;
        Instantiate(bullet, firePos.position, Quaternion.identity);
        yield return new WaitForSeconds(fireRate);
        fired=false;
    }
    public void changePorams(float playerSpeed,float playerFireRate) {
        speed=playerSpeed;
        fireRate=playerFireRate;
    }
    public void resetPlayerPorams() {
        speed=playerBaseSpeed;
        fireRate=playerBaseFireRate;
    }

    #endregion
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.transform.tag=="obstecal"||hit.transform.tag=="enemy") {
            gameManager.gameIsRunning=false;
        }
    }
    bool chech() {
        return (CharacterController.isGrounded&&!slidding&&gameManager.gameIsRunning);
    }


}
