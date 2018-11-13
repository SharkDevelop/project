﻿using System;
using System.Net.Http;
using System.Text;
using Foundation;
using UIKit;
using DataUtils;

namespace pbDispatcher.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		public override UIWindow Window {
			get;
			set;
		}

		public override void OnResignActivation (UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate (UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}


		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{


			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0))
			{
				var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes (
											   UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null
										   );

				UIApplication.SharedApplication.RegisterUserNotificationSettings (notificationSettings);
				UIApplication.SharedApplication.RegisterForRemoteNotifications ();

				//new UIAlertView ("RegisterForRemoteNotifications", "RegisterForRemoteNotifications", null, "OK", null).Show ();

			} else {
				//==== register for remote notifications and get the device token
				// set what kind of notification types we want
				UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge;
				// register for remote notifications
				UIApplication.SharedApplication.RegisterForRemoteNotificationTypes (notificationTypes);
			}

			return true;
		}

		public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
		{
            DataManager.SheduleSetDeviceTokenRequest (deviceToken.ToString().Replace("<", "").Replace(">", "").Replace(" ", ""), null);
		}

		public override void DidReceiveRemoteNotification (UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
		{
//			base.DidReceiveRemoteNotification (application, userInfo, completionHandler);
//			new UIAlertView ("", userInfo.Values[0].ValueForKey (new NSString ("alert")).ToString(), null, "OK", null).Show ();
		}
	}
}
