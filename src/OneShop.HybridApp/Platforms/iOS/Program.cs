﻿// Copyright (c) HelloShop Corporation. All rights reserved.
// See the license file in the project root for more information.

using ObjCRuntime;
using UIKit;

namespace OneShop.HybridApp
{
    public class Program
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));
        }
    }
}
