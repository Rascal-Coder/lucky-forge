using UnityEngine;

public class FalseDestroyLater : MonoBehaviour
{
	public float second;

	public bool destroy;

	public bool falseit;

	public bool parentidafalseet;

	public bool transformToParent;

	public bool ikincikereBeniGorme;

	public float timer;

	private Transform _parent;

	public bool lookatcamera;

	public bool bilgivertimeresetle;

	public PoolObject pooling;

	public bool Unscaled;

	private int ikincikeremi;

	private void Start()
	{
		// Native RVA0x2208f40. Reparentable pooled objects initially remember their owner and hide.
		if(transformToParent){_parent=transform.parent;gameObject.SetActive(false);}
	}

	private void OnEnable()
	{
		// Native RVA0x2208fa0. This method does not reset the object's lifetime timer.
		if(ikincikereBeniGorme){ikincikeremi=unchecked(ikincikeremi+1);if(ikincikeremi>=2){gameObject.SetActive(false);ikincikeremi=0;}}
		if(bilgivertimeresetle)GameManager.bilgitimer=0f;
	}

	private void Update()
	{
		// Native RVA0x2209044. Welcome overlay uses second9,falseit=true,Unscaled=true.
		if(gameObject.activeSelf){
		    timer+=Unscaled?Time.unscaledDeltaTime:Time.deltaTime;
		    if(lookatcamera)transform.eulerAngles=new Vector3(-52f,-144f,0f);
		}
		if(timer>second){
		    if(destroy)Destroy(gameObject);
		    if(falseit){
		        gameObject.SetActive(false);
		        if(parentidafalseet)gameObject.transform.parent.gameObject.SetActive(false);
		        if(transformToParent)transform.SetParent(_parent);
		        if(pooling!=null)pooling.ReturnToPool(gameObject.name,gameObject);
		        timer=0f;
		    }
		}
	}

	public void Hemen()
	{
		// Native RVA0x2209254. Original click guard accelerates lifetime; it does not directly close.
		if(GameManager.bilgitimer>0.5f)timer=10f;
	}

	public void ForAnim()
	{
		// Original native RVA0x22092c4: unconditionally deactivate this same GameObject.
		gameObject.SetActive(false);
	}
}
