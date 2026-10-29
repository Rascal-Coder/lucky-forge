using System.Collections.Generic;

namespace FunGames.Core.Modules
{
	public interface FGModule
	{
		FGModuleInfo ModuleInfo { get; }

		bool IsInitialized { get; }

		bool IsChildCompleted { get; }

		InitializationStatus InitializationStatus { get; }

		List<FGModule> SubModules { get; }

		float TotalSubModules { get; }

		float TotalSubModulesCompleted { get; }

		void Awake();

		void Start();

		void Log(params string[] message);

		void LogError(params string[] message);

		void LogWarning(params string[] message);

		bool MustBeInitialized();

		void CheckModuleInitialization();

		void Initialize();

		void AddChild(FGModule child);

		void InitWithoutTimer();

		void SetMaxInitTime(float time);

		void SetManualInit();

		void UnlockManualInit();
	}
}
