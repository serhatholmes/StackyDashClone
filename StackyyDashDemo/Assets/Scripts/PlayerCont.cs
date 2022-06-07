using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public static PlayerCont instance;
    private Rigidbody rb;
    public float speed;
    public GameObject dashesParent;
    public GameObject prevDash;
    private bool isMoving = false;

    private void Awake() {
        if(instance==null){
            instance=this;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || MobileInput.Instance.swipeLeft && !isMoving){
            isMoving = true;
            rb.velocity = Vector3.left*speed*Time.fixedDeltaTime;
        }

        else if(Input.GetKeyDown(KeyCode.RightArrow) || MobileInput.Instance.swipeRight && !isMoving){
            isMoving = true;
            rb.velocity = Vector3.right*speed*Time.fixedDeltaTime;
        }

        else if(Input.GetKeyDown(KeyCode.UpArrow) || MobileInput.Instance.swipeUp && !isMoving){
            isMoving = true;
            rb.velocity = Vector3.forward*speed*Time.fixedDeltaTime;
        }

        else if(Input.GetKeyDown(KeyCode.DownArrow) || MobileInput.Instance.swipeDown && !isMoving){
            isMoving = true;
            rb.velocity = -Vector3.forward*speed*Time.fixedDeltaTime;
        }

        if(rb.velocity == Vector3.zero){
            isMoving =false;
        }
    }

    public void TakeDashes(GameObject dash){
        dash.transform.SetParent(dashesParent.transform);
        Vector3 pos = prevDash.transform.localPosition;
        pos.y -= 0.07f; 
        dash.transform.localPosition= pos;

        Vector3 charPos=transform.localPosition;
        charPos.y += 0.07f;
        transform.localPosition = charPos;
        prevDash=dash;
        prevDash.GetComponent<BoxCollider>().isTrigger = false;
    }
}
