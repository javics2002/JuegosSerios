using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    ///     The GameManager instance for the game
    /// </summary>
    public static GameManager Instance { get; private set; }

    public bool isArrowVisible;
	public bool isDragging;
	public GameObject draggedObject;

    #region Progreso
    public enum LevelCompletion { Locked, Uncompleted, Completed, Par, HoleInOne };

    public const int numberOfLevels = 100;
    public LevelCompletion[] levelCompletion;
    #endregion

    private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}

		Instance.Init();
	}

    private void Init()
	{
		isDragging = false;
        isArrowVisible = false;
		draggedObject = null;

        LoadManager.Instance.Load();
    }

    public void Save()
    {
        LoadManager.Instance.Save();
    }

	public void DragObject(GameObject dragObject)
	{
        draggedObject = dragObject;
		isDragging = true;
    }
    public void DropObject()
    {
        draggedObject = null;
        isDragging = false;
    }

    /// <summary>
    ///     Applies a force to the ball given a <paramref name="rotation" /> in degrees.
    /// </summary>
    /// <param name="rotation">The amount of degrees</param>
    /// <param name="force">The amount of force that should be applied</param>
    //   public void ApplyForceToBall(float rotation, float force)
    //{
    //	var radians = rotation * Mathf.Deg2Rad;
    //	_playerRigidBody.AddForce(new Vector2(Mathf.Cos(radians) * force, Mathf.Sin(radians) * force));
    //}
}