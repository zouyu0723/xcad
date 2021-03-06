﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://xcad.xarial.com/license/
//*********************************************************************

using SolidWorks.Interop.sldworks;
using Xarial.XCad.Base;
using Xarial.XCad.Documents;
using Xarial.XCad.Geometry.Structures;
using Xarial.XCad.Utils.Diagnostics;

namespace Xarial.XCad.SolidWorks.Documents
{
    public class SwAssembly : SwDocument3D, IXAssembly
    {
        public IAssemblyDoc Assembly { get; }

        public IXComponentRepository Components { get; }

        internal SwAssembly(IAssemblyDoc assembly, SwApplication app, IXLogger logger)
            : base((IModelDoc2)assembly, app, logger)
        {
            Assembly = assembly;
            Components = new SwComponentCollection(this, 
                (Assembly as IModelDoc2).ConfigurationManager.ActiveConfiguration.GetRootComponent3(true));
        }

        public override Box3D CalculateBoundingBox()
        {
            const int NO_REF_GEOM = 0;

            var box = Assembly.GetBox(NO_REF_GEOM) as double[];

            return new Box3D(box[0], box[1], box[2], box[3], box[4], box[5]);
        }
    }
}