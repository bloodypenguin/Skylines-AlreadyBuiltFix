using ICities;

namespace AlreadyBuiltFix
{
    public class Mod : IUserMod
    {
        public string Name
        {
            get { return "Building Panel Already Exists Fix"; }
        }

        public string Description
        {
            get { return "Makes unique buildings panel display proper already exists state"; }
        }
    }
}