﻿using Android.App;
using Android.Runtime;

namespace FloresTareaMVVM
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => JFMauiProgram.CreateMauiApp();
    }
}
