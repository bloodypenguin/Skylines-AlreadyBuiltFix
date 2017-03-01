using System;
using AlreadyBuiltFix;
using ColossalFramework;

namespace DlcUnlocker
{
    public class MonumentAIDetour : MonumentAI
    {
        private static RedirectCallsState _state;
        private static bool _deployed;

        public static void Deploy()
        {
            if (_deployed)
            {
                return;
            }
            try
            {
                _state = RedirectionHelper.RedirectCalls
                    (
                    typeof(MonumentAI).GetMethod("CanBeBuilt"),
                    typeof(MonumentAIDetour).GetMethod("CanBeBuilt")
                    );
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogException(e);
            }
            _deployed = true;
        }

        public static void Revert()
        {
            if (!_deployed)
            {
                return;
            }
            try
            {
                RedirectionHelper.RevertRedirect(
                    typeof(MonumentAI).GetMethod("CanBeBuilt"),
                    _state
                    );

            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogException(e);
            }
            _deployed = false;
        }

        public override bool CanBeBuilt()
        {
            var instance = Singleton<BuildingManager>.instance;
            var serviceBuildings = instance.GetServiceBuildings(this.m_info.m_class.m_service);
            for (var index = 0; index < serviceBuildings.m_size; ++index)
            {
                var num = serviceBuildings.m_buffer[index];
                if ((int)num != 0 && instance.m_buildings.m_buffer[(int)num].Info == this.m_info)
                {
                    return false;
                }
            }
            return true;
        }
    }
}