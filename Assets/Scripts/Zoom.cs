using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{

    Vector3 touch;

    public new Camera camera;
    public GameObject cam;
    

    public float zoomMin = 1f;
    public float zoomMax = 4f;

    [Header("Position Camera")]

    public static Zoom Instance;
    
    [SerializeField]public Vector3[] parameter;


    [SerializeField] SpriteRenderer mapRender;
    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {


        
    }


    //Position Camera
    public void SetPossition(int index)
    {
        camera.transform.position = parameter[index];
        camera.orthographicSize = 1.95f;
        camera.gameObject.SetActive(true);
    }

    //Reset Position Camera
    public void CameraDetalReset()
    {
        camera.transform.position = new Vector3(4, 8, -10);
        camera.orthographicSize = 8;
    }

    // Update is called once per frame
    void Update()
    {



        mapMinX = mapRender.transform.position.x - mapRender.bounds.size.x /2;
        mapMaxX = mapRender.transform.position.x + mapRender.bounds.size.x /2;

        mapMinX = mapRender.transform.position.y - mapRender.bounds.size.y /2;
        mapMaxY = mapRender.transform.position.y + mapRender.bounds.size.y /2;




        
        if (Input.GetMouseButtonDown(0))
        {
            touch = camera.ScreenToWorldPoint(Input.mousePosition);
        }

        


        //Zoom touch
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroLastPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOneLastPos = touchOne.position - touchOne.deltaPosition;

            float distTouch = (touchZeroLastPos - touchOneLastPos).magnitude;
            float curentDistTouch = (touchZero.position - touchOne.position).magnitude;

            float difference = curentDistTouch - distTouch;

            ZoomMap(difference * 0.01f);
        }

        //Move X and Y
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touch - camera.ScreenToWorldPoint(Input.mousePosition);
            //camera.transform.position += direction;

            if (camera.orthographicSize < 8f)
            {
                camera.transform.position = ClampCamera(camera.transform.position + direction);
            }
            
        }
        //Reset
        if (camera.orthographicSize >= 8f)
        {
            CameraDetalReset();
        }

        //Zoom
        ZoomMap(Input.GetAxis("Mouse ScrollWheel"));
    }

    //Zoom Map
    public void ZoomMap(float increment)
    {

        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize - increment, zoomMin, zoomMax);
        camera.transform.position = ClampCamera(camera.transform.position);
    }

    //Zone Map
    private Vector3 ClampCamera(Vector3 targetPosition)
    {

        float camHeight = camera.orthographicSize;
        float camWhidth = camera.orthographicSize * camera.aspect;

        float minX = mapMinX + camWhidth;
        float maxX = mapMaxX - camWhidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
}
