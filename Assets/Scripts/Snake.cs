using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Snake : MonoBehaviour
{
    private Vector2Int snakePosition;
    private Vector2Int direction;
    private int speed = 4;
    private List<Transform> bodyList;
    public Transform bodyPart;

    public static int score;
    private static int maxScore;


    [SerializeField] private TextMeshProUGUI txtScore;


    private void Awake()
    {
        snakePosition.Set(5, 5);
        direction = Vector2Int.up;
        Time.fixedDeltaTime = 0.2f;
        score = 0;
        maxScore = GameController.getPref("Score");

        bodyList = new List<Transform>();
        bodyList.Add(this.transform);
    }

    private void Update()
    {
        userControl();
    }

    private void FixedUpdate()
    {

        snakeMovement();
    }

    private void userControl()
    {
        if (Input.GetKeyDown(KeyCode.W) && !direction.Equals(Vector2Int.down))
        {
            direction = Vector2Int.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && !direction.Equals(Vector2Int.up))
        {
            direction = Vector2Int.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) && !direction.Equals(Vector2Int.right))
        {
            direction = Vector2Int.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && !direction.Equals(Vector2Int.left))
        {
            direction = Vector2Int.right;
        }

    }

    private void snakeMovement()
    {

        // Update body part position
        for (int i = bodyList.Count - 1; i > 0; i--)
        {
            bodyList[i].position = bodyList[i - 1].position;
        }

        // Update head position
        transform.position = new Vector3(transform.position.x + direction.x * speed, transform.position.y + direction.y * speed);
        transform.eulerAngles = new Vector3(0, 0, getAngle(direction) - 90);
    }

    private void growBody()
    {

        Transform newBody = Instantiate(this.bodyPart);
        Transform lastBodyPart = bodyList[bodyList.Count - 1];

        newBody.position = new Vector3(lastBodyPart.position.x, lastBodyPart.position.y);
        Debug.Log(newBody.position);
        bodyList.Add(newBody);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "food")
        {
            growBody();
            score += 1;
            txtScore.text = ("Score: " + score.ToString());
        } else if (collision.CompareTag("Wall") || collision.CompareTag("Snake Body"))
        {
            if (score > maxScore) maxScore = score;
            GameController.setPref("Score", maxScore);
            SceneManager.LoadScene(0);
        }
    }

    private float getAngle(Vector2Int direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360;
        return angle;
    }

    public static int getMaxScore()
    {
        return maxScore;
    }

    public static void setScore(int score)
    {
        maxScore = score;
    }

}
