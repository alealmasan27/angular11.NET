using System;

namespace EFTest.Domain
{
    [Serializable]
    public class AppSettings
    {
        public string ConnectionString { get; set; }
    }
}