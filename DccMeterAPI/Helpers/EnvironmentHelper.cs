using System.Reflection;

namespace Euronet.Api.Helpers
{
    /// <summary>
    /// Environment helper
    /// </summary>
    public class EnvironmentHelper
    {
        private static string _version = null;

        /// <summary>
        /// Version
        /// </summary>
        public static string Version
        {
            get
            {
                if (_version == null)
                {
                    _version = typeof(Program).Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
                }

                return _version;
            }
        }

        private static string _applicationName = null;

        /// <summary>
        /// Application name
        /// </summary>
        public static string ApplicationName
        {
            get
            {
                if (_applicationName == null)
                {
                    _applicationName = typeof(Program).Assembly.GetCustomAttribute<AssemblyProductAttribute>().Product;
                }

                return _applicationName;
            }
        }
    }
}
