﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://xcad.xarial.com/license/
//*********************************************************************

using Xarial.XCad.UI.PropertyPage.Delegates;

namespace Xarial.XCad.UI.PropertyPage
{
    /// <summary>
    /// Represents native proeprty page to manage entity parameters
    /// </summary>
    /// <typeparam name="TDataModel"></typeparam>
    public interface IXPropertyPage<TDataModel>
    {
        /// <summary>
        /// Fired when the data is changed (i.e. text box changed, combobox selection changed etc.)
        /// </summary>
        event PageDataChangedDelegate DataChanged;

        /// <summary>
        /// Fired when property page is about to be closed. Use the argument to provide additional instructions
        /// </summary>
        event PageClosingDelegate Closing;

        /// <summary>
        /// Fired when property manager page is closed
        /// </summary>
        event PageClosedDelegate Closed;

        /// <summary>
        /// Opens the property page with the specified data model
        /// </summary>
        /// <param name="model">Pointer to an instance of the bound data model</param>
        void Show(TDataModel model);
    }
}