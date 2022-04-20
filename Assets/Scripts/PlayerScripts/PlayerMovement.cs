using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerMovement : SingletonGeneric<PlayerMovement>
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    [SerializeField] CircleCollider2D rebBallCollider;
    [SerializeField] CircleCollider2D blueBallCollider;


    Rigidbody2D rb;
    Vector3 startPosition;
    Camera cam;
    float touchPosX;

    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChange += OnGameStateChange;
    }

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        moveUp();

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameOver)
        {

            if (Input.GetMouseButtonDown(0))
                touchPosX = cam.ScreenToWorldPoint(Input.mousePosition).x;


            if (Input.GetMouseButton(0))
            {

                if (touchPosX > 0.001f)
                {
                    RotateRight();
                }
                else
                {
                    RotateLeft();
                }

            }
            else
            {
                rb.angularVelocity = 0;
            }

#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                RotateLeft();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                RotateRight();
            }

            if ((Input.GetKeyUp(KeyCode.LeftArrow)) || (Input.GetKeyUp(KeyCode.RightArrow)))
            {
                rb.angularVelocity = 0;
            }
        }
#endif

    }

    void moveUp()
    {
        rb.velocity = Vector2.up * speed;
    }
    void RotateLeft()
    {
        rb.angularVelocity = rotationSpeed;
    }
    void RotateRight()
    {
        rb.angularVelocity = -rotationSpeed;
    }
    public void Restart()
    {
        rebBallCollider.enabled = false;
        blueBallCollider.enabled = false;
        rb.angularVelocity = 0;
        rb.velocity = Vector2.zero;

        transform.DORotate(Vector3.zero, 1f)
              .SetDelay(1f)
              .SetEase(Ease.InOutBack);

        transform
            .DOMove(startPosition, 1f)
            .SetDelay(1f)
            .SetEase(Ease.InOutFlash)

            .OnComplete(() =>
            {
                rebBallCollider.enabled = true;
                blueBallCollider.enabled = true;

                GameManager.Instance.isGameOver = false;
                moveUp();
            });


    }
    private void OnGameStateChange(GameState newGameState)
    {
        enabled = newGameState == GameState.GamePlay;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LevelEnd"))
        {
            Debug.Log("Level Complete");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

