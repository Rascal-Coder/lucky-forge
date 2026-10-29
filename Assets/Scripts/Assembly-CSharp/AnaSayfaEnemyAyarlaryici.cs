using UnityEngine;

public class AnaSayfaEnemyAyarlaryici : MonoBehaviour
{
	public SpriteRenderer[] enemies;

	public GameObject enemyBossObj;

	public Transform EnemyPosParent;

	public PoolObject pool;

	public WarController warController;

	public void SetUp(int level)
	{
        // Original ARM64 recovery 0x21ad760.
        string bossTag="boss"+unchecked(level%14+1).ToString();
        Sprite first=pool.SpawnFromPool(warController.GetEnemyTagsForWave(level,32)[0],EnemyPosParent.position,Quaternion.identity,false,true).GetComponent<Enemy>().icon.sprite;
        Sprite second=pool.SpawnFromPool(warController.GetEnemyTagsForWave(level,32)[1],EnemyPosParent.position,Quaternion.identity,false,true).GetComponent<Enemy>().icon.sprite;
        Sprite third=pool.SpawnFromPool(warController.GetEnemyTagsForWave(level,32)[2],EnemyPosParent.position,Quaternion.identity,false,true).GetComponent<Enemy>().icon.sprite;
        enemyBossObj=pool.SpawnFromPool(bossTag,EnemyPosParent.position,Quaternion.identity,false,true).GetComponent<Enemy>().Char.gameObject;
        EneyleriDiz(new Sprite[]{first,second,third});
        BossVer();
	}

	private void EneyleriDiz(Sprite[] enemyIcon)
	{
        // Original ARM64 recovery 0x21adbe0.
        if(enemyIcon.Length==0)return;
        int count=enemies.Length;
        for(int i=0;i<count;i++)enemies[i].sprite=enemyIcon[System.Math.Min((int)((long)i*enemyIcon.Length/count),enemyIcon.Length-1)];
	}

	private void BossVer()
	{
        // Original ARM64 recovery 0x21adca8.
        if(enemyBossObj==null)return;
        if(EnemyPosParent.childCount>=1)Destroy(EnemyPosParent.GetChild(0).gameObject);
        GameObject copy=Instantiate(enemyBossObj,EnemyPosParent);
        copy.transform.SetParent(EnemyPosParent);
        copy.transform.localPosition=Vector3.zero;
        copy.transform.localScale=new Vector3(1.399999976158142f,1.399999976158142f,1.399999976158142f);
	}
}
