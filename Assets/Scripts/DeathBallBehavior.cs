using Unity.VisualScripting;
using UnityEngine;

public class DeathBallBehavior : BallBehavior
{
    protected override float Multiplier { get { return 0.4f; } }
    protected override float TooFar { get { return 5f; } }
    protected override byte Score { get { return 0; } }

    /// <summary>
    /// Видаляє м'яча та відразу завершує гру.
    /// </summary>
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        GameController controller = Camera.main.GetComponent<GameController>();
        controller.GameOver = true;
    }
}
