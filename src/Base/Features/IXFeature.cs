﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://xcad.xarial.com/license/
//*********************************************************************

using Xarial.XCad.Annotations;

namespace Xarial.XCad.Features
{
    public interface IXFeature : IXSelObject
    {
        string Name { get; set; }
        IXDimensionRepository Dimensions { get; }
    }
}