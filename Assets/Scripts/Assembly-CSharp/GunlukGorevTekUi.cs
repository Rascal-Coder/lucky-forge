using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunlukGorevTekUi : MonoBehaviour
{
	public TextMeshProUGUI titleText;

	public TextMeshProUGUI expRewardText;

	public TextMeshProUGUI progressText;

	public Slider progressSlider;

	public Button collectButton;

	public TextMeshProUGUI _collecttext;

	public GunlukGorev task;

	private GunlukGorevler gunlukgorevler;

	public GameObject _check;

	public Transform _rewardIcons;

	public GameObject siyahlik;

	public void Initialize(GunlukGorev task, GunlukGorevler manager)
	{
        // Original ARM64 recovery 0x1f7ae00.
        this.task=task;gunlukgorevler=manager;UpdateUI();for(int i=0;i<_rewardIcons.childCount;i++)_rewardIcons.GetChild(i).gameObject.SetActive(i==task.OdulType);
	}

	public void UpdateUI()
	{
        // Original ARM64 recovery 0x1f7b1bc.
        expRewardText.text=task.OdulType==4?ShortScaleString.parseDouble((double)task.expReward,1,1000000d,false):string.Format("x{0}",task.expReward);
        progressText.text=string.Format("{0} / {1}",task.currentCount,task.maxValue);progressSlider.maxValue=task.maxValue;progressSlider.value=task.currentCount;
        if(collectButton!=null){collectButton.interactable=task.isCompleted&&!task.isCollected;_collecttext.text=task.isCompleted&&!task.isCollected?(task.reklamli?GooglePlayPassHandler.AdSpriteTag+Lang.Get.topla:Lang.Get.topla):Lang.Get.inProgress;collectButton.gameObject.SetActive(!task.isCollected);}
        _check.SetActive(task.isCollected);siyahlik.SetActive(task.isCollected);
        switch(task.GorevType){
        case 0:titleText.text=Lang.Get.gunlukGorev1+".";break;
        case 1:titleText.text=Lang.Get.gunlukGorev2+".";break;
        case 2:titleText.text=Lang.Get.gunlukGorev3+".";break;
        case 3:titleText.text=Lang.Get.gunlukGorev4+".";break;
        case 4:titleText.text=Lang.Get.gunlukGorev5+".";break;
        case 5:titleText.text=Lang.Get.gunlukGorev6+".";break;
        case 6:titleText.text=Lang.Get.gunlukGorev7+".";break;
        case 7:titleText.text=Lang.Get.gunlukGorev8+".";break;
        case 8:titleText.text=Lang.Get.gunlukGorev9+".";break;
        case 9:titleText.text=Lang.Get.gunlukGorev10+".";break;
        case 10:titleText.text=Lang.Get.gunlukGorev11+".";break;
        case 11:titleText.text=Lang.Get.gunlukGorev12+".";break;
        case 12:titleText.text=Lang.Get.gunlukGorev13+".";break;
        case 13:titleText.text=Lang.Get.gunlukGorev14+".";break;
        case 14:titleText.text=Lang.Get.gunlukGorev15+".";break;
        case 15:titleText.text=Lang.Get.gunlukGorev16+".";break;
        case 16:titleText.text=Lang.Get.gunlukGorev17+".";break;
        case 17:titleText.text=Lang.Get.mission17;break;
        case 18:titleText.text=Lang.Get.mission18;break;
        case 19:titleText.text=Lang.Get.mission19;break;
        }
	}

	public void OnCollectButtonPressed()
	{
        // Original ARM64 recovery 0x1f7d07c.
        if(task.reklamli){gunlukgorevler.rewardAdsManager._gunlukGorev=task;gunlukgorevler.rewardAdsManager.ShowRewardBasedVideo(35);return;}
        gunlukgorevler.CollectReward(task);UpdateUI();
	}
}
