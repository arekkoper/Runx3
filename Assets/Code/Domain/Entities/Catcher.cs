
using Assets.Code.Domain.Enums;
using UnityEngine;

namespace Assets.Code.Domain.Entities
{
    public class Catcher
    {
        public int Id { get; set; }
        public float Speed { get; set; }
        public float MinRetargetInterval { get; set; }
        public float MaxRetargetInterval { get; set; }
        public float RotationTime { get; set; }
        public float PostRotationWaitTime { get; set; }
        public CatcherState State { get; set; }
        public Vector3 CurrentTarget { get; set; }
        public Quaternion InitialRotation { get; set; }
        public Quaternion TargetRotation { get; set; }
        public float RotationStartTime { get; set; }

    }
}