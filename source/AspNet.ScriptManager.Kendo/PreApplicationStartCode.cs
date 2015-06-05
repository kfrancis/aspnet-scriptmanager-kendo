
#region License, Terms and Conditions
//
// PreApplicationStartCode.cs
//
// Authors: Kori Francis <twitter.com/djbyter>
// Copyright (C) 2015 Clinical Support Systems, Inc. All rights reserved.
// 
//  THIS FILE IS LICENSED UNDER THE MIT LICENSE AS OUTLINED IMMEDIATELY BELOW:
//
//  Permission is hereby granted, free of charge, to any person obtaining a
//  copy of this software and associated documentation files (the "Software"),
//  to deal in the Software without restriction, including without limitation
//  the rights to use, copy, modify, merge, publish, distribute, sublicense,
//  and/or sell copies of the Software, and to permit persons to whom the
//  Software is furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//  FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//  DEALINGS IN THE SOFTWARE.
//
#endregion

[assembly: System.Web.PreApplicationStartMethod(typeof(AspNet.ScriptManager.Kendo.PreApplicationStartCode), "Start")]

namespace AspNet.ScriptManager.Kendo
{
    #region Imports
    using System.ComponentModel;
    using System.Web.UI;
    using System.Diagnostics;
    using System.Linq;
    #endregion

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class PreApplicationStartCode
    {
        public static void Start()
        {
            // IMPORTANT: The version of this library determines the version of kendo script that will be used in the script definition.
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            // We can't do anything if we can't determine the version properly
            if (string.IsNullOrWhiteSpace(version)) return;

            // The version will come out in Telerik format, but with the added .0 (ie. 2014.1.528.0), but that needs to be removed to be
            // used as a URL segment for the CDN script url or file script path.
            if (version.Count(x => x == '.') == 3 && version.EndsWith(value: ".0")) { version = version.Remove(version.IndexOf(value: ".0")); }

            ScriptResourceMapping scriptResourceMapping = ScriptManager.ScriptResourceMapping;

            ScriptResourceDefinition kendoWebDefinition = new ScriptResourceDefinition()
            {
                Path = string.Concat(str0: "~/Scripts/kendo/", str1: version, str2: "/kendo.web.min.js"),
                DebugPath = string.Concat(str0: "~/Scripts/kendo/", str1: version, str2: "/kendo.web.min.js"),
                CdnPath = string.Concat(str0: "http://cdn.kendostatic.com/", str1: version, str2: "/js/kendo.web.min.js"),
                CdnDebugPath = string.Concat(str0: "http://cdn.kendostatic.com/", str1: version, str2: "/js/kendo.web.min.js"),
                CdnSupportsSecureConnection = false,
                LoadSuccessExpression = "window.kendo && window.kendo.version === '" + version + "'"
            };
            scriptResourceMapping.AddDefinition(name: "kendo-web", definition: kendoWebDefinition);

            // The SSL CDN has a different URL, use it here.
            ScriptResourceDefinition kendoWebSecureDefinition = new ScriptResourceDefinition()
            {
                Path = string.Concat(str0: "~/Scripts/kendo/", str1: version, str2: "/kendo.web.min.js"),
                DebugPath = string.Concat(str0: "~/Scripts/kendo/", str1: version, str2: "/kendo.web.min.js"),
                CdnPath = string.Concat(str0: "https://da7xgjtj801h2.cloudfront.net/", str1: version, str2: "/js/kendo.web.min.js"),
                CdnDebugPath = string.Concat(str0: "https://da7xgjtj801h2.cloudfront.net/", str1: version, str2: "/js/kendo.web.min.js"),
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.kendo && window.kendo.version === '"+ version + "'"
            };
            scriptResourceMapping.AddDefinition(name: "kendo-web-secure", definition: kendoWebSecureDefinition);
        }
    }
}
