using UnityEngine;

public class StarBallBehavior : BallBehavior
{
    protected override float Multiplier { get { return 1f; } }
    protected override float TooFar { get { return 20f; } }
    protected override byte Score { get { return 15; } }
}
