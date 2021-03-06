﻿using HK.Framework.EventSystems;
using Quant.Events;
using UnityEngine;
using UnityEngine.Assertions;

namespace Quant.Task
{
    /// <summary>
    /// カメラが追従するオブジェクトをプレイヤーに戻すタスク
    /// </summary>
    public sealed class SetCameraPropertyRevertLookAt : TaskMonoBehavior
    {
        public override void Invoke()
        {
            var property = new OverrideCameraProperty();
            property.LookAt.CanApply = true;
            property.LookAt.Value = GameEnvironment.Instance.Player.transform;
            Broker.Global.Publish(RequestOverrideCameraProperty.Get(property));
        }
    }
}
