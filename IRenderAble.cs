using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEngine
{
    internal interface IRenderAble
    {
        public void doRender(Matrix4 parentTransformation);
    }
}
