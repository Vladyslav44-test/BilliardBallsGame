using UnityEngine;

public class OneBallBehavior : BallBehavior
{
    protected override float Multiplier { get { return 0.75f; } }
    protected override byte Score { get { return 1; } }
}
