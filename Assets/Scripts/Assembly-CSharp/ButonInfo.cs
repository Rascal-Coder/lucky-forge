using UnityEngine;

public class ButonInfo : MonoBehaviour
{
	public int Num;

	public infoCurrencyShow currencyShow;

	public void Clicked()
	{
        // Native RVA0x21cc200: _buble is static offset0x58 (not _bell).
        if (SoundManager.instance != null) SoundManager.instance.RandomizeSfx(SoundManager._buble);
        if (currencyShow == null)
        {
            GameObject top=GameObject.Find("TopCanvasJobs");
            CanvasJobs jobs=top != null ? top.GetComponent<CanvasJobs>() : null;
            if (jobs != null) currencyShow=jobs.infoCurrency;
        }
        if (currencyShow != null) currencyShow.Show(Num, transform.position);
	}
}
