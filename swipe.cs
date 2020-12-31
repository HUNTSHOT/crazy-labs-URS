using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe : MonoBehaviour
{
    [SerializeField] float minamlMovement;
    [SerializeField] float doubleTapTime;

    bool tap, doubleTap, isDragging;
    Vector2 firstTouch, moveInfo ;
    float lastTapTime,thisTapTime;
    PlayerCentroller player;

    private void Start() {
        reset();
        player=FindObjectOfType<PlayerCentroller>();
    }
    private void Update() {
        if(gameManager.gameIsRunning) {
            if(doubleTap) player.fire();
            tap=doubleTap=false;
            if(Input.touches.Length!=0) {
                if(Input.touches[0].phase==TouchPhase.Began) {
                    Tap();
                    firstTouch=Input.touches[0].position;
                } else if(Input.touches[0].phase==TouchPhase.Ended||Input.touches[0].phase==TouchPhase.Canceled) {
                    reset();
                }
            }
            if(isDragging) {
                if(Input.touches.Length>0)
                    moveInfo=Input.touches[0].position-firstTouch;
            }
            if(moveInfo.magnitude>minamlMovement) {
                float dirX = moveInfo.x;
                float dirY = moveInfo.y;
                if(Mathf.Abs(dirX)>Mathf.Abs(dirY)) {
                    if(dirX>0) player.left();
                    else player.right();
                } else {
                    if(dirY<0) player.slide();
                    else player.jump(); ;
                }
                reset();
            }
        }
    }
    private void reset() {
        isDragging=false;
        firstTouch=moveInfo=Vector2.zero;
    }
    void Tap() {
        tap=true;
        isDragging=true;
        thisTapTime=Time.time-lastTapTime;
        doubleTap=doubleTapTime>thisTapTime;
        lastTapTime=Time.time;
    }
}
