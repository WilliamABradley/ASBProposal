using ASBDemo.Enums;
using Windows.System.Profile;

namespace ASBDemo.Common
{
    public static class AppInformation
    {
        static AppInformation()
        {
            DeviceType = GetDeviceType();
        }

        public static DeviceType DeviceType { get; }

        public static DeviceType GetDeviceType()
        {
            switch (AnalyticsInfo.VersionInfo.DeviceFamily)
            {
                case "Windows.Xbox":
                    return DeviceType.Xbox;

                case "Windows.Desktop":
                    return DeviceType.Desktop;

                case "Windows.Mobile":
                    return DeviceType.Mobile;

                case "Windows.Holographic":
                    return DeviceType.Hololens;

                case "Windows.IoT":
                    return DeviceType.IOT;

                case "Windows.Team":
                    return DeviceType.SurfaceHub;

                default:
                    return DeviceType.unknown;
            }
        }
    }
}