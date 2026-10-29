using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasariGorevUI : MonoBehaviour
{
	public TextMeshProUGUI titleText;

	public TextMeshProUGUI expRewardText;

	public TextMeshProUGUI progressText;

	public Slider progressSlider;

	public Button collectButton;

	public TextMeshProUGUI _collecttext;

	public BasariGorev gorev;

	private Basarimlar manager;

	public GameObject _check;

	public Transform _rewardIcons;

	public GameObject siyahlik;

	public void Initialize(BasariGorev gorev, Basarimlar manager)
	{
        // Original ARM64 recovery 0x21ae8b0.
        this.gorev=gorev;this.manager=manager;UpdateUI();collectButton.onClick.RemoveAllListeners();collectButton.onClick.AddListener(OnCollectButtonPressed);
	}

	public void SetData(BasariGorev gorev)
	{
        // Original ARM64 recovery 0x21aed44.
        this.gorev=gorev;UpdateUI();
	}

	public void UpdateUI()
	{
        // Original ARM64 recovery 0x21ae990.
        expRewardText.text=gorev.OdulType==1?ShortScaleString.parseDouble((double)gorev.expReward,1,1000000d,false):string.Format("x{0}",gorev.expReward);
        progressText.text=string.Format("{0} / {1}",gorev.currentCount,gorev.maxValue);progressSlider.maxValue=gorev.maxValue;progressSlider.value=gorev.currentCount;
        collectButton.interactable=gorev.currentCount>=gorev.maxValue;_collecttext.text=gorev.currentCount>=gorev.maxValue?Lang.Get.topla:Lang.Get.inProgress;
        collectButton.gameObject.SetActive(!gorev.isCollected);_check.SetActive(gorev.isCollected);siyahlik.SetActive(gorev.isCollected);
        for(int i=0;i<_rewardIcons.childCount;i++)_rewardIcons.GetChild(i).gameObject.SetActive(i==gorev.OdulType);
        titleText.text=GetMissionText(gorev.GorevType)+".";
	}

	private string GetMissionText(int num)
	{
        // Original ARM64 recovery 0x21aed60.
        switch(num){
        case 0:return Lang.Get.missionStr0;
        case 1:return Lang.Get.missionStr1;
        case 2:return Lang.Get.missionStr2;
        case 3:return Lang.Get.missionStr3;
        case 4:return Lang.Get.missionStr4;
        case 5:return Lang.Get.missionStr5;
        case 6:return Lang.Get.missionStr6;
        case 7:return Lang.Get.missionStr7;
        case 8:return Lang.Get.missionStr8;
        case 9:return Lang.Get.missionStr9;
        case 10:return Lang.Get.missionStr10;
        case 11:return Lang.Get.missionStr11;
        case 12:return Lang.Get.missionStr12;
        case 13:return Lang.Get.missionStr13;
        case 14:return Lang.Get.missionStr14;
        case 15:return Lang.Get.missionStr15;
        case 16:return Lang.Get.missionStr16;
        case 17:return Lang.Get.missionStr17;
        case 18:return Lang.Get.missionStr18;
        case 19:return Lang.Get.missionStr19;
        case 20:return Lang.Get.missionStr20;
        case 21:return Lang.Get.missionStr21;
        case 22:return Lang.Get.missionStr22;
        case 23:return Lang.Get.missionStr23;
        case 24:return Lang.Get.missionStr24;
        case 25:return Lang.Get.missionStr25;
        case 26:return Lang.Get.missionStr26;
        case 27:return Lang.Get.missionStr27;
        case 28:return Lang.Get.missionStr28;
        case 29:return Lang.Get.missionStr29;
        case 30:return Lang.Get.missionStr30;
        case 31:return Lang.Get.missionStr31;
        default:return Lang.Get.missionStrDefault;
        }
	}

	public void OnCollectButtonPressed()
	{
        // Original ARM64 recovery 0x21af270.
        manager.CollectReward(gorev,this);UpdateUI();
	}
}
