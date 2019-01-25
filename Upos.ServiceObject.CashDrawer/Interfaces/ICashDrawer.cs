using System.Runtime.InteropServices;

namespace Upos.ServiceObject.CashDrawer.Interfaces
{
    /// <summary>
    /// The cash drawer is a sharable device. Its device sharing rules are:
    /// After opening and enabling the device, the application may access all properties and methods and will receive status update events.
    /// If more than one application has opened and enabled the device, each of these applications may access its properties and methods. Status update events are delivered to all of these applications.
    /// If one application claims the cash drawer, then only that application may call openDrawer and waitForDrawerClose. This feature provides a degree of security, such that these methods may effectively be restricted to the main application if that application claims the device at startup.
    /// </summary>
    public interface ICashDrawer
    {
        /// <summary>
        /// Opens the drawer. Use after open-enable
        /// </summary>
        /// <returns>A UposException may be thrown when this method is invoked.</returns>
        [DispId(0x20)]
        int OpenDrawer();

        /// <summary>
        /// waits until the cash drawer is closed. If the drawer is still open after beepTimeout milliseconds, then the system alert beeper is started.
        /// Not all POS implementations may support the typical PC speaker system alert beeper. However, by setting these parameters the application will insure that the system alert beeper will be utilized if it is present.
        /// Blocking call until all cash drawers all closed.
        /// </summary>
        /// <param name="beepTimeout">number of milliseconds to wait before starting an alert beeper</param>
        /// <param name="beepFrequency">Audio frequency of the alert beeper in hertz</param>
        /// <param name="beepDuration">Number of milliseconds that the beep tone will be sounded</param>
        /// <param name="beepDelay">Number of milliseconds between teh sounding of the beeper tones.</param>
        /// <returns>A UposException may be thrown when this method is invoked.</returns>
        [DispId(0x21)]
        int WaitForDrawerClose([In, MarshalAs(UnmanagedType.I4)] int beepTimeout, [In, MarshalAs(UnmanagedType.I4)] int beepFrequency, [In, MarshalAs(UnmanagedType.I4)] int beepDuration, [In, MarshalAs(UnmanagedType.I4)] int beepDelay);
    }
}
