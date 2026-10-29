# 图标、首页与背景音乐修复

更新：2026-10-29T23:41:49。本批次基于 main `30a5e66`；仍是持续还原的 Unity 离线工程。

## 修复行为

- 统一核对全部1693个导出Sprite，通过原RenderDataKey精确定位原资源；1213个恢复原逻辑矩形、偏移、中心点、九宫格边框和textureRectOffset，包含五个底部Tab、英雄部件、卡框与天赋图标。其余480个原值无需修改。
- 原纹理515份PNG、Sprite顶点/索引/UV、GUID/.meta和场景布局保持。255个原数据中tightRect超过fullRect的案例照抄原值，不人为裁切；全部实际加载通过。
- TMP两个原Settings资源的asset/meta配对交换到正确Resources地址，使默认图集为MeduSprite。开始消耗显示闪电；显式引用EmojiOne的原文本引用保留。
- 恢复原三段背景创建、回收及10部件角色同步。主页读取与Gears相同的MainHeroNum；原选择、锁定与保存规则保留。
- 原单步回收在低帧率/大拖动时只追一块，随后缓存相机位置，造成Lv4顶端约355px黑区。保留原单步方法为UpdateBolumPositionsOnce；共享入口反复原步骤至引用、位置和启用状态稳定。这是明确的桌面离线适配，不称原代码逐字还原；不改102/250常量、关卡长度、相机投影、模板或实例数量。
- 补回原Loading大厅音乐调用，以及War.OnEnable的原战斗音乐分支。后者仅恢复音乐尾部，整段OnEnable其他逻辑仍未全部还原；原音乐开关规则保留。

## 实际验证

- 原有1120项模块加首页世界72项，共 **1192项通过**。章节奖励77项在真实PlayMode中验证原Destroy生命周期；其余模块在EditMode执行。
- 全1693个真实导入Sprite共 **13544项通过**；几何顶点/索引数量差异0。
- BGM实际PlayMode **30项通过**：DSP与timeSamples推进，音频输出非零，首进大厅、战斗、暂停、音乐开关和返回大厅切换均检查。
- 实际607×1280 GameView查看武器、天赋、召唤入口及结果页。38武器卡、22天赋卡、6结果卡的矩形和网格节距完全未改；可见卡框恢复留白。四个可见Tab矩形未改，第五个原等级锁仍生效，其原图标已恢复并通过资产加载验证。
- Lv4/Drovak在正常自动Update中快速移动到最大边界后实际画面已无黑区，未启用诊断单步。
- 最新Windows构建 **0错误、2184警告**，627535830字节。实际程序逐个测试internal0..17，覆盖16个背景模板和循环复用，18次最大边界及快速返底，结构检查 **224项通过**、运行错误0；截图先于验证调用生成，验证调用不得再移动地块。
- 构建10在背景收敛适配前已完整实跑两关胜利、原50代币六卡召唤、400金币武器升级、天赋召唤与装备、返回首页，运行错误0。随后构建11专测本次共享循环改动。两种证据不混称一次完整流程。

完整数值见 [visual-audio-verification.json](visual-audio-verification.json)。生成的原始日志、隔离存档及截图留在本机Verification，继续忽略入库。

## 复测入口

模块：`LuckyForge.Offline.Editor.OfflineIntegrationVerification.RunChecksBatch`，自动先进入隔离PlayMode跑章节奖励，再回EditMode跑其余模块。不要附加`-quit`。

资产：`LuckyForge.Offline.Editor.OriginalSpriteGeometryVerification.RunBatch`；音乐：`BgmPlaybackVerification.RunBatch`（保留音频设备，不加`-noaudio`）。

画面：`LuckyForge.Offline.Editor.VisualReviewVerification.RunBatch`。需将`LUCKYFORGE_VISUAL_PROFILE_SOURCE`设置为此前通过的隔离Profile目录；可选`LUCKYFORGE_VISUAL_LEVEL`表示显示等级，内部使用原Seviye键且减1。`LUCKYFORGE_VISUAL_HOME_ONLY=1`仅查看首页两端。旧探索捕获中曾写无效English Level键，实际internal2/显示Lv3为其权威状态，不当作Lv4证据；原始记录保留。

Windows巡检：显式`LUCKYFORGE_RECOVERY_PROBE_ROOT`指向新的独立Level2 Profile副本及world-sweep-baseline.json，`LUCKYFORGE_RECOVERY_PROBE_ACTIONS=home-world-sweep`。普通启动不启用这些探针。

本批次不是完整复刻完成声明，其他客户端入口和模式仍有未还原项；服务端未重建。截图及UI回调测试也不等于全部物理鼠标实测。
