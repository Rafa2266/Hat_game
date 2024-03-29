using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float topDistance, lateralMargin;
    [SerializeField] private Transform allBallsParent;
    private Vector2 screenWidth;
    private GameController gameController;

    private void Awake()
    {
        Initialize();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameController= FindObjectOfType<GameController>();
        InvokeRepeating("SpawnInvoke",2.0f,Random.Range(1.0f,2.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialize()
    {
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.safeArea.width, Screen.safeArea.height));
        Vector2 heightPosition = new Vector2(transform.position.x, Camera.main.orthographicSize +topDistance);
        transform.position = heightPosition;
    }
    private void SpawnInvoke()
    {
        if(gameController.gameStarted)
        {
            StartCoroutine(Spawn());
        }
        
    }
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0f);
        transform.position=new Vector2(Random.Range(-screenWidth.x + lateralMargin,screenWidth.x - lateralMargin),transform.position.y);
        GameObject tempBallPrefab= Instantiate(ballPrefab,transform.position,Quaternion.identity) as GameObject;
        tempBallPrefab.transform.parent = allBallsParent;
    }
}
