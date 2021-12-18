using System;
using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using System;
using System.Threading.Tasks;

namespace ZXing.Net.Maui
{
	internal partial class CameraManager : IDisposable
	{
		public CameraManager(IMauiContext context, CameraLocation cameraLocation)
		{
			Context = context;
			CameraLocation = cameraLocation;
		}

		protected readonly IMauiContext Context;
		public event EventHandler<CameraFrameBufferEventArgs> FrameReady;

		public CameraLocation CameraLocation { get; private set; }

		public void UpdateCameraLocation(CameraLocation cameraLocation)
		{
			CameraLocation = cameraLocation;

			UpdateCamera();
		}

		public async Task<bool> CheckPermissions()
			=> (await Microsoft.Maui.Essentials.Permissions.RequestAsync<Microsoft.Maui.Essentials.Permissions.Camera>()) == Microsoft.Maui.Essentials.PermissionStatus.Granted;

#if !ANDROID && !IOS && !MACCATALYST
		public NativePlatformCameraPreviewView CreateNativeView() => throw new NotImplementedException();

		public void Connect() => throw new NotImplementedException();

		public void Disconnect() => throw new NotImplementedException();

		public void UpdateCamera() => throw new NotImplementedException();

		public void UpdateTorch(bool on) => throw new NotImplementedException();

		public void Focus(Point point) => throw new NotImplementedException();

		public void AutoFocus() => throw new NotImplementedException();

		public void Dispose() => throw new NotImplementedException();
#endif
	}
}
