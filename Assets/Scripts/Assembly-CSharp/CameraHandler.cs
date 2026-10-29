using UnityEngine;

public class CameraHandler : MonoBehaviour
{
	[Header("Kamera Ayarlar\ufffd")]
	public float minZ=-219.8000030517578f;

	public float maxZ=220f;

	public float smoothSpeed=20f;

	public float dragMultiplier=10f;

	[Header("Drag Hassasiyeti")]
	public float dragThreshold=6f;

	public float targetZ;

	private float dragStartZ;

	private Vector3 dragStartWorldPos;

	private Vector3 dragStartScreenPos;

	private bool isDragging;

	private bool dragStarted;

	public Camera camera;

	public bool draggingInfo;

	private void Start()
	{
		// Recovered from original ARM64 0x21ccb28.
		camera.orthographic = true; camera.orthographicSize = 71.19999694824219f; ResetCameraPosition();
	}

	public void GameIn()
	{
		// Recovered from original ARM64 0x21ccbdc.
		camera.fieldOfView=19f; Vector3 p=transform.position; transform.position=new Vector3(p.x,p.y,-255f); targetZ=-255f; camera.orthographic=false; camera.orthographicSize=71.19999694824219f;
	}

	private void ResetCameraPosition()
	{
		// Recovered from original ARM64 0x21ccb6c.
		Vector3 p = transform.position; transform.position = new Vector3(p.x,p.y,minZ); targetZ=minZ;
	}

	private void Update()
	{
		// Recovered from original ARM64 0x21ccc88.
		if(GecisControl.savastayim || GameManager.guidecamera) return;
		if(Input.GetMouseButtonDown(0)) {
		 dragStarted=true; dragStartScreenPos=Input.mousePosition;
		 dragStartWorldPos=GetWorldPointAtZ(Input.mousePosition,transform.position.z); dragStartZ=targetZ;
		} else if(Input.GetMouseButtonUp(0)) { isDragging=false; dragStarted=false; }
		if(dragStarted && !isDragging && Vector2.Distance(dragStartScreenPos,Input.mousePosition)>dragThreshold) isDragging=true;
		if(isDragging) {
		 Vector3 current=GetWorldPointAtZ(Input.mousePosition,transform.position.z);
		 targetZ=Mathf.Clamp(dragStartZ-(current.y-dragStartWorldPos.y)*dragMultiplier,minZ,maxZ);
		}
		Vector3 p=transform.position;
		transform.position=new Vector3(p.x,p.y,Mathf.Lerp(p.z,targetZ,Time.deltaTime*smoothSpeed)); draggingInfo=isDragging;
	}

	public void SetTargetZDirect(float newZ)
	{
		// Recovered from original ARM64 0x21cd038.
		targetZ=Mathf.Clamp(newZ,minZ,maxZ); Vector3 p=transform.position; transform.position=new Vector3(p.x,p.y,targetZ);
	}

	private Vector3 GetWorldPointAtZ(Vector3 screenPos, float z)
	{
		// Recovered from original ARM64 0x21ccf3c.
		Camera main=Camera.main; if(main==null) return Vector3.zero; screenPos.z=main.WorldToScreenPoint(new Vector3(0f,0f,z)).z; return main.ScreenToWorldPoint(screenPos);
	}
}
