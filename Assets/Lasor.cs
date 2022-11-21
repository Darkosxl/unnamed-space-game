using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasor : MonoBehaviour
{
    private float dDistanceRay = 100;
    public Transform laserpoint;
    public LineRenderer linerenderer;
    Transform m_transform;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }
    void Update()
    {
        LasorBeam();
    }
    void LasorBeam()
    {
        if (Physics2D.Raycast(m_transform.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserpoint.position, transform.right);
            Draw2DRay(laserpoint.position, _hit.point);
        }
        else
        {
            Draw2DRay(laserpoint.position, laserpoint.transform.right * dDistanceRay);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Draw2DRay(Vector2 startpos, Vector2 endpos)
    {
        linerenderer.SetPosition(0, startpos);
        linerenderer.SetPosition(1, endpos);
    }
    // Update is called once per frame
    
}
