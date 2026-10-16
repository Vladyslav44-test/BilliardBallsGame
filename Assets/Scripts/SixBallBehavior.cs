using UnityEngine;

public class SixBallBehavior : BallBehavior
{
    protected override float Multiplier { get { return 0.7f; } }
    protected override float TooFar { get { return 8.5f; } }
    protected override byte Score { get { return 6; } }
}
