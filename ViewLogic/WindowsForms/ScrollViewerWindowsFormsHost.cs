using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

namespace SignalProcessor.ViewLogic.WindowsForms
{
    /// <summary>
    /// Class with fixing WindowsFormsHost's original scroll trouble
    /// 
    /// Taken from:
    ///     http://stackoverflow.com/questions/14080580/scrollviewer-is-not-working-in-wpf-windowsformhost
    /// </summary>
    class ScrollViewerWindowsFormsHost : WindowsFormsHost
    {

        protected override void OnWindowPositionChanged(Rect rcBoundingBox)
        {
            base.OnWindowPositionChanged(rcBoundingBox);

            if (ParentScrollViewer == null)
                return;

            GeneralTransform tr = ParentScrollViewer.TransformToAncestor(MainWindow);
            var scrollRect = new Rect(new Size(ParentScrollViewer.ViewportWidth, ParentScrollViewer.ViewportHeight));
            scrollRect = tr.TransformBounds(scrollRect);

            var intersect = Rect.Intersect(scrollRect, rcBoundingBox);
            if (!intersect.IsEmpty)
            {
                tr = MainWindow.TransformToDescendant(this);
                intersect = tr.TransformBounds(intersect);
            }

            SetRegion(intersect);
        }

        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);
            ParentScrollViewer = null;

            var p = Parent as FrameworkElement;
            while (p != null)
            {
                if (p is ScrollViewer)
                {
                    ParentScrollViewer = (ScrollViewer)p;
                    break;
                }

                p = p.Parent as FrameworkElement;
            }
        }

        private void SetRegion(Rect intersect)
        {
            using (var graphics = System.Drawing.Graphics.FromHwnd(Handle))
                SetWindowRgn(Handle, (new System.Drawing.Region(ConvertRect(intersect))).GetHrgn(graphics), true);
        }

        static System.Drawing.RectangleF ConvertRect(Rect r)
        {
            return new System.Drawing.RectangleF((float)r.X, (float)r.Y, (float)r.Width, (float)r.Height);
        }

        private Window _mainWindow;
        Window MainWindow
        {
            get
            {
                if (_mainWindow == null)
                    _mainWindow = Window.GetWindow(this);

                return _mainWindow;
            }
        }

        ScrollViewer ParentScrollViewer { get; set; }

        [DllImport("User32.dll", SetLastError = true)]
        public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);
    }
}
