using UnityEngine;

public abstract class BallBehavior : MonoBehaviour
{
    /// <summary>
    /// Швидкість пересування м'яча по осі X.
    /// </summary>
    protected float XSpeed;
    /// <summary>
    /// Швидкість пересування м'яча по осі Y.
    /// </summary>
    protected float YSpeed;
    /// <summary>
    /// Швидкість пересування м'яча по осі Z.
    /// </summary>
    protected float ZSpeed;

    /// <summary>
    /// Значення, що визначає маскимальну позицію м'яча.
    /// </summary>
    protected abstract float TooFar { get; }
    /// <summary>
    /// Множник, який визначає зміну швидкості руху м'яча.
    /// </summary>
    protected abstract float Multiplier { get; }
    /// <summary>
    /// Очки, на які збільшується рахунок гравця при клікові по м'ячу.
    /// </summary>
    protected abstract byte Score { get; }

    /// <summary>
    /// Викликає метод ResetBall для визначення початкової позиції м'яча та його початкових швидкостей руху.
    /// </summary>
    protected void Start()
    {
        ResetBall();
    }
    /// <summary>
    /// Змінює позицію м'яча та переміщує м'яч на іншу позицію при виході за межі максимально дозволених положень.
    /// </summary>
    protected void Update()
    {
        transform.Translate(Time.deltaTime * XSpeed, Time.deltaTime * YSpeed, Time.deltaTime * ZSpeed);
        XSpeed += Multiplier - Random.value * Multiplier * 2;
        YSpeed += Multiplier - Random.value * Multiplier * 2;
        ZSpeed += Multiplier - Random.value * Multiplier * 2;
        if ((Mathf.Abs(transform.position.x) > TooFar)
            || (Mathf.Abs(transform.position.y) > TooFar)
            || (Mathf.Abs(transform.position.z) > TooFar)) ResetBall();
    }
    /// <summary>
    /// Видаляє м'яча та збільшує рахунок гравця при клікові на ньому.
    /// </summary>
    protected virtual void OnMouseDown()
    {
        GameController controller = Camera.main.GetComponent<GameController>();
        if (!controller.GameOver)
        {
            controller.ClickedOnBall(Score);
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// Встановлює м'яча на випадкову позицію в полі зору гравця та задає значення його швидкостей руху.
    /// </summary>
    protected void ResetBall()
    {
        transform.position = new Vector3(3 - Random.value * 6, 3 - Random.value * 6, 3 - Random.value * 6);
        XSpeed = Multiplier - Random.value * Multiplier * 2;
        YSpeed = Multiplier - Random.value * Multiplier * 2;
        ZSpeed = Multiplier - Random.value * Multiplier * 2;
    }
}
