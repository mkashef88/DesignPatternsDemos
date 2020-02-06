using System;
using System.Windows;

namespace DesignPatterns.Behavioral.Observer.WeakEventPattern
{
    public class Button
    {
        public event EventHandler Clicked;
        public void Fire()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Window
    {
        public Window(Button button)
        {
            button.Clicked += Button_Clicked;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine($"Button clicked (Window handler)");
        }

        ~Window()
        {
            Console.WriteLine("Window finalized");
        }
    }

    public class Window2
    {
        public Window2(Button button)
        {
            WeakEventManager<Button, EventArgs>
       .AddHandler(button, "Clicked", Button_Clicked);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine($"Button clicked (Window handler)");
        }

        ~Window2()
        {
            Console.WriteLine("Window finalized");
        }
    }
    class WeakEventPattern
    {
        static void Main234(string[] args)
        {
            var btn = new Button();
            var window = new Window2(btn);
            //var window = new Window(btn);
            var windowRef = new WeakReference(window);
            btn.Fire();

            Console.WriteLine("Setting window to null");
            window = null;

            FireGC();
            Console.WriteLine($"Is window alive after GC? {windowRef.IsAlive}");

            btn.Fire();

            Console.WriteLine("Setting button to null");
            btn = null;

            FireGC();
        }
        private static void FireGC()
        {
            Console.WriteLine("Starting GC");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine("GC is done!");
        }
    }
}
