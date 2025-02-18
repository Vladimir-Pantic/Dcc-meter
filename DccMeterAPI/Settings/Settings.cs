using System.Runtime.CompilerServices;

namespace DccMeter.API.Settings
{
    public class Settings
    {
        public Settings() { }

        private static volatile Settings instance;
        private static object instanceLock = new object();

        public static Settings Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new Settings();

                    return instance;
                }

            }
        }

        internal static void Initialize(IConfiguration configuration)
        {
            lock (instanceLock)
            {
                instance = configuration.GetSection("Settings").Get<Settings>();
            }
        }


        public AuditSettings AuditSettings { get; set; }

        public AppSettings AppSettings { get; set; }

        public SwaggerSettings SwaggerSettings { get; set; }


    }
}