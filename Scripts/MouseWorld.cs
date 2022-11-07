using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    public static MouseWorld Instance;


    [SerializeField] private LayerMask mousePlaneLayerMask;


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        transform.position = MouseWorld.GetPosition();
    }

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.GetMouseWorldPosition());
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, Instance.mousePlaneLayerMask);
        return raycastHit.point;
    }

}
