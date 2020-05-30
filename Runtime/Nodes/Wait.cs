﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBT
{
    [AddComponentMenu("")]
    [MBTNode(name = "Tasks/Wait")]
    public class Wait : Leaf
    {
        [Tooltip("Wait time in seconds")]
        public float time = 1f;
        public bool continueOnRestart = false;
        private float timer;
        
        public override void OnEnter()
        {
            if (!continueOnRestart) {
                timer = 0;
            }
        }

        public override NodeResult Execute()
        {
            timer += Time.deltaTime;
            if (timer > time) {
                // Reset timer in case continueOnRestart option is active
                timer = 0;
                return NodeResult.success;
            }
            return NodeResult.running;
        }
    }
}
