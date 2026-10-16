using UnityEngine;

public class OneBallBehavior : BallBehavior
{
    protected override float Multiplier { get { return 0.75f; } }
    protected override float TooFar { get { return 5f; } }
    protected override byte Score { get { return 1; } }
}
