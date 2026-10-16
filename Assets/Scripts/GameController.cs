using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// Рандомайзер для легкого обрання випадкової заготовки м'яча.
    /// </summary>
    private static readonly System.Random random = new System.Random();
    /// <summary>
    /// Текстовий елемент, що відображає поточні набрані очки.
    /// </summary>
    public Text ScoreText;
    /// <summary>
    /// Кнопка, що запускає нову гру.
    /// </summary>
    public Button PlayAgainButton;
    /// <summary>
    /// Масив найчастіше генерованих м'ячів.
    /// </summary>
    public GameObject[] TheMostOftenBalls = new GameObject[3];
    /// <summary>
    /// Масив середньо генерованих м'ячів. 
    /// </summary>
    public GameObject[] MediumOftenBalls = new GameObject[3];
    /// <summary>
    /// Масив рідко генерованих м'ячів.
    /// </summary>
    public GameObject[] RareBalls = new GameObject[2];
    /// <summary>
    /// Масив найрідкісніших м'ячів.
    /// </summary>
    public GameObject[] TheRarestBalls = new GameObject[2];
    /// <summary>
    /// Поточні набрані очки.
    /// </summary>
    private int Score = 0;
    /// <summary>
    /// Статус гри.
    /// </summary>
    public bool GameOver = true;
    /// <summary>
    /// Поточна кількість м'ячів на екрані. 
    /// </summary>
    private int NumberOfBalls = 0;
    /// <summary>
    /// Максимальна можлива кількість м'ячів на екрані.
    /// </summary>
    private readonly int MaximumBalls = 20;
    /// <summary>
    /// Швидкість генерації нових м'ячів (у секундах).
    /// </summary>
    private readonly float GeneratingSpeed = 2F;

    /// <summary>
    /// Запускає циклічний процес генерації м'ячів.
    /// </summary>
    void Start()
    {
        InvokeRepeating("AddABall", GeneratingSpeed, 1);
    }
    /// <summary>
    /// Виводить поточні набрані очки на екран та виводить кнопку початку нової гри при програші.
    /// </summary>
    void Update()
    {
        ScoreText.text = Score.ToString();
        if (GameOver) PlayAgainButton.gameObject.SetActive(true);
    }
    /// <summary>
    /// Додає новий м'яч на екран (якщо стан гри активний) та переводить гру в стан програшу при перевищенні максимальної кількості м'ячів.
    /// </summary>
    void AddABall()
    {
         if (!GameOver)
        {
            Instantiate(ChooseRandomBallPrefab());
            NumberOfBalls++;
            if (NumberOfBalls >= MaximumBalls)
            {
                GameOver = true;
                PlayAgainButton.gameObject.SetActive(true);
            }
        }
    }
    /// <summary>
    /// Обирає випадкову заготовку для нового м'яча.
    /// </summary>
    /// <returns>Об'єкт-заготовка, з якого буде створено новий м'яч.</returns>
    private GameObject ChooseRandomBallPrefab()
    {
        byte randomNumber = (byte)random.Next(1, 101);
        if (randomNumber <= 10) return TheRarestBalls[random.Next(2)];
        else if (randomNumber <= 30) return RareBalls[random.Next(2)];
        else if (randomNumber <= 50) return MediumOftenBalls[random.Next(3)];
        return TheMostOftenBalls[random.Next(3)];
    }
    /// <summary>
    /// Збільшує набрані очки гравця при натисканню по м'ячі та зменшує загальну кількість м'ячів.
    /// </summary>
    /// <param name="score">Очки, які додаються.</param>
    public void ClickedOnBall(byte score)
    {
        Score += score;
        NumberOfBalls--;
    }
    /// <summary>
    /// Знищує всі м'ячі з екрану, скидає значення полів, прибирає кнопку запуску нової гри та переводить гру в активний стан.
    /// </summary>
    public void StartGame()
    {
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
        {
            Destroy(ball);
        }
        PlayAgainButton.gameObject.SetActive(false);
        Score = 0;
        NumberOfBalls = 0;
        GameOver = false;
    }
}
