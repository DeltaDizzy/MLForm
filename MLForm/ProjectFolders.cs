using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MLForm
{
    public struct ProjectFolders
    {
        public static readonly DirectoryInfo? inputDir = new DirectoryInfo(Assembly.GetExecutingAssembly().Location)
                .Parent.Parent.Parent.GetDirectories("Assets").FirstOrDefault().GetDirectories("InputImages").FirstOrDefault();
        public static readonly DirectoryInfo? outputDir = new DirectoryInfo(Assembly.GetExecutingAssembly().Location)
            .Parent.Parent.Parent.GetDirectories("Assets").FirstOrDefault().GetDirectories("InputImages").FirstOrDefault();
        public static readonly string modelPath = inputDir.Parent.GetFiles("model.onnx").FirstOrDefault().FullName;
    }
}
