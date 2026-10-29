# Lucky Forge Offline Recovery

可编辑的 Unity 离线还原工程，基于 Lucky Forge: Idle TD Game 1.49.9 (82) 的本地客户端资源与原生代码分析。核心战斗可运行，仍有客户端功能、其他模式和视觉细节待还原，尚非完整复刻。

## 打开工程

1. 安装 Git LFS 后克隆仓库，并执行 `git lfs pull`。`Assets/Scenes/Sahne.unity` 是 LFS 文件，不能只下载未展开的指针。
2. 使用 Unity **6000.0.58f2** 添加仓库根目录。原客户端版本为 6000.0.68f1，当前还原和验证使用前者。
3. 打开 `Assets/Scenes/Loading.unity` 后运行，让原加载流程初始化数据和主场景。

`Assets`、`Packages`、`ProjectSettings` 和原 `.meta` 身份均保留。缓存、生成的解决方案、构建输出、隔离测试存档和原 APK/逆向材料不入库。

## 当前恢复与验证范围

已恢复主线刷怪、攻击、抽取与合成、技能选择、普通胜利领奖，以及已验证的武器、装备、天赋、英雄、城墙、宠物和本地保存路径。挂机奖励、地牢挑战的部分路径和原解锁规则也已恢复。

图标、五个底部Tab、首页选中角色、跨关卡背景循环及BGM的修复与验证见 [本批记录](RecoveryNotes/VISUAL-AUDIO-RECOVERY.md)。

最新验证与边界记录见 [RecoveryNotes/VALIDATION.md](RecoveryNotes/VALIDATION.md)。模块检查不等于所有功能均完成端到端验证。账号、公会、排行榜及原联网服务未重建；原广告和支付权益不在离线验证中模拟授予。

新离线保存采用独立 JSON 适配层，不兼容原加密 ES3 账号存档。

## 构建和检查

Windows 开发构建入口：`LuckyForge.Offline.Editor.OfflineBuildWindows.RunBatch`。该 Editor 方法构建 Loading/Sahne 两个场景，使用 Windows 64 位 Mono 后端，输出至 `Builds/Windows`。

模块检查入口：`LuckyForge.Offline.Editor.OfflineIntegrationVerification.RunChecksBatch`。可通过 Unity 的 `-batchmode -projectPath <工程目录> -executeMethod <入口> -logFile <日志路径>` 执行；由方法自行结束 Editor，不要提前添加 `-quit`。

验证源位于 `Assets/OfflineRecovery`。运行时探针仅在显式设置 `LUCKYFORGE_RECOVERY_PROBE_ROOT` 时创建隔离存档；普通启动不启用探针。实际生成的 `Verification` 文件夹不提交。

当前仓库提供源码和资源；Windows 可运行文件在本机构建输出中。Android 仍需相应 Unity 构建模块及后续验证。
