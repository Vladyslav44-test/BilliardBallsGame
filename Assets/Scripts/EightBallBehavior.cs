using UnityEngine;

public class EightBallBehavior : BallBehavior
{
    protected override float Multiplier { get { return 0.4f; } }
    protected override float TooFar { get { return 12f; } }
    protected override byte Score { get { return 8; } }
}
