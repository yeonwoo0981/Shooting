using UnityEngine;

public class Mission4 : MonoBehaviour
{
    int objSize;
    public float circleR = 1f;
    private float deg;
    public float objSpeed = 140f;
    public GameObject[] target;

    private void Start()
    {
        objSize = target.Length;
        transform.localPosition = Vector3.zero;
    }

    void Update()
    {
        deg += Time.deltaTime * objSpeed;
        if (deg < 360)
        {
            for (int i = 0; i < objSize; i++)
            {
                var rad = Mathf.Deg2Rad * (deg + (i * (360 / objSize)));
                var x = circleR * Mathf.Sin(rad);
                var y = circleR * Mathf.Cos(rad);
                target[i].transform.position = transform.position + new Vector3(x, y);
            }
        }
        else
        {
            deg = 0;
        }
    }
}
