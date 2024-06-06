using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is NULL");
            }

            return _instance;
        }

    }

    public bool HasCard { get; set; }
    public PlayableDirector introCutscene;
    public bool _sceneSkipped = false;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && _sceneSkipped == false)
        {
            introCutscene.time = 62.0f;
            _sceneSkipped = true;
        }
    }
}
