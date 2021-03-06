﻿// Copyright © 2010-2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Windows.Forms;
using EyeXFramework.Forms;

namespace CefSharp.MinimalExample.WinForms
{
    public class Program
    {
        private FormsEyeXHost _eyeXHost = new FormsEyeXHost();

        /// <summary>
        /// Gets the singleton EyeX host instance.
        /// </summary>
        public FormsEyeXHost EyeXHost
        {
            get { return _eyeXHost; }
        }

        [STAThread]
        public static void Main()
        {
            Program p = new Program();
            
            //For Windows 7 and above, best to include relevant app.manifest entries as well
            Cef.EnableHighDPISupport();

            //Perform dependency check to make sure all relevant resources are in our output directory.
            Cef.Initialize(new CefSettings(), performDependencyCheck: true, browserProcessHandler: null);

            var browser = new BrowserForm(p);
            p._eyeXHost.Start();
            try { Application.Run(browser); }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //p._eyeXHost.Dispose();
        }
    }
}
