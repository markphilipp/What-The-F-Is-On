using System;

namespace Containerization
{
    public static class ConsoleContainer
    {
        public static IServiceProvider Current { get; set; }
    }
}
