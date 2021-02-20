using System;
using System.IO;

namespace Zmeika_C_sharp
{
    public class Params
    {
        private string ResourcesFolder;
        public Params()
        {
            var ind = Directory.GetCurrentDirectory().ToString()
                .IndexOf("bin", StringComparison.Ordinal); // Получить индекс папки bin

            string binFolder =
                Directory.GetCurrentDirectory().ToString().Substring(0, ind)
                    .ToString(); // путь до указанной в инкесе папки

            ResourcesFolder = binFolder + "Music\\";
        }

        public string GetResourcesFolder()
        {
            return ResourcesFolder;
        }
    }
}