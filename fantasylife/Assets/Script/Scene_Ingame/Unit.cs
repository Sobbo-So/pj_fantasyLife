using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public static class State {
        public const int IDLE = 0;
        public const int WALK = 1;
        public const int ACT_ETC = 2;
        public const int SLEEP = 3;
    }

    // SETTING
    public Animator animator;
    public float nextActTime = 5;


    // PRIVATE
    private int _state;
    private float _nextActTimer;

    public void Awake() {
        _state = State.IDLE;
    }

    public void FixedUpdate() {
        _nextActTimer += Time.deltaTime;
        if (_nextActTimer >= nextActTime) {
        }
    }

    public void ChangeAct(int state) {
        animator.SetInteger("State", state);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
