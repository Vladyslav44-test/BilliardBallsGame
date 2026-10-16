using UnityEngine;

public class SevenBallBehavior : BallBehavior
{
    protected override float Multiplier { get { return 0.65f; } }
    protected override float TooFar { get { return 12f; } }
    protected override byte Score { get { return 7; } }
}
