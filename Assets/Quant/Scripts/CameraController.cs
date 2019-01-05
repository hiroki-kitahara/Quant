﻿using HK.Framework.EventSystems;
using Quant.Events;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Assertions;

namespace Quant
{
    /// <summary>
    /// ゲーム中のカメラを制御するクラス
    /// </summary>
    public sealed class CameraController : MonoBehaviour
    {
        private Vector3 currentPosition = Vector3.zero;

        [SerializeField]
        private float positionSmoothDamp = 1.0f;

        private void Awake()
        {
            Broker.Global.Receive<SpawnedPlayerActor>()
                .SubscribeWithState(this, (x, _this) => _this.Setup(x.Actor))
                .AddTo(this);
        }

        private void Setup(Actor actor)
        {
            this.FixedUpdateAsObservable()
                .SubscribeWithState2(this, actor, (_, _this, _actor) =>
                {
                    var cameraman = Cameraman.Instance;
                    cameraman.Position = Vector3.SmoothDamp(cameraman.Position, _actor.transform.position, ref _this.currentPosition, _this.positionSmoothDamp);
                });
        }
    }
}
