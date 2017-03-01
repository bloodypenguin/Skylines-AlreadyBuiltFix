using DlcUnlocker;
using ICities;

namespace AlreadyBuiltFix
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);

            if (mode == LoadMode.LoadGame || mode == LoadMode.NewGame)
            {
                MonumentAIDetour.Deploy();
            }
        }

        public override void OnLevelUnloading()
        {
            base.OnLevelUnloading();
            MonumentAIDetour.Revert();
        }
    }
}