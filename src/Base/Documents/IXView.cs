﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://xcad.xarial.com/license/
//*********************************************************************

using System.Drawing;
using Xarial.XCad.Geometry.Structures;

namespace Xarial.XCad.Documents
{
    public interface IXView
    {
        void Freeze(bool freeze);
        TransformMatrix Transform { get; set; }
        TransformMatrix ScreenTransform { get; }
        Rectangle ScreenRect { get; }

        /// <summary>
        /// Zooms view to the specified box in XYZ model space
        /// </summary>
        /// <param name="box">Box to zoom to</param>
        void ZoomToBox(Box3D box);

        void Update();
    }
}