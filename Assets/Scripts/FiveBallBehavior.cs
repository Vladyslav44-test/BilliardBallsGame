using UnityEngine;

public class FiveBallBehavior : BallBehavior
{
    protected override float Multiplier { get { return 0.55f; } }
    protected override float TooFar { get { return 8.5f; } }
    protected override byte Score { get { return 5; } }
}
