using UnityEngine;

public class Laser : MonoBehaviour
{
    void Start()
    {
        Line = Utility.CreateLine(FirePoint.transform.position, StartWidth, EndWidth);
    }

    void Update()
    {
        Line.SetPosition(0, FirePoint.transform.position);

        Ray ray = Utility.CreateRay(FirePoint.transform.position, FirePoint.transform.forward);

        if (Utility.RaycastCheck(out Hit, ray, MaximumLength))
        {
            Line.SetPosition(1, Hit.point);
        }
        else
        {
            Vector3 position = ray.GetPoint(MaximumLength);
            Line.SetPosition(1, position);
        }
    }

    LineRenderer Line;
    public RaycastHit Hit;
    [SerializeField] float MaximumLength = 10;
    [SerializeField] GameObject FirePoint;
    [SerializeField] float StartWidth = 0.05f;
    [SerializeField] float EndWidth = 0.05f;
}
