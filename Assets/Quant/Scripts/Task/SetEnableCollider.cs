﻿using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Quant.Task
{
    /// <summary>
    /// 対象のコライダーのアクティブフラグを設定するタスク
    /// </summary>
    public sealed class SetEnableCollider : TaskMonoBehavior
    {
        [SerializeField]
        private Parameter[] parameters = null;

        public override void Invoke()
        {
            foreach(var p in this.parameters)
            {
                p.Invoke();
            }
        }

        [Serializable]
        public class Parameter
        {
            [SerializeField]
            private GameObject target = null;

            [SerializeField]
            private bool isEnable = false;

            public void Invoke()
            {
                foreach(var c in this.target.GetComponents<Collider>())
                {
                    c.enabled = this.isEnable;
                }
            }
        }
    }
}
