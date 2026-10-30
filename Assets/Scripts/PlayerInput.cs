using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static readonly string RotateAxis = "MousePoint";
    public static readonly string FireAxis = "Fire1";
    public static readonly string ReloadAxis = "Reload";

    public float Rotate {get; private set;}
   public bool Fire {get; private set;}
   public bool Reload {get; private set;}

    private void OnDisable()
    {
        Rotate = 0;
        Fire = false;
        Reload = false;
    }

    private void Update()
    {
        Fire = Input.GetButton(FireAxis);
        Reload = Input.GetButtonDown(ReloadAxis);
    }

}
